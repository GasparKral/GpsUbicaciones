Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Tile

Public Class frmTrasladoProductos

#Region "Enumeraciones y Constantes"

    ''' <summary>
    ''' Estados posibles del formulario de traslado
    ''' </summary>
    Public Enum EstadoTraslado
        CargarEnCarrito
        DescargarDelCarrito
    End Enum

#End Region

#Region "Propiedades y Variables"

    Private ReadOnly ArticulosEnEspera As New BindingList(Of ProductoTraslado)
    Private _estadoActual As EstadoTraslado = EstadoTraslado.CargarEnCarrito
    Private ReadOnly _gestorUI As GestorUITraslado
    Private ReadOnly _validador As ValidadorTraslado
    Private ReadOnly _servicioTransferencia As ServicioTransferencia

    ''' <summary>
    ''' Estado actual del formulario
    ''' </summary>
    Public Property EstadoActual As EstadoTraslado
        Get
            Return _estadoActual
        End Get
        Private Set(value As EstadoTraslado)
            If _estadoActual <> value Then
                _estadoActual = value
                _gestorUI.ActualizarEstadoVisual(value)
            End If
        End Set
    End Property

#End Region

#Region "Constructor e Inicialización"

    Public Sub New()
        InitializeComponent()
        _gestorUI = New GestorUITraslado(Me)
        _validador = New ValidadorTraslado()
        _servicioTransferencia = New ServicioTransferencia(ArticulosEnEspera)
    End Sub

    Private Sub frmTransladoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            InicializarFormulario()
            CargarArticulosTemporales()
            ConfigurarControlesIniciales()
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al cargar el formulario: " & ex.Message)
        End Try
    End Sub

    Private Sub InicializarFormulario()
        ProductoTrasladoBindingSource.DataSource = ArticulosEnEspera
        EstadoActual = EstadoTraslado.CargarEnCarrito
        _gestorUI.ConfigurarAparienciaInicial()
    End Sub

    Private Sub CargarArticulosTemporales()
        For Each transaction As DataRow In RepositorioMovPDA.ObtenerTraspasosPDA.Rows
            ArticulosEnEspera.Add(New ProductoTraslado With {
                .Articulo = RepositorioArticulo.ObtenerInformacion(transaction("Articulo")),
                .CantidadAMover = Single.Parse(transaction("Cantidad")),
                .CodigoUbicacionOrigen = transaction("Lote")
            })
        Next

        If ArticulosEnEspera.Count > 0 Then
            GridControlArticulosParaTraslado.Visible = True
        End If
    End Sub

    Private Sub ConfigurarControlesIniciales()
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(SpinEditCantidadSeleccionada, False)
        PermitirEdicion(TextEditLocation, True)
    End Sub

#End Region

#Region "Eventos de Formulario"

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click
        Try
            If Not _validador.ValidarTodosLosCampos(TextEditLocation.Text, TextEditItem.Text, SpinEditCantidadSeleccionada.Value) Then
                Return
            End If

            Cursor.Current = Cursors.WaitCursor

            Select Case EstadoActual
                Case EstadoTraslado.CargarEnCarrito
                    ProcesarCargarEnCarrito()
                Case EstadoTraslado.DescargarDelCarrito
                    ProcesarDescargarDelCarrito()
            End Select

        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al procesar la operación: " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonClearForm_Click(sender As Object, e As EventArgs) Handles ButtonClearForm.Click
        ' Desactivar validaciones temporalmente
        RemoveHandler SpinEditCantidadSeleccionada.Validating, AddressOf SpinEditCantidadSeleccionada_Validating
        _gestorUI.LimpiarFormulario()
        ' Reactivar validaciones
        AddHandler SpinEditCantidadSeleccionada.Validating, AddressOf SpinEditCantidadSeleccionada_Validating
    End Sub

    Private Sub GroupControl_CustomButtonClick(sender As Object, e As DevExpress.XtraBars.Docking2010.BaseButtonEventArgs) Handles GroupControl.CustomButtonClick
        CambiarEstado()
    End Sub

    Private Sub LabelLoadedAmount_Click(sender As Object, e As EventArgs) Handles LabelLoadedAmount.Click
        If Not String.IsNullOrEmpty(LabelLoadedAmount.Text) Then
            SpinEditCantidadSeleccionada.Value = LabelLoadedAmount.Text
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub TileViewArticulosParaTraslado_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles TileViewArticulosParaTraslado.ContextButtonClick
        If e.Item.Name = "ButtonItemElimination" Then
            _servicioTransferencia.EliminarArticuloDelCarrito(TileViewArticulosParaTraslado, Me)
        End If
        BuscarUltimoFoco(ButtonConfirm, TextEditLocation, TextEditItem, SpinEditCantidadSeleccionada)
    End Sub

