Public Class frmUtilidades

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub ResetTable_Click(sender As Object, e As EventArgs) Handles ResetTable.Click
        Dim result = GestorMensajes.FabricaMensajes.MostrarConfirmacionConCancelar("¿Está seguro que desea eliminar todos los registros de la tabla MovPda?" & vbCrLf & vbCrLf & "Esta acción no se puede deshacer.")

        If result = DialogResult.Yes Then
            Try
                Operacion.ExecuteNonQuery("DELETE FROM MovPda WHERE Terminal = ?", Terminal)
                GestorMensajes.FabricaMensajes.MostrarConfirmacion("Tabla reiniciada correctamente.")
            Catch ex As Exception
                GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al reiniciar la tabla: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub ButtonVisualizeTable_Click(sender As Object, e As EventArgs) Handles ButtonVisualizeTable.Click
        Dim form = New frmMovimientosPDA(RepositorioMovPDA.ObtenerMovimientosPDA)
        form.ShowDialog()
    End Sub

    Private Sub ButtonLocation_Click(sender As Object, e As EventArgs) Handles ButtonLocation.Click
        frmInformacionArticulo.ShowDialog()
    End Sub

End Class