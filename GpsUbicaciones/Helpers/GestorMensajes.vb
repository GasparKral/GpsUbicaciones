Imports DevExpress.XtraEditors

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

    ''' <summary>
    ''' Clase factory para mostrar mensajes al usuario
    ''' </summary>
    Public Class FabricaMensajes
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
    End Class
End Module