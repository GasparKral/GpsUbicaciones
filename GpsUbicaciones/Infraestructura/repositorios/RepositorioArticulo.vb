Public Class RepositorioArticulo

    Public Shared Function ObtenerInFormacion(CodigoArticulo As String) As Articulo
        Try
            Dim dsArticulo = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosBasicosArticuloPorCodigo, CodigoArticulo), 0, 0)
            Return New Articulo With {
            .Codigo = CodigoArticulo,
            .NombreComercial = dsArticulo("NombreComercial"),
            .PorPeso = Convert.ToBoolean(dsArticulo("PorPeso"))
        }
        Catch err As InvalidOperationException
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesDeError.MensajesArticulos.CodigoInvalido)
        Catch err As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Debug, err.Message)
        End Try
        Return Nothing
    End Function

End Class
