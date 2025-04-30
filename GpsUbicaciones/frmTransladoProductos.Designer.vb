<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransladoProductos
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransladoProductos))
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        gvDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        grdProductos = New DevExpress.XtraGrid.GridControl()
        Label1 = New Label()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        btnAgregarArticulo = New DevExpress.XtraEditors.SimpleButton()
        nupUnidades = New DevExpress.XtraEditors.SpinEdit()
        Label2 = New Label()
        lblStock = New DevExpress.XtraEditors.LabelControl()
        Label3 = New Label()
        lblNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        lblUbicacion = New Label()
        teCodigoUbicacion = New DevExpress.XtraEditors.TextEdit()
        lblArticulo = New Label()
        lblNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        teCodigoArticulo = New DevExpress.XtraEditors.TextEdit()
        btnConsultaArtUbiacion = New Button()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label4 = New Label()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(gvDatos, ComponentModel.ISupportInitialize).BeginInit()
        CType(grdProductos, ComponentModel.ISupportInitialize).BeginInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(nupUnidades.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(teCodigoUbicacion.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(teCodigoArticulo.Properties, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupControl1
        ' 
        GroupControl1.Appearance.BackColor = SystemColors.Control
        GroupControl1.Appearance.BorderColor = Color.White
        GroupControl1.Appearance.ForeColor = Color.White
        GroupControl1.Appearance.Options.UseBackColor = True
        GroupControl1.Appearance.Options.UseBorderColor = True
        GroupControl1.Appearance.Options.UseForeColor = True
        GroupControl1.AppearanceCaption.ForeColor = Color.White
        GroupControl1.AppearanceCaption.Options.UseForeColor = True
        GroupControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink
        GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        GroupControl1.Location = New Point(15, 666)
        GroupControl1.Margin = New Padding(2, 3, 2, 3)
        GroupControl1.MaximumSize = New Size(575, 0)
        GroupControl1.MinimumSize = New Size(500, 150)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Size = New Size(573, 150)
        GroupControl1.TabIndex = 12
        GroupControl1.Text = "ORIGEN"
        ' 
        ' gvDatos
        ' 
        gvDatos.GridControl = grdProductos
        gvDatos.Name = "gvDatos"
        ' 
        ' grdProductos
        ' 
        grdProductos.BackgroundImageLayout = ImageLayout.None
        grdProductos.EmbeddedNavigator.Margin = New Padding(4, 3, 4, 3)
        grdProductos.Location = New Point(13, 310)
        grdProductos.MainView = gvDatos
        grdProductos.MinimumSize = New Size(0, 350)
        grdProductos.Name = "grdProductos"
        grdProductos.Size = New Size(574, 350)
        grdProductos.TabIndex = 13
        grdProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {gvDatos})
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(295, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 13)
        Label1.TabIndex = 14
        Label1.Text = "ALMACEN: 00"
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), Image)
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.Image = CType(resources.GetObject("btnSalir.ImageOptions.Image"), Image)
        btnSalir.Location = New Point(436, 821)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 15
        btnSalir.Text = "Salir"
        ' 
        ' GroupControlUbicacion
        ' 
        GroupControlUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlUbicacion.Appearance.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        GroupControlUbicacion.Appearance.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.BorderColor = Color.MidnightBlue
        GroupControlUbicacion.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlUbicacion.AppearanceCaption.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseBorderColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseFont = True
        GroupControlUbicacion.Controls.Add(btnAgregarArticulo)
        GroupControlUbicacion.Controls.Add(nupUnidades)
        GroupControlUbicacion.Controls.Add(Label2)
        GroupControlUbicacion.Controls.Add(lblStock)
        GroupControlUbicacion.Controls.Add(Label3)
        GroupControlUbicacion.Controls.Add(lblNombreUbicacion)
        GroupControlUbicacion.Controls.Add(lblUbicacion)
        GroupControlUbicacion.Controls.Add(teCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(lblArticulo)
        GroupControlUbicacion.Controls.Add(lblNombreArticulo)
        GroupControlUbicacion.Controls.Add(teCodigoArticulo)
        GroupControlUbicacion.Controls.Add(btnConsultaArtUbiacion)
        GroupControlUbicacion.Controls.Add(btnUbicacion)
        GroupControlUbicacion.Location = New Point(15, 62)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 10)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Padding = New Padding(20, 10, 20, 10)
        GroupControlUbicacion.Size = New Size(574, 235)
        GroupControlUbicacion.TabIndex = 16
        GroupControlUbicacion.Text = "ORIGEN"
        ' 
        ' btnAgregarArticulo
        ' 
        btnAgregarArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAgregarArticulo.ImageOptions.Image = CType(resources.GetObject("btnAgregarArticulo.ImageOptions.Image"), Image)
        btnAgregarArticulo.Location = New Point(493, 177)
        btnAgregarArticulo.Margin = New Padding(4, 3, 4, 3)
        btnAgregarArticulo.Name = "btnAgregarArticulo"
        btnAgregarArticulo.Size = New Size(55, 47)
        btnAgregarArticulo.TabIndex = 26
        btnAgregarArticulo.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        btnAgregarArticulo.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' nupUnidades
        ' 
        nupUnidades.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        nupUnidades.Location = New Point(152, 186)
        nupUnidades.Name = "nupUnidades"
        nupUnidades.Properties.Appearance.Font = New Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        nupUnidades.Properties.Appearance.Options.UseFont = True
        nupUnidades.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        nupUnidades.Properties.IsFloatValue = False
        nupUnidades.Properties.MaskSettings.Set("mask", "N00")
        nupUnidades.Size = New Size(108, 24)
        nupUnidades.TabIndex = 25
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Tahoma", 15.75F)
        Label2.Location = New Point(26, 183)
        Label2.Margin = New Padding(3, 0, 0, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 25)
        Label2.TabIndex = 24
        Label2.Text = "CANTIDAD"
        ' 
        ' lblStock
        ' 
        lblStock.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblStock.Appearance.BackColor = Color.RoyalBlue
        lblStock.Appearance.Font = New Font("Tahoma", 15.75F)
        lblStock.Appearance.ForeColor = Color.White
        lblStock.Appearance.Options.UseBackColor = True
        lblStock.Appearance.Options.UseFont = True
        lblStock.Appearance.Options.UseForeColor = True
        lblStock.Appearance.Options.UseTextOptions = True
        lblStock.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        lblStock.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblStock.Location = New Point(396, 108)
        lblStock.Margin = New Padding(4, 3, 4, 3)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(152, 28)
        lblStock.TabIndex = 23
        lblStock.Text = "Stock"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Tahoma", 15.75F)
        Label3.Location = New Point(316, 109)
        Label3.Margin = New Padding(3, 0, 0, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(76, 25)
        Label3.TabIndex = 22
        Label3.Text = "STOCK"
        ' 
        ' lblNombreUbicacion
        ' 
        lblNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        lblNombreUbicacion.Appearance.Font = New Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNombreUbicacion.Appearance.ForeColor = Color.White
        lblNombreUbicacion.Appearance.Options.UseBackColor = True
        lblNombreUbicacion.Appearance.Options.UseFont = True
        lblNombreUbicacion.Appearance.Options.UseForeColor = True
        lblNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblNombreUbicacion.Location = New Point(26, 143)
        lblNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        lblNombreUbicacion.Name = "lblNombreUbicacion"
        lblNombreUbicacion.Size = New Size(523, 28)
        lblNombreUbicacion.TabIndex = 21
        lblNombreUbicacion.Text = "Nombre Ubicación"
        ' 
        ' lblUbicacion
        ' 
        lblUbicacion.AutoSize = True
        lblUbicacion.Font = New Font("Tahoma", 15.75F)
        lblUbicacion.Location = New Point(25, 109)
        lblUbicacion.Margin = New Padding(3, 0, 0, 6)
        lblUbicacion.Name = "lblUbicacion"
        lblUbicacion.Size = New Size(123, 25)
        lblUbicacion.TabIndex = 20
        lblUbicacion.Text = "UBICACIÓN"
        ' 
        ' teCodigoUbicacion
        ' 
        teCodigoUbicacion.Location = New Point(154, 109)
        teCodigoUbicacion.Margin = New Padding(6, 3, 3, 6)
        teCodigoUbicacion.MinimumSize = New Size(0, 25)
        teCodigoUbicacion.Name = "teCodigoUbicacion"
        teCodigoUbicacion.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        teCodigoUbicacion.Properties.Appearance.Options.UseFont = True
        teCodigoUbicacion.Properties.MaxLength = 13
        teCodigoUbicacion.Size = New Size(156, 25)
        teCodigoUbicacion.TabIndex = 19
        ' 
        ' lblArticulo
        ' 
        lblArticulo.AutoSize = True
        lblArticulo.Font = New Font("Tahoma", 15.75F)
        lblArticulo.Location = New Point(25, 33)
        lblArticulo.Margin = New Padding(3, 0, 0, 6)
        lblArticulo.Name = "lblArticulo"
        lblArticulo.Size = New Size(110, 25)
        lblArticulo.TabIndex = 18
        lblArticulo.Text = "ARTÍCULO"
        ' 
        ' lblNombreArticulo
        ' 
        lblNombreArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblNombreArticulo.Appearance.BackColor = Color.RoyalBlue
        lblNombreArticulo.Appearance.Font = New Font("Tahoma", 15.75F)
        lblNombreArticulo.Appearance.ForeColor = Color.White
        lblNombreArticulo.Appearance.Options.UseBackColor = True
        lblNombreArticulo.Appearance.Options.UseFont = True
        lblNombreArticulo.Appearance.Options.UseForeColor = True
        lblNombreArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblNombreArticulo.Location = New Point(25, 67)
        lblNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        lblNombreArticulo.Name = "lblNombreArticulo"
        lblNombreArticulo.Size = New Size(523, 28)
        lblNombreArticulo.TabIndex = 17
        lblNombreArticulo.Text = "Nombre Artículo"
        ' 
        ' teCodigoArticulo
        ' 
        teCodigoArticulo.Location = New Point(141, 33)
        teCodigoArticulo.Margin = New Padding(6, 3, 3, 6)
        teCodigoArticulo.MinimumSize = New Size(0, 25)
        teCodigoArticulo.Name = "teCodigoArticulo"
        teCodigoArticulo.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        teCodigoArticulo.Properties.Appearance.Options.UseFont = True
        teCodigoArticulo.Properties.MaxLength = 13
        teCodigoArticulo.Size = New Size(156, 25)
        teCodigoArticulo.TabIndex = 12
        ' 
        ' btnConsultaArtUbiacion
        ' 
        btnConsultaArtUbiacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnConsultaArtUbiacion.BackColor = Color.White
        btnConsultaArtUbiacion.BackgroundImage = CType(resources.GetObject("btnConsultaArtUbiacion.BackgroundImage"), Image)
        btnConsultaArtUbiacion.BackgroundImageLayout = ImageLayout.Stretch
        btnConsultaArtUbiacion.Location = New Point(816, 68)
        btnConsultaArtUbiacion.Name = "btnConsultaArtUbiacion"
        btnConsultaArtUbiacion.Size = New Size(34, 33)
        btnConsultaArtUbiacion.TabIndex = 8
        btnConsultaArtUbiacion.UseVisualStyleBackColor = False
        ' 
        ' btnUbicacion
        ' 
        btnUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUbicacion.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        btnUbicacion.Location = New Point(875, 33)
        btnUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnUbicacion.Name = "btnUbicacion"
        btnUbicacion.Size = New Size(55, 47)
        btnUbicacion.TabIndex = 6
        btnUbicacion.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        btnUbicacion.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' PanelTitulo
        ' 
        PanelTitulo.BackColor = Color.RoyalBlue
        PanelTitulo.Controls.Add(LabelControl2)
        PanelTitulo.Controls.Add(Label4)
        PanelTitulo.Dock = DockStyle.Top
        PanelTitulo.Location = New Point(10, 10)
        PanelTitulo.Name = "PanelTitulo"
        PanelTitulo.Size = New Size(580, 48)
        PanelTitulo.TabIndex = 17
        ' 
        ' LabelControl2
        ' 
        LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelControl2.ImageOptions.Image = CType(resources.GetObject("LabelControl2.ImageOptions.Image"), Image)
        LabelControl2.Location = New Point(10, 3)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(56, 42)
        LabelControl2.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(325, 7)
        Label4.Name = "Label4"
        Label4.Size = New Size(241, 31)
        Label4.TabIndex = 1
        Label4.Text = "Trasladar Articulos"
        ' 
        ' frmTransladoProductos
        ' 
        Appearance.BackColor = Color.Gainsboro
        Appearance.BorderColor = SystemColors.Highlight
        Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.ControlText
        Appearance.Options.UseBackColor = True
        Appearance.Options.UseBorderColor = True
        Appearance.Options.UseFont = True
        Appearance.Options.UseForeColor = True
        AutoScaleDimensions = New SizeF(5F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        ClientSize = New Size(600, 900)
        Controls.Add(PanelTitulo)
        Controls.Add(GroupControlUbicacion)
        Controls.Add(btnSalir)
        Controls.Add(Label1)
        Controls.Add(grdProductos)
        Controls.Add(GroupControl1)
        FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(2, 3, 2, 3)
        MinimumSize = New Size(600, 900)
        Name = "frmTransladoProductos"
        Padding = New Padding(10)
        StartPosition = FormStartPosition.Manual
        Text = "Translado Mercancía"
        CType(GroupControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(gvDatos, ComponentModel.ISupportInitialize).EndInit()
        CType(grdProductos, ComponentModel.ISupportInitialize).EndInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).EndInit()
        GroupControlUbicacion.ResumeLayout(False)
        GroupControlUbicacion.PerformLayout()
        CType(nupUnidades.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(teCodigoUbicacion.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(teCodigoArticulo.Properties, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ddbArticulo As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gvDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblArticulo As Label
    Friend WithEvents lblNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents teCodigoArticulo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnConsultaArtUbiacion As Button
    Friend WithEvents btnUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStock As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents teCodigoUbicacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents nupUnidades As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAgregarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
End Class