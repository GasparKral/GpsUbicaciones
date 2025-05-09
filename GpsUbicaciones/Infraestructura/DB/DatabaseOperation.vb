''' <summary>
''' Clase base abstracta que proporciona operaciones básicas de base de datos.
''' </summary>
''' <remarks>
''' Esta clase debe ser heredada por implementaciones concretas para proveedores específicos de bases de datos.
''' </remarks>
Public MustInherit Class DatabaseOperation
    ''' <summary>
    ''' Configuración de la base de datos utilizada por la instancia.
    ''' </summary>
    Protected ReadOnly Settings As DatabaseSettings

    ''' <summary>
    ''' Inicializa una nueva instancia de la clase DatabaseOperation con la configuración especificada.
    ''' </summary>
    ''' <param name="settings">Configuración de la base de datos que será utilizada.</param>
    Public Sub New(settings As DatabaseSettings)
        Me.Settings = settings
    End Sub

    ''' <summary>
    ''' Crea y devuelve una nueva conexión a la base de datos.
    ''' </summary>
    ''' <param name="company">Nombre de la compañía para la conexión. Por defecto es "ACTIVA".</param>
    ''' <param name="dataPath">Ruta de los datos. Por defecto es "PRINCIPAL".</param>
    ''' <returns>Una interfaz IDbConnection que representa la conexión a la base de datos.</returns>
    Public MustOverride Function CreateConnection(Optional company As String = "ACTIVA", Optional dataPath As String = "PRINCIPAL") As IDbConnection

    ''' <summary>
    ''' Ejecuta una consulta SQL y devuelve los resultados como un DataSet.
    ''' </summary>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>DataSet con los resultados de la consulta.</returns>
    Public MustOverride Function ExecuteQuery(commandText As String, ParamArray parameters() As Object) As DataSet

    ''' <summary>
    ''' Ejecuta una consulta SQL usando una conexión existente y devuelve los resultados como un DataSet.
    ''' </summary>
    ''' <param name="connection">Conexión a la base de datos a utilizar.</param>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>DataSet con los resultados de la consulta.</returns>
    Public MustOverride Function ExecuteQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataSet

    ''' <summary>
    ''' Ejecuta un comando SQL que no devuelve resultados (INSERT, UPDATE, DELETE).
    ''' </summary>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para el comando SQL.</param>
    ''' <returns>Número de filas afectadas por el comando.</returns>
    Public MustOverride Function ExecuteNonQuery(commandText As String, ParamArray parameters() As Object) As Integer

    ''' <summary>
    ''' Ejecuta un comando SQL usando una conexión existente que no devuelve resultados.
    ''' </summary>
    ''' <param name="connection">Conexión a la base de datos a utilizar.</param>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para el comando SQL.</param>
    ''' <returns>Número de filas afectadas por el comando.</returns>
    Public MustOverride Function ExecuteNonQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As Integer

    ''' <summary>
    ''' Ejecuta una consulta SQL y devuelve los resultados como un DataTable.
    ''' </summary>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>DataTable con los resultados de la consulta.</returns>
    Public MustOverride Function ExecuteTable(commandText As String, ParamArray parameters() As Object) As DataTable

    ''' <summary>
    ''' Ejecuta una consulta SQL usando una conexión existente y devuelve los resultados como un DataTable.
    ''' </summary>
    ''' <param name="connection">Conexión a la base de datos a utilizar.</param>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>DataTable con los resultados de la consulta.</returns>
    Public MustOverride Function ExecuteTable(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataTable

    ''' <summary>
    ''' Ejecuta una consulta SQL y devuelve un único valor booleano.
    ''' </summary>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>Valor booleano resultante de la consulta.</returns>
    Public MustOverride Function ExecuteScalar(commandText As String, ParamArray parameters() As Object) As Boolean

    ''' <summary>
    ''' Ejecuta una consulta SQL usando una conexión y transacción existentes, y devuelve un único valor booleano.
    ''' </summary>
    ''' <param name="connection">Conexión a la base de datos a utilizar.</param>
    ''' <param name="transaction">Transacción asociada a la ejecución.</param>
    ''' <param name="commandText">Texto del comando SQL a ejecutar.</param>
    ''' <param name="parameters">Parámetros opcionales para la consulta SQL.</param>
    ''' <returns>Valor booleano resultante de la consulta.</returns>
    Public MustOverride Function ExecuteScalar(connection As IDbConnection, transaction As IDbTransaction, commandText As String, ParamArray parameters() As Object) As Boolean

    ''' <summary>
    ''' Construye la cadena de conexión apropiada basada en la compañía y ruta de datos especificadas.
    ''' </summary>
    ''' <param name="company">Nombre de la compañía para la conexión.</param>
    ''' <param name="dataPath">Ruta de los datos.</param>
    ''' <returns>Cadena de conexión formateada según los parámetros.</returns>
    ''' <remarks>
    ''' Si company es "ACTIVA", se usará la compañía seleccionada en Settings.
    ''' Si dataPath es "PRINCIPAL", se usará la ruta de datos de Settings.
    ''' Maneja casos especiales para "COMUN" y "RUTACOMPLETA".
    ''' </remarks>
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