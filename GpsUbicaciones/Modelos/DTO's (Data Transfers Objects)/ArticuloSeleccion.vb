Public Class ArticuloSeleccion
    Implements IDisposable

    Private disposedValue As Boolean

    Property Ubicacion As String
    Property Articulo As String
    Property Descripcion As String
    Property Unidades As Single



    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            Ubicacion = Nothing
            Articulo = Nothing
            Descripcion = Nothing
            Unidades = Nothing
        End If
        disposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(disposing:=False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class