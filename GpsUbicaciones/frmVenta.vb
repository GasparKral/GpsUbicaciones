Public Class frmVenta

#Region "Configuraciones Iniciales"

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Inicializar el DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
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
#End Region

#Region "Control UI"

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        LabelStockArticulo.Text = String.Empty
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

#Region "Eventos de Formulario"

    Private Sub BotonConfirmarArticulo_Click(sender As Object, e As EventArgs) Handles BotonConfirmarArticulo.Click

        ' Grabar la asignación
        Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, TextEditCodigoArticulo.Text, TextEditCodigoUbicacion.Text, SpinEditCantidadSeleccionada.Value)

        ' Añade una fila al grid
        Dim dt As DataTable = CType(GridControlArticulosSeleccionados.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = TextEditCodigoArticulo.Text
        row("Nombre") = LabelNombreArticulo.Text
        row("Ubicacion") = TextEditCodigoUbicacion.Text
        row("Uds") = CInt(SpinEditCantidadSeleccionada.Value)
        dt.Rows.Add(row)

        LimpiarArticulo()
        LimpiarUbicacion()

        PermitirEdicion(SpinEditCantidadSeleccionada, False)
        PermitirEdicion(TextEditCodigoArticulo, False)
        PermitirEdicion(TextEditCodigoUbicacion, True)
        GridControlArticulosSeleccionados.Visible = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BotonConfirmarUbicacion_Click(sender As Object, e As EventArgs) Handles BotonConfirmarUbicacion.Click
        PermitirEdicion(TextEditCodigoUbicacion, False)
        PermitirEdicion(TextEditCodigoArticulo, True)
        MostrarFrames(False)
    End Sub

    Private Sub TextBoxCodigoUbicacion_TextChanged(sender As Object, e As EventArgs) Handles TextEditCodigoUbicacion.TextChanged

        If String.IsNullOrWhiteSpace(TextEditCodigoUbicacion.Text) Then
            Exit Sub
        End If
        Using Ubicacion = RepositorioUbicacion.ObtenerInformacion(TextEditCodigoUbicacion.Text)
            If Ubicacion Is Nothing Then
                TextEditCodigoUbicacion.Focus()
                TextEditCodigoUbicacion.SelectAll()
            End If

            LabelNombreUbicacion.Text = Ubicacion.Nombre
            LabelNombreAlmacen.Text = Ubicacion.NombreAlmacen
        End Using
    End Sub

    Private Sub TextEditCodigoArticulo_TextChanged(sender As Object, e As EventArgs) Handles TextEditCodigoArticulo.TextChanged

        If String.IsNullOrWhiteSpace(TextEditCodigoArticulo.Text) Then
            Exit Sub
        End If

        Using StockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditCodigoArticulo.Text, TextEditCodigoUbicacion.Text)
            If StockLote Is Nothing Then
                TextEditCodigoArticulo.Focus()
                TextEditCodigoArticulo.SelectAll()
                Exit Sub
            End If

            LabelNombreArticulo.Text = StockLote.Articulo.NombreComercial
            LabelStockArticulo.Text = StockLote.Cantidad
            AceptarDecimales(SpinEditCantidadSeleccionada, StockLote.Articulo.PorPeso, LabelIndicadorPorPeso)
            SpinEditCantidadSeleccionada.Properties.MaxValue = StockLote.Cantidad
            PermitirEdicion(SpinEditCantidadSeleccionada, True)
        End Using
    End Sub
#End Region

End Class