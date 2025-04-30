Imports System.ComponentModel

Public Class frmAsignar

    Private Almacen As String = "00" 'Cambiar
    Private ConexionLocal As IDbConnection
    Private DecUds As Integer

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
        Dim Stock As Single
        Stock = Val(txtNuevoStock.Text)
        If Stock = 0 Then
            MsgBox("SE DEBE INDICAR UNA CANTIDAD DISTINTA DE CERO", MsgBoxStyle.Information, "Aviso")
            txtNuevoStock.Focus()
            Exit Sub
        End If

        ' Grabar la asignación
        Dim sql As String
        If AbrirBaseDatos(ConexionLocal) Then

            Dim dsDatos As New DataSet
            dsDatos = CargarDataSet("SELECT Articulo,Lote FROM StockLotes " &
                                            "WHERE Articulo='" & txtArticulo.Text & "' AND Lote='" & txtUbicacion.Text & "'", ConexionLocal)
            If dsDatos.Tables(0).Rows.Count = 0 Then
                sql = "INSERT INTO StockLotes (Almacen,Lote, Articulo, Uds_Ini,Uds_Com,Uds_Ven,Uds_Tra) " &
                          "VALUES ('" & Almacen & "','" & txtUbicacion.Text & "', '" & txtArticulo.Text & "','" & Stock & "',0,0,0)"
            Else
                sql = "UPDATE StockLotes SET Uds_Ini=Uds_Ini+" & Stock & " " &
                          "WHERE Articulo='" & txtArticulo.Text & "' AND Lote='" & txtUbicacion.Text & "'"
            End If

            Dim cmd As New OleDb.OleDbCommand(sql, ConexionLocal)
            cmd.ExecuteNonQuery()
            ConexionLocal.Close()

            ' Añade una fila al grid
            Dim dt As DataTable = CType(Grid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row("Articulo") = txtArticulo.Text & vbTab & lblArticuloNombre.Text
            row("Cantidad") = Stock
            dt.Rows.Add(row)

            Call LimpiarArticulo()
        End If

    End Sub

    Private Sub btnConsultaArtUbiacion_Click(sender As Object, e As EventArgs) Handles btnConsultaArtUbiacion.Click
        frmConsulta.Consulta = "SELECT Articulo,NombreComercial AS Nombre,Round(Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven," & nDecUds & ") AS Stock " &
                               "FROM StockLotes INNER JOIN Articulos ON StockLotes.Articulo=Articulos.Codigo " &
                               "WHERE Almacen='" & Almacen & "' AND StockLotes.Lote='" & txtUbicacion.Text & "'"
        frmConsulta.lblTitulo.Text = "Artículos en ubicación: " & txtUbicacion.Text
        frmConsulta.ShowDialog()
        frmConsulta.Dispose()
    End Sub

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
    Private Sub txtArticulo_Validating(sender As Object, e As CancelEventArgs) Handles txtArticulo.Validating
        Try
            If txtArticulo.Text = "" Then
                '  e.Cancel = True
                Exit Sub
            End If
            Dim Continuar As Boolean = False
            If AbrirBaseDatos(ConexionLocal) Then
                Dim dtDatos As New DataTable
                dtDatos = CargarDataTable("SELECT NombreComercial,PorPeso FROM Articulos WHERE Codigo='" & txtArticulo.Text & "'", ConexionLocal)
                If dtDatos.Rows.Count = 0 Then
                    Call MsgBox("NO EXISTE ARTICULO CON EL CODIGO: " & txtArticulo.Text)
                    e.Cancel = True
                Else
                    lblArticuloNombre.Text = dtDatos.Rows(0).Item("NombreComercial")
                    If dtDatos.Rows(0).Item("PorPeso") = 1 Then
                        lblPorPeso.Visible = True
                        DecUds = nDecUds
                    Else
                        lblPorPeso.Visible = False
                        DecUds = 0
                    End If
                End If

                'dsDatos = CargarDataSet("SELECT Uds_Ini " &
                '                        "FROM StockLotes WHERE Articulo='" & txtArticulo.Text & "' AND Lote='" & txtUbicacion.Text & "'", ConexionLocal)
                'If dsDatos.Tables(0).Rows.Count = 0 Then
                '    lblStock.Text = "0"
                'Else
                '    lblStock.Text = dsDatos.Tables(0).Rows(0).Item("Uds_Ini")
                'End If
                dtDatos.Dispose()
                ConexionLocal.Close()
            Else
                ' cancelar la validación
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ' Comprobar si conexion está abiert, cerrarla
            If ConexionLocal.State = ConnectionState.Open Then
                ConexionLocal.Close()
            End If
        End Try

    End Sub
    Private Sub txtNuevoStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevoStock.KeyPress
        ' Campo numerico con decimales, no acepta letras
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or e.KeyChar = "." Or e.KeyChar = ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles txtUbicacion.Validating
        Try
            If txtUbicacion.Text = "" Then
                Exit Sub
            End If
            If AbrirBaseDatos(ConexionLocal) Then
                Dim dtDatos As New DataTable
                dtDatos = CargarDataTable("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre " &
                                        "FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo " &
                                        "WHERE Ubicaciones.Codigo='" & txtUbicacion.Text & "'", ConexionLocal)
                If dtDatos.Rows.Count = 0 Then
                    MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
                    txtUbicacion.Text = ""
                    e.Cancel = True
                Else
                    Almacen = dtDatos.Rows(0).Item("Almacen")
                    If Almacen <> gAlmacen Then
                        MsgBox("EL ALMACEN ASIGNADO A ESTE TERMINAL: " & gAlmacen & " NO SE CORRESONDE CON EL ALMACEN " & Almacen & " DE ESTA UBICACION", MsgBoxStyle.Exclamation)
                        e.Cancel = True
                    End If

                    lblUbicacionNombre.Text = dtDatos.Rows(0).Item("UbicacionNombre")
                    lblAlmacenNombre.Text = dtDatos.Rows(0).Item("AlmacenNombre")
                End If
                dtDatos.Dispose()
                '  ConexionLocal.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            ConexionLocal.Close()
        End Try
    End Sub

    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs) Handles txtUbicacion.TextChanged
        Dim dsFila = ObtenerFila(RealizarQuery(ConexionLocal, ObtenerInformacionUbicacion, txtUbicacion.Text), 0, 0)
        lblUbicacionNombre.Text = dsFila("Nombre")
        lblAlmacenNombre.Text = dsFila("Almacen")
    End Sub

    Private Sub txtArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtArticulo.TextChanged
        Dim dsFila = ObtenerFila(RealizarQuery(ConexionLocal, ObtenerInformacionDeArticulo, txtArticulo.Text), 0, 0)
        lblArticuloNombre.Text = dsFila("NombreComercial")
    End Sub
End Class
