Imports System.ComponentModel

Public Class frmTrasladoProductos

    Private ReadOnly ArticulosEnEspera As New BindingList(Of ProductoTraslado)
    Private PatronDeTrabajo = True ' TRUE: Agregar a la lista de espera | FALSE: Realizar Transferencia

#Region "Configuracion Iniciales"

    Private Sub frmTransladoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'Cargar estado temporal
            Dim table = Operacion.ExecuteTable("SELECT * FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = 'TR'", Terminal)

            For Each transaction As DataRow In table.Rows
                ArticulosEnEspera.Add(New ProductoTraslado With {
                    .Articulo = RepositorioArticulo.ObtenerInformacion(transaction("Articulo")),
                    .CantidadAMover = Single.Parse(transaction("Cantidad")),
                    .CodigoUbicacionOrigen = transaction("Lote")
                })
            Next

            ProductoTrasladoBindingSource.DataSource = ArticulosEnEspera
            PermitirEdicion(TextEditItem, False)
            PermitirEdicion(SpinEditCantidadSeleccionada, False)
            PermitirEdicion(TextEditLocation, True)

            GroupControl.CustomHeaderButtons("Cargar/Descargar").Properties.Appearance.ForeColor = Color.White

        Catch ex As Exception
            ManejarError(ex, "Error al cargar el formulario")
        End Try
    End Sub

#End Region

#Region "Control de UI"

    Private Sub LimpiarCampos()
        TextEditLocation.Clear()
        TextEditItem.Clear()
        LabelLocation.Text = String.Empty
        LabelStockArticulo.Text = String.Empty
        LabelItemName.Text = String.Empty
        SpinEditCantidadSeleccionada.Value = 0
        IconWeight.Visible = False
    End Sub

    Private Sub ManejarError(ex As Exception, mensaje As String)
        ' Mostrar mensaje al usuario
        FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"{mensaje}: {ex.Message}")
    End Sub

#End Region

