Public Class ProductoTraslado
    Property Articulo As Articulo
    Property CodigoUbicacionOrigen As String
    Property CodigoUbicacionDestino As String
    Property Stock As Single
    Property CantidadAMover As Single

    Public ReadOnly Property NombreComercial As String
        Get
            Return Articulo.NombreComercial
        End Get
    End Property

    Public ReadOnly Property Codigo As String
        Get
            Return Articulo.Codigo
        End Get
    End Property
End Class
