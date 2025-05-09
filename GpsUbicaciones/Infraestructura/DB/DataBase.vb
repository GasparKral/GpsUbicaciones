Public Enum DatabaseType
    Access2000
    SqlServer2005
    Access2007
    Access2013
    SqlServer
End Enum

Public Class DatabaseSettings
    Public Property DatabaseType As DatabaseType
    Public Property Provider As String
    Public Property Server As String
    Public Property Username As String
    Public Property Password As String
    Public Property CommonDatabasePassword As String
    Public Property SelectedCompany As String
    Public Property DataPath As String
    Public Property Terminal As String
    Public Property Warehouse As String
    Public Property DecimalPlaces As Integer
    Public Property DecimalSeparator As Char
End Class

