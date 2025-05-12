Module MensajesDeError
    ''' <summary>
    ''' Mensajes relacionados con artículos
    ''' </summary>
    Public Class MensajesArticulos
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de artículo
        ''' </summary>
        Public Const CodigoFaltante As String = "Por favor, introduzca un código de artículo para continuar."

        ''' <summary>
        ''' Mensaje para cuando el código de artículo no es válido
        ''' </summary>
        Public Const CodigoInvalido As String = "El código de artículo proporcionado no es válido. Verifique e intente nuevamente."

        ''' <summary>
        ''' Mensaje para cuando el artículo no existe
        ''' </summary>
        Public Const NoExiste As String = "No se encontró un artículo asociado al código proporcionado: {0}."

        ''' <summary>
        ''' Mensaje para errores al consultar artículos
        ''' </summary>
        Public Const ErrorConsulta As String = "Se produjo un error al intentar consultar los datos del artículo: {0}."

        Public Const ArticuloYaSeleccionado As String = "El artículos ya fue seleccionado. Solo puede hacer la operación de translado de un tipo de articulo a la vez"
    End Class

    ''' <summary>
    ''' Mensajes relacionados con ubicaciones
    ''' </summary>
    Public Class MensajesUbicaciones
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de ubicación
        ''' </summary>
        Public Const CodigoFaltante As String = "Por favor, introduzca un código de ubicación para continuar."

        ''' <summary>
        ''' Mensaje para cuando el código de ubicación no es válido
        ''' </summary>
        Public Const CodigoInvalido As String = "El código de ubicación proporcionado no es válido. Verifique e intente nuevamente."

        ''' <summary>
        ''' Mensaje para cuando la ubicación no existe
        ''' </summary>
        Public Const NoExiste As String = "No se encontró una ubicación asociada al código proporcionado: {0}."

        ''' <summary>
        ''' Mensaje para errores al validar ubicaciones
        ''' </summary>
        Public Const ErrorValidacion As String = "Se produjo un error al intentar validar la ubicación: {0}."

        ''' <summary>
        ''' Mensaje para cuando el almacén no coincide con la ubicación
        ''' </summary>
        Public Const AlmacenNoCoincide As String = "El almacén asignado al terminal: {0} no coincide con el almacén asociado a la ubicación: {1}."
    End Class

    ''' <summary>
    ''' Mensajes relacionados con stock e inventario
    ''' </summary>
    Public Class MensajesStock
        ''' <summary>
        ''' Mensaje para cuando no hay suficiente stock disponible
        ''' </summary>
        Public Const Insuficiente As String = "No hay suficiente stock disponible para completar la operación. Stock restante: {0}."

        ''' <summary>
        ''' Mensaje para cuando la cantidad seleccionada es inválida
        ''' </summary>
        Public Const CantidadInvalida As String = "La cantidad seleccionada debe ser mayor a cero. Por favor, revise e intente nuevamente."

        ''' <summary>
        ''' Mensaje para cuando no se puede determinar el stock disponible
        ''' </summary>
        Public Const ErrorDeterminacion As String = "No fue posible determinar el stock disponible en este momento. Intente nuevamente más tarde."
    End Class

    ''' <summary>
    ''' Mensajes generales del sistema
    ''' </summary>
    Public Class MensajesGenerales

        Public Const GuardadoCorrectamente As String = "Los datos se guardaron correctamente."

        ''' <summary>
        ''' Mensaje para cuando faltan campos obligatorios
        ''' </summary>
        Public Const FaltanCampos As String = "Es necesario seleccionar un artículo y una ubicación válidos para continuar."

        ''' <summary>
        ''' Mensaje para cuando se requiere un valor numérico
        ''' </summary>
        Public Const ValorNumericoRequerido As String = "El valor ingresado debe ser numérico. Por favor, revise e intente nuevamente."

        ''' <summary>
        ''' Mensaje para errores en operaciones de base de datos
        ''' </summary>
        Public Const ErrorOperacionBD As String = "Se produjo un error durante la operación en la base de datos: {0}."

        ''' <summary>
        ''' Mensaje para errores inesperados
        ''' </summary>
        Public Const ErrorInesperado As String = "Se produjo un error inesperado en el sistema: {0}. Por favor, contacte al soporte técnico."

        ''' <summary>
        ''' Mensaje para cuando no se encuentran datos
        ''' </summary>
        Public Const SinDatos As String = "No se encontraron datos que coincidan con la consulta proporcionada."

        ''' <summary>
        ''' Mensaje para cuando no se ha definido una consulta
        ''' </summary>
        Public Const ConsultaNoDefinida As String = "No se ha definido una consulta válida para ejecutar. Por favor, revise la configuración."

        ''' <summary>
        ''' Mensaje para cuando el terminal no está definido
        ''' </summary>
        Public Const TerminalNoDefinido As String = "El terminal no está registrado en la base de datos. Por favor, contacte al administrador del sistema."
    End Class
End Module
