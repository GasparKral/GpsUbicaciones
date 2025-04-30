<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVenta))
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        lblAlmacen = New DevExpress.XtraEditors.LabelControl()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        txtUbicacion = New TextBox()
        lblUbicacionNombre = New DevExpress.XtraEditors.LabelControl()
        GroupControlArticulos = New DevExpress.XtraEditors.GroupControl()
        lblPorPeso = New Label()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        lblStock = New DevExpress.XtraEditors.LabelControl()
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
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.BackgroundImage = CType(resources.GetObject("btnSalir.BackgroundImage"), Image)
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.Image = CType(resources.GetObject("btnSalir.ImageOptions.Image"), Image)
        btnSalir.Location = New Point(438, 822)
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
        GroupControlUbicacion.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlUbicacion.AppearanceCaption.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseFont = True
        GroupControlUbicacion.Controls.Add(lblAlmacen)
        GroupControlUbicacion.Controls.Add(btnUbicacion)
        GroupControlUbicacion.Controls.Add(txtUbicacion)
        GroupControlUbicacion.Controls.Add(lblUbicacionNombre)
        GroupControlUbicacion.Location = New Point(10, 54)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Size = New Size(578, 98)
        GroupControlUbicacion.TabIndex = 0
        GroupControlUbicacion.Text = "Leer Ubicación"
        ' 
        ' lblAlmacen
        ' 
        lblAlmacen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblAlmacen.Appearance.BackColor = Color.RoyalBlue
        lblAlmacen.Appearance.Font = New Font("Tahoma", 15.75F)
        lblAlmacen.Appearance.ForeColor = Color.White
        lblAlmacen.Appearance.Options.UseBackColor = True
        lblAlmacen.Appearance.Options.UseFont = True
        lblAlmacen.Appearance.Options.UseForeColor = True
        lblAlmacen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblAlmacen.Location = New Point(209, 28)
        lblAlmacen.Margin = New Padding(4, 3, 4, 3)
        lblAlmacen.Name = "lblAlmacen"
        lblAlmacen.Size = New Size(296, 28)
        lblAlmacen.TabIndex = 7
        lblAlmacen.Text = "Nombre Almacen"
        ' 
        ' btnUbicacion
        ' 
        btnUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUbicacion.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        btnUbicacion.Location = New Point(519, 26)
        btnUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnUbicacion.Name = "btnUbicacion"
        btnUbicacion.Size = New Size(55, 50)
        btnUbicacion.TabIndex = 6
        ' 
        ' txtUbicacion
        ' 
        txtUbicacion.Font = New Font("Tahoma", 15.75F)
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
        lblUbicacionNombre.Appearance.Font = New Font("Tahoma", 15.75F)
        lblUbicacionNombre.Appearance.ForeColor = Color.White
        lblUbicacionNombre.Appearance.Options.UseBackColor = True
        lblUbicacionNombre.Appearance.Options.UseFont = True
        lblUbicacionNombre.Appearance.Options.UseForeColor = True
        lblUbicacionNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblUbicacionNombre.Location = New Point(16, 64)
        lblUbicacionNombre.Margin = New Padding(4, 3, 4, 3)
        lblUbicacionNombre.Name = "lblUbicacionNombre"
        lblUbicacionNombre.Size = New Size(489, 28)
        lblUbicacionNombre.TabIndex = 4
        lblUbicacionNombre.Text = "Nombre Ubicación"
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(lblPorPeso)
        GroupControlArticulos.Controls.Add(LabelControl1)
        GroupControlArticulos.Controls.Add(lblStock)
        GroupControlArticulos.Controls.Add(txtNuevoStock)
        GroupControlArticulos.Controls.Add(btnArticulo)
        GroupControlArticulos.Controls.Add(txtArticulo)
        GroupControlArticulos.Controls.Add(lblArticuloNombre)
        GroupControlArticulos.Location = New Point(11, 158)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 121)
        GroupControlArticulos.TabIndex = 1
        GroupControlArticulos.Text = "Leer Artículos"
        GroupControlArticulos.Visible = False
        ' 
        ' lblPorPeso
        ' 
        lblPorPeso.BackColor = Color.White
        lblPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPorPeso.ForeColor = Color.Red
        lblPorPeso.Location = New Point(124, 73)
        lblPorPeso.Name = "lblPorPeso"
        lblPorPeso.Size = New Size(207, 25)
        lblPorPeso.TabIndex = 13
        lblPorPeso.Text = "** Por Peso/Fracción **"
        lblPorPeso.TextAlign = ContentAlignment.MiddleCenter
        lblPorPeso.Visible = False
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelControl1.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(337, 73)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(83, 25)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Cantidad"
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
        lblStock.Location = New Point(16, 70)
        lblStock.Margin = New Padding(4, 3, 4, 3)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(89, 28)
        lblStock.TabIndex = 8
        lblStock.Text = "Stock"
        ' 
        ' txtNuevoStock
        ' 
        txtNuevoStock.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtNuevoStock.Font = New Font("Tahoma", 15.75F)
        txtNuevoStock.Location = New Point(427, 69)
        txtNuevoStock.Margin = New Padding(4, 3, 4, 3)
        txtNuevoStock.Name = "txtNuevoStock"
        txtNuevoStock.Size = New Size(78, 33)
        txtNuevoStock.TabIndex = 2
        txtNuevoStock.TextAlign = HorizontalAlignment.Right
        ' 
        ' btnArticulo
        ' 
        btnArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnArticulo.ImageOptions.Image = CType(resources.GetObject("btnArticulo.ImageOptions.Image"), Image)
        btnArticulo.Location = New Point(517, 64)
        btnArticulo.Margin = New Padding(4, 3, 4, 3)
        btnArticulo.Name = "btnArticulo"
        btnArticulo.Size = New Size(55, 50)
        btnArticulo.TabIndex = 3
        ' 
        ' txtArticulo
        ' 
        txtArticulo.Font = New Font("Tahoma", 15.75F)
        txtArticulo.Location = New Point(16, 27)
        txtArticulo.Margin = New Padding(4, 3, 4, 3)
        txtArticulo.MaxLength = 15
        txtArticulo.Name = "txtArticulo"
        txtArticulo.Size = New Size(182, 33)
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
        lblArticuloNombre.Location = New Point(206, 28)
        lblArticuloNombre.Margin = New Padding(4, 3, 4, 3)
        lblArticuloNombre.Name = "lblArticuloNombre"
        lblArticuloNombre.Size = New Size(366, 28)
        lblArticuloNombre.TabIndex = 4
        lblArticuloNombre.Text = "Nombre Articulo"
        ' 
        ' Grid
        ' 
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        Grid.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Grid.Location = New Point(10, 284)
        Grid.MainView = GridView1
        Grid.Margin = New Padding(3, 2, 3, 2)
        Grid.Name = "Grid"
        Grid.Size = New Size(579, 532)
        Grid.TabIndex = 7
        Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
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
        LabelControl2.Appearance.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        LabelControl2.Appearance.Options.UseBackColor = True
        LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelControl2.ImageOptions.Image = CType(resources.GetObject("LabelControl2.ImageOptions.Image"), Image)
        LabelControl2.Location = New Point(10, 3)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(69, 45)
        LabelControl2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(372, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(216, 32)
        Label1.TabIndex = 1
        Label1.Text = "Venta Artículos"
        ' 
        ' frmVenta
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CadetBlue
        ClientSize = New Size(600, 900)
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
        Name = "frmVenta"
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
    Friend WithEvents lblStock As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNuevoStock As TextBox
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPorPeso As Label
End Class
