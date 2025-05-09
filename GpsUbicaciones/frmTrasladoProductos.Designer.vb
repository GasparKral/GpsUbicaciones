<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTrasladoProductos
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrasladoProductos))
        GridViewArticulosParaTraslado = New DevExpress.XtraGrid.Views.Grid.GridView()
        GridControlArticulosParaTraslado = New DevExpress.XtraGrid.GridControl()
        Label1 = New Label()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        LabelIndicadorPorPesoOrigen = New Label()
        BotonAgregarArticulo = New DevExpress.XtraEditors.SimpleButton()
        SpinEditCantidadSeleccionadaOrigen = New DevExpress.XtraEditors.SpinEdit()
        Label2 = New Label()
        LabelStockArticuloOrigen = New DevExpress.XtraEditors.LabelControl()
        Label3 = New Label()
        LabelNombreUbicacionOrigen = New DevExpress.XtraEditors.LabelControl()
        lblUbicacion = New Label()
        TextEditCodigoUbicacionOrigen = New DevExpress.XtraEditors.TextEdit()
        lblArticulo = New Label()
        LabelNombreArticuloOrigen = New DevExpress.XtraEditors.LabelControl()
        TextEditCodigoArticuloOrigen = New DevExpress.XtraEditors.TextEdit()
        btnConsultaArtUbiacion = New Button()
        btnUbicacion = New DevExpress.XtraEditors.SimpleButton()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label4 = New Label()
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        BotonConfirmarTraslado = New DevExpress.XtraEditors.SimpleButton()
        LabelIndicadorPorPesoDestino = New Label()
        SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        SpinEditCantidadSeleccionadaDestino = New DevExpress.XtraEditors.SpinEdit()
        Label5 = New Label()
        LabelStockArticuloDestino = New DevExpress.XtraEditors.LabelControl()
        Label6 = New Label()
        LabelNombreUbicacionDestino = New DevExpress.XtraEditors.LabelControl()
        Label7 = New Label()
        TextEditCodigoUbicacionDestino = New DevExpress.XtraEditors.TextEdit()
        Label8 = New Label()
        LabelNombreArticuloDestino = New DevExpress.XtraEditors.LabelControl()
        TextEditCodigoArticuloDestino = New DevExpress.XtraEditors.TextEdit()
        Button1 = New Button()
        SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(components)
        CType(GridViewArticulosParaTraslado, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlArticulosParaTraslado, ComponentModel.ISupportInitialize).BeginInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(SpinEditCantidadSeleccionadaOrigen.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoUbicacionOrigen.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoArticuloOrigen.Properties, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        GroupControl1.SuspendLayout()
        CType(SpinEditCantidadSeleccionadaDestino.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoUbicacionDestino.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditCodigoArticuloDestino.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(BehaviorManager1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GridViewArticulosParaTraslado
        ' 
        GridViewArticulosParaTraslado.GridControl = GridControlArticulosParaTraslado
        GridViewArticulosParaTraslado.Name = "GridViewArticulosParaTraslado"
        ' 
        ' GridControlArticulosParaTraslado
        ' 
        GridControlArticulosParaTraslado.BackgroundImageLayout = ImageLayout.None
        GridControlArticulosParaTraslado.EmbeddedNavigator.Margin = New Padding(6, 3, 6, 3)
        GridControlArticulosParaTraslado.Location = New Point(10, 310)
        GridControlArticulosParaTraslado.MainView = GridViewArticulosParaTraslado
        GridControlArticulosParaTraslado.MinimumSize = New Size(0, 300)
        GridControlArticulosParaTraslado.Name = "GridControlArticulosParaTraslado"
        GridControlArticulosParaTraslado.Size = New Size(580, 300)
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
        btnSalir.Location = New Point(436, 933)
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
        GroupControlUbicacion.Controls.Add(LabelIndicadorPorPesoOrigen)
        GroupControlUbicacion.Controls.Add(BotonAgregarArticulo)
        GroupControlUbicacion.Controls.Add(SpinEditCantidadSeleccionadaOrigen)
        GroupControlUbicacion.Controls.Add(Label2)
        GroupControlUbicacion.Controls.Add(LabelStockArticuloOrigen)
        GroupControlUbicacion.Controls.Add(Label3)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacionOrigen)
        GroupControlUbicacion.Controls.Add(lblUbicacion)
        GroupControlUbicacion.Controls.Add(TextEditCodigoUbicacionOrigen)
        GroupControlUbicacion.Controls.Add(lblArticulo)
        GroupControlUbicacion.Controls.Add(LabelNombreArticuloOrigen)
        GroupControlUbicacion.Controls.Add(TextEditCodigoArticuloOrigen)
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
        ' LabelIndicadorPorPesoOrigen
        ' 
        LabelIndicadorPorPesoOrigen.BackColor = Color.White
        LabelIndicadorPorPesoOrigen.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPesoOrigen.ForeColor = Color.Red
        LabelIndicadorPorPesoOrigen.Location = New Point(262, 186)
        LabelIndicadorPorPesoOrigen.Name = "LabelIndicadorPorPesoOrigen"
        LabelIndicadorPorPesoOrigen.Size = New Size(230, 25)
        LabelIndicadorPorPesoOrigen.TabIndex = 28
        LabelIndicadorPorPesoOrigen.Text = "** Por Peso/Fracción **"
        LabelIndicadorPorPesoOrigen.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPesoOrigen.Visible = False
        ' 
        ' BotonAgregarArticulo
        ' 
        BotonAgregarArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonAgregarArticulo.ImageOptions.Image = CType(resources.GetObject("BotonAgregarArticulo.ImageOptions.Image"), Image)
        BotonAgregarArticulo.Location = New Point(499, 177)
        BotonAgregarArticulo.Margin = New Padding(4, 3, 4, 3)
        BotonAgregarArticulo.Name = "BotonAgregarArticulo"
        BotonAgregarArticulo.Size = New Size(55, 47)
        BotonAgregarArticulo.TabIndex = 26
        BotonAgregarArticulo.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        BotonAgregarArticulo.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' SpinEditCantidadSeleccionadaOrigen
        ' 
        SpinEditCantidadSeleccionadaOrigen.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionadaOrigen.Location = New Point(152, 186)
        SpinEditCantidadSeleccionadaOrigen.Name = "SpinEditCantidadSeleccionadaOrigen"
        SpinEditCantidadSeleccionadaOrigen.Properties.Appearance.Font = New Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SpinEditCantidadSeleccionadaOrigen.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionadaOrigen.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        SpinEditCantidadSeleccionadaOrigen.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionadaOrigen.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionadaOrigen.Size = New Size(108, 24)
        SpinEditCantidadSeleccionadaOrigen.TabIndex = 25
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
        ' LabelStockArticuloOrigen
        ' 
        LabelStockArticuloOrigen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelStockArticuloOrigen.Appearance.BackColor = Color.RoyalBlue
        LabelStockArticuloOrigen.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelStockArticuloOrigen.Appearance.ForeColor = Color.White
        LabelStockArticuloOrigen.Appearance.Options.UseBackColor = True
        LabelStockArticuloOrigen.Appearance.Options.UseFont = True
        LabelStockArticuloOrigen.Appearance.Options.UseForeColor = True
        LabelStockArticuloOrigen.Appearance.Options.UseTextOptions = True
        LabelStockArticuloOrigen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelStockArticuloOrigen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticuloOrigen.Location = New Point(396, 108)
        LabelStockArticuloOrigen.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticuloOrigen.Name = "LabelStockArticuloOrigen"
        LabelStockArticuloOrigen.Size = New Size(158, 28)
        LabelStockArticuloOrigen.TabIndex = 23
        LabelStockArticuloOrigen.Text = "Stock"
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
        ' LabelNombreUbicacionOrigen
        ' 
        LabelNombreUbicacionOrigen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacionOrigen.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacionOrigen.Appearance.Font = New Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelNombreUbicacionOrigen.Appearance.ForeColor = Color.White
        LabelNombreUbicacionOrigen.Appearance.Options.UseBackColor = True
        LabelNombreUbicacionOrigen.Appearance.Options.UseFont = True
        LabelNombreUbicacionOrigen.Appearance.Options.UseForeColor = True
        LabelNombreUbicacionOrigen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacionOrigen.Location = New Point(26, 143)
        LabelNombreUbicacionOrigen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacionOrigen.Name = "LabelNombreUbicacionOrigen"
        LabelNombreUbicacionOrigen.Size = New Size(529, 28)
        LabelNombreUbicacionOrigen.TabIndex = 21
        LabelNombreUbicacionOrigen.Text = "Nombre Ubicación"
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
        ' TextEditCodigoUbicacionOrigen
        ' 
        TextEditCodigoUbicacionOrigen.Enabled = False
        TextEditCodigoUbicacionOrigen.Location = New Point(154, 109)
        TextEditCodigoUbicacionOrigen.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoUbicacionOrigen.MinimumSize = New Size(0, 25)
        TextEditCodigoUbicacionOrigen.Name = "TextEditCodigoUbicacionOrigen"
        TextEditCodigoUbicacionOrigen.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoUbicacionOrigen.Properties.Appearance.Options.UseFont = True
        TextEditCodigoUbicacionOrigen.Properties.MaxLength = 13
        TextEditCodigoUbicacionOrigen.Size = New Size(156, 25)
        TextEditCodigoUbicacionOrigen.TabIndex = 19
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
        ' LabelNombreArticuloOrigen
        ' 
        LabelNombreArticuloOrigen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticuloOrigen.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticuloOrigen.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelNombreArticuloOrigen.Appearance.ForeColor = Color.White
        LabelNombreArticuloOrigen.Appearance.Options.UseBackColor = True
        LabelNombreArticuloOrigen.Appearance.Options.UseFont = True
        LabelNombreArticuloOrigen.Appearance.Options.UseForeColor = True
        LabelNombreArticuloOrigen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticuloOrigen.Location = New Point(25, 67)
        LabelNombreArticuloOrigen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticuloOrigen.Name = "LabelNombreArticuloOrigen"
        LabelNombreArticuloOrigen.Size = New Size(529, 28)
        LabelNombreArticuloOrigen.TabIndex = 17
        LabelNombreArticuloOrigen.Text = "Nombre Artículo"
        ' 
        ' TextEditCodigoArticuloOrigen
        ' 
        TextEditCodigoArticuloOrigen.Location = New Point(141, 33)
        TextEditCodigoArticuloOrigen.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoArticuloOrigen.MinimumSize = New Size(0, 25)
        TextEditCodigoArticuloOrigen.Name = "TextEditCodigoArticuloOrigen"
        TextEditCodigoArticuloOrigen.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoArticuloOrigen.Properties.Appearance.Options.UseFont = True
        TextEditCodigoArticuloOrigen.Properties.MaxLength = 13
        TextEditCodigoArticuloOrigen.Size = New Size(156, 25)
        TextEditCodigoArticuloOrigen.TabIndex = 12
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
        ' GroupControl1
        ' 
        GroupControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControl1.Appearance.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        GroupControl1.Appearance.Options.UseBackColor = True
        GroupControl1.AppearanceCaption.BorderColor = Color.MidnightBlue
        GroupControl1.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControl1.AppearanceCaption.Options.UseBackColor = True
        GroupControl1.AppearanceCaption.Options.UseBorderColor = True
        GroupControl1.AppearanceCaption.Options.UseFont = True
        GroupControl1.Controls.Add(BotonConfirmarTraslado)
        GroupControl1.Controls.Add(LabelIndicadorPorPesoDestino)
        GroupControl1.Controls.Add(SimpleButton1)
        GroupControl1.Controls.Add(SpinEditCantidadSeleccionadaDestino)
        GroupControl1.Controls.Add(Label5)
        GroupControl1.Controls.Add(LabelStockArticuloDestino)
        GroupControl1.Controls.Add(Label6)
        GroupControl1.Controls.Add(LabelNombreUbicacionDestino)
        GroupControl1.Controls.Add(Label7)
        GroupControl1.Controls.Add(TextEditCodigoUbicacionDestino)
        GroupControl1.Controls.Add(Label8)
        GroupControl1.Controls.Add(LabelNombreArticuloDestino)
        GroupControl1.Controls.Add(TextEditCodigoArticuloDestino)
        GroupControl1.Controls.Add(Button1)
        GroupControl1.Controls.Add(SimpleButton2)
        GroupControl1.Location = New Point(10, 616)
        GroupControl1.Margin = New Padding(4, 3, 4, 10)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Padding = New Padding(20, 10, 20, 10)
        GroupControl1.Size = New Size(580, 248)
        GroupControl1.TabIndex = 27
        GroupControl1.Text = "DESTINO"
        ' 
        ' BotonConfirmarTraslado
        ' 
        BotonConfirmarTraslado.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonConfirmarTraslado.ImageOptions.Image = CType(resources.GetObject("BotonConfirmarTraslado.ImageOptions.Image"), Image)
        BotonConfirmarTraslado.Location = New Point(500, 187)
        BotonConfirmarTraslado.Margin = New Padding(4, 3, 4, 3)
        BotonConfirmarTraslado.Name = "BotonConfirmarTraslado"
        BotonConfirmarTraslado.Size = New Size(55, 47)
        BotonConfirmarTraslado.TabIndex = 29
        BotonConfirmarTraslado.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        BotonConfirmarTraslado.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' LabelIndicadorPorPesoDestino
        ' 
        LabelIndicadorPorPesoDestino.BackColor = Color.White
        LabelIndicadorPorPesoDestino.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPesoDestino.ForeColor = Color.Red
        LabelIndicadorPorPesoDestino.Location = New Point(266, 193)
        LabelIndicadorPorPesoDestino.Name = "LabelIndicadorPorPesoDestino"
        LabelIndicadorPorPesoDestino.Size = New Size(230, 25)
        LabelIndicadorPorPesoDestino.TabIndex = 28
        LabelIndicadorPorPesoDestino.Text = "** Por Peso/Fracción **"
        LabelIndicadorPorPesoDestino.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPesoDestino.Visible = False
        ' 
        ' SimpleButton1
        ' 
        SimpleButton1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), Image)
        SimpleButton1.Location = New Point(859, 187)
        SimpleButton1.Margin = New Padding(4, 3, 4, 3)
        SimpleButton1.Name = "SimpleButton1"
        SimpleButton1.Size = New Size(55, 47)
        SimpleButton1.TabIndex = 26
        SimpleButton1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        SimpleButton1.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' SpinEditCantidadSeleccionadaDestino
        ' 
        SpinEditCantidadSeleccionadaDestino.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionadaDestino.Enabled = False
        SpinEditCantidadSeleccionadaDestino.Location = New Point(152, 193)
        SpinEditCantidadSeleccionadaDestino.Name = "SpinEditCantidadSeleccionadaDestino"
        SpinEditCantidadSeleccionadaDestino.Properties.Appearance.Font = New Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SpinEditCantidadSeleccionadaDestino.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionadaDestino.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        SpinEditCantidadSeleccionadaDestino.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionadaDestino.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionadaDestino.Size = New Size(108, 24)
        SpinEditCantidadSeleccionadaDestino.TabIndex = 25
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Tahoma", 15.75F)
        Label5.Location = New Point(26, 192)
        Label5.Margin = New Padding(3, 0, 0, 6)
        Label5.Name = "Label5"
        Label5.Size = New Size(113, 25)
        Label5.TabIndex = 24
        Label5.Text = "CANTIDAD"
        ' 
        ' LabelStockArticuloDestino
        ' 
        LabelStockArticuloDestino.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelStockArticuloDestino.Appearance.BackColor = Color.RoyalBlue
        LabelStockArticuloDestino.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelStockArticuloDestino.Appearance.ForeColor = Color.White
        LabelStockArticuloDestino.Appearance.Options.UseBackColor = True
        LabelStockArticuloDestino.Appearance.Options.UseFont = True
        LabelStockArticuloDestino.Appearance.Options.UseForeColor = True
        LabelStockArticuloDestino.Appearance.Options.UseTextOptions = True
        LabelStockArticuloDestino.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelStockArticuloDestino.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticuloDestino.Location = New Point(397, 115)
        LabelStockArticuloDestino.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticuloDestino.Name = "LabelStockArticuloDestino"
        LabelStockArticuloDestino.Size = New Size(157, 28)
        LabelStockArticuloDestino.TabIndex = 23
        LabelStockArticuloDestino.Text = "Stock"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Tahoma", 15.75F)
        Label6.Location = New Point(316, 115)
        Label6.Margin = New Padding(3, 0, 0, 6)
        Label6.Name = "Label6"
        Label6.Size = New Size(76, 25)
        Label6.TabIndex = 22
        Label6.Text = "STOCK"
        ' 
        ' LabelNombreUbicacionDestino
        ' 
        LabelNombreUbicacionDestino.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacionDestino.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacionDestino.Appearance.Font = New Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelNombreUbicacionDestino.Appearance.ForeColor = Color.White
        LabelNombreUbicacionDestino.Appearance.Options.UseBackColor = True
        LabelNombreUbicacionDestino.Appearance.Options.UseFont = True
        LabelNombreUbicacionDestino.Appearance.Options.UseForeColor = True
        LabelNombreUbicacionDestino.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacionDestino.Location = New Point(26, 153)
        LabelNombreUbicacionDestino.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacionDestino.Name = "LabelNombreUbicacionDestino"
        LabelNombreUbicacionDestino.Size = New Size(528, 28)
        LabelNombreUbicacionDestino.TabIndex = 21
        LabelNombreUbicacionDestino.Text = "Nombre Ubicación"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Tahoma", 15.75F)
        Label7.Location = New Point(25, 113)
        Label7.Margin = New Padding(3, 0, 0, 6)
        Label7.Name = "Label7"
        Label7.Size = New Size(123, 25)
        Label7.TabIndex = 20
        Label7.Text = "UBICACIÓN"
        ' 
        ' TextEditCodigoUbicacionDestino
        ' 
        TextEditCodigoUbicacionDestino.Enabled = False
        TextEditCodigoUbicacionDestino.Location = New Point(154, 115)
        TextEditCodigoUbicacionDestino.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoUbicacionDestino.MinimumSize = New Size(0, 25)
        TextEditCodigoUbicacionDestino.Name = "TextEditCodigoUbicacionDestino"
        TextEditCodigoUbicacionDestino.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoUbicacionDestino.Properties.Appearance.Options.UseFont = True
        TextEditCodigoUbicacionDestino.Properties.MaxLength = 13
        TextEditCodigoUbicacionDestino.Size = New Size(156, 25)
        TextEditCodigoUbicacionDestino.TabIndex = 19
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Tahoma", 15.75F)
        Label8.Location = New Point(25, 37)
        Label8.Margin = New Padding(3, 0, 0, 6)
        Label8.Name = "Label8"
        Label8.Size = New Size(110, 25)
        Label8.TabIndex = 18
        Label8.Text = "ARTÍCULO"
        ' 
        ' LabelNombreArticuloDestino
        ' 
        LabelNombreArticuloDestino.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticuloDestino.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticuloDestino.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelNombreArticuloDestino.Appearance.ForeColor = Color.White
        LabelNombreArticuloDestino.Appearance.Options.UseBackColor = True
        LabelNombreArticuloDestino.Appearance.Options.UseFont = True
        LabelNombreArticuloDestino.Appearance.Options.UseForeColor = True
        LabelNombreArticuloDestino.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticuloDestino.Location = New Point(26, 71)
        LabelNombreArticuloDestino.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticuloDestino.Name = "LabelNombreArticuloDestino"
        LabelNombreArticuloDestino.Size = New Size(529, 28)
        LabelNombreArticuloDestino.TabIndex = 17
        LabelNombreArticuloDestino.Text = "Nombre Artículo"
        ' 
        ' TextEditCodigoArticuloDestino
        ' 
        TextEditCodigoArticuloDestino.Enabled = False
        TextEditCodigoArticuloDestino.Location = New Point(141, 37)
        TextEditCodigoArticuloDestino.Margin = New Padding(6, 3, 3, 6)
        TextEditCodigoArticuloDestino.MinimumSize = New Size(0, 25)
        TextEditCodigoArticuloDestino.Name = "TextEditCodigoArticuloDestino"
        TextEditCodigoArticuloDestino.Properties.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextEditCodigoArticuloDestino.Properties.Appearance.Options.UseFont = True
        TextEditCodigoArticuloDestino.Properties.MaxLength = 13
        TextEditCodigoArticuloDestino.Size = New Size(156, 25)
        TextEditCodigoArticuloDestino.TabIndex = 12
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = Color.White
        Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), Image)
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.Location = New Point(1182, 78)
        Button1.Name = "Button1"
        Button1.Size = New Size(34, 33)
        Button1.TabIndex = 8
        Button1.UseVisualStyleBackColor = False
        ' 
        ' SimpleButton2
        ' 
        SimpleButton2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), Image)
        SimpleButton2.Location = New Point(1241, 43)
        SimpleButton2.Margin = New Padding(4, 3, 4, 3)
        SimpleButton2.Name = "SimpleButton2"
        SimpleButton2.Size = New Size(55, 47)
        SimpleButton2.TabIndex = 6
        SimpleButton2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        SimpleButton2.ToolTipTitle = "Confirma Ubicación"
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
        ClientSize = New Size(600, 1012)
        Controls.Add(GroupControl1)
        Controls.Add(PanelTitulo)
        Controls.Add(GroupControlUbicacion)
        Controls.Add(btnSalir)
        Controls.Add(Label1)
        Controls.Add(GridControlArticulosParaTraslado)
        Font = New Font("Bahnschrift SemiCondensed", 8.25F)
        FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(2, 3, 2, 3)
        MinimumSize = New Size(600, 900)
        Name = "frmTransladoProductos"
        Padding = New Padding(10)
        StartPosition = FormStartPosition.Manual
        Text = "Translado Mercancía"
        CType(GridViewArticulosParaTraslado, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlArticulosParaTraslado, ComponentModel.ISupportInitialize).EndInit()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).EndInit()
        GroupControlUbicacion.ResumeLayout(False)
        GroupControlUbicacion.PerformLayout()
        CType(SpinEditCantidadSeleccionadaOrigen.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoUbicacionOrigen.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoArticuloOrigen.Properties, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).EndInit()
        GroupControl1.ResumeLayout(False)
        GroupControl1.PerformLayout()
        CType(SpinEditCantidadSeleccionadaDestino.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoUbicacionDestino.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditCodigoArticuloDestino.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(BehaviorManager1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ddbArticulo As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents GridViewArticulosParaTraslado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControlArticulosParaTraslado As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblArticulo As Label
    Friend WithEvents LabelNombreArticuloOrigen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditCodigoArticuloOrigen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnConsultaArtUbiacion As Button
    Friend WithEvents btnUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelStockArticuloOrigen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelNombreUbicacionOrigen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents TextEditCodigoUbicacionOrigen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SpinEditCantidadSeleccionadaOrigen As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents BotonAgregarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SpinEditCantidadSeleccionadaDestino As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelStockArticuloDestino As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label6 As Label
    Friend WithEvents LabelNombreUbicacionDestino As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label7 As Label
    Friend WithEvents TextEditCodigoUbicacionDestino As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelNombreArticuloDestino As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextEditCodigoArticuloDestino As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Button1 As Button
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelIndicadorPorPesoOrigen As Label
    Friend WithEvents BotonConfirmarTraslado As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelIndicadorPorPesoDestino As Label
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
End Class