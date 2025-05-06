Module Querys

    Public Function ObtenerFila(
        DataSet As DataSet,
        indiceTabla As Integer,
        indiceFila As Integer,
        Optional mensajeErrorTabla As String = "El DataSet no contiene tablas",
        Optional mensajeErrorFila As String = "La tabla no contiene filas"
    ) As DataRow

        If DataSet Is Nothing Then
            Throw New ArgumentNullException(NameOf(DataSet), "El DataSet no puede ser nulo")
        End If

        If DataSet.Tables.Count = 0 Then
            Throw New InvalidOperationException(mensajeErrorTabla)
        End If

        If indiceTabla < 0 OrElse indiceTabla >= DataSet.Tables.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(indiceTabla), "Índice de tabla inválido")
        End If

        Dim tabla As DataTable = DataSet.Tables(indiceTabla)

        If tabla.Rows.Count = 0 Then
            Throw New InvalidOperationException(mensajeErrorFila)
        End If

        If indiceFila < 0 OrElse indiceFila >= tabla.Rows.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(indiceFila), "Índice de fila inválido")
        End If

        Return tabla.Rows(indiceFila)
    End Function

    Class [Select]
        Public Shared Function VerificarExistenciaLoteDeArticulo() As String
            Return "SELECT COUNT(*) > 0 FROM StockLotes WHERE Articulo = ? AND Lote = ?"
        End Function

        Public Shared Function ConsultarDatosBasicosArticuloPorCodigo() As String
            Return "SELECT 
                        A.NombreComercial,
                        A.Codigo,
                        A.PorPeso
                    FROM 
                       ARTICULOS AS A
                    WHERE 
                        A.Codigo = ?"
        End Function

        Public Shared Function ConsultarStockDeLote() As String
            Return "SELECT
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven) AS Stock
                    FROM StockLotes AS S
                    WHERE 
                        S.Articulo = ? AND
                        S.Lote = ?"
        End Function

        Public Shared Function ConsultarArticuloConStockPorCodigoYAlmacen() As String
            Return "SELECT 
                        A.NombreComercial,
                        A.Codigo,
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven) AS Stock
                    FROM 
                       ARTICULOS AS A
                       INNER JOIN STOCK AS S ON S.Articulo = A.Codigo
                    WHERE 
                        A.Codigo = ? AND 
                        S.Almacen = ?"
        End Function

        Public Shared Function ConsultarStockTotalArticuloPorCodigo() As String
            Return "SELECT
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven) AS Stock
                    FROM
                        STOCK AS S
                    WHERE
                        S.Articulo = ?"
        End Function

        Public Shared Function ConsultarLoteDeArticuloPorCodigoYLote() As String
            Return "SELECT 
                        Articulo, 
                        Lote 
                    FROM 
                        StockLotes 
                    WHERE 
                        Articulo = ? AND 
                        Lote = ?"
        End Function

        Public Shared Function ConsultarDatosUbicacionPorCodigo() As String
            Return "SELECT
                        U.Codigo,
                        U.Nombre,
                        A.Codigo AS CodigoAlmacen,
                        A.Nombre AS Almacen
                    FROM
                        UBICACIONES AS U 
                        LEFT JOIN ALMACENES AS A ON Left(U.Codigo,2) = A.Codigo 
                    WHERE
                        U.Codigo = ?"
        End Function

        Public Shared Function ConsultarUbicacionDeLotePorCodigo() As String
            Return "SELECT
                        U.Codigo,
                        U.Nombre
                    FROM
                        UBICACIONES AS U 
                        INNER JOIN STOCKLOTES AS S ON S.Lote = U.Codigo
                    WHERE
                        U.Codigo = ?"
        End Function

    End Class

    Class Insert
        Public Shared Function InsertarNuevoLoteDeArticuloEnStock() As String
            Return "INSERT INTO StockLotes (Almacen, Lote, Articulo, Uds_Ini, Uds_Com, Uds_Ven, Uds_Tra) VALUES (?, ?, ?, 0, 0, 0, 0)"
        End Function

        Public Shared Function InsertarMovimientoVentaEnPDA() As String
            Return "INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES (?,'VE',?,?,?)"
        End Function
    End Class

    Class Update
        Public Shared Function ActualizarCantidadStockDeLote() As String
            Return "UPDATE StockLotes SET Uds_Ini = Uds_Ini + ? WHERE Articulo = ? AND Lote = ?"
        End Function
    End Class

    Class Delete

    End Class

End Module