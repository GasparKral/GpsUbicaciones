Public Module DatabaseUtils
    Public Function GenerateFilter(ByRef filter As String, text As String, Optional [operator] As String = "AND") As String
        If String.IsNullOrEmpty(filter) Then
            Return $" WHERE {text}"
        Else
            Return $" {filter} {[operator]} {text}"
        End If
    End Function

    Public Function FormatDateForQuery(dateValue As String) As String
        Return $"#{Format$(CDate(dateValue), "MM-dd-yy")}#"
    End Function

    Public Function DateFilter(fieldName As String, dateValue As String, Optional filterDirection As String = "") As String
        Dim condition = $" DateDiff('d', {FormatDateForQuery(dateValue)}, {fieldName}) "

        Select Case filterDirection.ToUpper()
            Case "I" ' Inicio / Desde
                Return $"{condition} >= 0"
            Case "=" ' Igual
                Return $"{condition} = 0"
            Case "F" ' Fin / Hasta
                Return $"{condition} <= 0"
            Case Else
                Return condition
        End Select
    End Function

    Public Function IsNullCondition(fieldName As String, Optional negate As Boolean = False) As String
        If negate Then
            Return $"NOT ISNULL({fieldName})"
        Else
            Return $"ISNULL({fieldName})"
        End If
    End Function
End Module