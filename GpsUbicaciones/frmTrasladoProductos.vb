Imports System.ComponentModel
Imports DevExpress.Mvvm.Native
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTrasladoProductos

    Private ArticuloTransferido As ProductoTraslado = Nothing
    Private ListaArticulos As New BindingList(Of ProductoTraslado)

#Region "Configuracion Iniciales"
    Private Sub ConfigurarGrid()
        GridControlArticulosParaTraslado.DataSource = ListaArticulos
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
            CreateColumn("CodigoUbicacionOrigen", "UBICACIÓN", 100),
            CreateColumn("Stock", "STOCK", 60),
            CreateColumn("CantidadAMover", "CANTIDAD", 80)
        })

        ' Configurar columna de eliminación
        Dim colEliminar = CreateColumn("Eliminar", "ELIMINAR", 80)
        Dim repoButton = New RepositoryItemButtonEdit()
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
                Dim prodEliminado As ProductoTraslado = ListaArticulos(rowHandle)
                ListaArticulos.RemoveAt(rowHandle)

                If EsUltimoArticulo() Then
                    PermitirEdicion(TextEditCodigoArticuloDestino, False)
                End If

                ' Si el artículo eliminado es el actualmente visible, actualizar MaxValue
                If prodEliminado.Articulo.NombreComercial = LabelNombreArticuloOrigen.Text Then
                    Dim stockTotal As Integer = Integer.Parse(LabelStockArticuloOrigen.Text)
                    Dim cantidadYaAsignada As Integer = ListaArticulos.
                        Where(Function(p) p.Articulo.NombreComercial = prodEliminado.Articulo.NombreComercial).
                        Sum(Function(p) p.CantidadAMover)
                    SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = Math.Max(0, stockTotal - cantidadYaAsignada)
                End If
            End If
        End If
    End Sub

    Private Sub frmTransladoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigurarGrid()
        PermitirEdicion(TextEditCodigoUbicacionOrigen, True)
        PermitirEdicion(SpinEditCantidadSeleccionadaOrigen, False)
        PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)
    End Sub
#End Region

#Region "Validación de Campos"

    Private Function EsUltimoArticulo() As Boolean
        Return ListaArticulos.Count = 0
    End Function

    Private Function ValidarCamposRequeridosOrigen() As Boolean
        Return Not (String.IsNullOrEmpty(TextEditCodigoArticuloOrigen.Text)) AndAlso
               Not (String.IsNullOrEmpty(TextEditCodigoUbicacionOrigen.Text))
    End Function
    Private Function ValidarStockDisponible(nombreArticulo As String, cantidadSolicitada As Decimal, Optional productoExistente As ProductoTraslado = Nothing) As Boolean
        Dim stockDisponible As Single = Single.Parse(LabelStockArticuloOrigen.Text)
        Dim cantidadYaAsignada As Single = ListaArticulos.
            Where(Function(p) p.Articulo.NombreComercial = nombreArticulo).Sum(Function(p) p.CantidadAMover)

        ' Si estamos actualizando un producto existente, restamos su cantidad actual
        If productoExistente IsNot Nothing Then
            cantidadYaAsignada -= productoExistente.CantidadAMover
        End If

        If cantidadSolicitada > (stockDisponible - cantidadYaAsignada) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia,
                String.Format(MensajesStock.Insuficiente, stockDisponible - cantidadYaAsignada))
            Return False
        End If

        Return True
    End Function
#End Region

