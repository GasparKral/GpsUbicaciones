Public Class frmVenta

#Region "Configuraciones Iniciales"

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Inicializar el DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Ref", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Ubicacion", GetType(String))
        dt.Columns.Add("Uds", GetType(Single))

        ' Asignar el DataTable al Grid
        GridControlArticulosSeleccionados.DataSource = dt

        Call LimpiarUbicacion()
    End Sub

#End Region

#Region "Validaciones de Campos"
    Private Sub frmVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    ''' <summary>
    ''' Valida que la ubicación ingresada sea válida
    ''' </summary>
    ''' <returns>True si la ubicación es válida, False en caso contrario</returns>
    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrWhiteSpace(TextEditCodigoUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar un código de ubicación.")
            TextEditCodigoUbicacion.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(LabelNombreUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "La ubicación no existe o no es válida.")
            TextEditCodigoUbicacion.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Valida que el artículo ingresado sea válido
    ''' </summary>
    ''' <returns>True si el artículo es válido, False en caso contrario</returns>
    Private Function ValidarArticulo() As Boolean
        If String.IsNullOrWhiteSpace(TextEditCodigoArticulo.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar un código de artículo.")
            TextEditCodigoArticulo.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(LabelNombreArticulo.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "El artículo no existe o no es válido.")
            TextEditCodigoArticulo.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Valida que la cantidad seleccionada sea válida
    ''' </summary>
    ''' <returns>True si la cantidad es válida, False en caso contrario</returns>
    Private Function ValidarCantidad() As Boolean
        If SpinEditCantidadSeleccionada.Value <= 0 Then
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

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        LabelStockArticulo.Text = String.Empty
        IconWeight.Visible = False
        TextEditCodigoArticulo.Text = String.Empty
        SpinEditCantidadSeleccionada.Value = 0
        If ActivarFoco Then
            TextEditCodigoArticulo.Focus()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreAlmacen.Text = String.Empty
        TextEditCodigoUbicacion.Text = String.Empty
        If ActivarFoco Then
            TextEditCodigoUbicacion.Focus()
        End If
    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        If EsUbicacion Then
            GroupControlArticulos.Visible = False
            LimpiarUbicacion()
        Else
            GroupControlArticulos.Visible = True
            LimpiarArticulo()
        End If
    End Sub

#End Region

#Region "Funciones Auxiliares"
    Private Function EliminarArticuloBaseDeDatos(CodigoArticulo As String, Cantidad As Single, CodigoUbicacion As String)
        Try
            Operacion.ExecuteNonQuery("DELETE FROM MOVPDA WHERE Terminal = ? AND Operacion ='VE' AND Articulo = ?", Terminal, CodigoArticulo, Cantidad, CodigoUbicacion)
            Return True
        Catch ex As Exception
            ' Log del error si es necesario
            Console.WriteLine("Error al eliminar de la base de datos MOVPDA: " & ex.Message)
            Return False
        End Try


    End Function
#End Region

#Region "Eventos de Validación"

    ''' <summary>
    ''' Valida el código de ubicación cuando pierde el foco
    ''' </summary>
    Private Sub TextEditCodigoUbicacion_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextEditCodigoUbicacion.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreUbicacion.Text = String.Empty
            LabelNombreAlmacen.Text = String.Empty

            ' Si el campo está vacío, no validar pero limpiar campos dependientes
            If String.IsNullOrWhiteSpace(TextEditCodigoUbicacion.Text) Then
                LimpiarArticulo(False)
                PermitirEdicion(TextEditCodigoArticulo, False)
                Return
            End If

            ' Buscar la ubicación en la base de datos
            Using Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacion.Text)
                If Ubicacion Is Nothing Then
                    LimpiarArticulo(False)
                    PermitirEdicion(TextEditCodigoArticulo, False)
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    TextEditCodigoUbicacion.SelectAll()
                    Return
                End If

                ' Ubicación válida - actualizar campos
                LabelNombreUbicacion.Text = Ubicacion.Nombre
                LabelNombreAlmacen.Text = Ubicacion.NombreAlmacen

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
    Private Sub TextEditCodigoArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextEditCodigoArticulo.Validating
        Try
            ' Limpiar los campos relacionados
            LabelNombreArticulo.Text = String.Empty
            LabelStockArticulo.Text = String.Empty
            SpinEditCantidadSeleccionada.Value = 0
            PermitirEdicion(SpinEditCantidadSeleccionada, False)

            ' Si el campo está vacío, no validar
            If String.IsNullOrWhiteSpace(TextEditCodigoArticulo.Text) Then
                Return
            End If

            ' Verificar que haya una ubicación válida primero
            If String.IsNullOrWhiteSpace(TextEditCodigoUbicacion.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreUbicacion.Text) Then
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar una ubicación válida antes de seleccionar un artículo.")
                e.Cancel = True
                Return
            End If

            ' Buscar el artículo en el lote especificado
            Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditCodigoArticulo.Text, TextEditCodigoUbicacion.Text)
                If StockLote Is Nothing Then
                    e.Cancel = True ' Cancelar el cambio de foco para que el usuario corrija
                    TextEditCodigoArticulo.SelectAll()
                    Return
                End If

                ' Artículo válido - actualizar campos
                LabelNombreArticulo.Text = StockLote.Articulo.NombreComercial
                LabelStockArticulo.Text = StockLote.Cantidad.ToString()
                AceptarDecimales(SpinEditCantidadSeleccionada, StockLote.Articulo.PorPeso, IconWeight)
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
    Private Sub SpinEditCantidadSeleccionada_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SpinEditCantidadSeleccionada.Validating
        Try
            ' Si no hay artículo seleccionado, no validar
            If String.IsNullOrWhiteSpace(TextEditCodigoArticulo.Text) OrElse String.IsNullOrWhiteSpace(LabelNombreArticulo.Text) Then
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

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al validar la cantidad: {ex.Message}")
            e.Cancel = True
        End Try
    End Sub

#End Region

#Region "Eventos de Formulario"

    Private Sub BotonConfirmarArticulo_Click(sender As Object, e As EventArgs) Handles BotonConfirmarArticulo.Click
        Try
            ' Validar todos los campos antes de confirmar
            If Not ValidarUbicacion() OrElse Not ValidarArticulo() OrElse Not ValidarCantidad() Then
                Exit Sub
            End If

            ' Grabar la asignación
            Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, RepositorioArticulo.ObtenerInformacion(TextEditCodigoArticulo.Text).Codigo, TextEditCodigoUbicacion.Text, SpinEditCantidadSeleccionada.Value)

            ' Añade una fila al grid
            Dim dt As DataTable = GridControlArticulosSeleccionados.DataSource
            Dim row As DataRow = dt.NewRow()
            row("Ref") = TextEditCodigoArticulo.Text
            row("Nombre") = LabelNombreArticulo.Text
            row("Ubicacion") = TextEditCodigoUbicacion.Text
            row("Uds") = CInt(SpinEditCantidadSeleccionada.Value)
            dt.Rows.Add(row)

            LimpiarArticulo()
            LimpiarUbicacion()

            PermitirEdicion(SpinEditCantidadSeleccionada, False)
            PermitirEdicion(TextEditCodigoArticulo, False)
            GridControlArticulosSeleccionados.Visible = True
            GroupControlArticulos.Visible = False
            GroupControlUbicacion.Enabled = True
            PermitirEdicion(TextEditCodigoUbicacion, True, True)

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al confirmar el artículo: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BotonConfirmarUbicacion_Click(sender As Object, e As EventArgs) Handles BotonConfirmarUbicacion.Click
        Try
            ' Validar la ubicación antes de confirmar
            If Not ValidarUbicacion() Then
                Exit Sub
            End If

            PermitirEdicion(TextEditCodigoUbicacion, False)
            PermitirEdicion(TextEditCodigoArticulo, True)
            MostrarFrames(False)

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al confirmar la ubicación: {ex.Message}")
        End Try
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        LimpiarUbicacion()
        LimpiarArticulo(False)

        GridControlArticulosSeleccionados.Visible = False

        ' Configurar el estado inicial de los controles
        PermitirEdicion(TextEditCodigoUbicacion, True)
        PermitirEdicion(TextEditCodigoArticulo, False)
        PermitirEdicion(SpinEditCantidadSeleccionada, False)

        ' Mostrar el frame de ubicación y ocultar el de artículos
        MostrarFrames(True)

        ' Establecer el foco en el campo de ubicación
        TextEditCodigoUbicacion.Focus()
    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs)

        ' Obtener el index de la fila
        Dim RowHandler = GridViewArticulosSeleccionados.FocusedRowHandle

        Dim codigoArticulo = GridViewArticulosSeleccionados.GetRowCellValue(RowHandler, "Ref")
        Dim cantidad = Single.Parse(GridViewArticulosSeleccionados.GetRowCellValue(RowHandler, "Uds"))
        Dim codigoUbicacion = GridViewArticulosSeleccionados.GetRowCellValue(RowHandler, "Ubicacion")

        If Not EliminarArticuloBaseDeDatos(codigoArticulo, cantidad, codigoUbicacion) Then
            MessageBox.Show("Error al eliminar el artículo de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

#End Region

End Class