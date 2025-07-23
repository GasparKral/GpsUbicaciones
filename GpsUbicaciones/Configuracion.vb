Module Configuracion

    ' Instancia del logger
    Public ReadOnly LoggerInstance As Logger = Logger.Instance

    ' Propiedades de la aplicación
    Public Unidad As String = "C:"
    Public SepDecimal As String
    Public Terminal As String = "001"
    Public EmpresaSeleccionada As String = "038"
    Public nDecUds As Integer = 2
    Public ContraseñaBBDDComun As String = "GpS924"
    Public RutaDatos As String = Unidad & "\GpsWin"
    Public Almacen As String = "00"
    Public DataBaseAplicationType As DatabaseType = DatabaseType.Access2007

    ' Configuración de la base de datos
    Public settings As New DatabaseSettings() With {
        .DatabaseType = DataBaseAplicationType,
        .Provider = "Microsoft.ACE.OLEDB.12.0",
        .Password = ContraseñaBBDDComun,
        .DataPath = RutaDatos,
        .SelectedCompany = EmpresaSeleccionada
    }

    Public Operacion As DatabaseOperation = DatabaseOperationFactory.Create(settings)

End Module

