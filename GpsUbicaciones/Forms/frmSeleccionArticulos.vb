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


#Region "Control UI"

    ''' <summary>
    ''' Inicializa el formulario y sus controles
    ''' </summary>
    Private Sub frmSeleccionArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DatePicker.DateTime = Now
            DatePicker.Focus()

            ' Leer estado temporal
            Using Info As DataTable = Operacion.ExecuteTable("SELECT * FROM MOVPDA WHERE Terminal = ? AND Operacion ='SE'", Terminal)
                If Info.Rows.Count > 0 Then
                    For Each row As DataRow In Info.Rows
                        Dim temp As New ArticuloSeleccion With {
                            .Articulo = row("Articulo"),
                            .Ubicacion = row("Lote"),
                            .Unidades = Single.Parse(row("Cantidad"))
                        }

                        ArticulosSeleccionados.Add(temp)
                    Next
                End If
            End Using

            GridControlArticulosSeleccionados.DataSource = ArticulosSeleccionados
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al inicializar el formulario:  {ex.Message}")
        End Try
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

    Private Sub LimpiarCampos()
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(SpinEditCantidadSeleccionada, False)
        GridControlArticulosSeleccionados.Visible = True
        TextEditItem.Clear()
        TextEditLocation.Clear()
        SpinEditCantidadSeleccionada.Value = 0
        LabelNombreAlmacen.Text = String.Empty
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreArticulo.Text = String.Empty
        LabelStockArticulo.Text = String.Empty
    End Sub

#End Region

#Region "Eventos de Validación"

    ''' <summary>
    ''' Valida el código de ubicación cuando pierde el foco
    ''' </summary>
    Private Sub TextEditLocation_Validating(sender As Object, e As CancelEventArgs) Handles TextEditLocation.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreUbicacion.Text = String.Empty
            LabelNombreAlmacen.Text = String.Empty

            If String.IsNullOrWhiteSpace(TextEditLocation.Text) Then
                PermitirEdicion(TextEditItem, False)
                e.Cancel = True
                Return
            End If

            ' Buscar la ubicación en la base de datos
            Using Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditLocation.Text)
                If Ubicacion Is Nothing Then
                    ' Ubicación no encontrada
                    PermitirEdicion(TextEditItem, False)
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    Return
                End If

                ' Ubicación válida - actualizar campos
                LabelNombreUbicacion.Text = Ubicacion.Nombre
                LabelNombreAlmacen.Text = Ubicacion.NombreAlmacen
                PermitirEdicion(TextEditItem, True)

                ' Limpiar artículo anterior si existe
            End Using

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al validar la ubicación: {ex.Message}")
            e.Cancel = True
        End Try
    End Sub

    ''' <summary>
    ''' Valida el código de artículo cuando pierde el foco
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextEditItem.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreArticulo.Text = String.Empty
            LabelStockArticulo.Text = String.Empty
            SpinEditCantidadSeleccionada.Value = 0
            PermitirEdicion(SpinEditCantidadSeleccionada, False)

            ' Si el campo está vacío, no validar
            If String.IsNullOrWhiteSpace(TextEditItem.Text) Then
                Return
            End If

            ' Verificar que haya una ubicación válida primero
            If String.IsNullOrWhiteSpace(TextEditLocation.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreUbicacion.Text) Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar una ubicación válida antes de seleccionar un artículo.")
                e.Cancel = True
                Return
            End If

            ' Buscar el artículo en el lote especificado
            Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditItem.Text, TextEditLocation.Text)
                If StockLote Is Nothing Then
                    ' Artículo no encontrado en la ubicación
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    Return
                End If

                ' Artículo válido - actualizar campos
                LabelStockArticulo.Text = StockLote.Cantidad.ToString()
                LabelNombreArticulo.Text = StockLote.Articulo.NombreComercial
                AceptarDecimales(SpinEditCantidadSeleccionada, StockLote.Articulo.PorPeso, IconWeight)
                SpinEditCantidadSeleccionada.Properties.MaxValue = StockLote.Cantidad
                PermitirEdicion(SpinEditCantidadSeleccionada, True)
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
            If String.IsNullOrWhiteSpace(TextEditItem.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreArticulo.Text) Then
                Return
            End If

            ' Validar que la cantidad sea mayor que cero
            If SpinEditCantidadSeleccionada.Value <= 0 Then
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

            ButtonConfirmacionAccion.Focus()

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

            Dim nuevoArticulo As New ArticuloSeleccion With {
                .Articulo = TextEditItem.Text,
                .Ubicacion = TextEditLocation.Text,
                .Descripcion = LabelNombreArticulo.Text,
                .Unidades = SpinEditCantidadSeleccionada.Value
            }

            Operacion.ExecuteNonQuery("INSERT INTO MOVPDA VALUES(?,'SE',?,?,?)", Terminal, nuevoArticulo.Articulo, nuevoArticulo.Unidades, nuevoArticulo.Ubicacion)

            ArticulosSeleccionados.Add(nuevoArticulo)
            PermitirEdicion(TextEditItem, False)
            PermitirEdicion(SpinEditCantidadSeleccionada, False)
            GridControlArticulosSeleccionados.Visible = True
            LimpiarCampos()
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al confirmar la lectura: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón Reset
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(SpinEditCantidadSeleccionada, False)
        LimpiarCampos()
    End Sub

    ''' <summary>
    ''' Maneja el evento de cambio de valor en el DatePicker
    ''' </summary>
    Private Sub datePicker_EditValueChanged(sender As Object, e As EventArgs) Handles DatePicker.EditValueChanged
        Try
            If DatePicker.DateTime = Nothing OrElse DatePicker.DateTime = DateTime.MinValue Then
                Exit Sub
            End If

            GridPedidos.DataSource = Operacion.ExecuteQuery(Querys.Select.ConsultarPedidosPorFecha, DatePicker.EditValue.Date, Almacen).Tables(0)

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al cargar los pedidos: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón de confirmación de acción
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ButtonConfirmacionAccion_Click(sender As Object, e As EventArgs) Handles ButtonConfirmacionAccion.Click

        If RadioButtonOpcionAlbaran.Checked Then
            For Each item As ArticuloSeleccion In ArticulosSeleccionados
                Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, item.Articulo, item.Ubicacion, item.Unidades)
            Next
        End If

        If RadioButtonOpcionTraspasoAlamacen.Checked Then

        End If

    End Sub

    ''' <summary>
    ''' Maneja el evento Click del botón de cancelación en el repositorio
    ''' Elimina el artículo seleccionado de la lista y de la base de datos si es necesario
    ''' </summary>
    Private Sub RepositoryCancelButton_Click(sender As Object, e As EventArgs) Handles RepositoryCancelButton.Click
        Try
            ' Obtener el índice de la fila seleccionada
            Dim RowHandler = GridViewArticulosSeleccionados.FocusedRowHandle

            ' Verificar que hay una fila seleccionada válida
            If RowHandler < 0 OrElse RowHandler >= ArticulosSeleccionados.Count Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "No hay ningún artículo seleccionado para eliminar.")
                Return
            End If

            ' Obtener el artículo seleccionado antes de eliminarlo
            Dim articuloAEliminar As ArticuloSeleccion = ArticulosSeleccionados(RowHandler)

            ' Confirmar la eliminación con el usuario
            Dim resultado = MessageBox.Show(
            $"¿Está seguro de que desea eliminar el artículo {articuloAEliminar.Articulo} de la ubicación {articuloAEliminar.Ubicacion}?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

            If resultado = DialogResult.Yes Then
                ' Eliminar de la tabla MOVPDA si existe un registro
                Try
                    Operacion.ExecuteNonQuery(
                    "DELETE FROM MovPda WHERE Terminal = ? AND Articulo = ? AND Lote = ? AND OPERACION = 'VE'",
                    Terminal,
                    articuloAEliminar.Articulo,
                    articuloAEliminar.Ubicacion,
                    articuloAEliminar.Unidades
                )
                Catch dbEx As Exception
                    ' Log del error pero continuar con la eliminación de la lista
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia,
                    $"No se pudo eliminar el registro de la base de datos: {dbEx.Message}")
                End Try

                ' Eliminar de la colección local
                ArticulosSeleccionados.RemoveAt(RowHandler)

                ' Actualizar la interfaz
                GridControlArticulosSeleccionados.RefreshDataSource()

                ' Si no quedan artículos, ocultar el grid
                If ArticulosSeleccionados.Count = 0 Then
                    GridControlArticulosSeleccionados.Visible = False
                End If

                ' Mensaje de confirmación
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Artículo eliminado correctamente.")
            End If

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al eliminar el artículo: {ex.Message}")
        End Try
    End Sub

#End Region

End Class