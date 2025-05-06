Public Class frmConsulta

    Public Consulta As String
    Private Almacen As String

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Consulta = "" Then
            MessageFactory.ShowMessage(MessageType.Error, UndefinedQueryMessage)
            Me.Close()
        End If

        ' Cargar en el grid la consulta del parámetro Consulta

        Dim dt = Operacion.ExecuteTable(Consulta)
        ' comprobar si hay datos
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            GridControlConsultaArticulos.DataSource = dt
        Else
            MessageFactory.ShowMessage(MessageType.Information, NoDataFoundMessage)
            Me.Close()
        End If


    End Sub

End Class