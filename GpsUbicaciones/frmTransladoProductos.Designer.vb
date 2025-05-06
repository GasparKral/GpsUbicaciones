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
        GridViewArticulosParaTraslado = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridControlArticulosParaTraslado = New DevExpress.XtraGrid.GridControl()
        Label1 = New Label()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        btnAgregarArticulo = New DevExpress.XtraEditors.SimpleButton()
        SpinEditCantidadSeleccionada = New DevExpress.XtraEditors.SpinEdit()
        Label2 = New Label()
        LabelStockArticulo = New DevExpress.XtraEditors.LabelControl()
        Label3 = New Label()
        LabelNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        lblUbicacion = New Label()
        TextEditCodigoUbicacion = New DevExpress.XtraEditors.TextEdit()
        lblArticulo = New Label()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        TextEditCodigoArticulo = New DevExpress.XtraEditors.TextEdit()
        btnConsultaArtUbiacion = New Button()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label4 = New Label()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewArticulosParaTraslado, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlArticulosParaTraslado, ComponentModel.ISupportInitialize).BeginInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoUbicacion.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoArticulo.Properties, ComponentModel.ISupportInitialize).BeginInit()
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
        GroupControl1.Location = New Point(10, 666)
        GroupControl1.Margin = New Padding(2, 3, 2, 3)
        GroupControl1.MaximumSize = New Size(575, 0)
        GroupControl1.MinimumSize = New Size(500, 150)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Size = New Size(575, 150)
        GroupControl1.TabIndex = 12
        GroupControl1.Text = "ORIGEN"
        ' 
        ' GridViewArticulosParaTraslado
        ' 
        GridViewArticulosParaTraslado.GridControl = GridControlArticulosParaTraslado
        GridViewArticulosParaTraslado.Name = "GridViewArticulosParaTraslado"
        ' 
        ' GridControlArticulosParaTraslado
        ' 
        GridControlArticulosParaTraslado.BackgroundImageLayout = ImageLayout.None
        GridControlArticulosParaTraslado.EmbeddedNavigator.Margin = New Padding(4, 3, 4, 3)
        GridControlArticulosParaTraslado.Location = New Point(10, 310)
        GridControlArticulosParaTraslado.MainView = GridViewArticulosParaTraslado
        GridControlArticulosParaTraslado.MinimumSize = New Size(0, 350)
        GridControlArticulosParaTraslado.Name = "GridControlArticulosParaTraslado"
        GridControlArticulosParaTraslado.Size = New Size(580, 350)
        GridControlArticulosParaTraslado.TabIndex = 13
        GridControlArticulosParaTraslado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewArticulosParaTraslado})
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
        GroupControlUbicacion.Controls.Add(SpinEditCantidadSeleccionada)
        GroupControlUbicacion.Controls.Add(Label2)
        GroupControlUbicacion.Controls.Add(LabelStockArticulo)
        GroupControlUbicacion.Controls.Add(Label3)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Controls.Add(lblUbicacion)
        GroupControlUbicacion.Controls.Add(TextEditCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(lblArticulo)
        GroupControlUbicacion.Controls.Add(LabelNombreArticulo)
        GroupControlUbicacion.Controls.Add(TextEditCodigoArticulo)
        GroupControlUbicacion.Controls.Add(btnConsultaArtUbiacion)
        GroupControlUbicacion.Controls.Add(btnUbicacion)
        GroupControlUbicacion.Location = New Point(10, 62)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 10)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Padding = New Padding(20, 10, 20, 10)
        GroupControlUbicacion.Size = New Size(580, 235)
        GroupControlUbicacion.TabIndex = 16
        GroupControlUbicacion.Text = "ORIGEN"
        ' 
        ' btnAgregarArticulo
        ' 
        btnAgregarArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnAgregarArticulo.ImageOptions.Image = CType(resources.GetObject("btnAgregarArticulo.ImageOptions.Image"), Image)
        btnAgregarArticulo.Location = New Point(499, 177)
        btnAgregarArticulo.Margin = New Padding(4, 3, 4, 3)
        btnAgregarArticulo.Name = "btnAgregarArticulo"
        btnAgregarArticulo.Size = New Size(55, 47)
        btnAgregarArticulo.TabIndex = 26
        btnAgregarArticulo.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        btnAgregarArticulo.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' SpinEditCantidadSeleccionada
        ' 
        SpinEditCantidadSeleccionada.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionada.Location = New Point(152, 186)
        SpinEditCantidadSeleccionada.Name = "SpinEditCantidadSeleccionada"
        SpinEditCantidadSeleccionada.Properties.Appearance.Font = New Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SpinEditCantidadSeleccionada.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        SpinEditCantidadSeleccionada.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionada.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionada.Size = New Size(108, 24)
        SpinEditCantidadSeleccionada.TabIndex = 25
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
        ' LabelStockArticulo
        ' 
        LabelStockArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelStockArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelStockArticulo.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelStockArticulo.Appearance.ForeColor = Color.White
        LabelStockArticulo.Appearance.Options.UseBackColor = True
        LabelStockArticulo.Appearance.Options.UseFont = True
        LabelStockArticulo.Appearance.Options.UseForeColor = True
        LabelStockArticulo.Appearance.Options.UseTextOptions = True
        LabelStockArticulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelStockArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticulo.Location = New Point(396, 108)
        LabelStockArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticulo.Name = "LabelStockArticulo"
        LabelStockArticulo.Size = New Size(158, 28)
        LabelStockArticulo.TabIndex = 23
        LabelStockArticulo.Text = "Stock"
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
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(26, 143)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Size = New Size(529, 28)
        LabelNombreUbicacion.TabIndex = 21
        LabelNombreUbicacion.Text = "Nombre Ubicación"
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
        ' TextEditCodigoUbicacion
        ' 
        TextEditCodigoUbicacion.Location = New Point(154, 109)
        TextEditCodigoUbicacion.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoUbicacion.MinimumSize = New Size(0, 25)
        TextEditCodigoUbicacion.Name = "TextEditCodigoUbicacion"
        TextEditCodigoUbicacion.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoUbicacion.Properties.Appearance.Options.UseFont = True
        TextEditCodigoUbicacion.Properties.MaxLength = 13
        TextEditCodigoUbicacion.Size = New Size(156, 25)
        TextEditCodigoUbicacion.TabIndex = 19
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
        ' LabelNombreArticulo
        ' 
        LabelNombreArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticulo.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelNombreArticulo.Appearance.ForeColor = Color.White
        LabelNombreArticulo.Appearance.Options.UseBackColor = True
        LabelNombreArticulo.Appearance.Options.UseFont = True
        LabelNombreArticulo.Appearance.Options.UseForeColor = True
        LabelNombreArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(25, 67)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Size = New Size(529, 28)
        LabelNombreArticulo.TabIndex = 17
        LabelNombreArticulo.Text = "Nombre Artículo"
        ' 
        ' TextEditCodigoArticulo
        ' 
        TextEditCodigoArticulo.Location = New Point(141, 33)
        TextEditCodigoArticulo.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoArticulo.MinimumSize = New Size(0, 25)
        TextEditCodigoArticulo.Name = "TextEditCodigoArticulo"
        TextEditCodigoArticulo.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoArticulo.Properties.Appearance.Options.UseFont = True
        TextEditCodigoArticulo.Properties.MaxLength = 13
        TextEditCodigoArticulo.Size = New Size(156, 25)
        TextEditCodigoArticulo.TabIndex = 12
        ' 
        ' btnConsultaArtUbiacion
        ' 
        btnConsultaArtUbiacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnConsultaArtUbiacion.BackColor = Color.White
        btnConsultaArtUbiacion.BackgroundImage = CType(resources.GetObject("btnConsultaArtUbiacion.BackgroundImage"), Image)
        btnConsultaArtUbiacion.BackgroundImageLayout = ImageLayout.Stretch
        btnConsultaArtUbiacion.Location = New Point(822, 68)
        btnConsultaArtUbiacion.Name = "btnConsultaArtUbiacion"
        btnConsultaArtUbiacion.Size = New Size(34, 33)
        btnConsultaArtUbiacion.TabIndex = 8
        btnConsultaArtUbiacion.UseVisualStyleBackColor = False
        ' 
        ' btnUbicacion
        ' 
        btnUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUbicacion.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        btnUbicacion.Location = New Point(881, 33)
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
        Controls.Add(GridControlArticulosParaTraslado)
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
        CType(GridViewArticulosParaTraslado, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlArticulosParaTraslado, ComponentModel.ISupportInitialize).EndInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).EndInit()
        GroupControlUbicacion.ResumeLayout(False)
        GroupControlUbicacion.PerformLayout()
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoUbicacion.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoArticulo.Properties, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ddbArticulo As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridViewArticulosParaTraslado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControlArticulosParaTraslado As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblArticulo As Label
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditCodigoArticulo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnConsultaArtUbiacion As Button
    Friend WithEvents btnUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelStockArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents TextEditCodigoUbicacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SpinEditCantidadSeleccionada As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAgregarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
End Class