Public Class Articulo
    Implements IDisposable

    Private disposedValue As Boolean

    Property Codigo As String
    Property NombreComercial As String
    Property PorPeso As Boolean

    Property CodigoBarras As String = ""
    Property ReferenciaProvedor As String = ""
    Property StockTotal As Single
    Property Foto As String = ""
    Property Categoria As String = ""
    Property PVP As Single = 0.0

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            Codigo = Nothing
            NombreComercial = Nothing
            PorPeso = False
            CodigoBarras = Nothing
            ReferenciaProvedor = Nothing
            StockTotal = 0.0
            Foto = Nothing
            Categoria = Nothing

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