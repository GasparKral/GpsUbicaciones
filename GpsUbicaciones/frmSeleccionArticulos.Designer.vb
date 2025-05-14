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
        LabelNombreAlmacen = New DevExpress.XtraEditors.LabelControl()
        LabelStockArticulo = New DevExpress.XtraEditors.LabelControl()
        ButtonConfirmacionLectura = New DevExpress.XtraEditors.SimpleButton()
        TextBoxCantidadSeleccionada = New TextBox()
        TextBoxCodigoUbicacion = New TextBox()
        TextBoxCodigoArticulo = New TextBox()
        LabelNombreUbicacion = New DevExpress.XtraEditors.LabelControl()
        LabelNombreArticulo = New DevExpress.XtraEditors.LabelControl()
        GridControlArticulosSeleccionados = New DevExpress.XtraGrid.GridControl()
        GridViewArticulosSeleccionados = New DevExpress.XtraGrid.Views.Grid.GridView()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Label1 = New Label()
        GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        RadioButton2 = New RadioButton()
        RadioButton1 = New RadioButton()
        DatePicker = New DevExpress.XtraEditors.DateEdit()
        LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        GridPedidos = New DevExpress.XtraGrid.GridControl()
        GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(GroupControlUbicacion, ComponentModel.ISupportInitialize).BeginInit()
        GroupControlUbicacion.SuspendLayout()
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
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
        GroupControlUbicacion.Appearance.BackColor = Color.FromArgb(224, 224, 224)
        GroupControlUbicacion.Appearance.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
        GroupControlUbicacion.AppearanceCaption.Options.UseBackColor = True
        GroupControlUbicacion.AppearanceCaption.Options.UseFont = True
        GroupControlUbicacion.Controls.Add(lblPorPeso)
        GroupControlUbicacion.Controls.Add(LabelControl1)
        GroupControlUbicacion.Controls.Add(LabelNombreAlmacen)
        GroupControlUbicacion.Controls.Add(LabelStockArticulo)
        GroupControlUbicacion.Controls.Add(ButtonConfirmacionLectura)
        GroupControlUbicacion.Controls.Add(TextBoxCantidadSeleccionada)
        GroupControlUbicacion.Controls.Add(TextBoxCodigoUbicacion)
        GroupControlUbicacion.Controls.Add(TextBoxCodigoArticulo)
        GroupControlUbicacion.Controls.Add(LabelNombreUbicacion)
        GroupControlUbicacion.Controls.Add(LabelNombreArticulo)
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
        lblPorPeso.Font = New Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
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
        LabelControl1.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        LabelControl1.Appearance.Options.UseFont = True
        LabelControl1.Location = New Point(16, 109)
        LabelControl1.Margin = New Padding(3, 2, 3, 2)
        LabelControl1.Name = "LabelControl1"
        LabelControl1.Size = New Size(83, 25)
        LabelControl1.TabIndex = 9
        LabelControl1.Text = "Cantidad"
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
        LabelNombreAlmacen.Location = New Point(184, 28)
        LabelNombreAlmacen.Margin = New Padding(4, 3, 4, 3)
        LabelNombreAlmacen.Name = "LabelNombreAlmacen"
        LabelNombreAlmacen.Size = New Size(147, 28)
        LabelNombreAlmacen.TabIndex = 7
        LabelNombreAlmacen.Text = "Nombre Almacen"
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
        LabelStockArticulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelStockArticulo.Location = New Point(184, 106)
        LabelStockArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelStockArticulo.Name = "LabelStockArticulo"
        LabelStockArticulo.Size = New Size(104, 28)
        LabelStockArticulo.TabIndex = 8
        LabelStockArticulo.Text = "Stock"
        ' 
        ' ButtonConfirmacionLectura
        ' 
        ButtonConfirmacionLectura.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ButtonConfirmacionLectura.ImageOptions.Image = CType(resources.GetObject("btnUbicacion.ImageOptions.Image"), Image)
        ButtonConfirmacionLectura.Location = New Point(511, 95)
        ButtonConfirmacionLectura.Margin = New Padding(4, 3, 4, 3)
        ButtonConfirmacionLectura.Name = "ButtonConfirmacionLectura"
        ButtonConfirmacionLectura.Size = New Size(55, 50)
        ButtonConfirmacionLectura.TabIndex = 6
        ' 
        ' TextBoxCantidadSeleccionada
        ' 
        TextBoxCantidadSeleccionada.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxCantidadSeleccionada.Font = New Font("Tahoma", 15.75F)
        TextBoxCantidadSeleccionada.Location = New Point(108, 105)
        TextBoxCantidadSeleccionada.Margin = New Padding(4, 3, 4, 3)
        TextBoxCantidadSeleccionada.Name = "TextBoxCantidadSeleccionada"
        TextBoxCantidadSeleccionada.Size = New Size(68, 33)
        TextBoxCantidadSeleccionada.TabIndex = 2
        TextBoxCantidadSeleccionada.TextAlign = HorizontalAlignment.Right
        ' 
        ' TextBoxCodigoUbicacion
        ' 
        TextBoxCodigoUbicacion.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoUbicacion.Location = New Point(16, 27)
        TextBoxCodigoUbicacion.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoUbicacion.Name = "TextBoxCodigoUbicacion"
        TextBoxCodigoUbicacion.Size = New Size(160, 33)
        TextBoxCodigoUbicacion.TabIndex = 0
        ' 
        ' TextBoxCodigoArticulo
        ' 
        TextBoxCodigoArticulo.Font = New Font("Tahoma", 15.75F)
        TextBoxCodigoArticulo.Location = New Point(16, 66)
        TextBoxCodigoArticulo.Margin = New Padding(4, 3, 4, 3)
        TextBoxCodigoArticulo.Name = "TextBoxCodigoArticulo"
        TextBoxCodigoArticulo.Size = New Size(160, 33)
        TextBoxCodigoArticulo.TabIndex = 1
        ' 
        ' LabelNombreUbicacion
        ' 
        LabelNombreUbicacion.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelNombreUbicacion.Appearance.BackColor = Color.RoyalBlue
        LabelNombreUbicacion.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
        LabelNombreUbicacion.Appearance.ForeColor = Color.White
        LabelNombreUbicacion.Appearance.Options.UseBackColor = True
        LabelNombreUbicacion.Appearance.Options.UseFont = True
        LabelNombreUbicacion.Appearance.Options.UseForeColor = True
        LabelNombreUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelNombreUbicacion.Location = New Point(349, 27)
        LabelNombreUbicacion.Margin = New Padding(4, 3, 4, 3)
        LabelNombreUbicacion.Name = "LabelNombreUbicacion"
        LabelNombreUbicacion.Size = New Size(217, 28)
        LabelNombreUbicacion.TabIndex = 4
        LabelNombreUbicacion.Text = "Nombre Ubicación"
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
        LabelNombreArticulo.Location = New Point(184, 66)
        LabelNombreArticulo.Margin = New Padding(4, 3, 4, 3)
        LabelNombreArticulo.Name = "LabelNombreArticulo"
        LabelNombreArticulo.Size = New Size(382, 28)
        LabelNombreArticulo.TabIndex = 4
        LabelNombreArticulo.Text = "Nombre Articulo"
        ' 
        ' GridControlArticulosSeleccionados
        ' 
        GridControlArticulosSeleccionados.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlArticulosSeleccionados.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
        GridControlArticulosSeleccionados.Location = New Point(13, 369)
        GridControlArticulosSeleccionados.MainView = GridViewArticulosSeleccionados
        GridControlArticulosSeleccionados.Margin = New Padding(3, 2, 3, 2)
        GridControlArticulosSeleccionados.Name = "GridControlArticulosSeleccionados"
        GridControlArticulosSeleccionados.Size = New Size(579, 362)
        GridControlArticulosSeleccionados.TabIndex = 7
        GridControlArticulosSeleccionados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewArticulosSeleccionados})
        GridControlArticulosSeleccionados.Visible = False
        ' 
        ' GridViewArticulosSeleccionados
        ' 
        GridViewArticulosSeleccionados.DetailHeight = 262
        GridViewArticulosSeleccionados.GridControl = GridControlArticulosSeleccionados
        GridViewArticulosSeleccionados.Name = "GridViewArticulosSeleccionados"
        GridViewArticulosSeleccionados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewArticulosSeleccionados.OptionsBehavior.Editable = False
        GridViewArticulosSeleccionados.OptionsEditForm.PopupEditFormWidth = 700
        GridViewArticulosSeleccionados.OptionsView.ShowGroupPanel = False
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
        LabelControl2.Appearance.BackColor = Color.FromArgb(224, 224, 224)
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
        Label1.Font = New Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
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
        ' DatePicker
        ' 
        DatePicker.EditValue = Nothing
        DatePicker.Location = New Point(86, 54)
        DatePicker.Name = "DatePicker"
        DatePicker.Properties.Appearance.Font = New Font("Tahoma", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
        DatePicker.Properties.Appearance.Options.UseFont = True
        DatePicker.Properties.AppearanceCalendar.DayCell.Font = New Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
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
        LabelControl3.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0)
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
        GridPedidos.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
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
        CType(GridControlArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewArticulosSeleccionados, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ButtonConfirmacionLectura As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextBoxCodigoUbicacion As TextBox
    Friend WithEvents LabelNombreUbicacion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBoxCodigoArticulo As TextBox
    Friend WithEvents LabelNombreArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelStockArticulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBoxCantidadSeleccionada As TextBox
    Friend WithEvents GridControlArticulosSeleccionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewArticulosSeleccionados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelNombreAlmacen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DatePicker As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GridPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblPorPeso As Label
End Class
