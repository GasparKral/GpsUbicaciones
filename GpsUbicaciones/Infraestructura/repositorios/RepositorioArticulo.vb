Public Class RepositorioArticulo

    Public Shared Function ObtenerInformacion(CodigoArticulo As String) As Articulo
        Using ds = Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo, CodigoArticulo, CodigoArticulo, CodigoArticulo, Almacen)
            Dim dsArticulo = ObtenerFila(ds, 0, 0)
            Return New Articulo With {
                .Codigo = dsArticulo("Codigo"),
                .NombreComercial = dsArticulo("NombreComercial"),
                .PorPeso = Convert.ToBoolean(dsArticulo("PorPeso")),
                .CodigoBarras = dsArticulo("CodBarras"),
                .ReferenciaProvedor = dsArticulo("RefProveedor"),
                .StockTotal = dsArticulo("StockTotal"),
                .Foto = dsArticulo("RutaFoto"),
                .Categoria = dsArticulo("Categoria"),
                .PVP = Convert.ToSingle(dsArticulo("PVP"))
            }
        End Using
        Return Nothing
    End Function

    Friend Shared Function ObtenerCodigoArticulo(nombreArticulo As String) As String
        Using ds = Operacion.ExecuteQuery("SELECT Codigo FROM ARTICULOS WHERE NombreComercial = ?", nombreArticulo)
            Return ObtenerFila(ds, 0, 0)("Codigo")
        End Using
        Return Nothing
    End Function
End Class
