Public Class DatabaseOperationException
    Inherits Exception

    Public Property SqlCommand As String
    Public Property Parameters As String

    Public Sub New(message As String, innerException As Exception, sqlCommand As String, ParamArray parameters As Object())
        MyBase.New(message, innerException)
        Me.SqlCommand = sqlCommand
        Me.Parameters = String.Join(", ", parameters)
    End Sub

    Public Overrides ReadOnly Property Message As String
        Get
            Return $"{MyBase.Message}{vbCrLf} Inner Exception: {InnerException.Message}{vbCrLf} SQL Command: {SqlCommand} {vbCrLf} Parameters: {Parameters}"
        End Get
    End Property
End Class