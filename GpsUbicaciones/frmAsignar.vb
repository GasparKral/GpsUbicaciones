Public Class frmAsignar

    Private Almacen As String = "00" 'Cambiar
    Private ConexionLocal As IDbConnection
    Private DecUds As Integer

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles btnArticulo.Click
        ' Validaciones iniciales
        If String.IsNullOrEmpty(txtArticulo.Text) Then
            MessageBox.Show("Debe ingresar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtArticulo.Focus()
            Return
        End If
        Dim stock As Single
        If Not Single.TryParse(txtNuevoStock.Text, stock) OrElse stock = 0 Then
            MessageBox.Show(If(Not IsNumeric(txtNuevoStock.Text),
                         "Debe ingresar un valor numérico",
                         "SE DEBE INDICAR UNA CANTIDAD DISTINTA DE CERO"),
                      "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNuevoStock.Focus()
            Return
        End If

        ' Usar la transacción condicional
        Try

            Using nestedTx As New NestedConditionalTransaction(Operacion)
                ' Definir la consulta condicional
                Dim conditionQuery = "SELECT Articulo, Lote FROM StockLotes WHERE Articulo=? AND Lote=?"

                ' Definir acciones para cada caso
                Dim ifTrueAction As Action(Of IDbTransaction) = Sub(tran)
                                                                    ' Caso cuando no existe el registro (INSERT)
                                                                    Dim insertSql = "INSERT INTO StockLotes (Almacen, Lote, Articulo, Uds_Ini, Uds_Com, Uds_Ven, Uds_Tra) " &
                           "VALUES (?, ?, ?, ?, 0, 0, 0)"

                                                                    Operacion.ExecuteNonQuery(tran.Connection, insertSql, tran,
                                      Almacen, txtUbicacion.Text, txtArticulo.Text, stock)
                                                                End Sub

                Dim ifFalseAction As Action(Of IDbTransaction) = Sub(tran)
                                                                     ' Caso cuando ya existe el registro (UPDATE)
                                                                     Dim updateSql = "UPDATE StockLotes SET Uds_Ini=Uds_Ini+? " &
                           "WHERE Articulo=? AND Lote=?"

                                                                     Operacion.ExecuteNonQuery(tran.Connection, updateSql, tran,
                                      stock, txtArticulo.Text, txtUbicacion.Text)
                                                                 End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
            conditionQuery,
            ifTrueAction,
            ifFalseAction,
            txtArticulo.Text, txtUbicacion.Text)

                ' Si todo fue bien, actualizar la interfaz
                If success Then
                    ' Añadir fila al grid
                    Dim dt As DataTable = CType(Grid.DataSource, DataTable)
                    Dim row As DataRow = dt.NewRow()
                    row("Articulo") = $"{txtArticulo.Text}{vbTab}{lblArticuloNombre.Text}"
                    row("Cantidad") = stock
                    dt.Rows.Add(row)

                    LimpiarArticulo()
                End If
            End Using
        Catch ex As DatabaseOperationException
            MessageBox.Show($"Error en la operación de base de datos: {ex.Message}",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error inesperado: {ex.Message}",
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub btnConsultaArtUbiacion_Click(sender As Object, e As EventArgs) Handles btnConsultaArtUbiacion.Click
    '    frmConsulta.Consulta = "SELECT Articulo,NombreComercial AS Nombre,Round(Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven," & nDecUds & ") AS Stock " &
    '                           "FROM StockLotes INNER JOIN Articulos ON StockLotes.Articulo=Articulos.Codigo " &
    '                           "WHERE Almacen='" & Almacen & "' AND StockLotes.Lote='" & txtUbicacion.Text & "'"
    '    frmConsulta.lblTitulo.Text = "Artículos en ubicación: " & txtUbicacion.Text
    '    frmConsulta.ShowDialog()
    '    frmConsulta.Dispose()
    'End Sub

    Private Sub btnNuevaUbicacion_Click(sender As Object, e As EventArgs) Handles btnNuevaUbicacion.Click
        Call LimpiarArticulo(False)
        Call MostrarFrames(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        'If txtUbicacion.Text = "" Then
        '    MsgBox("Debe ingresar una ubicación", MsgBoxStyle.Information, "Aviso")
        '    txtUbicacion.Focus()
        '    Exit Sub
        'End If
        'Dim Continuar = False
        'If AbrirBaseDatos(ConexionLocal) Then
        '    Dim dsDatos As New DataSet
        '    dsDatos = CargarDataSet("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo WHERE Ubicaciones.Codigo='" & txtUbicacion.Text & "'", ConexionLocal)
        '    If dsDatos.Tables(0).Rows.Count = 0 Then
        '        MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
        '    Else
        '        Almacen = dsDatos.Tables(0).Rows(0).Item("Almacen")
        '        lblUbicacionNombre.Text = dsDatos.Tables(0).Rows(0).Item("UbicacionNombre")
        '        lblAlmacenNombre.Text = dsDatos.Tables(0).Rows(0).Item("AlmacenNombre")
        '        Continuar = True
        '    End If
        '    dsDatos.Dispose()
        '    ConexionLocal.Close()
        'End If
        'If Not Continuar Then
        '    txtUbicacion.Focus()
        '    Exit Sub
        'End If

        MostrarFrames(False)
    End Sub

    Private Sub frmAsignar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Inicializar el DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
        dt.Columns.Add("Cantidad", GetType(Single))

        ' Asignar el DataTable al Grid
        Grid.DataSource = dt

        Call LimpiarUbicacion()
    End Sub

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        lblArticuloNombre.Text = ""
        ' lblStock.Text = ""
        txtArticulo.Text = ""
        txtNuevoStock.Text = ""
        If ActivarFoco Then
            txtArticulo.Focus()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        lblUbicacionNombre.Text = ""
        lblAlmacenNombre.Text = ""
        txtUbicacion.Text = ""
        If ActivarFoco Then
            txtUbicacion.Focus()
        End If
    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        If EsUbicacion Then
            GroupControlArticulos.Visible = False
            Grid.Visible = False

            Call LimpiarUbicacion()
        Else
            GroupControlArticulos.Visible = True
            Grid.Visible = True
            ' vaciar el grid
            If Grid.DataSource IsNot Nothing Then
                Dim dt As DataTable = CType(Grid.DataSource, DataTable)
                dt.Rows.Clear()
            End If
            Call LimpiarArticulo()
        End If
    End Sub

    Private Sub txtArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtArticulo.TextChanged
        Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionDeArticulo, txtArticulo.Text), 0, 0)
        lblArticuloNombre.Text = dsFila("NombreComercial")
    End Sub

    'Private Sub txtArticulo_Validating(sender As Object, e As CancelEventArgs) Handles txtArticulo.Validating
    '    Try
    '        If txtArticulo.Text = "" Then
    '            '  e.Cancel = True
    '            Exit Sub
    '        End If
    '        Dim Continuar As Boolean = False
    '        If AbrirBaseDatos(ConexionLocal) Then
    '            Dim dtDatos As New DataTable
    '            dtDatos = CargarDataTable("SELECT NombreComercial,PorPeso FROM Articulos WHERE Codigo='" & txtArticulo.Text & "'", ConexionLocal)
    '            If dtDatos.Rows.Count = 0 Then
    '                Call MsgBox("NO EXISTE ARTICULO CON EL CODIGO: " & txtArticulo.Text)
    '                e.Cancel = True
    '            Else
    '                lblArticuloNombre.Text = dtDatos.Rows(0).Item("NombreComercial")
    '                If dtDatos.Rows(0).Item("PorPeso") = 1 Then
    '                    lblPorPeso.Visible = True
    '                    DecUds = nDecUds
    '                Else
    '                    lblPorPeso.Visible = False
    '                    DecUds = 0
    '                End If
    '            End If

    '            'dsDatos = CargarDataSet("SELECT Uds_Ini " &
    '            '                        "FROM StockLotes WHERE Articulo='" & txtArticulo.Text & "' AND Lote='" & txtUbicacion.Text & "'", ConexionLocal)
    '            'If dsDatos.Tables(0).Rows.Count = 0 Then
    '            '    lblStock.Text = "0"
    '            'Else
    '            '    lblStock.Text = dsDatos.Tables(0).Rows(0).Item("Uds_Ini")
    '            'End If
    '            dtDatos.Dispose()
    '            ConexionLocal.Close()
    '        Else
    '            ' cancelar la validación
    '            e.Cancel = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        ' Comprobar si conexion está abiert, cerrarla
    '        If ConexionLocal.State = ConnectionState.Open Then
    '            ConexionLocal.Close()
    '        End If
    '    End Try

    'End Sub

    Private Sub txtNuevoStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevoStock.KeyPress
        ' Campo numerico con decimales, no acepta letras
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or e.KeyChar = "." Or e.KeyChar = ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs) Handles txtUbicacion.TextChanged
        Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionUbicacion, txtUbicacion.Text), 0, 0)
        lblUbicacionNombre.Text = dsFila("Nombre")
        lblAlmacenNombre.Text = dsFila("Almacen")
    End Sub

    'Private Sub txtUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles txtUbicacion.Validating
    '    Try
    '        If txtUbicacion.Text = "" Then
    '            Exit Sub
    '        End If
    '        If AbrirBaseDatos(ConexionLocal) Then
    '            Dim dtDatos As New DataTable
    '            dtDatos = CargarDataTable("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre " &
    '                                    "FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo " &
    '                                    "WHERE Ubicaciones.Codigo='" & txtUbicacion.Text & "'", ConexionLocal)
    '            If dtDatos.Rows.Count = 0 Then
    '                MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
    '                txtUbicacion.Text = ""
    '                e.Cancel = True
    '            Else
    '                Almacen = dtDatos.Rows(0).Item("Almacen")
    '                If Almacen <> gAlmacen Then
    '                    MsgBox("EL ALMACEN ASIGNADO A ESTE TERMINAL: " & gAlmacen & " NO SE CORRESONDE CON EL ALMACEN " & Almacen & " DE ESTA UBICACION", MsgBoxStyle.Exclamation)
    '                    e.Cancel = True
    '                End If

    '                lblUbicacionNombre.Text = dtDatos.Rows(0).Item("UbicacionNombre")
    '                lblAlmacenNombre.Text = dtDatos.Rows(0).Item("AlmacenNombre")
    '            End If
    '            dtDatos.Dispose()
    '            '  ConexionLocal.Close()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        ConexionLocal.Close()
    '    End Try
    'End Sub
End Class