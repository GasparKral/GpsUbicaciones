Imports System.ComponentModel
Imports DevExpress.XtraGrid.Views.Grid

''' <summary>
''' Formulario para la selección de artículos.
''' </summary>
Public Class frmSeleccionArticulos
    Sub New()

        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Colección de artículos seleccionados durante la sesión
    ''' </summary>
    Private ReadOnly ArticulosSeleccionados As New BindingList(Of ArticuloSeleccion)

    ''' <summary>
    ''' Valor mínimo aceptable para la cantidad seleccionada
    ''' </summary>
    Private Const CANTIDAD_MINIMA As Decimal = 0

#Region "Validación de Campos"

    ''' <summary>
    ''' Valida que la ubicación ingresada sea válida
    ''' </summary>
    ''' <returns>True si la ubicación es válida, False en caso contrario</returns>
    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrWhiteSpace(TextBoxCodigoUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesUbicaciones.CodigoFaltante)
            TextBoxCodigoUbicacion.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(LabelNombreUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La ubicación no existe o no es válida.")
            TextBoxCodigoUbicacion.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Valida que el artículo ingresado sea válido
    ''' </summary>
    ''' <returns>True si el artículo es válido, False en caso contrario</returns>
    Private Function ValidarArticulo() As Boolean
        If String.IsNullOrWhiteSpace(TextBoxCodigoArticulo.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar un código de artículo.")
            TextBoxCodigoArticulo.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(LabelNombreArticulo.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "El artículo no existe o no es válido.")
            TextBoxCodigoArticulo.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Valida que la cantidad seleccionada sea válida
    ''' </summary>
    ''' <returns>True si la cantidad es válida, False en caso contrario</returns>
    Private Function ValidarCantidad() As Boolean
        If SpinEditCantidadSeleccionada.Value <= CANTIDAD_MINIMA Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La cantidad debe ser mayor que cero.")
            SpinEditCantidadSeleccionada.Focus()
            Return False
        End If

        Dim stockDisponible As Decimal
        If Not Decimal.TryParse(LabelStockArticulo.Text, stockDisponible) Then
            Return False
        End If

        If SpinEditCantidadSeleccionada.Value > stockDisponible Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La cantidad seleccionada excede el stock disponible.")
            SpinEditCantidadSeleccionada.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Control UI"

    ''' <summary>
    ''' Maneja el evento KeyPress del formulario para navegar con Enter
    ''' </summary>
    Private Sub frmSeleccionArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    ''' <summary>
    ''' Inicializa el formulario y sus controles
    ''' </summary>
    Private Sub frmSeleccionArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            LimpiarUbicacion(False)
            LimpiarArticulo(False)

            DatePicker.DateTime = Now
            DatePicker.Focus()
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al inicializar el formulario: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Limpia los campos relacionados con el artículo
    ''' </summary>
    ''' <param name="ActivarFoco">Indica si debe activarse el foco en el campo de artículo</param>
    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        LabelStockArticulo.Text = String.Empty
        TextBoxCodigoArticulo.Text = String.Empty
        SpinEditCantidadSeleccionada.Value = CANTIDAD_MINIMA
        If ActivarFoco Then
            TextBoxCodigoArticulo.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Limpia los campos relacionados con la ubicación
    ''' </summary>
    ''' <param name="ActivarFoco">Indica si debe activarse el foco en el campo de ubicación</param>
    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreAlmacen.Text = String.Empty
        TextBoxCodigoUbicacion.Text = String.Empty
        If ActivarFoco Then
            TextBoxCodigoUbicacion.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Crea una columna para un GridView
    ''' </summary>
    ''' <param name="GridView">GridView al que se añadirá la columna</param>
    ''' <param name="NombreColumna">Nombre de la columna</param>
    ''' <param name="AnchoColumna">Ancho de la columna</param>
    ''' <param name="Visible">Indica si la columna es visible</param>
    Private Sub CrearColumna(ByRef GridView As GridView, NombreColumna As String, AnchoColumna As Integer, Visible As Boolean)
        Dim Columna As New DevExpress.XtraGrid.Columns.GridColumn() With {
            .FieldName = NombreColumna,
            .Visible = Visible,
            .VisibleIndex = GridView.Columns.Count,
            .Width = AnchoColumna
        }
        Columna.AppearanceCell.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridView.Columns.Add(Columna)
    End Sub

#End Region

