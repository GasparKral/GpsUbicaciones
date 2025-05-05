Imports System.Data.SqlClient

Public Class SqlServerDatabaseOperation
    Inherits DatabaseOperation

    Public Sub New(settings As DatabaseSettings)
        MyBase.New(settings)
    End Sub

    Public Overrides Function CreateConnection(Optional company As String = "ACTIVA", Optional dataPath As String = "PRINCIPAL") As IDbConnection
        Dim connectionString = BuildConnectionString(company, dataPath)
        Return New SqlConnection(connectionString)
    End Function

    Public Overrides Function ExecuteQuery(commandText As String, ParamArray parameters() As Object) As DataSet
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteNonQuery(commandText As String, ParamArray parameters() As Object) As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteTable(commandText As String, ParamArray parameters() As Object) As DataTable
        Throw New NotImplementedException()
    End Function

    Protected Overloads Function BuildConnectionString(company As String, dataPath As String) As String
        Return $"Server={Settings.Server};Database={If(company = "COMUN", "COMUNSQL", $"{company}DATSQL")};User Id={Settings.Username};Password={Settings.Password};"
    End Function

    ' Implementaciones similares a AccessDatabaseOperation pero para SQL Server
    ' ...
End Class