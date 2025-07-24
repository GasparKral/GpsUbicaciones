<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformacionArticulo
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
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        PictureBoxItemImage = New PictureBox()
        LabelItemPVP = New DevExpress.XtraEditors.LabelControl()
        LabelTotalStock = New DevExpress.XtraEditors.LabelControl()
        LabelCategory = New DevExpress.XtraEditors.LabelControl()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        TextEditItem = New DevExpress.XtraEditors.TextEdit()
        Label4 = New Label()
        GridControlLotes = New DevExpress.XtraGrid.GridControl()
        GridViewLotes = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        GroupControl1.SuspendLayout()
        CType(PictureBoxItemImage, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlLotes, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewLotes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupControl1
        ' 
        GroupControl1.Controls.Add(Label3)
        GroupControl1.Controls.Add(Label2)
        GroupControl1.Controls.Add(Label1)
        GroupControl1.Controls.Add(PictureBoxItemImage)
        GroupControl1.Controls.Add(LabelItemPVP)
        GroupControl1.Controls.Add(LabelTotalStock)
        GroupControl1.Controls.Add(LabelCategory)
        GroupControl1.Controls.Add(LabelNombreArticulo)
        GroupControl1.Controls.Add(TextEditItem)
        GroupControl1.Controls.Add(Label4)
        GroupControl1.Location = New Point(13, 12)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Padding = New Padding(20)
        GroupControl1.ShowCaption = False
        GroupControl1.Size = New Size(599, 428)
        GroupControl1.TabIndex = 0
        GroupControl1.Text = "GroupControl1"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(26, 220)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 20)
        Label3.TabIndex = 43
        Label3.Text = "PVP:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(25, 161)
        Label2.Name = "Label2"
        Label2.Size = New Size(169, 20)
        Label2.TabIndex = 42
        Label2.Text = "Existencias Totales:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(25, 102)
        Label1.Name = "Label1"
        Label1.Size = New Size(71, 20)
        Label1.TabIndex = 41
        Label1.Text = "Familia:"
        ' 
        ' PictureBoxItemImage
        ' 
        PictureBoxItemImage.Location = New Point(276, 105)
        PictureBoxItemImage.Name = "PictureBoxItemImage"
        PictureBoxItemImage.Size = New Size(298, 298)
        PictureBoxItemImage.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBoxItemImage.TabIndex = 40
        PictureBoxItemImage.TabStop = False
        ' 
        ' LabelItemPVP
        ' 
        LabelItemPVP.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelItemPVP.Appearance.BackColor = Color.RoyalBlue
        LabelItemPVP.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelItemPVP.Appearance.ForeColor = Color.White
        LabelItemPVP.Appearance.Options.UseBackColor = True
        LabelItemPVP.Appearance.Options.UseFont = True
        LabelItemPVP.Appearance.Options.UseForeColor = True
        LabelItemPVP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelItemPVP.Location = New Point(25, 243)
        LabelItemPVP.Margin = New Padding(4, 3, 4, 3)
        LabelItemPVP.Name = "LabelItemPVP"
        LabelItemPVP.Padding = New Padding(6, 0, 6, 0)
        LabelItemPVP.Size = New Size(243, 33)
        LabelItemPVP.TabIndex = 39
        ' 
        ' LabelTotalStock
        ' 
        LabelTotalStock.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelTotalStock.Appearance.BackColor = Color.RoyalBlue
        LabelTotalStock.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelTotalStock.Appearance.ForeColor = Color.White
        LabelTotalStock.Appearance.Options.UseBackColor = True
        LabelTotalStock.Appearance.Options.UseFont = True
        LabelTotalStock.Appearance.Options.UseForeColor = True
        LabelTotalStock.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelTotalStock.Location = New Point(25, 184)
        LabelTotalStock.Margin = New Padding(4, 3, 4, 3)
        LabelTotalStock.Name = "LabelTotalStock"
        LabelTotalStock.Padding = New Padding(6, 0, 6, 0)
        LabelTotalStock.Size = New Size(243, 33)
        LabelTotalStock.TabIndex = 38
        ' 
        ' LabelCategory
        ' 
        LabelCategory.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelCategory.Appearance.BackColor = Color.RoyalBlue
        LabelCategory.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelCategory.Appearance.ForeColor = Color.White
        LabelCategory.Appearance.Options.UseBackColor = True
        LabelCategory.Appearance.Options.UseFont = True
        LabelCategory.Appearance.Options.UseForeColor = True
        LabelCategory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelCategory.Location = New Point(25, 125)
        LabelCategory.Margin = New Padding(4, 3, 4, 3)
        LabelCategory.Name = "LabelCategory"
        LabelCategory.Padding = New Padding(6, 0, 6, 0)
        LabelCategory.Size = New Size(243, 33)
        LabelCategory.TabIndex = 37
        ' 
        ' LabelNombreArticulo
        ' 
        LabelNombreArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticulo.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelNombreArticulo.Appearance.ForeColor = Color.White
        LabelNombreArticulo.Appearance.Options.UseBackColor = True
        LabelNombreArticulo.Appearance.Options.UseFont = True
        LabelNombreArticulo.Appearance.Options.UseForeColor = True
        LabelNombreArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(26, 66)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(548, 33)
        LabelNombreArticulo.TabIndex = 36
        ' 
        ' TextEditItem
        ' 
        TextEditItem.Location = New Point(106, 25)
        TextEditItem.Margin = New Padding(3, 3, 3, 6)
        TextEditItem.Name = "TextEditItem"
        TextEditItem.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        TextEditItem.Properties.Appearance.Options.UseFont = True
        TextEditItem.Properties.ValidateOnEnterKey = True
        TextEditItem.Size = New Size(172, 32)
        TextEditItem.TabIndex = 35
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(25, 33)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 20)
        Label4.TabIndex = 34
        Label4.Text = "Artículo:"
        ' 
        ' GridControlLotes
        ' 
        GridControlLotes.Font = New Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridControlLotes.Location = New Point(13, 446)
        GridControlLotes.LookAndFeel.SkinName = "WXI"
        GridControlLotes.LookAndFeel.UseDefaultLookAndFeel = False
        GridControlLotes.MainView = GridViewLotes
        GridControlLotes.Name = "GridControlLotes"
        GridControlLotes.Size = New Size(599, 420)
        GridControlLotes.TabIndex = 1
        GridControlLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewLotes})
        ' 
        ' GridViewLotes
        ' 
        GridViewLotes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {GridColumn1, GridColumn2})
        GridViewLotes.GridControl = GridControlLotes
        GridViewLotes.Name = "GridViewLotes"
        GridViewLotes.OptionsView.ShowGroupPanel = False
        GridViewLotes.OptionsView.ShowIndicator = False
        ' 
        ' GridColumn1
        ' 
        GridColumn1.AppearanceCell.Font = New Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridColumn1.AppearanceCell.Options.UseFont = True
        GridColumn1.AppearanceHeader.Font = New Font("Microsoft YaHei UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridColumn1.AppearanceHeader.Options.UseFont = True
        GridColumn1.Caption = "Ubicación"
        GridColumn1.FieldName = "Nombre"
        GridColumn1.Name = "GridColumn1"
        GridColumn1.OptionsColumn.AllowEdit = False
        GridColumn1.Visible = True
        GridColumn1.VisibleIndex = 0
        GridColumn1.Width = 517
        ' 
        ' GridColumn2
        ' 
        GridColumn2.AppearanceCell.Font = New Font("Microsoft YaHei UI", 14.25F)
        GridColumn2.AppearanceCell.Options.UseFont = True
        GridColumn2.AppearanceHeader.Font = New Font("Microsoft YaHei UI", 9.25F)
        GridColumn2.AppearanceHeader.Options.UseFont = True
        GridColumn2.Caption = "Existencias"
        GridColumn2.FieldName = "Cantidad"
        GridColumn2.MaxWidth = 80
        GridColumn2.Name = "GridColumn2"
        GridColumn2.OptionsColumn.AllowEdit = False
        GridColumn2.Visible = True
        GridColumn2.VisibleIndex = 1
        GridColumn2.Width = 80
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(461, 871)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 3
        btnSalir.TabStop = False
        btnSalir.Text = "Volver"
        ' 
        ' frmInformacionArticulo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(625, 950)
        Controls.Add(btnSalir)
        Controls.Add(GridControlLotes)
        Controls.Add(GroupControl1)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(0, 80)
        Name = "frmInformacionArticulo"
        Padding = New Padding(10)
        StartPosition = FormStartPosition.Manual
        Text = "frmInformacionArticulo"
        CType(GroupControl1, ComponentModel.ISupportInitialize).EndInit()
        GroupControl1.ResumeLayout(False)
        GroupControl1.PerformLayout()
        CType(PictureBoxItemImage, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlLotes, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewLotes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label4 As Label
    Friend WithEvents TextEditItem As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureBoxItemImage As PictureBox
    Friend WithEvents LabelItemPVP As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTotalStock As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewLotes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
