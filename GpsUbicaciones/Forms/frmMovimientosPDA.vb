Public Class frmMovimientosPDA

    Public Sub New(Table As DataTable)
        InitializeComponent()
        GridControlMovimientos.DataSource = Table
    End Sub

    Public Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub GridViewMovimientos_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridViewMovimientos.RowStyle
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.RowHandle >= 0 Then ' Asegurarse de que es una fila de datos
            Dim valor As String = view.GetRowCellValue(e.RowHandle, "Operacion")?.ToString()

            Select Case valor
                Case "SE"
                    e.Appearance.BackColor = Color.FromArgb(255, 249, 197)
                    e.Appearance.BackColor2 = Color.FromArgb(255, 249, 197)
                    e.HighPriority = True
                Case "TR"
                    e.Appearance.BackColor = Color.FromArgb(197, 213, 255)
                    e.Appearance.BackColor2 = Color.FromArgb(197, 213, 255)
                    e.HighPriority = True
                Case "VE"
                    e.Appearance.BackColor = Color.FromArgb(197, 255, 199)
                    e.Appearance.BackColor2 = Color.FromArgb(197, 255, 199)
                    e.HighPriority = True
            End Select
        End If
    End Sub
End Class