''' <summary>
''' Módulo que contiene consultas SQL comunes y métodos para interactuar con bases de datos.
''' </summary>
''' <remarks>
''' Este módulo proporciona funciones y consultas predefinidas para operaciones CRUD básicas,
''' especialmente enfocadas en la gestión de artículos, stock y ubicaciones.
''' </remarks>
Module SQLquerys

    ''' <summary>
    ''' Obtiene una fila específica de una tabla dentro de un DataSet.
    ''' </summary>
    ''' <param name="DataSet">El DataSet del cual se obtendrá la fila. No puede ser nulo.</param>
    ''' <param name="indiceTabla">El índice de base cero de la tabla dentro del DataSet.</param>
    ''' <param name="indiceFila">El índice de base cero de la fila dentro de la tabla especificada.</param>
    ''' <returns>La fila (DataRow) correspondiente a los índices especificados.</returns>
    ''' <exception cref="ArgumentNullException">
    ''' Se lanza cuando el parámetro DataSet es nulo.
    ''' </exception>
    ''' <exception cref="InvalidOperationException">
    ''' Se lanza cuando el DataSet no contiene tablas o cuando la tabla especificada no contiene filas.
    ''' </exception>
    ''' <exception cref="ArgumentOutOfRangeException">
    ''' Se lanza cuando el índice de tabla o el índice de fila están fuera del rango válido.
    ''' </exception>
    ''' <remarks>
    ''' Esta función realiza varias validaciones antes de devolver la fila solicitada:
    ''' 1. Verifica que el DataSet no sea nulo
    ''' 2. Comprueba que el DataSet contenga al menos una tabla
    ''' 3. Valida que el índice de tabla esté dentro del rango válido
    ''' 4. Verifica que la tabla especificada contenga filas
    ''' 5. Valida que el índice de fila esté dentro del rango válido
    ''' 
    ''' Ejemplo de uso:
    ''' <code>
    ''' Dim fila As DataRow = ObtenerFila(miDataSet, 0, 3) 'Obtiene la cuarta fila de la primera tabla
    ''' </code>
    ''' </remarks>
    Public Function ObtenerFila(
    DataSet As DataSet,
    indiceTabla As Integer,
    indiceFila As Integer
) As DataRow

        If DataSet Is Nothing Then
            Throw New ArgumentNullException(NameOf(DataSet), "El DataSet no puede ser nulo")
        End If

        If DataSet.Tables.Count = 0 Then
            Throw New InvalidOperationException("El DataSet no contiene tablas")
        End If

        If indiceTabla < 0 OrElse indiceTabla >= DataSet.Tables.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(indiceTabla), "Índice de tabla inválido")
        End If

        Dim tabla As DataTable = DataSet.Tables(indiceTabla)

        If tabla.Rows.Count = 0 Then
            Throw New InvalidOperationException("La tabla no contiene filas")
        End If

        If indiceFila < 0 OrElse indiceFila >= tabla.Rows.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(indiceFila), "Índice de fila inválido")
        End If

        Return tabla.Rows(indiceFila)
    End Function

    ''' <summary>
    ''' Consulta información básica de un artículo por su código.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: NombreComercial, Codigo.
    ''' </remarks>
    Public ObtenerInformacionDeArticulo As String = "SELECT 
        A.NombreComercial,
        A.Codigo
    FROM 
       ARTICULOS AS A
    WHERE 
        A.Codigo = ?
    "

    ''' <summary>
    ''' Consulta información de un artículo incluyendo su stock en un almacén específico.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: NombreComercial, Codigo, Stock (calculado como Uds_Ini + Uds_Com + Uds_Tra - Uds_Ven).
    ''' </remarks>
    Public ObtenerInformacionDeArticuloConStock As String = "SELECT 
        A.NombreComercial,
        A.Codigo,
        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven) AS Stock
    FROM 
       ARTICULOS AS A
       INNER JOIN STOCK AS S ON S.Articulo = A.Codigo
    WHERE 
        A.Codigo = ? AND S.Almacen = ?
    "

    ''' <summary>
    ''' Obtiene información de una ubicación por su código.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: Codigo, Nombre.
    ''' </remarks>
    Public ObtenerInformacionUbicacion As String = "SELECT
        U.Codigo,
        U.Nombre,
        A.Codigo AS CodigoAlmacen,
        A.Nombre AS Almacen
    FROM
        UBICACIONES AS U 
        LEFT JOIN ALMACENES AS A ON Left(U.Codigo,2) = A.Codigo 
    WHERE
        U.Codigo = ?
    "

    ''' <summary>
    ''' Obtiene información de una ubicación que tiene asociado un lote.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: Codigo, Nombre.
    ''' </remarks>
    Public ObtenerInformacionUbicacionLote As String = "
    SELECT
        U.Codigo,
        U.Nombre
    FROM
        UBICACIONES AS U 
        INNER JOIN STOCKLOTES AS S ON S.Lote = U.Codigo
    WHERE
        U.Codigo = ?
    "

    ''' <summary>
    ''' Consulta el stock de un artículo en un lote específico.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: Todos los campos de STOCKLOTES.
    ''' </remarks>
    Public ObtenerStockProductoLote As String = "
    SELECT 
        Round(S.Uds_Ini + S.Uds_Com + S.Uds_Tra - S.Uds_Ven) AS Stock
    FROM
        STOCKLOTES AS S
    WHERE
        S.Articulo = ? AND 
        S.Lote = ? AND
        S.Almacen = ?
    "

    ''' <summary>
    ''' Obtiene el stock total de un artículo (sin considerar lotes).
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: Stock (calculado como Uds_Ini + Uds_Com + Uds_Tra - Uds_Ven).
    ''' </remarks>
    Public ObtenerStockProducto As String = "SELECT
        Round(S.Uds_Ini+S.Uds_Com+S.Uds_Tra-S.Uds_Ven) AS Stock
    FROM
        STOCK AS S
    WHERE
        S.Articulo = ?
    "

    ''' <summary>
    ''' Verifica si existe un artículo en una ubicación específica.
    ''' </summary>
    ''' <remarks>
    ''' Campos retornados: Articulo, Lote.
    ''' </remarks>
    Public ObtenerArticulosPorCodigoYUbicacion As String = "SELECT Articulo, Lote FROM StockLotes WHERE Articulo = ? AND Lote = ?"

    ''' <summary>
    ''' Query para insertar un nuevo artículo en un almacén y lote específicos.
    ''' </summary>
    ''' <remarks>
    ''' Parámetros requeridos:
    ''' 1. NºAlmacen, 2. Lote, 3. Articulo.
    ''' Inicializa Uds_Ini, Uds_Com, Uds_Ven y Uds_Tra a 0.
    ''' </remarks>
    Public AgregarArticuloAlStock As String = "INSERT INTO StockLotes (Almacen, Lote, Articulo, Uds_Ini, Uds_Com, Uds_Ven, Uds_Tra) VALUES (?, ?, ?, 0, 0, 0, 0)"

    ''' <summary>
    ''' Actualiza el stock inicial de un artículo en un lote específico.
    ''' </summary>
    ''' <remarks>
    ''' Parámetros requeridos:
    ''' 1. Cantidad a añadir, 2. Articulo, 3. Lote.
    ''' </remarks>
    Public ActualizarStockDeArticulo As String = "UPDATE StockLotes SET Uds_Ini = Uds_Ini + ? WHERE Articulo = ? AND Lote = ?"

    Public ObtenerArticulosPorFecha As String = "SELECT P.Fecha FROM PEDCLI AS P"
End Module