Imports System.ComponentModel
Imports DevExpress.Data.Extensions
Imports DevExpress.Mvvm.Native
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmTrasladoProductos

    Private ArticuloTransferido As ProductoTraslado = Nothing
    Private ReadOnly ListaArticulos As New BindingList(Of ProductoTraslado)

#Region "Configuracion Iniciales"
    Private Sub ConfigurarGrid()
        GridControlArticulosParaTraslado.DataSource = ListaArticulos
        GridViewArticulosParaTraslado.Columns.Clear()

        ' Método auxiliar para crear columnas
        Dim CreateColumn = Function(fieldName As String, caption As String, width As Integer) As GridColumn
                               Dim col As New GridColumn() With {
                                   .FieldName = fieldName,
                                   .Caption = caption,
                                   .Visible = True,
                                   .Width = width
                               }
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
        Try
            Dim gridView As GridView = TryCast(GridControlArticulosParaTraslado.MainView, GridView)

            If gridView IsNot Nothing Then
                Dim rowHandle As Integer = gridView.FocusedRowHandle

                If rowHandle >= 0 Then
                    Dim prodEliminado As ProductoTraslado = ListaArticulos(rowHandle)
                    ListaArticulos.RemoveAt(rowHandle)

                    If EsUltimoArticulo() Then
                        PermitirEdicion(TextEditCodigoArticuloDestino, False)
                        PermitirEdicion(TextEditCodigoArticuloOrigen, True)
                    End If

                    ActualizarMaximoValorCantidad(prodEliminado)
                End If
            End If
        Catch ex As Exception
            ManejarError(ex, "Error al eliminar fila")
        End Try
    End Sub

    Private Sub ActualizarMaximoValorCantidad(prodEliminado As ProductoTraslado)
        ' Si el artículo eliminado es el actualmente visible, actualizar MaxValue
        If prodEliminado.Articulo.NombreComercial = LabelNombreArticuloOrigen.Text Then
            Try
                Dim stockTotal As Integer = Integer.Parse(LabelStockArticuloOrigen.Text)
                Dim cantidadYaAsignada As Integer = ListaArticulos.
                    Where(Function(p) p.Articulo.NombreComercial = prodEliminado.Articulo.NombreComercial).
                    Sum(Function(p) p.CantidadAMover)
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = Math.Max(0, stockTotal - cantidadYaAsignada)
            Catch ex As Exception
                ' Si hay problemas con la conversión, establecer a 0 por seguridad
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = 0
                ManejarError(ex, "Error al actualizar valor máximo")
            End Try
        End If
    End Sub

    Private Sub frmTransladoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConfigurarGrid()
            ConfigurarEstadoInicial()
        Catch ex As Exception
            ManejarError(ex, "Error al cargar el formulario")
        End Try
    End Sub

    Private Sub ConfigurarEstadoInicial()
        PermitirEdicion(TextEditCodigoUbicacionOrigen, True)
        PermitirEdicion(TextEditCodigoArticuloOrigen, False)
        PermitirEdicion(SpinEditCantidadSeleccionadaOrigen, False)
        PermitirEdicion(TextEditCodigoUbicacionDestino, False)
        PermitirEdicion(TextEditCodigoArticuloDestino, False)
        PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)
    End Sub
#End Region

