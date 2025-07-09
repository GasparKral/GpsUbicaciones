<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtilidades
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
        ResetTable = New DevExpress.XtraEditors.SimpleButton()
        ButtonVisualizeTable = New DevExpress.XtraEditors.SimpleButton()
        ButtonLocation = New DevExpress.XtraEditors.SimpleButton()
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
        btnSalir.Location = New Point(437, 822)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 4
        btnSalir.Text = "Volver"
        ' 
        ' ResetTable
        ' 
        ResetTable.Appearance.Font = New Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ResetTable.Appearance.Options.UseFont = True
        ResetTable.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        ResetTable.ImageOptions.SvgImage = My.Resources.Resources.resetview
        ResetTable.ImageOptions.SvgImageSize = New Size(60, 60)
        ResetTable.Location = New Point(12, 611)
        ResetTable.Name = "ResetTable"
        ResetTable.Size = New Size(576, 198)
        ResetTable.TabIndex = 5
        ResetTable.Text = "Reiniciar Tabla MovPDA"
        ' 
        ' ButtonVisualizeTable
        ' 
        ButtonVisualizeTable.Appearance.Font = New Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonVisualizeTable.Appearance.Options.UseFont = True
        ButtonVisualizeTable.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        ButtonVisualizeTable.ImageOptions.SvgImage = My.Resources.Resources.about
        ButtonVisualizeTable.ImageOptions.SvgImageSize = New Size(60, 60)
        ButtonVisualizeTable.Location = New Point(12, 407)
        ButtonVisualizeTable.Name = "ButtonVisualizeTable"
        ButtonVisualizeTable.Size = New Size(576, 198)
        ButtonVisualizeTable.TabIndex = 6
        ButtonVisualizeTable.Text = "Visualizar Tabla MovPDA"
        ' 
        ' ButtonLocation
        ' 
        ButtonLocation.Appearance.Font = New Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonLocation.Appearance.Options.UseFont = True
        ButtonLocation.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        ButtonLocation.ImageOptions.SvgImage = My.Resources.Resources.customerquicklocations
        ButtonLocation.ImageOptions.SvgImageSize = New Size(60, 60)
        ButtonLocation.Location = New Point(12, 203)
        ButtonLocation.Name = "ButtonLocation"
        ButtonLocation.Size = New Size(576, 198)
        ButtonLocation.TabIndex = 7
        ButtonLocation.Text = "Visualizar Posición "
        ' 
        ' frmUtilidades
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(600, 900)
        Controls.Add(ButtonLocation)
        Controls.Add(ButtonVisualizeTable)
        Controls.Add(ResetTable)
        Controls.Add(btnSalir)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.None
        Location = New Point(0, 80)
        Name = "frmUtilidades"
        StartPosition = FormStartPosition.Manual
        Text = "frmUtilidades"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ResetTable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonVisualizeTable As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonLocation As DevExpress.XtraEditors.SimpleButton
End Class
