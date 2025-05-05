Public Class DatabaseOperationException
    Inherits Exception

    Public Property SqlCommand As String

    Public Sub New(message As String, innerException As Exception, sqlCommand As String)
        MyBase.New(message, innerException)
        Me.SqlCommand = sqlCommand
    End Sub

    Public Overrides ReadOnly Property Message As String
        Get
            Return $"{MyBase.Message}{vbCrLf}Comando SQL: {SqlCommand}"
        End Get
    End Property
End Class