#Region "Validación de Campos"

    Private Function EsUltimoArticulo() As Boolean
        Return ListaArticulos.Count = 0
    End Function

    Private Function ValidarCamposRequeridosOrigen() As Boolean
        Return Not (String.IsNullOrWhiteSpace(TextEditCodigoArticuloOrigen.Text)) AndAlso
               Not (String.IsNullOrWhiteSpace(TextEditCodigoUbicacionOrigen.Text))
    End Function

    Private Function ValidarCamposRequeridosDestino() As Boolean
        Return Not (String.IsNullOrWhiteSpace(TextEditCodigoArticuloDestino.Text)) AndAlso
               Not (String.IsNullOrWhiteSpace(TextEditCodigoUbicacionDestino.Text)) AndAlso
               SpinEditCantidadSeleccionadaDestino.Value > 0
    End Function

    Private Function ValidarStockDisponible(nombreArticulo As String, cantidadSolicitada As Decimal, Optional productoExistente As ProductoTraslado = Nothing) As Boolean
        Try
            Dim stockDisponible As Single
            If Not Single.TryParse(LabelStockArticuloOrigen.Text, stockDisponible) Then
                Return False
            End If

            Dim cantidadYaAsignada As Single = ListaArticulos.
                Where(Function(p) p.Articulo.NombreComercial = nombreArticulo).
                Sum(Function(p) p.CantidadAMover)

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
        Catch ex As Exception
            ManejarError(ex, "Error validando stock disponible")
            Return False
        End Try
    End Function

    Private Function EsMismaUbicacion() As Boolean
        Return TextEditCodigoUbicacionOrigen.Text.Trim().Equals(TextEditCodigoUbicacionDestino.Text.Trim(), StringComparison.OrdinalIgnoreCase)
    End Function
#End Region

#Region "Control de UI"

    Private Sub ActualizarCampoStockOrigen()
        Try
            If String.IsNullOrWhiteSpace(TextEditCodigoArticuloOrigen.Text) OrElse
               String.IsNullOrWhiteSpace(TextEditCodigoUbicacionOrigen.Text) Then
                LimpiarStockOrigen()
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarStockDeLote,
                              TextEditCodigoArticuloOrigen.Text,
                              TextEditCodigoUbicacionOrigen.Text), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                LimpiarStockOrigen()
                Exit Sub
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                LabelStockArticuloOrigen.Text = stock.ToString()
                SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = stock
            Else
                LimpiarStockOrigen()
            End If
        Catch ex As Exception
            LimpiarStockOrigen()
            ManejarError(ex, "Error al actualizar campo stock origen")
        End Try
    End Sub

    Private Sub LimpiarStockOrigen()
        LabelStockArticuloOrigen.Text = "0"
        SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = 0
    End Sub

    Private Sub LimpiarCamposOrigen()
        TextEditCodigoArticuloOrigen.Clear()
        TextEditCodigoUbicacionOrigen.Clear()
        LabelStockArticuloOrigen.Text = String.Empty
        LabelNombreUbicacionOrigen.Text = String.Empty
        LabelNombreArticuloOrigen.Text = String.Empty
        SpinEditCantidadSeleccionadaOrigen.Value = 0
        LabelIndicadorPorPesoOrigen.Visible = False
    End Sub

    Private Sub LimpiarCamposDestino()
        TextEditCodigoArticuloDestino.Clear()
        TextEditCodigoUbicacionDestino.Clear()
        LabelStockArticuloDestino.Text = String.Empty
        LabelNombreUbicacionDestino.Text = String.Empty
        LabelNombreArticuloDestino.Text = String.Empty
        SpinEditCantidadSeleccionadaDestino.Value = 0
        LabelIndicadorPorPesoDestino.Visible = False
    End Sub

    Private Sub ManejarError(ex As Exception, mensaje As String)
        ' Mostrar mensaje al usuario
        FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"{mensaje}: {ex.Message}")
    End Sub

    ' Validación de entrada
    Private Sub ControlEntradaAlfanumerica(sender As Object, e As KeyPressEventArgs)
        ' Solo permitir caracteres alfanuméricos
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub teCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoArticuloOrigen.KeyPress,
                                                                                           TextEditCodigoArticuloDestino.KeyPress
        ControlEntradaAlfanumerica(sender, e)
    End Sub

    Private Sub teCodigoUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditCodigoUbicacionOrigen.KeyPress,
                                                                                            TextEditCodigoUbicacionDestino.KeyPress
        ControlEntradaAlfanumerica(sender, e)
    End Sub

#End Region

