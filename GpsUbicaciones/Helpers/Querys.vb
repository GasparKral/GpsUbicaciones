''' <summary>
''' Módulo que contiene funciones y clases para gestionar consultas SQL y operaciones con datos.
''' </summary>
Module Querys

    ''' <summary>
    ''' Obtiene una fila específica de un DataSet.
    ''' </summary>
    ''' <param name="DataSet">El DataSet del que se obtendrá la fila.</param>
    ''' <param name="indiceTabla">Índice de la tabla dentro del DataSet.</param>
    ''' <param name="indiceFila">Índice de la fila dentro de la tabla.</param>
    ''' <param name="mensajeErrorTabla">Mensaje personalizado para el error cuando el DataSet no contiene tablas.</param>
    ''' <param name="mensajeErrorFila">Mensaje personalizado para el error cuando la tabla no contiene filas.</param>
    ''' <returns>La fila solicitada como un objeto DataRow.</returns>
    ''' <exception cref="ArgumentNullException">Se lanza cuando el DataSet es nulo.</exception>
    ''' <exception cref="InvalidOperationException">Se lanza cuando el DataSet no contiene tablas o la tabla no contiene filas.</exception>
    ''' <exception cref="ArgumentOutOfRangeException">Se lanza cuando el índice de tabla o fila está fuera de rango.</exception>
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

    ''' <summary>
    ''' Clase que contiene consultas SQL de selección.
    ''' </summary>
    Class [Select]

        ''' <summary>
        ''' Obtiene una consulta SQL para verificar si existe un lote específico de un artículo.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Articulo - Código del artículo
        ''' 2. Lote - Código del lote
        ''' </param>
        ''' <returns>Consulta SQL que devuelve un valor booleano (TRUE/FALSE) indicando si existe el lote del artículo.</returns>
        Public Shared Function VerificarExistenciaLoteDeArticulo() As String
            Return "SELECT COUNT(*) > 0 FROM StockLotes WHERE Articulo = ? AND Lote = ?"
        End Function

        Public Shared Function ConsultarArticulosEnUbicacion() As String
            Return "SELECT
                        A.Codigo AS CodigoArticulo,
                        A.NombreComercial AS NombreArticulo,
                        A.PorPeso,
                        A.CodBarras,
                        A.RefProveedor,
                        S.Uds_Ini AS UnidadesIniciales,
                        S.Uds_Com AS UnidadesCompradas,
                        S.Uds_Ven AS UnidadesVendidas,
                        S.Uds_Tra AS UnidadesTransferidas,
                        U.Codigo AS CodigoUbicacion,
                        U.Nombre AS NombreUbicacion,
                        Al.Codigo AS CodigoAlmacen,
                        Al.Nombre AS NombreAlmacen
                    FROM
                        ((ARTICULOS AS A
                        INNER JOIN STOCKLOTES AS S ON S.Articulo = A.Codigo)
                        INNER JOIN UBICACIONES AS U ON U.Codigo = S.Lote)
                        INNER JOIN ALMACENES AS AL ON S.Almacen = AL.Codigo
                    WHERE 
                        S.Lote = ?
                    "
        End Function

        Public Shared Function ConsultarTotalArticuloEnLotes() As String
            Return $"SELECT Round(SUM(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven), {nDecUds}) 
                    FROM StockLotes S 
                    WHERE Articulo = ?
                    "
        End Function

        Public Shared Function ConsultarArticuloEnUbicacion() As String
            Return $"SELECT
                        A.Codigo AS CodigoArticulo,
                        A.NombreComercial AS NombreArticulo,
                        A.PorPeso,
                        A.CodBarras,
                        A.RefProveedor,   
                        S.Uds_Ini AS UnidadesIniciales,
                        S.Uds_Com AS UnidadesCompradas,
                        S.Uds_Ven AS UnidadesVendidas,
                        S.Uds_Tra AS UnidadesTransferidas,
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven,{nDecUds}) AS StockTotal,
                        U.Codigo AS CodigoUbicacion,
                        U.Nombre AS NombreUbicacion,
                        Al.Codigo AS CodigoAlmacen,
                        Al.Nombre AS NombreAlmacen
                    FROM 
                        (((ARTICULOS A
                        INNER JOIN STOCKLOTES S ON S.Articulo = A.Codigo)
                        INNER JOIN UBICACIONES U ON U.Codigo = S.Lote)
                        INNER JOIN ALMACENES AL ON S.Almacen = AL.Codigo)
                        INNER JOIN STOCK ST ON ST.Articulo = A.Codigo
                    WHERE 
                        (A.Codigo = ? OR 
                        A.CodBarras = ? OR 
                        A.RefProveedor = ?) AND 
                        S.Lote = ?
                    "
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar los datos básicos de un artículo por su código.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Codigo - Código del artículo a consultar
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: NombreComercial, Codigo, PorPeso del artículo.</returns>
        Public Shared Function ConsultarDatosBasicosArticuloPorCodigo() As String
            Return $"SELECT 
                        A.Codigo,
                        A.NombreComercial,
                        A.PorPeso,
                        A.CodBarras,
                        A.RefProveedor,
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven, {nDecUds} ) as StockTotal
                    FROM 
                       ARTICULOS AS A
                       INNER JOIN STOCK AS S ON S.Articulo = A.Codigo
                    WHERE 
                        A.Codigo = ? OR A.CodBarras = ? OR A.RefProveedor = ? AND
                        S.Almacen = ?
                    "
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar el stock disponible de un lote específico.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Articulo - Código del artículo
        ''' 2. Lote - Código del lote
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: Stock (cantidad disponible calculada como Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven).</returns>
        Public Shared Function ConsultarStockDeLote() As String
            Return $"SELECT
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven, {nDecUds} ) AS Stock
                    FROM StockLotes AS S
                    WHERE 
                        S.Articulo = ? AND
                        S.Lote = ?"
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar un artículo con su stock por código y almacén.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Codigo - Código del artículo
        ''' 2. Almacen - Código del almacén
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: NombreComercial, Codigo, Stock (cantidad disponible calculada).</returns>
        Public Shared Function ConsultarArticuloConStockPorCodigoYAlmacen() As String
            Return $"SELECT 
                        A.NombreComercial,
                        A.Codigo,
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven,{nDecUds}) AS Stock
                    FROM 
                       ARTICULOS AS A
                       INNER JOIN STOCK AS S ON S.Articulo = A.Codigo
                    WHERE 
                        A.Codigo = ? AND 
                        S.Almacen = ?"
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar stock total de un artículo por su código.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Articulo - Código del artículo
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: Stock (cantidad total disponible calculada como Uds_Ini+Uds_Com+Uds_Tra-Uds_Ven).</returns>
        Public Shared Function ConsultarStockTotalArticuloPorCodigo() As String
            Return $"SELECT
                        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven,{nDecUds}) AS Stock
                    FROM
                        STOCK AS S
                    WHERE
                        S.Articulo = ?"
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar un lote específico de un artículo por código y lote.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Articulo - Código del artículo
        ''' 2. Lote - Código del lote
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: Articulo[Codigo de artículo], Lote[Ubicación del lote].</returns>
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

        ''' <summary>
        ''' Crea una consulta fluida para consultar los datos de una ubicación por su código.
        ''' </summary>
        ''' <param name="codigo">Código de la ubicación</param>
        ''' <returns>FluentQuery configurada para consultar datos de ubicación</returns>
        ''' 
        Public Shared Function ConsultarDatosUbicacionPorCodigo() As String
            Return "SELECT 
                        U.Codigo,
                        U.Nombre,
                        A.Codigo as CodigoAlmacen,
                        A.Nombre as Almacen
                    FROM 
                        UBICACIONES AS U,
                        ALMACENES AS A
                    WHERE 
                        U.Codigo = ? AND
                        A.Codigo = ?
                "
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para consultar la ubicación de un lote por su código.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Codigo - Código de la ubicación
        ''' </param>
        ''' <returns>Consulta SQL que devuelve: Codigo[de la ubicación], Nombre[de la ubicación].</returns>
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

        Public Shared Function ConsultarPedidosPorFecha() As String
            Return $"SELECT    
                        SubPedidos.Referencia,
                        SubPedidos.Descripcion,
                        U.Nombre AS Ubicacion,
                        SubPedidos.CantidadPedida,
                        ROUND(S.Uds_Ini + S.Uds_Com + S.Uds_Tra - S.Uds_Ven, {nDecUds}) AS StockDisponible
                    FROM
                        ((
                            SELECT    
                                M.Articulo AS Referencia,
                                M.Descripcion,
                                ROUND(SUM(M.Cantidad), {nDecUds}) AS CantidadPedida
                            FROM
                                MOVPCL AS M
                                INNER JOIN PEDCLI AS P ON P.SERIE = M.SERIE AND P.NUMERO = M.NUMERO
                            WHERE
                                P.Fecha = ? AND
                                M.Articulo IS NOT NULL AND
                                M.Articulo <> ''
                            GROUP BY
                                M.Articulo,
                                M.Descripcion
                        ) AS SubPedidos
                        INNER JOIN STOCKLOTES AS S ON S.Articulo = SubPedidos.Referencia)
                        INNER JOIN UBICACIONES AS U ON U.Codigo = S.Lote
                    WHERE
                        (S.Uds_Ini + S.Uds_Com + S.Uds_Tra - S.Uds_Ven) >= SubPedidos.CantidadPedida
                    ORDER BY
                        U.Orden, SubPedidos.Referencia
        "
        End Function


    End Class

    ''' <summary>
    ''' Clase que contiene consultas SQL de inserción.
    ''' </summary>
    Class Insert
        ''' <summary>
        ''' Obtiene una consulta SQL para insertar un nuevo lote de artículo en el stock.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Almacen - Código del almacén
        ''' 2. Lote - Código del lote
        ''' 3. Articulo - Código del artículo
        ''' 4. Uds_Ini - Unidades iniciales
        ''' </param>
        ''' <returns>Consulta SQL de inserción que no devuelve resultados. Inserta un registro en la tabla StockLotes.</returns>
        Public Shared Function InsertarNuevoLoteDeArticuloEnStock() As String
            Return "INSERT INTO StockLotes (Articulo, Almacen, Lote, Uds_Ini, Uds_Com, Uds_Ven, Uds_Tra) VALUES (?, ?, ?, 0, 0, 0, ?)"
        End Function

        ''' <summary>
        ''' Obtiene una consulta SQL para insertar un movimiento de venta en PDA.
        ''' </summary>
        ''' <param name="Parámetros SQL">
        ''' 1. Terminal - Código del terminal
        ''' 2. Articulo - Código del artículo
        ''' 3. Lote - Código del lote
        ''' 4. Cantidad - Cantidad vendida
        ''' </param>
        ''' <returns>Consulta SQL de inserción que no devuelve resultados. Inserta un registro en la tabla MovPda con operación 'VE'.</returns>
        Public Shared Function InsertarMovimientoVentaEnPDA() As String
            Return "INSERT INTO MovPda (Terminal,Operacion,Articulo,Lote,Cantidad) VALUES (?,'VE',?,?,?)"
        End Function
    End Class

    ''' <summary>
    ''' Clase que contiene consultas SQL de actualización.
    ''' </summary>
    Class Update
        Public Shared Function ReducirStockEnLote() As String
            Return "UPDATE StockLotes SET Uds_Tra = Uds_Tra - ? WHERE Articulo = ? AND Lote = ?"
        End Function

        Public Shared Function IncrementarStockEnLote() As String
            Return "UPDATE StockLotes SET Uds_Tra = Uds_Tra + ? WHERE Articulo = ? AND Lote = ?"
        End Function
    End Class

    ''' <summary>
    ''' Clase que contiene consultas SQL de eliminación.
    ''' </summary>
    Class Delete

    End Class

End Module

