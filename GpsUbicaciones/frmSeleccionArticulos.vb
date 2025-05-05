Imports System.ComponentModel

Public Class frmSeleccionArticulos

    Private Articulos As BindingList(Of ProductoSeleccion)

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmSeleccionArticulos_Load() Handles MyBase.Load
        ' Inicializar el DataTable
        GridPedidos.DataSource = Articulos

        If GridView1 IsNot Nothing Then
            GridView1.Columns.Clear()
            ' Columna Articulo
            Dim colArticulo As New DevExpress.XtraGrid.Columns.GridColumn()
            colArticulo.FieldName = "CodigoUbicacion"
            colArticulo.Caption = "UBICACIÓN"
            colArticulo.Visible = True
            colArticulo.VisibleIndex = 0
            GridView1.Columns.Add(colArticulo)
            ' Columna Nombre
            Dim colNombre As New DevExpress.XtraGrid.Columns.GridColumn()
            colNombre.FieldName = "NombreComercial"
            colNombre.Caption = "ARTÍCULO"
            colNombre.Visible = True
            colNombre.VisibleIndex = 1
            GridView1.Columns.Add(colNombre)
            ' Columna Ubicacion
            Dim colUbicacion As New DevExpress.XtraGrid.Columns.GridColumn()
            colUbicacion.FieldName = "Destino"
            colUbicacion.Caption = "DESTINO"
            colUbicacion.Visible = True
            colUbicacion.VisibleIndex = 2
            GridView1.Columns.Add(colUbicacion)
            ' Columna Uds
            Dim colUds As New DevExpress.XtraGrid.Columns.GridColumn()
            colUds.FieldName = "Uds"
            colUds.Caption = "UDS"
            colUds.Visible = True
            colUds.VisibleIndex = 3
            GridView1.Columns.Add(colUds)
        End If

    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        If txtUbicacion.Text = "" Then
            MsgBox("Debe ingresar una ubicación", MsgBoxStyle.Information, "Aviso")
            txtUbicacion.Focus()
            Exit Sub
        End If

        Dim Continuar As Boolean
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery("SELECT Ubicaciones.Almacen,Ubicaciones.Nombre AS UbicacionNombre,Almacenes.Nombre AS AlmacenNombre FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo WHERE Ubicaciones.Codigo= ?", txtUbicacion.Text), 0, 0)
            Dim ThisAlmacen = dsDatos("Almacen")
            lblUbicacionNombre.Text = dsDatos("UbicacionNombre")
            lblAlmacen.Text = dsDatos("AlmacenNombre")
            Continuar = True
        Catch ex As InvalidOperationException
            MsgBox("NO EXISTE UBICACION CON ESTE CODIGO: " & txtUbicacion.Text)
            Continuar = False
        End Try
        If Not Continuar Then
            txtUbicacion.Focus()
            Exit Sub
        End If
        MostrarFrames(False)

    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        If EsUbicacion Then
            Call LimpiarUbicacion()
        Else
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

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs)
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
        Operacion.ExecuteNonQuery("INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES (?,'VE',?,?,?)", Terminal, txtArticulo.Text, txtUbicacion.Text, txtNuevoStock.Text)

        Dim dt = CType(Grid.DataSource, DataTable)
        Dim row = dt.NewRow
        row("Articulo") = txtArticulo.Text
        row("Nombre") = lblArticuloNombre.Text
        row("Ubicacion") = txtUbicacion.Text
        row("Uds") = CInt(txtNuevoStock.Text)
        dt.Rows.Add(row)

        LimpiarUbicacion()
    End Sub

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Inicializar el DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Ubicacion", GetType(String))
        dt.Columns.Add("Uds", GetType(Single))

        ' Asignar el DataTable al Grid
        Grid.DataSource = dt


        Call LimpiarUbicacion(False)
        Call LimpiarArticulo(False)

        datePicker.DateTime = Now
        datePicker.Focus()
    End Sub

    Private Sub txtArticulo_Validating(sender As Object, e As CancelEventArgs) Handles txtArticulo.Validating

        If txtArticulo.Text = "" Then
            e.Cancel = True
            Exit Sub
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionDeArticulo, txtArticulo.Text), 0, 0)
            lblArticuloNombre.Text = dsDatos("NombreComercial")

            Dim dsDatos2 = Operacion.ExecuteQuery("SELECT Uds_Ini FROM StockLotes WHERE Articulo=? AND Lote=?", txtArticulo.Text, txtUbicacion.Text)
            If dsDatos2.Tables(0).Rows.Count = 0 Then
                lblStock.Text = "0"
            Else
                lblStock.Text = dsDatos2.Tables(0).Rows(0).Item("Uds_Ini")
            End If
            dsDatos2.Dispose()
        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    'Private Sub DateEdit1_Validated(sender As Object, e As EventArgs) Handles DateEdit1.Validated
    '    ' cargar en gridpedidos la selección de pedidos
    '    Try
    '        Dim sql As String
    '        Dim dt As New DataTable
    '        If AbrirBaseDatos(ConexionLocal) Then
    '            sql = "SELECT Articulo,Descripcion,Round(Sum(Cantidad)," & nDecUds & ") AS SumaUds " &
    '                  "FROM PedCli INNER JOIN MovPCl ON PedCli.Serie=MovPcl.Serie AND PedCli.Numero=MovPCl.Numero " &
    '                  "WHERE Fecha=#" & DateEdit1.DateTime.ToString("MM-dd-yyyy") & "# AND Articulo<>'' GROUP BY Articulo,Descripcion"
    '            dt = CargarDataTable(sql, ConexionLocal)
    '            GridPedidos.DataSource = dt
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        If ConexionLocal.State = ConnectionState.Open Then
    '            ConexionLocal.Close()
    '        End If
    '    End Try
    'End Sub

    Private Sub frmSeleccionArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub datePicker_Validating(sender As Object, e As CancelEventArgs) Handles datePicker.Validating
        ' Si no tiene valor no abandonar el control
        If datePicker.DateTime = Nothing Then
            e.Cancel = True
        End If
    End Sub

    Private Sub datePicker_EditValueChanged(sender As Object, e As EventArgs) Handles datePicker.EditValueChanged
        Dim dsDatos = Operacion.ExecuteQuery(ObtenerArticulosPorFecha, datePicker.Text)
    End Sub
End Class