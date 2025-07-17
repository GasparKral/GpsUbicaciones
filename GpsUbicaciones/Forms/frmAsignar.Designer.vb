Imports DevExpress.Mvvm.Native
Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAsignar
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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim TableColumnDefinition1 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New TableLayout.TableColumnDefinition()
        Dim TableColumnDefinition2 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New TableLayout.TableColumnDefinition()
        Dim TableColumnDefinition3 As DevExpress.XtraEditors.TableLayout.TableColumnDefinition = New TableLayout.TableColumnDefinition()
        Dim TableRowDefinition1 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New TableLayout.TableRowDefinition()
        Dim TableRowDefinition2 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New TableLayout.TableRowDefinition()
        Dim TableRowDefinition3 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New TableLayout.TableRowDefinition()
        Dim TableRowDefinition4 As DevExpress.XtraEditors.TableLayout.TableRowDefinition = New TableLayout.TableRowDefinition()
        Dim TableSpan1 As DevExpress.XtraEditors.TableLayout.TableSpan = New TableLayout.TableSpan()
        Dim TableSpan2 As DevExpress.XtraEditors.TableLayout.TableSpan = New TableLayout.TableSpan()
        Dim TableSpan3 As DevExpress.XtraEditors.TableLayout.TableSpan = New TableLayout.TableSpan()
        Dim TableSpan4 As DevExpress.XtraEditors.TableLayout.TableSpan = New TableLayout.TableSpan()
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement5 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement7 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement8 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement9 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement10 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        ColumnLocation = New DevExpress.XtraGrid.Columns.TileViewColumn()
        ColumnReference = New DevExpress.XtraGrid.Columns.TileViewColumn()
        ColumnItem = New DevExpress.XtraGrid.Columns.TileViewColumn()
        ColumnLocal = New DevExpress.XtraGrid.Columns.TileViewColumn()
        ColumnStock = New DevExpress.XtraGrid.Columns.TileViewColumn()
        RepositoryItemPictureEdit1 = New Repository.RepositoryItemPictureEdit()
        ColumnTotalStock = New DevExpress.XtraGrid.Columns.TileViewColumn()
        btnSalir = New SimpleButton()
        ButtonConsultarUbicacion = New SimpleButton()
        LabelNombreUbicacion = New LabelControl()
        GroupControlArticulos = New GroupControl()
        TextEditLocation = New TextEdit()
        TextEditItem = New TextEdit()
        IconWeigth = New SvgImageBox()
        Label9 = New Label()
        Label8 = New Label()
        LabelTotalStock = New LabelControl()
        Label7 = New Label()
        LabelLocalStock = New LabelControl()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        SpinEditCantidad = New SpinEdit()
        ButtonResetForm = New SimpleButton()
        ButtonConfirmacionArticulo = New SimpleButton()
        LabelNombreArticulo = New LabelControl()
        GridControlAsignacionArticulos = New DevExpress.XtraGrid.GridControl()
        TileView1 = New DevExpress.XtraGrid.Views.Tile.TileView()
        PanelTitulo = New Panel()
        LabelControl2 = New LabelControl()
        Label1 = New Label()
        CType(RepositoryItemPictureEdit1, ComponentModel.ISupportInitialize).BeginInit()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(TextEditLocation.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(IconWeigth, ComponentModel.ISupportInitialize).BeginInit()
        CType(SpinEditCantidad.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlAsignacionArticulos, ComponentModel.ISupportInitialize).BeginInit()
        CType(TileView1, ComponentModel.ISupportInitialize).BeginInit()
        PanelTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' ColumnLocation
        ' 
        ColumnLocation.Caption = "Ubicación"
        ColumnLocation.FieldName = "Location"
        ColumnLocation.Name = "ColumnLocation"
        ColumnLocation.OptionsColumn.AllowEdit = False
        ColumnLocation.Visible = True
        ColumnLocation.VisibleIndex = 1
        ColumnLocation.Width = 182
        ' 
        ' ColumnReference
        ' 
        ColumnReference.Caption = "Ref"
        ColumnReference.FieldName = "Ref"
        ColumnReference.Name = "ColumnReference"
        ColumnReference.Visible = True
        ColumnReference.VisibleIndex = 4
        ' 
        ' ColumnItem
        ' 
        ColumnItem.Caption = "Artículo"
        ColumnItem.FieldName = "ItemName"
        ColumnItem.Name = "ColumnItem"
        ColumnItem.OptionsColumn.AllowEdit = False
        ColumnItem.Visible = True
        ColumnItem.VisibleIndex = 0
        ColumnItem.Width = 535
        ' 
        ' ColumnLocal
        ' 
        ColumnLocal.Caption = "Local"
        ColumnLocal.FieldName = "LocalStock"
        ColumnLocal.Name = "ColumnLocal"
        ColumnLocal.Visible = True
        ColumnLocal.VisibleIndex = 5
        ' 
        ' ColumnStock
        ' 
        ColumnStock.Caption = "Asignadas"
        ColumnStock.FieldName = "Asign"
        ColumnStock.Name = "ColumnStock"
        ColumnStock.OptionsColumn.AllowEdit = False
        ColumnStock.Visible = True
        ColumnStock.VisibleIndex = 3
        ColumnStock.Width = 87
        ' 
        ' RepositoryItemPictureEdit1
        ' 
        RepositoryItemPictureEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        RepositoryItemPictureEdit1.LookAndFeel.SkinName = "WXI"
        RepositoryItemPictureEdit1.LookAndFeel.UseDefaultLookAndFeel = False
        RepositoryItemPictureEdit1.Name = "RepositoryItemPictureEdit1"
        RepositoryItemPictureEdit1.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False
        RepositoryItemPictureEdit1.ShowMenu = False
        RepositoryItemPictureEdit1.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False
        RepositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        ' 
        ' ColumnTotalStock
        ' 
        ColumnTotalStock.Caption = "Existencias Totales"
        ColumnTotalStock.FieldName = "TotalStock"
        ColumnTotalStock.Name = "ColumnTotalStock"
        ColumnTotalStock.OptionsColumn.AllowEdit = False
        ColumnTotalStock.Visible = True
        ColumnTotalStock.VisibleIndex = 2
        ColumnTotalStock.Width = 105
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.Location = ImageLocation.MiddleLeft
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(461, 874)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 2
        btnSalir.TabStop = False
        btnSalir.Text = "Volver"
        ' 
        ' ButtonConsultarUbicacion
        ' 
        ButtonConsultarUbicacion.Enabled = False
        ButtonConsultarUbicacion.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConsultarUbicacion.ImageOptions.SvgImage = My.Resources.Resources.about
        ButtonConsultarUbicacion.ImageOptions.SvgImageSize = New Size(50, 50)
        ButtonConsultarUbicacion.Location = New Point(534, 204)
        ButtonConsultarUbicacion.Name = "ButtonConsultarUbicacion"
        ButtonConsultarUbicacion.Size = New Size(50, 50)
        ButtonConsultarUbicacion.TabIndex = 4
        ' 
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.AutoSizeMode = LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(13, 68)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Padding = New Padding(6, 0, 6, 0)
        LabelNombreUbicacion.Size = New Size(569, 33)
        LabelNombreUbicacion.TabIndex = 4
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(TextEditLocation)
        GroupControlArticulos.Controls.Add(TextEditItem)
        GroupControlArticulos.Controls.Add(IconWeigth)
        GroupControlArticulos.Controls.Add(Label9)
        GroupControlArticulos.Controls.Add(Label8)
        GroupControlArticulos.Controls.Add(LabelTotalStock)
        GroupControlArticulos.Controls.Add(Label7)
        GroupControlArticulos.Controls.Add(LabelLocalStock)
        GroupControlArticulos.Controls.Add(Label6)
        GroupControlArticulos.Controls.Add(Label5)
        GroupControlArticulos.Controls.Add(Label4)
        GroupControlArticulos.Controls.Add(Label3)
        GroupControlArticulos.Controls.Add(ButtonConsultarUbicacion)
        GroupControlArticulos.Controls.Add(SpinEditCantidad)
        GroupControlArticulos.Controls.Add(LabelNombreUbicacion)
        GroupControlArticulos.Controls.Add(ButtonResetForm)
        GroupControlArticulos.Controls.Add(ButtonConfirmacionArticulo)
        GroupControlArticulos.Controls.Add(LabelNombreArticulo)
        GroupControlArticulos.Location = New Point(9, 54)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(603, 345)
        GroupControlArticulos.TabIndex = 0
        GroupControlArticulos.Text = "Leer Ubicación / Artículo"
        ' 
        ' TextEditLocation
        ' 
        TextEditLocation.Location = New Point(109, 30)
        TextEditLocation.Name = "TextEditLocation"
        TextEditLocation.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        TextEditLocation.Properties.Appearance.Options.UseFont = True
        TextEditLocation.Properties.ValidateOnEnterKey = True
        TextEditLocation.Size = New Size(172, 32)
        TextEditLocation.TabIndex = 0
        ' 
        ' TextEditItem
        ' 
        TextEditItem.Location = New Point(109, 107)
        TextEditItem.Name = "TextEditItem"
        TextEditItem.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        TextEditItem.Properties.Appearance.Options.UseFont = True
        TextEditItem.Properties.ValidateOnEnterKey = True
        TextEditItem.Size = New Size(172, 32)
        TextEditItem.TabIndex = 1
        ' 
        ' IconWeigth
        ' 
        IconWeigth.Location = New Point(304, 267)
        IconWeigth.Name = "IconWeigth"
        IconWeigth.Size = New Size(80, 68)
        IconWeigth.SvgImage = My.Resources.Resources.weightedpies
        IconWeigth.TabIndex = 41
        IconWeigth.Text = "SvgImageBox1"
        IconWeigth.Visible = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(17, 291)
        Label9.Name = "Label9"
        Label9.Size = New Size(88, 19)
        Label9.TabIndex = 40
        Label9.Text = "Cantidad:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold Or FontStyle.Underline)
        Label8.Location = New Point(12, 247)
        Label8.Margin = New Padding(3, 8, 3, 8)
        Label8.Name = "Label8"
        Label8.Size = New Size(128, 25)
        Label8.TabIndex = 39
        Label8.Text = "Asignación"
        ' 
        ' LabelTotalStock
        ' 
        LabelTotalStock.Appearance.BackColor = Color.WhiteSmoke
        LabelTotalStock.Appearance.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold)
        LabelTotalStock.Appearance.Options.UseBackColor = True
        LabelTotalStock.Appearance.Options.UseFont = True
        LabelTotalStock.Appearance.Options.UseTextOptions = True
        LabelTotalStock.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelTotalStock.AutoSizeMode = LabelAutoSizeMode.None
        LabelTotalStock.Cursor = Cursors.Hand
        LabelTotalStock.Location = New Point(325, 217)
        LabelTotalStock.Name = "LabelTotalStock"
        LabelTotalStock.Size = New Size(94, 19)
        LabelTotalStock.TabIndex = 38
        LabelTotalStock.Text = "0"
        LabelTotalStock.ToolTip = "Haz Click para asignar como cantidad"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold)
        Label7.Location = New Point(261, 217)
        Label7.Name = "Label7"
        Label7.Size = New Size(62, 24)
        Label7.TabIndex = 37
        Label7.Text = "Total:"
        ' 
        ' LabelLocalStock
        ' 
        LabelLocalStock.Appearance.BackColor = Color.WhiteSmoke
        LabelLocalStock.Appearance.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelLocalStock.Appearance.Options.UseBackColor = True
        LabelLocalStock.Appearance.Options.UseFont = True
        LabelLocalStock.Appearance.Options.UseTextOptions = True
        LabelLocalStock.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelLocalStock.AutoSizeMode = LabelAutoSizeMode.None
        LabelLocalStock.Location = New Point(75, 217)
        LabelLocalStock.Name = "LabelLocalStock"
        LabelLocalStock.Size = New Size(94, 19)
        LabelLocalStock.TabIndex = 36
        LabelLocalStock.Text = "0"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(12, 217)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 20)
        Label6.TabIndex = 35
        Label6.Text = "Local:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(10, 184)
        Label5.Margin = New Padding(3, 8, 3, 8)
        Label5.Name = "Label5"
        Label5.Size = New Size(133, 25)
        Label5.TabIndex = 34
        Label5.Text = "Existencias"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(13, 114)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 20)
        Label4.TabIndex = 33
        Label4.Text = "Artículo:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(10, 37)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 20)
        Label3.TabIndex = 32
        Label3.Text = "Ubicación:"
        ' 
        ' SpinEditCantidad
        ' 
        SpinEditCantidad.CausesValidation = False
        SpinEditCantidad.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidad.Enabled = False
        SpinEditCantidad.Location = New Point(112, 283)
        SpinEditCantidad.Margin = New Padding(4, 3, 4, 3)
        SpinEditCantidad.Name = "SpinEditCantidad"
        SpinEditCantidad.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True
        SpinEditCantidad.Properties.Appearance.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SpinEditCantidad.Properties.Appearance.Options.UseFont = True
        SpinEditCantidad.Properties.AutoHeight = False
        EditorButtonImageOptions1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False
        EditorButtonImageOptions1.SvgImageSize = New Size(35, 35)
        SerializableAppearanceObject1.Font = New Font("Tahoma", 72F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SerializableAppearanceObject1.Options.UseFont = True
        SpinEditCantidad.Properties.Buttons.AddRange(New Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 40, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        SpinEditCantidad.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        SpinEditCantidad.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True
        SpinEditCantidad.Properties.ContextImageOptions.SvgImageSize = New Size(40, 40)
        SpinEditCantidad.Properties.HideSelection = False
        SpinEditCantidad.Properties.IsFloatValue = False
        SpinEditCantidad.Properties.LookAndFeel.SkinName = "WXI"
        SpinEditCantidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        SpinEditCantidad.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidad.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidad.Size = New Size(185, 38)
        SpinEditCantidad.TabIndex = 2
        ' 
        ' ButtonResetForm
        ' 
        ButtonResetForm.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonResetForm.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonResetForm.Appearance.Options.UseFont = True
        ButtonResetForm.CausesValidation = False
        ButtonResetForm.ImageOptions.Location = ImageLocation.MiddleLeft
        ButtonResetForm.ImageOptions.SvgImage = My.Resources.Resources.resetview
        ButtonResetForm.ImageOptions.SvgImageSize = New Size(70, 70)
        ButtonResetForm.Location = New Point(426, 260)
        ButtonResetForm.Margin = New Padding(4, 3, 4, 3)
        ButtonResetForm.Name = "ButtonResetForm"
        ButtonResetForm.Size = New Size(75, 75)
        ButtonResetForm.TabIndex = 4
        ' 
        ' ButtonConfirmacionArticulo
        ' 
        ButtonConfirmacionArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionArticulo.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConfirmacionArticulo.ImageOptions.SvgImage = My.Resources.Resources.actions_check
        ButtonConfirmacionArticulo.ImageOptions.SvgImageSize = New Size(50, 50)
        ButtonConfirmacionArticulo.Location = New Point(509, 260)
        ButtonConfirmacionArticulo.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionArticulo.Name = "ButtonConfirmacionArticulo"
        ButtonConfirmacionArticulo.Size = New Size(75, 75)
        ButtonConfirmacionArticulo.TabIndex = 3
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
        LabelNombreArticulo.AutoSizeMode = LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(12, 145)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(572, 33)
        LabelNombreArticulo.TabIndex = 4
        ' 
        ' GridControlAsignacionArticulos
        ' 
        GridControlAsignacionArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlAsignacionArticulos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Font = New Font("Tahoma", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridControlAsignacionArticulos.Location = New Point(10, 404)
        GridControlAsignacionArticulos.MainView = TileView1
        GridControlAsignacionArticulos.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Name = "GridControlAsignacionArticulos"
        GridControlAsignacionArticulos.RepositoryItems.AddRange(New Repository.RepositoryItem() {RepositoryItemPictureEdit1})
        GridControlAsignacionArticulos.Size = New Size(602, 466)
        GridControlAsignacionArticulos.TabIndex = 1
        GridControlAsignacionArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {TileView1})
        GridControlAsignacionArticulos.Visible = False
        ' 
        ' TileView1
        ' 
        TileView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnItem, ColumnLocation, ColumnTotalStock, ColumnStock, ColumnReference, ColumnLocal})
        TileView1.DetailHeight = 262
        TileView1.GridControl = GridControlAsignacionArticulos
        TileView1.Name = "TileView1"
        TileView1.OptionsEditForm.PopupEditFormWidth = 700
        TileView1.OptionsTiles.GroupTextPadding = New Padding(12, 8, 12, 8)
        TileView1.OptionsTiles.IndentBetweenGroups = 0
        TileView1.OptionsTiles.IndentBetweenItems = 0
        TileView1.OptionsTiles.ItemSize = New Size(524, 100)
        TileView1.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List
        TileView1.OptionsTiles.Orientation = Orientation.Vertical
        TileView1.OptionsTiles.Padding = New Padding(0)
        TileView1.OptionsTiles.RowCount = 0
        TileView1.TileColumns.Add(TableColumnDefinition1)
        TileView1.TileColumns.Add(TableColumnDefinition2)
        TileView1.TileColumns.Add(TableColumnDefinition3)
        TableRowDefinition1.Length.Value = 21R
        TableRowDefinition2.Length.Value = 21R
        TableRowDefinition3.Length.Value = 21R
        TableRowDefinition4.Length.Value = 21R
        TileView1.TileRows.Add(TableRowDefinition1)
        TileView1.TileRows.Add(TableRowDefinition2)
        TileView1.TileRows.Add(TableRowDefinition3)
        TileView1.TileRows.Add(TableRowDefinition4)
        TableSpan1.ColumnSpan = 3
        TableSpan2.ColumnSpan = 3
        TableSpan2.RowIndex = 3
        TableSpan3.ColumnSpan = 3
        TableSpan3.RowIndex = 1
        TableSpan4.ColumnSpan = 3
        TableSpan4.RowIndex = 2
        TileView1.TileSpans.Add(TableSpan1)
        TileView1.TileSpans.Add(TableSpan2)
        TileView1.TileSpans.Add(TableSpan3)
        TileView1.TileSpans.Add(TableSpan4)
        TileViewItemElement1.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement1.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement1.RowIndex = 1
        TileViewItemElement1.Text = "Referencia:"
        TileViewItemElement1.TextAlignment = TileItemContentAlignment.MiddleLeft
        TileViewItemElement2.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TileViewItemElement2.Appearance.Normal.Options.UseFont = True
        TileViewItemElement2.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement2.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement2.Text = "Ubicación:"
        TileViewItemElement2.TextAlignment = TileItemContentAlignment.MiddleLeft
        TileViewItemElement3.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        TileViewItemElement3.Appearance.Normal.Options.UseFont = True
        TileViewItemElement3.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement3.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement3.RowIndex = 2
        TileViewItemElement3.Text = "Local:"
        TileViewItemElement3.TextAlignment = TileItemContentAlignment.MiddleLeft
        TileViewItemElement4.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        TileViewItemElement4.Appearance.Normal.Options.UseFont = True
        TileViewItemElement4.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement4.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement4.RowIndex = 3
        TileViewItemElement4.Text = "Asignadas:"
        TileViewItemElement4.TextAlignment = TileItemContentAlignment.MiddleLeft
        TileViewItemElement5.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement5.AnchorElementIndex = 1
        TileViewItemElement5.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TileViewItemElement5.Appearance.Normal.Options.UseFont = True
        TileViewItemElement5.Column = ColumnLocation
        TileViewItemElement5.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement5.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement5.Text = "ColumnLocation"
        TileViewItemElement5.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement6.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement6.AnchorElementIndex = 0
        TileViewItemElement6.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F)
        TileViewItemElement6.Appearance.Normal.Options.UseFont = True
        TileViewItemElement6.Column = ColumnReference
        TileViewItemElement6.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement6.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement6.Text = "ColumnReference"
        TileViewItemElement6.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement7.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement7.AnchorElementIndex = 5
        TileViewItemElement7.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F)
        TileViewItemElement7.Appearance.Normal.Options.UseFont = True
        TileViewItemElement7.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement7.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement7.Text = "|"
        TileViewItemElement7.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement8.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement8.AnchorElementIndex = 6
        TileViewItemElement8.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F)
        TileViewItemElement8.Appearance.Normal.Options.UseFont = True
        TileViewItemElement8.Column = ColumnItem
        TileViewItemElement8.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement8.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement8.Text = "ColumnItem"
        TileViewItemElement8.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement9.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement9.AnchorElementIndex = 2
        TileViewItemElement9.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F)
        TileViewItemElement9.Appearance.Normal.Options.UseFont = True
        TileViewItemElement9.Column = ColumnLocal
        TileViewItemElement9.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement9.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement9.Text = "ColumnLocal"
        TileViewItemElement9.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement10.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Right
        TileViewItemElement10.AnchorElementIndex = 3
        TileViewItemElement10.Appearance.Normal.Font = New Font("Microsoft Sans Serif", 12F)
        TileViewItemElement10.Appearance.Normal.Options.UseFont = True
        TileViewItemElement10.Column = ColumnStock
        TileViewItemElement10.ImageOptions.ImageAlignment = TileItemContentAlignment.MiddleCenter
        TileViewItemElement10.ImageOptions.ImageScaleMode = TileItemImageScaleMode.Squeeze
        TileViewItemElement10.Text = "ColumnStock"
        TileViewItemElement10.TextAlignment = TileItemContentAlignment.MiddleCenter
        TileView1.TileTemplate.Add(TileViewItemElement1)
        TileView1.TileTemplate.Add(TileViewItemElement2)
        TileView1.TileTemplate.Add(TileViewItemElement3)
        TileView1.TileTemplate.Add(TileViewItemElement4)
        TileView1.TileTemplate.Add(TileViewItemElement5)
        TileView1.TileTemplate.Add(TileViewItemElement6)
        TileView1.TileTemplate.Add(TileViewItemElement7)
        TileView1.TileTemplate.Add(TileViewItemElement8)
        TileView1.TileTemplate.Add(TileViewItemElement9)
        TileView1.TileTemplate.Add(TileViewItemElement10)
        ' 
        ' PanelTitulo
        ' 
        PanelTitulo.BackColor = Color.RoyalBlue
        PanelTitulo.Controls.Add(LabelControl2)
        PanelTitulo.Controls.Add(Label1)
        PanelTitulo.Dock = DockStyle.Top
        PanelTitulo.Location = New Point(0, 0)
        PanelTitulo.Name = "PanelTitulo"
        PanelTitulo.Size = New Size(625, 48)
        PanelTitulo.TabIndex = 8
        ' 
        ' LabelControl2
        ' 
        LabelControl2.AutoSizeMode = LabelAutoSizeMode.None
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
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = Color.LightBlue
        ClientSize = New Size(625, 950)
        ControlBox = False
        Controls.Add(PanelTitulo)
        Controls.Add(GridControlAsignacionArticulos)
        Controls.Add(GroupControlArticulos)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Location = New Point(0, 80)
        Margin = New Padding(3, 2, 3, 2)
        MinimumSize = New Size(625, 950)
        Name = "frmAsignar"
        StartPosition = FormStartPosition.Manual
        CType(RepositoryItemPictureEdit1, ComponentModel.ISupportInitialize).EndInit()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).EndInit()
        GroupControlArticulos.ResumeLayout(False)
        GroupControlArticulos.PerformLayout()
        CType(TextEditLocation.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(TextEditItem.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(IconWeigth, ComponentModel.ISupportInitialize).EndInit()
        CType(SpinEditCantidad.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlAsignacionArticulos, ComponentModel.ISupportInitialize).EndInit()
        CType(TileView1, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ButtonConfirmacionArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlAsignacionArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SpinEditCantidad As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents ButtonConsultarUbicacion As SimpleButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelTotalStock As LabelControl
    Friend WithEvents Label7 As Label
    Friend WithEvents LabelLocalStock As LabelControl
    Friend WithEvents Label9 As Label
    Friend WithEvents IconWeigth As SvgImageBox
    Friend WithEvents ButtonResetForm As SimpleButton
    Friend WithEvents TileView1 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents ColumnItem As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents ColumnTotalStock As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents ColumnStock As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents ColumnReference As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents ColumnLocal As DevExpress.XtraGrid.Columns.TileViewColumn
    Friend WithEvents RepositoryItemPictureEdit1 As Repository.RepositoryItemPictureEdit
    Friend WithEvents TextEditItem As TextEdit
    Friend WithEvents TextEditLocation As TextEdit
End Class
