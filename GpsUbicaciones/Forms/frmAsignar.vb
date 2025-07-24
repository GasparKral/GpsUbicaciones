Imports System.ComponentModel

Public Class frmAsignar
    Implements IDisposable

    ' Estado del formulario
    Private ReadOnly _formStateManager As New AsignarFormStateManager()
    Private ReadOnly _validationService As New AsignarValidationService()
    Private ReadOnly _stockService As New AsignarStockService()

    ' Control de permisos especiales y validaciones
    Private _hasSpecialPermission As Boolean = False
    Private _validationSuspended As Boolean = False

#Region "Inicialización y configuración"

    Private Sub frmAsignar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            InitializeGridDataSource()
            InitializeFormState()
        Catch ex As Exception
            HandleError("Error al inicializar el formulario", ex)
        End Try
    End Sub

    Private Sub InitializeGridDataSource()
        Dim dt As New DataTable()
        With dt.Columns
            .Add("Ref", GetType(String))
            .Add("ItemName", GetType(String))
            .Add("Location", GetType(String))
            .Add("TotalStock", GetType(String))
            .Add("LocalStock", GetType(Single))
            .Add("Asign", GetType(Single))
            .Add("Image")
        End With
        GridControlAsignacionArticulos.DataSource = dt
    End Sub

    Private Sub InitializeFormState()
        _formStateManager.ResetToInitialState(Me)
        ' Asegurar flujo secuencial: solo ubicación habilitada inicialmente
        PermitirEdicion(TextEditLocation, True, True)
        PermitirEdicion(TextEditItem, False)
        PermitirEdicion(SpinEditCantidad, False)
    End Sub

#End Region

#Region "Eventos de validación de campos"

    Private Sub TextEditLocation_Validating(sender As Object, e As CancelEventArgs) Handles TextEditLocation.Validating
        ' Salir si las validaciones están suspendidas
        If _validationSuspended Then Return

        Try
            ' Siempre limpiar datos de artículo cuando cambia ubicación
            _formStateManager.ClearItemData(Me)

            Dim validationResult = _validationService.ValidateLocation(TextEditLocation.Text.Trim())

            If Not validationResult.IsValid Then
                e.Cancel = True
                If Not String.IsNullOrEmpty(validationResult.ErrorMessage) Then
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, validationResult.ErrorMessage)
                End If
                TextEditLocation.SelectAll()
                _formStateManager.ClearLocationData(Me)
                Return
            End If

            ' Aplicar datos de ubicación válida y habilitar siguiente campo
            _formStateManager.SetLocationData(Me, validationResult.Data)

        Catch ex As Exception
            HandleValidationError("ubicación", ex, e)
        End Try
    End Sub

    Private Sub TextEditItem_Validating(sender As Object, e As CancelEventArgs) Handles TextEditItem.Validating
        If _validationSuspended Then Return

        Try
            If Not _validationService.HasValidLocation(TextEditLocation.Text.Trim(), LabelNombreUbicacion.Text) Then
                e.Cancel = True
                FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, "Debe especificar una ubicación válida antes de seleccionar un artículo.")
                TextEditLocation.Focus()
                Return
            End If

            ' VERIFICAR si el artículo realmente cambió
            Dim currentItemCode = TextEditItem.Text.Trim()
            Dim isEmptyItem = String.IsNullOrEmpty(currentItemCode)

            ' Si está vacío, limpiar datos
            If isEmptyItem Then
                _formStateManager.ClearItemData(Me)
                Return
            End If

            ' EVITAR validación si el artículo ya está cargado y es el mismo
            If Not String.IsNullOrEmpty(LabelNombreArticulo.Text) AndAlso
           _validationService.IsSameItem(currentItemCode, LabelNombreArticulo.Text) Then
                Return ' No hacer nada si es el mismo artículo
            End If

            ' Solo limpiar y revalidar si es un artículo diferente
            Dim currentSpinValue As Decimal = SpinEditCantidad.Value
            _formStateManager.ClearItemData(Me)

            Dim validationResult = _validationService.ValidateItem(currentItemCode, TextEditLocation.Text.Trim())

            If Not validationResult.IsValid Then
                e.Cancel = True
                FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, validationResult.ErrorMessage)
                TextEditItem.SelectAll()
                Return
            End If

            _formStateManager.SetItemData(Me, validationResult.Data)

            ' Restaurar valor del SpinEdit si era válido
            If currentSpinValue > 0 Then
                SpinEditCantidad.Value = currentSpinValue
            End If

        Catch ex As Exception
            HandleValidationError("artículo", ex, e)
        End Try
    End Sub