#Region "Eventos del Formulario"

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        If PatronDeTrabajo Then
            ' Agregar a MOVPDA OPERACION:TR[Transeferencia]
            Operacion.ExecuteNonQuery("INSERT INTO MOVPDA VALUES(?,'TR',?,?,?)", Terminal, TextEditItem.Text, SpinEditCantidadSeleccionada.Value, TextEditLocation.Text)

            ' Agregar a la lista de espera
            Dim articuloParaTranslado As New ProductoTraslado With {
                .Articulo = RepositorioArticulo.ObtenerInformacion(TextEditItem.Text),
                .CantidadAMover = SpinEditCantidadSeleccionada.Value,
                .CodigoUbicacionOrigen = TextEditLocation.Text
            }

            ArticulosEnEspera.Add(articuloParaTranslado)
            LimpiarCampos()
            PermitirEdicion(TextEditItem, False)
            PermitirEdicion(SpinEditCantidadSeleccionada, False)
            PermitirEdicion(TextEditLocation, True)

            GridControlArticulosParaTraslado.Visible = True
        Else
            'Obtener Articulos en la lista para cubrir la transferencia y realizar el desconteo/transferencia
            Try
                DescontarDeArticulosEnEspera(SpinEditCantidadSeleccionada.Value, BuscarArticulosParaDescuento(TextEditItem.Text, TextEditLocation.Text))
            Catch ex As Exception
                ManejarError(ex, "Error al confirmar traslado")
            End Try

        End If
    End Sub

    Private Sub ButtonClearForm_Click(sender As Object, e As EventArgs) Handles ButtonClearForm.Click
        LimpiarCampos()
        PermitirEdicion(SpinEditCantidadSeleccionada, False)
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(TextEditLocation, True)
    End Sub
    Private Sub GroupControl_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GroupControl.CustomButtonClick
        PatronDeTrabajo = Not PatronDeTrabajo
        CambioDePatron(PatronDeTrabajo)
    End Sub

    Private Sub LabelLoadedAmount_Click(sender As Object, e As EventArgs) Handles LabelLoadedAmount.Click
        SpinEditCantidadSeleccionada.Value = LabelLoadedAmount.Text
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Funciones Auxiliares"
    ''' <summary>
    ''' Busca los articulos en espera con el mismo codigo de articulo y codigo de ubicacion 
    ''' </summary>
    ''' <param name="codigoArticulo">Codigo,Codigo de Barras o Referencia del Proveedor del articulo</param>
    ''' <param name="codigoUbicacion">Codigo de la ubicacion</param>
    ''' <returns>False si no encuentra el articulo, True en caso contrario</returns>
    Private Function BuscarArticuloEnEspera(codigoArticulo As String, codigoUbicacion As String) As Boolean
        Dim articulos = ArticulosEnEspera.Where(Function(A) A.Articulo.Codigo.Equals(codigoArticulo) And A.CodigoUbicacionOrigen.Equals(codigoUbicacion))

        Return articulos.Count > 0
    End Function

    ''' <summary>
    ''' Busca los articulos en espera con el mismo codigo de articulo y diferente codigo de ubicacion
    ''' </summary>
    ''' <param name="codigoArticulo"></param>
    ''' <param name="codigoUbicacion"></param>
    ''' <returns></returns>
    Private Function BuscarArticulosParaDescuento(codigoArticulo As String, codigoUbicacion As String) As Integer()
        Dim articulos = ArticulosEnEspera.Where(Function(A) _
            (
             A.Articulo.Codigo.Equals(codigoArticulo) OrElse
             A.Articulo.CodigoBarras.Equals(codigoArticulo) OrElse
             A.Articulo.ReferenciaProvedor.Equals(codigoArticulo)
             ) _
            And Not A.CodigoUbicacionOrigen.Equals(codigoUbicacion))

        ' Devolver los indices de los articulos encontrados
        Return articulos.Select(Function(A) ArticulosEnEspera.IndexOf(A)).ToArray
    End Function

    ''' <summary>
    ''' Descontar de los articulos en espera la cantidad asignada usando TransactionBlockExecutor
    ''' </summary>
    ''' <param name="cantidadAsignar">Cantidad total a asignar</param>
    ''' <param name="articulos">Índices de los artículos a procesar</param>
    ''' <returns>True si se realizó correctamente la operación</returns>
    Private Function DescontarDeArticulosEnEspera(cantidadAsignar As Single, articulos As Integer()) As Boolean
        If articulos Is Nothing OrElse articulos.Length = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "No hay artículos para procesar")
            Return False
        End If

        ' Usar la operación extendida que soporta transacciones
        Dim operacionExtendida As New AccessDatabaseOperationExtended(Configuracion.settings)

        Using transactionBlock As New TransactionBlockExecutor(operacionExtendida)
            Try
                Dim cantidadRestante As Single = cantidadAsignar
                Dim transferenciasRealizadas As New List(Of TransferenciaInfo)()
                Dim articulosParaActualizar As New List(Of (Articulo As ProductoTraslado, CantidadTransferida As Single))()

                ' Bloque de transacción que procesa todas las transferencias
                Dim procesoTransferencias As Action(Of IDbConnection, IDbTransaction) =
                Sub(conn, trans)
                    For i As Integer = 0 To articulos.Length - 1
                        If cantidadRestante <= 0 Then Exit For

                        Dim articulo As ProductoTraslado = ArticulosEnEspera(articulos(i))
                        Dim cantidadATransferir As Single = Math.Min(cantidadRestante, articulo.CantidadAMover)

                        ' Realizar la transferencia usando el repositorio extendido
                        Dim operacionesRealizadas = RepositorioStockLote.RealizarTransferenciaCompleta(
                            conn, trans,
                            cantidadATransferir,
                            articulo.Articulo.Codigo,
                            articulo.CodigoUbicacionOrigen,
                            TextEditLocation.Text)

                        If operacionesRealizadas > 0 Then
                            ' Registrar la transferencia exitosa
                            transferenciasRealizadas.Add(New TransferenciaInfo With {
                                .Cantidad = cantidadATransferir,
                                .CodigoArticulo = articulo.Articulo.Codigo,
                                .CodigoUbicacionOrigen = articulo.CodigoUbicacionOrigen,
                                .CodigoUbicacionDestino = TextEditLocation.Text,
                                .Descripcion = $"Transferencia de {cantidadATransferir} unidades"
                            })

                            ' Registrar para actualización posterior
                            articulosParaActualizar.Add((articulo, cantidadATransferir))
                            cantidadRestante -= cantidadATransferir

                            ' Agregar al historico de transferencias
                            If operacionExtendida IsNot Nothing Then
                                Dim filasHistorico = operacionExtendida.ExecuteNonQuery(conn, trans,
                                    "INSERT INTO LINTRASPLOTES VALUES (?,?,?,?,?)",
                                    Date.Now,                         ' Fecha actual
                                    articulo.Articulo.Codigo,         ' Código del artículo
                                    cantidadATransferir,              ' Unidades transferidas
                                    articulo.CodigoUbicacionOrigen,   ' Ubicación origen
                                    TextEditLocation.Text)            ' Ubicación destino

                                If filasHistorico <= 0 Then
                                    Throw New Exception($"Error al registrar en histórico la transferencia de {cantidadATransferir} unidades del artículo {articulo.Articulo.Codigo}")
                                End If
                            End If

                        Else
                            Throw New Exception($"No se pudo transferir {cantidadATransferir} unidades del artículo {articulo.Articulo.Codigo}")
                        End If
                    Next

                    ' Verificar que se procesó toda la cantidad
                    If cantidadRestante > 0 Then
                        Throw New Exception($"No se pudo procesar toda la cantidad. Restante: {cantidadRestante}")
                    End If
                End Sub

                ' Ejecutar el bloque de transacción
                Dim exito As Boolean = transactionBlock.ExecuteTransactionBlock(procesoTransferencias)

                If exito Then
                    ' Confirmar la transacción
                    transactionBlock.Commit()

                    ' Actualizar los artículos en memoria solo después del commit exitoso
                    ActualizarArticulosEnEspera(articulosParaActualizar)

                    ' Mostrar mensaje de éxito
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion,
                    $"Se realizaron {transferenciasRealizadas.Count} transferencias correctamente. " &
                    $"Cantidad total procesada: {cantidadAsignar - cantidadRestante}")

                    Return True
                Else
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al realizar las transferencias")
                    Return False
                End If

            Catch ex As Exception
                FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en el proceso: {ex.Message}")
                Return False
            End Try
        End Using
    End Function

    ''' <summary>
    ''' Actualiza los artículos en espera después de las transferencias exitosas
    ''' </summary>
    Private Sub ActualizarArticulosEnEspera(articulosParaActualizar As List(Of (Articulo As ProductoTraslado, CantidadTransferida As Single)))
        Dim articulosParaRemover As New List(Of ProductoTraslado)()

        For Each item In articulosParaActualizar
            If item.CantidadTransferida >= item.Articulo.CantidadAMover Then
                ' El artículo se agotó completamente
                articulosParaRemover.Add(item.Articulo)
            Else
                ' Reducir la cantidad restante
                item.Articulo.CantidadAMover -= item.CantidadTransferida
                Operacion.ExecuteNonQuery("UPDATE MOVPDA SET CANTIDAD = ? WHERE TERMINAL = ? AND OPERACION = 'TR' AND ARTICULO = ? AND LOTE = ?", item.Articulo.CantidadAMover, Terminal, item.Articulo.Articulo.Codigo, item.Articulo.CodigoUbicacionOrigen)
            End If
        Next

        ' Remover los artículos que se agotaron
        For Each articuloParaRemover In articulosParaRemover
            ArticulosEnEspera.Remove(articuloParaRemover)
            Operacion.ExecuteNonQuery("DELETE FROM MOVPDA WHERE ARTICULO = ? AND LOTE = ? AND TERMINAL = ? AND OPERACION = 'TR'", articuloParaRemover.Articulo.Codigo, articuloParaRemover.CodigoUbicacionOrigen, Terminal)
        Next

        ' Actualizar la grilla
        GridControlArticulosParaTraslado.RefreshDataSource()
        LabelLoadedAmount.Text = CalcularTotalEnEspera(TextEditItem.Text)
    End Sub

    Private Function CalcularTotalEnEspera(textEdit As String) As String
        Return ArticulosEnEspera.Where(Function(item) _
                                                                             item.Articulo.Codigo.Equals(textEdit) OrElse
                                                                             item.Articulo.CodigoBarras.Equals(textEdit) OrElse
                                                                             item.Articulo.ReferenciaProvedor.Equals(textEdit)
                        ).Sum(Function(item) item.CantidadAMover).ToString()
    End Function

    Private Function EliminarDeBaseDatos(codigo As String, ubicacionOrigen As String, cantidadAMover As Object) As Boolean
        Try
            Operacion.ExecuteNonQuery("Delete FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = 'TR' AND ARTICULO = ? AND LOTE = ?", Terminal, codigo, ubicacionOrigen)
            Return True
        Catch ex As Exception
            ' Log del error si es necesario
            Console.WriteLine("Error al eliminar de la base de datos MOVPDA: " & ex.Message)
            Return False
        End Try
    End Function


    Private Sub CambioDePatron(patron As Boolean)
        If patron Then
            GroupControl.Text = "Cargar En Carrito"
            GroupControl.AppearanceCaption.BorderColor = Color.SaddleBrown
            LabelLocation.BackColor = Color.Peru
            LabelItemName.BackColor = Color.Peru
            LabelStockArticulo.BackColor = Color.Peru
            LabelLoadedAmount.BackColor = Color.Peru
            PanelTitulo.BackColor = Color.Peru

            ButtonConfirm.ImageOptions.SvgImage = My.Resources.save
            LabelLoaded.Visible = False
            LabelLoadedAmount.Visible = False
            GroupControl.CustomHeaderButtons("Cargar/Descargar").Properties.Appearance.ForeColor = Color.White
        Else
            GroupControl.Text = "Realizar Transferencia"
            GroupControl.AppearanceCaption.BorderColor = Color.Indigo
            LabelLocation.BackColor = Color.BlueViolet
            LabelItemName.BackColor = Color.BlueViolet
            LabelStockArticulo.BackColor = Color.BlueViolet
            LabelLoadedAmount.BackColor = Color.BlueViolet
            PanelTitulo.BackColor = Color.BlueViolet

            ButtonConfirm.ImageOptions.SvgImage = My.Resources.actions_check
            LabelLoaded.Visible = True
            LabelLoadedAmount.Visible = True
            GroupControl.CustomHeaderButtons("Cargar/Descargar").Properties.Appearance.ForeColor = Color.White
        End If
    End Sub

#End Region

#Region "Validación de Campos"

    Private Sub ValidarUbicacion(sender As Object, e As CancelEventArgs) Handles TextEditLocation.Validating
        Try
            Dim textEdit = CType(sender, DevExpress.XtraEditors.TextEdit)

            If String.IsNullOrWhiteSpace(textEdit.Text) Then
                PermitirEdicion(TextEditItem, False)
                LabelLocation.Text = String.Empty
                LimpiarCampos()
                Return
            End If

            Dim ubicacion = RepositorioUbicacion.ObtenerInformacion(textEdit.Text)

            If ubicacion Is Nothing Then
                e.Cancel = True
                textEdit.Focus()
                textEdit.SelectAll()
                Exit Sub
            End If

            LabelLocation.Text = ubicacion.Nombre
            PermitirEdicion(TextEditItem, True)

        Catch ex As Exception
            e.Cancel = True
            TextEditLocation.Clear()
            ManejarError(ex, "Error al validar ubicación origen")
        End Try
    End Sub

    Private Sub ValidarArticulo(sender As Object, e As CancelEventArgs) Handles TextEditItem.Validating
        Try
            Dim textEdit = TextEditItem.Text

            If String.IsNullOrWhiteSpace(textEdit) OrElse
               String.IsNullOrWhiteSpace(TextEditLocation.Text) Then
                LimpiarCampos()
                Return
            End If

            Dim stockLote As StockLote

            If PatronDeTrabajo Then
                If BuscarArticuloEnEspera(TextEditItem.Text, TextEditLocation.Text) Then
                    ManejarError(Nothing, "No se usar la misma ubicación dos veces")
                    e.Cancel = True
                    Exit Sub
                End If

                stockLote = RepositorioStockLote.ObtenerArticuloEnLote(textEdit, TextEditLocation.Text)

                If stockLote Is Nothing Then
                    e.Cancel = True
                    TextEditItem.Focus()
                    TextEditItem.SelectAll()
                    Return
                End If

            Else
                stockLote = New StockLote With {
                    .Articulo = RepositorioArticulo.ObtenerInformacion(textEdit),
                    .Lote = RepositorioUbicacion.ObtenerInformacion(TextEditLocation.Text),
                    .UnidadesTransferidas = CalcularTotalEnEspera(textEdit)
                }

                LabelLoadedAmount.Text = CalcularTotalEnEspera(textEdit)
            End If

            LabelItemName.Text = stockLote.Articulo.NombreComercial
            AceptarDecimales(SpinEditCantidadSeleccionada, stockLote.Articulo.PorPeso, IconWeight)
            LabelLocation.Text = stockLote.Lote.Nombre
            LabelStockArticulo.Text = stockLote.Cantidad.ToString()
            SpinEditCantidadSeleccionada.Properties.MaxValue = stockLote.Cantidad
            SpinEditCantidadSeleccionada.Properties.MinValue = 0.0
            PermitirEdicion(SpinEditCantidadSeleccionada, True)

        Catch ex As Exception
            Logger.Instance.Error(ex:=ex, message:=ex.Message)
            e.Cancel = True
            TextEditItem.Clear()
            ManejarError(ex, "Error al validar artículo origen")
        End Try
    End Sub

    Private Sub SpinEditCantidadSeleccionada_Validating(sender As Object, e As CancelEventArgs) Handles SpinEditCantidadSeleccionada.Validating
        If SpinEditCantidadSeleccionada.Text = "0" Then
            e.Cancel = True
            SpinEditCantidadSeleccionada.Focus()
            SpinEditCantidadSeleccionada.SelectAll()
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
            Return
        End If
    End Sub


    ' Validación de entrada
    Private Sub ControlEntradaAlfanumerica(sender As Object, e As KeyPressEventArgs)
        ' Permitir caracteres alfanuméricos, guión bajo (_) y guión (-)
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso
       Not Char.IsControl(e.KeyChar) AndAlso
       e.KeyChar <> "_"c AndAlso
       e.KeyChar <> "-"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub teCodigoArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditItem.KeyPress
        ControlEntradaAlfanumerica(sender, e)
    End Sub

    Private Sub teCodigoUbicacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextEditLocation.KeyPress
        ControlEntradaAlfanumerica(sender, e)
    End Sub

    Private Sub TileViewArticulosParaTraslado_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles TileViewArticulosParaTraslado.ContextButtonClick
        Try
            ' Verificar que es el botón de eliminar
            If e.Item.Name = "ButtonItemElimination" Then
                ' Obtener el TileView
                Dim tileView As DevExpress.XtraGrid.Views.Tile.TileView = CType(sender, DevExpress.XtraGrid.Views.Tile.TileView)

                ' Verificar si hay una fila seleccionada
                If tileView.FocusedRowHandle >= 0 Then
                    ' Obtener el índice de la fila enfocada
                    Dim rowHandle As Integer = tileView.FocusedRowHandle

                    ' Obtener los valores necesarios para identificar el registro
                    Dim codigo As String = tileView.GetRowCellValue(rowHandle, "Codigo")?.ToString()
                    Dim ubicacionOrigen As String = tileView.GetRowCellValue(rowHandle, "CodigoUbicacionOrigen")?.ToString()
                    Dim cantidadAMover As Object = tileView.GetRowCellValue(rowHandle, "CantidadAMover")

                    ' Mostrar confirmación antes de eliminar
                    Dim mensaje As String = $"¿Está seguro que desea eliminar este artículo del traslado?{vbCrLf}{vbCrLf}" &
                                      $"Artículo: {codigo}{vbCrLf}" &
                                      $"Ubicación: {ubicacionOrigen}{vbCrLf}" &
                                      $"Cantidad: {cantidadAMover}"

                    Dim result As DialogResult = MessageBox.Show(mensaje,
                                                            "Confirmar eliminación",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        ' Eliminar de la base de datos (tabla MOVPDA)
                        If EliminarDeBaseDatos(codigo, ubicacionOrigen, cantidadAMover) Then
                            ' Eliminar la fila del TileView
                            tileView.DeleteRow(rowHandle)

                            ' Actualizar la vista
                            tileView.RefreshData()

                            ' Actualizar contadores si es necesario
                            LabelLoadedAmount.Text = CalcularTotalEnEspera(TextEditItem.Text)

                            MessageBox.Show("Artículo eliminado correctamente del traslado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Error al eliminar el artículo de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("No hay ningún artículo seleccionado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar el artículo: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class