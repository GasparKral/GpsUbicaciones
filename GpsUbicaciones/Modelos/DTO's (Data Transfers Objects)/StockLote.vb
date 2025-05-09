Public Class StockLote
    Property Articulo As Articulo
    Property Lote As Ubicacion
    Property UnidadesIniciales As Single
    Property UnidadesCompradas As Single
    Property UnidadesVendidas As Single
    Property UnidadesTransferidas As Single

    Public ReadOnly Property Cantidad As Single
        Get
            Return Math.Round(UnidadesIniciales + UnidadesCompradas + UnidadesTransferidas - UnidadesVendidas, nDecUds)
        End Get
    End Property

    Public ReadOnly Property NombreArticulo As String
        Get
            Return Articulo.NombreComercial
        End Get
    End Property
End Class
