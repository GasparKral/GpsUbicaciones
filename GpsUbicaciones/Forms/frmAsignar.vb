Imports System.ComponentModel
Imports System.Globalization
Imports System.IO

Public Class frmAsignar
    Implements IDisposable

#Region "Operaciones de Grid"
    Private Sub ActualizarGridDespuesDeOperacion()
        Dim dt As DataTable = GridControlAsignacionArticulos.DataSource
        Dim row As DataRow = dt.NewRow()
        Dim info = RepositorioStockLote.ObtenerArticuloEnLote(TextEditItem.Text, TextEditLocation.Text)

        row("Ref") = info.Articulo.Codigo
        row("ItemName") = info.Articulo.NombreComercial
        row("Location") = info.Lote.Nombre
        row("TotalStock") = info.Articulo.StockTotal
        row("LocalStock") = info.Cantidad
        row("Asign") = SpinEditCantidad.Value

        ' Cargar la imagen como objeto Image
        Try
            If Not String.IsNullOrEmpty(info.Articulo.Foto) AndAlso File.Exists(info.Articulo.Foto) Then
                Dim imagen As Image = Image.FromFile(info.Articulo.Foto)
                row("Image") = imagen
            Else
                row("Image") = My.Resources.Resources.NoImage ' Tu imagen por defecto
            End If
        Catch ex As Exception
            row("Image") = My.Resources.Resources.NoImage
        End Try

        dt.Rows.Add(row)
        GridControlAsignacionArticulos.Visible = True
    End Sub

#End Region

#Region "Eventos de Formulario"
    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.AutoValidate = AutoValidate.EnableAllowFocusChange
        Dim dt As New DataTable()
        ' Los nombres deben coincidir con los FieldName del designer
        dt.Columns.Add("Ref", GetType(String))
        dt.Columns.Add("ItemName", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("TotalStock", GetType(String))
        dt.Columns.Add("LocalStock", GetType(Single))
        dt.Columns.Add("Asign", GetType(Single))
        dt.Columns.Add("Image")

        GridControlAsignacionArticulos.DataSource = dt
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
        If String.IsNullOrEmpty(TextEditItem.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesArticulos.CodigoFaltante)
            TextEditItem.Focus()
            Return False
        End If

        Dim stock As Single
        If Not Single.TryParse(SpinEditCantidad.Text, NumberStyles.Any, CultureInfo.InvariantCulture, stock) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesGenerales.ValorNumericoRequerido)
            SpinEditCantidad.Focus()
            Return False
        End If

        If stock = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesStock.CantidadInvalida)
            SpinEditCantidad.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function ValidarUbicacion() As Boolean
        If String.IsNullOrEmpty(TextEditLocation.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesUbicaciones.CodigoFaltante)
            TextEditLocation.Focus()
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Control de UI"


    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        TextEditItem.Clear()
        SpinEditCantidad.Clear()
        IconWeigth.Visible = False
        LabelTotalStock.Text = String.Empty
        If ActivarFoco Then
            PermitirEdicion(TextEditItem, True)
            TextEditItem.Select()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        TextEditLocation.Clear()
        If ActivarFoco Then
            PermitirEdicion(TextEditLocation, True)
            TextEditLocation.Select()
        End If
    End Sub

#End Region

#Region "Carga de Datos"
    Private Sub CargarStockLote(e As CancelEventArgs)
        Try
            Dim stockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextEditItem.Text, TextEditLocation.Text)

            If stockLote Is Nothing Then
                e.Cancel = True
                Exit Sub
            End If

            LabelNombreArticulo.Text = stockLote.Articulo.NombreComercial
            LabelTotalStock.Text = stockLote.Articulo.StockTotal
            LabelLocalStock.Text = stockLote.Cantidad

            AceptarDecimales(SpinEditCantidad, stockLote.Articulo.PorPeso, IconWeigth)

        Catch ex As InvalidOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, ex.Message)
            TextEditItem.SelectAll()
            TextEditItem.Focus()

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.CodigoInvalido, TextEditItem.Text))
            TextEditItem.SelectAll()
            TextEditItem.Focus()

        End Try
    End Sub

    Private Sub CargarDatosUbicacion(esValidacion As Boolean, Optional e As CancelEventArgs = Nothing)
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextEditLocation.Text, Almacen), 0, 0)

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

        Catch ex As InvalidOperationException
            FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, ex.Message)
            TextEditLocation.SelectAll()
            TextEditLocation.Focus()
            If esValidacion Then
                TextEditLocation.Text = String.Empty
                If e IsNot Nothing Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Dim mensaje = If(esValidacion, ex.Message, String.Format(MensajesGenerales.SinDatos, TextEditItem.Text))
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, mensaje)
            TextEditLocation.SelectAll()
            TextEditLocation.Focus()
            If esValidacion AndAlso e IsNot Nothing Then
                e.Cancel = True
            End If
        End Try
    End Sub

    Private Sub actualizarCampoStock()
        Try
            If String.IsNullOrEmpty(TextEditItem.Text) OrElse String.IsNullOrEmpty(TextEditLocation.Text) Then
                Exit Sub
            End If

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarStockDeLote, TextEditLocation.Text, TextEditItem.Text), 0, 0)

            If dsFila Is Nothing OrElse dsFila("Stock") Is DBNull.Value Then
                SpinEditCantidad.Text = "0"
                Return
            End If

            Dim stock As Integer
            If Integer.TryParse(dsFila("Stock").ToString(), stock) Then
                SpinEditCantidad.Text = stock.ToString()
            Else
                SpinEditCantidad.Text = "0"
            End If
        Catch ex As Exception
            SpinEditCantidad.Text = "0"
        End Try
    End Sub
#End Region

