Public MustInherit Class DatabaseOperation
    Protected ReadOnly Settings As DatabaseSettings

    Public Sub New(settings As DatabaseSettings)
        Me.Settings = settings
    End Sub

    Public MustOverride Function CreateConnection(Optional company As String = "ACTIVA", Optional dataPath As String = "PRINCIPAL") As IDbConnection
    Public MustOverride Function ExecuteQuery(commandText As String, ParamArray parameters() As Object) As DataSet
    Public MustOverride Function ExecuteNonQuery(commandText As String, ParamArray parameters() As Object) As Integer
    Public MustOverride Function ExecuteTable(commandText As String, ParamArray parameters() As Object) As DataTable

    Protected Function BuildConnectionString(company As String, dataPath As String) As String
        If company = "ACTIVA" Then
            company = Settings.SelectedCompany
        End If

        If dataPath = "PRINCIPAL" Then
            dataPath = Settings.DataPath
        End If

        Select Case company.ToUpper()
            Case "COMUN"
                Return $"Provider={Settings.Provider};Persist Security Info=False;Jet OLEDB:Database Password={Settings.CommonDatabasePassword};Data Source={dataPath}\BCOMUN.MDB"
            Case "RUTACOMPLETA"
                Return $"Provider={Settings.Provider};Persist Security Info=False;Jet OLEDB:Database Password={Settings.Password};Data Source={dataPath}"
            Case Else
                Return $"Provider={Settings.Provider};Persist Security Info=False;Jet OLEDB:Database Password={Settings.Password};Data Source={dataPath}\{company}DATOS.MDB"
        End Select
    End Function
End Class