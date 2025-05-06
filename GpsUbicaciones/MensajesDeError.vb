Module MensajesDeError
    ''' <summary>
    ''' Mensajes relacionados con artículos
    ''' </summary>
    Public Class MensajesArticulos
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de artículo
        ''' </summary>
        Public Const CodigoFaltante As String = "Introduzca un código de artículo"

        ''' <summary>
        ''' Mensaje para cuando el código de artículo no es válido
        ''' </summary>
        Public Const CodigoInvalido As String = "Introduzca un código de artículo válido"

        ''' <summary>
        ''' Mensaje para cuando el artículo no existe
        ''' </summary>
        Public Const NoExiste As String = "NO EXISTE ARTICULO CON ESTE CODIGO: {0}"

        ''' <summary>
        ''' Mensaje para errores al consultar artículos
        ''' </summary>
        Public Const ErrorConsulta As String = "Error al consultar artículos: {0}"
    End Class

    ''' <summary>
    ''' Mensajes relacionados con ubicaciones
    ''' </summary>
    Public Class MensajesUbicaciones
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de ubicación
        ''' </summary>
        Public Const CodigoFaltante As String = "Introduzca un código de ubicación"

        ''' <summary>
        ''' Mensaje para cuando el código de ubicación no es válido
        ''' </summary>
        Public Const CodigoInvalido As String = "Introduzca un código de ubicación válido"

        ''' <summary>
        ''' Mensaje para cuando la ubicación no existe
        ''' </summary>
        Public Const NoExiste As String = "NO EXISTE UBICACION CON ESTE CODIGO: {0}"

        ''' <summary>
        ''' Mensaje para errores al validar ubicaciones
        ''' </summary>
        Public Const ErrorValidacion As String = "Error al validar ubicación: {0}"

        ''' <summary>
        ''' Mensaje para cuando el almacén no coincide con la ubicación
        ''' </summary>
        Public Const AlmacenNoCoincide As String = "EL ALMACEN ASIGNADO A ESTE TERMINAL: {0} NO SE CORRESPONDE CON EL ALMACEN {1} DE ESTA UBICACION"
    End Class

    ''' <summary>
    ''' Mensajes relacionados con stock e inventario
    ''' </summary>
    Public Class MensajesStock
        ''' <summary>
        ''' Mensaje para cuando no hay suficiente stock disponible
        ''' </summary>
        Public Const Insuficiente As String = "No hay suficiente stock disponible. Stock restante: {0}"

        ''' <summary>
        ''' Mensaje para cuando la cantidad seleccionada es inválida
        ''' </summary>
        Public Const CantidadInvalida As String = "La cantidad seleccionada debe ser mayor a cero"

        ''' <summary>
        ''' Mensaje para cuando no se puede determinar el stock disponible
        ''' </summary>
        Public Const ErrorDeterminacion As String = "No se pudo determinar el stock disponible"
    End Class

    ''' <summary>
    ''' Mensajes generales del sistema
    ''' </summary>
    Public Class MensajesGenerales

        ''' <summary>
        ''' Mensaje para cuando faltan campos obligatorios
        ''' </summary>
        Public Const FaltanCampos As String = "Debe seleccionar un artículo y una ubicación válidos"

        ''' <summary>
        ''' Mensaje para cuando se requiere un valor numérico
        ''' </summary>
        Public Const ValorNumericoRequerido As String = "Debe ingresar un valor numérico"

        ''' <summary>
        ''' Mensaje para errores en operaciones de base de datos
        ''' </summary>
        Public Const ErrorOperacionBD As String = "Error en la operación de base de datos: {0}"

        ''' <summary>
        ''' Mensaje para errores inesperados
        ''' </summary>
        Public Const ErrorInesperado As String = "Error inesperado: {0}"

        ''' <summary>
        ''' Mensaje para cuando no se encuentran datos
        ''' </summary>
        Public Const SinDatos As String = "No se han encontrado datos para la consulta proporcionada"

        ''' <summary>
        ''' Mensaje para cuando no se ha definido una consulta
        ''' </summary>
        Public Const ConsultaNoDefinida As String = "No se ha definido la consulta a ejecutar"

        ''' <summary>
        ''' Mensaje para cuando el terminal no está definido
        ''' </summary>
        Public Const TerminalNoDefinido As String = "Terminal no definido en la base de datos"
    End Class
End Module