#Region "Control de UI"

    Private Sub AceptarDecimales(Control As SpinEdit, Valor As Boolean)
        Control.Properties.Mask.UseMaskAsDisplayFormat = True
        If Valor Then
            Control.Properties.IsFloatValue = True
            Control.Properties.EditMask = $"N{nDecUds}"
            Control.Properties.Increment = 0.1
            LabelIndicadorPorPesoOrigen.Visible = True
        Else
            Control.Properties.IsFloatValue = False
            Control.Properties.EditMask = "d"
            Control.Properties.Increment = 1
            LabelIndicadorPorPesoOrigen.Visible = False
        End If
    End Sub

    Private Sub actualizarCampoStockOrigen()
        Try
            If String.IsNullOrEmpty(TextEditCodigoArticuloOrigen.Text) OrElse String.IsNullOrEmpty(TextEditCodigoUbicacionOrigen.Text) Then
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarStockDeLote,
                              TextEditCodigoArticuloOrigen.Text,
                              TextEditCodigoUbicacionOrigen.Text), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                LabelStockArticuloOrigen.Text = "0"
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = 0
                Return
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                LabelStockArticuloOrigen.Text = stock.ToString()
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = stock
            Else
                LabelStockArticuloOrigen.Text = "0"
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = 0
            End If
        Catch ex As Exception
            LabelStockArticuloOrigen.Text = "0"
            SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = 0
        End Try
    End Sub

    Private Sub LimpiarCamposOrigen()
        TextEditCodigoArticuloOrigen.Clear()
        TextEditCodigoUbicacionOrigen.Clear()
        LabelStockArticuloOrigen.Text = String.Empty
        LabelNombreUbicacionOrigen.Text = String.Empty
        LabelNombreArticuloOrigen.Text = String.Empty
        SpinEditCantidadSeleccionadaOrigen.Value = 0
        PermitirEdicion(TextEditCodigoUbicacionOrigen, False)
        PermitirEdicion(SpinEditCantidadSeleccionadaOrigen, False)
    End Sub
    Private Sub LimpiarCamposDestino()
        TextEditCodigoArticuloDestino.Clear()
        TextEditCodigoUbicacionDestino.Clear()
        LabelStockArticuloDestino.Text = String.Empty
        LabelNombreUbicacionDestino.Text = String.Empty
        LabelNombreArticuloDestino.Text = String.Empty
        SpinEditCantidadSeleccionadaDestino.Value = 0
        PermitirEdicion(TextEditCodigoUbicacionDestino, False)
        PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)
    End Sub

    Private Sub PermitirEdicion(campo As Control, estado As Boolean)
        campo.Enabled = estado
    End Sub
    Private Sub teCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoArticuloOrigen.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub teCodigoUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoUbicacionOrigen.KeyPress
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

#End Region

