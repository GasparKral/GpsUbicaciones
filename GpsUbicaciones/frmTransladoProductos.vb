Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Public Class frmTransladoProductos

    Private Almacen As String = "00"
    Private ConexionLocal As IDbConnection
    'Cambiar
    Private ListaProductos As New BindingList(Of ProductoOrigenTranslado)
    Private Sub actualizarCampoStockOrigen()
        Dim dsData = RealizarQuery(ConexionLocal, ObtenerStockProductoLote, teCodigoArticulo.Text.ToString, teCodigoUbicacion.Text.ToString, Almacen)

        If dsData.Tables.Count > 0 AndAlso dsData.Tables(0).Rows.Count > 0 Then
            Dim dsFila = dsData.Tables(0).Rows(0)
            lblStock.Text = dsFila("Stock")
            nupUnidades.Properties.MaxValue = Integer.Parse(dsFila("Stock"))
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulo.Click
        ' Buscar si el producto ya existe en la lista
        Dim productoExistente = ListaProductos.FirstOrDefault(Function(p) p.CodigoUbicacion = teCodigoArticulo.Text)

        If productoExistente IsNot Nothing Then
            ' Actualizar la cantidad del producto existente
            productoExistente.CantidadAMover = CInt(nupUnidades.Value)

            ' Forzar la notificación de cambio para actualizar los controles enlazados
            ListaProductos.ResetItem(ListaProductos.IndexOf(productoExistente))
        Else
            ' Crear y agregar un nuevo producto
            Dim nuevoProducto As New ProductoOrigenTranslado With {
            .NombreComercial = lblNombreArticulo.Text,
            .CodigoUbicacion = teCodigoUbicacion.Text,
            .Stock = lblStock.Text,
            .CantidadAMover = nupUnidades.Value
        }

            ListaProductos.Add(nuevoProducto)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ConfigurarGrid()
        grdProductos.DataSource = ListaProductos

        ' Usa directamente gvDatos (ya está asociado en el diseñador)
        If gvDatos IsNot Nothing Then
            gvDatos.Columns.Clear()

            ' Columna NombreComercial
            Dim colNombre As New GridColumn()
            colNombre.FieldName = "NombreComercial"
            colNombre.Caption = "ARTÍCULO"
            colNombre.Visible = True
            gvDatos.Columns.Add(colNombre)

            ' Columna CodigoUbicacion
            Dim colUbicacion As New GridColumn()
            colUbicacion.FieldName = "CodigoUbicacion"
            colUbicacion.Caption = "UBICACIÓN"
            colUbicacion.Visible = True
            gvDatos.Columns.Add(colUbicacion)

            ' Columna Stock
            Dim colCantidad As New GridColumn()
            colCantidad.FieldName = "CantidadAMover"
            colCantidad.Caption = "CANTIDAD"
            colCantidad.Visible = True
            gvDatos.Columns.Add(colCantidad)

            ' Columna para el botón de eliminar
            Dim colEliminar As New GridColumn()
            colEliminar.FieldName = "Eliminar"
            colEliminar.Caption = "ELIMINAR"
            colEliminar.Visible = True
            gvDatos.Columns.Add(colEliminar)

            ' Configura el repositorio para el botón
            Dim repoButton As New RepositoryItemButtonEdit()
            repoButton.Buttons.Clear()
            repoButton.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete))
            repoButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
            AddHandler repoButton.ButtonClick, AddressOf EliminarFila

            gvDatos.Columns("Eliminar").ColumnEdit = repoButton
            gvDatos.Columns("Eliminar").OptionsColumn.AllowEdit = True
            gvDatos.Columns("Eliminar").OptionsColumn.ReadOnly = False

        End If
    End Sub

    Private Sub EliminarFila(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim gridView As GridView = TryCast(grdProductos.MainView, GridView)

        If gridView IsNot Nothing Then
            Dim rowHandle As Integer = gridView.FocusedRowHandle

            If rowHandle >= 0 Then
                Dim prodEliminado As ProductoOrigenTranslado = ListaProductos(rowHandle)
                ListaProductos.RemoveAt(rowHandle)

                ' Si el artículo eliminado es el actualmente visible, actualizar MaxValue
                If prodEliminado.NombreComercial = lblNombreArticulo.Text Then
                    Dim stockTotal As Integer = Integer.Parse(lblStock.Text)
                    Dim cantidadYaAsignada As Integer = ListaProductos.
                    Where(Function(p) p.NombreComercial = prodEliminado.NombreComercial).
                    Sum(Function(p) p.CantidadAMover)
                    nupUnidades.Properties.MaxValue = Math.Max(0, stockTotal - cantidadYaAsignada)
                End If
            End If
        End If
    End Sub

    Private Sub frmTransladoProductos_Load() Handles MyBase.Load
        ConfigurarGrid()
    End Sub
    Private Sub lblArticulo_Click(sender As Object, e As EventArgs) Handles lblArticulo.Click
        teCodigoArticulo.Focus()
    End Sub

    Private Sub lblUbicacion_Click(sender As Object, e As EventArgs) Handles lblUbicacion.Click
        teCodigoUbicacion.Focus()
    End Sub

    Private Sub teCodigoArticulo_EditValueChanged(sender As Object, e As EventArgs) Handles teCodigoArticulo.EditValueChanged
        Dim dsTabla = RealizarQuery(ConexionLocal, ObtenerInformacionDeArticulo, TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString).Tables(0)
        If dsTabla.Rows.Count > 1 Then
            MsgBox("Error: Demasiadas coincidencias con la petición")
        ElseIf dsTabla.Rows.Count = 0 Then
            MsgBox("Error: No se encontró ninguna coincidencia")
        Else
            lblNombreArticulo.Text = dsTabla.Rows(0)("NombreComercial")
            If teCodigoUbicacion.Text <> "" Then
                actualizarCampoStockOrigen()
            End If
        End If
    End Sub

    Private Sub teCodigoUbicacion_EditValueChanged(sender As Object, e As EventArgs) Handles teCodigoUbicacion.EditValueChanged
        Dim dsTabla = RealizarQuery(ConexionLocal, ObtenerInformacionUbicacionLote, TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString).Tables(0)
        If dsTabla.Rows.Count > 1 Then
            MsgBox("Error: Demasiadas coincidencias con la petición")
        ElseIf dsTabla.Rows.Count = 0 Then
            MsgBox("Error: No se encontró ninguna coincidencia")
        Else
            lblNombreUbicacion.Text = dsTabla.Rows(0)("Nombre")
            If teCodigoArticulo.Text <> "" Then
                actualizarCampoStockOrigen()
            End If
        End If
    End Sub
End Class