#End Region

#Region "Eventos de botones"

    Private Sub ButtonConfirmacionArticulo_Click(sender As Object, e As EventArgs) Handles ButtonConfirmacionArticulo.Click
        Try
            If Not ValidateFormForSubmission() Then Return

            Dim confirmationResult = _validationService.ValidateStockConfirmation(
                TextEditItem.Text.Trim(),
                TextEditLocation.Text.Trim(),
                SpinEditCantidad.Value,
                _hasSpecialPermission)

            If Not confirmationResult.IsValid Then
                If confirmationResult._RequiresConfirmation Then
                    _hasSpecialPermission = RequestSpecialPermission(confirmationResult.ErrorMessage)
                    If Not _hasSpecialPermission Then Return
                Else
                    FabricaMensajes.MostrarMensaje(TipoMensaje.Error, confirmationResult.ErrorMessage)
                    SpinEditCantidad.Focus()
                    Return
                End If
            End If

            ProcessStockAssignment()

        Catch ex As Exception
            HandleError("Error al confirmar el artículo", ex)
        Finally
            _hasSpecialPermission = False
        End Try
    End Sub

    Private Sub ButtonResetForm_Click(sender As Object, e As EventArgs) Handles ButtonResetForm.Click
        Try
            ' Deshabilitar validaciones temporalmente durante el reset
            SuspendValidation()
            _formStateManager.ResetFormSilent(Me)
            _hasSpecialPermission = False
        Catch ex As Exception
            HandleError("Error al reiniciar el formulario", ex)
        Finally
            ' Reactivar validaciones
            ResumeValidation()
        End Try
    End Sub

    Private Sub ButtonConsultarUbicacion_Click(sender As Object, e As EventArgs) Handles ButtonConsultarUbicacion.Click
        Try
            If String.IsNullOrEmpty(LabelNombreUbicacion.Text) Then Return

            Using frm As New frmConsulta
                frm.LabelUbicaciónConsultada.Text = LabelNombreUbicacion.Text
                frm.Source = RepositorioStockLote.ObtenerArticulosEnLote(TextEditLocation.Text)
                frm.ShowDialog()
            End Using
        Catch ex As Exception
            HandleError("Error al consultar la ubicación", ex)
        Finally
            BuscarUltimoFoco(ButtonConfirmacionArticulo, TextEditLocation, TextEditItem, SpinEditCantidad)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Eventos de interacción"

    Private Sub LabelTotalStock_Click(sender As Object, e As EventArgs) Handles LabelTotalStock.Click
        Try
            If String.IsNullOrEmpty(LabelTotalStock.Text) Then Return

            If Decimal.TryParse(LabelTotalStock.Text, SpinEditCantidad.Value) AndAlso SpinEditCantidad.Value >= 0 Then
                SpinEditCantidad.Value = Math.Max(0, SpinEditCantidad.Value)
            End If
        Catch ex As Exception
            ' Error silencioso para interacción de UI
        End Try
    End Sub

#End Region

