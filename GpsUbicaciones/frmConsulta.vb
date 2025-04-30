Imports System.ComponentModel
Imports DevExpress.CodeParser
Imports DevExpress.XtraGrid

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
        Try
            Dim dt As New DataTable
            If AbrirBaseDatos(ConexionLocal) Then
                dt = CargarDataTable(Consulta, ConexionLocal)
                ' comprobar si hay datos
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Grid.DataSource = dt
                Else
                    MsgBox("No se han encontrado datos para la consulta proporcionada.", MsgBoxStyle.Information, "Sin datos")
                    Me.Close()
                End If
                dt.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message)
        Finally
            ' Si la conexion está abiert, cerrarla
            If ConexionLocal.State = ConnectionState.Open Then
                ConexionLocal.Close()
            End If
        End Try

    End Sub
End Class