#Region "Eventos del Formulario"

    Private Sub BotonAgregarArticulo_Click(sender As Object, e As EventArgs) Handles BotonAgregarArticulo.Click
        ' Validaciones previas
        If Not ValidarCamposRequeridosOrigen() Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesGenerales.FaltanCampos)
            Exit Sub
        End If

        If SpinEditCantidadSeleccionadaOrigen.Value = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
            Exit Sub
        End If

        Try
            Dim productoExistente = ListaArticulos.FirstOrDefault(Function(p) p.Articulo.Codigo = TextEditCodigoArticuloOrigen.Text)

            If productoExistente IsNot Nothing Then
                GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesArticulos.ArticuloYaSeleccionado)
            Else
                ' Validar stock para nuevo producto
                If Not ValidarStockDisponible(LabelNombreArticuloOrigen.Text, SpinEditCantidadSeleccionadaOrigen.Value) Then
                    LimpiarCamposOrigen()
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.ArticuloYaSeleccionado)
                    Exit Sub
                End If

                Dim nuevoProducto As New ProductoTraslado With {
                    .Articulo = RepositorioArticulo.ObtenerInFormacion(TextEditCodigoArticuloOrigen.Text),
                    .CodigoUbicacionOrigen = TextEditCodigoUbicacionOrigen.Text,
                    .Stock = LabelStockArticuloOrigen.Text,
                    .CantidadAMover = SpinEditCantidadSeleccionadaOrigen.Value
                }

                ListaArticulos.Add(nuevoProducto)
                PermitirEdicion(TextEditCodigoUbicacionDestino, True)
                LimpiarCamposOrigen()
                SpinEditCantidadSeleccionadaOrigen.Value = 0
            End If
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesGenerales.SinDatos, ex.Message))
        End Try
    End Sub

    Private Sub BotonConfirmarTraslado_Click(sender As Object, e As EventArgs) Handles BotonConfirmarTraslado.Click
        Dim Trx = New NestedConditionalTransaction(Operacion)

        Dim SiExiste As Action(Of IDbConnection) = Sub(Conn)
                                                       RepositorioStockLote.MoverStock(Conn, SpinEditCantidadSeleccionadaDestino.Value, TextEditCodigoArticuloDestino.Text, TextEditCodigoUbicacionDestino.Text)
                                                   End Sub
        Dim NoExiste As Action(Of IDbConnection) = Sub(Conn)
                                                       RepositorioStockLote.InsertarArticulo(Conn, SpinEditCantidadSeleccionadaDestino.Value, TextEditCodigoArticuloDestino.Text, TextEditCodigoUbicacionDestino.Text, Almacen)
                                                   End Sub

        Dim success = Trx.ExecuteConditionalTransaction(
            Querys.Select.VerificarExistenciaLoteDeArticulo,
            SiExiste,
            NoExiste,
            TextEditCodigoArticuloDestino.Text,
            TextEditCodigoUbicacionDestino.Text
        )

        If success Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesGenerales.GuardadoCorrectamente)

            Dim articuloEnLista = ListaArticulos.Where(Function(p) p.Articulo.Codigo = ArticuloTransferido.Articulo.Codigo).FirstOrDefault()

            If articuloEnLista IsNot Nothing Then
                If articuloEnLista.CantidadAMover = SpinEditCantidadSeleccionadaDestino.Value Then
                    ListaArticulos.Remove(articuloEnLista)
                Else
                    articuloEnLista.CantidadAMover -= SpinEditCantidadSeleccionadaDestino.Value
                    ListaArticulos = New BindingList(Of ProductoTraslado)(ListaArticulos.Where(Function(p) p IsNot articuloEnLista).Concat({articuloEnLista}).ToList())
                End If
            End If

            LimpiarCamposDestino()
            PermitirEdicion(TextEditCodigoUbicacionDestino, False)
            PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)
            ArticuloTransferido = Nothing
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TextEditCodigoArticuloDestino_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticuloDestino.EditValueChanged

        If TextEditCodigoArticuloDestino.Text = String.Empty Then
            Exit Sub
        End If

        ArticuloTransferido = ListaArticulos.Where(Function(p) p.Articulo.Codigo = TextEditCodigoArticuloDestino.Text).FirstOrDefault()

        If ArticuloTransferido Is Nothing Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.CodigoInvalido)
            TextEditCodigoArticuloDestino.Focus()
            TextEditCodigoArticuloDestino.SelectAll()
            Exit Sub
        End If

        Dim Trx = New NestedConditionalTransaction(Operacion)

        Dim SiExiste As Action(Of IDbConnection) = Sub(Conn)
                                                       Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditCodigoArticuloDestino.Text, TextEditCodigoUbicacionDestino.Text)
                                                           If StockLote IsNot Nothing Then
                                                               LabelStockArticuloDestino.Text = StockLote.Cantidad
                                                           End If
                                                       End Using
                                                   End Sub
        Dim NoExiste As Action(Of IDbConnection) = Sub(Conn)
                                                       LabelStockArticuloDestino.Text = 0
                                                   End Sub

        Trx.ExecuteConditionalTransaction(
            Querys.Select.VerificarExistenciaLoteDeArticulo,
            SiExiste,
            NoExiste,
            TextEditCodigoArticuloDestino.Text,
            TextEditCodigoUbicacionDestino.Text
        )

        LabelNombreArticuloDestino.Text = ArticuloTransferido.Articulo.NombreComercial

        AceptarDecimales(SpinEditCantidadSeleccionadaDestino, ArticuloTransferido.Articulo.PorPeso)
        PermitirEdicion(SpinEditCantidadSeleccionadaDestino, True)
        SpinEditCantidadSeleccionadaDestino.Properties.MaxValue = ArticuloTransferido.CantidadAMover

    End Sub

    Private Sub TextEditCodigoArticuloOrigen_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticuloOrigen.EditValueChanged

        If TextEditCodigoArticuloOrigen.Text = String.Empty Then
            Exit Sub
        End If

        Dim stockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditCodigoArticuloOrigen.Text, TextEditCodigoUbicacionOrigen.Text)
        If stockLote Is Nothing Then
            TextEditCodigoUbicacionOrigen.Focus()
            TextEditCodigoUbicacionOrigen.SelectAll()
            Exit Sub
        End If

        LabelNombreArticuloOrigen.Text = stockLote.Articulo.NombreComercial

        AceptarDecimales(SpinEditCantidadSeleccionadaOrigen, stockLote.Articulo.PorPeso)

        LabelNombreUbicacionOrigen.Text = stockLote.Lote.Nombre
        LabelStockArticuloOrigen.Text = stockLote.Cantidad.ToString()
        SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = stockLote.Cantidad
        PermitirEdicion(SpinEditCantidadSeleccionadaOrigen, True)
    End Sub

    Private Sub TextEditCodigoUbicacionDestino_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacionDestino.EditValueChanged
        If TextEditCodigoUbicacionDestino.Text = String.Empty Then
            Exit Sub
        End If

        Dim Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacionDestino.Text)

        If Ubicacion Is Nothing Then
            TextEditCodigoUbicacionDestino.Focus()
            TextEditCodigoUbicacionDestino.SelectAll()
            Exit Sub
        End If


        LabelNombreUbicacionDestino.Text = Ubicacion.Nombre
        PermitirEdicion(TextEditCodigoArticuloDestino, True)

    End Sub

    Private Sub TextEditCodigoUbicacionOrigen_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacionOrigen.EditValueChanged

        If TextEditCodigoUbicacionOrigen.Text = String.Empty Then
            Exit Sub
        End If

        Dim Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacionOrigen.Text)

        If Ubicacion Is Nothing Then
            TextEditCodigoUbicacionOrigen.Focus()
            TextEditCodigoUbicacionOrigen.SelectAll()
            Exit Sub
        End If

        LabelNombreUbicacionOrigen.Text = Ubicacion.Nombre
        PermitirEdicion(TextEditCodigoUbicacionOrigen, True)
    End Sub
#End Region

End Class