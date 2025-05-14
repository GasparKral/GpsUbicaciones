Public Class Cursor(Of T)
    Private _cursor As List(Of T)
    Private _position As Integer = 0

    Public Property Items As IEnumerable
        Get
            Return _cursor
        End Get
        Set(value As IEnumerable)
            _cursor = New List(Of T)
            For Each item As Object In value
                _cursor.Add(DirectCast(item, T))
            Next
        End Set
    End Property

    Public Shared Function [From](source As IEnumerable) As Cursor(Of T)
        Dim cursor As New Cursor(Of T)
        cursor.Items = source
        Return cursor
    End Function

    Public Sub New()
        _cursor = New List(Of T)
    End Sub

    Public Function HasNext() As Boolean
        Return _position < _cursor.Count
    End Function

    Public Function NextValue() As T
        If Not HasNext() Then
            Throw New InvalidOperationException("No more elements.")
        End If
        Dim value As T = _cursor(_position)
        _position += 1
        Return value
    End Function

    Public Sub Reset()
        _position = 0
    End Sub

    Public Function Count() As Integer
        Return _cursor.Count
    End Function
End Class
