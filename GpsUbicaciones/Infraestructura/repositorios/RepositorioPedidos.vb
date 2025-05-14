Imports System.ComponentModel

Public Class RepositorioPedidos
    Public Shared Function ObtenerPedidosPorFecha(fecha As Date) As BindingList(Of Pedido)
        Dim pedidos As New BindingList(Of Pedido)

        Dim dsDatos = Operacion.ExecuteQuery(Querys.Select.ConsultarPedidosPorFecha, fecha.ToUniversalTime.Date.ToString("dd/MM/yyyy")).Tables(0).Rows

        For Each TempRow As DataRow In dsDatos

            Dim pedido As New Pedido With {
                .Identificador = IIf(IsDBNull(TempRow("Identificador")), Nothing, TempRow("Identificador")),
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
        Next


        Return pedidos
    End Function
End Class

'.Ubicacion = New Ubicacion With {
'    .Identificador = TempRow("CodigoUbicacion"),
'    .Nombre = TempRow("NombreUbicacion"),
'    .Almacen = TempRow("CodigoAlmacen"),
'    .NombreAlmacen = TempRow("Almacen")
'},