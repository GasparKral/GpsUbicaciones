Public Class frmBusquedaLocalizacion

    Public Sub New(Info As DataTable)
        InitializeComponent()
        GridControl1.DataSource = Info
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class