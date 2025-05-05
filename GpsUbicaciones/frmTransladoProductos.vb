Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTransladoProductos
    Implements IDisposable

    ' Constantes para mensajes
    Private Const MSG_ERROR_ARTICULO As String = "Introduzca un código de artículo válido"
    Private Const MSG_ERROR_UBICACION As String = "Introduzca un código de ubicación válido"
    Private Const MSG_STOCK_INSUFICIENTE As String = "No hay suficiente stock disponible. Stock restante: {0}"
    Private Const MSG_DATOS_INCOMPLETOS As String = "Debe seleccionar un artículo y una ubicación válidos"
    Private Const MSG_CANTIDAD_INVALIDA As String = "La cantidad a mover debe ser mayor que cero"
    Private Const TITULO_ERROR As String = "Error"
    Private Const TITULO_ADVERTENCIA As String = "Advertencia"

    ' Variables miembro
    Private ListaProductos As New BindingList(Of ProductoOrigenTranslado)
    Private repoButton As RepositoryItemButtonEdit

    ' Métodos principales
    Private Sub actualizarCampoStockOrigen()
        Try
            If String.IsNullOrEmpty(teCodigoArticulo.Text) OrElse String.IsNullOrEmpty(teCodigoUbicacion.Text) Then
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerStockProductoLote,
                              teCodigoArticulo.Text,
                              teCodigoUbicacion.Text,
                              Almacen), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                lblStock.Text = "0"
                nupUnidades.Properties.MaxValue = 0
                Return
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                lblStock.Text = stock.ToString()
                nupUnidades.Properties.MaxValue = stock
            Else
                lblStock.Text = "0"
                nupUnidades.Properties.MaxValue = 0
            End If
        Catch ex As Exception
            lblStock.Text = "0"
            nupUnidades.Properties.MaxValue = 0
            ' Considera registrar el error en un log
            Debug.WriteLine($"Error en actualizarCampoStockOrigen: {ex.Message}")
        End Try
    End Sub

    Private Function GenerarIdentificador(nombre As String, ubicacion As String) As String
        Return String.Format("{0}_{1}", nombre, ubicacion)
    End Function

    Private Function ValidarCamposRequeridos() As Boolean
        Return Not (String.IsNullOrEmpty(teCodigoArticulo.Text)) AndAlso
               Not (String.IsNullOrEmpty(teCodigoUbicacion.Text)) AndAlso
               nupUnidades.Value > 0
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulo.Click
        ' Validaciones previas
        If Not ValidarCamposRequeridos() Then
            MessageBox.Show(MSG_DATOS_INCOMPLETOS, TITULO_ADVERTENCIA, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If nupUnidades.Value <= 0 Then
            MessageBox.Show(MSG_CANTIDAD_INVALIDA, TITULO_ADVERTENCIA, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim identificador = GenerarIdentificador(lblArticulo.Text, teCodigoUbicacion.Text)
            Dim productoExistente = ListaProductos.FirstOrDefault(Function(p) p.Identificador = identificador)

            If productoExistente IsNot Nothing Then
                ' Validar que no exceda el stock disponible
                Dim stockDisponible = Integer.Parse(lblStock.Text)
                Dim cantidadYaAsignada = ListaProductos.
                    Where(Function(p) p.NombreComercial = lblNombreArticulo.Text).
                    Sum(Function(p) p.CantidadAMover)
                Dim nuevoTotal = cantidadYaAsignada - productoExistente.CantidadAMover + nupUnidades.Value

                If nuevoTotal > stockDisponible Then
                    MessageBox.Show(
                        String.Format(MSG_STOCK_INSUFICIENTE, stockDisponible - cantidadYaAsignada),
                        TITULO_ADVERTENCIA,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                    Return
                End If

                productoExistente.CantidadAMover = CInt(nupUnidades.Value)
                ListaProductos.ResetItem(ListaProductos.IndexOf(productoExistente))
            Else
                ' Validar stock para nuevo producto
                Dim stockDisponible = Integer.Parse(lblStock.Text)
                Dim cantidadYaAsignada = ListaProductos.
                    Where(Function(p) p.NombreComercial = lblNombreArticulo.Text).
                    Sum(Function(p) p.CantidadAMover)

                If nupUnidades.Value > (stockDisponible - cantidadYaAsignada) Then
                    MessageBox.Show(
                        String.Format(MSG_STOCK_INSUFICIENTE, stockDisponible - cantidadYaAsignada),
                        TITULO_ADVERTENCIA,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
                    Return
                End If

                Dim nuevoProducto As New ProductoOrigenTranslado With {
                    .Identificador = identificador,
                    .NombreComercial = lblNombreArticulo.Text,
                    .CodigoUbicacion = teCodigoUbicacion.Text,
                    .Stock = lblStock.Text,
                    .CantidadAMover = nupUnidades.Value
                }

                ListaProductos.Add(nuevoProducto)
            End If

            ' Resetear controles después de agregar
            nupUnidades.Value = 0
        Catch ex As Exception
            MessageBox.Show($"Error al agregar producto: {ex.Message}", TITULO_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Error en btnAgregar_Click: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ConfigurarGrid()
        grdProductos.DataSource = ListaProductos

        If gvDatos Is Nothing Then Return

        gvDatos.Columns.Clear()

        ' Método auxiliar para crear columnas
        Dim CreateColumn = Function(fieldName As String, caption As String, width As Integer) As GridColumn
                               Dim col As New GridColumn()
                               col.FieldName = fieldName
                               col.Caption = caption
                               col.Visible = True
                               col.Width = width
                               Return col
                           End Function

        ' Columnas principales
        gvDatos.Columns.AddRange({
            CreateColumn("NombreComercial", "ARTÍCULO", 200),
            CreateColumn("CodigoUbicacion", "UBICACIÓN", 100),
            CreateColumn("Stock", "STOCK", 60),
            CreateColumn("CantidadAMover", "CANTIDAD", 80)
        })

        ' Configurar columna de eliminación
        Dim colEliminar = CreateColumn("Eliminar", "ELIMINAR", 80)
        repoButton = New RepositoryItemButtonEdit()
        repoButton.Buttons.Clear()
        repoButton.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete))
        repoButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        AddHandler repoButton.ButtonClick, AddressOf EliminarFila

        colEliminar.ColumnEdit = repoButton
        colEliminar.OptionsColumn.AllowEdit = True
        gvDatos.Columns.Add(colEliminar)

        ' Configuración adicional de la vista
        gvDatos.OptionsView.ShowAutoFilterRow = True
        gvDatos.OptionsView.ShowGroupPanel = False
        gvDatos.OptionsBehavior.Editable = True
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
        If String.IsNullOrEmpty(teCodigoArticulo.Text) Then
            Exit Sub
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionDeArticulo,
                              TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString), 0, 0)
            lblNombreArticulo.Text = dsFila("NombreComercial")

            If Not String.IsNullOrEmpty(teCodigoUbicacion.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            teCodigoArticulo.SelectAll()
            MessageBox.Show(MSG_ERROR_ARTICULO, TITULO_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Error en teCodigoArticulo_EditValueChanged: {ex.Message}")
        End Try
    End Sub

    Private Sub teCodigoUbicacion_EditValueChanged(sender As Object, e As EventArgs) Handles teCodigoUbicacion.EditValueChanged
        If String.IsNullOrEmpty(teCodigoUbicacion.Text) Then
            Exit Sub
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionUbicacionLote,
                              TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString), 0, 0)
            lblNombreUbicacion.Text = dsFila("Nombre")

            If Not String.IsNullOrEmpty(teCodigoArticulo.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            teCodigoUbicacion.SelectAll()
            MessageBox.Show(MSG_ERROR_UBICACION, TITULO_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Error en teCodigoUbicacion_EditValueChanged: {ex.Message}")
        End Try
    End Sub

    Private Sub teCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles teCodigoArticulo.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub teCodigoUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles teCodigoUbicacion.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class