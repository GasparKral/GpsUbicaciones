Public Class frmConsulta

    Public Consulta As String

    Private ConexionLocal As IDbConnection
    Private Almacen As String

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Consulta = "" Then
            MsgBox("No se ha definido la consulta a ejecutar", MsgBoxStyle.Critical, "Error")
            Me.Close()
        End If

        ' Cargar en el grid la consulta del parámetro Consulta

        Dim dt = Operacion.ExecuteTable(Consulta)
        ' comprobar si hay datos
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Grid.DataSource = dt
        Else
            MsgBox("No se han encontrado datos para la consulta proporcionada.", MsgBoxStyle.Information, "Sin datos")
            Me.Close()
        End If


    End Sub

End Class