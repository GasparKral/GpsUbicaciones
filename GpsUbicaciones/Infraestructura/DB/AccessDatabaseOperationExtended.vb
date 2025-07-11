Imports System.Data.OleDb

''' <summary>
''' Extensión de AccessDatabaseOperation que agrega soporte completo para transacciones
''' sin cerrar conexiones automáticamente
''' </summary>
Public Class AccessDatabaseOperationExtended
    Inherits AccessDatabaseOperation

    Private Shared ReadOnly Logger As Logger = Logger.Instance

    Public Sub New(settings As DatabaseSettings)
        MyBase.New(settings)
    End Sub

    ''' <summary>
    ''' Sobrecarga de ExecuteNonQuery que acepta transacción y no cierra la conexión
    ''' </summary>
    Public Overloads Function ExecuteNonQuery(connection As IDbConnection,
                                             transaction As IDbTransaction,
                                             commandText As String,
                                             ParamArray parameters() As Object) As Integer
        Logger.Debug($"Ejecutando comando NonQuery con transacción: {commandText.Substring(0, Math.Min(100, commandText.Length))}...")

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                If transaction IsNot Nothing Then
                    cmd.Transaction = CType(transaction, OleDbTransaction)
                End If

                AddParametersExtended(cmd, parameters)
                Dim rowsAffected = cmd.ExecuteNonQuery()
                Logger.Debug($"Comando ejecutado exitosamente. Filas afectadas: {rowsAffected}")
                Return rowsAffected
            End Using

        Catch ex As Exception
            Logger.Error($"Error ejecutando comando: {commandText}", ex)
            Throw New DatabaseOperationException("Error al ejecutar comando", ex, commandText)
        End Try
        ' *** NO cerrar la conexión aquí ***
    End Function

    ''' <summary>
    ''' Sobrecarga de ExecuteQuery que acepta transacción y no cierra la conexión
    ''' </summary>
    Public Overloads Function ExecuteQuery(connection As IDbConnection,
                                          transaction As IDbTransaction,
                                          commandText As String,
                                          ParamArray parameters() As Object) As DataSet
        Dim ds = New DataSet()
        Logger.Debug($"Ejecutando consulta con transacción: {commandText.Substring(0, Math.Min(100, commandText.Length))}...")

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                If transaction IsNot Nothing Then
                    cmd.Transaction = CType(transaction, OleDbTransaction)
                End If

                AddParametersExtended(cmd, parameters)

                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(ds)
                End Using
            End Using

            Logger.Debug($"Consulta ejecutada exitosamente. Tablas devueltas: {ds.Tables.Count}")
            Return ds

        Catch ex As Exception
            Logger.Error($"Error ejecutando consulta: {commandText}", ex)
            Throw New DatabaseOperationException("Error al ejecutar consulta", ex, commandText)
        End Try
        ' *** NO cerrar la conexión aquí ***
    End Function

    ''' <summary>
    ''' Sobrecarga de ExecuteTable que acepta transacción y no cierra la conexión
    ''' </summary>
    Public Overloads Function ExecuteTable(connection As IDbConnection,
                                          transaction As IDbTransaction,
                                          commandText As String,
                                          ParamArray parameters() As Object) As DataTable
        Dim dt = New DataTable()
        Logger.Debug($"Ejecutando tabla con transacción: {commandText.Substring(0, Math.Min(100, commandText.Length))}...")

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                If transaction IsNot Nothing Then
                    cmd.Transaction = CType(transaction, OleDbTransaction)
                End If

                AddParametersExtended(cmd, parameters)

                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            Logger.Debug($"Tabla ejecutada exitosamente. Filas: {dt.Rows.Count}")
            Return dt

        Catch ex As Exception
            Logger.Error($"Error ejecutando tabla: {commandText}", ex)
            Throw New DatabaseOperationException("Error al cargar tabla", ex, commandText, parameters)
        End Try
        ' *** NO cerrar la conexión aquí ***
    End Function

    ''' <summary>
    ''' Sobrecarga de ExecuteScalar que acepta transacción y no cierra la conexión
    ''' </summary>
    Public Overloads Function ExecuteScalar(connection As IDbConnection,
                                           transaction As IDbTransaction,
                                           commandText As String,
                                           closeConnection As Boolean,
                                           ParamArray parameters() As Object) As Boolean
        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                If transaction IsNot Nothing Then
                    cmd.Transaction = CType(transaction, OleDbTransaction)
                End If

                AddParametersExtended(cmd, parameters)
                Dim result = cmd.ExecuteScalar()

                If result Is Nothing OrElse result Is DBNull.Value Then
                    Return False
                End If

                If TypeOf result Is Boolean Then
                    Return CBool(result)
                End If

                If TypeOf result Is Integer Then
                    Return CInt(result) <> 0 ' Access suele devolver -1/0
                End If

                ' Por si acaso, intenta convertir a Boolean
                Return Convert.ToBoolean(result)
            End Using

        Catch ex As Exception
            Throw New DatabaseOperationException("Error al ejecutar ExecuteScalar", ex, commandText)
        Finally
            ' Solo cerrar si se especifica explícitamente
            If closeConnection AndAlso connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

    ''' <summary>
    ''' Método auxiliar para agregar parámetros con mejor manejo de tipos
    ''' </summary>
    Private Sub AddParametersExtended(cmd As OleDbCommand, parameters() As Object)
        If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
            For Each param In parameters
                Dim oleParam As New OleDbParameter()

                If param Is Nothing Then
                    oleParam.Value = DBNull.Value
                    oleParam.OleDbType = OleDbType.VarWChar
                Else
                    ' Detectar el tipo y asignar el OleDbType correcto
                    Select Case param.GetType()
                        Case GetType(DateTime), GetType(Date)
                            oleParam.OleDbType = OleDbType.Date
                            oleParam.Value = param
                        Case GetType(Integer), GetType(Int32)
                            oleParam.OleDbType = OleDbType.Integer
                            oleParam.Value = param
                        Case GetType(Long), GetType(Int64)
                            oleParam.OleDbType = OleDbType.BigInt
                            oleParam.Value = param
                        Case GetType(Single)
                            oleParam.OleDbType = OleDbType.Single
                            oleParam.Value = param
                        Case GetType(Double), GetType(Decimal)
                            oleParam.OleDbType = OleDbType.Double
                            oleParam.Value = param
                        Case GetType(Boolean)
                            oleParam.OleDbType = OleDbType.Boolean
                            oleParam.Value = param
                        Case GetType(Byte())
                            oleParam.OleDbType = OleDbType.Binary
                            oleParam.Value = param
                        Case Else
                            oleParam.OleDbType = OleDbType.VarWChar
                            oleParam.Value = param.ToString()
                    End Select
                End If

                cmd.Parameters.Add(oleParam)
            Next
        End If
    End Sub

    ''' <summary>
    ''' Método utilitario para ejecutar múltiples comandos en una transacción
    ''' </summary>
    Public Function ExecuteMultipleCommands(connection As IDbConnection,
                                           transaction As IDbTransaction,
                                           ParamArray commandsWithParams As (CommandText As String, Parameters As Object())()) As Integer
        Dim totalRowsAffected As Integer = 0

        For Each commandInfo In commandsWithParams
            totalRowsAffected += ExecuteNonQuery(connection, transaction, commandInfo.CommandText, commandInfo.Parameters)
        Next

        Return totalRowsAffected
    End Function

    ''' <summary>
    ''' Método utilitario para verificar si existe un registro
    ''' </summary>
    Public Function ExistsRecord(connection As IDbConnection,
                                transaction As IDbTransaction,
                                commandText As String,
                                ParamArray parameters() As Object) As Boolean
        Try
            Dim result = ExecuteScalar(connection, transaction, commandText, False, parameters)
            Return result
        Catch
            Return False
        End Try
    End Function
End Class