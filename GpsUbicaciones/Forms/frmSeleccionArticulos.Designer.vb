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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        ButtonConfirmacionLectura = New DevExpress.XtraEditors.SimpleButton()
        Label2 = New Label()
        Label3 = New Label()
        lblArticulo = New Label()
        lblUbicacion = New Label()
        SpinEditCantidadSeleccionada = New DevExpress.XtraEditors.SpinEdit()
        LabelIndicadorPorPeso = New Label()
        LabelNombreAlmacen = New DevExpress.XtraEditors.LabelControl()
        LabelStockArticulo = New DevExpress.XtraEditors.LabelControl()
        TextBoxCodigoUbicacion = New TextBox()
        TextBoxCodigoArticulo = New TextBox()
        LabelNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        GridControlArticulosSeleccionados = New DevExpress.XtraGrid.GridControl()
        GridViewArticulosSeleccionados = New DevExpress.XtraGrid.Views.Grid.GridView()
        ColumnItemRef = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnAmmount = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnDelete = New DevExpress.XtraGrid.Columns.GridColumn()
        RepositoryCancelButton = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        ButtonConfirmacionAccion = New DevExpress.XtraEditors.SimpleButton()
        RadioButtonOpcionTraspasoAlamacen = New RadioButton()
        RadioButtonOpcionAlbaran = New RadioButton()
        DatePicker = New DevExpress.XtraEditors.DateEdit()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        GridPedidos = New DevExpress.XtraGrid.GridControl()
        GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        ColumnRef = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnItem = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnPlacement = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnUnits = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnStock = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnState = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
        CType(RepositoryCancelButton, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).BeginInit()
        GroupControl1.SuspendLayout()
        CType(DatePicker.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(DatePicker.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.SvgImage = CType(resources.GetObject("btnSalir.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        btnSalir.Location = New Point(439, 824)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 3
        btnSalir.Text = "Volver"
        ' 
        ' GroupControlUbicacion
        ' 
        GroupControlUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlUbicacion.Appearance.BackColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        GroupControlUbicacion.Appearance.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlUbicacion.AppearanceCaption.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseFont = True
        GroupControlUbicacion.Controls.Add(ButtonConfirmacionLectura)
        GroupControlUbicacion.Controls.Add(Label2)
        GroupControlUbicacion.Controls.Add(Label3)
        GroupControlUbicacion.Controls.Add(lblArticulo)
        GroupControlUbicacion.Controls.Add(lblUbicacion)
        GroupControlUbicacion.Controls.Add(SpinEditCantidadSeleccionada)
        GroupControlUbicacion.Controls.Add(LabelIndicadorPorPeso)
        GroupControlUbicacion.Controls.Add(LabelNombreAlmacen)
        GroupControlUbicacion.Controls.Add(LabelStockArticulo)
        GroupControlUbicacion.Controls.Add(TextBoxCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(TextBoxCodigoArticulo)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreArticulo)
        GroupControlUbicacion.Location = New Point(13, 219)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Padding = New Padding(0, 0, 0, 10)
        GroupControlUbicacion.Size = New Size(577, 224)
        GroupControlUbicacion.TabIndex = 1
        GroupControlUbicacion.Text = "Leer Artículos (Ubicacion / Articulo)"
        ' 
        ' ButtonConfirmacionLectura
        ' 
        ButtonConfirmacionLectura.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionLectura.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        ButtonConfirmacionLectura.ImageOptions.SvgImage = CType(resources.GetObject("ButtonConfirmacionLectura.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        ButtonConfirmacionLectura.ImageOptions.SvgImageSize = New Size(45, 45)
        ButtonConfirmacionLectura.Location = New Point(514, 170)
        ButtonConfirmacionLectura.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionLectura.Name = "ButtonConfirmacionLectura"
        ButtonConfirmacionLectura.Size = New Size(50, 50)
        ButtonConfirmacionLectura.TabIndex = 8
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Tahoma", 15.75F)
        Label2.Location = New Point(16, 183)
        Label2.Margin = New Padding(3, 0, 0, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(113, 25)
        Label2.TabIndex = 30
        Label2.Text = "CANTIDAD"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Tahoma", 15.75F)
        Label3.Location = New Point(310, 102)
        Label3.Margin = New Padding(3, 0, 0, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(76, 25)
        Label3.TabIndex = 29
        Label3.Text = "STOCK"
        ' 
        ' lblArticulo
        ' 
        lblArticulo.AutoSize = True
        lblArticulo.Font = New Font("Tahoma", 15.75F)
        lblArticulo.Location = New Point(16, 102)
        lblArticulo.Margin = New Padding(3, 0, 0, 6)
        lblArticulo.Name = "lblArticulo"
        lblArticulo.Size = New Size(110, 25)
        lblArticulo.TabIndex = 28
        lblArticulo.Text = "ARTÍCULO"
        ' 
        ' lblUbicacion
        ' 
        lblUbicacion.AutoSize = True
        lblUbicacion.Font = New Font("Tahoma", 15.75F)
        lblUbicacion.Location = New Point(16, 31)
        lblUbicacion.Margin = New Padding(3, 0, 0, 6)
        lblUbicacion.Name = "lblUbicacion"
        lblUbicacion.Size = New Size(123, 25)
        lblUbicacion.TabIndex = 27
        lblUbicacion.Text = "UBICACIÓN"
        ' 
        ' SpinEditCantidadSeleccionada
        ' 
        SpinEditCantidadSeleccionada.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionada.Enabled = False
        SpinEditCantidadSeleccionada.Location = New Point(143, 176)
        SpinEditCantidadSeleccionada.Name = "SpinEditCantidadSeleccionada"
        SpinEditCantidadSeleccionada.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        SpinEditCantidadSeleccionada.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionada.Properties.AutoHeight = False
        SpinEditCantidadSeleccionada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 35, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        SpinEditCantidadSeleccionada.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionada.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionada.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidadSeleccionada.Size = New Size(160, 40)
        SpinEditCantidadSeleccionada.TabIndex = 26
        ' 
        ' LabelIndicadorPorPeso
        ' 
        LabelIndicadorPorPeso.BackColor = Color.White
        LabelIndicadorPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPeso.ForeColor = Color.Red
        LabelIndicadorPorPeso.Location = New Point(329, 183)
        LabelIndicadorPorPeso.Name = "LabelIndicadorPorPeso"
        LabelIndicadorPorPeso.Size = New Size(174, 25)
        LabelIndicadorPorPeso.TabIndex = 13
        LabelIndicadorPorPeso.Text = "Por Peso/Fracción"
        LabelIndicadorPorPeso.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPeso.Visible = False
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
        LabelNombreAlmacen.Appearance.Options.UseTextOptions = True
        LabelNombreAlmacen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        LabelNombreAlmacen.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        LabelNombreAlmacen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreAlmacen.Location = New Point(310, 28)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Padding = New Padding(6, 0, 6, 0)
        LabelNombreAlmacen.Size = New Size(254, 33)
        LabelNombreAlmacen.TabIndex = 7
        LabelNombreAlmacen.Text = " "
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
        LabelStockArticulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        LabelStockArticulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        LabelStockArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticulo.Location = New Point(400, 98)
        LabelStockArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticulo.Name = "LabelStockArticulo"
        LabelStockArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelStockArticulo.Size = New Size(164, 33)
        LabelStockArticulo.TabIndex = 8
        LabelStockArticulo.Text = " "
        ' 
        ' TextBoxCodigoUbicacion
        ' 
        TextBoxCodigoUbicacion.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoUbicacion.Location = New Point(143, 28)
        TextBoxCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoUbicacion.Name = "TextBoxCodigoUbicacion"
        TextBoxCodigoUbicacion.Size = New Size(160, 33)
        TextBoxCodigoUbicacion.TabIndex = 0
        ' 
        ' TextBoxCodigoArticulo
        ' 
        TextBoxCodigoArticulo.Enabled = False
        TextBoxCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoArticulo.Location = New Point(143, 98)
        TextBoxCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoArticulo.Name = "TextBoxCodigoArticulo"
        TextBoxCodigoArticulo.Size = New Size(160, 33)
        TextBoxCodigoArticulo.TabIndex = 1
        ' 
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.Appearance.Options.UseTextOptions = True
        LabelNombreUbicacion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        LabelNombreUbicacion.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        LabelNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(16, 65)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Padding = New Padding(6, 0, 6, 0)
        LabelNombreUbicacion.Size = New Size(548, 28)
        LabelNombreUbicacion.TabIndex = 4
        LabelNombreUbicacion.Text = " "
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
        LabelNombreArticulo.Appearance.Options.UseTextOptions = True
        LabelNombreArticulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        LabelNombreArticulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        LabelNombreArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(16, 136)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(548, 28)
        LabelNombreArticulo.TabIndex = 4
        LabelNombreArticulo.Text = " "
        ' 
        ' GridControlArticulosSeleccionados
        ' 
        GridControlArticulosSeleccionados.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlArticulosSeleccionados.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Font = New Font("Tahoma", 15.75F)
        GridControlArticulosSeleccionados.Location = New Point(13, 448)
        GridControlArticulosSeleccionados.MainView = GridViewArticulosSeleccionados
        GridControlArticulosSeleccionados.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Name = "GridControlArticulosSeleccionados"
        GridControlArticulosSeleccionados.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryCancelButton})
        GridControlArticulosSeleccionados.Size = New Size(577, 283)
        GridControlArticulosSeleccionados.TabIndex = 7
        GridControlArticulosSeleccionados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewArticulosSeleccionados})
        GridControlArticulosSeleccionados.Visible = False
        ' 
        ' GridViewArticulosSeleccionados
        ' 
        GridViewArticulosSeleccionados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnItemRef, ColumnItemName, ColumnLocation, ColumnAmmount, ColumnDelete})
        GridViewArticulosSeleccionados.DetailHeight = 262
        GridViewArticulosSeleccionados.GridControl = GridControlArticulosSeleccionados
        GridViewArticulosSeleccionados.Name = "GridViewArticulosSeleccionados"
        GridViewArticulosSeleccionados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewArticulosSeleccionados.OptionsBehavior.Editable = False
        GridViewArticulosSeleccionados.OptionsEditForm.PopupEditFormWidth = 700
        GridViewArticulosSeleccionados.OptionsView.ShowGroupPanel = False
        GridViewArticulosSeleccionados.OptionsView.ShowIndicator = False
        ' 
        ' ColumnItemRef
        ' 
        ColumnItemRef.Caption = "Referenia"
        ColumnItemRef.FieldName = "Articulo"
        ColumnItemRef.Name = "ColumnItemRef"
        ColumnItemRef.OptionsColumn.AllowEdit = False
        ColumnItemRef.Visible = True
        ColumnItemRef.VisibleIndex = 0
        ColumnItemRef.Width = 120
        ' 
        ' ColumnItemName
        ' 
        ColumnItemName.Caption = "Artículo"
        ColumnItemName.FieldName = "Descripcion"
        ColumnItemName.Name = "ColumnItemName"
        ColumnItemName.OptionsColumn.AllowEdit = False
        ColumnItemName.Visible = True
        ColumnItemName.VisibleIndex = 1
        ColumnItemName.Width = 387
        ' 
        ' ColumnLocation
        ' 
        ColumnLocation.Caption = "Ubicación"
        ColumnLocation.FieldName = "Ubicacion"
        ColumnLocation.Name = "ColumnLocation"
        ColumnLocation.OptionsColumn.AllowEdit = False
        ColumnLocation.Visible = True
        ColumnLocation.VisibleIndex = 2
        ColumnLocation.Width = 213
        ' 
        ' ColumnAmmount
        ' 
        ColumnAmmount.Caption = "Unidades"
        ColumnAmmount.FieldName = "Unidades"
        ColumnAmmount.Name = "ColumnAmmount"
        ColumnAmmount.OptionsColumn.AllowEdit = False
        ColumnAmmount.Visible = True
        ColumnAmmount.VisibleIndex = 3
        ColumnAmmount.Width = 69
        ' 
        ' ColumnDelete
        ' 
        ColumnDelete.ColumnEdit = RepositoryCancelButton
        ColumnDelete.Name = "ColumnDelete"
        ColumnDelete.OptionsColumn.AllowSize = False
        ColumnDelete.Visible = True
        ColumnDelete.VisibleIndex = 4
        ColumnDelete.Width = 120
        ' 
        ' RepositoryCancelButton
        ' 
        EditorButtonImageOptions2.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        EditorButtonImageOptions2.SvgImage = CType(resources.GetObject("EditorButtonImageOptions2.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        EditorButtonImageOptions2.SvgImageSize = New Size(16, 16)
        RepositoryCancelButton.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Eliminar", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        RepositoryCancelButton.Name = "RepositoryCancelButton"
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
        GroupControl1.Controls.Add(ButtonConfirmacionAccion)
        GroupControl1.Controls.Add(RadioButtonOpcionTraspasoAlamacen)
        GroupControl1.Controls.Add(RadioButtonOpcionAlbaran)
        GroupControl1.Location = New Point(13, 736)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.Size = New Size(577, 83)
        GroupControl1.TabIndex = 2
        GroupControl1.Text = "Destino"
        ' 
        ' ButtonConfirmacionAccion
        ' 
        ButtonConfirmacionAccion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionAccion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        ButtonConfirmacionAccion.ImageOptions.SvgImage = CType(resources.GetObject("ButtonConfirmacionAccion.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        ButtonConfirmacionAccion.ImageOptions.SvgImageSize = New Size(45, 45)
        ButtonConfirmacionAccion.Location = New Point(516, 26)
        ButtonConfirmacionAccion.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionAccion.Name = "ButtonConfirmacionAccion"
        ButtonConfirmacionAccion.Size = New Size(50, 50)
        ButtonConfirmacionAccion.TabIndex = 7
        ' 
        ' RadioButtonOpcionTraspasoAlamacen
        ' 
        RadioButtonOpcionTraspasoAlamacen.AutoSize = True
        RadioButtonOpcionTraspasoAlamacen.Font = New Font("Tahoma", 15.75F)
        RadioButtonOpcionTraspasoAlamacen.Location = New Point(229, 32)
        RadioButtonOpcionTraspasoAlamacen.Name = "RadioButtonOpcionTraspasoAlamacen"
        RadioButtonOpcionTraspasoAlamacen.Size = New Size(200, 29)
        RadioButtonOpcionTraspasoAlamacen.TabIndex = 1
        RadioButtonOpcionTraspasoAlamacen.TabStop = True
        RadioButtonOpcionTraspasoAlamacen.Text = "Traspaso Almacén"
        RadioButtonOpcionTraspasoAlamacen.UseVisualStyleBackColor = True
        ' 
        ' RadioButtonOpcionAlbaran
        ' 
        RadioButtonOpcionAlbaran.AutoSize = True
        RadioButtonOpcionAlbaran.Font = New Font("Tahoma", 15.75F)
        RadioButtonOpcionAlbaran.Location = New Point(52, 32)
        RadioButtonOpcionAlbaran.Name = "RadioButtonOpcionAlbaran"
        RadioButtonOpcionAlbaran.Size = New Size(102, 29)
        RadioButtonOpcionAlbaran.TabIndex = 0
        RadioButtonOpcionAlbaran.TabStop = True
        RadioButtonOpcionAlbaran.Text = "Albarán"
        RadioButtonOpcionAlbaran.UseVisualStyleBackColor = True
        ' 
        ' DatePicker
        ' 
        DatePicker.EditValue = Nothing
        DatePicker.Location = New Point(86, 54)
        DatePicker.Name = "DatePicker"
        DatePicker.Properties.Appearance.Font = New Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DatePicker.Properties.Appearance.Options.UseFont = True
        DatePicker.Properties.AppearanceCalendar.DayCell.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DatePicker.Properties.AppearanceCalendar.DayCell.Options.UseFont = True
        DatePicker.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DatePicker.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DatePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent
        DatePicker.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False
        DatePicker.Size = New Size(188, 40)
        DatePicker.TabIndex = 0
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelControl3.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl3.Appearance.Options.UseFont = True
        LabelControl3.Location = New Point(13, 63)
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
        GridPedidos.Font = New Font("Tahoma", 15.75F)
        GridPedidos.Location = New Point(13, 99)
        GridPedidos.MainView = GridView2
        GridPedidos.Margin = New Padding(3, 2, 3, 2)
        GridPedidos.Name = "GridPedidos"
        GridPedidos.Size = New Size(577, 115)
        GridPedidos.TabIndex = 12
        GridPedidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView2})
        ' 
        ' GridView2
        ' 
        GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnRef, ColumnItem, ColumnPlacement, ColumnUnits, ColumnStock, ColumnState})
        GridView2.DetailHeight = 262
        GridView2.GridControl = GridPedidos
        GridView2.Name = "GridView2"
        GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridView2.OptionsBehavior.Editable = False
        GridView2.OptionsEditForm.PopupEditFormWidth = 700
        GridView2.OptionsView.ShowGroupPanel = False
        GridView2.OptionsView.ShowIndicator = False
        ' 
        ' ColumnRef
        ' 
        ColumnRef.Caption = "Referencia"
        ColumnRef.FieldName = "Referencia"
        ColumnRef.Name = "ColumnRef"
        ColumnRef.OptionsColumn.AllowEdit = False
        ColumnRef.Visible = True
        ColumnRef.VisibleIndex = 0
        ' 
        ' ColumnItem
        ' 
        ColumnItem.Caption = "Artículo"
        ColumnItem.FieldName = "Descripcion"
        ColumnItem.Name = "ColumnItem"
        ColumnItem.OptionsColumn.AllowEdit = False
        ColumnItem.Visible = True
        ColumnItem.VisibleIndex = 1
        ' 
        ' ColumnPlacement
        ' 
        ColumnPlacement.Caption = "Ubicación"
        ColumnPlacement.Name = "ColumnPlacement"
        ColumnPlacement.OptionsColumn.AllowEdit = False
        ColumnPlacement.Visible = True
        ColumnPlacement.VisibleIndex = 2
        ' 
        ' ColumnUnits
        ' 
        ColumnUnits.Caption = "Unidades"
        ColumnUnits.FieldName = "Cantidad"
        ColumnUnits.Name = "ColumnUnits"
        ColumnUnits.OptionsColumn.AllowEdit = False
        ColumnUnits.Visible = True
        ColumnUnits.VisibleIndex = 3
        ' 
        ' ColumnStock
        ' 
        ColumnStock.Caption = "Existencias"
        ColumnStock.FieldName = "Existencias"
        ColumnStock.Name = "ColumnStock"
        ColumnStock.OptionsColumn.AllowEdit = False
        ColumnStock.Visible = True
        ColumnStock.VisibleIndex = 4
        ' 
        ' ColumnState
        ' 
        ColumnState.Caption = "Estado"
        ColumnState.FieldName = "ColumnState"
        ColumnState.Name = "ColumnState"
        ColumnState.OptionsColumn.AllowEdit = False
        ColumnState.ShowUnboundExpressionMenu = True
        ColumnState.UnboundDataType = GetType(String)
        ColumnState.UnboundExpression = "Iif([StockDisponible] >= [CantidadPedida], '✅ Disponible', '⚠️ Parcial')"
        ColumnState.Visible = True
        ColumnState.VisibleIndex = 5
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
        Controls.Add(DatePicker)
        Controls.Add(GroupControl1)
        Controls.Add(PanelTitulo)
        Controls.Add(GridControlArticulosSeleccionados)
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
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
        CType(RepositoryCancelButton, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        CType(GroupControl1, ComponentModel.ISupportInitialize).EndInit()
        GroupControl1.ResumeLayout(False)
        GroupControl1.PerformLayout()
        CType(DatePicker.Properties.CalendarTimeProperties, ComponentModel.ISupportInitialize).EndInit()
        CType(DatePicker.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridPedidos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TextBoxCodigoUbicacion As TextBox
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBoxCodigoArticulo As TextBox
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelStockArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlArticulosSeleccionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewArticulosSeleccionados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DatePicker As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ButtonConfirmacionAccion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioButtonOpcionTraspasoAlamacen As RadioButton
    Friend WithEvents RadioButtonOpcionAlbaran As RadioButton
    Friend WithEvents GridPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelIndicadorPorPeso As Label
    Friend WithEvents SpinEditCantidadSeleccionada As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblUbicacion As Label
    Friend WithEvents lblArticulo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonConfirmacionLectura As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ColumnRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnUnits As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnPlacement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItemRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnAmmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDelete As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryCancelButton As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ColumnState As DevExpress.XtraGrid.Columns.GridColumn
End Class
