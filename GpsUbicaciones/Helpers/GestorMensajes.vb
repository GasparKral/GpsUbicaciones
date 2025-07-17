Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraWaitForm

''' <summary>
''' Módulo que gestiona los mensajes del sistema, incluyendo mensajes de error, advertencia e información.
''' </summary>
Module GestorMensajes
    ''' <summary>
    ''' Enumeración que define los tipos de mensajes disponibles.
    ''' </summary>
    Public Enum TipoMensaje
        ''' <summary>
        ''' Mensaje de tipo Error
        ''' </summary>
        [Error]
        ''' <summary>
        ''' Mensaje de tipo Advertencia
        ''' </summary>
        Advertencia
        ''' <summary>
        ''' Mensaje de tipo Información
        ''' </summary>
        Informacion
        ''' <summary>
        ''' Mensaje de tipo Debug
        ''' </summary>
        Debug
    End Enum

    ' Constantes para títulos por defecto
    Private Const TITULO_ERROR_POR_DEFECTO As String = "Error"
    Private Const TITULO_ADVERTENCIA_POR_DEFECTO As String = "Advertencia"
    Private Const TITULO_INFORMACION_POR_DEFECTO As String = "Información"
    Private Const TITULO_DEBUG_POR_DEFECTO As String = "Debug"

    ' Constantes para estilos
    Private Const ANCHO_MENSAJE As Integer = 600
    Private Const FUENTE_NOMBRE As String = "Roboto"
    Private Const FUENTE_TAMAÑO As Integer = 12

    ' Constantes para mensajes de espera
    Private Const TIMEOUT_ESPERA_DEFECTO As Integer = 5000 ' 5 segundos
    Private Const MENSAJE_ESPERA_DEFECTO As String = "Procesando, por favor espere..."

    ''' <summary>
    ''' Clase factory para mostrar mensajes al usuario
    ''' </summary>
    Public Class FabricaMensajes
        ' Variables estáticas para controlar mensajes de espera
        Private Shared _timerEspera As Timer = Nothing
        Private Shared _lockObject As New Object()
        Private Shared _waitFormVisible As Boolean = False

        ''' <summary>
        ''' Muestra un mensaje al usuario con el tipo especificado
        ''' </summary>
        ''' <param name="messageType">Tipo de mensaje a mostrar</param>
        ''' <param name="content">Contenido del mensaje</param>
        ''' <param name="customTitle">Título personalizado (opcional)</param>
        Public Shared Sub MostrarMensaje(messageType As TipoMensaje, content As String, Optional customTitle As String = Nothing)
            Dim title As String = If(customTitle, GetDefaultTitle(messageType))

            ' Crear argumentos para el mensaje
            Dim args As New XtraMessageBoxArgs() With {
                .Caption = title,
                .Text = content,
                .Buttons = New DialogResult() {DialogResult.OK}
            }

            ' Configurar ícono según el tipo
            Select Case messageType
                Case TipoMensaje.Error
                    args.ImageOptions.Image = SystemIcons.Error.ToBitmap()
                Case TipoMensaje.Advertencia
                    args.ImageOptions.Image = SystemIcons.Warning.ToBitmap()
                Case TipoMensaje.Informacion
                    args.ImageOptions.Image = SystemIcons.Information.ToBitmap()
                Case TipoMensaje.Debug
                    ' Sin ícono para Debug
                Case Else
                    Throw New ArgumentException("Tipo de mensaje no válido")
            End Select

            ' Configurar evento para personalizar apariencia
            AddHandler args.Showing, AddressOf ConfigurarAparienciaMensaje

            XtraMessageBox.Show(args)
        End Sub

        ''' <summary>
        ''' Muestra un mensaje de confirmación al usuario
        ''' </summary>
        ''' <param name="content">Contenido del mensaje</param>
        ''' <param name="customTitle">Título personalizado (opcional)</param>
        ''' <returns>True si el usuario selecciona Sí, False en caso contrario</returns>
        Public Shared Function MostrarConfirmacion(content As String, Optional customTitle As String = "Confirmación") As Boolean
            ' Crear argumentos para el mensaje
            Dim args As New XtraMessageBoxArgs() With {
                .Caption = customTitle,
                .Text = content,
                .Buttons = New DialogResult() {DialogResult.Yes, DialogResult.No}
            }

            ' Configurar ícono de pregunta
            args.ImageOptions.Image = SystemIcons.Question.ToBitmap()

            ' Configurar evento para personalizar apariencia
            AddHandler args.Showing, AddressOf ConfigurarAparienciaMensaje

            Dim result As DialogResult = XtraMessageBox.Show(args)
            Return result = DialogResult.Yes
        End Function

        ''' <summary>
        ''' Muestra un mensaje con opciones Sí/No/Cancelar
        ''' </summary>
        ''' <param name="content">Contenido del mensaje</param>
        ''' <param name="customTitle">Título personalizado (opcional)</param>
        ''' <returns>DialogResult con la opción seleccionada</returns>
        Public Shared Function MostrarConfirmacionConCancelar(content As String, Optional customTitle As String = "Confirmación") As DialogResult
            ' Crear argumentos para el mensaje
            Dim args As New XtraMessageBoxArgs() With {
                .Caption = customTitle,
                .Text = content,
                .Buttons = New DialogResult() {DialogResult.Yes, DialogResult.No, DialogResult.Cancel}
            }

            ' Configurar ícono de pregunta
            args.ImageOptions.Image = SystemIcons.Question.ToBitmap()

            ' Configurar evento para personalizar apariencia
            AddHandler args.Showing, AddressOf ConfigurarAparienciaMensaje

            Return XtraMessageBox.Show(args)
        End Function

        ''' <summary>
        ''' Muestra un mensaje de espera con WaitForm usando SplashScreenManager estático
        ''' </summary>
        ''' <param name="parentForm">Formulario padre (opcional)</param>
        ''' <param name="mensaje">Mensaje a mostrar (opcional)</param>
        ''' <param name="descripcion">Descripción del mensaje (opcional)</param>
        ''' <param name="maxTimeout">Tiempo máximo de espera en milisegundos (opcional, por defecto 5000)</param>
        ''' <param name="waitFormType">Tipo de WaitForm personalizado (opcional)</param>
        Public Shared Sub MostrarMensajeEspera(Optional parentForm As Form = Nothing,
                                             Optional mensaje As String = Nothing,
                                             Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                             Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO,
                                             Optional waitFormType As Type = Nothing)
            SyncLock _lockObject
                Try
                    ' Cerrar mensaje anterior si existe
                    CerrarMensajeEspera()

                    ' Determinar el tipo de WaitForm a usar
                    Dim formType As Type = If(waitFormType, GetType(WaitForm))


                    SplashScreenManager.ShowForm(parentForm, formType, True, True, False)

                    ' Configurar caption y descripción si se proporcionan
                    If Not String.IsNullOrEmpty(mensaje) Then
                        SplashScreenManager.Default?.SetWaitFormCaption(mensaje)
                    End If

                    If Not String.IsNullOrEmpty(descripcion) Then
                        SplashScreenManager.Default?.SetWaitFormDescription(descripcion)
                    End If

                    _waitFormVisible = True

                    ' Configurar timer para timeout automático
                    If maxTimeout > 0 Then
                        _timerEspera = New Timer(AddressOf TimeoutCallback, Nothing, maxTimeout, Timeout.Infinite)
                    End If

                Catch ex As Exception
                    ' En caso de error, registrar y continuar
                    System.Diagnostics.Debug.WriteLine($"Error al mostrar mensaje de espera: {ex.Message}")
                    _waitFormVisible = False
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Muestra un mensaje de espera usando un SplashScreenManager específico
        ''' </summary>
        ''' <param name="splashManager">SplashScreenManager específico a usar</param>
        ''' <param name="mensaje">Mensaje a mostrar (opcional)</param>
        ''' <param name="descripcion">Descripción del mensaje (opcional)</param>
        ''' <param name="maxTimeout">Tiempo máximo de espera en milisegundos (opcional, por defecto 5000)</param>
        Public Shared Sub MostrarMensajeEspera(splashManager As SplashScreenManager,
                                             Optional mensaje As String = Nothing,
                                             Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                             Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO)
            SyncLock _lockObject
                Try
                    ' Cerrar mensaje anterior si existe
                    CerrarMensajeEspera()

                    ' Mostrar WaitForm usando el SplashScreenManager específico
                    splashManager.ShowWaitForm()

                    ' Configurar caption y descripción si se proporcionan
                    If Not String.IsNullOrEmpty(mensaje) Then
                        splashManager.SetWaitFormCaption(mensaje)
                    End If

                    If Not String.IsNullOrEmpty(descripcion) Then
                        splashManager.SetWaitFormDescription(descripcion)
                    End If

                    _waitFormVisible = True

                    ' Configurar timer para timeout automático
                    If maxTimeout > 0 Then
                        _timerEspera = New Timer(AddressOf TimeoutCallback, Nothing, maxTimeout, Timeout.Infinite)
                    End If

                Catch ex As Exception
                    ' En caso de error, registrar y continuar
                    System.Diagnostics.Debug.WriteLine($"Error al mostrar mensaje de espera: {ex.Message}")
                    _waitFormVisible = False
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Actualiza el caption del mensaje de espera actual
        ''' </summary>
        ''' <param name="nuevoCaption">Nuevo caption del mensaje</param>
        Public Shared Sub ActualizarCaptionMensajeEspera(nuevoCaption As String)
            SyncLock _lockObject
                Try
                    If _waitFormVisible AndAlso SplashScreenManager.Default IsNot Nothing Then
                        SplashScreenManager.Default.SetWaitFormCaption(nuevoCaption)
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al actualizar caption del mensaje de espera: {ex.Message}")
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Actualiza la descripción del mensaje de espera actual
        ''' </summary>
        ''' <param name="nuevaDescripcion">Nueva descripción del mensaje</param>
        Public Shared Sub ActualizarDescripcionMensajeEspera(nuevaDescripcion As String)
            SyncLock _lockObject
                Try
                    If _waitFormVisible AndAlso SplashScreenManager.Default IsNot Nothing Then
                        SplashScreenManager.Default.SetWaitFormDescription(nuevaDescripcion)
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al actualizar descripción del mensaje de espera: {ex.Message}")
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Actualiza tanto el caption como la descripción del mensaje de espera actual
        ''' </summary>
        ''' <param name="nuevoCaption">Nuevo caption del mensaje</param>
        ''' <param name="nuevaDescripcion">Nueva descripción del mensaje</param>
        Public Shared Sub ActualizarMensajeEspera(nuevoCaption As String, nuevaDescripcion As String)
            SyncLock _lockObject
                Try
                    If _waitFormVisible AndAlso SplashScreenManager.Default IsNot Nothing Then
                        SplashScreenManager.Default.SetWaitFormCaption(nuevoCaption)
                        SplashScreenManager.Default.SetWaitFormDescription(nuevaDescripcion)
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al actualizar mensaje de espera: {ex.Message}")
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Envía un comando personalizado al WaitForm actual
        ''' </summary>
        ''' <param name="command">Comando a enviar</param>
        ''' <param name="parameter">Parámetro del comando (opcional)</param>
        Public Shared Sub EnviarComandoMensajeEspera(command As [Enum], Optional parameter As Object = Nothing)
            SyncLock _lockObject
                Try
                    If _waitFormVisible AndAlso SplashScreenManager.Default IsNot Nothing Then
                        SplashScreenManager.Default.SendCommand(command, parameter)
                    End If
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al enviar comando al mensaje de espera: {ex.Message}")
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Cierra el mensaje de espera actual
        ''' </summary>
        Public Shared Sub CerrarMensajeEspera()
            SyncLock _lockObject
                Try
                    ' Detener timer si existe
                    If _timerEspera IsNot Nothing Then
                        _timerEspera.Dispose()
                        _timerEspera = Nothing
                    End If

                    ' Cerrar mensaje de espera si existe
                    If _waitFormVisible Then
                        SplashScreenManager.CloseForm(False)
                        _waitFormVisible = False
                    End If

                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al cerrar mensaje de espera: {ex.Message}")
                    ' Forzar limpieza en caso de error
                    _waitFormVisible = False
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Cierra el mensaje de espera usando un SplashScreenManager específico
        ''' </summary>
        ''' <param name="splashManager">SplashScreenManager específico a usar</param>
        Public Shared Sub CerrarMensajeEspera(splashManager As SplashScreenManager)
            SyncLock _lockObject
                Try
                    ' Detener timer si existe
                    If _timerEspera IsNot Nothing Then
                        _timerEspera.Dispose()
                        _timerEspera = Nothing
                    End If

                    ' Cerrar mensaje de espera si existe
                    If _waitFormVisible Then
                        splashManager.CloseWaitForm()
                        _waitFormVisible = False
                    End If

                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al cerrar mensaje de espera: {ex.Message}")
                    ' Forzar limpieza en caso de error
                    _waitFormVisible = False
                End Try
            End SyncLock
        End Sub

        ''' <summary>
        ''' Verifica si hay un mensaje de espera visible
        ''' </summary>
        ''' <returns>True si hay un mensaje de espera visible</returns>
        Public Shared ReadOnly Property EsMensajeEsperaVisible As Boolean
            Get
                SyncLock _lockObject
                    Try
                        Return _waitFormVisible AndAlso SplashScreenManager.Default?.IsSplashFormVisible = True
                    Catch
                        Return _waitFormVisible
                    End Try
                End SyncLock
            End Get
        End Property

        ''' <summary>
        ''' Callback para el timeout del timer
        ''' </summary>
        ''' <param name="state">Estado del timer</param>
        Private Shared Sub TimeoutCallback(state As Object)
            Try
                CerrarMensajeEspera()
                ' Opcional: mostrar mensaje de timeout
                System.Diagnostics.Debug.WriteLine("Timeout: Mensaje de espera cerrado automáticamente")
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"Error en timeout callback: {ex.Message}")
            End Try
        End Sub

        ''' <summary>
        ''' Ejecuta una acción con mensaje de espera
        ''' </summary>
        ''' <param name="accion">Acción a ejecutar</param>
        ''' <param name="parentForm">Formulario padre (opcional)</param>
        ''' <param name="mensaje">Mensaje de espera (opcional)</param>
        ''' <param name="descripcion">Descripción de espera (opcional)</param>
        ''' <param name="maxTimeout">Timeout máximo (opcional)</param>
        Public Shared Sub EjecutarConMensajeEspera(accion As Action,
                                                 Optional parentForm As Form = Nothing,
                                                 Optional mensaje As String = Nothing,
                                                 Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                                 Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO)
            Try
                ' Mostrar mensaje de espera
                MostrarMensajeEspera(parentForm, mensaje, descripcion, maxTimeout)

                ' Ejecutar la acción
                accion.Invoke()

            Catch ex As Exception
                ' Re-lanzar la excepción para que la maneje el código llamador
                Throw
            Finally
                ' Siempre cerrar el mensaje de espera
                CerrarMensajeEspera()
            End Try
        End Sub

        ''' <summary>
        ''' Ejecuta una acción con mensaje de espera usando un SplashScreenManager específico
        ''' </summary>
        ''' <param name="accion">Acción a ejecutar</param>
        ''' <param name="splashManager">SplashScreenManager específico a usar</param>
        ''' <param name="mensaje">Mensaje de espera (opcional)</param>
        ''' <param name="descripcion">Descripción de espera (opcional)</param>
        ''' <param name="maxTimeout">Timeout máximo (opcional)</param>
        Public Shared Sub EjecutarConMensajeEspera(accion As Action,
                                                 splashManager As SplashScreenManager,
                                                 Optional mensaje As String = Nothing,
                                                 Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                                 Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO)
            Try
                ' Mostrar mensaje de espera
                MostrarMensajeEspera(splashManager, mensaje, descripcion, maxTimeout)

                ' Ejecutar la acción
                accion.Invoke()

            Catch ex As Exception
                ' Re-lanzar la excepción para que la maneje el código llamador
                Throw
            Finally
                ' Siempre cerrar el mensaje de espera
                CerrarMensajeEspera(splashManager)
            End Try
        End Sub

        ''' <summary>
        ''' Ejecuta una función con mensaje de espera y devuelve el resultado
        ''' </summary>
        ''' <typeparam name="T">Tipo de retorno</typeparam>
        ''' <param name="funcion">Función a ejecutar</param>
        ''' <param name="parentForm">Formulario padre (opcional)</param>
        ''' <param name="mensaje">Mensaje de espera (opcional)</param>
        ''' <param name="descripcion">Descripción de espera (opcional)</param>
        ''' <param name="maxTimeout">Timeout máximo (opcional)</param>
        ''' <returns>Resultado de la función</returns>
        Public Shared Function EjecutarConMensajeEspera(Of T)(funcion As Func(Of T),
                                                             Optional parentForm As Form = Nothing,
                                                             Optional mensaje As String = Nothing,
                                                             Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                                             Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO) As T
            Try
                ' Mostrar mensaje de espera
                MostrarMensajeEspera(parentForm, mensaje, descripcion, maxTimeout)

                ' Ejecutar la función y devolver el resultado
                Return funcion.Invoke()

            Catch ex As Exception
                ' Re-lanzar la excepción para que la maneje el código llamador
                Throw
            Finally
                ' Siempre cerrar el mensaje de espera
                CerrarMensajeEspera()
            End Try
        End Function

        ''' <summary>
        ''' Ejecuta una función con mensaje de espera usando un SplashScreenManager específico y devuelve el resultado
        ''' </summary>
        ''' <typeparam name="T">Tipo de retorno</typeparam>
        ''' <param name="funcion">Función a ejecutar</param>
        ''' <param name="splashManager">SplashScreenManager específico a usar</param>
        ''' <param name="mensaje">Mensaje de espera (opcional)</param>
        ''' <param name="descripcion">Descripción de espera (opcional)</param>
        ''' <param name="maxTimeout">Timeout máximo (opcional)</param>
        ''' <returns>Resultado de la función</returns>
        Public Shared Function EjecutarConMensajeEspera(Of T)(funcion As Func(Of T),
                                                             splashManager As SplashScreenManager,
                                                             Optional mensaje As String = Nothing,
                                                             Optional descripcion As String = MENSAJE_ESPERA_DEFECTO,
                                                             Optional maxTimeout As Integer = TIMEOUT_ESPERA_DEFECTO) As T
            Try
                ' Mostrar mensaje de espera
                MostrarMensajeEspera(splashManager, mensaje, descripcion, maxTimeout)

                ' Ejecutar la función y devolver el resultado
                Return funcion.Invoke()

            Catch ex As Exception
                ' Re-lanzar la excepción para que la maneje el código llamador
                Throw
            Finally
                ' Siempre cerrar el mensaje de espera
                CerrarMensajeEspera(splashManager)
            End Try
        End Function

        ''' <summary>
        ''' Muestra un cuadro de diálogo para solicitar datos al usuario (InputBox)
        ''' </summary>
        ''' <param name="prompt">Texto que se muestra al usuario</param>
        ''' <param name="title">Título del cuadro de diálogo</param>
        ''' <param name="defaultValue">Valor por defecto en el campo de texto</param>
        ''' <returns>El texto ingresado por el usuario, o String.Empty si se cancela</returns>
        Public Shared Function SolicitarDatos(prompt As String, Optional title As String = "Entrada de datos", Optional defaultValue As String = "") As String
            Using inputForm As New Form()
                ' Configurar propiedades del formulario
                inputForm.Text = title
                inputForm.Width = ANCHO_MENSAJE
                inputForm.Height = 180
                inputForm.StartPosition = FormStartPosition.CenterParent
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog
                inputForm.MaximizeBox = False
                inputForm.MinimizeBox = False
                inputForm.AutoSize = True
                inputForm.AutoSizeMode = AutoSizeMode.GrowAndShrink
                inputForm.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Bold)

                ' Crear etiqueta para el prompt
                Dim lblPrompt As New LabelControl()
                lblPrompt.Text = prompt
                lblPrompt.Location = New Point(12, 15)
                lblPrompt.Size = New Size(ANCHO_MENSAJE - 40, 40)
                lblPrompt.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Regular)
                lblPrompt.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                lblPrompt.AutoSizeMode = LabelAutoSizeMode.Vertical

                ' Crear campo de texto
                Dim txtInput As New TextEdit()
                txtInput.Text = defaultValue
                txtInput.Location = New Point(12, lblPrompt.Bottom + 10)
                txtInput.Size = New Size(ANCHO_MENSAJE - 40, 23)
                txtInput.Properties.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Regular)

                ' Crear botones
                Dim btnOK As New SimpleButton()
                btnOK.Text = "Aceptar"
                btnOK.DialogResult = DialogResult.OK
                btnOK.Size = New Size(80, 30)
                btnOK.Location = New Point(ANCHO_MENSAJE - 180, txtInput.Bottom + 15)
                btnOK.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Regular)

                Dim btnCancel As New SimpleButton()
                btnCancel.Text = "Cancelar"
                btnCancel.DialogResult = DialogResult.Cancel
                btnCancel.Size = New Size(80, 30)
                btnCancel.Location = New Point(ANCHO_MENSAJE - 90, txtInput.Bottom + 15)
                btnCancel.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Regular)

                ' Agregar controles al formulario
                inputForm.Controls.AddRange(New Control() {lblPrompt, txtInput, btnOK, btnCancel})

                ' Configurar botones por defecto
                inputForm.AcceptButton = btnOK
                inputForm.CancelButton = btnCancel

                ' Ajustar altura del formulario
                inputForm.Height = btnOK.Bottom + 50

                ' Enfocar el campo de texto y seleccionar todo el texto
                txtInput.Focus()
                txtInput.SelectAll()

                ' Mostrar el formulario y devolver el resultado
                If inputForm.ShowDialog() = DialogResult.OK Then
                    Return txtInput.Text
                Else
                    Return String.Empty
                End If
            End Using
        End Function

        ''' <summary>
        ''' Configura la apariencia del XtraMessageBox usando el evento Showing
        ''' </summary>
        ''' <param name="sender">Objeto que envía el evento</param>
        ''' <param name="e">Argumentos del evento</param>
        Private Shared Sub ConfigurarAparienciaMensaje(sender As Object, e As XtraMessageShowingArgs)
            ' Configurar el ancho del formulario
            e.MessageBoxForm.MaximumSize = New Size(ANCHO_MENSAJE, 650)

            ' Configurar fuente del título (caption) - Bold
            e.MessageBoxForm.Appearance.FontStyleDelta = FontStyle.Bold
            e.MessageBoxForm.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Bold)

            ' Configurar fuente del texto del mensaje
            For Each control As Control In e.MessageBoxForm.Controls
                If TypeOf control Is LabelControl Then
                    Dim label As LabelControl = CType(control, LabelControl)
                    label.Appearance.Font = New Font(FUENTE_NOMBRE, FUENTE_TAMAÑO, FontStyle.Regular)
                End If
            Next
        End Sub

        ''' <summary>
        ''' Obtiene el título por defecto según el tipo de mensaje
        ''' </summary>
        ''' <param name="messageType">Tipo de mensaje</param>
        ''' <returns>El título correspondiente al tipo de mensaje</returns>
        Private Shared Function GetDefaultTitle(messageType As TipoMensaje) As String
            Select Case messageType
                Case TipoMensaje.Error
                    Return TITULO_ERROR_POR_DEFECTO
                Case TipoMensaje.Advertencia
                    Return TITULO_ADVERTENCIA_POR_DEFECTO
                Case TipoMensaje.Informacion
                    Return TITULO_INFORMACION_POR_DEFECTO
                Case TipoMensaje.Debug
                    Return TITULO_DEBUG_POR_DEFECTO
                Case Else
                    Throw New ArgumentException("Tipo de mensaje no válido")
            End Select
        End Function

        ''' <summary>
        ''' Limpia todos los recursos utilizados por los mensajes de espera
        ''' </summary>
        Public Shared Sub LimpiarRecursos()
            SyncLock _lockObject
                Try
                    CerrarMensajeEspera()
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error al limpiar recursos: {ex.Message}")
                End Try
            End SyncLock
        End Sub
    End Class
End Module