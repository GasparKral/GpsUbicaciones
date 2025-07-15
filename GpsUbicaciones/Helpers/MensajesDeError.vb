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
        ''' Mensaje para errores al consultar artículos
        ''' </summary>
        Public Shared Function ErrorConsulta() As String
            Return "Se produjo un error al intentar consultar los datos del artículo: {0}."
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

    End Class

    ''' <summary>
    ''' Mensajes generales del sistema
    ''' </summary>
    Public Class MensajesGenerales

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
        ''' Mensaje para cuando no se encuentran datos
        ''' </summary>
        Public Shared Function SinDatos() As String
            Return "No se encontraron datos que coincidan con la consulta proporcionada."
        End Function

    End Class
End Module
