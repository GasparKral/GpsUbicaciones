Public Class frmVenta

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        If txtUbicacion.Text = "" Then
            MsgBox("Debe ingresar una ubicación", MsgBoxStyle.Information, "Aviso")
            txtUbicacion.Focus()
            Exit Sub
        End If

        Dim Continuar As Boolean = False
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo WHERE Ubicaciones.Codigo= ?", txtUbicacion.Text), 0, 0)

            lblUbicacionNombre.Text = dsDatos("UbicacionNombre")
            lblAlmacen.Text = dsDatos("AlmacenNombre")
            Continuar = True
        Catch ex As InvalidOperationException
            txtUbicacion.SelectAll()
            txtUbicacion.Focus()
            MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
        End Try
        If Not Continuar Then
            txtUbicacion.Focus()
            Exit Sub
            Call MostrarFrames(False)
        End If
    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        If EsUbicacion Then
            GroupControlArticulos.Visible = False

            Call LimpiarUbicacion()
        Else
            GroupControlArticulos.Visible = True
            Call LimpiarArticulo()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        lblUbicacionNombre.Text = ""
        lblAlmacen.Text = ""
        txtUbicacion.Text = ""
        If ActivarFoco Then
            txtUbicacion.Focus()
        End If
    End Sub

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        lblArticuloNombre.Text = ""
        lblStock.Text = ""
        txtArticulo.Text = ""
        txtNuevoStock.Text = ""
        If ActivarFoco Then
            txtArticulo.Focus()
        End If
    End Sub

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles btnArticulo.Click
        If txtArticulo.Text = "" Then
            MsgBox("Debe ingresar un artículo", MsgBoxStyle.Information, "Aviso")
            txtArticulo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(txtNuevoStock.Text) Then
            MsgBox("Debe ingresar un valor numérico", MsgBoxStyle.Information, "Aviso")
            txtNuevoStock.Focus()
            Exit Sub
        End If

        ' Grabar la asignación
        Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES(?,'VE',?,?,?)", Terminal, txtArticulo.Text, txtUbicacion.Text, txtNuevoStock.Text)

        ' Añade una fila al grid
        Dim dt As DataTable = CType(Grid.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = txtArticulo.Text
        row("Nombre") = lblArticuloNombre.Text
        row("Ubicacion") = txtUbicacion.Text
        row("Uds") = CInt(txtNuevoStock.Text)
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
        Grid.DataSource = dt

        Call LimpiarUbicacion()
    End Sub

    Private Sub txtArticulo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtArticulo.Validating
        If txtArticulo.Text = "" Then
            e.Cancel = True
            Exit Sub
        End If
        Dim Continuar As Boolean = False

        Try
            Dim dsDatos = Operacion.ExecuteQuery("SELECT NombreComercial,PorPeso FROM Articulos WHERE Codigo= ?", txtArticulo.Text)

            If dsDatos.Tables(0).Rows.Count = 0 Then
                Call MsgBox("NO EXISTE ARTICULO CON EL CODIGO: " & txtArticulo.Text)
                e.Cancel = True
            Else
                lblArticuloNombre.Text = dsDatos.Tables(0).Rows(0).Item("NombreComercial")
                If dsDatos.Tables(0).Rows(0).Item("PorPeso") = 1 Then
                    lblPorPeso.Visible = True
                    'cambiar formato txtnuevostock para que no acepte decimales
                Else
                    lblPorPeso.Visible = False
                End If

                dsDatos = Operacion.ExecuteQuery("SELECT Uds_Ini FROM StockLotes WHERE Articulo = ? AND Lote = ?", txtArticulo.Text, txtUbicacion.Text)

                If dsDatos.Tables(0).Rows.Count = 0 Then
                    lblStock.Text = "0"
                Else
                    lblStock.Text = dsDatos.Tables(0).Rows(0).Item("Uds_Ini")
                End If
            End If
        Catch ex As Exception
            e.Cancel = True
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs) Handles txtUbicacion.TextChanged

    End Sub
End Class