Imports System.ComponentModel
Imports System.Globalization

Public Class frmAsignar
    Implements IDisposable

#Region "Operaciones de Grid"
    Private Sub ActualizarGridDespuesDeOperacion(stock As Single)
        Dim dt As DataTable = GridControlAsignacionArticulos.DataSource
        Dim row As DataRow = dt.NewRow()

        ' Usa los FieldName en lugar de los nombres de columna
        row("Item") = $"{TextBoxCodigoArticulo.Text}{vbTab}{LabelNombreArticulo.Text}"
        row("Location") = TextBoxCodigoUbicacion.Text
        row("TotalStock") = LabelTotalStock.Text
        row("LocalStock") = stock

        dt.Rows.Add(row)
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
        Me.AutoValidate = AutoValidate.EnableAllowFocusChange
        Dim dt As New DataTable()
        ' Los nombres deben coincidir con los FieldName del designer
        dt.Columns.Add("Item", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        dt.Columns.Add("TotalStock", GetType(String))
        dt.Columns.Add("LocalStock", GetType(Single))

        GridControlAsignacionArticulos.DataSource = dt
        SpinEditCantidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        SpinEditCantidad.Properties.LookAndFeel.SetSkinStyle("WXI")
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
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesUbicaciones.CodigoFaltante)
            TextBoxCodigoUbicacion.Focus()
            Return False
        End If
        Return True
    End Function
#End Region

#Region "Control de UI"


    Private Sub LimpiarArticulo(Optional ActivarFoco As Boolean = True)
        LabelNombreArticulo.Text = String.Empty
        TextBoxCodigoArticulo.Clear()
        SpinEditCantidad.Clear()
        IconWeigth.Visible = False
        LabelTotalStock.Text = String.Empty
        If ActivarFoco Then
            PermitirEdicion(TextBoxCodigoArticulo, True)
            TextBoxCodigoArticulo.Select()
        End If
    End Sub

    Private Sub LimpiarUbicacion(Optional ActivarFoco As Boolean = True)
        LabelNombreUbicacion.Text = String.Empty
        TextBoxCodigoUbicacion.Clear()
        If ActivarFoco Then
            PermitirEdicion(TextBoxCodigoUbicacion, True)
            TextBoxCodigoUbicacion.Select()
        End If
    End Sub

#End Region

