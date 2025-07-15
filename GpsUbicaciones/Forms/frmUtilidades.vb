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
        Dim form = New frmMovimientosPDA(Operacion.ExecuteTable("Select MOVPDA.*, ARTICULOS.NombreComercial FROM MovPda INNER JOIN ARTICULOS ON MovPda.Articulo = Articulos.Codigo WHERE Terminal = ?", Terminal))
        form.ShowDialog()
    End Sub

    Private Sub ButtonLocation_Click(sender As Object, e As EventArgs) Handles ButtonLocation.Click
        ' Abrir popup de busqueda
        Dim ReferenciaBusqueda As String = InputBox("Por favor, introduzca el código de referencia del artículo que desea buscar.", "Busqueda de ubicaciones")

        If String.IsNullOrEmpty(ReferenciaBusqueda) Then
            Exit Sub
        End If

        Dim table = Operacion.ExecuteTable($"
        SELECT U.Nombre, Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven,{nDecUds}) AS Cantidad
        FROM (UBICACIONES AS U
        INNER JOIN STOCKLOTES AS S ON S.Lote = U.Codigo)
        INNER JOIN ARTICULOS AS A ON A.Codigo = S.Articulo
        WHERE  A.Codigo = ? OR 
               A.CodBarras = ? OR 
               A.RefProveedor = ?
        ORDER BY U.Orden
        ", ReferenciaBusqueda, ReferenciaBusqueda, ReferenciaBusqueda)

        If table.Rows.Count = 0 Then
            MessageBox.Show("Artículo no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim form = New frmBusquedaLocalizacion(table)
        form.ShowDialog()
    End Sub
End Class