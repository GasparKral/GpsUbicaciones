Public Class frmMain

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        LoggerInstance.Info("Usuario solicitó cerrar la aplicación")
        Me.Close()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        LoggerInstance.Info("Abriendo formulario de asignación de artículos")
        Try
            frmAsignar.ShowDialog()
            frmAsignar.Dispose()
            LoggerInstance.Debug("Formulario de asignación cerrado correctamente")
        Catch ex As Exception
            LoggerInstance.Error("Error al abrir formulario de asignación", ex)
        End Try
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoggerInstance.Info("Iniciando aplicación GpsUbicaciones", logType:=LogType.Both)

        Try
            ' The following line provides localization for data formats.
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
            SepDecimal = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            LoggerInstance.Debug($"Configuración regional establecida: es-ES, SepDecimal: {SepDecimal}")

            ' The following line provides localization for the application's user interface.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-ES")

            Application.EnableVisualStyles()
            '  Application.SetCompatibleTextRenderingDefault(False)


            SplashScreen.Show()
            Application.DoEvents()

            ' Leer el primer parametro de la linea de comandos:
            Dim args() As String = Environment.GetCommandLineArgs()
            LoggerInstance.Info($"Argumentos de línea de comandos recibidos: {String.Join(", ", args)}")

            ' Verificar que tenemos al menos los argumentos mínimos (unidad, empresa, terminal)
            If args.Length >= 4 Then  ' ejecutable + 3 argumentos mínimos
                Unidad = args(1)
                EmpresaSeleccionada = args(2)
                Terminal = args(3)
                LoggerInstance.Info($"Parámetros principales - Unidad: {Unidad}, Empresa: {EmpresaSeleccionada}, Terminal: {Terminal}")

                ' Argumentos opcionales
                If args.Length > 4 Then
                    Almacen = args(4)
                    LoggerInstance.Debug($"Almacén especificado: {Almacen}")
                End If
                If args.Length > 5 Then
                    DataBaseAplicationType = [Enum].Parse(GetType(DatabaseType), args(5))
                    LoggerInstance.Debug($"Tipo de base de datos especificado: {DataBaseAplicationType}")
                End If

                '      RevaluateSettings()
                RutaDatos = Unidad & "\GpsWin"
                settings.DataPath = RutaDatos
                settings.SelectedCompany = EmpresaSeleccionada
                LoggerInstance.Info($"Configuración actualizada - RutaDatos: {RutaDatos}")
            Else
                ' Manejar el caso cuando no hay suficientes argumentos
                Dim errorMsg = "Faltan argumentos requeridos: Unidad, Empresa y Terminal"
                LoggerInstance.Error(errorMsg, logType:=LogType.Both)
                MessageBox.Show(errorMsg)
                Return
            End If

            LoggerInstance.Info($"Consultando configuración de terminal: {Terminal}")
            Dim dt = Operacion.ExecuteTable("SELECT * FROM Pda WHERE Codigo = ?", Terminal)

            If dt.Rows.Count = 0 Then
                Dim errorMsg = $"Terminal {Terminal} no definido en la tabla PDA"
                LoggerInstance.Error(errorMsg, logType:=LogType.Both)
                MsgBox(errorMsg)
                Me.Close()
                Return
            End If

            Almacen = dt.Rows(0)("almacen")
            lblTerminal.Text = dt.Rows(0)("Nombre").ToString
            LoggerInstance.Info($"Terminal configurado - Nombre: {lblTerminal.Text}, Almacén: {Almacen}")
            dt.Dispose()

            lblEmpresa.Text = "Empresa: " & EmpresaSeleccionada
            lblAlmacen.Text = "Almacen: " & Almacen

            SplashScreen.Close()
            LoggerInstance.Info("Aplicación iniciada correctamente")

        Catch ex As Exception
            LoggerInstance.Fatal("Error crítico durante la inicialización de la aplicación", ex, logType:=LogType.Both)
            MessageBox.Show($"Error crítico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        LoggerInstance.Info("Abriendo formulario de venta")
        Try
            frmVenta.ShowDialog()
            frmVenta.Dispose()
            LoggerInstance.Debug("Formulario de venta cerrado correctamente")
        Catch ex As Exception
            LoggerInstance.Error("Error al abrir formulario de venta", ex)
        End Try
    End Sub

    Private Sub btnSeleccionArticulos_Click(sender As Object, e As EventArgs) Handles btnSeleccionArticulos.Click
        LoggerInstance.Info("Abriendo formulario de selección de artículos")
        Try
            frmSeleccionArticulos.ShowDialog()
            frmSeleccionArticulos.Dispose()
            LoggerInstance.Debug("Formulario de selección de artículos cerrado correctamente")
        Catch ex As Exception
            LoggerInstance.Error("Error al abrir formulario de selección de artículos", ex)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("Gestión Ubicaciones" & vbCrLf & vbCrLf &
               "Gabinete de Proyectos Software SL" & vbCrLf &
               "924 810067" & vbCrLf &
               "www.gps-sl.es", MsgBoxStyle.Information, "(c) Copyright")
    End Sub

    Private Sub btnTrasladarArticulos_Click(sender As Object, e As EventArgs) Handles btnTrasladarArticulos.Click
        LoggerInstance.Info("Abriendo formulario de traslado de productos")
        Try
            frmTrasladoProductos.ShowDialog()
            frmTrasladoProductos.Dispose()
            LoggerInstance.Debug("Formulario de traslado de productos cerrado correctamente")
        Catch ex As Exception
            LoggerInstance.Error("Error al abrir formulario de traslado de productos", ex)
        End Try
    End Sub

    Private Sub btnUtilidades_Click(sender As Object, e As EventArgs) Handles btnUtilidades.Click
        LoggerInstance.Info("Abriendo formulario de utilidades")
        Try
            frmUtilidades.ShowDialog()
            frmUtilidades.Dispose()
            LoggerInstance.Debug("Formulario de utilidades cerrado correctamente")
        Catch ex As Exception
            LoggerInstance.Error("Error al abrir formulario de utilidades", ex)
        End Try
    End Sub
End Class