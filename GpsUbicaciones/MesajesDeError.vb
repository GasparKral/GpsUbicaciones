Module MesajesDeError
    ''' <summary>
    ''' Mensaje para cuando no se ha introducido un código de artículo
    ''' </summary>
    Public Const MensajeCodigoArticuloFaltante As String = "Introduzca un código de artículo"

    ''' <summary>
    ''' Mensaje para cuando no se ha introducido un código de ubicación
    ''' </summary>
    Public Const MensajeCodigoUbicacionFaltante As String = "Introduzca un código de ubicación"

    ''' <summary>
    ''' Mensaje para cuando el código de artículo no es válido
    ''' </summary>
    Public Const MensajeCodigoArticuloInvalido As String = "Introduzca un código de artículo válido"

    ''' <summary>
    ''' Mensaje para cuando el código de ubicación no es válido
    ''' </summary>
    Public Const MensajeCodigoUbicacionInvalido As String = "Introduzca un código de ubicación válido"

    ''' <summary>
    ''' Mensaje para cuando no hay suficiente stock disponible
    ''' </summary>
    Public Const MensajeStockInsuficiente As String = "No hay suficiente stock disponible. Stock restante: {0}"

    ''' <summary>
    ''' Mensaje para cuando la cantidad seleccionada es inválida
    ''' </summary>
    Public Const MensajeCantidadInvalida As String = "La cantidad seleccionada debe ser mayor a cero"

    ''' <summary>
    ''' Mensaje para cuando se requiere un valor numérico
    ''' </summary>
    Public Const MensajeValorNumericoRequerido As String = "Debe ingresar un valor numérico"

    ''' <summary>
    ''' Mensaje para cuando el almacén no coincide con la ubicación
    ''' </summary>
    Public Const MensajeAlmacenNoCoincide As String = "EL ALMACEN ASIGNADO A ESTE TERMINAL: {0} NO SE CORRESPONDE CON EL ALMACEN {1} DE ESTA UBICACION"

    ''' <summary>
    ''' Mensaje para cuando el artículo no existe
    ''' </summary>
    Public Const MensajeArticuloNoExiste As String = "NO EXISTE ARTICULO CON ESTE CODIGO: {0}"

    ''' <summary>
    ''' Mensaje para cuando la ubicación no existe
    ''' </summary>
    Public Const MensajeUbicacionNoExiste As String = "NO EXISTE UBICACION CON ESTE CODIGO: {0}"

    ''' <summary>
    ''' Mensaje para errores en operaciones de base de datos
    ''' </summary>
    Public Const MensajeErrorOperacionBD As String = "Error en la operación de base de datos: {0}"

    ''' <summary>
    ''' Mensaje para errores al consultar artículos
    ''' </summary>
    Public Const MensajeErrorConsultaArticulos As String = "Error al consultar artículos: {0}"

    ''' <summary>
    ''' Mensaje para errores al validar ubicaciones
    ''' </summary>
    Public Const MensajeErrorValidacionUbicacion As String = "Error al validar ubicación: {0}"

    ''' <summary>
    ''' Mensaje para errores inesperados
    ''' </summary>
    Public Const MensajeErrorInesperado As String = "Error inesperado: {0}"

    ''' <summary>
    ''' Mensaje para cuando no se encuentran datos
    ''' </summary>
    Public Const MensajeSinDatos As String = "No se han encontrado datos para la consulta proporcionada"

    ''' <summary>
    ''' Mensaje para cuando no se ha definido una consulta
    ''' </summary>
    Public Const MensajeConsultaNoDefinida As String = "No se ha definido la consulta a ejecutar"

    ''' <summary>
    ''' Mensaje para cuando el terminal no está definido
    ''' </summary>
    Public Const MensajeTerminalNoDefinido As String = "Terminal no definido en la base de datos"

End Module
