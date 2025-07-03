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
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GroupControlUbicacion = New DevExpress.XtraEditors.GroupControl()
        LabelNombreAlmacen = New DevExpress.XtraEditors.LabelControl()
        BotonConfirmarUbicacion = New DevExpress.XtraEditors.SimpleButton()
        TextEditCodigoUbicacion = New TextBox()
        LabelNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        GroupControlArticulos = New DevExpress.XtraEditors.GroupControl()
        ButtonCancelar = New DevExpress.XtraEditors.SimpleButton()
        SpinEditCantidadSeleccionada = New DevExpress.XtraEditors.SpinEdit()
        LabelIndicadorPorPeso = New Label()
        LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        LabelStockArticulo = New DevExpress.XtraEditors.LabelControl()
        BotonConfirmarArticulo = New DevExpress.XtraEditors.SimpleButton()
        TextEditCodigoArticulo = New TextBox()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        GridControlArticulosSeleccionados = New DevExpress.XtraGrid.GridControl()
        GridViewArticulosSeleccionados = New DevExpress.XtraGrid.Views.Grid.GridView()
        ColumnItemRef = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnAmmount = New DevExpress.XtraGrid.Columns.GridColumn()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(GroupControlArticulos, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlArticulos.SuspendLayout()
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.SvgImage = CType(resources.GetObject("btnSalir.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        btnSalir.Location = New Point(438, 822)
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
        GroupControlUbicacion.Controls.Add(LabelNombreAlmacen)
        GroupControlUbicacion.Controls.Add(BotonConfirmarUbicacion)
        GroupControlUbicacion.Controls.Add(TextEditCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Location = New Point(10, 54)
        GroupControlUbicacion.Margin = New Padding(4, 3, 4, 3)
        GroupControlUbicacion.Name = "GroupControlUbicacion"
        GroupControlUbicacion.Size = New Size(578, 109)
        GroupControlUbicacion.TabIndex = 0
        GroupControlUbicacion.Text = "Leer Ubicación"
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
        LabelNombreAlmacen.Location = New Point(209, 27)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Size = New Size(296, 33)
        LabelNombreAlmacen.TabIndex = 7
        ' 
        ' BotonConfirmarUbicacion
        ' 
        BotonConfirmarUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonConfirmarUbicacion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        BotonConfirmarUbicacion.ImageOptions.SvgImage = CType(resources.GetObject("BotonConfirmarUbicacion.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        BotonConfirmarUbicacion.ImageOptions.SvgImageSize = New Size(45, 45)
        BotonConfirmarUbicacion.Location = New Point(513, 41)
        BotonConfirmarUbicacion.Margin = New Padding(4, 3, 4, 3)
        BotonConfirmarUbicacion.Name = "BotonConfirmarUbicacion"
        BotonConfirmarUbicacion.Size = New Size(50, 50)
        BotonConfirmarUbicacion.TabIndex = 1
        ' 
        ' TextEditCodigoUbicacion
        ' 
        TextEditCodigoUbicacion.Font = New Font("Tahoma", 15.75F)
        TextEditCodigoUbicacion.Location = New Point(16, 27)
        TextEditCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextEditCodigoUbicacion.MaxLength = 13
        TextEditCodigoUbicacion.Name = "TextEditCodigoUbicacion"
        TextEditCodigoUbicacion.Size = New Size(185, 33)
        TextEditCodigoUbicacion.TabIndex = 0
        ' 
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(16, 66)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Size = New Size(489, 33)
        LabelNombreUbicacion.TabIndex = 4
        ' 
        ' GroupControlArticulos
        ' 
        GroupControlArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        GroupControlArticulos.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupControlArticulos.AppearanceCaption.Options.UseFont = True
        GroupControlArticulos.Controls.Add(ButtonCancelar)
        GroupControlArticulos.Controls.Add(SpinEditCantidadSeleccionada)
        GroupControlArticulos.Controls.Add(LabelIndicadorPorPeso)
        GroupControlArticulos.Controls.Add(LabelControl1)
        GroupControlArticulos.Controls.Add(LabelStockArticulo)
        GroupControlArticulos.Controls.Add(BotonConfirmarArticulo)
        GroupControlArticulos.Controls.Add(TextEditCodigoArticulo)
        GroupControlArticulos.Controls.Add(LabelNombreArticulo)
        GroupControlArticulos.Location = New Point(10, 169)
        GroupControlArticulos.Margin = New Padding(4, 3, 4, 3)
        GroupControlArticulos.Name = "GroupControlArticulos"
        GroupControlArticulos.Size = New Size(578, 130)
        GroupControlArticulos.TabIndex = 1
        GroupControlArticulos.Text = "Leer Artículos"
        GroupControlArticulos.Visible = False
        ' 
        ' ButtonCancelar
        ' 
        ButtonCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        ButtonCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        ButtonCancelar.ImageOptions.SvgImage = CType(resources.GetObject("ButtonCancelar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        ButtonCancelar.Location = New Point(480, 26)
        ButtonCancelar.Name = "ButtonCancelar"
        ButtonCancelar.Size = New Size(83, 40)
        ButtonCancelar.TabIndex = 2
        ButtonCancelar.Text = "Cancellar"
        ' 
        ' SpinEditCantidadSeleccionada
        ' 
        SpinEditCantidadSeleccionada.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        SpinEditCantidadSeleccionada.Location = New Point(110, 68)
        SpinEditCantidadSeleccionada.Name = "SpinEditCantidadSeleccionada"
        SpinEditCantidadSeleccionada.Properties.Appearance.Font = New Font("Tahoma", 15.75F)
        SpinEditCantidadSeleccionada.Properties.Appearance.Options.UseFont = True
        SpinEditCantidadSeleccionada.Properties.AutoHeight = False
        SpinEditCantidadSeleccionada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 35, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.Default)})
        SpinEditCantidadSeleccionada.Properties.IsFloatValue = False
        SpinEditCantidadSeleccionada.Properties.MaskSettings.Set("mask", "N00")
        SpinEditCantidadSeleccionada.Properties.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal
        SpinEditCantidadSeleccionada.Size = New Size(139, 40)
        SpinEditCantidadSeleccionada.TabIndex = 1
        ' 
        ' LabelIndicadorPorPeso
        ' 
        LabelIndicadorPorPeso.BackColor = Color.White
        LabelIndicadorPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelIndicadorPorPeso.ForeColor = Color.Red
        LabelIndicadorPorPeso.Location = New Point(348, 77)
        LabelIndicadorPorPeso.Name = "LabelIndicadorPorPeso"
        LabelIndicadorPorPeso.Size = New Size(158, 25)
        LabelIndicadorPorPeso.TabIndex = 13
        LabelIndicadorPorPeso.Text = "Por Peso/Fracción"
        LabelIndicadorPorPeso.TextAlign = ContentAlignment.MiddleCenter
        LabelIndicadorPorPeso.Visible = False
        ' 
        ' LabelControl1
        ' 
        LabelControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LabelControl1.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(21, 75)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(83, 25)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Cantidad"
        ' 
        ' LabelStockArticulo
        ' 
        LabelStockArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelStockArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelStockArticulo.Appearance.Font = New Font("Tahoma", 14.25F)
        LabelStockArticulo.Appearance.ForeColor = Color.White
        LabelStockArticulo.Appearance.Options.UseBackColor = True
        LabelStockArticulo.Appearance.Options.UseFont = True
        LabelStockArticulo.Appearance.Options.UseForeColor = True
        LabelStockArticulo.Appearance.Options.UseTextOptions = True
        LabelStockArticulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        LabelStockArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticulo.Location = New Point(256, 73)
        LabelStockArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticulo.Name = "LabelStockArticulo"
        LabelStockArticulo.Size = New Size(85, 33)
        LabelStockArticulo.TabIndex = 8
        ' 
        ' BotonConfirmarArticulo
        ' 
        BotonConfirmarArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BotonConfirmarArticulo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        BotonConfirmarArticulo.ImageOptions.SvgImage = CType(resources.GetObject("BotonConfirmarArticulo.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        BotonConfirmarArticulo.ImageOptions.SvgImageSize = New Size(45, 45)
        BotonConfirmarArticulo.Location = New Point(513, 72)
        BotonConfirmarArticulo.Margin = New Padding(4, 3, 4, 3)
        BotonConfirmarArticulo.Name = "BotonConfirmarArticulo"
        BotonConfirmarArticulo.Size = New Size(50, 50)
        BotonConfirmarArticulo.TabIndex = 3
        ' 
        ' TextEditCodigoArticulo
        ' 
        TextEditCodigoArticulo.Enabled = False
        TextEditCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextEditCodigoArticulo.Location = New Point(19, 29)
        TextEditCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextEditCodigoArticulo.MaxLength = 15
        TextEditCodigoArticulo.Name = "TextEditCodigoArticulo"
        TextEditCodigoArticulo.Size = New Size(182, 33)
        TextEditCodigoArticulo.TabIndex = 0
        ' 
        ' LabelNombreArticulo
        ' 
        LabelNombreArticulo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreArticulo.Appearance.BackColor = Color.RoyalBlue
        LabelNombreArticulo.Appearance.Font = New Font("Tahoma", 14.25F)
        LabelNombreArticulo.Appearance.ForeColor = Color.White
        LabelNombreArticulo.Appearance.Options.UseBackColor = True
        LabelNombreArticulo.Appearance.Options.UseFont = True
        LabelNombreArticulo.Appearance.Options.UseForeColor = True
        LabelNombreArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreArticulo.Location = New Point(209, 29)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Size = New Size(264, 33)
        LabelNombreArticulo.TabIndex = 4
        ' 
        ' GridControlArticulosSeleccionados
        ' 
        GridControlArticulosSeleccionados.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlArticulosSeleccionados.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Font = New Font("Tahoma", 15.75F)
        GridControlArticulosSeleccionados.Location = New Point(10, 304)
        GridControlArticulosSeleccionados.MainView = GridViewArticulosSeleccionados
        GridControlArticulosSeleccionados.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Name = "GridControlArticulosSeleccionados"
        GridControlArticulosSeleccionados.Size = New Size(579, 512)
        GridControlArticulosSeleccionados.TabIndex = 7
        GridControlArticulosSeleccionados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewArticulosSeleccionados})
        GridControlArticulosSeleccionados.Visible = False
        ' 
        ' GridViewArticulosSeleccionados
        ' 
        GridViewArticulosSeleccionados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnItemRef, ColumnItemName, ColumnLocation, ColumnAmmount})
        GridViewArticulosSeleccionados.DetailHeight = 262
        GridViewArticulosSeleccionados.GridControl = GridControlArticulosSeleccionados
        GridViewArticulosSeleccionados.Name = "GridViewArticulosSeleccionados"
        GridViewArticulosSeleccionados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewArticulosSeleccionados.OptionsBehavior.Editable = False
        GridViewArticulosSeleccionados.OptionsEditForm.PopupEditFormWidth = 700
        GridViewArticulosSeleccionados.OptionsView.ShowGroupPanel = False
        ' 
        ' ColumnItemRef
        ' 
        ColumnItemRef.Caption = "Referencia"
        ColumnItemRef.FieldName = "Ref"
        ColumnItemRef.Name = "ColumnItemRef"
        ColumnItemRef.Visible = True
        ColumnItemRef.VisibleIndex = 0
        ' 
        ' ColumnItemName
        ' 
        ColumnItemName.Caption = "Artículo"
        ColumnItemName.FieldName = "Nombre"
        ColumnItemName.Name = "ColumnItemName"
        ColumnItemName.Visible = True
        ColumnItemName.VisibleIndex = 1
        ' 
        ' ColumnLocation
        ' 
        ColumnLocation.Caption = "Ubicación"
        ColumnLocation.FieldName = "Ubicacion"
        ColumnLocation.Name = "ColumnLocation"
        ColumnLocation.Visible = True
        ColumnLocation.VisibleIndex = 2
        ' 
        ' ColumnAmmount
        ' 
        ColumnAmmount.Caption = "Unidades"
        ColumnAmmount.FieldName = "Uds"
        ColumnAmmount.Name = "ColumnAmmount"
        ColumnAmmount.Visible = True
        ColumnAmmount.VisibleIndex = 3
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
        Controls.Add(GridControlArticulosSeleccionados)
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
        CType(SpinEditCantidadSeleccionada.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        PanelTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControlUbicacion As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BotonConfirmarUbicacion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEditCodigoUbicacion As TextBox
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlArticulos As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BotonConfirmarArticulo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextEditCodigoArticulo As TextBox
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelStockArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControlArticulosSeleccionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewArticulosSeleccionados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelIndicadorPorPeso As Label
    Friend WithEvents SpinEditCantidadSeleccionada As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents ButtonCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ColumnItemRef As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnAmmount As DevExpress.XtraGrid.Columns.GridColumn
End Class
