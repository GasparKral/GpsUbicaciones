Public Class StockLote
    Implements IDisposable

    Private disposedValue As Boolean
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

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                If Articulo IsNot Nothing Then
                    Articulo.Dispose()
                    Articulo = Nothing
                End If
            End If

            If Lote IsNot Nothing Then
                Lote.Dispose()
                Lote = Nothing
            End If

            UnidadesIniciales = 0
            UnidadesCompradas = 0
            UnidadesVendidas = 0
            UnidadesTransferidas = 0

            disposedValue = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(disposing:=False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class