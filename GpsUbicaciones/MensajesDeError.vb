Module MensajesDeError
    ''' <summary>
    ''' Mensajes relacionados con artículos
    ''' </summary>
    Public Class MensajesArticulos
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de artículo
        ''' </summary>
        Public Shared Function CodigoFaltante() As String
            Return "Por favor, introduzca un código de artículo para continuar."
        End Function

        ''' <summary>
        ''' Mensaje para cuando el código de artículo no es válido
        ''' </summary>
        Public Shared Function CodigoInvalido() As String
            Return "El código de artículo proporcionado no es válido. Verifique e intente nuevamente."
        End Function

        ''' <summary>
        ''' Mensaje para cuando el artículo no existe
        ''' </summary>
        Public Shared Function NoExiste() As String
            Return "No se encontró un artículo asociado al código proporcionado: {0}."
        End Function

        ''' <summary>
        ''' Mensaje para errores al consultar artículos
        ''' </summary>
        Public Shared Function ErrorConsulta() As String
            Return "Se produjo un error al intentar consultar los datos del artículo: {0}."
        End Function

        Public Shared Function ArticuloYaSeleccionado() As String
            Return "El artículos ya fue seleccionado. Solo puede hacer la operación de translado de un tipo de articulo a la vez"
        End Function
    End Class

    ''' <summary>
    ''' Mensajes relacionados con ubicaciones
    ''' </summary>
    Public Class MensajesUbicaciones
        ''' <summary>
        ''' Mensaje para cuando no se ha introducido un código de ubicación
        ''' </summary>
        Public Shared Function CodigoFaltante() As String
            Return "Por favor, introduzca un código de ubicación para continuar."
        End Function

        ''' <summary>
        ''' Mensaje para cuando el código de ubicación no es válido
        ''' </summary>
        Public Shared Function CodigoInvalido() As String
            Return "El código de ubicación proporcionado no es válido. Verifique e intente nuevamente."
        End Function

        ''' <summary>
        ''' Mensaje para cuando la ubicación no existe
        ''' </summary>
        Public Shared Function NoExiste() As String
            Return "No se encontró una ubicación asociada al código proporcionado: {0}."
        End Function

        ''' <summary>
        ''' Mensaje para errores al validar ubicaciones
        ''' </summary>
        Public Shared Function ErrorValidacion() As String
            Return "Se produjo un error al intentar validar la ubicación: {0}."
        End Function

        ''' <summary>
        ''' Mensaje para cuando el almacén no coincide con la ubicación
        ''' </summary>
        Public Shared Function AlmacenNoCoincide() As String
            Return "El almacén asignado al terminal: {0} no coincide con el almacén asociado a la ubicación: {1}."
        End Function
    End Class

    ''' <summary>
    ''' Mensajes relacionados con stock e inventario
    ''' </summary>
    Public Class MensajesStock
        ''' <summary>
        ''' Mensaje para cuando no hay suficiente stock disponible
        ''' </summary>
        Public Shared Function Insuficiente() As String
            Return "No hay suficiente stock disponible para completar la operación. Stock restante: {0}."
        End Function

        ''' <summary>
        ''' Mensaje para cuando la cantidad seleccionada es inválida
        ''' </summary>
        Public Shared Function CantidadInvalida() As String
            Return "La cantidad seleccionada debe ser mayor a cero. Por favor, revise e intente nuevamente."
        End Function

        ''' <summary>
        ''' Mensaje para cuando no se puede determinar el stock disponible
        ''' </summary>
        Public Shared Function ErrorDeterminacion() As String
            Return "No fue posible determinar el stock disponible en este momento. Intente nuevamente más tarde."
        End Function
    End Class

    ''' <summary>
    ''' Mensajes generales del sistema
    ''' </summary>
    Public Class MensajesGenerales

        Public Shared Function GuardadoCorrectamente() As String
            Return "Los datos se guardaron correctamente."
        End Function

        ''' <summary>
        ''' Mensaje para cuando faltan campos obligatorios
        ''' </summary>
        Public Shared Function FaltanCampos() As String
            Return "Es necesario seleccionar un artículo y una ubicación válidos para continuar."
        End Function

        ''' <summary>
        ''' Mensaje para cuando se requiere un valor numérico
        ''' </summary>
        Public Shared Function ValorNumericoRequerido() As String
            Return "El valor ingresado debe ser numérico. Por favor, revise e intente nuevamente."
        End Function

        ''' <summary>
        ''' Mensaje para errores en operaciones de base de datos
        ''' </summary>
        Public Shared Function ErrorOperacionBD() As String
            Return "Se produjo un error durante la operación en la base de datos: {0}."
        End Function

        ''' <summary>
        ''' Mensaje para errores inesperados
        ''' </summary>
        Public Shared Function ErrorInesperado() As String
            Return "Se produjo un error inesperado en el sistema: {0}. Por favor, contacte al soporte técnico."
        End Function

        ''' <summary>
        ''' Mensaje para cuando no se encuentran datos
        ''' </summary>
        Public Shared Function SinDatos() As String
            Return "No se encontraron datos que coincidan con la consulta proporcionada."
        End Function

        ''' <summary>
        ''' Mensaje para cuando no se ha definido una consulta
        ''' </summary>
        Public Shared Function ConsultaNoDefinida() As String
            Return "No se ha definido una consulta válida para ejecutar. Por favor, revise la configuración."
        End Function

        ''' <summary>
        ''' Mensaje para cuando el terminal no está definido
        ''' </summary>
        Public Shared Function TerminalNoDefinido() As String
            Return "El terminal no está registrado en la base de datos. Por favor, contacte al administrador del sistema."
        End Function
    End Class
End Module
