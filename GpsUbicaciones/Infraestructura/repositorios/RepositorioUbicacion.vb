Public Class RepositorioUbicacion

    Public Shared Function ObtenerInformacion(CodigoUbicacion As String) As Ubicacion
        Try
            Dim dsUbicacion = ObtenerFila(Operacion.ExecuteQuery(Querys.Select.ConsultarDatosUbicacionPorCodigo, CodigoUbicacion), 0, 0)

            Return New Ubicacion With {
                .Identificador = CodigoUbicacion,
                .Nombre = dsUbicacion("Nombre"),
                .Almacen = dsUbicacion("CodigoAlmacen"),
                .NombreAlmacen = dsUbicacion("Almacen")
            }
        Catch err As InvalidOperationException
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Advertencia, MensajesDeError.MensajesUbicaciones.CodigoInvalido)
        Catch err As Exception
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Debug, err.Message)
        End Try
        Return Nothing
    End Function

End Class
