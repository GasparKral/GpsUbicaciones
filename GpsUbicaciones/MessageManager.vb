''' <summary>
''' Módulo que gestiona los mensajes del sistema, incluyendo mensajes de error, advertencia e información.
''' </summary>
Module MessageManager
    ''' <summary>
    ''' Enumeración que define los tipos de mensajes disponibles.
    ''' </summary>
    Public Enum MessageType
        ''' <summary>
        ''' Mensaje de tipo Error
        ''' </summary>
        [Error]
        ''' <summary>
        ''' Mensaje de tipo Advertencia
        ''' </summary>
        Warning
        ''' <summary>
        ''' Mensaje de tipo Información
        ''' </summary>
        Information
    End Enum

    ' Constantes para títulos por defecto
    Private Const DEFAULT_ERROR_TITLE As String = "Error"
    Private Const DEFAULT_WARNING_TITLE As String = "Advertencia"
    Private Const DEFAULT_INFORMATION_TITLE As String = "Información"

    ''' <summary>
    ''' Mensaje para cuando no se ha introducido un código de artículo
    ''' </summary>
    Public Const MissingArticleCodeMessage As String = "Introduzca un código de artículo"

    ''' <summary>
    ''' Mensaje para cuando no se ha introducido un código de ubicación
    ''' </summary>
    Public Const MissingLocationCodeMessage As String = "Introduzca un código de ubicación"

    ''' <summary>
    ''' Mensaje para cuando el código de artículo no es válido
    ''' </summary>
    Public Const InvalidArticleCodeMessage As String = "Introduzca un código de artículo válido"

    ''' <summary>
    ''' Mensaje para cuando el código de ubicación no es válido
    ''' </summary>
    Public Const InvalidLocationCodeMessage As String = "Introduzca un código de ubicación válido"

    ''' <summary>
    ''' Mensaje para cuando no hay suficiente stock disponible
    ''' </summary>
    Public Const InsufficientStockMessage As String = "No hay suficiente stock disponible. Stock restante: {0}"

    ''' <summary>
    ''' Mensaje para cuando la cantidad seleccionada es inválida
    ''' </summary>
    Public Const InvalidQuantityMessage As String = "La cantidad seleccionada debe ser mayor a cero"

    ''' <summary>
    ''' Mensaje para cuando se requiere un valor numérico
    ''' </summary>
    Public Const NumericValueRequiredMessage As String = "Debe ingresar un valor numérico"

    ''' <summary>
    ''' Mensaje para cuando el almacén no coincide con la ubicación
    ''' </summary>
    Public Const WarehouseMismatchMessage As String = "EL ALMACEN ASIGNADO A ESTE TERMINAL: {0} NO SE CORRESPONDE CON EL ALMACEN {1} DE ESTA UBICACION"

    ''' <summary>
    ''' Mensaje para cuando el artículo no existe
    ''' </summary>
    Public Const ArticleNotFoundMessage As String = "NO EXISTE ARTICULO CON ESTE CODIGO: {0}"

    ''' <summary>
    ''' Mensaje para cuando la ubicación no existe
    ''' </summary>
    Public Const LocationNotFoundMessage As String = "NO EXISTE UBICACION CON ESTE CODIGO: {0}"

    ''' <summary>
    ''' Mensaje para errores en operaciones de base de datos
    ''' </summary>
    Public Const DatabaseOperationErrorMessage As String = "Error en la operación de base de datos: {0}"

    ''' <summary>
    ''' Mensaje para errores al consultar artículos
    ''' </summary>
    Public Const ArticleQueryErrorMessage As String = "Error al consultar artículos: {0}"

    ''' <summary>
    ''' Mensaje para errores al validar ubicaciones
    ''' </summary>
    Public Const LocationValidationErrorMessage As String = "Error al validar ubicación: {0}"

    ''' <summary>
    ''' Mensaje para errores inesperados
    ''' </summary>
    Public Const UnexpectedErrorMessage As String = "Error inesperado: {0}"

    ''' <summary>
    ''' Mensaje para cuando no se encuentran datos
    ''' </summary>
    Public Const NoDataFoundMessage As String = "No se han encontrado datos para la consulta proporcionada"

    ''' <summary>
    ''' Mensaje para cuando no se ha definido una consulta
    ''' </summary>
    Public Const UndefinedQueryMessage As String = "No se ha definido la consulta a ejecutar"

    ''' <summary>
    ''' Mensaje para cuando el terminal no está definido
    ''' </summary>
    Public Const UndefinedTerminalMessage As String = "Terminal no definido en la base de datos"

    ''' <summary>
    ''' Clase factory para mostrar mensajes al usuario
    ''' </summary>
    Public Class MessageFactory
        ''' <summary>
        ''' Muestra un mensaje al usuario con el tipo especificado
        ''' </summary>
        ''' <param name="messageType">Tipo de mensaje a mostrar</param>
        ''' <param name="content">Contenido del mensaje</param>
        ''' <param name="customTitle">Título personalizado (opcional)</param>
        Public Shared Sub ShowMessage(messageType As MessageType, content As String, Optional customTitle As String = Nothing)
            Dim title As String = If(customTitle, GetDefaultTitle(messageType))

            Select Case messageType
                Case MessageType.Error
                    MsgBox(content, MsgBoxStyle.Critical, title)
                Case MessageType.Warning
                    MsgBox(content, MsgBoxStyle.Exclamation, title)
                Case MessageType.Information
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
        Private Shared Function GetDefaultTitle(messageType As MessageType) As String
            Select Case messageType
                Case MessageType.Error
                    Return DEFAULT_ERROR_TITLE
                Case MessageType.Warning
                    Return DEFAULT_WARNING_TITLE
                Case MessageType.Information
                    Return DEFAULT_INFORMATION_TITLE
                Case Else
                    Throw New ArgumentException("Tipo de mensaje no válido")
            End Select
        End Function
    End Class
End Module