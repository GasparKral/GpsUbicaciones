<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainClean
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
        btnUtilidades = New DevExpress.XtraEditors.SimpleButton()
        PictureBox1 = New PictureBox()
        lblAlmacen = New Label()
        lblEmpresa = New Label()
        lblTerminal = New Label()
        btnVenta = New DevExpress.XtraEditors.SimpleButton()
        btnSeleccionArticulos = New DevExpress.XtraEditors.SimpleButton()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        btnTrasladarArticulos = New DevExpress.XtraEditors.SimpleButton()
        btnAsignar = New DevExpress.XtraEditors.SimpleButton()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnUtilidades
        ' 
        btnUtilidades.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnUtilidades.Appearance.Options.UseFont = True
        btnUtilidades.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnUtilidades.ImageOptions.ImageToTextIndent = 0
        btnUtilidades.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnUtilidades.ImageOptions.SvgImage = My.Resources.Resources.actions_options
        btnUtilidades.ImageOptions.SvgImageSize = New Size(60, 60)
        btnUtilidades.Location = New Point(61, 537)
        btnUtilidades.Margin = New Padding(3, 2, 3, 2)
        btnUtilidades.Name = "btnUtilidades"
        btnUtilidades.Size = New Size(462, 112)
        btnUtilidades.TabIndex = 20
        btnUtilidades.Text = "Utilidades"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        PictureBox1.Image = My.Resources.Resources.LOGO_3D
        PictureBox1.ImeMode = ImeMode.NoControl
        PictureBox1.Location = New Point(488, 828)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(100, 57)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 19
        PictureBox1.TabStop = False
        ' 
        ' lblAlmacen
        ' 
        lblAlmacen.BackColor = Color.Transparent
        lblAlmacen.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold Or FontStyle.Italic)
        lblAlmacen.ForeColor = Color.Blue
        lblAlmacen.ImeMode = ImeMode.NoControl
        lblAlmacen.Location = New Point(368, 800)
        lblAlmacen.Name = "lblAlmacen"
        lblAlmacen.Size = New Size(220, 31)
        lblAlmacen.TabIndex = 18
        lblAlmacen.Text = "Almacén"
        ' 
        ' lblEmpresa
        ' 
        lblEmpresa.BackColor = Color.Transparent
        lblEmpresa.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold Or FontStyle.Italic)
        lblEmpresa.ForeColor = Color.Blue
        lblEmpresa.ImeMode = ImeMode.NoControl
        lblEmpresa.Location = New Point(183, 800)
        lblEmpresa.Name = "lblEmpresa"
        lblEmpresa.Size = New Size(179, 31)
        lblEmpresa.TabIndex = 17
        lblEmpresa.Text = "Empresa"
        ' 
        ' lblTerminal
        ' 
        lblTerminal.BackColor = Color.Transparent
        lblTerminal.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold Or FontStyle.Italic)
        lblTerminal.ForeColor = Color.Blue
        lblTerminal.ImeMode = ImeMode.NoControl
        lblTerminal.Location = New Point(178, 850)
        lblTerminal.Name = "lblTerminal"
        lblTerminal.Size = New Size(304, 31)
        lblTerminal.TabIndex = 16
        lblTerminal.Text = "Nombre Terminal"
        ' 
        ' btnVenta
        ' 
        btnVenta.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnVenta.Appearance.Options.UseFont = True
        btnVenta.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnVenta.ImageOptions.ImageToTextIndent = 0
        btnVenta.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnVenta.ImageOptions.SvgImage = My.Resources.Resources.bo_sale
        btnVenta.ImageOptions.SvgImageSize = New Size(60, 60)
        btnVenta.Location = New Point(61, 407)
        btnVenta.Margin = New Padding(3, 2, 3, 2)
        btnVenta.Name = "btnVenta"
        btnVenta.Size = New Size(462, 112)
        btnVenta.TabIndex = 15
        btnVenta.Text = " Selección Venta"
        ' 
        ' btnSeleccionArticulos
        ' 
        btnSeleccionArticulos.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnSeleccionArticulos.Appearance.Options.UseFont = True
        btnSeleccionArticulos.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnSeleccionArticulos.ImageOptions.ImageToTextIndent = 0
        btnSeleccionArticulos.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnSeleccionArticulos.ImageOptions.SvgImage = My.Resources.Resources.tasks
        btnSeleccionArticulos.ImageOptions.SvgImageSize = New Size(60, 60)
        btnSeleccionArticulos.Location = New Point(61, 275)
        btnSeleccionArticulos.Margin = New Padding(3, 2, 3, 2)
        btnSeleccionArticulos.Name = "btnSeleccionArticulos"
        btnSeleccionArticulos.Size = New Size(462, 112)
        btnSeleccionArticulos.TabIndex = 14
        btnSeleccionArticulos.Text = "  Selección Artículos"
        ' 
        ' btnSalir
        ' 
        btnSalir.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnSalir.Appearance.Options.UseFont = True
        btnSalir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter
        btnSalir.ImageOptions.SvgImage = My.Resources.Resources.SignOut
        btnSalir.Location = New Point(12, 788)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(160, 93)
        btnSalir.TabIndex = 13
        btnSalir.Text = "Salir"
        ' 
        ' btnTrasladarArticulos
        ' 
        btnTrasladarArticulos.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnTrasladarArticulos.Appearance.Options.UseFont = True
        btnTrasladarArticulos.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnTrasladarArticulos.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnTrasladarArticulos.ImageOptions.SvgImage = My.Resources.Resources.bo_order
        btnTrasladarArticulos.ImageOptions.SvgImageSize = New Size(60, 60)
        btnTrasladarArticulos.Location = New Point(61, 144)
        btnTrasladarArticulos.Margin = New Padding(3, 2, 3, 2)
        btnTrasladarArticulos.Name = "btnTrasladarArticulos"
        btnTrasladarArticulos.Size = New Size(462, 112)
        btnTrasladarArticulos.TabIndex = 12
        btnTrasladarArticulos.Text = "Trasladar Artículos"
        ' 
        ' btnAsignar
        ' 
        btnAsignar.Appearance.Font = New Font("Tahoma", 15.75F, FontStyle.Bold)
        btnAsignar.Appearance.Options.UseFont = True
        btnAsignar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        btnAsignar.ImageOptions.ImageToTextIndent = 0
        btnAsignar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        btnAsignar.ImageOptions.SvgImage = My.Resources.Resources.bo_document
        btnAsignar.ImageOptions.SvgImageSize = New Size(60, 60)
        btnAsignar.Location = New Point(61, 16)
        btnAsignar.Margin = New Padding(3, 2, 3, 2)
        btnAsignar.Name = "btnAsignar"
        btnAsignar.Size = New Size(462, 112)
        btnAsignar.TabIndex = 11
        btnAsignar.Text = " Asignar Ubicación"
        ' 
        ' frmMainClean
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(600, 900)
        Controls.Add(btnUtilidades)
        Controls.Add(PictureBox1)
        Controls.Add(lblAlmacen)
        Controls.Add(lblEmpresa)
        Controls.Add(lblTerminal)
        Controls.Add(btnVenta)
        Controls.Add(btnSeleccionArticulos)
        Controls.Add(btnSalir)
        Controls.Add(btnTrasladarArticulos)
        Controls.Add(btnAsignar)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(0, 80)
        Name = "frmMainClean"
        StartPosition = FormStartPosition.Manual
        Text = "frmMainClean"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnUtilidades As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents lblTerminal As Label
    Friend WithEvents btnVenta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSeleccionArticulos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTrasladarArticulos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAsignar As DevExpress.XtraEditors.SimpleButton
End Class
