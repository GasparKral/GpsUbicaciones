Imports System.ComponentModel

Public Class RepositorioStockLote
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
                    .ReferenciaProvedor = row("RefProveedor")
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
            Else
                GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesUbicaciones.CodigoInvalido)
                Return Nothing
            End If
        End Using
        Return stockLote
    End Function

    Public Shared Function ObtenerTotalArticuloEnLotes(CodigoArticulo As String) As Single
        Return Convert.ToSingle(Operacion.ExecuteScalar(Querys.Select.ConsultarTotalArticuloEnLotes, CodigoArticulo))
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
End Class