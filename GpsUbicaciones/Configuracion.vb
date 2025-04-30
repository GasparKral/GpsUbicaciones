Imports System.Data.OleDb
Imports System.Data.SqlClient

Module Configuracion

    Public VersionBBDD As String = "ACCESS2000"
    Public CadenaTipoBD As String
    Public CadenaTipoBDComun As String
    Public ProveedorBD As String, ProveedorAccess As String, ServidorBD As String, UsuarioBD As String, PasswordBD As String
    Public ContraseñaBBDDComun As String
    Public EmpresaSeleccionada As String
    Public RutaDatos As String
    Public Terminal As String
    Public gAlmacen As String
    Public nDecUds As Integer
    Public SepDecimal As Char

    ' Abrir Conexion con la base de datos
    Public Function AbrirBaseDatos(ByRef Conexion As IDbConnection, Optional ByVal cEmpresa As String = "ACTIVA", Optional ByVal RutaDeBBDD As String = "PRINCIPAL") As Boolean

        Try
            AbrirBaseDatos = False

            If cEmpresa = "ACTIVA" Then
                cEmpresa = EmpresaSeleccionada
            End If

            Select Case VersionBBDD
                Case "", "ACCESS2000"
                    Conexion = New OleDbConnection() ' Assuming you are using OleDbConnection

                    ProveedorAccess = "Microsoft.ACE.OLEDB.12.0"

                    ProveedorBD = ProveedorAccess
                    CadenaTipoBD = "Provider=" & ProveedorBD & ";" &
                                   "Persist Security Info=False;" &
                                  "Jet OLEDB:Database Password=" & PasswordBD & ";"        ' Clave de acceso <05> para todas las bases de datos
                    ' 27/04/2022: Cadena conexion distinta porque tiene contraseña
                    CadenaTipoBDComun = "Provider=" & ProveedorBD & ";" & "Jet OLEDB:Database Password=" & ContraseñaBBDDComun & ";"

                    If RutaDeBBDD = "PRINCIPAL" Then
                        RutaDeBBDD = RutaDatos
                    End If
                    Select Case UCase(cEmpresa)
                        Case "COMUN"
                            Conexion.ConnectionString = CadenaTipoBDComun & "DATA SOURCE=" & RutaDeBBDD & "\BCOMUN.MDB"
                        Case "RUTACOMPLETA"
                            Conexion.ConnectionString = CadenaTipoBD & "DATA SOURCE=" & RutaDeBBDD
                        Case Else
                            Conexion.ConnectionString = CadenaTipoBD & "DATA SOURCE=" & RutaDeBBDD & "\" & cEmpresa & "DATOS.MDB"
                    End Select
                    Conexion = New OleDbConnection(Conexion.ConnectionString)

                Case "SQL2005"
                    Conexion.ConnectionString = CadenaTipoBD & "Initial Catalog=" &
                                        IIf(cEmpresa = "COMUN", "COMUNSQL;", cEmpresa & "DATSQL;")
            End Select
            Conexion.Open()
            AbrirBaseDatos = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function CargarDataSet(ByVal TextoComando As String, Conexion As IDbConnection) As DataSet
        Dim ds = New DataSet()

        Try
            Select Case VersionBBDD
                Case "", "ACCESS2000", "ACCESS2007", "ACCESS2013"
                    'Dim ComandoOleDb As New OleDbCommand()
                    'Dim DataAdapterOleDb As OleDbDataAdapter

                    'ComandoOleDb.CommandText = TextoComando
                    'ComandoOleDb.CommandType = CommandType.Text
                    'ComandoOleDb.Connection = CType(Conexion, OleDbConnection)
                    ''    ComandoOleDb.Parameters.Add("@Codigo", OleDb.OleDbType.VarChar)
                    ''    ComandoOleDb.Parameters("@Codigo").Value = ""
                    'DataAdapterOleDb = New OleDbDataAdapter(ComandoOleDb)
                    'DataAdapterOleDb.Fill(ds)

                    If TypeOf Conexion Is OleDbConnection Then
                        Dim ComandoOleDb As New OleDbCommand(TextoComando, CType(Conexion, OleDbConnection))
                        Dim DataAdapterOleDb As New OleDbDataAdapter(ComandoOleDb)
                        DataAdapterOleDb.Fill(ds)
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo OleDbConnection.")
                    End If

                Case "SQLSERVER", "SQL2005"

                    'Dim ComandoSql As New SqlClient.SqlCommand
                    'Dim DataAdapterSql As SqlClient.SqlDataAdapter

                    'ComandoSql.CommandText = TextoComando
                    'ComandoSql.CommandType = CommandType.Text
                    'ComandoSql.Connection = CType(Conexion, SqlConnection)
                    ''    ComandoSql.Parameters.Add("@Codigo",sqlclient.sqltype.VarChar)
                    ''    ComandoSql.Parameters("@Codigo").Value = ""
                    'DataAdapterSql = New SqlClient.SqlDataAdapter(ComandoSql)
                    'CargarDataSet = New DataSet()
                    'DataAdapterSql.Fill(ds)
            End Select
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

        Return ds
    End Function

    Public Function CargarDataSet(
    ByVal TextoComando As String,
    ByVal Conexion As IDbConnection,
    ByVal ParamArray Parametros() As Object
) As DataSet
        Dim ds = New DataSet()

        Try
            If Conexion.State <> ConnectionState.Open Then
                Conexion.Open()
            End If

            Select Case VersionBBDD
                Case "", "ACCESS2000", "ACCESS2007", "ACCESS2013"
                    If TypeOf Conexion Is OleDbConnection Then
                        Using ComandoOleDb As New OleDbCommand(TextoComando, CType(Conexion, OleDbConnection))
                            ' Si hay parámetros, agregarlos
                            If Parametros IsNot Nothing AndAlso Parametros.Length > 0 Then
                                For Each param In Parametros
                                    Dim oleParam As New OleDbParameter("?", OleDbType.VarWChar) With {
                                        .Value = If(param, DBNull.Value)
                                    }
                                    ComandoOleDb.Parameters.Add(oleParam)
                                Next
                            End If

                            Using DataAdapterOleDb As New OleDbDataAdapter(ComandoOleDb)
                                DataAdapterOleDb.Fill(ds)
                            End Using
                        End Using
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo OleDbConnection.")
                    End If

                Case "SQLSERVER", "SQL2005"
                    If TypeOf Conexion Is SqlConnection Then
                        Using ComandoSql As New SqlCommand(TextoComando, CType(Conexion, SqlConnection))
                            ' Si hay parámetros, agregarlos
                            If Parametros IsNot Nothing AndAlso Parametros.Length > 0 Then
                                For Each param In Parametros
                                    Dim sqlParam As New SqlParameter With {
                                        .Value = If(param, DBNull.Value)
                                    }
                                    ComandoSql.Parameters.Add(sqlParam)
                                Next
                            End If

                            Using DataAdapterSql As New SqlDataAdapter(ComandoSql)
                                DataAdapterSql.Fill(ds)
                            End Using
                        End Using
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo SqlConnection.")
                    End If
            End Select
        Catch ex As Exception
            MsgBox("Error al cargar DataSet: " & ex.Message & vbCrLf & "Consulta: " & TextoComando)
            ' Considera lanzar la excepción en lugar de solo mostrar un mensaje
            Throw
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try

        Return ds
    End Function

    Public Function ExecuteNonQuery(
    ByVal TextoComando As String,
    ByVal Conexion As IDbConnection,
    ByVal ParamArray Parametros() As Object
) As Integer
        Dim affectedRows As Integer = 0

        Try
            If Conexion.State <> ConnectionState.Open Then
                Conexion.Open()
            End If

            Select Case VersionBBDD
                Case "", "ACCESS2000", "ACCESS2007", "ACCESS2013"
                    If TypeOf Conexion Is OleDbConnection Then
                        Using ComandoOleDb As New OleDbCommand(TextoComando, CType(Conexion, OleDbConnection))
                            ' Si hay parámetros, agregarlos
                            If Parametros IsNot Nothing AndAlso Parametros.Length > 0 Then
                                For Each param In Parametros
                                    Dim oleParam As New OleDbParameter("?", OleDbType.VarWChar) With {
                                    .Value = If(param, DBNull.Value)
                                }
                                    ComandoOleDb.Parameters.Add(oleParam)
                                Next
                            End If

                            affectedRows = ComandoOleDb.ExecuteNonQuery()
                        End Using
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo OleDbConnection.")
                    End If

                Case "SQLSERVER", "SQL2005"
                    If TypeOf Conexion Is SqlConnection Then
                        Using ComandoSql As New SqlCommand(TextoComando, CType(Conexion, SqlConnection))
                            ' Si hay parámetros, agregarlos
                            If Parametros IsNot Nothing AndAlso Parametros.Length > 0 Then
                                For Each param In Parametros
                                    Dim sqlParam As New SqlParameter With {
                                    .Value = If(param, DBNull.Value)
                                }
                                    ComandoSql.Parameters.Add(sqlParam)
                                Next
                            End If

                            affectedRows = ComandoSql.ExecuteNonQuery()
                        End Using
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo SqlConnection.")
                    End If
            End Select
        Catch ex As Exception
            MsgBox("Error al ejecutar comando: " & ex.Message & vbCrLf & "Consulta: " & TextoComando)
            ' Considera lanzar la excepción en lugar de solo mostrar un mensaje
            Throw
        Finally
            If Conexion.State = ConnectionState.Open Then
                Conexion.Close()
            End If
        End Try

        Return affectedRows
    End Function

    Public Function CargarDataTable(ByVal TextoComando As String, Conexion As IDbConnection) As DataTable
        Dim dt = New DataTable()

        Try
            Select Case VersionBBDD
                Case "", "ACCESS2000", "ACCESS2007", "ACCESS2013"

                    If TypeOf Conexion Is OleDbConnection Then
                        Dim ComandoOleDb As New OleDbCommand(TextoComando, CType(Conexion, OleDbConnection))
                        Dim DataAdapterOleDb As New OleDbDataAdapter(ComandoOleDb)
                        DataAdapterOleDb.Fill(dt)
                    Else
                        Throw New InvalidCastException("La conexión no es de tipo OleDbConnection.")
                    End If

                Case "SQLSERVER", "SQL2005"

                    'Dim ComandoSql As New SqlClient.SqlCommand
                    'Dim DataAdapterSql As SqlClient.SqlDataAdapter

                    'ComandoSql.CommandText = TextoComando
                    'ComandoSql.CommandType = CommandType.Text
                    'ComandoSql.Connection = CType(Conexion, SqlConnection)
                    ''    ComandoSql.Parameters.Add("@Codigo",sqlclient.sqltype.VarChar)
                    ''    ComandoSql.Parameters("@Codigo").Value = ""
                    'DataAdapterSql = New SqlClient.SqlDataAdapter(ComandoSql)
                    'CargarDataSet = New DataSet()
                    'DataAdapterSql.Fill(ds)
            End Select
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

        Return dt
    End Function

    Public Sub GeneraFiltro(ByRef Filtro As String, ByVal Texto As String, Optional Operador As String = "AND")
        If Filtro = "" Then
            Filtro = " Where " & Texto
        Else
            Filtro = Filtro & " " & Operador & " " & Texto
        End If
    End Sub

    Public Function FechaSelect(ByVal QueFecha As String) As String
        FechaSelect = "#" & Format$(CDate(QueFecha), "MM-dd-yy") & "#"
    End Function

    Public Function FiltroFecha(ByVal Campo As String, QueFecha As String, Optional SentidoFiltro As String = "") As String
        FiltroFecha = " DateDiff('d'," & FechaSelect(QueFecha) & "," & Campo & ") "
        Select Case UCase(SentidoFiltro)
            Case "I"        ' Inicio / Desde
                FiltroFecha = FiltroFecha & ">=0 "
            Case "="        ' Igual
                FiltroFecha = FiltroFecha & "=0 "
            Case "F"        ' Fin / Hasta
                FiltroFecha = FiltroFecha & "<=0 "
        End Select
    End Function

    Public Function IsNullSelect(ByVal Campo As String, Optional Negacion As Boolean = False) As String
        Select Case VersionBBDD
            Case "SQL2005"
                If Negacion Then
                    IsNullSelect = Campo & " IS NOT NULL "
                Else
                    IsNullSelect = Campo & " IS NULL "
                End If
            Case Else
                If Negacion Then
                    IsNullSelect = "NOT ISNULL(" & Campo & ") "
                Else
                    IsNullSelect = "ISNULL(" & Campo & ") "
                End If
        End Select
    End Function
End Module

