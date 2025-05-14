Public Class Pedido
    Property Identificador As Integer
    Property Fecha As DateTime
    Property Destino As String
    Property Unidades As Single
    Property Articulo As Articulo
    Property Ubicacion As Ubicacion

    ''' <summary>
    ''' Convierte una cadena de fecha en un objeto DateTime en el formato dd/mm/yyyy.
    ''' </summary>
    ''' <param name="fecha">La cadena de fecha a convertir.</param>
    ''' <returns>Un objeto DateTime que representa la fecha convertida.</returns>
    ''' <exception cref="FormatException">La fecha no está en el formato dd/mm/yyyy.</exception>
    Public Shared Function ConvertirFecha(fecha As String) As DateTime
        Dim fechaFormateada As DateTime
        If DateTime.TryParseExact(fecha, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fechaFormateada) Then
            Return fechaFormateada
        Else
            Throw New FormatException("La fecha no está en el formato dd/mm/yyyy")
        End If
    End Function

End Class
