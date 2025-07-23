Public Class RepositorioMovPDA

    Public Shared Function ObtenerMovimientosPDA() As DataTable
        Try
            Return Operacion.ExecuteTable("Select MOVPDA.*, ARTICULOS.NombreComercial FROM MovPda INNER JOIN ARTICULOS ON MovPda.Articulo = Articulos.Codigo " &
                                          "WHERE Terminal = ? ORDER BY Operacion,Articulo", Terminal)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en la consulta a la base de datos: {ex.Message}")
        End Try
        Return Nothing
    End Function

    Public Shared Function ObtenerTraspasosPDA() As DataTable
        Try
            Return Operacion.ExecuteTable("SELECT * FROM MOVPDA WHERE TERMINAL = ? And OPERACION = 'TR'", Terminal)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en la consulta a la base de datos: {ex.Message}")
        End Try
        Return Nothing
    End Function

    Public Shared Function ObtenerSeleccionesPDA() As DataTable
        Try
            Return Operacion.ExecuteTable("SELECT * FROM MOVPDA WHERE Terminal = ? AND Operacion ='SE'", Terminal)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en la consulta a la base de datos: {ex.Message}")
        End Try
        Return Nothing
    End Function

    Public Shared Function ObtenerVentasPDA() As DataTable
        Try
            Return Operacion.ExecuteTable("SELECT * FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = 'VE'", Terminal)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error en la consulta a la base de datos: {ex.Message}")
        End Try
        Return Nothing
    End Function

    Public Shared Sub InsertarOperacionPDA(TipoOperacion As TypeOperacion, CodigoArticulo As String, Cantidad As Single, CodigoUbicacion As String)
        Try
            Operacion.ExecuteNonQuery("INSERT INTO MOVPDA VALUES(?,?,?,?,?)", Terminal, ObtenerCodigo(TipoOperacion), CodigoArticulo, Cantidad, CodigoUbicacion)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al insertar Operacion de tipo {ObtenerCodigo(TipoOperacion)}: {ex.Message}")
        End Try
    End Sub

    Public Shared Sub EliminarOperacionPDA(TipoOperacion As TypeOperacion, CodigoArticulo As String, Cantidad As Single, CodigoUbicacion As String)
        Try
            Operacion.ExecuteNonQuery(
                    "DELETE FROM MovPda WHERE Terminal = ? AND Operacion = ? AND Articulo = ? AND Cantidad = ? AND Lote = ?", Terminal, ObtenerCodigo(TipoOperacion), CodigoArticulo, Cantidad, CodigoUbicacion)
        Catch ex As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Error, $"Error al eliminar Operacion de tipo {ObtenerCodigo(TipoOperacion)}: {ex.Message}")
        End Try
    End Sub

    ' ================================================================================================
    ' NUEVOS MÉTODOS CON SOPORTE PARA TRANSACCIONES
    ' ================================================================================================

    ''' <summary>
    ''' Inserta una operación PDA usando una conexión y transacción específica
    ''' </summary>
    Public Shared Function InsertarOperacionPDA(connection As IDbConnection,
                                               transaction As IDbTransaction,
                                               terminal As String,
                                               tipoOperacion As TypeOperacion,
                                               codigoArticulo As String,
                                               cantidad As Single,
                                               codigoUbicacion As String) As Integer
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)
            If operacionExtendida IsNot Nothing Then
                Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                    "INSERT INTO MOVPDA (TERMINAL, OPERACION, ARTICULO, CANTIDAD, LOTE) VALUES(?,?,?,?,?)",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, cantidad, codigoUbicacion)
            Else
                Return Operacion.ExecuteNonQuery(connection,
                    "INSERT INTO MOVPDA (TERMINAL, OPERACION, ARTICULO, CANTIDAD, LOTE) VALUES(?,?,?,?,?)",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, cantidad, codigoUbicacion)
            End If
        Catch ex As Exception
            Logger.Instance.Error($"Error al insertar operación PDA con transacción: {ex.Message}", ex)
            Throw New DatabaseOperationException("Error al insertar operación PDA", ex, "INSERT MOVPDA")
        End Try
    End Function

    ''' <summary>
    ''' Elimina una operación PDA específica usando una conexión y transacción
    ''' </summary>
    Public Shared Function EliminarOperacionPDA(connection As IDbConnection,
                                               transaction As IDbTransaction,
                                               terminal As String,
                                               tipoOperacion As TypeOperacion,
                                               codigoArticulo As String,
                                               cantidad As Single,
                                               codigoUbicacion As String) As Integer
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)
            If operacionExtendida IsNot Nothing Then
                Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                    "DELETE FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND CANTIDAD = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, cantidad, codigoUbicacion)
            Else
                Return Operacion.ExecuteNonQuery(connection,
                    "DELETE FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND CANTIDAD = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, cantidad, codigoUbicacion)
            End If
        Catch ex As Exception
            Logger.Instance.Error($"Error al eliminar operación PDA con transacción: {ex.Message}", ex)
            Throw New DatabaseOperationException("Error al eliminar operación PDA", ex, "DELETE MOVPDA")
        End Try
    End Function

    ''' <summary>
    ''' Elimina todas las operaciones PDA de un artículo en una ubicación específica
    ''' </summary>
    Public Shared Function EliminarTodasOperacionesPorArticuloUbicacion(connection As IDbConnection,
                                                                       transaction As IDbTransaction,
                                                                       terminal As String,
                                                                       tipoOperacion As TypeOperacion,
                                                                       codigoArticulo As String,
                                                                       codigoUbicacion As String) As Integer
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)
            If operacionExtendida IsNot Nothing Then
                Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                    "DELETE FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)
            Else
                Return Operacion.ExecuteNonQuery(connection,
                    "DELETE FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)
            End If
        Catch ex As Exception
            Logger.Instance.Error($"Error al eliminar todas las operaciones PDA: {ex.Message}", ex)
            Throw New DatabaseOperationException("Error al eliminar operaciones PDA por artículo/ubicación", ex, "DELETE ALL MOVPDA")
        End Try
    End Function

    ''' <summary>
    ''' Actualiza la cantidad de una operación PDA específica
    ''' </summary>
    Public Shared Function ActualizarCantidadOperacionPDA(connection As IDbConnection,
                                                         transaction As IDbTransaction,
                                                         terminal As String,
                                                         tipoOperacion As TypeOperacion,
                                                         codigoArticulo As String,
                                                         codigoUbicacion As String,
                                                         nuevaCantidad As Single) As Integer
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)
            If operacionExtendida IsNot Nothing Then
                Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                    "UPDATE MOVPDA SET CANTIDAD = ? WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    nuevaCantidad, terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)
            Else
                Return Operacion.ExecuteNonQuery(connection,
                    "UPDATE MOVPDA SET CANTIDAD = ? WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    nuevaCantidad, terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)
            End If
        Catch ex As Exception
            Logger.Instance.Error($"Error al actualizar cantidad en operación PDA: {ex.Message}", ex)
            Throw New DatabaseOperationException("Error al actualizar cantidad PDA", ex, "UPDATE MOVPDA")
        End Try
    End Function

    ''' <summary>
    ''' Obtiene la cantidad total de un artículo en una ubicación específica
    ''' </summary>
    Public Shared Function ObtenerCantidadTotalPorArticuloUbicacion(connection As IDbConnection,
                                                                   transaction As IDbTransaction,
                                                                   terminal As String,
                                                                   tipoOperacion As TypeOperacion,
                                                                   codigoArticulo As String,
                                                                   codigoUbicacion As String) As Single
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)
            Dim result As Object

            If operacionExtendida IsNot Nothing Then
                Dim ds = operacionExtendida.ExecuteQuery(connection, transaction,
                    "SELECT ISNULL(SUM(CANTIDAD), 0) AS Total FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)

                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    result = ds.Tables(0).Rows(0)("Total")
                Else
                    result = 0
                End If
            Else
                Dim ds = Operacion.ExecuteQuery(connection,
                    "SELECT ISNULL(SUM(CANTIDAD), 0) AS Total FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? AND ARTICULO = ? AND LOTE = ?",
                    terminal, ObtenerCodigo(tipoOperacion), codigoArticulo, codigoUbicacion)

                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    result = ds.Tables(0).Rows(0)("Total")
                Else
                    result = 0
                End If
            End If

            Return If(result Is Nothing OrElse result Is DBNull.Value, 0, Convert.ToSingle(result))
        Catch ex As Exception
            Logger.Instance.Error($"Error al obtener cantidad total PDA: {ex.Message}", ex)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Ejecuta múltiples operaciones PDA en una sola transacción
    ''' </summary>
    Public Shared Function ExecutarOperacionesMultiplesPDA(connection As IDbConnection,
                                                          transaction As IDbTransaction,
                                                          terminal As String,
                                                          operaciones As List(Of OperacionPDAInfo)) As Integer
        Dim totalOperaciones As Integer = 0

        Try
            For Each _Operacion In operaciones
                Select Case _Operacion.TipoAccion
                    Case "INSERTAR"
                        totalOperaciones += InsertarOperacionPDA(connection, transaction, terminal,
                            _Operacion.TipoOperacion, _Operacion.CodigoArticulo, _Operacion.Cantidad, _Operacion.CodigoUbicacion)

                    Case "ELIMINAR"
                        totalOperaciones += EliminarOperacionPDA(connection, transaction, terminal,
                            _Operacion.TipoOperacion, _Operacion.CodigoArticulo, _Operacion.Cantidad, _Operacion.CodigoUbicacion)

                    Case "ELIMINAR_TODOS"
                        totalOperaciones += EliminarTodasOperacionesPorArticuloUbicacion(connection, transaction, terminal,
                            _Operacion.TipoOperacion, _Operacion.CodigoArticulo, _Operacion.CodigoUbicacion)

                    Case "ACTUALIZAR"
                        totalOperaciones += ActualizarCantidadOperacionPDA(connection, transaction, terminal,
                            _Operacion.TipoOperacion, _Operacion.CodigoArticulo, _Operacion.CodigoUbicacion, _Operacion.Cantidad)

                    Case Else
                        Logger.Instance.Warning($"Tipo de acción desconocido: {_Operacion.TipoAccion}")
                End Select
            Next

            Logger.Instance.Debug($"Ejecutadas {totalOperaciones} operaciones PDA en transacción")
            Return totalOperaciones

        Catch ex As Exception
            Logger.Instance.Error($"Error ejecutando operaciones múltiples PDA: {ex.Message}", ex)
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Sincroniza operaciones PDA - Útil para verificar consistencia
    ''' </summary>
    Public Shared Function SincronizarOperacionesPDA(connection As IDbConnection,
                                                    transaction As IDbTransaction,
                                                    terminal As String,
                                                    tipoOperacion As TypeOperacion) As DataTable
        Try
            Dim operacionExtendida = New AccessDatabaseOperationExtended(settings)

            If operacionExtendida IsNot Nothing Then
                Return operacionExtendida.ExecuteTable(connection, transaction,
                    "SELECT * FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? ORDER BY ARTICULO, LOTE",
                    terminal, ObtenerCodigo(tipoOperacion))
            Else
                Return Operacion.ExecuteTable(connection,
                    "SELECT * FROM MOVPDA WHERE TERMINAL = ? AND OPERACION = ? ORDER BY ARTICULO, LOTE",
                    terminal, ObtenerCodigo(tipoOperacion))
            End If
        Catch ex As Exception
            Logger.Instance.Error($"Error al sincronizar operaciones PDA: {ex.Message}", ex)
            Throw New DatabaseOperationException("Error al sincronizar operaciones PDA", ex, "SELECT MOVPDA")
        End Try
    End Function

    ' ================================================================================================
    ' CLASES DE APOYO Y ENUMERACIONES
    ' ================================================================================================

    Public Enum TypeOperacion
        VENTA
        TRASPASO
        SELECCION
    End Enum

    Private Shared Function ObtenerCodigo(op As TypeOperacion) As String
        Select Case op
            Case TypeOperacion.VENTA
                Return "VE"
            Case TypeOperacion.TRASPASO
                Return "TR"
            Case TypeOperacion.SELECCION
                Return "SE"
            Case Else
                Return String.Empty
        End Select
    End Function

End Class

''' <summary>
''' Información de una operación PDA para ejecución en lote
''' </summary>
Public Class OperacionPDAInfo
    Public Property TipoAccion As String ' "INSERTAR", "ELIMINAR", "ELIMINAR_TODOS", "ACTUALIZAR"
    Public Property TipoOperacion As RepositorioMovPDA.TypeOperacion
    Public Property CodigoArticulo As String
    Public Property CodigoUbicacion As String
    Public Property Cantidad As Single
    Public Property CantidadAnterior As Single = 0 ' Para operaciones de actualización
End Class