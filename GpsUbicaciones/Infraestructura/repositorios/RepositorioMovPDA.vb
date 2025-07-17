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



