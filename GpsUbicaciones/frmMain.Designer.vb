<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        btnAsignar = New DevExpress.XtraEditors.SimpleButton()
        btnTrasladarArticulos = New DevExpress.XtraEditors.SimpleButton()
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        btnSeleccionArticulos = New DevExpress.XtraEditors.SimpleButton()
        btnVenta = New DevExpress.XtraEditors.SimpleButton()
        lblTerminal = New Label()
        lblEmpresa = New Label()
        lblAlmacen = New Label()
        PictureBox1 = New PictureBox()
        btnUtilidades = New DevExpress.XtraEditors.SimpleButton()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnAsignar
        ' 
        btnAsignar.Appearance.Font = CType(resources.GetObject("btnAsignar.Appearance.Font"), Font)
        btnAsignar.Appearance.Options.UseFont = True
        btnAsignar.ImageOptions.Image = CType(resources.GetObject("btnAsignar.ImageOptions.Image"), Image)
        btnAsignar.ImageOptions.ImageToTextIndent = 0
        resources.ApplyResources(btnAsignar, "btnAsignar")
        btnAsignar.Name = "btnAsignar"
        ' 
        ' btnTrasladarArticulos
        ' 
        btnTrasladarArticulos.Appearance.Font = CType(resources.GetObject("btnTrasladarArticulos.Appearance.Font"), Font)
        btnTrasladarArticulos.Appearance.Options.UseFont = True
        btnTrasladarArticulos.ImageOptions.Image = CType(resources.GetObject("btnTrasladarArticulos.ImageOptions.Image"), Image)
        resources.ApplyResources(btnTrasladarArticulos, "btnTrasladarArticulos")
        btnTrasladarArticulos.Name = "btnTrasladarArticulos"
        ' 
        ' btnSalir
        ' 
        btnSalir.Appearance.Font = CType(resources.GetObject("btnSalir.Appearance.Font"), Font)
        btnSalir.Appearance.Options.UseFont = True
        resources.ApplyResources(btnSalir, "btnSalir")
        btnSalir.ImageOptions.Image = CType(resources.GetObject("btnSalir.ImageOptions.Image"), Image)
        btnSalir.Name = "btnSalir"
        ' 
        ' btnSeleccionArticulos
        ' 
        btnSeleccionArticulos.Appearance.Font = CType(resources.GetObject("btnSeleccionArticulos.Appearance.Font"), Font)
        btnSeleccionArticulos.Appearance.Options.UseFont = True
        btnSeleccionArticulos.ImageOptions.Image = CType(resources.GetObject("btnSeleccionArticulos.ImageOptions.Image"), Image)
        btnSeleccionArticulos.ImageOptions.ImageToTextIndent = 0
        resources.ApplyResources(btnSeleccionArticulos, "btnSeleccionArticulos")
        btnSeleccionArticulos.Name = "btnSeleccionArticulos"
        ' 
        ' btnVenta
        ' 
        btnVenta.Appearance.Font = CType(resources.GetObject("btnVenta.Appearance.Font"), Font)
        btnVenta.Appearance.Options.UseFont = True
        btnVenta.ImageOptions.Image = CType(resources.GetObject("btnVenta.ImageOptions.Image"), Image)
        btnVenta.ImageOptions.ImageToTextIndent = 0
        resources.ApplyResources(btnVenta, "btnVenta")
        btnVenta.Name = "btnVenta"
        ' 
        ' lblTerminal
        ' 
        lblTerminal.BackColor = Color.Transparent
        resources.ApplyResources(lblTerminal, "lblTerminal")
        lblTerminal.ForeColor = Color.Blue
        lblTerminal.Name = "lblTerminal"
        ' 
        ' lblEmpresa
        ' 
        lblEmpresa.BackColor = Color.Transparent
        resources.ApplyResources(lblEmpresa, "lblEmpresa")
        lblEmpresa.ForeColor = Color.Blue
        lblEmpresa.Name = "lblEmpresa"
        ' 
        ' lblAlmacen
        ' 
        lblAlmacen.BackColor = Color.Transparent
        resources.ApplyResources(lblAlmacen, "lblAlmacen")
        lblAlmacen.ForeColor = Color.Blue
        lblAlmacen.Name = "lblAlmacen"
        ' 
        ' PictureBox1
        ' 
        resources.ApplyResources(PictureBox1, "PictureBox1")
        PictureBox1.Name = "PictureBox1"
        PictureBox1.TabStop = False
        ' 
        ' btnUtilidades
        ' 
        btnUtilidades.Appearance.Font = CType(resources.GetObject("btnUtilidades.Appearance.Font"), Font)
        btnUtilidades.Appearance.Options.UseFont = True
        btnUtilidades.ImageOptions.Image = CType(resources.GetObject("btnUtilidades.ImageOptions.Image"), Image)
        btnUtilidades.ImageOptions.ImageToTextIndent = 0
        resources.ApplyResources(btnUtilidades, "btnUtilidades")
        btnUtilidades.Name = "btnUtilidades"
        ' 
        ' frmMain
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Silver
        ControlBox = False
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
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMain"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnAsignar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTrasladarArticulos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSeleccionArticulos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnVenta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTerminal As Label
    Friend WithEvents lblEmpresa As Label
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnUtilidades As DevExpress.XtraEditors.SimpleButton
End Class
