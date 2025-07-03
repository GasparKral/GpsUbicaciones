Public Class frmUtilidades

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub ResetTable_Click(sender As Object, e As EventArgs) Handles ResetTable.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro que desea eliminar todos los registros de la tabla MovPda?" & vbCrLf & vbCrLf & "Esta acción no se puede deshacer.",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Operacion.ExecuteQuery("DELETE FROM MovPda")
                MessageBox.Show("Tabla reiniciada correctamente.", "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al reiniciar la tabla: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class