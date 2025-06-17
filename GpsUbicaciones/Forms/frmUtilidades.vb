Public Class frmUtilidades
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ResetTable_Click(sender As Object, e As EventArgs) Handles ResetTable.Click
        Operacion.ExecuteQuery("Truncate Table MovPda")
    End Sub
End Class