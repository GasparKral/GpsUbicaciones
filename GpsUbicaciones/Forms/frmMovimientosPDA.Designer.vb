<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientosPDA
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GridControlMovimientos = New DevExpress.XtraGrid.GridControl()
        GridViewMovimientos = New DevExpress.XtraGrid.Views.Grid.GridView()
        ColumnAcción = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnCantidad = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnAmmount = New DevExpress.XtraGrid.Columns.GridColumn()
        ColumnLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(GridControlMovimientos, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewMovimientos, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnSalir
        ' 
        btnSalir.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.CausesValidation = False
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.arrowleft
        btnSalir.ImageOptions.SvgImageSize = New Size(40, 40)
        btnSalir.Location = New Point(437, 872)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 5
        btnSalir.Text = "Volver"
        ' 
        ' GridControlMovimientos
        ' 
        GridControlMovimientos.Location = New Point(12, 12)
        GridControlMovimientos.LookAndFeel.SkinName = "WXI"
        GridControlMovimientos.LookAndFeel.UseDefaultLookAndFeel = False
        GridControlMovimientos.MainView = GridViewMovimientos
        GridControlMovimientos.Name = "GridControlMovimientos"
        GridControlMovimientos.Size = New Size(576, 855)
        GridControlMovimientos.TabIndex = 6
        GridControlMovimientos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewMovimientos})
        ' 
        ' GridViewMovimientos
        ' 
        GridViewMovimientos.Appearance.Row.Options.UseBackColor = True
        GridViewMovimientos.Appearance.Row.Options.UseForeColor = True
        GridViewMovimientos.Appearance.VertLine.BackColor = Color.Transparent
        GridViewMovimientos.Appearance.VertLine.BorderColor = Color.Transparent
        GridViewMovimientos.Appearance.VertLine.ForeColor = Color.Transparent
        GridViewMovimientos.Appearance.VertLine.Options.UseBackColor = True
        GridViewMovimientos.Appearance.VertLine.Options.UseBorderColor = True
        GridViewMovimientos.Appearance.VertLine.Options.UseForeColor = True
        GridViewMovimientos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {ColumnAcción, ColumnCantidad, ColumnAmmount, ColumnLocation})
        GridViewMovimientos.GridControl = GridControlMovimientos
        GridViewMovimientos.Name = "GridViewMovimientos"
        GridViewMovimientos.OptionsCustomization.AllowGroup = False
        GridViewMovimientos.OptionsView.ShowGroupPanel = False
        GridViewMovimientos.OptionsView.ShowIndicator = False
        ' 
        ' ColumnAcción
        ' 
        ColumnAcción.Caption = "OP"
        ColumnAcción.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        ColumnAcción.FieldName = "Operacion"
        ColumnAcción.MaxWidth = 50
        ColumnAcción.MinWidth = 50
        ColumnAcción.Name = "ColumnAcción"
        ColumnAcción.OptionsColumn.AllowEdit = False
        ColumnAcción.Visible = True
        ColumnAcción.VisibleIndex = 0
        ColumnAcción.Width = 50
        ' 
        ' ColumnCantidad
        ' 
        ColumnCantidad.Caption = "Artículo"
        ColumnCantidad.FieldName = "NombreComercial"
        ColumnCantidad.Name = "ColumnCantidad"
        ColumnCantidad.OptionsColumn.AllowEdit = False
        ColumnCantidad.Visible = True
        ColumnCantidad.VisibleIndex = 2
        ColumnCantidad.Width = 754
        ' 
        ' ColumnAmmount
        ' 
        ColumnAmmount.Caption = "Cantidad"
        ColumnAmmount.FieldName = "Cantidad"
        ColumnAmmount.MaxWidth = 80
        ColumnAmmount.MinWidth = 80
        ColumnAmmount.Name = "ColumnAmmount"
        ColumnAmmount.OptionsColumn.AllowEdit = False
        ColumnAmmount.Visible = True
        ColumnAmmount.VisibleIndex = 3
        ColumnAmmount.Width = 80
        ' 
        ' ColumnLocation
        ' 
        ColumnLocation.Caption = "Ubicación"
        ColumnLocation.FieldName = "Lote"
        ColumnLocation.Name = "ColumnLocation"
        ColumnLocation.OptionsColumn.AllowEdit = False
        ColumnLocation.Visible = True
        ColumnLocation.VisibleIndex = 1
        ColumnLocation.Width = 371
        ' 
        ' frmMovimientosPDA
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(600, 950)
        Controls.Add(GridControlMovimientos)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(0, 80)
        Name = "frmMovimientosPDA"
        StartPosition = FormStartPosition.Manual
        CType(GridControlMovimientos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewMovimientos, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlMovimientos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMovimientos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColumnCantidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnAmmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnAcción As DevExpress.XtraGrid.Columns.GridColumn
End Class
