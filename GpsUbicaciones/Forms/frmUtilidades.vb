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
                Operacion.ExecuteNonQuery("DELETE FROM MovPda WHERE Terminal = ?", Terminal)
                MessageBox.Show("Tabla reiniciada correctamente.", "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error al reiniciar la tabla: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub



    Private Sub ButtonVisualizeTable_Click(sender As Object, e As EventArgs) Handles ButtonVisualizeTable.Click
        Dim form = New frmMovimientosPDA(Operacion.ExecuteTable("Select * FROM MovPda WHERE Terminal = ?", Terminal))
    End Sub

    Private Sub ButtonLocation_Click(sender As Object, e As EventArgs) Handles ButtonLocation.Click

    End Sub
End Class