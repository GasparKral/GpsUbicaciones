Imports System.Configuration
Imports System.IO
Imports System.Threading

Public Enum LogLevel
    Debug = 0
    Info = 1
    Warning = 2
    [Error] = 3
    Fatal = 4
End Enum

Public Enum LogType
    File = 0
    Console = 1
    Both = 2
End Enum

Public Class Logger
    Implements IDisposable

    Private Shared ReadOnly _lock As New Object()
    Private Shared _instance As Logger = Nothing
    Private _isDebug As Boolean = False
    Private _logFile As String
    Private _minLogLevel As LogLevel = LogLevel.Info
    Private _maxFileSize As Long = 10 * 1024 * 1024 ' 10MB
    Private _disposed As Boolean = False

    Private Sub New()
        Try
            ' Cargar configuración una sola vez
            _isDebug = Boolean.Parse(If(ConfigurationManager.AppSettings("debug"), "false"))
            _logFile = If(ConfigurationManager.AppSettings("logFile"), "application.log")

            ' Configurar nivel mínimo de log
            Dim minLevel As String = If(ConfigurationManager.AppSettings("minLogLevel"), "Info")
            [Enum].TryParse(minLevel, _minLogLevel)

            ' Configurar tamaño máximo de archivo
            Dim maxSize As String = ConfigurationManager.AppSettings("maxLogFileSize")
            If Not String.IsNullOrEmpty(maxSize) Then
                Long.TryParse(maxSize, _maxFileSize)
            End If

            ' Crear directorio si no existe
            Dim logDir As String = Path.GetDirectoryName(_logFile)
            If Not String.IsNullOrEmpty(logDir) AndAlso Not Directory.Exists(logDir) Then
                Directory.CreateDirectory(logDir)
            End If

        Catch ex As Exception
            ' Si falla la configuración, usar valores por defecto
            Console.WriteLine($"Error loading logger configuration: {ex.Message}")
            _isDebug = False
            _logFile = "application.log"
            _minLogLevel = LogLevel.Info
        End Try
    End Sub

    Public Shared ReadOnly Property Instance() As Logger
        Get
            If _instance Is Nothing Then
                SyncLock _lock
                    If _instance Is Nothing Then
                        _instance = New Logger()
                    End If
                End SyncLock
            End If
            Return _instance
        End Get
    End Property

    Private Function ShouldLog(level As LogLevel) As Boolean
        ' No logear DEBUG si no está habilitado
        If Not _isDebug AndAlso level = LogLevel.Debug Then
            Return False
        End If

        ' Verificar nivel mínimo
        Return level >= _minLogLevel
    End Function

    Private Function LineHeaderBuilder(level As LogLevel, caller As String) As String
        Dim timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
        Dim threadId = Thread.CurrentThread.ManagedThreadId
        Dim levelText As String = GetLevelText(level)

        Return $"[{timestamp}] [{threadId:D3}] [{levelText,-7}] [{caller}]"
    End Function

    Private Function GetLevelText(level As LogLevel) As String
        Select Case level
            Case LogLevel.Debug
                Return "DEBUG"
            Case LogLevel.Info
                Return "INFO"
            Case LogLevel.Warning
                Return "WARN"
            Case LogLevel.[Error]
                Return "ERROR"
            Case LogLevel.Fatal
                Return "FATAL"
            Case Else
                Return "UNKNOWN"
        End Select
    End Function

    Private Function LogLineBuilder(level As LogLevel, message As String, caller As String) As String
        Return $"{LineHeaderBuilder(level, caller)} {message}"
    End Function

    Private Sub RotateLogIfNeeded()
        Try
            If File.Exists(_logFile) Then
                Dim fileInfo As New FileInfo(_logFile)
                If fileInfo.Length > _maxFileSize Then
                    Dim backupFile = $"{_logFile}.{DateTime.Now:yyyyMMdd_HHmmss}.bak"
                    File.Move(_logFile, backupFile)
                End If
            End If
        Catch ex As Exception
            ' No fallar si no se puede rotar el log
            Console.WriteLine($"Warning: Could not rotate log file: {ex.Message}")
        End Try
    End Sub

    Public Sub Log(level As LogLevel, message As String, caller As String, Optional logType As LogType = LogType.Console)
        If _disposed Then Return
        If Not ShouldLog(level) Then Return
        If String.IsNullOrWhiteSpace(message) Then Return

        Try
            Dim logLine = LogLineBuilder(level, message, caller)

            SyncLock _lock
                Select Case logType
                    Case LogType.File
                        WriteToFile(logLine)
                    Case LogType.Console
                        WriteToConsole(logLine, level)
                    Case LogType.Both
                        WriteToFile(logLine)
                        WriteToConsole(logLine, level)
                End Select
            End SyncLock

        Catch ex As Exception
            ' Fallback: al menos intentar escribir a consola
            Try
                Console.WriteLine($"Logger Error: {ex.Message}")
                Console.WriteLine($"Original message: {message}")
            Catch
                ' Si todo falla, no hacer nada para evitar crashes
            End Try
        End Try
    End Sub

    Private Sub WriteToFile(logLine As String)
        Try
            RotateLogIfNeeded()
            Using writer As New StreamWriter(_logFile, True, System.Text.Encoding.UTF8)
                writer.WriteLine(logLine)
                writer.Flush()
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error writing to log file: {ex.Message}")
        End Try
    End Sub

    Private Sub WriteToConsole(logLine As String, level As LogLevel)
        Try
            ' Colorear según el nivel
            Dim originalColor = Console.ForegroundColor
            Select Case level
                Case LogLevel.Debug
                    Console.ForegroundColor = ConsoleColor.Gray
                Case LogLevel.Info
                    Console.ForegroundColor = ConsoleColor.White
                Case LogLevel.Warning
                    Console.ForegroundColor = ConsoleColor.Yellow
                Case LogLevel.[Error], LogLevel.Fatal
                    Console.ForegroundColor = ConsoleColor.Red
            End Select

            Console.WriteLine(logLine)
            Console.ForegroundColor = originalColor

        Catch ex As Exception
            ' Fallback sin colores
            Console.WriteLine(logLine)
        End Try
    End Sub

    ' Métodos de conveniencia
    Public Sub Debug(message As String, Optional caller As String = "", Optional logType As LogType = LogType.Console)
        If String.IsNullOrEmpty(caller) Then caller = GetCallerName()
        Log(LogLevel.Debug, message, caller, logType)
    End Sub

    Public Sub Info(message As String, Optional caller As String = "", Optional logType As LogType = LogType.Both)
        If String.IsNullOrEmpty(caller) Then caller = GetCallerName()
        Log(LogLevel.Info, message, caller, logType)
    End Sub

    Public Sub Warning(message As String, Optional caller As String = "", Optional logType As LogType = LogType.Both)
        If String.IsNullOrEmpty(caller) Then caller = GetCallerName()
        Log(LogLevel.Warning, message, caller, logType)
    End Sub

    Public Sub [Error](message As String, Optional ex As Exception = Nothing, Optional caller As String = "", Optional logType As LogType = LogType.Both)
        If String.IsNullOrEmpty(caller) Then caller = GetCallerName()
        Dim fullMessage = If(ex IsNot Nothing, $"{message} | Exception: {ex}", message)
        Log(LogLevel.[Error], fullMessage, caller, logType)
    End Sub

    Public Sub Fatal(message As String, Optional ex As Exception = Nothing, Optional caller As String = "", Optional logType As LogType = LogType.Both)
        If String.IsNullOrEmpty(caller) Then caller = GetCallerName()
        Dim fullMessage = If(ex IsNot Nothing, $"{message} | Exception: {ex}", message)
        Log(LogLevel.Fatal, fullMessage, caller, logType)
    End Sub

    Private Function GetCallerName() As String
        Try
            Dim stackTrace As New System.Diagnostics.StackTrace()
            Dim frame = stackTrace.GetFrame(2) ' 2 niveles arriba
            If frame IsNot Nothing Then
                Dim method = frame.GetMethod()
                Return $"{method.DeclaringType.Name}.{method.Name}"
            End If
        Catch
            ' Si falla, devolver string genérico
        End Try
        Return "Unknown"
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not _disposed Then
            If disposing Then
                ' Cleanup managed resources si los hubiera
            End If
            _disposed = True
        End If
    End Sub

End Class