#Region "Carga de Datos"
    Private Sub CargarStockLote(e As CancelEventArgs)
        Try
            Dim stockLote = RepositorioStockLote.ObtenerArticuloEnLote(TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)

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
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()

        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.CodigoInvalido, TextBoxCodigoArticulo.Text))
            TextBoxCodigoArticulo.SelectAll()
            TextBoxCodigoArticulo.Focus()

        End Try
    End Sub

    Private Sub CargarDatosUbicacion(esValidacion As Boolean, Optional e As CancelEventArgs = Nothing)
        Try
            Dim dsDatos = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, TextBoxCodigoUbicacion.Text, Almacen), 0, 0)

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

            Dim dsFila = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarStockDeLote, TextBoxCodigoUbicacion.Text, TextBoxCodigoArticulo.Text), 0, 0)

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
    Private Sub BotonConfirmacionDeUbicacion_Click(sender As Object, e As EventArgs)
        If Not ValidarUbicacion() Then
            Exit Sub
        End If

        Try
            Dim ubicacion = RepositorioUbicacion.ObtenerInformacion(TextBoxCodigoUbicacion.Text)

            LabelNombreUbicacion.Text = ubicacion.Nombre


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
                        RepositorioStockLote.AgregarStock(con, SpinEditCantidad.Value, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
                    End Sub

                Dim ifFalseAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.InsertarArticulo(con, SpinEditCantidad.Value, TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
                    End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
                    Querys.Select.VerificarExistenciaLoteDeArticulo,
                    ifTrueAction,
                    ifFalseAction,
                    RepositorioArticulo.ObtenerInformacion(TextBoxCodigoArticulo.Text).Codigo, TextBoxCodigoUbicacion.Text
                )

                ' Si todo fue bien, actualizar la interfaz
                If success Then
                    ActualizarGridDespuesDeOperacion(SpinEditCantidad.Value)
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
                frm.Source = RepositorioStockLote.ObtenerArticulosEnLote(TextBoxCodigoUbicacion.Text)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, String.Format(MensajesArticulos.ErrorConsulta, ex.Message))
        End Try
    End Sub

    Private Sub btnNuevaUbicacion_Click() Handles btnNuevaUbicacion.Click
        TextBoxCodigoUbicacion.Clear()
        TextBoxCodigoArticulo.Clear()
        LabelNombreUbicacion.Text = String.Empty
        LabelNombreArticulo.Text = String.Empty
        IconWeigth.Visible = False
        SpinEditCantidad.Value = 0
        LabelLocalStock.Text = "0000"
        LabelTotalStock.Text = "0000"

        PermitirEdicion(SpinEditCantidad, False)
        PermitirEdicion(TextBoxCodigoArticulo, False)
        PermitirEdicion(TextBoxCodigoUbicacion, True)
    End Sub

    ''' <summary>
    ''' Valida el código de artículo cuando el usuario termina de editarlo
    ''' Se ejecuta al perder el foco o al presionar Tab/Enter
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoArticulo.Validating
        ' Si el campo está vacío, cancelar la validación pero no mostrar error
        ' (el error se mostrará cuando el usuario intente confirmar)
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text.Trim) Then
            ' Limpiar datos relacionados
            LabelNombreArticulo.Text = String.Empty
            IconWeigth.Visible = False
            SpinEditCantidad.Text = "0"
            Return
        End If

        ' Cargar datos del artículo y actualizar stock
        CargarStockLote(e)
        PermitirEdicion(SpinEditCantidad, True)

        ' Solo actualizar stock si la validación del artículo fue exitosa
        If Not e.Cancel Then
            actualizarCampoStock()
        End If
    End Sub

    ''' <summary>
    ''' Valida el código de ubicación cuando el usuario termina de editarlo
    ''' Se ejecuta al perder el foco o al presionar Tab/Enter
    ''' </summary>
    Private Sub TextBoxCodigoUbicacion_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxCodigoUbicacion.Validating
        ' Si el campo está vacío, no hacer nada (se permite)
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text.Trim) Then
            ' Limpiar datos relacionados
            LabelNombreUbicacion.Text = String.Empty
            Return
        End If

        ' Cargar datos de la ubicación
        CargarDatosUbicacion(True, e)
        PermitirEdicion(ButtonConsultarUbicacion, True, False)
        PermitirEdicion(TextBoxCodigoArticulo, True)

        ' Si la validación de ubicación fue exitosa y hay un artículo seleccionado,
        ' actualizar el stock
        If Not e.Cancel AndAlso Not String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            actualizarCampoStock()
        End If
    End Sub

    ''' <summary>
    ''' Evento opcional para limpiar datos cuando el usuario borra el contenido
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_TextChanged(sender As Object, e As EventArgs)
        ' Solo limpiar si el campo queda completamente vacío
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            LabelNombreArticulo.Text = String.Empty
            IconWeigth.Visible = False
            SpinEditCantidad.Text = "0"
        End If
    End Sub

    ''' <summary>
    ''' Evento opcional para limpiar datos cuando el usuario borra el contenido de ubicación
    ''' </summary>
    Private Sub TextBoxCodigoUbicacion_TextChanged(sender As Object, e As EventArgs)
        ' Solo limpiar si el campo queda completamente vacío
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            LabelNombreUbicacion.Text = String.Empty
        End If
    End Sub

    Private Sub LabelStockTotal_Click(sender As Object, e As EventArgs)
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

        Dim stockTotal = RepositorioStockLote.ObtenerArticuloEnLote(TextBoxCodigoArticulo.Text, TextBoxCodigoUbicacion.Text)
        If (SpinEditCantidad.Value + stockTotal.Cantidad) > stockTotal.Articulo.StockTotal Then
            ' Alert sobre la disconformidad y pedir confirmación
            Dim confirmacion = MessageBox.Show("La cantidad total de lotes excede el stock disponible. ¿Desea continuar de todos modos?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If confirmacion <> DialogResult.OK Then
                PermitirEdicion(btnNuevaUbicacion, False)
                PermitirEdicion(ButtonConfirmacionArticulo, False)
                e.Cancel = True
                SpinEditCantidad.Focus()
                Exit Sub
            End If

        End If

        ' Activar botones
        PermitirEdicion(btnNuevaUbicacion, True, False)
        PermitirEdicion(ButtonConfirmacionArticulo, True)

        ' Actualizar stock

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