#Region "Eventos del Formulario"

    Private Sub BotonAgregarArticulo_Click(sender As Object, e As EventArgs) Handles BotonAgregarArticulo.Click
        Try
            ' Validaciones previas
            If Not ValidarCamposRequeridosOrigen() Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesGenerales.FaltanCampos)
                Exit Sub
            End If

            If SpinEditCantidadSeleccionadaOrigen.Value <= 0 Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
                Exit Sub
            End If

            ' Buscar si el artículo ya existe en la lista
            Dim productoExistente = ListaArticulos.FirstOrDefault(Function(p) p.Articulo.Codigo = TextEditCodigoArticuloOrigen.Text)

            If productoExistente IsNot Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesArticulos.ArticuloYaSeleccionado)
                Exit Sub
            End If

            ' Validar stock para nuevo producto
            If Not ValidarStockDisponible(LabelNombreArticuloOrigen.Text, SpinEditCantidadSeleccionadaOrigen.Value) Then
                Exit Sub
            End If

            ' Crear y agregar el nuevo producto
            Dim nuevoProducto As New ProductoTraslado With {
                .Articulo = RepositorioArticulo.ObtenerInFormacion(TextEditCodigoArticuloOrigen.Text),
                .CodigoUbicacionOrigen = TextEditCodigoUbicacionOrigen.Text,
                .Stock = LabelStockArticuloOrigen.Text,
                .CantidadAMover = SpinEditCantidadSeleccionadaOrigen.Value
            }

            ListaArticulos.Add(nuevoProducto)
            PermitirEdicion(TextEditCodigoUbicacionDestino, True, False)
            PermitirEdicion(TextEditCodigoUbicacionOrigen, True, False)
            PermitirEdicion(TextEditCodigoArticuloOrigen, False)
            LimpiarCamposOrigen()

        Catch ex As Exception
            ManejarError(ex, "Error al agregar artículo")
        End Try
    End Sub

    Private Sub BotonConfirmarTraslado_Click(sender As Object, e As EventArgs) Handles BotonConfirmarTraslado.Click
        Try
            If Not ValidarCamposRequeridosDestino() Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesGenerales.FaltanCampos)
                Exit Sub
            End If

            If ArticuloTransferido Is Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.CodigoInvalido)
                Exit Sub
            End If

            If EsMismaUbicacion() Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "No se puede transferir a la misma ubicación")
                Exit Sub
            End If

            Dim Trx = New NestedConditionalTransaction(Operacion)

            Dim SiExiste As Action(Of IDbConnection) = Sub(Conn)
                                                           RepositorioStockLote.TransferirStock(Conn,
                                                                                             SpinEditCantidadSeleccionadaDestino.Value,
                                                                                             TextEditCodigoArticuloDestino.Text,
                                                                                             ArticuloTransferido.CodigoUbicacionOrigen,
                                                                                             TextEditCodigoUbicacionDestino.Text)
                                                       End Sub

            Dim NoExiste As Action(Of IDbConnection) = Sub(Conn)
                                                           RepositorioStockLote.InsertarArticuloDesdeStock(Conn,
                                                                                                        SpinEditCantidadSeleccionadaDestino.Value,
                                                                                                        TextEditCodigoArticuloDestino.Text,
                                                                                                        ArticuloTransferido.CodigoUbicacionOrigen,
                                                                                                        TextEditCodigoUbicacionDestino.Text)
                                                       End Sub

            Dim success = Trx.ExecuteConditionalTransaction(
                Querys.Select.VerificarExistenciaLoteDeArticulo,
                SiExiste,
                NoExiste,
                TextEditCodigoArticuloDestino.Text,
                TextEditCodigoUbicacionDestino.Text
            )

            If success Then
                ActualizarListaDespuesDeTransferencia()
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesGenerales.GuardadoCorrectamente)
            Else
                FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al realizar la transferencia")
            End If
        Catch ex As Exception
            ManejarError(ex, "Error al confirmar traslado")
        End Try
    End Sub

    Private Sub ActualizarListaDespuesDeTransferencia()
        Try
            Dim index = ListaArticulos.FindIndex(Function(p) p.Articulo.Codigo = ArticuloTransferido.Articulo.Codigo)

            If index >= 0 Then
                Dim articuloEnLista = ListaArticulos(index)
                If articuloEnLista.CantidadAMover <= SpinEditCantidadSeleccionadaDestino.Value Then
                    ListaArticulos.RemoveAt(index)
                Else
                    articuloEnLista.CantidadAMover -= SpinEditCantidadSeleccionadaDestino.Value
                End If
            End If

            GridViewArticulosParaTraslado.RefreshData()

            LimpiarCamposDestino()
            PermitirEdicion(TextEditCodigoArticuloDestino, False)
            PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)

            If EsUltimoArticulo() Then
                PermitirEdicion(TextEditCodigoUbicacionDestino, False)
                PermitirEdicion(TextEditCodigoUbicacionOrigen, True)
            Else
                PermitirEdicion(TextEditCodigoUbicacionDestino, True)
            End If

            ArticuloTransferido = Nothing
        Catch ex As Exception
            ManejarError(ex, "Error al actualizar lista después de transferencia")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TextEditCodigoArticuloDestino_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticuloDestino.EditValueChanged
        Try
            If String.IsNullOrWhiteSpace(TextEditCodigoArticuloDestino.Text) Then
                LimpiarCamposDestino()
                PermitirEdicion(SpinEditCantidadSeleccionadaDestino, False)
                Exit Sub
            End If

            ArticuloTransferido = ListaArticulos.FirstOrDefault(Function(p) p.Articulo.Codigo = TextEditCodigoArticuloDestino.Text)

            If ArticuloTransferido Is Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.CodigoInvalido)
                TextEditCodigoArticuloDestino.Focus()
                TextEditCodigoArticuloDestino.SelectAll()
                Exit Sub
            End If

            ActualizarStockDestino()

            LabelNombreArticuloDestino.Text = ArticuloTransferido.Articulo.NombreComercial

            AceptarDecimales(SpinEditCantidadSeleccionadaDestino, ArticuloTransferido.Articulo.PorPeso, LabelIndicadorPorPesoDestino)
            PermitirEdicion(SpinEditCantidadSeleccionadaDestino, True)
            SpinEditCantidadSeleccionadaDestino.Properties.MaxValue = ArticuloTransferido.CantidadAMover
        Catch ex As Exception
            ManejarError(ex, "Error al cambiar código de artículo destino")
        End Try
    End Sub

    Private Sub ActualizarStockDestino()
        Try
            Dim Trx = New NestedConditionalTransaction(Operacion)

            Dim SiExiste As Action(Of IDbConnection) = Sub(Conn)
                                                           Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(
                                                                        TextEditCodigoArticuloDestino.Text,
                                                                        TextEditCodigoUbicacionDestino.Text)
                                                               If StockLote IsNot Nothing Then
                                                                   LabelStockArticuloDestino.Text = StockLote.Cantidad.ToString()
                                                               Else
                                                                   LabelStockArticuloDestino.Text = "0"
                                                               End If
                                                           End Using
                                                       End Sub

            Dim NoExiste As Action(Of IDbConnection) = Sub(Conn)
                                                           LabelStockArticuloDestino.Text = "0"
                                                       End Sub

            Trx.ExecuteConditionalTransaction(
                Querys.Select.VerificarExistenciaLoteDeArticulo,
                SiExiste,
                NoExiste,
                TextEditCodigoArticuloDestino.Text,
                TextEditCodigoUbicacionDestino.Text
            )
        Catch ex As Exception
            LabelStockArticuloDestino.Text = "0"
            ManejarError(ex, "Error al actualizar stock destino")
        End Try
    End Sub

    Private Sub TextEditCodigoArticuloOrigen_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticuloOrigen.EditValueChanged
        Try
            If String.IsNullOrWhiteSpace(TextEditCodigoArticuloOrigen.Text) OrElse
               String.IsNullOrWhiteSpace(TextEditCodigoUbicacionOrigen.Text) Then
                Exit Sub
            End If

            Dim stockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditCodigoArticuloOrigen.Text, TextEditCodigoUbicacionOrigen.Text)
            If stockLote Is Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "El artículo no existe en esta ubicación")
                TextEditCodigoUbicacionOrigen.Focus()
                TextEditCodigoUbicacionOrigen.SelectAll()
                Exit Sub
            End If

            LabelNombreArticuloOrigen.Text = stockLote.Articulo.NombreComercial
            AceptarDecimales(SpinEditCantidadSeleccionadaOrigen, stockLote.Articulo.PorPeso, LabelIndicadorPorPesoOrigen)
            LabelNombreUbicacionOrigen.Text = stockLote.Lote.Nombre
            LabelStockArticuloOrigen.Text = stockLote.Cantidad.ToString()
            SpinEditCantidadSeleccionadaOrigen.Properties.MaxValue = stockLote.Cantidad
            PermitirEdicion(SpinEditCantidadSeleccionadaOrigen, True)
        Catch ex As Exception
            LimpiarCamposOrigen()
            ManejarError(ex, "Error al cambiar código de artículo origen")
        End Try
    End Sub

    Private Sub TextEditCodigoUbicacionDestino_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacionDestino.EditValueChanged
        Try
            If String.IsNullOrWhiteSpace(TextEditCodigoUbicacionDestino.Text) Then
                PermitirEdicion(TextEditCodigoArticuloDestino, False)
                LabelNombreUbicacionDestino.Text = String.Empty
                Exit Sub
            End If

            Dim Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacionDestino.Text)

            If Ubicacion Is Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "Ubicación no encontrada")
                TextEditCodigoUbicacionDestino.Focus()
                TextEditCodigoUbicacionDestino.SelectAll()
                Exit Sub
            End If

            If EsMismaUbicacion() Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "No se puede transferir a la misma ubicación")
                TextEditCodigoUbicacionDestino.Focus()
                TextEditCodigoUbicacionDestino.SelectAll()
                Exit Sub
            End If

            LabelNombreUbicacionDestino.Text = Ubicacion.Nombre
            PermitirEdicion(TextEditCodigoArticuloDestino, True)

            ' Si ya hay un artículo seleccionado, actualizar su stock en la nueva ubicación
            If ArticuloTransferido IsNot Nothing Then
                ActualizarStockDestino()
            End If
        Catch ex As Exception
            ManejarError(ex, "Error al cambiar código de ubicación destino")
        End Try
    End Sub

    Private Sub TextEditCodigoUbicacionOrigen_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacionOrigen.EditValueChanged
        Try
            If String.IsNullOrWhiteSpace(TextEditCodigoUbicacionOrigen.Text) Then
                PermitirEdicion(TextEditCodigoArticuloOrigen, False)
                LabelNombreUbicacionOrigen.Text = String.Empty
                Exit Sub
            End If

            Dim Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacionOrigen.Text)

            If Ubicacion Is Nothing Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "Ubicación no encontrada")
                TextEditCodigoUbicacionOrigen.Focus()
                TextEditCodigoUbicacionOrigen.SelectAll()
                Exit Sub
            End If

            LabelNombreUbicacionOrigen.Text = Ubicacion.Nombre
            PermitirEdicion(TextEditCodigoArticuloOrigen, True)

            ' Si ya hay un artículo seleccionado, actualizar su stock
            If Not String.IsNullOrWhiteSpace(TextEditCodigoArticuloOrigen.Text) Then
                ActualizarCampoStockOrigen()
            End If
        Catch ex As Exception
            ManejarError(ex, "Error al cambiar código de ubicación origen")
        End Try
    End Sub
#End Region

End Class