#Region "Eventos de Controles"

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
                        RepositorioStockLote.AgregarStock(con, SpinEditCantidad.Value, TextEditItem.Text, TextEditLocation.Text)
                    End Sub

                Dim ifFalseAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.InsertarArticulo(con, SpinEditCantidad.Value, TextEditItem.Text, TextEditLocation.Text)
                    End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
                    Querys.Select.VerificarExistenciaLoteDeArticulo,
                    ifTrueAction,
                    ifFalseAction,
                    RepositorioArticulo.ObtenerInformacion(TextEditItem.Text).Codigo, TextEditLocation.Text
                )

                ' Si todo fue bien, actualizar la interfaz
                If success Then
                    ActualizarGridDespuesDeOperacion()
                    Operacion.ExecuteNonQuery("INSERT INTO LINTRASPLOTES VALUES(?,?,?,NULL,?)", Date.Now, RepositorioArticulo.ObtenerInformacion(TextEditItem.Text).Codigo, SpinEditCantidad.Value, TextEditLocation.Text)
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
            Using frm As New frmConsulta
                frm.LabelUbicaciónConsultada.Text = LabelNombreUbicacion.Text
                frm.Source = RepositorioStockLote.ObtenerArticulosEnLote(TextEditLocation.Text)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.ErrorConsulta, ex.Message))
        End Try
    End Sub

    Private Sub btnNuevaUbicacion_Click() Handles ButtonResetForm.Click
        TextEditLocation.Clear()
        TextEditItem.Clear()
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreArticulo.Text = String.Empty
        IconWeigth.Visible = False
        SpinEditCantidad.Value = 0
        LabelLocalStock.Text = "0000"
        LabelTotalStock.Text = "0000"

        PermitirEdicion(SpinEditCantidad, False)
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(TextEditLocation, True)
        PermitirEdicion(ButtonConfirmacionArticulo, False)
        PermitirEdicion(ButtonConsultarUbicacion, False)
        PermitirEdicion(ButtonResetForm, False)
    End Sub

    ''' <summary>
    ''' Valida el código de artículo cuando el usuario termina de editarlo
    ''' Se ejecuta al perder el foco o al presionar Tab/Enter
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextEditItem.Validating
        ' Si el campo está vacío, cancelar la validación pero no mostrar error
        ' (el error se mostrará cuando el usuario intente confirmar)
        If String.IsNullOrEmpty(TextEditItem.Text.Trim) Then
            ' Limpiar datos relacionados
            LabelNombreArticulo.Text = String.Empty
            IconWeigth.Visible = False
            SpinEditCantidad.Text = "0"
            Return
        End If

        ' Cargar datos del artículo y actualizar stock
        CargarStockLote(e)

        ' Solo actualizar stock si la validación del artículo fue exitosa
        If e.Cancel <> True Then
            actualizarCampoStock()
            PermitirEdicion(SpinEditCantidad, True)
        End If
    End Sub

    ''' <summary>
    ''' Valida el código de ubicación cuando el usuario termina de editarlo
    ''' Se ejecuta al perder el foco o al presionar Tab/Enter
    ''' </summary>
    Private Sub TextBoxCodigoUbicacion_Validating(sender As Object, e As CancelEventArgs)
        ' Si el campo está vacío, no hacer nada (se permite)
        If String.IsNullOrEmpty(TextEditLocation.Text.Trim) Then
            ' Limpiar datos relacionados
            LabelNombreUbicacion.Text = String.Empty
            Return
        End If

        ' Cargar datos de la ubicación
        CargarDatosUbicacion(True, e)
        ' Si la validación de ubicación fue exitosa y hay un artículo seleccionado,
        ' actualizar el stock
        If e.Cancel <> True Then
            actualizarCampoStock()
            PermitirEdicion(ButtonConsultarUbicacion, True, False)
            PermitirEdicion(TextEditItem, True)
        End If
    End Sub

    Private Sub LabelStockTotal_Click(sender As Object, e As EventArgs) Handles LabelTotalStock.Click
        If LabelTotalStock.Text = "" Then Exit Sub
        SpinEditCantidad.Value = CType(LabelTotalStock.Text, Single)
    End Sub

    Private Sub SpinEditCantidad_Validating(sender As Object, e As CancelEventArgs) Handles SpinEditCantidad.Validating
        If SpinEditCantidad.Value = 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "La cantidad debe ser mayor a 0")
            e.Cancel = True
            SpinEditCantidad.Focus()
            Exit Sub
        End If

        Dim stockTotal = RepositorioStockLote.ObtenerArticuloEnLote(TextEditItem.Text, TextEditLocation.Text)
        If (SpinEditCantidad.Value + stockTotal.Cantidad) > stockTotal.Articulo.StockTotal Then
            ' Alert sobre la disconformidad y pedir confirmación
            Dim confirmacion = MessageBox.Show("La cantidad total de lotes excede el stock disponible. ¿Desea continuar de todos modos?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If confirmacion <> DialogResult.OK Then
                PermitirEdicion(ButtonResetForm, False)
                PermitirEdicion(ButtonConfirmacionArticulo, False)
                e.Cancel = True
                SpinEditCantidad.Focus()
                Exit Sub
            End If

        End If

        ' Activar botones
        PermitirEdicion(ButtonResetForm, True, False)
        PermitirEdicion(ButtonConfirmacionArticulo, True)

    End Sub

    Private Sub LabelTotalStock_Click(sender As Object, e As EventArgs) Handles LabelTotalStock.Click
        Dim stockValue As Single
        If Single.TryParse(LabelTotalStock.Text, stockValue) AndAlso stockValue >= 0 Then
            SpinEditCantidad.Value = stockValue
        Else
            Exit Sub
        End If
    End Sub

#End Region

End Class