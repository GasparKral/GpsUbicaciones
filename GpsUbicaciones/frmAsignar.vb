Imports System.ComponentModel
Imports System.Globalization

Public Class frmAsignar
    Implements IDisposable

    ' Métodos principales
    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles btnArticulo.Click
        ' Validaciones iniciales
        If Not ValidarDatosArticulo() Then
            Return
        End If

        ' Usar la transacción condicional
        Try
            Using nestedTx As New NestedConditionalTransaction(Operacion)
                Dim stock As Single = Single.Parse(TextBoxStockArticulo.Text, CultureInfo.InvariantCulture)

                ' Definir acciones para cada caso
                Dim ifTrueAction As Action(Of IDbConnection) = Sub(con)
                                                                   ' Caso cuando ya existe el registro (UPDATE)
                                                                   Operacion.ExecuteNonQuery(con, Querys.Update.ActualizarCantidadStockDeLote(), stock, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
                                                               End Sub

                Dim ifFalseAction As Action(Of IDbConnection) = Sub(con)
                                                                    ' Caso cuando no existe el registro (INSERT)
                                                                    Operacion.ExecuteNonQuery(con, Querys.Insert.InsertarNuevoLoteDeArticuloEnStock(), Almacen, TextBoxCodigoUbicacion.Text, TextBoxCodigoArticulo.Text, stock)
                                                                End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
                    Querys.Select.VerificarExistenciaLoteDeArticulo,
                    ifTrueAction,
                    ifFalseAction,
                    TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text
                )

                ' Si todo fue bien, actualizar la interfaz
                If success Then
                    ActualizarGridDespuesDeOperacion(stock)
                    LimpiarArticulo()
                End If
            End Using
        Catch ex As DatabaseOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeErrorOperacionBD, ex.Message))
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeSinDatos, ex.Message))
        End Try
    End Sub

    Private Function ValidarDatosArticulo() As Boolean
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            FabricaMensajes.ShowMessage(TipoMensaje.Advertencia, MensajeCodigoArticuloFaltante)
            TextBoxCodigoArticulo.Focus()
            Return False
        End If

        Dim stock As Single
        If Not Single.TryParse(TextBoxStockArticulo.Text, NumberStyles.Any, CultureInfo.InvariantCulture, stock) Then
            FabricaMensajes.ShowMessage(TipoMensaje.Advertencia, MensajeValorNumericoRequerido)
            TextBoxStockArticulo.Focus()
            Return False
        End If

        If stock = 0 Then
            FabricaMensajes.ShowMessage(TipoMensaje.Advertencia, MensajeCantidadInvalida)
            TextBoxStockArticulo.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ActualizarGridDespuesDeOperacion(stock As Single)
        Dim dt As DataTable = CType(GridControlAsignacionArticulos.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = $"{TextBoxCodigoArticulo.Text}{vbTab}{LabelNombreArticulo.Text}"
        row("Cantidad") = stock
        dt.Rows.Add(row)
    End Sub

    Private Sub btnConsultaArtUbiacion_Click(sender As Object, e As EventArgs) Handles btnConsultaArtUbiacion.Click
        Try
            Using frm As New frmConsulta()
                frm.Consulta = $"SELECT Articulo, NombreComercial AS Nombre, Round(Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven, {nDecUds}) AS Stock " &
                               $"FROM StockLotes INNER JOIN Articulos ON StockLotes.Articulo=Articulos.Codigo " &
                               $"WHERE Almacen='{Almacen}' AND StockLotes.Lote='{TextBoxCodigoUbicacion.Text}'"
                frm.lblTitulo.Text = $"Artículos en ubicación: {TextBoxCodigoUbicacion.Text}"
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeErrorConsultaArticulos, ex.Message))
        End Try
    End Sub

    Private Sub btnNuevaUbicacion_Click(sender As Object, e As EventArgs) Handles btnNuevaUbicacion.Click
        LimpiarArticulo(False)
        MostrarFrames(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BotonConfirmacionDeUbicacion_Click(sender As Object, e As EventArgs) Handles BotonConfirmacionDeUbicacion.Click
        If Not ValidarUbicacion() Then
            Exit Sub
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo(), TextBoxCodigoUbicacion.Text), 0, 0)

            LabelNombreUbicacion.Text = dsDatos("Nombre")
            LabelNombreAlmacen.Text = dsDatos("Almacen")

            MostrarFrames(False)
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeErrorValidacionUbicacion, ex.Message))
            TextBoxCodigoUbicacion.Focus()
        End Try
    End Sub

    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            FabricaMensajes.ShowMessage(TipoMensaje.Advertencia, MensajeCodigoUbicacionFaltante)
            TextBoxCodigoUbicacion.Focus()
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
        GridControlAsignacionArticulos.DataSource = dt

    End Sub

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        TextBoxCodigoArticulo.Text = String.Empty
        TextBoxStockArticulo.Text = String.Empty
        If ActivarFoco Then
            TextBoxCodigoArticulo.Focus()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreAlmacen.Text = String.Empty
        TextBoxCodigoUbicacion.Text = String.Empty
        If ActivarFoco Then
            TextBoxCodigoUbicacion.Focus()
        End If
    End Sub

    Private Sub MostrarFrames(EsUbicacion As Boolean)
        GroupControlUbicacion.Enabled = EsUbicacion
        GroupControlArticulos.Visible = Not EsUbicacion
        GridControlAsignacionArticulos.Visible = Not EsUbicacion

        If EsUbicacion Then
            LimpiarUbicacion()
        Else
            LimpiarGrid()
            LimpiarArticulo()
        End If
    End Sub

    Private Sub LimpiarGrid()
        If GridControlAsignacionArticulos.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(GridControlAsignacionArticulos.DataSource, DataTable)
            dt.Rows.Clear()
        End If
    End Sub

    Private Sub txtArticulo_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCodigoArticulo.TextChanged
        If TextBoxCodigoArticulo.Text = String.Empty Then
            Exit Sub
        End If

        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo, TextBoxCodigoArticulo.Text), 0, 0)
            LabelNombreArticulo.Text = dsFila("NombreComercial")
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeSinDatos, TextBoxCodigoArticulo.Text))
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()
        End Try
    End Sub

    Private Sub txtArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoArticulo.Validating
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            e.Cancel = True
            Return
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo, TextBoxCodigoArticulo.Text), 0, 0)
            LabelNombreArticulo.Text = dsDatos("NombreComercial")
            lblPorPeso.Visible = dsDatos("PorPeso") = 1
            nDecUds = If(dsDatos("PorPeso") = 1, nDecUds, 0)
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, ex.Message)
            e.Cancel = True
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeSinDatos, TextBoxCodigoArticulo.Text))
            TextBoxCodigoArticulo.Text = String.Empty
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtNuevoStock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxStockArticulo.KeyPress
        ' Campo numérico con decimales, no acepta letras
        Dim decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.First()

        If Not (Char.IsDigit(e.KeyChar) OrElse
           e.KeyChar = ChrW(Keys.Back) OrElse
           e.KeyChar = decimalSeparator) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUbicacion_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCodigoUbicacion.TextChanged
        If TextBoxCodigoUbicacion.Text = String.Empty Then
            Exit Sub
        End If
        Try
            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextBoxCodigoUbicacion.Text), 0, 0)
            LabelNombreUbicacion.Text = dsFila("Nombre")
            LabelNombreAlmacen.Text = dsFila("Almacen")
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoUbicacion.SelectAll()
            TextBoxCodigoUbicacion.Focus()
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, String.Format(MensajeSinDatos, TextBoxCodigoArticulo.Text))
            TextBoxCodigoUbicacion.SelectAll()
            TextBoxCodigoUbicacion.Focus()
        End Try
    End Sub

    Private Sub txtUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoUbicacion.Validating
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            Return
        End If

        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextBoxCodigoUbicacion.Text), 0, 0)

            If dsDatos("CodigoAlmacen") <> Configuracion.Almacen Then
                FabricaMensajes.ShowMessage(TipoMensaje.Informacion, String.Format(MensajeAlmacenNoCoincide, Configuracion.Almacen, dsDatos("CodigoAlmacen")))
                e.Cancel = True
                Return
            End If

            Almacen = dsDatos("CodigoAlmacen")
            LabelNombreUbicacion.Text = dsDatos("Nombre")
            LabelNombreAlmacen.Text = dsDatos("Almacen")
        Catch ex As InvalidOperationException
            FabricaMensajes.ShowMessage(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoUbicacion.Text = String.Empty
            e.Cancel = True
        Catch ex As Exception
            FabricaMensajes.ShowMessage(TipoMensaje.Error, ex.Message)
            e.Cancel = True
        End Try
    End Sub


End Class