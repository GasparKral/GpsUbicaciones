Public Class frmVenta

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        If TextBoxCodigoUbicacion.Text = "" Then
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, MensajeCodigoUbicacionFaltante)
            TextBoxCodigoUbicacion.Focus()
            Exit Sub
        End If

        Dim Continuar As Boolean = False
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo WHERE Ubicaciones.Codigo= ?", TextBoxCodigoUbicacion.Text), 0, 0)

            LabelNombreUbicacion.Text = dsDatos("UbicacionNombre")
            LabelNombreAlmacen.Text = dsDatos("AlmacenNombre")
            Continuar = True
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoUbicacion.SelectAll()
            TextBoxCodigoUbicacion.Focus()
        End Try
        If Not Continuar Then
            TextBoxCodigoUbicacion.Focus()
            Exit Sub
            Call MostrarFrames(False)
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

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = ""
        LabelNombreAlmacen.Text = ""
        TextBoxCodigoUbicacion.Text = ""
        If ActivarFoco Then
            TextBoxCodigoUbicacion.Focus()
        End If
    End Sub

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = ""
        LabelStockArticulo.Text = ""
        TextBoxCodigoArticulo.Text = ""
        TextBoxCantidadSeleccionada.Text = ""
        If ActivarFoco Then
            TextBoxCodigoArticulo.Focus()
        End If
    End Sub

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles btnArticulo.Click
        If TextBoxCodigoArticulo.Text = "" Then
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, MensajeCodigoArticuloFaltante)
            TextBoxCodigoArticulo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(TextBoxCantidadSeleccionada.Text) Then
            FabricaMensajes.ShowMessage(TipoMensaje.Advertencia, MensajeValorNumericoRequerido)
            TextBoxCantidadSeleccionada.Focus()
            Exit Sub
        End If

        ' Grabar la asignación
        Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text, TextBoxCantidadSeleccionada.Text)

        ' Añade una fila al grid
        Dim dt As DataTable = CType(GridControlArticulosSeleccionados.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = TextBoxCodigoArticulo.Text
        row("Nombre") = LabelNombreArticulo.Text
        row("Ubicacion") = TextBoxCodigoUbicacion.Text
        row("Uds") = CInt(TextBoxCantidadSeleccionada.Text)
        dt.Rows.Add(row)

        LimpiarUbicacion()
    End Sub

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

    Private Sub txtArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxCodigoArticulo.Validating
        If TextBoxCodigoArticulo.Text = "" Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Continuar As Boolean = False

        Try
            Dim dsDatos = Operacion.ExecuteQuery("SELECT NombreComercial,PorPeso FROM Articulos WHERE Codigo= ?", TextBoxCodigoArticulo.Text)

            If dsDatos.Tables(0).Rows.Count = 0 Then
                Call MsgBox("NO EXISTE ARTICULO CON EL CODIGO: " & TextBoxCodigoArticulo.Text)
                e.Cancel = True
            Else
                LabelNombreArticulo.Text = dsDatos.Tables(0).Rows(0).Item("NombreComercial")
                If dsDatos.Tables(0).Rows(0).Item("PorPeso") = 1 Then
                    lblPorPeso.Visible = True
                    'cambiar formato txtnuevostock para que no acepte decimales
                Else
                    lblPorPeso.Visible = False
                End If

                dsDatos = Operacion.ExecuteQuery("SELECT Uds_Ini FROM StockLotes WHERE Articulo = ? AND Lote = ?", TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)

                If dsDatos.Tables(0).Rows.Count = 0 Then
                    LabelStockArticulo.Text = "0"
                Else
                    LabelStockArticulo.Text = dsDatos.Tables(0).Rows(0).Item("Uds_Ini")
                End If
            End If
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeSinDatos, ex.Message))
            e.Cancel = True
        End Try

    End Sub

    Private Sub frmVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

End Class