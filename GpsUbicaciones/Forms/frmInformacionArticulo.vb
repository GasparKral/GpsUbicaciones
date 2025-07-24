Public Class frmInformacionArticulo


    Private Sub TextEditItem_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextEditItem.Validating

        Using item = RepositorioArticulo.ObtenerInformacion(TextEditItem.Text)
            If item Is Nothing Then
                e.Cancel = True
                TextEditItem.Focus()
                TextEditItem.SelectAll()
            End If

            LabelNombreArticulo.Text = item.NombreComercial
            LabelCategory.Text = item.Categoria
            LabelTotalStock.Text = item.StockTotal.ToString
            LabelItemPVP.Text = 0

            Try
                PictureBoxItemImage.Image = Image.FromFile(item.Foto)
            Catch ex As Exception
                PictureBoxItemImage.Image = My.Resources.NoImage
            End Try

            Dim DataTable = Operacion.ExecuteQuery($"
            SELECT U.Nombre, Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven,{nDecUds}) AS Cantidad
            FROM (UBICACIONES AS U
            INNER JOIN STOCKLOTES AS S ON S.Lote = U.Codigo)
            INNER JOIN ARTICULOS AS A ON A.Codigo = S.Articulo
            WHERE  A.Codigo = ? OR 
                   A.CodBarras = ? OR 
                   A.RefProveedor = ?
            ORDER BY U.Orden", item.Codigo, item.Codigo, item.Codigo).Tables(0)

            GridControlLotes.DataSource = DataTable
            GridViewLotes.RefreshData()

        End Using
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class