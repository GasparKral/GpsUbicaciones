<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSeleccionArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionArticulos))
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        lblPorPeso = New Label()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        lblAlmacen = New DevExpress.XtraEditors.LabelControl()
        lblStock = New DevExpress.XtraEditors.LabelControl()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        txtNuevoStock = New TextBox()
        txtUbicacion = New TextBox()
        txtArticulo = New TextBox()
        lblUbicacionNombre = New DevExpress.XtraEditors.LabelControl()
        lblArticuloNombre = New DevExpress.XtraEditors.LabelControl()
        Grid = New DevExpress.XtraGrid.GridControl()
        GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        RadioButton2 = New RadioButton()
        RadioButton1 = New RadioButton()
        DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        GridPedidos = New DevExpress.XtraGrid.GridControl()
        GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(Grid, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        GroupControl1.SuspendLayout()
        CType(DateEdit1.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(DateEdit1.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridPedidos, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridView2, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.Location = New Point(439, 824)
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
        GroupControlUbicacion.Controls.Add(lblPorPeso)
        GroupControlUbicacion.Controls.Add(LabelControl1)
        GroupControlUbicacion.Controls.Add(lblAlmacen)
        GroupControlUbicacion.Controls.Add(lblStock)
        GroupControlUbicacion.Controls.Add(btnUbicacion)
        GroupControlUbicacion.Controls.Add(txtNuevoStock)
        GroupControlUbicacion.Controls.Add(txtUbicacion)
        GroupControlUbicacion.Controls.Add(txtArticulo)
        GroupControlUbicacion.Controls.Add(lblUbicacionNombre)
        GroupControlUbicacion.Controls.Add(lblArticuloNombre)
        GroupControlUbicacion.Location = New Point(14, 219)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Size = New Size(578, 145)
        GroupControlUbicacion.TabIndex = 1
        GroupControlUbicacion.Text = "Leer Artículos (Ubicacion / Articulo)"
        ' 
        ' lblPorPeso
        ' 
        lblPorPeso.BackColor = Color.White
        lblPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPorPeso.ForeColor = Color.Red
        lblPorPeso.Location = New Point(295, 109)
        lblPorPeso.Name = "lblPorPeso"
        lblPorPeso.Size = New Size(209, 25)
        lblPorPeso.TabIndex = 13
        lblPorPeso.Text = "** Por Peso/Fracción **"
        lblPorPeso.TextAlign = ContentAlignment.MiddleCenter
        lblPorPeso.Visible = False
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelControl1.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(16, 109)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(83, 25)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Cantidad"
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
        lblAlmacen.Location = New Point(184, 28)
        lblAlmacen.Margin = New Padding(4, 3, 4, 3)
        lblAlmacen.Name = "lblAlmacen"
        lblAlmacen.Size = New Size(147, 28)
        lblAlmacen.TabIndex = 7
        lblAlmacen.Text = "Nombre Almacen"
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
        lblStock.Location = New Point(184, 106)
        lblStock.Margin = New Padding(4, 3, 4, 3)
        lblStock.Name = "lblStock"
        lblStock.Size = New Size(104, 28)
        lblStock.TabIndex = 8
        lblStock.Text = "Stock"
        ' 
        ' btnUbicacion
        ' 
        btnUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUbicacion.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        btnUbicacion.Location = New Point(511, 95)
        btnUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnUbicacion.Name = "btnUbicacion"
        btnUbicacion.Size = New Size(55, 50)
        btnUbicacion.TabIndex = 6
        ' 
        ' txtNuevoStock
        ' 
        txtNuevoStock.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtNuevoStock.Font = New Font("Tahoma", 15.75F)
        txtNuevoStock.Location = New Point(108, 105)
        txtNuevoStock.Margin = New Padding(4, 3, 4, 3)
        txtNuevoStock.Name = "txtNuevoStock"
        txtNuevoStock.Size = New Size(68, 33)
        txtNuevoStock.TabIndex = 2
        txtNuevoStock.TextAlign = HorizontalAlignment.Right
        ' 
        ' txtUbicacion
        ' 
        txtUbicacion.Font = New Font("Tahoma", 15.75F)
        txtUbicacion.Location = New Point(16, 27)
        txtUbicacion.Margin = New Padding(4, 3, 4, 3)
        txtUbicacion.Name = "txtUbicacion"
        txtUbicacion.Size = New Size(160, 33)
        txtUbicacion.TabIndex = 0
        ' 
        ' txtArticulo
        ' 
        txtArticulo.Font = New Font("Tahoma", 15.75F)
        txtArticulo.Location = New Point(16, 66)
        txtArticulo.Margin = New Padding(4, 3, 4, 3)
        txtArticulo.Name = "txtArticulo"
        txtArticulo.Size = New Size(160, 33)
        txtArticulo.TabIndex = 1
        ' 
        ' lblUbicacionNombre
        ' 
        lblUbicacionNombre.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblUbicacionNombre.Appearance.BackColor = Color.RoyalBlue
        lblUbicacionNombre.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblUbicacionNombre.Appearance.ForeColor = Color.White
        lblUbicacionNombre.Appearance.Options.UseBackColor = True
        lblUbicacionNombre.Appearance.Options.UseFont = True
        lblUbicacionNombre.Appearance.Options.UseForeColor = True
        lblUbicacionNombre.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblUbicacionNombre.Location = New Point(349, 27)
        lblUbicacionNombre.Margin = New Padding(4, 3, 4, 3)
        lblUbicacionNombre.Name = "lblUbicacionNombre"
        lblUbicacionNombre.Size = New Size(217, 28)
        lblUbicacionNombre.TabIndex = 4
        lblUbicacionNombre.Text = "Nombre Ubicación"
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
        lblArticuloNombre.Location = New Point(184, 66)
        lblArticuloNombre.Margin = New Padding(4, 3, 4, 3)
        lblArticuloNombre.Name = "lblArticuloNombre"
        lblArticuloNombre.Size = New Size(382, 28)
        lblArticuloNombre.TabIndex = 4
        lblArticuloNombre.Text = "Nombre Articulo"
        ' 
        ' Grid
        ' 
        Grid.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Grid.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        Grid.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Grid.Location = New Point(13, 369)
        Grid.MainView = GridView1
        Grid.Margin = New Padding(3, 2, 3, 2)
        Grid.Name = "Grid"
        Grid.Size = New Size(579, 362)
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
        LabelControl2.Appearance.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        LabelControl2.Appearance.Options.UseBackColor = True
        LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelControl2.ImageOptions.Image = CType(resources.GetObject("LabelControl2.ImageOptions.Image"), Image)
        LabelControl2.Location = New Point(10, 3)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(57, 42)
        LabelControl2.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(253, 7)
        Label1.Name = "Label1"
        Label1.Size = New Size(281, 31)
        Label1.TabIndex = 1
        Label1.Text = "Selección de Artículos"
        ' 
        ' GroupControl1
        ' 
        GroupControl1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControl1.Controls.Add(SimpleButton1)
        GroupControl1.Controls.Add(RadioButton2)
        GroupControl1.Controls.Add(RadioButton1)
        GroupControl1.Location = New Point(14, 736)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Size = New Size(576, 83)
        GroupControl1.TabIndex = 2
        GroupControl1.Text = "Destino"
        ' 
        ' SimpleButton1
        ' 
        SimpleButton1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), Image)
        SimpleButton1.Location = New Point(515, 26)
        SimpleButton1.Margin = New Padding(4, 3, 4, 3)
        SimpleButton1.Name = "SimpleButton1"
        SimpleButton1.Size = New Size(55, 50)
        SimpleButton1.TabIndex = 7
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Font = New Font("Tahoma", 15.75F)
        RadioButton2.Location = New Point(229, 32)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(200, 29)
        RadioButton2.TabIndex = 1
        RadioButton2.TabStop = True
        RadioButton2.Text = "Traspaso Almacén"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Font = New Font("Tahoma", 15.75F)
        RadioButton1.Location = New Point(52, 32)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(102, 29)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Albarán"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' DateEdit1
        ' 
        DateEdit1.EditValue = Nothing
        DateEdit1.Location = New Point(86, 54)
        DateEdit1.Name = "DateEdit1"
        DateEdit1.Properties.Appearance.Font = New Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateEdit1.Properties.Appearance.Options.UseFont = True
        DateEdit1.Properties.AppearanceCalendar.DayCell.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateEdit1.Properties.AppearanceCalendar.DayCell.Options.UseFont = True
        DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DateEdit1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent
        DateEdit1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False
        DateEdit1.Size = New Size(188, 40)
        DateEdit1.TabIndex = 0
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelControl3.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl3.Appearance.Options.UseFont = True
        LabelControl3.Location = New Point(14, 62)
        LabelControl3.Margin = New Padding(3, 2, 3, 2)
        LabelControl3.Name = "LabelControl3"
        LabelControl3.Size = New Size(55, 25)
        LabelControl3.TabIndex = 11
        LabelControl3.Text = "Fecha"
        ' 
        ' GridPedidos
        ' 
        GridPedidos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridPedidos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridPedidos.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridPedidos.Location = New Point(14, 99)
        GridPedidos.MainView = GridView2
        GridPedidos.Margin = New Padding(3, 2, 3, 2)
        GridPedidos.Name = "GridPedidos"
        GridPedidos.Size = New Size(579, 115)
        GridPedidos.TabIndex = 12
        GridPedidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView2})
        ' 
        ' GridView2
        ' 
        GridView2.DetailHeight = 262
        GridView2.GridControl = GridPedidos
        GridView2.Name = "GridView2"
        GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridView2.OptionsBehavior.Editable = False
        GridView2.OptionsEditForm.PopupEditFormWidth = 700
        GridView2.OptionsView.ShowGroupPanel = False
        ' 
        ' frmSeleccionArticulos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SkyBlue
        ClientSize = New Size(600, 900)
        ControlBox = False
        Controls.Add(GridPedidos)
        Controls.Add(LabelControl3)
        Controls.Add(DateEdit1)
        Controls.Add(GroupControl1)
        Controls.Add(PanelTitulo)
        Controls.Add(Grid)
        Controls.Add(GroupControlUbicacion)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Location = New Point(0, 80)
        Margin = New Padding(3, 2, 3, 2)
        MinimumSize = New Size(600, 900)
        Name = "frmSeleccionArticulos"
        StartPosition = FormStartPosition.Manual
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).EndInit()
        GroupControlUbicacion.ResumeLayout(False)
        GroupControlUbicacion.PerformLayout()
        CType(Grid, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView1, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).EndInit()
        GroupControl1.ResumeLayout(False)
        GroupControl1.PerformLayout()
        CType(DateEdit1.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(DateEdit1.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridPedidos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents lblUbicacionNombre As DevExpress.XtraEditors.LabelControl
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
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GridPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblPorPeso As Label
End Class
