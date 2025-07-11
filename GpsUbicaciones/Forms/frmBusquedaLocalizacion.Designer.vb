<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaLocalizacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GridControl1 = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(GridControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(437, 822)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 5
        btnSalir.Text = "Volver"
        ' 
        ' GridControl1
        ' 
        GridControl1.Location = New Point(12, 12)
        GridControl1.MainView = GridView1
        GridControl1.Name = "GridControl1"
        GridControl1.Size = New Size(576, 805)
        GridControl1.TabIndex = 6
        GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ' 
        ' GridView1
        ' 
        GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {GridColumn1, GridColumn2})
        GridView1.GridControl = GridControl1
        GridView1.Name = "GridView1"
        GridView1.OptionsView.ShowGroupPanel = False
        GridView1.OptionsView.ShowIndicator = False
        ' 
        ' GridColumn1
        ' 
        GridColumn1.Caption = "Ubicación"
        GridColumn1.FieldName = "Nombre"
        GridColumn1.Name = "GridColumn1"
        GridColumn1.Visible = True
        GridColumn1.VisibleIndex = 0
        GridColumn1.Width = 1020
        ' 
        ' GridColumn2
        ' 
        GridColumn2.Caption = "Cantidad"
        GridColumn2.FieldName = "Cantidad"
        GridColumn2.Name = "GridColumn2"
        GridColumn2.Visible = True
        GridColumn2.VisibleIndex = 1
        GridColumn2.Width = 170
        ' 
        ' frmBusquedaLocalizacion
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(600, 900)
        Controls.Add(GridControl1)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(0, 80)
        Name = "frmBusquedaLocalizacion"
        StartPosition = FormStartPosition.Manual
        Text = "frmBusquedaLocalizacion"
        CType(GridControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
End Class
