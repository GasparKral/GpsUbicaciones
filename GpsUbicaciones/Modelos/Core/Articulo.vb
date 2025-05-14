Public Class Articulo
    Implements IDisposable

    Property Codigo As String
    Property NombreComercial As String
    Property PorPeso As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            Codigo = Nothing
            NombreComercial = Nothing
            PorPeso = False

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

    Private disposedValue As Boolean
End Class