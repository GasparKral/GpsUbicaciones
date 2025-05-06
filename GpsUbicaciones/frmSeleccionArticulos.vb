Imports System.ComponentModel

Public Class frmSeleccionArticulos

    Private Articulos As BindingList(Of ProductoSeleccion)

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmSeleccionArticulos_Load() Handles MyBase.Load

        ' Inicializar el DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Ubicacion", GetType(String))
        dt.Columns.Add("Uds", GetType(Single))

        ' Asignar el DataTable al Grid
        GridControlArticulosSeleccionados.DataSource = dt


        Call LimpiarUbicacion(False)
        Call LimpiarArticulo(False)

        DatePicker.DateTime = Now
        DatePicker.Focus()

        ' Inicializar el DataTable
        GridPedidos.DataSource = Articulos

        If GridViewArticulosSeleccionados IsNot Nothing Then
            GridViewArticulosSeleccionados.Columns.Clear()
            ' Columna Articulo
            Dim colArticulo As New DevExpress.XtraGrid.Columns.GridColumn()
            colArticulo.FieldName = "CodigoUbicacion"
            colArticulo.Caption = "UBICACIÓN"
            colArticulo.Visible = True
            colArticulo.VisibleIndex = 0
            GridViewArticulosSeleccionados.Columns.Add(colArticulo)
            ' Columna Nombre
            Dim colNombre As New DevExpress.XtraGrid.Columns.GridColumn()
            colNombre.FieldName = "NombreComercial"
            colNombre.Caption = "ARTÍCULO"
            colNombre.Visible = True
            colNombre.VisibleIndex = 1
            GridViewArticulosSeleccionados.Columns.Add(colNombre)
            ' Columna Ubicacion
            Dim colUbicacion As New DevExpress.XtraGrid.Columns.GridColumn()
            colUbicacion.FieldName = "Destino"
            colUbicacion.Caption = "DESTINO"
            colUbicacion.Visible = True
            colUbicacion.VisibleIndex = 2
            GridViewArticulosSeleccionados.Columns.Add(colUbicacion)
            ' Columna Uds
            Dim colUds As New DevExpress.XtraGrid.Columns.GridColumn()
            colUds.FieldName = "Uds"
            colUds.Caption = "UDS"
            colUds.Visible = True
            colUds.VisibleIndex = 3
            GridViewArticulosSeleccionados.Columns.Add(colUds)
        End If

    End Sub

    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        If TextBoxCodigoUbicacion.Text = "" Then
            MessageFactory.ShowMessage(MessageType.Information, MissingLocationCodeMessage)
            TextBoxCodigoUbicacion.Focus()
            Exit Sub
        End If

        Dim Continuar As Boolean
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextBoxCodigoUbicacion.Text), 0, 0)

            LabelNombreUbicacion.Text = dsDatos("Nombre")
            LabelNombreAlmacen.Text = dsDatos("Almacen")
            Continuar = True
        Catch ex As InvalidOperationException
            MessageFactory.ShowMessage(MessageType.Information, ex.Message)
            Continuar = False
        End Try
        If Not Continuar Then
            TextBoxCodigoUbicacion.Focus()
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

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs)
        If TextBoxCodigoArticulo.Text = "" Then
            MessageFactory.ShowMessage(MessageType.Information, MissingArticleCodeMessage)
            TextBoxCodigoArticulo.Focus()
            Exit Sub
        End If
        If Not IsNumeric(TextBoxCantidadSeleccionada.Text) Then
            MessageFactory.ShowMessage(MessageType.Warning, NumericValueRequiredMessage)
            TextBoxCantidadSeleccionada.Focus()
            Exit Sub
        End If

        ' Grabar la asignación
        Operacion.ExecuteNonQuery(Querys.Insert.InsertarMovimientoVentaEnPDA, Terminal, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text, TextBoxCantidadSeleccionada.Text)

        Dim dt = CType(GridControlArticulosSeleccionados.DataSource, DataTable)
        Dim row = dt.NewRow
        row("Articulo") = TextBoxCodigoArticulo.Text
        row("Nombre") = LabelNombreArticulo.Text
        row("Ubicacion") = TextBoxCodigoUbicacion.Text
        row("Uds") = CInt(TextBoxCantidadSeleccionada.Text)
        dt.Rows.Add(row)

        LimpiarUbicacion()
    End Sub


    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoArticulo.Validating

        If TextBoxCodigoArticulo.Text = "" Then
            e.Cancel = True
            Exit Sub
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo, TextBoxCodigoArticulo.Text), 0, 0)
            LabelNombreArticulo.Text = dsDatos("NombreComercial")

            Dim dsDatos2 = Operacion.ExecuteQuery("SELECT Uds_Ini FROM StockLotes WHERE Articulo=? AND Lote=?", TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
            If dsDatos2.Tables(0).Rows.Count = 0 Then
                LabelStockArticulo.Text = "0"
            Else
                LabelStockArticulo.Text = dsDatos2.Tables(0).Rows(0).Item("Uds_Ini")
            End If
            dsDatos2.Dispose()
        Catch ex As Exception
            MessageFactory.ShowMessage(MessageType.Error, String.Format(UnexpectedErrorMessage, TextBoxCodigoArticulo.Text))
            e.Cancel = True
        End Try

    End Sub

    Private Sub DatePicker_Validated(sender As Object, e As EventArgs) Handles DatePicker.Validated
        ' cargar en gridpedidos la selección de pedidos
        Try
            Dim dsDatos = Operacion.ExecuteQuery("SELECT Articulo,Descripcion,Round(Sum(Cantidad)," & nDecUds & ") AS SumaUds FROM PedCli INNER JOIN MovPCl ON PedCli.Serie=MovPcl.Serie AND PedCli.Numero=MovPCl.Numero WHERE Fecha=#" & DatePicker.DateTime.ToString("MM-dd-yyyy") & "# AND Articulo<>'' GROUP BY Articulo,Descripcion")
            GridPedidos.DataSource = dsDatos
        Catch ex As Exception
            MessageFactory.ShowMessage(MessageType.Error, String.Format(UnexpectedErrorMessage, TextBoxCodigoArticulo.Text)
        End Try
    End Sub

    Private Sub frmSeleccionArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub datePicker_Validating(sender As Object, e As CancelEventArgs) Handles DatePicker.Validating
        ' Si no tiene valor no abandonar el control
        If DatePicker.DateTime = Nothing Then
            e.Cancel = True
        End If
    End Sub

    Private Sub datePicker_EditValueChanged(sender As Object, e As EventArgs) Handles DatePicker.EditValueChanged
        ' Dim dsDatos = Operacion.ExecuteQuery("ObtenerArticulosPorFecha", DatePicker.DateTime.ToString("MM-dd-yyyy"))
    End Sub
End Class