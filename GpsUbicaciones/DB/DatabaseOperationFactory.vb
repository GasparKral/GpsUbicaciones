Public Class DatabaseOperationFactory
    Public Shared Function Create(settings As DatabaseSettings) As DatabaseOperation
        Select Case settings.DatabaseType
            Case DatabaseType.Access2000, DatabaseType.Access2007, DatabaseType.Access2013
                Return New AccessDatabaseOperation(settings)
            Case DatabaseType.SqlServer, DatabaseType.SqlServer2005
                Return New SqlServerDatabaseOperation(settings)
            Case Else
                Throw New NotSupportedException($"Tipo de base de datos no soportado: {settings.DatabaseType}")
        End Select
    End Function
End Class