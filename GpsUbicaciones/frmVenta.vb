Imports System.ComponentModel
Imports DevExpress.CodeParser
Imports DevExpress.XtraGrid

Public Class frmVenta

    Private ConexionLocal As IDbConnection
    Private Almacen As String

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
        If AbrirBaseDatos(ConexionLocal) Then
            Dim dsDatos As New DataSet
            dsDatos = CargarDataSet("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo WHERE Ubicaciones.Codigo='" & txtUbicacion.Text & "'", ConexionLocal)
            If dsDatos.Tables(0).Rows.Count = 0 Then
                Call MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
            Else
                Almacen = dsDatos.Tables(0).Rows(0).Item("Almacen")
                lblUbicacionNombre.Text = dsDatos.Tables(0).Rows(0).Item("UbicacionNombre")
                lblAlmacen.Text = dsDatos.Tables(0).Rows(0).Item("AlmacenNombre")
                Continuar = True
            End If
            dsDatos.Dispose()
            ConexionLocal.Close()
        End If
        If Not Continuar Then
            txtUbicacion.Focus()
            Exit Sub
        End If
        Call MostrarFrames(False)
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
        Dim sql As String
        If AbrirBaseDatos(ConexionLocal) Then
            Dim dsDatos As New DataSet
            sql = "INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) " &
                  "VALUES ('" & Terminal & "','VE','" & txtArticulo.Text & "','" & txtUbicacion.Text & "', '" & txtNuevoStock.Text & "')"

            Dim cmd As New OleDb.OleDbCommand(sql, ConexionLocal)
            cmd.ExecuteNonQuery()
            ConexionLocal.Close()

            ' Añade una fila al grid
            Dim dt As DataTable = CType(Grid.DataSource, DataTable)
            Dim row As DataRow = dt.NewRow()
            row("Articulo") = txtArticulo.Text
            row("Nombre") = lblArticuloNombre.Text
            row("Ubicacion") = txtUbicacion.Text
            row("Uds") = CInt(txtNuevoStock.Text)
            dt.Rows.Add(row)

            Call LimpiarUbicacion()
        End If

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
                        'cambiar formato txtnuevostock para que no acepte decimales
                    Else
                        lblPorPeso.Visible = False
                    End If
                End If


                dtDatos = CargarDataTable("SELECT Uds_Ini " &
                                        "FROM StockLotes WHERE Articulo='" & txtArticulo.Text & "' AND Lote='" & txtUbicacion.Text & "'", ConexionLocal)
                If dtDatos.Rows.Count = 0 Then
                    lblStock.Text = "0"
                Else
                    lblStock.Text = dtDatos.Rows(0).Item("Uds_Ini")
                End If
                dtDatos.Dispose()
                ConexionLocal.Close()
            Else
                ' cancelar la validación
                e.Cancel = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub txtArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtArticulo.TextChanged

    End Sub
End Class