Imports System.ComponentModel

Public Class frmConsulta
    Property Source As BindingList(Of StockLote)

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub frmConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Configurar el grid
        GridViewConsultaArticulos.OptionsBehavior.Editable = False
        GridViewConsultaArticulos.OptionsBehavior.ReadOnly = True
        GridViewConsultaArticulos.OptionsView.ShowGroupPanel = False
        GridViewConsultaArticulos.OptionsView.ShowIndicator = False
        GridViewConsultaArticulos.OptionsView.ShowAutoFilterRow = True
        GridViewConsultaArticulos.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        GridViewConsultaArticulos.OptionsCustomization.AllowColumnMoving = False
        GridViewConsultaArticulos.OptionsCustomization.AllowColumnResizing = False
        GridViewConsultaArticulos.OptionsCustomization.AllowFilter = True
        GridViewConsultaArticulos.OptionsCustomization.AllowSort = True
        GridViewConsultaArticulos.OptionsCustomization.AllowGroup = False
        GridViewConsultaArticulos.OptionsCustomization.AllowQuickHideColumns = False
        GridViewConsultaArticulos.OptionsCustomization.AllowRowSizing = True

        GridViewConsultaArticulos.OptionsBehavior.AutoPopulateColumns = False
        GridControlConsultaArticulos.DataSource = Source

        GridViewConsultaArticulos.Columns.Clear() ' Limpia columnas existentes (por si acaso)

        'Columna Artículo
        Dim colArticulo = GridViewConsultaArticulos.Columns.AddField("NombreArticulo")
        colArticulo.Caption = "Artículo"
        colArticulo.Visible = True
        colArticulo.VisibleIndex = 0
        colArticulo.Width = 200

        'Columna Cantidad (calculada)
        Dim colCantidad = GridViewConsultaArticulos.Columns.AddField("Cantidad")
        colCantidad.Caption = "Cantidad"
        colCantidad.Visible = True
        colCantidad.VisibleIndex = 1
        colCantidad.Width = 50
        colCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        colCantidad.DisplayFormat.FormatString = "N2" ' 2 decimales

        If Source.Count = 0 Then
            GestorMensajes.FabricaMensajes.MostrarMensaje(TipoMensaje.Informacion, MensajesGenerales.SinDatos)
            Me.Close()
        End If
    End Sub

End Class