Imports System.ComponentModel

Public Class RepositorioStockLote
    ''' <summary>
    ''' Verifica si hay existencias de un'articleo en una ubicación
    ''' </summary>
    ''' <param name="CodigoArticulo"></param>
    ''' <param name="CodigoUbicacion"></param>
    ''' <returns>True si hay existencias, False en caso contrario</returns>
    Public Shared Function HayExistencias(CodigoArticulo As String, CodigoUbicacion As String) As Boolean
        Return Convert.ToBoolean(Operacion.ExecuteScalar(Querys.Select.VerificarExistenciaLoteDeArticulo, CodigoArticulo, CodigoUbicacion))
    End Function

    Public Shared Function ObtenerArticulosEnLote(CodigoLote As String) As BindingList(Of StockLote)
        Dim stockLotes As New BindingList(Of StockLote)
        Using dsDatos = Operacion.ExecuteQuery(Querys.Select.ConsultarArticulosEnUbicacion, CodigoLote, Almacen).Tables(0)
            For Each row As DataRow In dsDatos.Rows
                Dim stockLote As New StockLote With {
                .Articulo = New Articulo With {
                    .Codigo = row("CodigoArticulo"),
                    .NombreComercial = row("NombreArticulo"),
                    .PorPeso = Convert.ToBoolean(row("PorPeso")),
                    .CodigoBarras = row("CodBarras"),
                    .ReferenciaProvedor = row("RefProveedor"),
                    .Foto = row("RutaFoto"),
                    .StockTotal = row("StockTotal")
                },
                .Lote = New Ubicacion With {
                    .Identificador = row("CodigoUbicacion"),
                    .Nombre = row("NombreUbicacion"),
                    .Almacen = row("CodigoAlmacen"),
                    .NombreAlmacen = row("NombreAlmacen")
                },
                .UnidadesIniciales = Convert.ToSingle(row("UnidadesIniciales")),
                .UnidadesCompradas = Convert.ToSingle(row("UnidadesCompradas")),
                .UnidadesVendidas = Convert.ToSingle(row("UnidadesVendidas")),
                .UnidadesTransferidas = Convert.ToSingle(row("UnidadesTransferidas"))
            }
                stockLotes.Add(stockLote)
            Next
            Return stockLotes
        End Using
    End Function

    Public Shared Function ObtenerArticuloEnLote(CodigoArticulo As String, CodigoLote As String) As StockLote
        Dim stockLote As StockLote = Nothing
        Dim parameters As Object() = {CodigoArticulo, CodigoArticulo, CodigoArticulo, CodigoLote}
        Using dsDatos = Operacion.ExecuteQuery(Querys.Select.ConsultarArticuloEnUbicacion, parameters).Tables(0)
            If dsDatos.Rows.Count > 0 Then
                Dim row As DataRow = dsDatos.Rows(0)
                stockLote = New StockLote With {
                .Articulo = New Articulo With {
                    .Codigo = row("CodigoArticulo"),
                    .NombreComercial = row("NombreArticulo"),
                    .PorPeso = Convert.ToBoolean(row("PorPeso")),
                    .CodigoBarras = row("CodBarras"),
                    .ReferenciaProvedor = row("RefProveedor"),
                    .StockTotal = row("StockTotal"),
                    .Foto = row("RutaFoto")
                },
                .Lote = New Ubicacion With {
                    .Identificador = row("CodigoUbicacion"),
                    .Nombre = row("NombreUbicacion"),
                    .Almacen = row("CodigoAlmacen"),
                    .NombreAlmacen = row("NombreAlmacen")
                },
                .UnidadesIniciales = Convert.ToSingle(row("UnidadesIniciales")),
                .UnidadesCompradas = Convert.ToSingle(row("UnidadesCompradas")),
                .UnidadesVendidas = Convert.ToSingle(row("UnidadesVendidas")),
                .UnidadesTransferidas = Convert.ToSingle(row("UnidadesTransferidas"))
            }
            Else
                Throw New InvalidOperationException("Datos no encontrados")
                Return Nothing
            End If
        End Using
        Return stockLote
    End Function

    Public Shared Function ObtenerTotalArticuloEnLotes(CodigoArticulo As String) As Single
        Return Convert.ToSingle(Operacion.ExecuteScalar(Querys.Select.ConsultarTotalArticuloEnLotes, CodigoArticulo, Almacen))
    End Function

    Public Shared Function InsertarArticulo(Connection As IDbConnection, Stock As Single, CodigoArticulo As String, CodigoUbicacion As String) As Integer

        Dim Articulo = RepositorioArticulo.ObtenerInformacion(CodigoArticulo)

        Return Operacion.ExecuteNonQuery(Connection, Querys.Insert.InsertarNuevoLoteDeArticuloEnStock,
        Articulo.Codigo, Almacen, CodigoUbicacion, Stock
        )
    End Function

    Public Shared Function InsertarArticuloDesdeStock(Connection As IDbConnection, Stock As Single, CodigoArticulo As String, CodigoUbicacionOrigen As String, CodigoUbicacionDestino As String) As Integer

        Dim Articulo = RepositorioArticulo.ObtenerInformacion(CodigoArticulo)

        Dim result = Operacion.ExecuteNonQuery(Connection, Querys.Insert.InsertarNuevoLoteDeArticuloEnStock, Articulo.Codigo, Almacen, CodigoUbicacionDestino, Stock)
        result += Operacion.ExecuteNonQuery(Connection, Querys.Update.ReducirStockEnLote, Stock, Articulo.Codigo, CodigoUbicacionOrigen)
        Return result
    End Function

    Public Shared Function AgregarStock(Connection As IDbConnection, Stock As Single, CodigoArticulo As String, CodigoUbicacion As String) As Integer
        Dim Articulo = RepositorioArticulo.ObtenerInformacion(CodigoArticulo)

        Return Operacion.ExecuteNonQuery(Connection, Querys.Update.IncrementarStockEnLote, Stock, Articulo.Codigo, CodigoUbicacion)
    End Function

    Public Shared Function TransferirStock(Connection As IDbConnection, Cantidad As Single, CodigoArticulo As String, CodigoUbicacionOrigen As String, CodigoUbicacionDestino As String) As Integer
        Dim Articulo = RepositorioArticulo.ObtenerInformacion(CodigoArticulo)

        Dim result = Operacion.ExecuteNonQuery(Connection, Querys.Update.ReducirStockEnLote, Cantidad, Articulo.Codigo, CodigoUbicacionOrigen)
        result += Operacion.ExecuteNonQuery(Connection, Querys.Update.IncrementarStockEnLote, Cantidad, Articulo.Codigo, CodigoUbicacionDestino)
        Return result
    End Function


    ''' <summary>
    ''' Inserta un artículo usando una transacción específica
    ''' </summary>
    Public Shared Function InsertarArticulo(connection As IDbConnection,
                                           transaction As IDbTransaction,
                                           stock As Single,
                                           codigoArticulo As String,
                                           codigoUbicacion As String) As Integer
        Dim articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)

        ' Usar la operación extendida que soporta transacciones
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)
        If operacionExtendida IsNot Nothing Then
            Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Insert.InsertarNuevoLoteDeArticuloEnStock,
                articulo.Codigo, Almacen, codigoUbicacion, stock)
        Else
            ' Fallback para operación normal (menos eficiente)
            Return Operacion.ExecuteNonQuery(connection,
                Querys.Insert.InsertarNuevoLoteDeArticuloEnStock,
                articulo.Codigo, Almacen, codigoUbicacion, stock)
        End If
    End Function

    ''' <summary>
    ''' Inserta artículo desde stock usando una transacción específica
    ''' </summary>
    Public Shared Function InsertarArticuloDesdeStock(connection As IDbConnection,
                                                     transaction As IDbTransaction,
                                                     stock As Single,
                                                     codigoArticulo As String,
                                                     codigoUbicacionOrigen As String,
                                                     codigoUbicacionDestino As String) As Integer
        Dim articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)

        If operacionExtendida IsNot Nothing Then
            ' Insertar en destino
            Dim result = operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Insert.InsertarNuevoLoteDeArticuloEnStock,
                articulo.Codigo, Almacen, codigoUbicacionDestino, stock)

            ' Reducir en origen
            result += operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Update.ReducirStockEnLote,
                stock, articulo.Codigo, codigoUbicacionOrigen)

            Return result
        Else
            ' Fallback para operación normal
            Dim result = Operacion.ExecuteNonQuery(connection,
                Querys.Insert.InsertarNuevoLoteDeArticuloEnStock,
                articulo.Codigo, Almacen, codigoUbicacionDestino, stock)

            result += Operacion.ExecuteNonQuery(connection,
                Querys.Update.ReducirStockEnLote,
                stock, articulo.Codigo, codigoUbicacionOrigen)

            Return result
        End If
    End Function

    ''' <summary>
    ''' Agrega stock usando una transacción específica
    ''' </summary>
    Public Shared Function AgregarStock(connection As IDbConnection,
                                       transaction As IDbTransaction,
                                       stock As Single,
                                       codigoArticulo As String,
                                       codigoUbicacion As String) As Integer
        Dim articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)

        If operacionExtendida IsNot Nothing Then
            Return operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Update.IncrementarStockEnLote,
                stock, articulo.Codigo, codigoUbicacion)
        Else
            Return Operacion.ExecuteNonQuery(connection,
                Querys.Update.IncrementarStockEnLote,
                stock, articulo.Codigo, codigoUbicacion)
        End If
    End Function

    ''' <summary>
    ''' Transfiere stock usando una transacción específica
    ''' </summary>
    Public Shared Function TransferirStock(connection As IDbConnection,
                                         transaction As IDbTransaction,
                                         cantidad As Single,
                                         codigoArticulo As String,
                                         codigoUbicacionOrigen As String,
                                         codigoUbicacionDestino As String) As Integer
        Dim articulo = RepositorioArticulo.ObtenerInformacion(codigoArticulo)
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)

        If operacionExtendida IsNot Nothing Then
            ' Reducir en origen
            Dim result = operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Update.ReducirStockEnLote,
                cantidad, articulo.Codigo, codigoUbicacionOrigen)

            ' Incrementar en destino
            result += operacionExtendida.ExecuteNonQuery(connection, transaction,
                Querys.Update.IncrementarStockEnLote,
                cantidad, articulo.Codigo, codigoUbicacionDestino)

            Return result
        Else
            ' Fallback para operación normal
            Dim result = Operacion.ExecuteNonQuery(connection,
                Querys.Update.ReducirStockEnLote,
                cantidad, articulo.Codigo, codigoUbicacionOrigen)

            result += Operacion.ExecuteNonQuery(connection,
                Querys.Update.IncrementarStockEnLote,
                cantidad, articulo.Codigo, codigoUbicacionDestino)

            Return result
        End If
    End Function

    ''' <summary>
    ''' Verifica si existe un lote de artículo usando una transacción específica
    ''' </summary>
    Public Shared Function ExisteLoteArticulo(connection As IDbConnection,
                                            transaction As IDbTransaction,
                                            codigoArticulo As String,
                                            codigoUbicacion As String) As Boolean
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)

        If operacionExtendida IsNot Nothing Then
            Return operacionExtendida.ExistsRecord(connection, transaction,
                Querys.Select.VerificarExistenciaLoteDeArticulo,
                codigoArticulo, codigoUbicacion)
        Else
            Return Operacion.ExecuteScalar(connection, transaction,
                Querys.Select.VerificarExistenciaLoteDeArticulo,
                codigoArticulo, codigoUbicacion)
        End If
    End Function

    ''' <summary>
    ''' Obtiene la cantidad disponible de un artículo en una ubicación específica
    ''' </summary>
    Public Shared Function ObtenerCantidadDisponible(connection As IDbConnection,
                                                    transaction As IDbTransaction,
                                                    codigoArticulo As String,
                                                    codigoUbicacion As String) As Single
        Dim operacionExtendida = TryCast(Operacion, AccessDatabaseOperationExtended)

        Try
            Dim query = "SELECT (UnidadesIniciales + UnidadesCompradas - UnidadesVendidas - UnidadesTransferidas) AS CantidadDisponible " &
                       "FROM StockLote WHERE CodigoArticulo = ? AND CodigoUbicacion = ?"

            Dim result As Object
            If operacionExtendida IsNot Nothing Then
                Dim ds = operacionExtendida.ExecuteQuery(connection, transaction, query, codigoArticulo, codigoUbicacion)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    result = ds.Tables(0).Rows(0)("CantidadDisponible")
                Else
                    result = 0
                End If
            Else
                Dim ds = Operacion.ExecuteQuery(connection, query, codigoArticulo, codigoUbicacion)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    result = ds.Tables(0).Rows(0)("CantidadDisponible")
                Else
                    result = 0
                End If
            End If

            Return If(result Is Nothing OrElse result Is DBNull.Value, 0, Convert.ToSingle(result))
        Catch
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Realiza una transferencia completa (verifica existencia y transfiere)
    ''' </summary>
    Public Shared Function RealizarTransferenciaCompleta(connection As IDbConnection,
                                                        transaction As IDbTransaction,
                                                        cantidad As Single,
                                                        codigoArticulo As String,
                                                        codigoUbicacionOrigen As String,
                                                        codigoUbicacionDestino As String) As Integer
        ' Verificar si existe el lote en destino
        If ExisteLoteArticulo(connection, transaction, codigoArticulo, codigoUbicacionDestino) Then
            ' Si existe, transferir stock
            Return TransferirStock(connection, transaction, cantidad, codigoArticulo, codigoUbicacionOrigen, codigoUbicacionDestino)
        Else
            ' Si no existe, crear nuevo lote desde stock
            Return InsertarArticuloDesdeStock(connection, transaction, cantidad, codigoArticulo, codigoUbicacionOrigen, codigoUbicacionDestino)
        End If
    End Function

    ''' <summary>
    ''' Realiza múltiples transferencias en una sola transacción
    ''' </summary>
    Public Shared Function RealizarTransferenciasMultiples(connection As IDbConnection,
                                                          transaction As IDbTransaction,
                                                          transferencias As List(Of TransferenciaInfo)) As Integer
        Dim totalOperaciones As Integer = 0

        For Each transferencia In transferencias
            totalOperaciones += RealizarTransferenciaCompleta(connection, transaction,
                transferencia.Cantidad,
                transferencia.CodigoArticulo,
                transferencia.CodigoUbicacionOrigen,
                transferencia.CodigoUbicacionDestino)
        Next

        Return totalOperaciones
    End Function


End Class


''' <summary>
''' Información de una transferencia de stock
''' </summary>
Public Class TransferenciaInfo
    Public Property Cantidad As Single
    Public Property CodigoArticulo As String
    Public Property CodigoUbicacionOrigen As String
    Public Property CodigoUbicacionDestino As String
    Public Property Descripcion As String
End Class