Imports System.ComponentModel
Imports System.Globalization
Imports DevExpress.XtraEditors

Public Class frmAsignar
    Implements IDisposable

#Region "Operaciones de Grid"
    Private Sub ActualizarGridDespuesDeOperacion(stock As Single)
        Dim dt As DataTable = CType(GridControlAsignacionArticulos.DataSource, DataTable)
        Dim row As DataRow = dt.NewRow()
        row("Articulo") = $"{TextBoxCodigoArticulo.Text}{vbTab}{LabelNombreArticulo.Text}"
        row("Cantidad") = stock
        dt.Rows.Add(row)
    End Sub

    Private Sub InicializarGrid()
        ' Crear un nuevo DataTable y asignarlo como DataSource
        Dim dt As New DataTable()
        dt.Columns.Add("Articulo", GetType(String))
        dt.Columns.Add("Cantidad", GetType(Decimal))
        GridControlAsignacionArticulos.DataSource = dt
    End Sub

    Private Sub LimpiarGrid()
        If GridControlAsignacionArticulos.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(GridControlAsignacionArticulos.DataSource, DataTable)
            dt.Rows.Clear()
        End If
    End Sub
#End Region

#Region "Eventos de Formulario"
    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load
        InicializarGrid()
    End Sub

    Private Sub frmAsignar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Al pulsar enter salte al siguiente control
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Validación de Campos"
    Private Function ValidarDatosArticulo() As Boolean
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.CodigoFaltante)
            TextBoxCodigoArticulo.Focus()
            Return False
        End If

        Dim stock As Single
        If Not Single.TryParse(SpinEditStock.Text, NumberStyles.Any, CultureInfo.InvariantCulture, stock) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesGenerales.ValorNumericoRequerido)
            SpinEditStock.Focus()
            Return False
        End If

        If stock = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
            SpinEditStock.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesUbicaciones.CodigoFaltante)
            TextBoxCodigoUbicacion.Focus()
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Control de UI"
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

    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        TextBoxCodigoArticulo.Clear()
        SpinEditStock.Clear()
        LabelIndicadorPorPeso.Visible = False
        If ActivarFoco Then
            PermitirEdicion(TextBoxCodigoArticulo, True)
            TextBoxCodigoArticulo.Select()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreAlmacen.Text = String.Empty
        TextBoxCodigoUbicacion.Clear()
        If ActivarFoco Then
            PermitirEdicion(TextBoxCodigoUbicacion, True)
            TextBoxCodigoUbicacion.Select()
        End If
    End Sub

    Private Sub PermitirEdicion(campo As Control, estado As Boolean)
        campo.Enabled = estado
    End Sub

    Private Sub AceptarDecimales(Control As SpinEdit, Valor As Boolean)
        Control.Properties.Mask.UseMaskAsDisplayFormat = True
        If Valor Then
            Control.Properties.IsFloatValue = True
            Control.Properties.EditMask = $"N{nDecUds}"
            Control.Properties.Increment = 0.1
            LabelIndicadorPorPeso.Visible = True
        Else
            Control.Properties.IsFloatValue = False
            Control.Properties.EditMask = "d"
            Control.Properties.Increment = 1
            LabelIndicadorPorPeso.Visible = False
        End If
    End Sub
#End Region

