<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignar
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignar))
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        btnConsultaArtUbiacion = New Button()
        lblAlmacenNombre = New DevExpress.XtraEditors.LabelControl()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        txtUbicacion = New TextBox()
        lblUbicacionNombre = New DevExpress.XtraEditors.LabelControl()
        GroupControlArticulos = New DevExpress.XtraEditors.GroupControl()
        lblPorPeso = New Label()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        btnNuevaUbicacion = New DevExpress.XtraEditors.SimpleButton()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        txtNuevoStock = New TextBox()
        btnArticulo = New DevExpress.XtraEditors.SimpleButton()
        txtArticulo = New TextBox()
        lblArticuloNombre = New DevExpress.XtraEditors.LabelControl()
        Grid = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(Grid, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), Image)
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.Image = CType(resources.GetObject("btnSalir.ImageOptions.Image"), Image)
        btnSalir.Location = New Point(437, 875)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 3
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
        GroupControlUbicacion.Controls.Add(btnConsultaArtUbiacion)
        GroupControlUbicacion.Controls.Add(lblAlmacenNombre)
        GroupControlUbicacion.Controls.Add(btnUbicacion)
        GroupControlUbicacion.Controls.Add(txtUbicacion)
        GroupControlUbicacion.Controls.Add(lblUbicacionNombre)
        GroupControlUbicacion.Location = New Point(9, 54)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Size = New Size(578, 100)
        GroupControlUbicacion.TabIndex = 0
        GroupControlUbicacion.Text = "Leer Ubicación"
        ' 
        ' btnConsultaArtUbiacion
        ' 
        btnConsultaArtUbiacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnConsultaArtUbiacion.BackgroundImage = CType(resources.GetObject("btnConsultaArtUbiacion.BackgroundImage"), Image)
        btnConsultaArtUbiacion.BackgroundImageLayout = ImageLayout.Stretch
        btnConsultaArtUbiacion.Location = New Point(470, 59)
        btnConsultaArtUbiacion.Name = "btnConsultaArtUbiacion"
        btnConsultaArtUbiacion.Size = New Size(34, 36)
        btnConsultaArtUbiacion.TabIndex = 8
        btnConsultaArtUbiacion.UseVisualStyleBackColor = True
        ' 
        ' lblAlmacenNombre
        ' 
        lblAlmacenNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAlmacenNombre.Appearance.BackColor = Color.RoyalBlue
        lblAlmacenNombre.Appearance.Font = New Font("Tahoma", 15.75F)
        lblAlmacenNombre.Appearance.ForeColor = Color.White
        lblAlmacenNombre.Appearance.Options.UseBackColor = True
        lblAlmacenNombre.Appearance.Options.UseFont = True
        lblAlmacenNombre.Appearance.Options.UseForeColor = True
        lblAlmacenNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblAlmacenNombre.Location = New Point(209, 29)
        lblAlmacenNombre.Margin = New Padding(4, 3, 4, 3)
        lblAlmacenNombre.Name = "lblAlmacenNombre"
        lblAlmacenNombre.Size = New Size(295, 28)
        lblAlmacenNombre.TabIndex = 7
        lblAlmacenNombre.Text = "Nombre Almacen"
        ' 
        ' btnUbicacion
        ' 
        btnUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUbicacion.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        btnUbicacion.Location = New Point(517, 30)
        btnUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnUbicacion.Name = "btnUbicacion"
        btnUbicacion.Size = New Size(55, 50)
        btnUbicacion.TabIndex = 6
        btnUbicacion.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        btnUbicacion.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' txtUbicacion
        ' 
        txtUbicacion.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtUbicacion.Location = New Point(16, 27)
        txtUbicacion.Margin = New Padding(4, 3, 4, 3)
        txtUbicacion.MaxLength = 13
        txtUbicacion.Name = "txtUbicacion"
        txtUbicacion.Size = New Size(185, 33)
        txtUbicacion.TabIndex = 5
        ' 
        ' lblUbicacionNombre
        ' 
        lblUbicacionNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUbicacionNombre.Appearance.BackColor = Color.RoyalBlue
        lblUbicacionNombre.Appearance.Font = New Font("Tahoma", 12.25F)
        lblUbicacionNombre.Appearance.ForeColor = Color.White
        lblUbicacionNombre.Appearance.Options.UseBackColor = True
        lblUbicacionNombre.Appearance.Options.UseFont = True
        lblUbicacionNombre.Appearance.Options.UseForeColor = True
        lblUbicacionNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblUbicacionNombre.Location = New Point(18, 67)
        lblUbicacionNombre.Margin = New Padding(4, 3, 4, 3)
        lblUbicacionNombre.Name = "lblUbicacionNombre"
        lblUbicacionNombre.Size = New Size(445, 28)
        lblUbicacionNombre.TabIndex = 4
        lblUbicacionNombre.Text = "Nombre Ubicación"
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(lblPorPeso)
        GroupControlArticulos.Controls.Add(LabelControl3)
        GroupControlArticulos.Controls.Add(btnNuevaUbicacion)
        GroupControlArticulos.Controls.Add(LabelControl1)
        GroupControlArticulos.Controls.Add(txtNuevoStock)
        GroupControlArticulos.Controls.Add(btnArticulo)
        GroupControlArticulos.Controls.Add(txtArticulo)
        GroupControlArticulos.Controls.Add(lblArticuloNombre)
        GroupControlArticulos.Location = New Point(9, 162)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 136)
        GroupControlArticulos.TabIndex = 1
        GroupControlArticulos.Text = "Leer Artículos"
        ' 
        ' lblPorPeso
        ' 
        lblPorPeso.BackColor = Color.White
        lblPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPorPeso.ForeColor = Color.Red
        lblPorPeso.Location = New Point(233, 105)
        lblPorPeso.Name = "lblPorPeso"
        lblPorPeso.Size = New Size(230, 25)
        lblPorPeso.TabIndex = 12
        lblPorPeso.Text = "** Por Peso/Fracción **"
        lblPorPeso.TextAlign = ContentAlignment.MiddleCenter
        lblPorPeso.Visible = False
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl3.Appearance.Options.UseFont = True
        LabelControl3.Location = New Point(18, 30)
        LabelControl3.Margin = New Padding(3, 2, 3, 2)
        LabelControl3.Name = "LabelControl3"
        LabelControl3.Size = New Size(55, 19)
        LabelControl3.TabIndex = 11
        LabelControl3.Text = "Artículo"
        ' 
        ' btnNuevaUbicacion
        ' 
        btnNuevaUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnNuevaUbicacion.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNuevaUbicacion.Appearance.Options.UseFont = True
        btnNuevaUbicacion.CausesValidation = False
        btnNuevaUbicacion.Location = New Point(380, 21)
        btnNuevaUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnNuevaUbicacion.Name = "btnNuevaUbicacion"
        btnNuevaUbicacion.Size = New Size(124, 39)
        btnNuevaUbicacion.TabIndex = 10
        btnNuevaUbicacion.Text = "Nueva Ubicación"
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(18, 108)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(39, 19)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Stock"
        ' 
        ' txtNuevoStock
        ' 
        txtNuevoStock.Font = New Font("Tahoma", 15.75F)
        txtNuevoStock.Location = New Point(80, 100)
        txtNuevoStock.Margin = New Padding(4, 3, 4, 3)
        txtNuevoStock.Name = "txtNuevoStock"
        txtNuevoStock.Size = New Size(121, 33)
        txtNuevoStock.TabIndex = 2
        txtNuevoStock.TextAlign = HorizontalAlignment.Right
        ' 
        ' btnArticulo
        ' 
        btnArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnArticulo.ImageOptions.Image = CType(resources.GetObject("btnArticulo.ImageOptions.Image"), Image)
        btnArticulo.Location = New Point(517, 66)
        btnArticulo.Margin = New Padding(4, 3, 4, 3)
        btnArticulo.Name = "btnArticulo"
        btnArticulo.Size = New Size(55, 50)
        btnArticulo.TabIndex = 3
        ' 
        ' txtArticulo
        ' 
        txtArticulo.Font = New Font("Tahoma", 15.75F)
        txtArticulo.Location = New Point(80, 27)
        txtArticulo.Margin = New Padding(4, 3, 4, 3)
        txtArticulo.Name = "txtArticulo"
        txtArticulo.Size = New Size(121, 33)
        txtArticulo.TabIndex = 1
        ' 
        ' lblArticuloNombre
        ' 
        lblArticuloNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblArticuloNombre.Appearance.BackColor = Color.RoyalBlue
        lblArticuloNombre.Appearance.Font = New Font("Tahoma", 15.75F)
        lblArticuloNombre.Appearance.ForeColor = Color.White
        lblArticuloNombre.Appearance.Options.UseBackColor = True
        lblArticuloNombre.Appearance.Options.UseFont = True
        lblArticuloNombre.Appearance.Options.UseForeColor = True
        lblArticuloNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblArticuloNombre.Location = New Point(15, 66)
        lblArticuloNombre.Margin = New Padding(4, 3, 4, 3)
        lblArticuloNombre.Name = "lblArticuloNombre"
        lblArticuloNombre.Size = New Size(489, 28)
        lblArticuloNombre.TabIndex = 4
        lblArticuloNombre.Text = "Nombre Articulo"
        ' 
        ' Grid
        ' 
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        Grid.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Grid.Location = New Point(10, 303)
        Grid.MainView = GridView1
        Grid.Margin = New Padding(3, 2, 3, 2)
        Grid.Name = "Grid"
        Grid.Size = New Size(579, 567)
        Grid.TabIndex = 7
        Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        Grid.Visible = False
        ' 
        ' GridView1
        ' 
        GridView1.DetailHeight = 262
        GridView1.GridControl = Grid
        GridView1.Name = "GridView1"
        GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridView1.OptionsBehavior.Editable = False
        GridView1.OptionsEditForm.PopupEditFormWidth = 700
        GridView1.OptionsView.ShowGroupPanel = False
        ' 
        ' PanelTitulo
        ' 
        PanelTitulo.BackColor = Color.RoyalBlue
        PanelTitulo.Controls.Add(LabelControl2)
        PanelTitulo.Controls.Add(Label1)
        PanelTitulo.Dock = DockStyle.Top
        PanelTitulo.Location = New Point(0, 0)
        PanelTitulo.Name = "PanelTitulo"
        PanelTitulo.Size = New Size(600, 48)
        PanelTitulo.TabIndex = 8
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(325, 7)
        Label1.Name = "Label1"
        Label1.Size = New Size(241, 32)
        Label1.TabIndex = 1
        Label1.Text = "Asignar Artículos"
        ' 
        ' frmAsignar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightBlue
        ClientSize = New Size(600, 950)
        ControlBox = False
        Controls.Add(PanelTitulo)
        Controls.Add(Grid)
        Controls.Add(GroupControlArticulos)
        Controls.Add(GroupControlUbicacion)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Location = New Point(0, 80)
        Margin = New Padding(3, 2, 3, 2)
        MinimumSize = New Size(600, 900)
        Name = "frmAsignar"
        StartPosition = FormStartPosition.Manual
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).EndInit()
        GroupControlUbicacion.ResumeLayout(False)
        GroupControlUbicacion.PerformLayout()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).EndInit()
        GroupControlArticulos.ResumeLayout(False)
        GroupControlArticulos.PerformLayout()
        CType(Grid, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents lblUbicacionNombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtArticulo As TextBox
    Friend WithEvents lblArticuloNombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNuevoStock As TextBox
    Friend WithEvents btnNuevaUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblAlmacenNombre As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnConsultaArtUbiacion As Button
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPorPeso As Label
End Class
