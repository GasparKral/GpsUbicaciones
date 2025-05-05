Public Class NestedConditionalTransaction
    Implements IDisposable
    Private ReadOnly _dbOperation As DatabaseOperation
    Private ReadOnly _connection As IDbConnection
    Private _transaction As IDbTransaction
    Private _transactionLevel As Integer = 0

    Public Sub New(dbOperation As DatabaseOperation)
        _dbOperation = dbOperation
        _connection = dbOperation.CreateConnection()
    End Sub

    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
        Dispose()
    End Sub

    Public Sub BeginTransaction()
        If _transactionLevel = 0 Then
            _connection.Open()
            _transaction = _connection.BeginTransaction()
        End If
        _transactionLevel += 1
    End Sub

    Public Function ExecuteConditionalTransaction(conditionQuery As String,
                                               ifTrueAction As Action(Of IDbTransaction),
                                               ifFalseAction As Action(Of IDbTransaction),
                                               ParamArray conditionParams() As Object) As Boolean
        BeginTransaction()

        Try
            ' Ejecutar consulta condicional
            Dim result = _dbOperation.ExecuteTable(_connection, conditionQuery, _transaction, conditionParams)

            ' Decidir qué acción tomar
            If result.Rows.Count = 0 Then
                ifTrueAction.Invoke(_transaction)
            Else
                ifFalseAction.Invoke(_transaction)
            End If

            Return True
        Catch ex As Exception
            Rollback()
            Throw New DatabaseOperationException("Error en transacción condicional", ex, conditionQuery)
        Finally
            Commit(False) ' False indica que no cerramos la conexión todavía
        End Try
    End Function

    Public Sub Commit(closeConnection As Boolean)
        _transactionLevel -= 1
        If _transactionLevel = 0 Then
            _transaction?.Commit()
            If closeConnection Then
                _connection.Close()
            End If
        End If
    End Sub

    Public Sub Rollback()
        If _transactionLevel > 0 Then
            _transactionLevel = 0
            _transaction?.Rollback()
            _connection.Close()
        End If
    End Sub

    Public Sub Dispose()
        If _transactionLevel > 0 Then
            Rollback()
        End If
        _transaction?.Dispose()
        _connection.Dispose()
    End Sub


End Class