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
        ButtonConsultarUbicacion = New Button()
        LabelNombreAlmacen = New DevExpress.XtraEditors.LabelControl()
        BotonConfirmacionDeUbicacion = New DevExpress.XtraEditors.SimpleButton()
        TextBoxCodigoUbicacion = New TextBox()
        LabelNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        GroupControlArticulos = New DevExpress.XtraEditors.GroupControl()
        LabelIndicadorPorPeso = New Label()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        btnNuevaUbicacion = New DevExpress.XtraEditors.SimpleButton()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        TextBoxStockArticulo = New TextBox()
        ButtonConfirmacionArticulo = New DevExpress.XtraEditors.SimpleButton()
        TextBoxCodigoArticulo = New TextBox()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        GridControlAsignacionArticulos = New DevExpress.XtraGrid.GridControl()
        GridViewAsignacionArticulos = New DevExpress.XtraGrid.Views.Grid.GridView()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(GridControlAsignacionArticulos, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewAsignacionArticulos, ComponentModel.ISupportInitialize).BeginInit()
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
        GroupControlUbicacion.Controls.Add(ButtonConsultarUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreAlmacen)
        GroupControlUbicacion.Controls.Add(BotonConfirmacionDeUbicacion)
        GroupControlUbicacion.Controls.Add(TextBoxCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Location = New Point(9, 54)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Size = New Size(578, 100)
        GroupControlUbicacion.TabIndex = 0
        GroupControlUbicacion.Text = "Leer Ubicación"
        ' 
        ' ButtonConsultarUbicacion
        ' 
        ButtonConsultarUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConsultarUbicacion.BackgroundImage = CType(resources.GetObject("ButtonConsultarUbicacion.BackgroundImage"), Image)
        ButtonConsultarUbicacion.BackgroundImageLayout = ImageLayout.Stretch
        ButtonConsultarUbicacion.Location = New Point(470, 59)
        ButtonConsultarUbicacion.Name = "ButtonConsultarUbicacion"
        ButtonConsultarUbicacion.Size = New Size(34, 36)
        ButtonConsultarUbicacion.TabIndex = 8
        ButtonConsultarUbicacion.UseVisualStyleBackColor = True
        ' 
        ' LabelNombreAlmacen
        ' 
        LabelNombreAlmacen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreAlmacen.Appearance.BackColor = Color.RoyalBlue
        LabelNombreAlmacen.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelNombreAlmacen.Appearance.ForeColor = Color.White
        LabelNombreAlmacen.Appearance.Options.UseBackColor = True
        LabelNombreAlmacen.Appearance.Options.UseFont = True
        LabelNombreAlmacen.Appearance.Options.UseForeColor = True
        LabelNombreAlmacen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreAlmacen.Location = New Point(209, 29)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Size = New Size(295, 28)
        LabelNombreAlmacen.TabIndex = 7
        LabelNombreAlmacen.Text = "Nombre Almacen"
        ' 
        ' BotonConfirmacionDeUbicacion
        ' 
        BotonConfirmacionDeUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonConfirmacionDeUbicacion.ImageOptions.Image = CType(resources.GetObject("BotonConfirmacionDeUbicacion.ImageOptions.Image"), Image)
        BotonConfirmacionDeUbicacion.Location = New Point(517, 30)
        BotonConfirmacionDeUbicacion.Margin = New Padding(4, 3, 4, 3)
        BotonConfirmacionDeUbicacion.Name = "BotonConfirmacionDeUbicacion"
        BotonConfirmacionDeUbicacion.Size = New Size(55, 50)
        BotonConfirmacionDeUbicacion.TabIndex = 6
        BotonConfirmacionDeUbicacion.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        BotonConfirmacionDeUbicacion.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' TextBoxCodigoUbicacion
        ' 
        TextBoxCodigoUbicacion.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCodigoUbicacion.Location = New Point(16, 27)
        TextBoxCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoUbicacion.MaxLength = 13
        TextBoxCodigoUbicacion.Name = "TextBoxCodigoUbicacion"
        TextBoxCodigoUbicacion.Size = New Size(185, 33)
        TextBoxCodigoUbicacion.TabIndex = 5
        ' 
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 12.25F)
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(18, 67)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Size = New Size(445, 28)
        LabelNombreUbicacion.TabIndex = 4
        LabelNombreUbicacion.Text = "Nombre Ubicación"
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(LabelIndicadorPorPeso)
        GroupControlArticulos.Controls.Add(LabelControl3)
        GroupControlArticulos.Controls.Add(btnNuevaUbicacion)
        GroupControlArticulos.Controls.Add(LabelControl1)
        GroupControlArticulos.Controls.Add(TextBoxStockArticulo)
        GroupControlArticulos.Controls.Add(ButtonConfirmacionArticulo)
        GroupControlArticulos.Controls.Add(TextBoxCodigoArticulo)
        GroupControlArticulos.Controls.Add(LabelNombreArticulo)
        GroupControlArticulos.Location = New Point(9, 162)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 136)
        GroupControlArticulos.TabIndex = 1
        GroupControlArticulos.Text = "Leer Artículos"
        GroupControlArticulos.Visible = False
        ' 
        ' LabelIndicadorPorPeso
        ' 
        LabelIndicadorPorPeso.BackColor = Color.White
        LabelIndicadorPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPeso.ForeColor = Color.Red
        LabelIndicadorPorPeso.Location = New Point(233, 105)
        LabelIndicadorPorPeso.Name = "LabelIndicadorPorPeso"
        LabelIndicadorPorPeso.Size = New Size(230, 25)
        LabelIndicadorPorPeso.TabIndex = 12
        LabelIndicadorPorPeso.Text = "** Por Peso/Fracción **"
        LabelIndicadorPorPeso.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPeso.Visible = False
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
        ' TextBoxStockArticulo
        ' 
        TextBoxStockArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxStockArticulo.Location = New Point(80, 100)
        TextBoxStockArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxStockArticulo.Name = "TextBoxStockArticulo"
        TextBoxStockArticulo.Size = New Size(121, 33)
        TextBoxStockArticulo.TabIndex = 2
        TextBoxStockArticulo.TextAlign = HorizontalAlignment.Right
        ' 
        ' ButtonConfirmacionArticulo
        ' 
        ButtonConfirmacionArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionArticulo.ImageOptions.Image = CType(resources.GetObject("ButtonConfirmacionArticulo.ImageOptions.Image"), Image)
        ButtonConfirmacionArticulo.Location = New Point(517, 66)
        ButtonConfirmacionArticulo.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionArticulo.Name = "ButtonConfirmacionArticulo"
        ButtonConfirmacionArticulo.Size = New Size(55, 50)
        ButtonConfirmacionArticulo.TabIndex = 3
        ' 
        ' TextBoxCodigoArticulo
        ' 
        TextBoxCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoArticulo.Location = New Point(80, 27)
        TextBoxCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoArticulo.Name = "TextBoxCodigoArticulo"
        TextBoxCodigoArticulo.Size = New Size(121, 33)
        TextBoxCodigoArticulo.TabIndex = 1
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
        LabelNombreArticulo.Location = New Point(15, 66)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Size = New Size(489, 28)
        LabelNombreArticulo.TabIndex = 4
        LabelNombreArticulo.Text = "Nombre Articulo"
        ' 
        ' GridControlAsignacionArticulos
        ' 
        GridControlAsignacionArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlAsignacionArticulos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridControlAsignacionArticulos.Location = New Point(10, 303)
        GridControlAsignacionArticulos.MainView = GridViewAsignacionArticulos
        GridControlAsignacionArticulos.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Name = "GridControlAsignacionArticulos"
        GridControlAsignacionArticulos.Size = New Size(579, 567)
        GridControlAsignacionArticulos.TabIndex = 7
        GridControlAsignacionArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewAsignacionArticulos})
        GridControlAsignacionArticulos.Visible = False
        ' 
        ' GridViewAsignacionArticulos
        ' 
        GridViewAsignacionArticulos.DetailHeight = 262
        GridViewAsignacionArticulos.GridControl = GridControlAsignacionArticulos
        GridViewAsignacionArticulos.Name = "GridViewAsignacionArticulos"
        GridViewAsignacionArticulos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewAsignacionArticulos.OptionsBehavior.Editable = False
        GridViewAsignacionArticulos.OptionsEditForm.PopupEditFormWidth = 700
        GridViewAsignacionArticulos.OptionsView.ShowGroupPanel = False
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
        Controls.Add(GridControlAsignacionArticulos)
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
        CType(GridControlAsignacionArticulos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewAsignacionArticulos, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BotonConfirmacionDeUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBoxCodigoUbicacion As TextBox
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ButtonConfirmacionArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBoxCodigoArticulo As TextBox
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBoxStockArticulo As TextBox
    Friend WithEvents btnNuevaUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlAsignacionArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAsignacionArticulos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ButtonConsultarUbicacion As Button
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelIndicadorPorPeso As Label
End Class