#Region "Métodos de validación y procesamiento"

    Private Function ValidateFormForSubmission() As Boolean
        ' Validar campos obligatorios
        If Not _validationService.HasValidLocation(TextEditLocation.Text, LabelNombreUbicacion.Text) OrElse
           Not _validationService.HasValidItem(TextEditItem.Text, LabelNombreArticulo.Text) Then
            Return False
        End If

        ' Validar cantidad
        If SpinEditCantidad.Value <= 0 Then
            FabricaMensajes.MostrarMensaje(TipoMensaje.Error, "La cantidad debe ser mayor a 0")
            SpinEditCantidad.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function RequestSpecialPermission(message As String) As Boolean
        Dim confirmation = FabricaMensajes.MostrarConfirmacion(
            message & " ¿Desea continuar de todos modos?",
            "Confirmación")

        If Not confirmation Then
            PermitirEdicion(ButtonResetForm, False)
            PermitirEdicion(ButtonConfirmacionArticulo, False)
            SpinEditCantidad.Focus()
        End If

        Return confirmation
    End Function

    Private Sub ProcessStockAssignment()
        Try
            _stockService.ProcessStockAssignment(
                TextEditItem.Text.Trim(),
                TextEditLocation.Text.Trim(),
                SpinEditCantidad.Value)

            UpdateGridAfterOperation()
            ' Limpiar solo datos del artículo para permitir agregar más artículos a la misma ubicación
            _formStateManager.ClearItemDataOnly(Me)

        Catch ex As Exception
            Throw New Exception($"Error al procesar la asignación de stock: {ex.Message}", ex)
        End Try
    End Sub

    Private Sub UpdateGridAfterOperation()
        Try
            Dim dt As DataTable = GridControlAsignacionArticulos.DataSource
            Dim row As DataRow = dt.NewRow()
            Dim info = RepositorioStockLote.ObtenerArticuloEnLote(TextEditItem.Text, TextEditLocation.Text)


            row("Ref") = info.Articulo.Codigo
            row("ItemName") = info.Articulo.NombreComercial
            row("Location") = info.Lote.Nombre
            row("TotalStock") = info.Articulo.StockTotal
            row("LocalStock") = info.Cantidad
            row("Asign") = SpinEditCantidad.Value


            dt.Rows.Add(row)
            GridControlAsignacionArticulos.Visible = True
        Catch ex As Exception
            Throw New Exception($"Error al actualizar la grilla: {ex.Message}", ex)
        End Try
    End Sub

#End Region

#Region "Control de validaciones"

    ''' <summary>
    ''' Suspende temporalmente las validaciones para operaciones de limpieza
    ''' </summary>
    Private Sub SuspendValidation()
        _validationSuspended = True
    End Sub

    ''' <summary>
    ''' Reactiva las validaciones después de operaciones de limpieza
    ''' </summary>
    Private Sub ResumeValidation()
        _validationSuspended = False
    End Sub

#End Region

#Region "Manejo de errores"

    Private Sub HandleError(message As String, ex As Exception)
        LoggerInstance.Error(message, ex)
        FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"{message}: {ex.Message}")
    End Sub

    Private Sub HandleValidationError(fieldName As String, ex As Exception, ByRef e As CancelEventArgs)
        e.Cancel = True
        HandleError($"Error al validar {fieldName}", ex)
    End Sub

#End Region

End Class


#Region "AsignarFormStateManager - Gestión de estado del formulario"

