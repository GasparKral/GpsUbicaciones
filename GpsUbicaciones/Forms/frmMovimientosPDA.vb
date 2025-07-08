Public Class frmMovimientosPDA

    Public Sub New(Table As DataTable)
        InitializeComponent()
        GridControlMovimientos.DataSource = Table
    End Sub

    Public Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

End Class