Module Configuracion

    ' Propiedades de la aplicación
    Public Unidad As String = "C:"
    Public SepDecimal As String
    Public Terminal As String = "001"
    Public EmpresaSeleccionada As String = "038"
    Public nDecUds As Integer = 2
    Public ContraseñaBBDDComun As String = "GpS924"
    Public RutaDatos As String = Unidad & "\GpsWin"
    Public Almacen As String

    ' Configuración de la base de datos
    Dim settings As New DatabaseSettings() With {
        .DatabaseType = DatabaseType.Access2000,
        .Provider = "Microsoft.ACE.OLEDB.12.0",
        .Password = ContraseñaBBDDComun,
        .DataPath = RutaDatos,
        .SelectedCompany = EmpresaSeleccionada
    }

    Public Operacion As DatabaseOperation = DatabaseOperationFactory.Create(settings)

End Module

