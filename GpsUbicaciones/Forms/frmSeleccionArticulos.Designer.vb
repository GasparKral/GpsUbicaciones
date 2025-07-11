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
        TextEditItem = New DevExpress.XtraEditors.TextEdit()
        TextEditLocation = New DevExpress.XtraEditors.TextEdit()
        IconWeight = New DevExpress.XtraEditors.SvgImageBox()
        ButtonConfirmacionLectura = New DevExpress.XtraEditors.SimpleButton()
        Label2 = New Label()
        Label3 = New Label()
        lblArticulo = New Label()
        lblUbicacion = New Label()
        SpinEditCantidadSeleccionada = New DevExpress.XtraEditors.SpinEdit()
        LabelNombreAlmacen = New DevExpress.XtraEditors.LabelControl()
        LabelStockArticulo = New DevExpress.XtraEditors.LabelControl()
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
        XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditLocation.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(IconWeight, ComponentModel.ISupportInitialize).BeginInit()
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
        CType(XtraTabControl1, ComponentModel.ISupportInitialize).BeginInit()
        XtraTabControl1.SuspendLayout()
        XtraTabPage1.SuspendLayout()
        XtraTabPage2.SuspendLayout()
        XtraTabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.Location = New Point(439, 824)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 3
        btnSalir.Text = "Volver"
        ' 
        ' GroupControlUbicacion
        ' 
        GroupControlUbicacion.Appearance.BackColor = Color.Transparent
        GroupControlUbicacion.Appearance.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlUbicacion.AppearanceCaption.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseFont = True
        GroupControlUbicacion.Controls.Add(TextEditItem)
        GroupControlUbicacion.Controls.Add(TextEditLocation)
        GroupControlUbicacion.Controls.Add(IconWeight)
        GroupControlUbicacion.Controls.Add(ButtonConfirmacionLectura)
        GroupControlUbicacion.Controls.Add(Label2)
        GroupControlUbicacion.Controls.Add(Label3)
        GroupControlUbicacion.Controls.Add(lblArticulo)
        GroupControlUbicacion.Controls.Add(lblUbicacion)
        GroupControlUbicacion.Controls.Add(SpinEditCantidadSeleccionada)
        GroupControlUbicacion.Controls.Add(LabelNombreAlmacen)
        GroupControlUbicacion.Controls.Add(LabelStockArticulo)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreArticulo)
        GroupControlUbicacion.Dock = DockStyle.Fill
        GroupControlUbicacion.Location = New Point(0, 0)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Padding = New Padding(0, 0, 0, 10)
        GroupControlUbicacion.ShowCaption = False
        GroupControlUbicacion.Size = New Size(575, 317)
        GroupControlUbicacion.TabIndex = 1
        GroupControlUbicacion.Text = "Leer Artículos (Ubicacion / Articulo)"
        ' 
        ' TextEditItem
        ' 
        TextEditItem.Location = New Point(98, 77)
        TextEditItem.Name = "TextEditItem"
        TextEditItem.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        TextEditItem.Properties.Appearance.Options.UseFont = True
        TextEditItem.Properties.ValidateOnEnterKey = True
        TextEditItem.Size = New Size(205, 32)
        TextEditItem.TabIndex = 1
        ' 
        ' TextEditLocation
        ' 
        TextEditLocation.Location = New Point(112, 8)
        TextEditLocation.Name = "TextEditLocation"
        TextEditLocation.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        TextEditLocation.Properties.Appearance.Options.UseFont = True
        TextEditLocation.Properties.ValidateOnEnterKey = True
        TextEditLocation.Size = New Size(191, 32)
        TextEditLocation.TabIndex = 0
        ' 
        ' IconWeight
        ' 
        IconWeight.Location = New Point(346, 150)
        IconWeight.Name = "IconWeight"
        IconWeight.Size = New Size(40, 40)
        IconWeight.SvgImage = My.Resources.Resources.weightedpies
        IconWeight.TabIndex = 31
        IconWeight.Text = "SvgImageBox1"
        IconWeight.Visible = False
        ' 
        ' ButtonConfirmacionLectura
        ' 
        ButtonConfirmacionLectura.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionLectura.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        ButtonConfirmacionLectura.ImageOptions.SvgImage = My.Resources.Resources.actions_check
        ButtonConfirmacionLectura.ImageOptions.SvgImageSize = New Size(45, 45)
        ButtonConfirmacionLectura.Location = New Point(494, 239)
        ButtonConfirmacionLectura.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionLectura.Name = "ButtonConfirmacionLectura"
        ButtonConfirmacionLectura.Size = New Size(75, 75)
        ButtonConfirmacionLectura.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        Label2.Location = New Point(16, 162)
        Label2.Margin = New Padding(3, 0, 0, 6)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 19)
        Label2.TabIndex = 30
        Label2.Text = "Cantidad:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        Label3.Location = New Point(309, 87)
        Label3.Margin = New Padding(3, 0, 0, 6)
        Label3.Name = "Label3"
        Label3.Size = New Size(106, 19)
        Label3.TabIndex = 29
        Label3.Text = "Existencias:"
        ' 
        ' lblArticulo
        ' 
        lblArticulo.AutoSize = True
        lblArticulo.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        lblArticulo.Location = New Point(16, 86)
        lblArticulo.Margin = New Padding(3, 0, 0, 6)
        lblArticulo.Name = "lblArticulo"
        lblArticulo.Size = New Size(79, 19)
        lblArticulo.TabIndex = 28
        lblArticulo.Text = "Artículo:"
        ' 
        ' lblUbicacion
        ' 
        lblUbicacion.AutoSize = True
        lblUbicacion.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        lblUbicacion.Location = New Point(16, 16)
        lblUbicacion.Margin = New Padding(3, 0, 0, 6)
        lblUbicacion.Name = "lblUbicacion"
        lblUbicacion.Size = New Size(93, 19)
        lblUbicacion.TabIndex = 27
        lblUbicacion.Text = "Ubicación:"
        ' 
        ' SpinEditCantidadSeleccionada
        ' 
        SpinEditCantidadSeleccionada.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionada.Enabled = False
        SpinEditCantidadSeleccionada.Location = New Point(112, 150)
        SpinEditCantidadSeleccionada.Name = "SpinEditCantidadSeleccionada"
        SpinEditCantidadSeleccionada.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        SpinEditCantidadSeleccionada.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionada.Properties.AutoHeight = False
        SpinEditCantidadSeleccionada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 35, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        SpinEditCantidadSeleccionada.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionada.Properties.LookAndFeel.SkinName = "WXI"
        SpinEditCantidadSeleccionada.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        SpinEditCantidadSeleccionada.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionada.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidadSeleccionada.Properties.ValidateOnEnterKey = True
        SpinEditCantidadSeleccionada.Size = New Size(228, 40)
        SpinEditCantidadSeleccionada.TabIndex = 2
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
        LabelNombreAlmacen.Location = New Point(310, 7)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Padding = New Padding(6, 0, 6, 0)
        LabelNombreAlmacen.Size = New Size(252, 33)
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
        LabelStockArticulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelStockArticulo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        LabelStockArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticulo.Location = New Point(419, 77)
        LabelStockArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticulo.Name = "LabelStockArticulo"
        LabelStockArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelStockArticulo.Size = New Size(143, 33)
        LabelStockArticulo.TabIndex = 8
        LabelStockArticulo.Text = " "
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
        LabelNombreUbicacion.Location = New Point(16, 44)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Padding = New Padding(6, 0, 6, 0)
        LabelNombreUbicacion.Size = New Size(546, 28)
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
        LabelNombreArticulo.Location = New Point(16, 115)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(546, 28)
        LabelNombreArticulo.TabIndex = 4
        LabelNombreArticulo.Text = " "
        ' 
        ' GridControlArticulosSeleccionados
        ' 
        GridControlArticulosSeleccionados.Dock = DockStyle.Fill
        GridControlArticulosSeleccionados.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Font = New Font("Tahoma", 15.75F)
        GridControlArticulosSeleccionados.Location = New Point(0, 0)
        GridControlArticulosSeleccionados.LookAndFeel.SkinName = "WXI"
        GridControlArticulosSeleccionados.LookAndFeel.UseDefaultLookAndFeel = False
        GridControlArticulosSeleccionados.MainView = GridViewArticulosSeleccionados
        GridControlArticulosSeleccionados.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Name = "GridControlArticulosSeleccionados"
        GridControlArticulosSeleccionados.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {RepositoryCancelButton})
        GridControlArticulosSeleccionados.Size = New Size(575, 317)
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
        GridViewArticulosSeleccionados.OptionsCustomization.AllowFilter = False
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
        EditorButtonImageOptions2.SvgImageSize = New Size(16, 16)
        RepositoryCancelButton.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "Eliminar", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        RepositoryCancelButton.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        RepositoryCancelButton.LookAndFeel.SkinName = "WXI"
        RepositoryCancelButton.LookAndFeel.UseDefaultLookAndFeel = False
        RepositoryCancelButton.Name = "RepositoryCancelButton"
        ' 
        ' PanelTitulo
        ' 
        PanelTitulo.BackColor = Color.RoyalBlue
        PanelTitulo.Controls.Add(Label1)
        PanelTitulo.Dock = DockStyle.Top
        PanelTitulo.Location = New Point(0, 0)
        PanelTitulo.Name = "PanelTitulo"
        PanelTitulo.Size = New Size(600, 48)
        PanelTitulo.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(296, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(281, 31)
        Label1.TabIndex = 1
        Label1.Text = "Selección de Artículos"
        ' 
        ' GroupControl1
        ' 
        GroupControl1.Controls.Add(ButtonConfirmacionAccion)
        GroupControl1.Controls.Add(RadioButtonOpcionTraspasoAlamacen)
        GroupControl1.Controls.Add(RadioButtonOpcionAlbaran)
        GroupControl1.Dock = DockStyle.Fill
        GroupControl1.Location = New Point(0, 0)
        GroupControl1.Name = "GroupControl1"
        GroupControl1.ShowCaption = False
        GroupControl1.Size = New Size(575, 317)
        GroupControl1.TabIndex = 2
        GroupControl1.Text = "Destino"
        ' 
        ' ButtonConfirmacionAccion
        ' 
        ButtonConfirmacionAccion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionAccion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        ButtonConfirmacionAccion.ImageOptions.SvgImage = My.Resources.Resources.actions_check
        ButtonConfirmacionAccion.ImageOptions.SvgImageSize = New Size(45, 45)
        ButtonConfirmacionAccion.Location = New Point(488, 237)
        ButtonConfirmacionAccion.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionAccion.Name = "ButtonConfirmacionAccion"
        ButtonConfirmacionAccion.Size = New Size(75, 75)
        ButtonConfirmacionAccion.TabIndex = 2
        ' 
        ' RadioButtonOpcionTraspasoAlamacen
        ' 
        RadioButtonOpcionTraspasoAlamacen.AutoSize = True
        RadioButtonOpcionTraspasoAlamacen.Font = New Font("Tahoma", 15.75F)
        RadioButtonOpcionTraspasoAlamacen.Location = New Point(233, 256)
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
        RadioButtonOpcionAlbaran.Location = New Point(56, 256)
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
        DatePicker.Location = New Point(88, 54)
        DatePicker.Name = "DatePicker"
        DatePicker.Properties.Appearance.Font = New Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DatePicker.Properties.Appearance.Options.UseFont = True
        DatePicker.Properties.AppearanceCalendar.DayCell.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DatePicker.Properties.AppearanceCalendar.DayCell.Options.UseFont = True
        DatePicker.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DatePicker.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        DatePicker.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent
        DatePicker.Properties.LookAndFeel.UseDefaultLookAndFeel = False
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
        GridPedidos.LookAndFeel.SkinName = "WXI"
        GridPedidos.LookAndFeel.UseDefaultLookAndFeel = False
        GridPedidos.MainView = GridView2
        GridPedidos.Margin = New Padding(3, 2, 3, 2)
        GridPedidos.Name = "GridPedidos"
        GridPedidos.Size = New Size(577, 363)
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
        GridView2.OptionsCustomization.AllowFilter = False
        GridView2.OptionsCustomization.AllowSort = False
        GridView2.OptionsEditForm.PopupEditFormWidth = 700
        GridView2.OptionsMenu.EnableColumnMenu = False
        GridView2.OptionsMenu.EnableFooterMenu = False
        GridView2.OptionsMenu.EnableGroupPanelMenu = False
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
        ColumnRef.Width = 68
        ' 
        ' ColumnItem
        ' 
        ColumnItem.Caption = "Artículo"
        ColumnItem.FieldName = "Descripcion"
        ColumnItem.Name = "ColumnItem"
        ColumnItem.OptionsColumn.AllowEdit = False
        ColumnItem.Visible = True
        ColumnItem.VisibleIndex = 1
        ColumnItem.Width = 172
        ' 
        ' ColumnPlacement
        ' 
        ColumnPlacement.Caption = "Ubicación"
        ColumnPlacement.FieldName = "Ubicacion"
        ColumnPlacement.Name = "ColumnPlacement"
        ColumnPlacement.OptionsColumn.AllowEdit = False
        ColumnPlacement.Visible = True
        ColumnPlacement.VisibleIndex = 3
        ColumnPlacement.Width = 131
        ' 
        ' ColumnUnits
        ' 
        ColumnUnits.Caption = "Unidades"
        ColumnUnits.FieldName = "Cantidad"
        ColumnUnits.Name = "ColumnUnits"
        ColumnUnits.OptionsColumn.AllowEdit = False
        ColumnUnits.Visible = True
        ColumnUnits.VisibleIndex = 2
        ColumnUnits.Width = 63
        ' 
        ' ColumnStock
        ' 
        ColumnStock.Caption = "Existencias"
        ColumnStock.FieldName = "Existencias"
        ColumnStock.Name = "ColumnStock"
        ColumnStock.OptionsColumn.AllowEdit = False
        ColumnStock.Visible = True
        ColumnStock.VisibleIndex = 4
        ColumnStock.Width = 67
        ' 
        ' ColumnState
        ' 
        ColumnState.Caption = "Estado"
        ColumnState.FieldName = "ColumnState"
        ColumnState.Name = "ColumnState"
        ColumnState.OptionsColumn.AllowEdit = False
        ColumnState.ShowUnboundExpressionMenu = True
        ColumnState.UnboundDataType = GetType(String)
        ColumnState.UnboundExpression = "Iif([Existencias] Is Null, '🚫 Sin Stock', [Existencias] >= [Cantidad], '✅ Disponible', [Existencias] > 0, '⚠️ Parcial', '❌ Sin Existencias')"
        ColumnState.Visible = True
        ColumnState.VisibleIndex = 5
        ColumnState.Width = 74
        ' 
        ' XtraTabControl1
        ' 
        XtraTabControl1.Location = New Point(13, 467)
        XtraTabControl1.LookAndFeel.SkinName = "WXI"
        XtraTabControl1.LookAndFeel.UseDefaultLookAndFeel = False
        XtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.True
        XtraTabControl1.Name = "XtraTabControl1"
        XtraTabControl1.SelectedTabPage = XtraTabPage1
        XtraTabControl1.Size = New Size(577, 352)
        XtraTabControl1.TabIndex = 1
        XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {XtraTabPage1, XtraTabPage2, XtraTabPage3})
        ' 
        ' XtraTabPage1
        ' 
        XtraTabPage1.Appearance.Header.Font = New Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        XtraTabPage1.Appearance.Header.Options.UseFont = True
        XtraTabPage1.Controls.Add(GroupControlUbicacion)
        XtraTabPage1.Name = "XtraTabPage1"
        XtraTabPage1.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False
        XtraTabPage1.Size = New Size(575, 317)
        XtraTabPage1.Text = "Lectura"
        ' 
        ' XtraTabPage2
        ' 
        XtraTabPage2.Appearance.Header.Font = New Font("Tahoma", 14.25F, FontStyle.Bold)
        XtraTabPage2.Appearance.Header.Options.UseFont = True
        XtraTabPage2.Controls.Add(GridControlArticulosSeleccionados)
        XtraTabPage2.Name = "XtraTabPage2"
        XtraTabPage2.Size = New Size(575, 317)
        XtraTabPage2.Text = "Visualización"
        ' 
        ' XtraTabPage3
        ' 
        XtraTabPage3.Appearance.Header.Font = New Font("Tahoma", 14.25F, FontStyle.Bold)
        XtraTabPage3.Appearance.Header.Options.UseFont = True
        XtraTabPage3.Controls.Add(GroupControl1)
        XtraTabPage3.Name = "XtraTabPage3"
        XtraTabPage3.Size = New Size(575, 317)
        XtraTabPage3.Text = "Destino"
        ' 
        ' frmSeleccionArticulos
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SkyBlue
        ClientSize = New Size(600, 900)
        ControlBox = False
        Controls.Add(XtraTabControl1)
        Controls.Add(GridPedidos)
        Controls.Add(LabelControl3)
        Controls.Add(DatePicker)
        Controls.Add(PanelTitulo)
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
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditLocation.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(IconWeight, ComponentModel.ISupportInitialize).EndInit()
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
        CType(XtraTabControl1, ComponentModel.ISupportInitialize).EndInit()
        XtraTabControl1.ResumeLayout(False)
        XtraTabPage1.ResumeLayout(False)
        XtraTabPage2.ResumeLayout(False)
        XtraTabPage3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelStockArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlArticulosSeleccionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewArticulosSeleccionados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DatePicker As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ButtonConfirmacionAccion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioButtonOpcionTraspasoAlamacen As RadioButton
    Friend WithEvents RadioButtonOpcionAlbaran As RadioButton
    Friend WithEvents GridPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents IconWeight As DevExpress.XtraEditors.SvgImageBox
    Friend WithEvents TextEditLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditItem As DevExpress.XtraEditors.TextEdit
End Class