''' <summary>
''' Gestiona el estado y la apariencia de los controles del formulario frmAsignar
''' </summary>
Public Class AsignarFormStateManager
    Implements IDisposable

    Public Sub ResetToInitialState(form As frmAsignar)
        With form
            .TextEditLocation.Clear()
            .TextEditItem.Clear()
            .LabelNombreUbicacion.Text = String.Empty
            .LabelNombreArticulo.Text = String.Empty
            .LabelTotalStock.Text = String.Empty
            .LabelLocalStock.Text = String.Empty
            .SpinEditCantidad.Value = 0
            .IconWeigth.Visible = False

            ' Flujo secuencial: solo ubicación habilitada inicialmente
            PermitirEdicion(.TextEditLocation, True, True)
            PermitirEdicion(.TextEditItem, False)
            PermitirEdicion(.SpinEditCantidad, False)
            PermitirEdicion(.ButtonConsultarUbicacion, False)
        End With
    End Sub

    Public Sub ResetForm(form As frmAsignar)
        ResetToInitialState(form)
        form.GridControlAsignacionArticulos.Visible = False
    End Sub

    Public Sub SetLocationData(form As frmAsignar, locationData As LocationValidationData)
        If locationData Is Nothing Then
            ClearLocationData(form)
            Return
        End If
        With form
            .LabelNombreUbicacion.Text = locationData.Name
            ' Solo habilitar artículo cuando ubicación es válida
            PermitirEdicion(.TextEditItem, True, True)  ' Con foco automático
            PermitirEdicion(.ButtonConsultarUbicacion, True, False)
        End With
    End Sub

    Public Sub ClearLocationData(form As frmAsignar)
        With form
            .LabelNombreUbicacion.Text = String.Empty
            ' Deshabilitar campos dependientes
            PermitirEdicion(.TextEditItem, False)
            PermitirEdicion(.SpinEditCantidad, False)
            PermitirEdicion(.ButtonConsultarUbicacion, False)
        End With
    End Sub

    Public Sub SetItemData(form As frmAsignar, itemData As ItemValidationData)
        With form
            .LabelNombreArticulo.Text = itemData.Name
            .LabelTotalStock.Text = itemData.TotalStock.ToString()
            .LabelLocalStock.Text = itemData.LocalStock.ToString()

            ' Preservar valor actual antes de reconfigurar
            Dim currentValue = .SpinEditCantidad.Value

            ' Configurar SpinEdit ANTES de habilitarlo para evitar reset a 0
            AceptarDecimales(.SpinEditCantidad, itemData.IsByWeight, .IconWeigth)

            ' Restaurar valor si era válido, o establecer valor mínimo válido
            If currentValue > 0 Then
                .SpinEditCantidad.Value = currentValue
            Else
                .SpinEditCantidad.Value = If(itemData.IsByWeight, 0.1D, 1D)
            End If

            ' Solo habilitar cantidad cuando artículo es válido
            PermitirEdicion(.SpinEditCantidad, True, True)  ' Con foco automático
        End With
    End Sub

    Public Sub ClearItemData(form As frmAsignar)
        With form
            .LabelNombreArticulo.Text = String.Empty
            .LabelTotalStock.Text = String.Empty
            .LabelLocalStock.Text = String.Empty
            .SpinEditCantidad.Value = 0
            .IconWeigth.Visible = False
            PermitirEdicion(.SpinEditCantidad, False)
        End With
    End Sub

    ''' <summary>
    ''' Limpia solo los datos del artículo pero mantiene la ubicación válida
    ''' Útil después de procesar una asignación exitosa
    ''' </summary>
    Public Sub ClearItemDataOnly(form As frmAsignar)
        With form
            .TextEditItem.Clear()
            .LabelNombreArticulo.Text = String.Empty
            .LabelTotalStock.Text = String.Empty
            .LabelLocalStock.Text = String.Empty
            .SpinEditCantidad.Value = 0
            .IconWeigth.Visible = False
            PermitirEdicion(.SpinEditCantidad, False)
            ' Mantener artículo habilitado para agregar más artículos a la misma ubicación
            PermitirEdicion(.TextEditItem, True, True)
        End With
    End Sub

    ''' <summary>
    ''' Realiza un reset completo sin disparar validaciones
    ''' Usado por el botón de reset
    ''' </summary>
    Public Sub ResetFormSilent(form As frmAsignar)
        With form
            ' Limpiar campos sin disparar eventos de validación
            .TextEditLocation.Text = String.Empty
            .TextEditItem.Text = String.Empty
            .LabelNombreUbicacion.Text = String.Empty
            .LabelNombreArticulo.Text = String.Empty
            .LabelTotalStock.Text = String.Empty
            .LabelLocalStock.Text = String.Empty
            .SpinEditCantidad.Value = 0
            .IconWeigth.Visible = False

            ' Flujo secuencial: solo ubicación habilitada inicialmente
            PermitirEdicion(.TextEditLocation, True, True)
            PermitirEdicion(.TextEditItem, False)
            PermitirEdicion(.SpinEditCantidad, False)
            PermitirEdicion(.ButtonConsultarUbicacion, False)

            .GridControlAsignacionArticulos.Visible = False
        End With
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Nothing to dispose
    End Sub
End Class

#End Region

#Region "AsignarValidationService - Servicio de validaciones"

''' <summary>
''' Servicio que maneja todas las validaciones del formulario frmAsignar
''' </summary>
Public Class AsignarValidationService
    Implements IDisposable

    Public Function ValidateLocation(locationCode As String) As ValidationResult(Of LocationValidationData)
        If String.IsNullOrWhiteSpace(locationCode) OrElse locationCode = "" Then
            Return ValidationResult(Of LocationValidationData).Success(Nothing)
        End If

        Try
            Using ubicacion = RepositorioUbicacion.ObtenerInformacion(locationCode)
                If ubicacion Is Nothing Then
                    Return ValidationResult(Of LocationValidationData).Failure("Código de ubicación no válido")
                End If

                Dim locationData As New LocationValidationData With {
                    .Code = locationCode,
                    .Name = ubicacion.Nombre,
                    .WarehouseName = ubicacion.NombreAlmacen
                }

                Return ValidationResult(Of LocationValidationData).Success(locationData)
            End Using
        Catch ex As Exception
            Return ValidationResult(Of LocationValidationData).Failure($"Error al validar ubicación: {ex.Message}")
        End Try
    End Function

    Public Function ValidateItem(itemCode As String, locationCode As String) As ValidationResult(Of ItemValidationData)
        If String.IsNullOrWhiteSpace(itemCode) Then
            Return ValidationResult(Of ItemValidationData).Success(Nothing)
        End If

        Try
            ' Verificar si existe stock en la ubicación
            If RepositorioStockLote.HayExistencias(itemCode, locationCode) Then
                Return ValidateExistingItem(itemCode, locationCode)
            Else
                Return ValidateNewItem(itemCode)
            End If
        Catch ex As InvalidOperationException
            Return ValidationResult(Of ItemValidationData).Failure("Código de artículo no válido")
        Catch ex As Exception
            Return ValidationResult(Of ItemValidationData).Failure($"Error al validar artículo: {ex.Message}")
        End Try
    End Function

    Public Function IsSameItem(itemCode As String, currentItemName As String) As Boolean
        Try
            Using articulo = RepositorioArticulo.ObtenerInformacion(itemCode)
                Return articulo.NombreComercial.Equals(currentItemName, StringComparison.OrdinalIgnoreCase)
            End Using
        Catch
            Return False
        End Try
    End Function

    Private Function ValidateExistingItem(itemCode As String, locationCode As String) As ValidationResult(Of ItemValidationData)
        Try
            Using stockLote = RepositorioStockLote.ObtenerArticuloEnLote(itemCode, locationCode)
                Dim itemData As New ItemValidationData With {
                    .Code = itemCode,
                    .Name = stockLote.Articulo.NombreComercial,
                    .TotalStock = stockLote.Articulo.StockTotal,
                    .LocalStock = stockLote.Cantidad,
                    .IsByWeight = stockLote.Articulo.PorPeso
                }

                Return ValidationResult(Of ItemValidationData).Success(itemData)
            End Using
        Catch ex As Exception
            Return ValidationResult(Of ItemValidationData).Failure("Error al obtener datos del artículo en ubicación")
        End Try
    End Function

    Private Function ValidateNewItem(itemCode As String) As ValidationResult(Of ItemValidationData)
        Try
            Using articulo = RepositorioArticulo.ObtenerInformacion(itemCode)
                Dim itemData As New ItemValidationData With {
                    .Code = itemCode,
                    .Name = articulo.NombreComercial,
                    .TotalStock = articulo.StockTotal,
                    .LocalStock = 0,
                    .IsByWeight = articulo.PorPeso
                }

                Return ValidationResult(Of ItemValidationData).Success(itemData)
            End Using
        Catch ex As InvalidOperationException
            Return ValidationResult(Of ItemValidationData).Failure("Código de artículo no válido")
        End Try
    End Function

    Public Function ValidateStockConfirmation(itemCode As String, locationCode As String, quantity As Single, hasSpecialPermission As Boolean) As StockConfirmationResult
        If quantity <= 0 Then
            Return StockConfirmationResult.Failure("La cantidad debe ser mayor a 0")
        End If

        If hasSpecialPermission Then
            Return StockConfirmationResult.Success()
        End If

        Try
            Using stockLote = RepositorioStockLote.ObtenerArticuloEnLote(itemCode, locationCode)
                If (quantity + stockLote.Cantidad) > stockLote.Articulo.StockTotal Then
                    Return StockConfirmationResult.RequiresConfirmation("La cantidad total de lotes excede el stock disponible.")
                End If
            End Using
        Catch ex As Exception
            Return StockConfirmationResult.Failure($"Error al validar stock: {ex.Message}")
        End Try

        Return StockConfirmationResult.Success()
    End Function

    Public Function HasValidLocation(locationCode As String, locationName As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(locationCode) AndAlso Not String.IsNullOrWhiteSpace(locationName)
    End Function

    Public Function HasValidItem(itemCode As String, itemName As String) As Boolean
        Return Not String.IsNullOrWhiteSpace(itemCode) AndAlso Not String.IsNullOrWhiteSpace(itemName)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Nothing to dispose
    End Sub
End Class

#End Region

#Region "AsignarStockService - Servicio de operaciones de stock"

''' <summary>
''' Servicio que maneja las operaciones de stock para el formulario frmAsignar
''' </summary>
Public Class AsignarStockService
    Implements IDisposable

    Public Sub ProcessStockAssignment(itemCode As String, locationCode As String, quantity As Single)
        Try
            Using nestedTx As New NestedConditionalTransaction(Operacion)
                ' Definir acciones para cada caso
                Dim ifTrueAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.AgregarStock(con, quantity, itemCode, locationCode)
                    End Sub

                Dim ifFalseAction As Action(Of IDbConnection) =
                    Sub(con)
                        RepositorioStockLote.InsertarArticulo(con, quantity, itemCode, locationCode)
                    End Sub

                ' Ejecutar la transacción condicional
                Dim success = nestedTx.ExecuteConditionalTransaction(
                    Querys.Select.VerificarExistenciaLoteDeArticulo,
                    ifTrueAction,
                    ifFalseAction,
                    RepositorioArticulo.ObtenerInformacion(itemCode).Codigo, locationCode
                )

                ' Si todo fue bien, registrar en histórico
                If success Then
                    RegistrarEnHistorico(itemCode, quantity, locationCode)
                End If
            End Using
        Catch ex As DatabaseOperationException
            Throw New Exception(String.Format(MensajesGenerales.ErrorOperacionBD, ex.Message), ex)
        Catch ex As Exception
            Throw New Exception($"Error en operación de stock: {ex.Message}", ex)
        End Try
    End Sub

    Private Sub RegistrarEnHistorico(itemCode As String, quantity As Single, locationCode As String)
        Try
            Operacion.ExecuteNonQuery(
                "INSERT INTO LINTRASPLOTES VALUES(?,?,?,NULL,?)",
                Date.Now,
                RepositorioArticulo.ObtenerInformacion(itemCode).Codigo,
                quantity,
                locationCode)
        Catch ex As Exception
            ' El historial es secundario, no debe fallar la operación principal
            LoggerInstance.Warning($"No se pudo registrar en histórico: {ex.Message}")
        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Nothing to dispose
    End Sub
End Class

#End Region

#Region "Clases de datos para validaciones"

''' <summary>
''' Datos de ubicación validada
''' </summary>
Public Class LocationValidationData
    Public Property Code As String
    Public Property Name As String
    Public Property WarehouseName As String
End Class

''' <summary>
''' Datos de artículo validado
''' </summary>
Public Class ItemValidationData
    Public Property Code As String
    Public Property Name As String
    Public Property TotalStock As Single
    Public Property LocalStock As Single
    Public Property IsByWeight As Boolean
End Class

''' <summary>
''' Resultado de validación genérico
''' </summary>
Public Class ValidationResult(Of T)
    Public Property IsValid As Boolean
    Public Property Data As T
    Public Property ErrorMessage As String

    Public Shared Function Success(data As T) As ValidationResult(Of T)
        Return New ValidationResult(Of T) With {
            .IsValid = True,
            .Data = data
        }
    End Function

    Public Shared Function Failure(errorMessage As String) As ValidationResult(Of T)
        Return New ValidationResult(Of T) With {
            .IsValid = False,
            .ErrorMessage = errorMessage
        }
    End Function
End Class

''' <summary>
''' Resultado específico para confirmaciones de stock
''' </summary>
Public Class StockConfirmationResult
    Public Property IsValid As Boolean
    Public Property _RequiresConfirmation As Boolean
    Public Property ErrorMessage As String

    Public Shared Function Success() As StockConfirmationResult
        Return New StockConfirmationResult With {.IsValid = True}
    End Function

    Public Shared Function Failure(errorMessage As String) As StockConfirmationResult
        Return New StockConfirmationResult With {
            .IsValid = False,
            .ErrorMessage = errorMessage
        }
    End Function

    Public Shared Function RequiresConfirmation(message As String) As StockConfirmationResult
        Return New StockConfirmationResult With {
            .IsValid = False,
            ._RequiresConfirmation = True,
            .ErrorMessage = message
        }
    End Function
End Class

#End Region