Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTransladoProductos
    Implements IDisposable

    ' Variables miembro
    Private ListaProductos As New BindingList(Of ProductoOrigenTranslado)
    Private repoButton As RepositoryItemButtonEdit

    ' Métodos principales
    Private Sub actualizarCampoStockOrigen()
        Try
            If String.IsNullOrEmpty(TextEditCodigoArticulo.Text) OrElse String.IsNullOrEmpty(TextEditCodigoUbicacion.Text) Then
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarArticuloConStockPorCodigoYAlmacen,
                              TextEditCodigoArticulo.Text,
                              TextEditCodigoUbicacion.Text,
                              Almacen), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                LabelStockArticulo.Text = "0"
                SpinEditCantidadSeleccionada.Properties.MaxValue = 0
                Return
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                LabelStockArticulo.Text = stock.ToString()
                SpinEditCantidadSeleccionada.Properties.MaxValue = stock
            Else
                LabelStockArticulo.Text = "0"
                SpinEditCantidadSeleccionada.Properties.MaxValue = 0
            End If
        Catch ex As Exception
            LabelStockArticulo.Text = "0"
            SpinEditCantidadSeleccionada.Properties.MaxValue = 0
        End Try
    End Sub

    Private Function GenerarIdentificador(nombre As String, ubicacion As String) As String
        Return String.Format("{0}_{1}", nombre, ubicacion)
    End Function

    Private Function ValidarCamposRequeridos() As Boolean
        Return Not (String.IsNullOrEmpty(TextEditCodigoArticulo.Text)) AndAlso
               Not (String.IsNullOrEmpty(TextEditCodigoUbicacion.Text)) AndAlso
               SpinEditCantidadSeleccionada.Value > 0
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulo.Click
        ' Validaciones previas
        If Not ValidarCamposRequeridos() Then
            MessageFactory.ShowMessage(MessageType.Warning, "Debe seleccionar un artículo y una ubicación válidos")
            Exit Sub
        End If

        If SpinEditCantidadSeleccionada.Value <= 0 Then
            MessageFactory.ShowMessage(MessageType.Warning, NumericValueRequiredMessage)
            Exit Sub
        End If

        Try
            Dim identificador = GenerarIdentificador(lblArticulo.Text, TextEditCodigoUbicacion.Text)
            Dim productoExistente = ListaProductos.FirstOrDefault(Function(p) p.Identificador = identificador)

            If productoExistente IsNot Nothing Then
                ' Validar que no exceda el stock disponible
                Dim stockDisponible = Integer.Parse(LabelStockArticulo.Text)
                Dim cantidadYaAsignada = ListaProductos.
                    Where(Function(p) p.NombreComercial = LabelNombreArticulo.Text).
                    Sum(Function(p) p.CantidadAMover)
                Dim nuevoTotal = cantidadYaAsignada - productoExistente.CantidadAMover + SpinEditCantidadSeleccionada.Value

                If nuevoTotal > stockDisponible Then
                    MessageFactory.ShowMessage(MessageType.Warning, String.Format(InsufficientStockMessage, stockDisponible - cantidadYaAsignada))
                    Exit Sub
                End If

                productoExistente.CantidadAMover = CInt(SpinEditCantidadSeleccionada.Value)
                ListaProductos.ResetItem(ListaProductos.IndexOf(productoExistente))
            Else
                ' Validar stock para nuevo producto
                Dim stockDisponible = Integer.Parse(LabelStockArticulo.Text)
                Dim cantidadYaAsignada = ListaProductos.
                    Where(Function(p) p.NombreComercial = LabelNombreArticulo.Text).
                    Sum(Function(p) p.CantidadAMover)

                If SpinEditCantidadSeleccionada.Value > (stockDisponible - cantidadYaAsignada) Then
                    MessageFactory.ShowMessage(MessageType.Warning, String.Format(InsufficientStockMessage, stockDisponible - cantidadYaAsignada))
                    Exit Sub
                End If

                Dim nuevoProducto As New ProductoOrigenTranslado With {
                    .Identificador = identificador,
                    .NombreComercial = LabelNombreArticulo.Text,
                    .CodigoUbicacion = TextEditCodigoUbicacion.Text,
                    .Stock = LabelStockArticulo.Text,
                    .CantidadAMover = SpinEditCantidadSeleccionada.Value
                }

                ListaProductos.Add(nuevoProducto)
            End If

            ' Resetear controles después de agregar
            SpinEditCantidadSeleccionada.Value = 0
        Catch ex As Exception
            MessageFactory.ShowMessage(MessageType.Error, String.Format(UnexpectedErrorMessage, ex.Message))
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ConfigurarGrid()
        GridControlArticulosParaTraslado.DataSource = ListaProductos

        If GridViewArticulosParaTraslado Is Nothing Then Return

        GridViewArticulosParaTraslado.Columns.Clear()

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
        GridViewArticulosParaTraslado.Columns.AddRange({
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
        GridViewArticulosParaTraslado.Columns.Add(colEliminar)

        ' Configuración adicional de la vista
        GridViewArticulosParaTraslado.OptionsView.ShowAutoFilterRow = True
        GridViewArticulosParaTraslado.OptionsView.ShowGroupPanel = False
        GridViewArticulosParaTraslado.OptionsBehavior.Editable = True
    End Sub

    Private Sub EliminarFila(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Dim gridView As GridView = TryCast(GridControlArticulosParaTraslado.MainView, GridView)

        If gridView IsNot Nothing Then
            Dim rowHandle As Integer = gridView.FocusedRowHandle

            If rowHandle >= 0 Then
                Dim prodEliminado As ProductoOrigenTranslado = ListaProductos(rowHandle)
                ListaProductos.RemoveAt(rowHandle)

                ' Si el artículo eliminado es el actualmente visible, actualizar MaxValue
                If prodEliminado.NombreComercial = LabelNombreArticulo.Text Then
                    Dim stockTotal As Integer = Integer.Parse(LabelStockArticulo.Text)
                    Dim cantidadYaAsignada As Integer = ListaProductos.
                        Where(Function(p) p.NombreComercial = prodEliminado.NombreComercial).
                        Sum(Function(p) p.CantidadAMover)
                    SpinEditCantidadSeleccionada.Properties.MaxValue = Math.Max(0, stockTotal - cantidadYaAsignada)
                End If
            End If
        End If
    End Sub

    Private Sub frmTransladoProductos_Load() Handles MyBase.Load
        ConfigurarGrid()
    End Sub

    Private Sub lblArticulo_Click(sender As Object, e As EventArgs) Handles lblArticulo.Click
        TextEditCodigoArticulo.Focus()
    End Sub

    Private Sub lblUbicacion_Click(sender As Object, e As EventArgs) Handles lblUbicacion.Click
        TextEditCodigoUbicacion.Focus()
    End Sub

    Private Sub teCodigoArticulo_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticulo.EditValueChanged
        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo(),
                              TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString), 0, 0)
            LabelNombreArticulo.Text = dsFila("NombreComercial")

            If Not String.IsNullOrEmpty(TextEditCodigoUbicacion.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            TextEditCodigoArticulo.SelectAll()
            MessageFactory.ShowMessage(MessageType.Error, InvalidArticleCodeMessage)
        End Try
    End Sub

    Private Sub teCodigoUbicacion_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacion.EditValueChanged
        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarUbicacionDeLotePorCodigo(),
                              TryCast(sender, DevExpress.XtraEditors.TextEdit).EditValue?.ToString), 0, 0)
            LabelNombreUbicacion.Text = dsFila("Nombre")

            If Not String.IsNullOrEmpty(TextEditCodigoArticulo.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            TextEditCodigoUbicacion.SelectAll()
            MessageFactory.ShowMessage(MessageType.Error, InvalidLocationCodeMessage)
        End Try
    End Sub

    Private Sub teCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoArticulo.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub teCodigoUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoUbicacion.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextEditCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextEditCodigoArticulo.Validating
        If String.IsNullOrEmpty(TextEditCodigoArticulo.Text) Then
            Return
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo(),
                              TextEditCodigoArticulo.Text), 0, 0)
            LabelNombreArticulo.Text = dsFila("NombreComercial")

            If Not String.IsNullOrEmpty(TextEditCodigoUbicacion.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            TextEditCodigoArticulo.SelectAll()
            MessageFactory.ShowMessage(MessageType.Error, InvalidArticleCodeMessage)
            e.Cancel = True ' Previene que el foco salga del control si la validación falla
        End Try
    End Sub

    Private Sub TextEditCodigoUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles TextEditCodigoUbicacion.Validating
        If String.IsNullOrEmpty(TextEditCodigoUbicacion.Text) Then
            e.Cancel = True
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarUbicacionDeLotePorCodigo(),
                              TextEditCodigoUbicacion.Text), 0, 0)
            LabelNombreUbicacion.Text = dsFila("Nombre")

            If Not String.IsNullOrEmpty(TextEditCodigoArticulo.Text) Then
                actualizarCampoStockOrigen()
            End If
        Catch ex As InvalidOperationException
            TextEditCodigoUbicacion.SelectAll()
            MessageFactory.ShowMessage(MessageType.Error, InvalidLocationCodeMessage)
            e.Cancel = True ' Previene que el foco salga del control si la validación falla
        End Try
    End Sub

    Private Sub SpinEditCantidadSeleccionada_Validating(sender As Object, e As CancelEventArgs) Handles SpinEditCantidadSeleccionada.Validating
        If SpinEditCantidadSeleccionada.Value <= 0 Then
            MessageFactory.ShowMessage(MessageType.Error, InvalidQuantityMessage)
            e.Cancel = True
            Exit Sub
        End If

        ' Validar que no exceda el stock disponible
        Dim stockDisponible As Integer
        If Integer.TryParse(LabelStockArticulo.Text, stockDisponible) Then
            Dim cantidadYaAsignada As Integer = ListaProductos.
                Where(Function(p) p.NombreComercial = LabelNombreArticulo.Text).
                Sum(Function(p) p.CantidadAMover)

            If SpinEditCantidadSeleccionada.Value > (stockDisponible - cantidadYaAsignada) Then
                MessageFactory.ShowMessage(MessageType.Warning,
                    String.Format(InsufficientStockMessage, stockDisponible - cantidadYaAsignada))
                e.Cancel = True
            End If
        Else
            MessageFactory.ShowMessage(MessageType.Error, "No se pudo determinar el stock disponible")
            e.Cancel = True
        End If
    End Sub

End Class