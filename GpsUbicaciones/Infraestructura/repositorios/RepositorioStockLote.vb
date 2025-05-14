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
                    .PorPeso = Convert.ToBoolean(row("PorPeso"))
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
        Using dsDatos = Operacion.ExecuteQuery(Querys.Select.ConsultarArticuloEnUbicacion, CodigoArticulo, CodigoLote, Almacen).Tables(0)
            If dsDatos.Rows.Count > 0 Then
                Dim row As DataRow = dsDatos.Rows(0)
                stockLote = New StockLote With {
                    .Articulo = New Articulo With {
                        .Codigo = row("CodigoArticulo"),
                        .NombreComercial = row("NombreArticulo"),
                        .PorPeso = Convert.ToBoolean(row("PorPeso"))
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

    Public Shared Function InsertarArticulo(Connection As IDbConnection, Stock As Single, CodigoArticulo As String, CodigoUbicacion As String, Almacen As String) As Integer
        Return Operacion.ExecuteNonQuery(Connection, Querys.Insert.InsertarNuevoLoteDeArticuloEnStock, Almacen, CodigoUbicacion, CodigoArticulo, Stock)
    End Function

    Public Shared Function MoverStock(Connection As IDbConnection, Cantidad As Single, CodigoArticulo As String, CodigoUbicacionOrigen As String) As Integer
        Return Operacion.ExecuteNonQuery(Connection, Querys.Update.MoverStockDeLote, Cantidad, CodigoArticulo, CodigoUbicacionOrigen)
    End Function
End Class
