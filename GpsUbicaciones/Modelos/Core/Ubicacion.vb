Public Class Ubicacion
    Implements IDisposable

    Property Identificador As String
    Property Nombre As String
    Property Almacen As String = Nothing
    Property NombreAlmacen As String = Nothing

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            Identificador = Nothing
            Nombre = Nothing
            Almacen = Nothing
            NombreAlmacen = Nothing

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