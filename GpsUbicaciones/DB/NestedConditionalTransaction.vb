Public Class NestedConditionalTransaction
    Implements IDisposable

    Private ReadOnly _operacion As DatabaseOperation
    Private ReadOnly _connection As IDbConnection
    Private ReadOnly _transaction As IDbTransaction
    Private _disposed As Boolean = False
    Private _completed As Boolean = False

    Public Sub New(operacion As DatabaseOperation)
        _operacion = operacion
        _connection = _operacion.CreateConnection()
        _connection.Open()
        _transaction = _connection.BeginTransaction()
    End Sub

    ''' <summary>
    ''' Ejecuta una transacción condicional basada en el resultado de una consulta.
    ''' </summary>
    ''' <param name="conditionQuery">Consulta que retorna un valor booleano.</param>
    ''' <param name="ifTrueAction">Acción si el resultado de la consulta es verdadero.</param>
    ''' <param name="ifFalseAction">Acción si el resultado es falso.</param>
    ''' <param name="parameters">Parámetros de la consulta.</param>
    ''' <returns>True si se ejecutó correctamente, False si hubo error (y se hizo rollback).</returns>
    Public Function ExecuteConditionalTransaction(conditionQuery As String,
                                                 ifTrueAction As Action(Of IDbConnection),
                                                 ifFalseAction As Action(Of IDbConnection),
                                                 ParamArray parameters() As Object) As Boolean
        Try
            Dim conditionResult As Boolean = _operacion.ExecuteScalar(_connection, _transaction, conditionQuery, parameters)

            If conditionResult Then
                ifFalseAction.Invoke(_connection)
            Else
                ifTrueAction.Invoke(_connection)
            End If

            _completed = True
            Return True
        Catch ex As Exception
            Try
                _transaction.Rollback()
            Catch
                ' Ignorar errores de rollback
            End Try
            Return False
        End Try
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If Not _disposed Then
            If Not _completed Then
                Try
                    _transaction.Rollback()
                Catch
                    ' Puede fallar si la transacción ya fue terminada
                End Try
            End If

            _transaction.Dispose()
            _connection.Close()
            _connection.Dispose()
            _disposed = True
        End If
    End Sub
End Class