#Region "Carga de Datos"
    Private Sub CargarDatosArticulo(esValidacion As Boolean, Optional e As CancelEventArgs = Nothing)
        Try
            Dim Articulo = RepositorioArticulo.ObtenerInFormacion(TextBoxCodigoArticulo.Text)
            LabelNombreArticulo.Text = Articulo.NombreComercial

            If esValidacion Then
                LabelIndicadorPorPeso.Visible = Articulo.PorPeso
                AceptarDecimales(SpinEditStock, Articulo.PorPeso)
            End If
        Catch ex As InvalidOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()
            If esValidacion AndAlso e IsNot Nothing Then
                e.Cancel = True
            End If
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.CodigoInvalido, TextBoxCodigoArticulo.Text))
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()
            If esValidacion Then
                TextBoxCodigoArticulo.Text = String.Empty
                If e IsNot Nothing Then
                    e.Cancel = True
                End If
            End If
        End Try
    End Sub

    Private Sub CargarDatosUbicacion(esValidacion As Boolean, Optional e As CancelEventArgs = Nothing)
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextBoxCodigoUbicacion.Text), 0, 0)

            If esValidacion Then
                If dsDatos("CodigoAlmacen") <> Configuracion.Almacen Then
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, String.Format(MensajesUbicaciones.AlmacenNoCoincide, Configuracion.Almacen, dsDatos("CodigoAlmacen")))
                    If e IsNot Nothing Then
                        e.Cancel = True
                    End If
                    Return
                End If
                Almacen = dsDatos("CodigoAlmacen")
            End If

            LabelNombreUbicacion.Text = dsDatos("Nombre")
            LabelNombreAlmacen.Text = dsDatos("Almacen")
        Catch ex As InvalidOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, ex.Message)
            TextBoxCodigoUbicacion.SelectAll()
            TextBoxCodigoUbicacion.Focus()
            If esValidacion Then
                TextBoxCodigoUbicacion.Text = String.Empty
                If e IsNot Nothing Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Dim mensaje = If(esValidacion, ex.Message, String.Format(MensajesGenerales.SinDatos, TextBoxCodigoArticulo.Text))
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, mensaje)
            TextBoxCodigoUbicacion.SelectAll()
            TextBoxCodigoUbicacion.Focus()
            If esValidacion AndAlso e IsNot Nothing Then
                e.Cancel = True
            End If
        End Try
    End Sub

    Private Sub actualizarCampoStock()
        Try
            If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) OrElse String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarStockDeLote,
                              TextBoxCodigoArticulo.Text,
                              TextBoxCodigoUbicacion.Text), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                SpinEditStock.Text = "0"
                Return
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                SpinEditStock.Text = stock.ToString()
            Else
                SpinEditStock.Text = "0"
            End If
        Catch ex As Exception
            SpinEditStock.Text = "0"
        End Try
    End Sub
#End Region

#Region "Eventos de Controles"
    Private Sub BotonConfirmacionDeUbicacion_Click(sender As Object, e As EventArgs) Handles BotonConfirmacionDeUbicacion.Click
        If Not ValidarUbicacion() Then
            Exit Sub
        End If

        Try
            Dim ubicacion = RepositorioUbicacion.ObtenerInformacion(TextBoxCodigoUbicacion.Text)

            LabelNombreUbicacion.Text = ubicacion.Nombre
            LabelNombreAlmacen.Text = ubicacion.NombreAlmacen

            MostrarFrames(False)
        Catch ex As InvalidOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesUbicaciones.ErrorValidacion, ex.Message))
            TextBoxCodigoUbicacion.Focus()
        End Try
    End Sub

    Private Sub ButtonConfirmacionArticulo_Click(sender As Object, e As EventArgs) Handles ButtonConfirmacionArticulo.Click
        ' Validaciones iniciales
        If Not ValidarDatosArticulo() Then
            Exit Sub
        End If

        ' Usar la transacción condicional
        Try
            Using nestedTx As New NestedConditionalTransaction(Operacion)

                ' Definir acciones para cada caso
                Dim ifTrueAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.MoverStock(con, SpinEditStock.Value, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
                    End Sub

                Dim ifFalseAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.InsertarArticulo(con, SpinEditStock.Value, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text, Almacen)
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
                    ActualizarGridDespuesDeOperacion(SpinEditStock.Value)
                    LimpiarArticulo()
                End If
            End Using
        Catch ex As DatabaseOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesGenerales.ErrorOperacionBD, ex.Message))
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesGenerales.SinDatos, ex.Message))
        End Try
    End Sub

    Private Sub ButtonConsultarUbicacion_Click(sender As Object, e As EventArgs) Handles ButtonConsultarUbicacion.Click
        Try
            Using frm As New frmConsulta()
                frm.LabelUbicaciónConsultada.Text = LabelNombreUbicacion.Text
                frm.Source = RepositorioStockLote.ObtenerArticulosEnLote(TextBoxCodigoUbicacion.Text)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.ErrorConsulta, ex.Message))
        End Try
    End Sub

    Private Sub btnNuevaUbicacion_Click(sender As Object, e As EventArgs) Handles btnNuevaUbicacion.Click
        ' Deshabilitar validación temporalmente
        Me.AutoValidate = AutoValidate.Disable

        LimpiarArticulo(False)
        MostrarFrames(True)

        ' Volver a habilitar la validación
        Me.AutoValidate = AutoValidate.EnableAllowFocusChange
    End Sub


    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoArticulo.Validating
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            e.Cancel = True
            Return
        End If

        CargarDatosArticulo(True, e)
        actualizarCampoStock()
    End Sub

    Private Sub TextBoxCodigoUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoUbicacion.Validating
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            Return
        End If

        CargarDatosUbicacion(True, e)
    End Sub
#End Region

End Class