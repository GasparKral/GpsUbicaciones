Imports System.ComponentModel
Imports System.Globalization

Public Class frmAsignar
    Implements IDisposable

    ' Constantes para mensajes
    Private Const MSG_ARTICULO_REQUERIDO As String = "Debe ingresar un artículo"
    Private Const MSG_CANTIDAD_INVALIDA As String = "Debe ingresar un valor numérico"
    Private Const MSG_CANTIDAD_CERO As String = "SE DEBE INDICAR UNA CANTIDAD DISTINTA DE CERO"
    Private Const MSG_UBICACION_REQUERIDA As String = "Debe ingresar una ubicación"
    Private Const MSG_ALMACEN_NO_COINCIDE As String = "EL ALMACEN ASIGNADO A ESTE TERMINAL: {0} NO SE CORRESPONDE CON EL ALMACEN {1} DE ESTA UBICACION"
    Private Const MSG_ARTICULO_NO_EXISTE As String = "NO EXISTE ARTICULO CON ESTE CODIGO: {0}"
    Private Const MSG_UBICACION_NO_EXISTE As String = "NO EXISTE UBICACION CON ESTE CODIGO: {0}"
    Private Const TITULO_AVISO As String = "Aviso"
    Private Const TITULO_ERROR As String = "Error"
    Private Const TITULO_ADVERTENCIA As String = "Advertencia"

    ' Métodos principales
    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles btnArticulo.Click
        ' Validaciones iniciales
        If Not ValidarDatosArticulo() Then
            Return
        End If

        ' Usar la transacción condicional
        Try
            Using nestedTx As New NestedConditionalTransaction(Operacion)
                ' Definir la consulta condicional
                Dim conditionQuery = "SELECT COUNT(*) > 0 FROM StockLotes WHERE Articulo = ? AND Lote = ?"
                Dim stock As Single = Single.Parse(txtNuevoStock.Text, CultureInfo.InvariantCulture)

                ' Definir acciones para cada caso
                Dim ifTrueAction As Action(Of IDbConnection) = Sub(con)
                                                                   ' Caso cuando no existe el registro (INSERT)
                                                                   Dim insertSql = "INSERT INTO StockLotes (Almacen, Lote, Articulo, Uds_Ini, Uds_Com, Uds_Ven, Uds_Tra) VALUES (?, ?, ?, ?, 0, 0, 0)"
                                                                   Operacion.ExecuteNonQuery(con, insertSql, Almacen, txtUbicacion.Text, txtArticulo.Text, stock)
                                                               End Sub

                Dim ifFalseAction As Action(Of IDbConnection) = Sub(con)
                                                                    ' Caso cuando ya existe el registro (UPDATE)
                                                                    Dim updateSql = "UPDATE StockLotes SET Uds_Ini=Uds_Ini+ ? WHERE Articulo=? AND Lote=?"
                                                                    Operacion.ExecuteNonQuery(con, updateSql, stock, txtArticulo.Text, txtUbicacion.Text)
                                                                End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
                    conditionQuery,
                    ifTrueAction,
                    ifFalseAction,
                    txtArticulo.Text, txtUbicacion.Text
                )

                ' Si todo fue bien, actualizar la interfaz
                If success Then
                    ActualizarGridDespuesDeOperacion(stock)
                    LimpiarArticulo()
                End If
            End Using
        Catch ex As DatabaseOperationException
            MostrarError($"Error en la operación de base de datos: {ex.Message}")
        Catch ex As Exception
            MostrarError($"Error inesperado: {ex.Message}")
        End Try
    End Sub

    Private Function ValidarDatosArticulo() As Boolean
        If String.IsNullOrEmpty(txtArticulo.Text) Then
            MessageBox.Show(MSG_ARTICULO_REQUERIDO, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtArticulo.Focus()
            Return False
        End If

        Dim stock As Single
        If Not Single.TryParse(txtNuevoStock.Text, NumberStyles.Any, CultureInfo.InvariantCulture, stock) Then
            MessageBox.Show(MSG_CANTIDAD_INVALIDA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNuevoStock.Focus()
            Return False
        End If

        If stock = 0 Then
            MessageBox.Show(MSG_CANTIDAD_CERO, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNuevoStock.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ActualizarGridDespuesDeOperacion(stock As Single)
        Dim dt As DataTable = CType(Grid.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = $"{txtArticulo.Text}{vbTab}{lblArticuloNombre.Text}"
        row("Cantidad") = stock
        dt.Rows.Add(row)
    End Sub

    Private Sub btnConsultaArtUbiacion_Click(sender As Object, e As EventArgs) Handles btnConsultaArtUbiacion.Click
        Try
            Using frm As New frmConsulta()
                frm.Consulta = $"SELECT Articulo, NombreComercial AS Nombre, Round(Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven, {nDecUds}) AS Stock " &
                               $"FROM StockLotes INNER JOIN Articulos ON StockLotes.Articulo=Articulos.Codigo " &
                               $"WHERE Almacen='{Almacen}' AND StockLotes.Lote='{txtUbicacion.Text}'"
                frm.lblTitulo.Text = $"Artículos en ubicación: {txtUbicacion.Text}"
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            MostrarError($"Error al consultar artículos: {ex.Message}")
        End Try
    End Sub

    Private Sub btnNuevaUbicacion_Click(sender As Object, e As EventArgs) Handles btnNuevaUbicacion.Click
        LimpiarArticulo(False)
        MostrarFrames(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        If Not ValidarUbicacion() Then
            Return
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(
                "SELECT Ubicaciones.Almacen, Ubicaciones.Nombre AS UbicacionNombre, Almacenes.Nombre AS AlmacenNombre " &
                "FROM Ubicaciones LEFT JOIN Almacenes ON Left(Ubicaciones.Codigo,2) = Almacenes.Codigo " &
                "WHERE Ubicaciones.Codigo= ?", txtUbicacion.Text), 0, 0)

            Almacen = dsDatos("Almacen")
            lblUbicacionNombre.Text = dsDatos("UbicacionNombre")
            lblAlmacenNombre.Text = dsDatos("AlmacenNombre")

            MostrarFrames(False)
        Catch ex As Exception
            MostrarError($"Error al validar ubicación: {ex.Message}")
            txtUbicacion.Focus()
        End Try
    End Sub

    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrEmpty(txtUbicacion.Text) Then
            MessageBox.Show(MSG_UBICACION_REQUERIDA, TITULO_AVISO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtUbicacion.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub frmAsignar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load
        InicializarGrid()
    End Sub

    Private Sub InicializarGrid()
        ' Crear un nuevo DataTable y asignarlo como DataSource
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        Grid.DataSource = dt

    End Sub

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        lblArticuloNombre.Text = String.Empty
        txtArticulo.Text = String.Empty
        txtNuevoStock.Text = String.Empty
        If ActivarFoco Then
            txtArticulo.Focus()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        lblUbicacionNombre.Text = String.Empty
        lblAlmacenNombre.Text = String.Empty
        txtUbicacion.Text = String.Empty
        If ActivarFoco Then
            txtUbicacion.Focus()
        End If
    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        GroupControlArticulos.Visible = Not EsUbicacion
        Grid.Visible = Not EsUbicacion

        If EsUbicacion Then
            LimpiarUbicacion()
        Else
            LimpiarGrid()
            LimpiarArticulo()
        End If
    End Sub

    Private Sub LimpiarGrid()
        If Grid.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(Grid.DataSource, DataTable)
            dt.Rows.Clear()
        End If
    End Sub

    Private Sub txtArticulo_TextChanged(sender As Object, e As EventArgs) Handles txtArticulo.TextChanged
        If txtArticulo.Text = String.Empty Then
            Exit Sub
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionDeArticulo, txtArticulo.Text), 0, 0)
            lblArticuloNombre.Text = dsFila("NombreComercial")
        Catch ex As InvalidOperationException
            MostrarError(String.Format(MSG_ARTICULO_NO_EXISTE, txtArticulo.Text))
            txtArticulo.SelectAll()
            txtArticulo.Focus()
        Catch ex As Exception
            MostrarError(ex.Message)
            txtArticulo.SelectAll()
            txtArticulo.Focus()
        End Try
    End Sub

    Private Sub txtArticulo_Validating(sender As Object, e As CancelEventArgs) Handles txtArticulo.Validating
        If String.IsNullOrEmpty(txtArticulo.Text) Then
            e.Cancel = True
            Return
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery("SELECT NombreComercial, PorPeso FROM Articulos WHERE Codigo=?", txtArticulo.Text), 0, 0)
            lblArticuloNombre.Text = dsDatos("NombreComercial")
            lblPorPeso.Visible = dsDatos("PorPeso") = 1
            nDecUds = If(dsDatos("PorPeso") = 1, nDecUds, 0)
        Catch ex As InvalidOperationException
            MostrarError(ex.Message)
            e.Cancel = True
        Catch ex As Exception
            MostrarError(ex.Message)
            txtArticulo.Text = String.Empty
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtNuevoStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevoStock.KeyPress
        ' Campo numérico con decimales, no acepta letras
        Dim decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.First()

        If Not (Char.IsDigit(e.KeyChar) OrElse
           e.KeyChar = ChrW(Keys.Back) OrElse
           e.KeyChar = decimalSeparator) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs) Handles txtUbicacion.TextChanged
        If txtUbicacion.Text = String.Empty Then
            Exit Sub
        End If
        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionUbicacion, txtUbicacion.Text), 0, 0)
            lblUbicacionNombre.Text = dsFila("Nombre")
            lblAlmacenNombre.Text = dsFila("Almacen")
        Catch ex As InvalidOperationException
            MostrarError(String.Format(MSG_UBICACION_NO_EXISTE, txtUbicacion.Text))
            txtUbicacion.SelectAll()
            txtUbicacion.Focus()
        Catch ex As Exception
            MostrarError(ex.Message)
            txtUbicacion.SelectAll()
            txtUbicacion.Focus()
        End Try
    End Sub

    Private Sub txtUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles txtUbicacion.Validating
        If String.IsNullOrEmpty(txtUbicacion.Text) Then
            Return
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(ObtenerInformacionUbicacion, txtUbicacion.Text), 0, 0)

            If dsDatos("CodigoAlmacen") <> Configuracion.Almacen Then
                MessageBox.Show(
                    String.Format(MSG_ALMACEN_NO_COINCIDE, Configuracion.Almacen, dsDatos("CodigoAlmacen")),
                    TITULO_ADVERTENCIA,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation)
                e.Cancel = True
                Return
            End If

            Almacen = dsDatos("CodigoAlmacen")
            lblUbicacionNombre.Text = dsDatos("Nombre")
            lblAlmacenNombre.Text = dsDatos("Almacen")
        Catch ex As InvalidOperationException
            MostrarError(String.Format(MSG_UBICACION_NO_EXISTE, txtUbicacion.Text))
            txtUbicacion.Text = String.Empty
            e.Cancel = True
        Catch ex As Exception
            MostrarError(ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub MostrarError(mensaje As String)
        MessageBox.Show(mensaje, TITULO_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Debug.WriteLine($"Error: {mensaje}")
    End Sub

End Class