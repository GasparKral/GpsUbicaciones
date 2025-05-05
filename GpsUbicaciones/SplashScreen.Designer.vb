<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreen
    Inherits DevExpress.XtraSplashScreen.SplashScreen

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        peImage = New DevExpress.XtraEditors.PictureEdit()
        peLogo = New DevExpress.XtraEditors.PictureEdit()
        labelStatus = New DevExpress.XtraEditors.LabelControl()
        labelCopyright = New DevExpress.XtraEditors.LabelControl()
        progressBarControl = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        CType(peImage.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(peLogo.Properties, ComponentModel.ISupportInitialize).BeginInit()
        CType(progressBarControl.Properties, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' peImage
        ' 
        peImage.Dock = DockStyle.Top
        peImage.EditValue = resources.GetObject("peImage.EditValue")
        peImage.Location = New Point(1, 1)
        peImage.Name = "peImage"
        peImage.Properties.AllowFocused = False
        peImage.Properties.Appearance.BackColor = Color.Transparent
        peImage.Properties.Appearance.Options.UseBackColor = True
        peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        peImage.Properties.ShowMenu = False
        peImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        peImage.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        peImage.Size = New Size(448, 200)
        peImage.TabIndex = 14
        ' 
        ' peLogo
        ' 
        peLogo.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        peLogo.Location = New Point(279, 267)
        peLogo.Name = "peLogo"
        peLogo.Properties.AllowFocused = False
        peLogo.Properties.Appearance.BackColor = Color.Transparent
        peLogo.Properties.Appearance.Options.UseBackColor = True
        peLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        peLogo.Properties.ShowMenu = False
        peLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        peLogo.Size = New Size(158, 48)
        peLogo.TabIndex = 13
        ' 
        ' labelStatus
        ' 
        labelStatus.Location = New Point(24, 215)
        labelStatus.Margin = New Padding(3, 3, 3, 1)
        labelStatus.Name = "labelStatus"
        labelStatus.Size = New Size(43, 13)
        labelStatus.TabIndex = 12
        labelStatus.Text = "Iniciando..."
        ' 
        ' labelCopyright
        ' 
        labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        labelCopyright.Location = New Point(24, 287)
        labelCopyright.Name = "labelCopyright"
        labelCopyright.Size = New Size(150, 13)
        labelCopyright.TabIndex = 11
        labelCopyright.Text = "Gabinete de Proyectos Software SL"
        ' 
        ' progressBarControl
        ' 
        progressBarControl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        progressBarControl.EditValue = 0
        progressBarControl.Location = New Point(24, 232)
        progressBarControl.Name = "progressBarControl"
        progressBarControl.Size = New Size(402, 12)
        progressBarControl.TabIndex = 10
        ' 
        ' SplashScreen
        ' 
        AutoScaleDimensions = New SizeF(6F, 13F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(450, 320)
        Controls.Add(peImage)
        Controls.Add(peLogo)
        Controls.Add(labelStatus)
        Controls.Add(labelCopyright)
        Controls.Add(progressBarControl)
        Name = "SplashScreen"
        Padding = New Padding(1)
        Text = "SplashScreen"
        CType(peImage.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(peLogo.Properties, ComponentModel.ISupportInitialize).EndInit()
        CType(progressBarControl.Properties, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private WithEvents peImage As DevExpress.XtraEditors.PictureEdit
    Private WithEvents peLogo As DevExpress.XtraEditors.PictureEdit
    Private WithEvents labelStatus As DevExpress.XtraEditors.LabelControl
    Private WithEvents labelCopyright As DevExpress.XtraEditors.LabelControl
    Private WithEvents progressBarControl As DevExpress.XtraEditors.MarqueeProgressBarControl
End Class
