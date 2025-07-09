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
        btnSalir = New SimpleButton()
        ButtonConsultarUbicacion = New SimpleButton()
        TextBoxCodigoUbicacion = New TextBox()
        LabelNombreUbicacion = New LabelControl()
        GroupControlArticulos = New GroupControl()
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
        Label2 = New Label()
        SpinEditCantidad = New SpinEdit()
        btnNuevaUbicacion = New SimpleButton()
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
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(IconWeigth, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.Location = ImageLocation.MiddleLeft
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(437, 875)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 2
        btnSalir.Text = "Volver"
        ' 
        ' ButtonConsultarUbicacion
        ' 
        ButtonConsultarUbicacion.Enabled = False
        ButtonConsultarUbicacion.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConsultarUbicacion.ImageOptions.SvgImage = My.Resources.Resources.about
        ButtonConsultarUbicacion.ImageOptions.SvgImageSize = New Size(50, 50)
        ButtonConsultarUbicacion.Location = New Point(507, 170)
        ButtonConsultarUbicacion.Name = "ButtonConsultarUbicacion"
        ButtonConsultarUbicacion.Size = New Size(50, 50)
        ButtonConsultarUbicacion.TabIndex = 1
        ' 
        ' TextBoxCodigoUbicacion
        ' 
        TextBoxCodigoUbicacion.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCodigoUbicacion.Location = New Point(110, 67)
        TextBoxCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoUbicacion.MaxLength = 13
        TextBoxCodigoUbicacion.Name = "TextBoxCodigoUbicacion"
        TextBoxCodigoUbicacion.Size = New Size(141, 33)
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
        LabelNombreUbicacion.Location = New Point(259, 68)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Padding = New Padding(6, 0, 6, 0)
        LabelNombreUbicacion.Size = New Size(298, 33)
        LabelNombreUbicacion.TabIndex = 4
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
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
        GroupControlArticulos.Controls.Add(Label2)
        GroupControlArticulos.Controls.Add(ButtonConsultarUbicacion)
        GroupControlArticulos.Controls.Add(TextBoxCodigoUbicacion)
        GroupControlArticulos.Controls.Add(SpinEditCantidad)
        GroupControlArticulos.Controls.Add(LabelNombreUbicacion)
        GroupControlArticulos.Controls.Add(btnNuevaUbicacion)
        GroupControlArticulos.Controls.Add(ButtonConfirmacionArticulo)
        GroupControlArticulos.Controls.Add(TextBoxCodigoArticulo)
        GroupControlArticulos.Controls.Add(LabelNombreArticulo)
        GroupControlArticulos.Location = New Point(9, 54)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 306)
        GroupControlArticulos.TabIndex = 0
        GroupControlArticulos.Text = "Leer Artículos"
        ' 
        ' IconWeigth
        ' 
        IconWeigth.Location = New Point(302, 241)
        IconWeigth.Name = "IconWeigth"
        IconWeigth.Size = New Size(40, 40)
        IconWeigth.SvgImage = My.Resources.Resources.weightedpies
        IconWeigth.TabIndex = 41
        IconWeigth.Text = "SvgImageBox1"
        IconWeigth.Visible = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(15, 257)
        Label9.Name = "Label9"
        Label9.Size = New Size(88, 19)
        Label9.TabIndex = 40
        Label9.Text = "Cantidad:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Tahoma", 15.75F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(10, 213)
        Label8.Margin = New Padding(3, 8, 3, 8)
        Label8.Name = "Label8"
        Label8.Size = New Size(125, 25)
        Label8.TabIndex = 39
        Label8.Text = "Asignación"
        ' 
        ' LabelTotalStock
        ' 
        LabelTotalStock.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelTotalStock.Appearance.Options.UseFont = True
        LabelTotalStock.Cursor = Cursors.Hand
        LabelTotalStock.Location = New Point(194, 183)
        LabelTotalStock.Name = "LabelTotalStock"
        LabelTotalStock.Size = New Size(40, 19)
        LabelTotalStock.TabIndex = 38
        LabelTotalStock.Text = "0000"
        LabelTotalStock.ToolTip = "Haz Click para asignar como cantidad"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(130, 183)
        Label7.Name = "Label7"
        Label7.Size = New Size(58, 19)
        Label7.TabIndex = 37
        Label7.Text = "Total:"
        ' 
        ' LabelLocalStock
        ' 
        LabelLocalStock.Appearance.Font = New Font("Tahoma", 12F, FontStyle.Bold)
        LabelLocalStock.Appearance.Options.UseFont = True
        LabelLocalStock.Location = New Point(73, 183)
        LabelLocalStock.Name = "LabelLocalStock"
        LabelLocalStock.Size = New Size(40, 19)
        LabelLocalStock.TabIndex = 36
        LabelLocalStock.Text = "0000"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(10, 183)
        Label6.Name = "Label6"
        Label6.Size = New Size(57, 19)
        Label6.TabIndex = 35
        Label6.Text = "Local:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Tahoma", 15.75F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(8, 150)
        Label5.Margin = New Padding(3, 8, 3, 8)
        Label5.Name = "Label5"
        Label5.Size = New Size(130, 25)
        Label5.TabIndex = 34
        Label5.Text = "Existencias"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(10, 114)
        Label4.Name = "Label4"
        Label4.Size = New Size(43, 19)
        Label4.TabIndex = 33
        Label4.Text = "Ref:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(10, 75)
        Label3.Name = "Label3"
        Label3.Size = New Size(93, 19)
        Label3.TabIndex = 32
        Label3.Text = "Ubicación:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Tahoma", 15.75F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(8, 31)
        Label2.Margin = New Padding(3, 8, 3, 8)
        Label2.Name = "Label2"
        Label2.Size = New Size(268, 25)
        Label2.TabIndex = 31
        Label2.Text = "Información Del Artículo"
        ' 
        ' SpinEditCantidad
        ' 
        SpinEditCantidad.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidad.Enabled = False
        SpinEditCantidad.Location = New Point(110, 249)
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
        SpinEditCantidad.Properties.LookAndFeel.SkinName = "WXI"
        SpinEditCantidad.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        SpinEditCantidad.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidad.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidad.Size = New Size(185, 33)
        SpinEditCantidad.TabIndex = 2
        ' 
        ' btnNuevaUbicacion
        ' 
        btnNuevaUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnNuevaUbicacion.Appearance.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnNuevaUbicacion.Appearance.Options.UseFont = True
        btnNuevaUbicacion.CausesValidation = False
        btnNuevaUbicacion.Enabled = False
        btnNuevaUbicacion.ImageOptions.Location = ImageLocation.MiddleLeft
        btnNuevaUbicacion.ImageOptions.SvgImage = My.Resources.Resources.resetview
        btnNuevaUbicacion.ImageOptions.SvgImageSize = New Size(70, 70)
        btnNuevaUbicacion.Location = New Point(399, 226)
        btnNuevaUbicacion.Margin = New Padding(4, 3, 4, 3)
        btnNuevaUbicacion.Name = "btnNuevaUbicacion"
        btnNuevaUbicacion.Size = New Size(75, 75)
        btnNuevaUbicacion.TabIndex = 4
        ' 
        ' ButtonConfirmacionArticulo
        ' 
        ButtonConfirmacionArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionArticulo.Enabled = False
        ButtonConfirmacionArticulo.ImageOptions.Location = ImageLocation.MiddleCenter
        ButtonConfirmacionArticulo.ImageOptions.SvgImage = My.Resources.Resources.actions_check
        ButtonConfirmacionArticulo.ImageOptions.SvgImageSize = New Size(50, 50)
        ButtonConfirmacionArticulo.Location = New Point(482, 226)
        ButtonConfirmacionArticulo.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionArticulo.Name = "ButtonConfirmacionArticulo"
        ButtonConfirmacionArticulo.Size = New Size(75, 75)
        ButtonConfirmacionArticulo.TabIndex = 3
        ' 
        ' TextBoxCodigoArticulo
        ' 
        TextBoxCodigoArticulo.Enabled = False
        TextBoxCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoArticulo.Location = New Point(60, 106)
        TextBoxCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoArticulo.Name = "TextBoxCodigoArticulo"
        TextBoxCodigoArticulo.Size = New Size(128, 33)
        TextBoxCodigoArticulo.TabIndex = 1
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
        LabelNombreArticulo.Location = New Point(196, 107)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Padding = New Padding(6, 0, 6, 0)
        LabelNombreArticulo.Size = New Size(361, 33)
        LabelNombreArticulo.TabIndex = 4
        ' 
        ' GridControlAsignacionArticulos
        ' 
        GridControlAsignacionArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlAsignacionArticulos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Font = New Font("Tahoma", 15.75F)
        GridControlAsignacionArticulos.Location = New Point(10, 365)
        GridControlAsignacionArticulos.MainView = GridViewAsignacionArticulos
        GridControlAsignacionArticulos.Margin = New Padding(3, 2, 3, 2)
        GridControlAsignacionArticulos.Name = "GridControlAsignacionArticulos"
        GridControlAsignacionArticulos.Size = New Size(577, 505)
        GridControlAsignacionArticulos.TabIndex = 1
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
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Location = New Point(0, 80)
        Margin = New Padding(3, 2, 3, 2)
        MinimumSize = New Size(600, 900)
        Name = "frmAsignar"
        StartPosition = FormStartPosition.Manual
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).EndInit()
        GroupControlArticulos.ResumeLayout(False)
        GroupControlArticulos.PerformLayout()
        CType(IconWeigth, ComponentModel.ISupportInitialize).EndInit()
        CType(SpinEditCantidad.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlAsignacionArticulos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewAsignacionArticulos, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBoxCodigoUbicacion As TextBox
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ButtonConfirmacionArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBoxCodigoArticulo As TextBox
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlAsignacionArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAsignacionArticulos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SpinEditCantidad As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents ColumnItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnTotalStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ButtonConsultarUbicacion As SimpleButton
    Friend WithEvents Label2 As Label
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
    Friend WithEvents btnNuevaUbicacion As SimpleButton
End Class
