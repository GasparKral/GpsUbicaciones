''' <summary>
''' Extensión para ejecutar transacciones por bloque de manera independiente
''' </summary>
Public Class TransactionBlockExecutor
    Implements IDisposable

    Private ReadOnly _operacion As DatabaseOperation
    Private ReadOnly _connection As IDbConnection
    Private ReadOnly _transaction As IDbTransaction
    Private ReadOnly _isExternalTransaction As Boolean
    Private _disposed As Boolean = False
    Private _completed As Boolean = False

    ''' <summary>
    ''' Constructor que crea una nueva conexión y transacción
    ''' </summary>
    ''' <param name="operacion">Operación de base de datos</param>
    Public Sub New(operacion As DatabaseOperation)
        _operacion = operacion
        _connection = _operacion.CreateConnection()
        _connection.Open()
        _transaction = _connection.BeginTransaction()
        _isExternalTransaction = False
    End Sub

    ''' <summary>
    ''' Constructor que usa una conexión y transacción existente
    ''' </summary>
    ''' <param name="operacion">Operación de base de datos</param>
    ''' <param name="connection">Conexión existente</param>
    ''' <param name="transaction">Transacción existente</param>
    Public Sub New(operacion As DatabaseOperation, connection As IDbConnection, transaction As IDbTransaction)
        If operacion Is Nothing Then Throw New ArgumentNullException(NameOf(operacion))
        If connection Is Nothing Then Throw New ArgumentNullException(NameOf(connection))
        If transaction Is Nothing Then Throw New ArgumentNullException(NameOf(transaction))

        _operacion = operacion
        _connection = connection
        _transaction = transaction
        _isExternalTransaction = True
    End Sub

    ''' <summary>
    ''' Ejecuta un bloque de operaciones dentro de la transacción
    ''' </summary>
    ''' <param name="transactionBlock">Bloque de operaciones a ejecutar</param>
    ''' <returns>True si se ejecutó correctamente</returns>
    Public Function ExecuteTransactionBlock(transactionBlock As Action(Of IDbConnection, IDbTransaction)) As Boolean
        Try
            transactionBlock.Invoke(_connection, _transaction)
            _completed = True
            Return True
        Catch ex As Exception
            If Not _isExternalTransaction Then
                Try
                    _transaction.Rollback()
                    _completed = False
                Catch
                    ' Ignorar errores de rollback
                End Try
            End If
            Throw ' Re-lanzar para manejo externo
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta un bloque de operaciones y maneja automáticamente el commit/rollback
    ''' </summary>
    ''' <param name="transactionBlock">Bloque de operaciones a ejecutar</param>
    ''' <param name="autoCommit">Si debe hacer commit automáticamente</param>
    ''' <returns>True si se ejecutó correctamente</returns>
    Public Function ExecuteTransactionBlock(transactionBlock As Action(Of IDbConnection, IDbTransaction), autoCommit As Boolean) As Boolean
        Try
            transactionBlock.Invoke(_connection, _transaction)

            If autoCommit AndAlso Not _isExternalTransaction Then
                _transaction.Commit()
                _completed = True
            End If

            Return True
        Catch ex As Exception
            If Not _isExternalTransaction Then
                Try
                    _transaction.Rollback()
                    _completed = False
                Catch
                    ' Ignorar errores de rollback
                End Try
            End If
            Throw ' Re-lanzar para manejo externo
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta múltiples bloques de operaciones en secuencia
    ''' </summary>
    ''' <param name="transactionBlocks">Array de bloques de operaciones</param>
    ''' <returns>True si todos se ejecutaron correctamente</returns>
    Public Function ExecuteTransactionBlocks(ParamArray transactionBlocks As Action(Of IDbConnection, IDbTransaction)()) As Boolean
        Try
            For Each block In transactionBlocks
                block.Invoke(_connection, _transaction)
            Next
            _completed = True
            Return True
        Catch ex As Exception
            If Not _isExternalTransaction Then
                Try
                    _transaction.Rollback()
                    _completed = False
                Catch
                    ' Ignorar errores de rollback
                End Try
            End If
            Throw ' Re-lanzar para manejo externo
        End Try
    End Function

    ''' <summary>
    ''' Confirma la transacción (solo si somos dueños de ella)
    ''' </summary>
    Public Sub Commit()
        If Not _isExternalTransaction AndAlso Not _completed Then
            _transaction.Commit()
            _completed = True
        End If
    End Sub

    ''' <summary>
    ''' Hace rollback de la transacción (solo si somos dueños de ella)
    ''' </summary>
    Public Sub Rollback()
        If Not _isExternalTransaction AndAlso Not _completed Then
            _transaction.Rollback()
            _completed = False
        End If
    End Sub

    ''' <summary>
    ''' Propiedades de solo lectura para acceder a los recursos
    ''' </summary>
    Public ReadOnly Property Connection As IDbConnection
        Get
            Return _connection
        End Get
    End Property

    Public ReadOnly Property Transaction As IDbTransaction
        Get
            Return _transaction
        End Get
    End Property

    Public ReadOnly Property IsExternalTransaction As Boolean
        Get
            Return _isExternalTransaction
        End Get
    End Property

    Public ReadOnly Property IsCompleted As Boolean
        Get
            Return _completed
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        If Not _disposed Then
            If Not _isExternalTransaction Then
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
            End If
            _disposed = True
        End If
    End Sub
End Class