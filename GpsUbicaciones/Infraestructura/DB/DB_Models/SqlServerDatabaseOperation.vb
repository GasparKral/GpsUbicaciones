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

    Public Overrides Function ExecuteQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataSet
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteNonQuery(commandText As String, ParamArray parameters() As Object) As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteNonQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As Integer
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteTable(commandText As String, ParamArray parameters() As Object) As DataTable
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteTable(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataTable
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteScalar(commandText As String, ParamArray parameters() As Object) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ExecuteScalar(connection As IDbConnection, transaction As IDbTransaction, commandText As String, ParamArray parameters() As Object) As Boolean
        Throw New NotImplementedException()
    End Function

End Class