#End Region

#Region "Procesamiento de Operaciones"

    Private Sub ProcesarCargarEnCarrito()
        ' Loop cargar: grabar + agregar info al tile + limpiar campos
        _servicioTransferencia.AgregarAlCarrito(
            TextEditItem.Text,
            SpinEditCantidadSeleccionada.Value,
            TextEditLocation.Text)

        ' Mostrar el grid con el nuevo artículo agregado
        GridControlArticulosParaTraslado.Visible = True

        ' Limpiar campos para agregar más artículos (mantener estado cargar)
        _gestorUI.LimpiarCamposParaSiguienteOperacion()
    End Sub

    Private Sub ProcesarDescargarDelCarrito()
        ' Loop descargar: transferir DB + actualizar grid + limpiar campos
        Dim articulosDisponibles = _servicioTransferencia.BuscarArticulosParaDescuento(TextEditItem.Text, TextEditLocation.Text)

        If articulosDisponibles.Count = 0 Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia,
                "No se tiene cargado el artículo, o está usando la misma ubicación de la cual lo quiere transferir")
            Return
        End If

        Dim exitosa = _servicioTransferencia.EjecutarTransferencia(
            SpinEditCantidadSeleccionada.Value,
            articulosDisponibles,
            TextEditLocation.Text,
            TextEditItem.Text,
            Terminal)

        If exitosa Then
            ' Actualizar vista después de la transferencia
            GridControlArticulosParaTraslado.RefreshDataSource()

            ' Ocultar grid si no quedan artículos
            If ArticulosEnEspera.Count = 0 Then
                GridControlArticulosParaTraslado.Visible = False
            End If

            ' Limpiar campos para continuar descargando en otras ubicaciones
            _gestorUI.LimpiarCamposParaSiguienteOperacion()
        End If
    End Sub

    Private Sub CambiarEstado()
        EstadoActual = If(EstadoActual = EstadoTraslado.CargarEnCarrito,
                         EstadoTraslado.DescargarDelCarrito,
                         EstadoTraslado.CargarEnCarrito)
    End Sub

#End Region

#Region "Validación de Campos"

    Private Sub ValidarUbicacion(sender As Object, e As CancelEventArgs) Handles TextEditLocation.Validating
        Try
            _gestorUI.LimpiarCamposUbicacion()

            If String.IsNullOrWhiteSpace(TextEditLocation.Text) Then
                PermitirEdicion(TextEditItem, False)
                Return
            End If

            Dim ubicacion = _validador.ValidarUbicacion(TextEditLocation.Text)
            If ubicacion Is Nothing Then
                e.Cancel = True
                TextEditLocation.Focus()
                TextEditLocation.SelectAll()
                Return
            End If

            _gestorUI.MostrarInformacionUbicacion(ubicacion)
            PermitirEdicion(TextEditItem, True)

        Catch ex As Exception
            e.Cancel = True
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al validar la ubicación: " & ex.Message)
        End Try
    End Sub

    Private Sub ValidarArticulo(sender As Object, e As CancelEventArgs) Handles TextEditItem.Validating
        Try
            _gestorUI.LimpiarCamposArticulo()

            If String.IsNullOrWhiteSpace(TextEditItem.Text) OrElse String.IsNullOrWhiteSpace(TextEditLocation.Text) Then
                Return
            End If

            Dim resultadoValidacion = _validador.ValidarArticulo(TextEditItem.Text, TextEditLocation.Text, EstadoActual)

            If Not resultadoValidacion.EsValido Then
                e.Cancel = True
                GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, resultadoValidacion.MensajeError)
                TextEditItem.Focus()
                TextEditItem.SelectAll()
                Return
            End If

            _gestorUI.MostrarInformacionArticulo(resultadoValidacion.StockLote, EstadoActual)
            PermitirEdicion(SpinEditCantidadSeleccionada, True)

            ' Mostrar cantidad cargada si estamos en modo descarga
            If EstadoActual = EstadoTraslado.DescargarDelCarrito Then
                Dim cantidadCargada = _servicioTransferencia.CalcularTotalEnEspera(TextEditItem.Text)
                _gestorUI.MostrarCantidadCargada(cantidadCargada)
            End If

        Catch ex As Exception
            Logger.Instance.Error(ex:=ex, message:=ex.Message)
            e.Cancel = True
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al validar el artículo: " & ex.Message)
        End Try
    End Sub

    Public Sub SpinEditCantidadSeleccionada_Validating(sender As Object, e As CancelEventArgs) Handles SpinEditCantidadSeleccionada.Validating
        If SpinEditCantidadSeleccionada.Value <= 0 Then
            e.Cancel = True
            SpinEditCantidadSeleccionada.Focus()
            SpinEditCantidadSeleccionada.SelectAll()
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
        End If
    End Sub

