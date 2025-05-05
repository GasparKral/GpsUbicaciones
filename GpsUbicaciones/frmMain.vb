Public Class frmMain

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        frmAsignar.ShowDialog()
        frmAsignar.Dispose()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' The following line provides localization for data formats.
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-ES")
        SepDecimal = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        ' The following line provides localization for the application's user interface.
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("es-ES")

        Application.EnableVisualStyles()
        '  Application.SetCompatibleTextRenderingDefault(False)


        SplashScreen.Show()
        Application.DoEvents()



        ' Leer el primer parametro de la linea de comandos:
        '    C:  038 001
        Dim args() As String = Environment.GetCommandLineArgs()
        If args.Length > 1 Then
            ' Si hay un parametro, es el DISCO de datos
            Unidad = args(1)
        End If
        If args.Length > 2 Then
            EmpresaSeleccionada = args(2)
        End If
        If args.Length > 3 Then
            Terminal = args(3)
        End If



        Dim dt = Operacion.ExecuteTable("SELECT * FROM Pda WHERE Codigo = ?", Terminal)

        If dt.Rows.Count = 0 Then
            MsgBox("Terminal no definido en la tabla PDA")
            Me.Close()
        End If

        Almacen = dt.Rows(0)("almacen")
        lblTerminal.Text = dt.Rows(0)("Nombre").ToString
        dt.Dispose()


        lblEmpresa.Text = "Empresa: " & EmpresaSeleccionada
        lblAlmacen.Text = "Almacen: " & Almacen


        SplashScreen.Close()
    End Sub

    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        frmVenta.ShowDialog()
        frmVenta.Dispose()
    End Sub

    Private Sub btnSeleccionArticulos_Click(sender As Object, e As EventArgs) Handles btnSeleccionArticulos.Click
        frmSeleccionArticulos.ShowDialog()
        frmSeleccionArticulos.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("Gestión Ubicaciones" & vbCrLf & vbCrLf &
               "Gabinete de Proyectos Software SL" & vbCrLf &
               "924 810067" & vbCrLf &
               "www.gps-sl.es", MsgBoxStyle.Information, "(c) Copyright")
    End Sub

    Private Sub btnTrasladarArticulos_Click(sender As Object, e As EventArgs) Handles btnTrasladarArticulos.Click
        frmTransladoProductos.ShowDialog()
        frmTransladoProductos.Dispose()
    End Sub
End Class