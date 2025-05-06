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
    End Enum

    ' Constantes para títulos por defecto
    Private Const TITULO_ERROR_POR_DEFECTO As String = "Error"
    Private Const TITULO_ADVERTENCIA_POR_DEFECTO As String = "Advertencia"
    Private Const TITULO_INFORMACION_POR_DEFECTO As String = "Información"

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
        Public Shared Sub ShowMessage(messageType As TipoMensaje, content As String, Optional customTitle As String = Nothing)
            Dim title As String = If(customTitle, GetDefaultTitle(messageType))

            Select Case messageType
                Case TipoMensaje.Error
                    MsgBox(content, MsgBoxStyle.Critical, title)
                Case TipoMensaje.Advertencia
                    MsgBox(content, MsgBoxStyle.Exclamation, title)
                Case TipoMensaje.Informacion
                    MsgBox(content, MsgBoxStyle.Information, title)
                Case Else
                    Throw New ArgumentException("Tipo de mensaje no válido")
            End Select
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
                Case Else
                    Throw New ArgumentException("Tipo de mensaje no válido")
            End Select
        End Function
    End Class
End Module