#End Region

#Region "Validación de Entrada"

    Private Sub ControlEntradaAlfanumerica(sender As Object, e As KeyPressEventArgs)
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

#End Region

End Class

#Region "Clases de Soporte"

''' <summary>
''' Gestiona el estado visual del formulario de traslado
''' </summary>
Public Class GestorUITraslado
    Private ReadOnly _formulario As frmTrasladoProductos

    Public Sub New(formulario As frmTrasladoProductos)
        _formulario = formulario
    End Sub

    Public Sub ActualizarEstadoVisual(estado As frmTrasladoProductos.EstadoTraslado)
        Select Case estado
            Case frmTrasladoProductos.EstadoTraslado.CargarEnCarrito
                ConfigurarModoCargar()
            Case frmTrasladoProductos.EstadoTraslado.DescargarDelCarrito
                ConfigurarModoDescargar()
        End Select
    End Sub

    Public Sub ConfigurarAparienciaInicial()
        _formulario.GroupControl.CustomHeaderButtons("Cargar/Descargar").Properties.Appearance.ForeColor = Color.White
        _formulario.GroupControl.CustomHeaderButtons("Cargar/Descargar").Properties.Appearance.Font = New Font("Roboto", 12, FontStyle.Regular)
    End Sub

    Private Sub ConfigurarModoCargar()
        With _formulario
            .GroupControl.Text = "Cargar En Carrito"
            .GroupControl.AppearanceCaption.BorderColor = Color.SaddleBrown
            .LabelLocation.BackColor = Color.Peru
            .LabelItemName.BackColor = Color.Peru
            .LabelStockArticulo.BackColor = Color.Peru
            .LabelLoadedAmount.BackColor = Color.Peru
            .PanelTitulo.BackColor = Color.Peru
            .ButtonConfirm.ImageOptions.SvgImage = My.Resources.save
            .LabelLoaded.Visible = False
            .LabelLoadedAmount.Visible = False
        End With
    End Sub

    Private Sub ConfigurarModoDescargar()
        With _formulario
            .GroupControl.Text = "Realizar Transferencia"
            .GroupControl.AppearanceCaption.BorderColor = Color.Indigo
            .LabelLocation.BackColor = Color.BlueViolet
            .LabelItemName.BackColor = Color.BlueViolet
            .LabelStockArticulo.BackColor = Color.BlueViolet
            .LabelLoadedAmount.BackColor = Color.BlueViolet
            .PanelTitulo.BackColor = Color.BlueViolet
            .ButtonConfirm.ImageOptions.SvgImage = My.Resources.actions_check
            .LabelLoaded.Visible = True
            .LabelLoadedAmount.Visible = True
        End With
    End Sub

    Public Sub LimpiarFormulario()
        ' Desactivar validaciones temporalmente para evitar errores durante la limpieza
        RemoveHandler _formulario.SpinEditCantidadSeleccionada.Validating, AddressOf _formulario.SpinEditCantidadSeleccionada_Validating

        LimpiarCamposCompleto()
        PermitirEdicion(_formulario.SpinEditCantidadSeleccionada, False)
        PermitirEdicion(_formulario.TextEditItem, False)
        PermitirEdicion(_formulario.TextEditLocation, True)
        _formulario.LabelLoadedAmount.Text = String.Empty

        ' Reactivar validaciones
        AddHandler _formulario.SpinEditCantidadSeleccionada.Validating, AddressOf _formulario.SpinEditCantidadSeleccionada_Validating
    End Sub

    Public Sub LimpiarCamposParaSiguienteOperacion()
        ' Limpiar campos pero mantener el estado/modo actual
        ' Desactivar validaciones temporalmente
        RemoveHandler _formulario.SpinEditCantidadSeleccionada.Validating, AddressOf _formulario.SpinEditCantidadSeleccionada_Validating

        ' Limpiar solo los campos de entrada, no cambiar habilitación de controles
        _formulario.TextEditLocation.Clear()
        _formulario.TextEditItem.Clear()
        _formulario.SpinEditCantidadSeleccionada.Value = 0

        ' Limpiar labels informativos
        _formulario.LabelLocation.Text = String.Empty
        _formulario.LabelItemName.Text = String.Empty
        _formulario.LabelStockArticulo.Text = String.Empty
        _formulario.IconWeight.Visible = False
        _formulario.LabelLoadedAmount.Text = String.Empty

        ' Configurar controles para siguiente operación
        PermitirEdicion(_formulario.TextEditLocation, True)
        PermitirEdicion(_formulario.TextEditItem, False)
        PermitirEdicion(_formulario.SpinEditCantidadSeleccionada, False)

        ' Enfocar ubicación para siguiente entrada
        _formulario.TextEditLocation.Focus()

        ' Reactivar validaciones
        AddHandler _formulario.SpinEditCantidadSeleccionada.Validating, AddressOf _formulario.SpinEditCantidadSeleccionada_Validating
    End Sub

    Public Sub LimpiarCamposUbicacion()
        _formulario.LabelLocation.Text = String.Empty
    End Sub

    Public Sub LimpiarCamposArticulo()
        _formulario.LabelItemName.Text = String.Empty
        _formulario.LabelStockArticulo.Text = String.Empty
        _formulario.SpinEditCantidadSeleccionada.Value = 0
        _formulario.IconWeight.Visible = False
        PermitirEdicion(_formulario.SpinEditCantidadSeleccionada, False)
    End Sub

    Private Sub LimpiarCamposCompleto()
        With _formulario
            .TextEditLocation.Clear()
            .TextEditItem.Clear()
            .LabelLocation.Text = String.Empty
            .LabelStockArticulo.Text = String.Empty
            .LabelItemName.Text = String.Empty
            .SpinEditCantidadSeleccionada.Value = 0
            .IconWeight.Visible = False
        End With
    End Sub

    Public Sub MostrarInformacionUbicacion(ubicacion As Ubicacion)
        _formulario.LabelLocation.Text = ubicacion.Nombre
    End Sub

    Public Sub MostrarInformacionArticulo(stockLote As StockLote, estado As frmTrasladoProductos.EstadoTraslado)
        With _formulario
            .LabelItemName.Text = stockLote.Articulo.NombreComercial
            .LabelStockArticulo.Text = stockLote.Cantidad.ToString()
            .SpinEditCantidadSeleccionada.Properties.MaxValue = stockLote.Cantidad
            AceptarDecimales(.SpinEditCantidadSeleccionada, stockLote.Articulo.PorPeso, .IconWeight)
        End With
    End Sub

    Public Sub MostrarCantidadCargada(cantidad As String)
        _formulario.LabelLoadedAmount.Text = cantidad
    End Sub
End Class

''' <summary>
''' Validador especializado para operaciones de traslado
''' </summary>
Public Class ValidadorTraslado
    ''' <summary>
    ''' Resultado de validación de artículo
    ''' </summary>
    Public Class ResultadoValidacionArticulo
        Public Property EsValido As Boolean
        Public Property MensajeError As String
        Public Property StockLote As StockLote
    End Class

    Public Function ValidarTodosLosCampos(ubicacion As String, articulo As String, cantidad As Decimal) As Boolean
        If String.IsNullOrEmpty(ubicacion) Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Todos los campos son obligatorios y la cantidad de artículo seleccionado debe ser mayor a 0")
            Return False
        End If

        If String.IsNullOrEmpty(articulo) Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Todos los campos son obligatorios y la cantidad de artículo seleccionado debe ser mayor a 0")
            Return False
        End If

        If cantidad <= 0 Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Todos los campos son obligatorios y la cantidad de artículo seleccionado debe ser mayor a 0")
            Return False
        End If

        Return True
    End Function

    Public Function ValidarUbicacion(codigoUbicacion As String) As Ubicacion
        Try
            Return RepositorioUbicacion.ObtenerInformacion(codigoUbicacion)
        Catch ex As InvalidOperationException
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Código de ubicación invalido")
            Return Nothing
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al validar la ubicación: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function ValidarArticulo(codigoArticulo As String, codigoUbicacion As String, estado As frmTrasladoProductos.EstadoTraslado) As ResultadoValidacionArticulo
        Dim resultado As New ResultadoValidacionArticulo()

        Try
            Select Case estado
                Case frmTrasladoProductos.EstadoTraslado.CargarEnCarrito
                    resultado = ValidarArticuloParaCargar(codigoArticulo, codigoUbicacion)
                Case frmTrasladoProductos.EstadoTraslado.DescargarDelCarrito
                    resultado = ValidarArticuloParaDescargar(codigoArticulo, codigoUbicacion)
            End Select

        Catch ex As Exception
            resultado.EsValido = False
            resultado.MensajeError = "Error al validar el artículo: " & ex.Message
        End Try

        Return resultado
    End Function

    Private Function ValidarArticuloParaCargar(codigoArticulo As String, codigoUbicacion As String) As ResultadoValidacionArticulo
        Dim resultado As New ResultadoValidacionArticulo()

        Try
            ' Verificar que no se use la misma ubicación dos veces
            If ExisteArticuloEnEspera(codigoArticulo, codigoUbicacion) Then
                resultado.EsValido = False
                resultado.MensajeError = "No se puede usar dos veces la misma ubicación"
                Return resultado
            End If

            Dim stockLote = RepositorioStockLote.ObtenerArticuloEnLote(codigoArticulo, codigoUbicacion)
            If stockLote Is Nothing Then
                resultado.EsValido = False
                resultado.MensajeError = "Artículo no encontrado en la ubicación especificada"
                Return resultado
            End If

            resultado.EsValido = True
            resultado.StockLote = stockLote

        Catch ex As InvalidOperationException
            resultado.EsValido = False
            Try
                Using articuloInfo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)
                    If articuloInfo IsNot Nothing Then
                        resultado.MensajeError = "Código de ubicación inválido"
                    End If
                End Using
            Catch
                resultado.MensajeError = "Código de artículo inválido"
            End Try
        End Try

        Return resultado
    End Function

    Private Function ValidarArticuloParaDescargar(codigoArticulo As String, codigoUbicacion As String) As ResultadoValidacionArticulo
        Dim resultado As New ResultadoValidacionArticulo()

        ' Para el modo descarga, crear un StockLote ficticio con la información necesaria
        Try
            Dim articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)
            Dim ubicacion = RepositorioUbicacion.ObtenerInformacion(codigoUbicacion)

            resultado.StockLote = New StockLote With {
                .Articulo = articulo,
                .Lote = ubicacion,
                .UnidadesTransferidas = 0 ' Se calculará dinámicamente
            }
            resultado.EsValido = True

        Catch ex As Exception
            resultado.EsValido = False
            resultado.MensajeError = "Error al validar artículo para descarga: " & ex.Message
        End Try

        Return resultado
    End Function

    Private Function ExisteArticuloEnEspera(codigoArticulo As String, codigoUbicacion As String) As Boolean
        ' Esta función necesitaría acceso a ArticulosEnEspera, se podría inyectar como dependencia
        ' Por ahora, retornamos False como implementación temporal
        Return False
    End Function
End Class

''' <summary>
''' Servicio para manejar las operaciones de transferencia
''' </summary>
Public Class ServicioTransferencia
    Private ReadOnly _articulosEnEspera As BindingList(Of ProductoTraslado)

    Public Sub New(articulosEnEspera As BindingList(Of ProductoTraslado))
        _articulosEnEspera = articulosEnEspera
    End Sub

    Public Sub AgregarAlCarrito(codigoArticulo As String, cantidad As Single, codigoUbicacion As String)
        ' Agregar a MOVPDA OPERACION:TR[Transferencia]
        RepositorioMovPDA.InsertarOperacionPDA(RepositorioMovPDA.TypeOperacion.TRASPASO, codigoArticulo, cantidad, codigoUbicacion)

        ' Agregar a la lista de espera
        Dim articuloParaTraslado As New ProductoTraslado With {
            .Articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo),
            .CantidadAMover = cantidad,
            .CodigoUbicacionOrigen = codigoUbicacion
        }

        _articulosEnEspera.Add(articuloParaTraslado)
    End Sub

    Public Function BuscarArticulosParaDescuento(codigoArticulo As String, codigoUbicacion As String) As List(Of Integer)
        Dim articulos = _articulosEnEspera.Where(Function(A) _
            (A.Articulo.Codigo.Equals(codigoArticulo) OrElse
             A.Articulo.CodigoBarras.Equals(codigoArticulo) OrElse
             A.Articulo.ReferenciaProvedor.Equals(codigoArticulo)) _
            And Not A.CodigoUbicacionOrigen.Equals(codigoUbicacion))

        Return articulos.Select(Function(A) _articulosEnEspera.IndexOf(A)).ToList()
    End Function

    Public Function CalcularTotalEnEspera(codigoArticulo As String) As String
        Return _articulosEnEspera.Where(Function(item) _
                                       item.Articulo.Codigo.Equals(codigoArticulo) OrElse
                                       item.Articulo.CodigoBarras.Equals(codigoArticulo) OrElse
                                       item.Articulo.ReferenciaProvedor.Equals(codigoArticulo)
        ).Sum(Function(item) item.CantidadAMover).ToString()
    End Function

    Public Function EjecutarTransferencia(cantidadAsignar As Single, articulos As List(Of Integer), codigoUbicacionDestino As String, terminal As String, codigoArticulo As String) As Boolean
        If articulos Is Nothing OrElse articulos.Count = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "No hay artículos para procesar")
            Return False
        End If

        Try
            ' Usar la operación extendida que soporta transacciones
            Dim operacionExtendida As New AccessDatabaseOperationExtended(Configuracion.settings)

            Using transactionBlock As New TransactionBlockExecutor(operacionExtendida)
                Dim cantidadRestante As Single = cantidadAsignar
                Dim transferenciasRealizadas As New List(Of TransferenciaInfo)()
                Dim articulosParaActualizar As New List(Of (Articulo As ProductoTraslado, CantidadTransferida As Single))()

                ' Bloque de transacción que procesa todas las transferencias
                Dim procesoTransferencias As Action(Of IDbConnection, IDbTransaction) =
                Sub(conn, trans)
                    For i As Integer = 0 To articulos.Count - 1
                        If cantidadRestante <= 0 Then Exit For

                        Dim articulo As ProductoTraslado = _articulosEnEspera(articulos(i))
                        Dim cantidadATransferir As Single = Math.Min(cantidadRestante, articulo.CantidadAMover)

                        ' Realizar la transferencia usando el repositorio extendido
                        Dim operacionesRealizadas = RepositorioStockLote.RealizarTransferenciaCompleta(
                            conn, trans,
                            cantidadATransferir,
                            articulo.Articulo.Codigo,
                            articulo.CodigoUbicacionOrigen,
                            codigoUbicacionDestino)

                        If operacionesRealizadas > 0 Then
                            ' Registrar la transferencia exitosa
                            transferenciasRealizadas.Add(New TransferenciaInfo With {
                                .Cantidad = cantidadATransferir,
                                .CodigoArticulo = articulo.Articulo.Codigo,
                                .CodigoUbicacionOrigen = articulo.CodigoUbicacionOrigen,
                                .CodigoUbicacionDestino = codigoUbicacionDestino,
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
                                    codigoUbicacionDestino)           ' Ubicación destino

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
                    ActualizarArticulosEnEspera(articulosParaActualizar, terminal)

                    ' Mostrar mensaje de éxito
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion,
                    $"Se realizaron {transferenciasRealizadas.Count} transferencias correctamente. " &
                    $"Cantidad total procesada: {cantidadAsignar - cantidadRestante}")

                    Return True
                Else
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al realizar las transferencias")
                    Return False
                End If
            End Using

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en el proceso: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Actualiza los artículos en espera después de las transferencias exitosas
    ''' </summary>
    Private Sub ActualizarArticulosEnEspera(articulosParaActualizar As List(Of (Articulo As ProductoTraslado, CantidadTransferida As Single)), terminal As String)
        Dim articulosParaRemover As New List(Of ProductoTraslado)()

        For Each item In articulosParaActualizar
            If item.CantidadTransferida >= item.Articulo.CantidadAMover Then
                ' El artículo se agotó completamente
                articulosParaRemover.Add(item.Articulo)
            Else
                ' Reducir la cantidad restante
                item.Articulo.CantidadAMover -= item.CantidadTransferida
                Operacion.ExecuteNonQuery("UPDATE MOVPDA SET CANTIDAD = ? WHERE TERMINAL = ? AND OPERACION = 'TR' AND ARTICULO = ? AND LOTE = ?",
                    item.Articulo.CantidadAMover, terminal, item.Articulo.Articulo.Codigo, item.Articulo.CodigoUbicacionOrigen)
            End If
        Next

        ' Remover los artículos que se agotaron
        For Each articuloParaRemover In articulosParaRemover
            _articulosEnEspera.Remove(articuloParaRemover)
            RepositorioMovPDA.EliminarOperacionPDA(RepositorioMovPDA.TypeOperacion.TRASPASO,
                articuloParaRemover.Articulo.Codigo, articuloParaRemover.CantidadAMover, articuloParaRemover.CodigoUbicacionOrigen)
        Next
    End Sub

    Public Sub EliminarArticuloDelCarrito(tileView As DevExpress.XtraGrid.Views.Tile.TileView, formulario As frmTrasladoProductos)
        Try
            If tileView.FocusedRowHandle >= 0 Then
                Dim rowHandle As Integer = tileView.FocusedRowHandle
                Dim nombreComercial As String = tileView.GetRowCellValue(rowHandle, "NombreComercial")?.ToString()
                Dim codigoArticulo As String = tileView.GetRowCellValue(rowHandle, "Codigo")?.ToString()
                Dim ubicacionOrigen As String = tileView.GetRowCellValue(rowHandle, "CodigoUbicacionOrigen")?.ToString()
                Dim cantidadAMover As Single = tileView.GetRowCellValue(rowHandle, "CantidadAMover")

                Dim mensaje As String = $"¿Está seguro que desea eliminar este artículo del traslado?{vbCrLf}{vbCrLf}" &
                                      $"Artículo: {nombreComercial}{vbCrLf}" &
                                      $"Ubicación: {ubicacionOrigen}{vbCrLf}" &
                                      $"Cantidad: {cantidadAMover}"
                Dim result = GestorMensajes.FabricaMensajes.MostrarConfirmacion(mensaje, "Confirmar eliminación")

                If result = True Then
                    If EliminarDeBaseDatos(codigoArticulo, ubicacionOrigen, cantidadAMover) Then
                        tileView.DeleteRow(rowHandle)
                        tileView.RefreshData()
                        formulario.LabelLoadedAmount.Text = CalcularTotalEnEspera(formulario.TextEditItem.Text)
                        GestorMensajes.FabricaMensajes.MostrarConfirmacion("Artículo eliminado correctamente del traslado.")
                    Else
                        GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al eliminar el artículo de la base de datos.")
                    End If
                End If
            Else
                GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, "No hay ninguna fila seleccionada.")
            End If

        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "Error al eliminar el artículo: " & ex.Message)
        End Try
    End Sub

    Private Function EliminarDeBaseDatos(codigoArticulo As String, ubicacionOrigen As String, cantidadAMover As Single) As Boolean
        Try
            RepositorioMovPDA.EliminarOperacionPDA(RepositorioMovPDA.TypeOperacion.TRASPASO, codigoArticulo, cantidadAMover, ubicacionOrigen)
            Return True
        Catch ex As Exception
            Console.WriteLine("Error al eliminar de la base de datos MOVPDA: " & ex.Message)
            Return False
        End Try
    End Function

End Class

#End Region