#Region "Eventos de Validación"

    ''' <summary>
    ''' Valida el código de ubicación cuando pierde el foco
    ''' </summary>
    Private Sub TextBoxCodigoUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoUbicacion.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreUbicacion.Text = String.Empty
            LabelNombreAlmacen.Text = String.Empty

            ' Si el campo está vacío, no validar pero limpiar campos dependientes
            If String.IsNullOrWhiteSpace(TextBoxCodigoUbicacion.Text) Then
                LimpiarArticulo(False)
                PermitirEdicion(TextBoxCodigoArticulo, False)
                Return
            End If

            ' Buscar la ubicación en la base de datos
            Using Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextBoxCodigoUbicacion.Text)
                If Ubicacion Is Nothing Then
                    ' Ubicación no encontrada
                    LimpiarArticulo(False)
                    PermitirEdicion(TextBoxCodigoArticulo, False)
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    Return
                End If

                ' Ubicación válida - actualizar campos
                LabelNombreUbicacion.Text = Ubicacion.Nombre
                LabelNombreAlmacen.Text = Ubicacion.NombreAlmacen
                PermitirEdicion(TextBoxCodigoArticulo, True)

                ' Limpiar artículo anterior si existe
                LimpiarArticulo(False)
            End Using

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al validar la ubicación: {ex.Message}")
            e.Cancel = True
        End Try
    End Sub

    ''' <summary>
    ''' Valida el código de artículo cuando pierde el foco
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoArticulo.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreArticulo.Text = String.Empty
            LabelStockArticulo.Text = String.Empty
            SpinEditCantidadSeleccionada.Value = CANTIDAD_MINIMA
            PermitirEdicion(SpinEditCantidadSeleccionada, False)

            ' Si el campo está vacío, no validar
            If String.IsNullOrWhiteSpace(TextBoxCodigoArticulo.Text) Then
                Return
            End If

            ' Verificar que haya una ubicación válida primero
            If String.IsNullOrWhiteSpace(TextBoxCodigoUbicacion.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreUbicacion.Text) Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar una ubicación válida antes de seleccionar un artículo.")
                e.Cancel = True
                Return
            End If

            ' Buscar el artículo en el lote especificado
            Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
                If StockLote Is Nothing Then
                    ' Artículo no encontrado en la ubicación
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    Return
                End If

                ' Artículo válido - actualizar campos
                LabelStockArticulo.Text = StockLote.Cantidad.ToString()
                LabelNombreArticulo.Text = StockLote.Articulo.NombreComercial
                AceptarDecimales(SpinEditCantidadSeleccionada, StockLote.Articulo.PorPeso, LabelIndicadorPorPeso)
                SpinEditCantidadSeleccionada.Properties.MaxValue = StockLote.Cantidad
                PermitirEdicion(SpinEditCantidadSeleccionada, True)

                ' Establecer el foco en la cantidad si todo es válido
                SpinEditCantidadSeleccionada.Focus()
            End Using

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al validar el artículo: {ex.Message}")
            e.Cancel = True
        End Try
    End Sub

    ''' <summary>
    ''' Valida la cantidad seleccionada cuando pierde el foco
    ''' </summary>
    Private Sub SpinEditCantidadSeleccionada_Validating(sender As Object, e As CancelEventArgs) Handles SpinEditCantidadSeleccionada.Validating
        Try
            ' Si no hay artículo seleccionado, no validar
            If String.IsNullOrWhiteSpace(TextBoxCodigoArticulo.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreArticulo.Text) Then
                Return
            End If

            ' Validar que la cantidad sea mayor que cero
            If SpinEditCantidadSeleccionada.Value <= CANTIDAD_MINIMA Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La cantidad debe ser mayor que cero.")
                e.Cancel = True
                Return
            End If

            ' Validar que no exceda el stock disponible
            Dim stockDisponible As Decimal
            If Decimal.TryParse(LabelStockArticulo.Text, stockDisponible) Then
                If SpinEditCantidadSeleccionada.Value > stockDisponible Then
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La cantidad seleccionada excede el stock disponible.")
                    e.Cancel = True
                    Return
                End If
            End If

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al validar la cantidad: {ex.Message}")
            e.Cancel = True
        End Try
    End Sub

#End Region

#Region "Eventos de Formulario"

    ''' <summary>
    ''' Maneja el evento Click del botón Salir
    ''' </summary>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón de confirmación de lectura
    ''' </summary>
    Private Sub ButtonConfirmacionLectura_Click(sender As Object, e As EventArgs) Handles ButtonConfirmacionLectura.Click
        Try
            If Not ValidarUbicacion() OrElse Not ValidarArticulo() OrElse Not ValidarCantidad() Then
                Exit Sub
            End If

            Dim nuevoArticulo As New ArticuloSeleccion With {
                .Articulo = TextBoxCodigoArticulo.Text,
                .Ubicacion = TextBoxCodigoUbicacion.Text,
                .Descripcion = LabelNombreArticulo.Text,
                .Unidades = SpinEditCantidadSeleccionada.Value
            }

            ArticulosSeleccionados.Add(nuevoArticulo)
            LimpiarUbicacion()
            LimpiarArticulo(False)
            PermitirEdicion(TextBoxCodigoArticulo, False)
            PermitirEdicion(SpinEditCantidadSeleccionada, False)
            GridControlArticulosSeleccionados.Visible = True
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al confirmar la lectura: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Maneja el evento de cambio de valor en el DatePicker
    ''' </summary>
    Private Sub datePicker_EditValueChanged(sender As Object, e As EventArgs) Handles DatePicker.EditValueChanged
        Try
            If DatePicker.DateTime = Nothing OrElse DatePicker.DateTime = DateTime.MinValue Then
                Exit Sub
            End If

            Dim fecha As DateTime = DatePicker.DateTime.Date
            GridPedidos.DataSource = Operacion.ExecuteQuery(Querys.Select.ConsultarPedidosPorFecha, fecha).Tables(0)

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al cargar los pedidos: {ex.Message}")
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles ButtonConfirmacionAccion.Click

        If RadioButtonOpcionAlbaran.Checked Then
            For Each item As ArticuloSeleccion In ArticulosSeleccionados
                Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, item.Articulo, item.Ubicacion, item.Unidades)
            Next
        End If

        If RadioButtonOpcionTraspasoAlamacen.Checked Then

        End If

    End Sub

    ' This event is generated by Data Source Configuration Wizard
    Sub UnboundSource1_ValueNeeded(sender As Object, e As DevExpress.Data.UnboundSourceValueNeededEventArgs)
        ' Handle this event to obtain data from your data source
        ' e.Value = something /* TODO: Assign the real data here.*/
    End Sub

    ' This event is generated by Data Source Configuration Wizard
    Sub UnboundSource1_ValuePushed(sender As Object, e As DevExpress.Data.UnboundSourceValuePushedEventArgs)
        ' Handle this event to save modified data back to your data source
        ' something = e.Value; /* TODO: Propagate the value into the storage.*/
    End Sub

#End Region

End Class