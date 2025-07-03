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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignar))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        btnSalir = New SimpleButton()
        GroupControlUbicacion = New GroupControl()
        ButtonConsultarUbicacion = New SimpleButton()
        LabelNombreAlmacen = New LabelControl()
        BotonConfirmacionDeUbicacion = New SimpleButton()
        TextBoxCodigoUbicacion = New TextBox()
        LabelNombreUbicacion = New LabelControl()
        GroupControlArticulos = New GroupControl()
        LabelControl6 = New LabelControl()
        LabelStockTotal = New LabelControl()
        SpinEditCantidad = New SpinEdit()
        LabelIndicadorPorPeso = New Label()
        LabelControl3 = New LabelControl()
        btnNuevaUbicacion = New SimpleButton()
        LabelControl1 = New LabelControl()
        ButtonConfirmacionArticulo = New SimpleButton()
        TextBoxCodigoArticulo = New TextBox()
        LabelNombreArticulo = New LabelControl()
        GridControlAsignacionArticulos = New DevExpress.XtraGrid.GridControl()
        GridViewAsignacionArticulos = New DevExpress.XtraGrid.Views.Grid.GridView()
        ColumnItem = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnTotalStock = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnStock = New DevExpress.XtraGrid.Columns.GridColumn()
        PanelTitulo = New Panel()
        LabelControl2 = New LabelControl()
        Label1 = New Label()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(SpinEditCantidad.Properties, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.Location = ImageLocation.MiddleLeft
        btnSalir.ImageOptions.SvgImage = CType(resources.GetObject("btnSalir.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(437, 875)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 0
        btnSalir.Text = "Volver"
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
        GroupControlUbicacion.Size = New Size(578, 108)
        GroupControlUbicacion.TabIndex = 0
        GroupControlUbicacion.Text = "Leer Ubicación"
        ' 
        ' ButtonConsultarUbicacion
        ' 
        ButtonConsultarUbicacion.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConsultarUbicacion.ImageOptions.SvgImage = CType(resources.GetObject("ButtonConsultarUbicacion.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        ButtonConsultarUbicacion.Location = New Point(468, 65)
        ButtonConsultarUbicacion.Name = "ButtonConsultarUbicacion"
        ButtonConsultarUbicacion.Size = New Size(33, 33)
        ButtonConsultarUbicacion.TabIndex = 1
        ' 
        ' LabelNombreAlmacen
        ' 
        LabelNombreAlmacen.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreAlmacen.Appearance.BackColor = Color.RoyalBlue
        LabelNombreAlmacen.Appearance.Font = New Font("Tahoma", 12.25F)
        LabelNombreAlmacen.Appearance.ForeColor = Color.White
        LabelNombreAlmacen.Appearance.Options.UseBackColor = True
        LabelNombreAlmacen.Appearance.Options.UseFont = True
        LabelNombreAlmacen.Appearance.Options.UseForeColor = True
        LabelNombreAlmacen.AutoSizeMode = LabelAutoSizeMode.None
        LabelNombreAlmacen.Location = New Point(208, 26)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Padding = New Padding(6, 0, 6, 0)
        LabelNombreAlmacen.Size = New Size(295, 33)
        LabelNombreAlmacen.TabIndex = 7
        ' 
        ' BotonConfirmacionDeUbicacion
        ' 
        BotonConfirmacionDeUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonConfirmacionDeUbicacion.Appearance.BorderColor = Color.Transparent
        BotonConfirmacionDeUbicacion.Appearance.Options.UseBorderColor = True
        BotonConfirmacionDeUbicacion.ImageOptions.Location = ImageLocation.MiddleCenter
        BotonConfirmacionDeUbicacion.ImageOptions.SvgImage = CType(resources.GetObject("BotonConfirmacionDeUbicacion.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        BotonConfirmacionDeUbicacion.ImageOptions.SvgImageSize = New Size(50, 50)
        BotonConfirmacionDeUbicacion.Location = New Point(517, 37)
        BotonConfirmacionDeUbicacion.Margin = New Padding(4, 3, 4, 3)
        BotonConfirmacionDeUbicacion.Name = "BotonConfirmacionDeUbicacion"
        BotonConfirmacionDeUbicacion.Size = New Size(50, 50)
        BotonConfirmacionDeUbicacion.TabIndex = 2
        BotonConfirmacionDeUbicacion.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        BotonConfirmacionDeUbicacion.ToolTipTitle = "Confirma Ubicación"
        ' 
        ' TextBoxCodigoUbicacion
        ' 
        TextBoxCodigoUbicacion.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCodigoUbicacion.Location = New Point(15, 26)
        TextBoxCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoUbicacion.MaxLength = 13
        TextBoxCodigoUbicacion.Name = "TextBoxCodigoUbicacion"
        TextBoxCodigoUbicacion.Size = New Size(185, 33)
        TextBoxCodigoUbicacion.TabIndex = 0
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
        LabelNombreUbicacion.AutoSizeMode = LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(15, 65)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Padding = New Padding(6, 0, 6, 0)
        LabelNombreUbicacion.Size = New Size(445, 33)
        LabelNombreUbicacion.TabIndex = 4
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(LabelControl6)
        GroupControlArticulos.Controls.Add(LabelStockTotal)
        GroupControlArticulos.Controls.Add(SpinEditCantidad)
        GroupControlArticulos.Controls.Add(LabelIndicadorPorPeso)
        GroupControlArticulos.Controls.Add(LabelControl3)
        GroupControlArticulos.Controls.Add(btnNuevaUbicacion)
        GroupControlArticulos.Controls.Add(LabelControl1)
        GroupControlArticulos.Controls.Add(ButtonConfirmacionArticulo)
        GroupControlArticulos.Controls.Add(TextBoxCodigoArticulo)
        GroupControlArticulos.Controls.Add(LabelNombreArticulo)
        GroupControlArticulos.Location = New Point(9, 168)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 203)
        GroupControlArticulos.TabIndex = 1
        GroupControlArticulos.Text = "Leer Artículos"
        GroupControlArticulos.Visible = False
        ' 
        ' LabelControl6
        ' 
        LabelControl6.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl6.Appearance.Options.UseFont = True
        LabelControl6.Location = New Point(15, 113)
        LabelControl6.Margin = New Padding(3, 2, 3, 2)
        LabelControl6.Name = "LabelControl6"
        LabelControl6.Size = New Size(132, 19)
        LabelControl6.TabIndex = 30
        LabelControl6.Text = "Existencias Totales"
        ' 
        ' LabelStockTotal
        ' 
        LabelStockTotal.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelStockTotal.Appearance.BackColor = Color.RoyalBlue
        LabelStockTotal.Appearance.Font = New Font("Tahoma", 12.25F)
        LabelStockTotal.Appearance.ForeColor = Color.White
        LabelStockTotal.Appearance.Options.UseBackColor = True
        LabelStockTotal.Appearance.Options.UseFont = True
        LabelStockTotal.Appearance.Options.UseForeColor = True
        LabelStockTotal.AutoSizeMode = LabelAutoSizeMode.None
        LabelStockTotal.Location = New Point(154, 106)
        LabelStockTotal.Margin = New Padding(4, 3, 4, 3)
        LabelStockTotal.Name = "LabelStockTotal"
        LabelStockTotal.Padding = New Padding(6, 0, 6, 0)
        LabelStockTotal.Size = New Size(413, 33)
        LabelStockTotal.TabIndex = 1
        ' 
        ' SpinEditCantidad
        ' 
        SpinEditCantidad.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidad.Location = New Point(84, 152)
        SpinEditCantidad.Margin = New Padding(4, 3, 4, 3)
        SpinEditCantidad.Name = "SpinEditCantidad"
        SpinEditCantidad.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True
        SpinEditCantidad.Properties.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        SpinEditCantidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        SpinEditCantidad.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidad.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidad.Size = New Size(185, 33)
        SpinEditCantidad.TabIndex = 2
        ' 
        ' LabelIndicadorPorPeso
        ' 
        LabelIndicadorPorPeso.BackColor = Color.White
        LabelIndicadorPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPeso.ForeColor = Color.Red
        LabelIndicadorPorPeso.Location = New Point(276, 155)
        LabelIndicadorPorPeso.Name = "LabelIndicadorPorPeso"
        LabelIndicadorPorPeso.Size = New Size(234, 25)
        LabelIndicadorPorPeso.TabIndex = 12
        LabelIndicadorPorPeso.Text = "Por Peso/Fracción"
        LabelIndicadorPorPeso.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPeso.Visible = False
        ' 
        ' LabelControl3
        ' 
        LabelControl3.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl3.Appearance.Options.UseFont = True
        LabelControl3.Location = New Point(15, 34)
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
        btnNuevaUbicacion.ImageOptions.Location = ImageLocation.MiddleLeft
        btnNuevaUbicacion.ImageOptions.SvgImage = CType(resources.GetObject("btnNuevaUbicacion.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        btnNuevaUbicacion.ImageOptions.SvgImageSize = New Size(27, 27)
        btnNuevaUbicacion.Location = New Point(423, 26)
        btnNuevaUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnNuevaUbicacion.Name = "btnNuevaUbicacion"
        btnNuevaUbicacion.Size = New Size(144, 33)
        btnNuevaUbicacion.TabIndex = 4
        btnNuevaUbicacion.Text = "Nueva Ubicación"
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(15, 158)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(62, 19)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Cantidad"
        ' 
        ' ButtonConfirmacionArticulo
        ' 
        ButtonConfirmacionArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionArticulo.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConfirmacionArticulo.ImageOptions.SvgImage = CType(resources.GetObject("ButtonConfirmacionArticulo.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        ButtonConfirmacionArticulo.ImageOptions.SvgImageSize = New Size(50, 50)
        ButtonConfirmacionArticulo.Location = New Point(517, 145)
        ButtonConfirmacionArticulo.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionArticulo.Name = "ButtonConfirmacionArticulo"
        ButtonConfirmacionArticulo.Size = New Size(50, 50)
        ButtonConfirmacionArticulo.TabIndex = 3
        ' 
        ' TextBoxCodigoArticulo
        ' 
        TextBoxCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoArticulo.Location = New Point(84, 27)
        TextBoxCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoArticulo.Name = "TextBoxCodigoArticulo"
        TextBoxCodigoArticulo.Size = New Size(185, 33)
        TextBoxCodigoArticulo.TabIndex = 0
        ' 
        ' LabelNombreArticulo
        ' 
        LabelNombreArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticulo.Appearance.Font = New Font("Tahoma", 12.25F)
        LabelNombreArticulo.Appearance.ForeColor = Color.White
        LabelNombreArticulo.Appearance.Options.UseBackColor = True
        LabelNombreArticulo.Appearance.Options.UseFont = True
        LabelNombreArticulo.Appearance.Options.UseForeColor = True
        LabelNombreArticulo.AutoSizeMode = LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(15, 66)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(552, 33)
        LabelNombreArticulo.TabIndex = 4
        ' 
        ' GridControlAsignacionArticulos
        ' 
        GridControlAsignacionArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlAsignacionArticulos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Font = New Font("Tahoma", 15.75F)
        GridControlAsignacionArticulos.Location = New Point(10, 376)
        GridControlAsignacionArticulos.MainView = GridViewAsignacionArticulos
        GridControlAsignacionArticulos.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Name = "GridControlAsignacionArticulos"
        GridControlAsignacionArticulos.Size = New Size(577, 494)
        GridControlAsignacionArticulos.TabIndex = 7
        GridControlAsignacionArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewAsignacionArticulos})
        GridControlAsignacionArticulos.Visible = False
        ' 
        ' GridViewAsignacionArticulos
        ' 
        GridViewAsignacionArticulos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnItem, ColumnLocation, ColumnTotalStock, ColumnStock})
        GridViewAsignacionArticulos.DetailHeight = 262
        GridViewAsignacionArticulos.GridControl = GridControlAsignacionArticulos
        GridViewAsignacionArticulos.Name = "GridViewAsignacionArticulos"
        GridViewAsignacionArticulos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewAsignacionArticulos.OptionsBehavior.Editable = False
        GridViewAsignacionArticulos.OptionsCustomization.AllowGroup = False
        GridViewAsignacionArticulos.OptionsEditForm.PopupEditFormWidth = 700
        GridViewAsignacionArticulos.OptionsView.ShowGroupPanel = False
        GridViewAsignacionArticulos.OptionsView.ShowIndicator = False
        ' 
        ' ColumnItem
        ' 
        ColumnItem.Caption = "Artículo"
        ColumnItem.FieldName = "Item"
        ColumnItem.Name = "ColumnItem"
        ColumnItem.OptionsColumn.AllowEdit = False
        ColumnItem.Visible = True
        ColumnItem.VisibleIndex = 0
        ColumnItem.Width = 535
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
        ' ColumnStock
        ' 
        ColumnStock.Caption = "Asignadas"
        ColumnStock.FieldName = "LocalStock"
        ColumnStock.Name = "ColumnStock"
        ColumnStock.OptionsColumn.AllowEdit = False
        ColumnStock.Visible = True
        ColumnStock.VisibleIndex = 3
        ColumnStock.Width = 87
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
        LabelControl2.AutoSizeMode = LabelAutoSizeMode.None
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
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
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
        CType(SpinEditCantidad.Properties, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnNuevaUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlAsignacionArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAsignacionArticulos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelIndicadorPorPeso As Label
    Friend WithEvents SpinEditCantidad As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelStockTotal As LabelControl
    Friend WithEvents LabelControl6 As LabelControl
    Friend WithEvents ColumnItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnTotalStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ButtonConsultarUbicacion As SimpleButton
End Class
