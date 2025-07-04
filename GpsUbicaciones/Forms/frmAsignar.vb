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
        row("TotalStock") = LabelStockTotal.Text
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
        SpinEditCantidad.Clear()
        LabelIndicadorPorPeso.Visible = False
        LabelStockTotal.Text = String.Empty
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

#End Region

#Region "Carga de Datos"
    Private Sub CargarDatosArticulo(esValidacion As Boolean, Optional e As CancelEventArgs = Nothing)
        Try
            Dim Articulo = RepositorioArticulo.ObtenerInformacion(TextBoxCodigoArticulo.Text)
            LabelNombreArticulo.Text = Articulo.NombreComercial
            LabelStockTotal.Text = Articulo.StockTotal
            If esValidacion Then
                LabelIndicadorPorPeso.Visible = Articulo.PorPeso
                AceptarDecimales(SpinEditCantidad, Articulo.PorPeso, LabelIndicadorPorPeso)
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

        Dim cantidadTotalLotes As Single = RepositorioStockLote.ObtenerTotalArticuloEnLotes(TextBoxCodigoArticulo.Text)
        Dim cantidadTotalStock As Single = RepositorioArticulo.ObtenerInformacion(TextBoxCodigoArticulo.Text).StockTotal

        If cantidadTotalStock + SpinEditCantidad.Value > cantidadTotalLotes Then
            ' Alert sobre la disconformidad y pedir confirmación
            Dim mensaje As String = "La cantidad total de lotes excede el stock disponible. ¿Desea continuar de todos modos?"
            Dim titulo As String = "Confirmación"
            Dim resultado As DialogResult = MessageBox.Show(mensaje, titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            If resultado = DialogResult.Cancel Then
                Exit Sub ' El usuario canceló, no continuar
            End If
            ' Si resultado = DialogResult.OK, continúa con el proceso
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
            LabelIndicadorPorPeso.Visible = False
            SpinEditCantidad.Text = "0"
            Return
        End If

        ' Cargar datos del artículo y actualizar stock
        CargarDatosArticulo(True, e)

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
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text.Trim()) Then
            ' Limpiar datos relacionados
            LabelNombreUbicacion.Text = String.Empty
            LabelNombreAlmacen.Text = String.Empty
            Return
        End If

        ' Cargar datos de la ubicación
        CargarDatosUbicacion(True, e)

        ' Si la validación de ubicación fue exitosa y hay un artículo seleccionado,
        ' actualizar el stock
        If Not e.Cancel AndAlso Not String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            actualizarCampoStock()
        End If
    End Sub

    ''' <summary>
    ''' Evento opcional para limpiar datos cuando el usuario borra el contenido
    ''' </summary>
    Private Sub TextBoxCodigoArticulo_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCodigoArticulo.TextChanged
        ' Solo limpiar si el campo queda completamente vacío
        If String.IsNullOrEmpty(TextBoxCodigoArticulo.Text) Then
            LabelNombreArticulo.Text = String.Empty
            LabelIndicadorPorPeso.Visible = False
            SpinEditCantidad.Text = "0"
        End If
    End Sub

    ''' <summary>
    ''' Evento opcional para limpiar datos cuando el usuario borra el contenido de ubicación
    ''' </summary>
    Private Sub TextBoxCodigoUbicacion_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCodigoUbicacion.TextChanged
        ' Solo limpiar si el campo queda completamente vacío
        If String.IsNullOrEmpty(TextBoxCodigoUbicacion.Text) Then
            LabelNombreUbicacion.Text = String.Empty
            LabelNombreAlmacen.Text = String.Empty
        End If
    End Sub

    Private Sub LabelStockTotal_Click(sender As Object, e As EventArgs) Handles LabelStockTotal.Click
        If LabelStockTotal.Text = "" Then Exit Sub

        SpinEditCantidad.Value = CType(LabelStockTotal.Text, Single)
    End Sub

#End Region

End Class