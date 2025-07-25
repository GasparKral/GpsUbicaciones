﻿Imports System.Data.OleDb

Public Class AccessDatabaseOperation
    Inherits DatabaseOperation

    Private Shared ReadOnly Logger As Logger = Logger.Instance

    Public Sub New(settings As DatabaseSettings)
        MyBase.New(settings)
        Logger.Debug($"Inicializando AccessDatabaseOperation con proveedor: {settings.Provider}")
    End Sub

    Public Overrides Function CreateConnection(Optional company As String = "ACTIVA", Optional dataPath As String = "PRINCIPAL") As IDbConnection
        Dim connectionString = BuildConnectionString(company, dataPath)
        Logger.Debug($"Creando conexión para empresa: {company}, ruta: {dataPath}")
        Return New OleDbConnection(connectionString)
    End Function

    Public Overrides Function ExecuteQuery(commandText As String, ParamArray parameters() As Object) As DataSet
        Using connection = CreateConnection()
            Return ExecuteQuery(connection, commandText, parameters)
        End Using
    End Function

    Public Overrides Function ExecuteQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataSet
        Dim ds = New DataSet()
        Logger.Debug($"Ejecutando consulta: {commandText.Substring(0, Math.Min(100, commandText.Length))}...")

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                AddParameters(cmd, parameters)

                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(ds)
                End Using
            End Using

            Logger.Debug($"Consulta ejecutada exitosamente. Tablas devueltas: {ds.Tables.Count}")
            Return ds
        Catch ex As Exception
            Logger.Error($"Error ejecutando consulta: {commandText}", ex)
            Throw New DatabaseOperationException("Error al ejecutar consulta", ex, commandText)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

    Public Overrides Function ExecuteNonQuery(commandText As String, ParamArray parameters() As Object) As Integer
        Using connection = CreateConnection()
            Return ExecuteNonQuery(connection, commandText, parameters)
        End Using
    End Function

    Public Overrides Function ExecuteNonQuery(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As Integer
        Logger.Debug($"Ejecutando comando NonQuery: {commandText.Substring(0, Math.Min(100, commandText.Length))}...")
        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                AddParameters(cmd, parameters)
                Dim rowsAffected = cmd.ExecuteNonQuery()
                Logger.Debug($"Comando ejecutado exitosamente. Filas afectadas: {rowsAffected}")
                Return rowsAffected
            End Using
        Catch ex As Exception
            Logger.Error($"Error ejecutando comando: {commandText}", ex)
            Throw New DatabaseOperationException("Error al ejecutar comando", ex, commandText)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

    Public Overrides Function ExecuteTable(commandText As String, ParamArray parameters() As Object) As DataTable
        Using connection = CreateConnection()
            Return ExecuteTable(connection, commandText, parameters)
        End Using
    End Function

    Public Overrides Function ExecuteTable(connection As IDbConnection, commandText As String, ParamArray parameters() As Object) As DataTable
        Dim dt = New DataTable()

        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                AddParameters(cmd, parameters)

                Using adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            Return dt
        Catch ex As Exception
            Throw New DatabaseOperationException("Error al cargar tabla", ex, commandText, parameters)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

    Private Sub AddParameters(cmd As OleDbCommand, parameters() As Object)
        If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
            For Each param In parameters
                Dim oleParam As New OleDbParameter()

                If param Is Nothing Then
                    oleParam.Value = DBNull.Value
                    oleParam.OleDbType = OleDbType.VarWChar
                Else
                    ' Detectar el tipo y asignar el OleDbType correcto
                    Select Case param.GetType()
                        Case GetType(DateTime), GetType(Date)
                            oleParam.OleDbType = OleDbType.Date
                            oleParam.Value = param
                        Case GetType(Integer)
                            oleParam.OleDbType = OleDbType.Integer
                            oleParam.Value = param
                        Case GetType(Double), GetType(Decimal)
                            oleParam.OleDbType = OleDbType.Double
                            oleParam.Value = param
                        Case GetType(Boolean)
                            oleParam.OleDbType = OleDbType.Boolean
                            oleParam.Value = param
                        Case Else
                            oleParam.OleDbType = OleDbType.VarWChar
                            oleParam.Value = param.ToString()
                    End Select
                End If

                cmd.Parameters.Add(oleParam)
            Next
        End If
    End Sub


    Public Overrides Function ExecuteScalar(commandText As String, ParamArray parameters() As Object) As Boolean
        Using connection = CreateConnection()
            connection.Open()
            Return ExecuteScalar(connection, connection.BeginTransaction, commandText, parameters)
        End Using
    End Function


    Public Overrides Function ExecuteScalar(connection As IDbConnection, transaction As IDbTransaction, commandText As String, ParamArray parameters() As Object) As Boolean
        Try
            If connection.State <> ConnectionState.Open Then
                connection.Open()
            End If

            Using cmd As New OleDbCommand(commandText, CType(connection, OleDbConnection))
                If transaction IsNot Nothing Then
                    cmd.Transaction = CType(transaction, OleDbTransaction)
                End If
                AddParameters(cmd, parameters)

                Dim result = cmd.ExecuteScalar()

                If result Is Nothing OrElse result Is DBNull.Value Then
                    Return False
                End If

                If TypeOf result Is Boolean Then
                    Return CBool(result)
                End If

                If TypeOf result Is Integer Then
                    Return CInt(result) <> 0 ' Access suele devolver -1/0
                End If

                ' Por si acaso, intenta convertir a Boolean
                Return Convert.ToBoolean(result)
            End Using
        Catch ex As Exception
            Throw New DatabaseOperationException("Error al ejecutar ExecuteScalar", ex, commandText)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Function

End Class