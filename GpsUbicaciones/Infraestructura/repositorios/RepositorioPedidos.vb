Imports System.ComponentModel

Public Class RepositorioPedidos
    Public Shared Function ObtenerPedidosPorFecha(fecha As Date) As BindingList(Of Pedido)
        Dim pedidos As New BindingList(Of Pedido)

        Dim dsDatos = Cursor(Of DataRow).From(Operacion.ExecuteQuery(Querys.Select.ConsultarPedidosPorFecha, fecha).Tables(0).Rows)

        While dsDatos.HasNext
            Dim TempRow = dsDatos.NextValue

            Dim pedido As New Pedido With {
                .Identificador = TempRow("Identificador"),
                .Articulo = New Articulo With {
                    .Codigo = TempRow("CodigoArticulo"),
                    .NombreComercial = TempRow("NombreArticulo"),
                    .PorPeso = Convert.ToBoolean(TempRow("PorPeso"))
                },
                .Destino = TempRow("Destino"),
                .Unidades = Convert.ToSingle(TempRow("Cantidad")),
                .Fecha = Pedido.ConvertirFecha(TempRow("Fecha"))
            }

            pedidos.Add(pedido)
        End While

        Return pedidos
    End Function
End Class

'.Ubicacion = New Ubicacion With {
'    .Identificador = TempRow("CodigoUbicacion"),
'    .Nombre = TempRow("NombreUbicacion"),
'    .Almacen = TempRow("CodigoAlmacen"),
'    .NombreAlmacen = TempRow("Almacen")
'},