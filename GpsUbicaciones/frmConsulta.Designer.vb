<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsulta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsulta))
        btnSalir = New DevExpress.XtraEditors.SimpleButton()
        GridControlConsultaArticulos = New DevExpress.XtraGrid.GridControl()
        GridViewConsultaArticulos = New DevExpress.XtraGrid.Views.Grid.GridView()
        PanelTitulo = New Panel()
        LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        lblTitulo = New Label()
        LabelUbicaciónConsultada = New DevExpress.XtraEditors.LabelControl()
        CType(GridControlConsultaArticulos, ComponentModel.ISupportInitialize).BeginInit()
        CType(GridViewConsultaArticulos, ComponentModel.ISupportInitialize).BeginInit()
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
        btnSalir.ImageOptions.Image = CType(resources.GetObject("btnSalir.ImageOptions.Image"), Image)
        btnSalir.Location = New Point(438, 875)
        btnSalir.Margin = New Padding(3, 2, 3, 2)
        btnSalir.Name = "btnSalir"
        btnSalir.Size = New Size(151, 67)
        btnSalir.TabIndex = 3
        btnSalir.Text = "Salir"
        ' 
        ' GridControlConsultaArticulos
        ' 
        GridControlConsultaArticulos.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        GridControlConsultaArticulos.EmbeddedNavigator.Margin = New Padding(3, 2, 3, 2)
        GridControlConsultaArticulos.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        GridControlConsultaArticulos.Location = New Point(10, 93)
        GridControlConsultaArticulos.MainView = GridViewConsultaArticulos
        GridControlConsultaArticulos.Margin = New Padding(3, 2, 3, 2)
        GridControlConsultaArticulos.Name = "GridControlConsultaArticulos"
        GridControlConsultaArticulos.Size = New Size(579, 778)
        GridControlConsultaArticulos.TabIndex = 7
        GridControlConsultaArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridViewConsultaArticulos})
        ' 
        ' GridViewConsultaArticulos
        ' 
        GridViewConsultaArticulos.DetailHeight = 262
        GridViewConsultaArticulos.GridControl = GridControlConsultaArticulos
        GridViewConsultaArticulos.Name = "GridViewConsultaArticulos"
        GridViewConsultaArticulos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
        GridViewConsultaArticulos.OptionsBehavior.Editable = False
        GridViewConsultaArticulos.OptionsEditForm.PopupEditFormWidth = 700
        GridViewConsultaArticulos.OptionsView.ShowFooter = True
        ' 
        ' PanelTitulo
        ' 
        PanelTitulo.BackColor = Color.RoyalBlue
        PanelTitulo.Controls.Add(LabelControl2)
        PanelTitulo.Controls.Add(lblTitulo)
        PanelTitulo.Dock = DockStyle.Top
        PanelTitulo.Location = New Point(0, 0)
        PanelTitulo.Name = "PanelTitulo"
        PanelTitulo.Size = New Size(600, 48)
        PanelTitulo.TabIndex = 8
        ' 
        ' LabelControl2
        ' 
        LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        LabelControl2.ImageOptions.Image = CType(resources.GetObject("LabelControl2.ImageOptions.Image"), Image)
        LabelControl2.Location = New Point(10, 3)
        LabelControl2.Name = "LabelControl2"
        LabelControl2.Size = New Size(60, 42)
        LabelControl2.TabIndex = 2
        ' 
        ' lblTitulo
        ' 
        lblTitulo.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitulo.ForeColor = Color.White
        lblTitulo.ImageAlign = ContentAlignment.MiddleLeft
        lblTitulo.Location = New Point(201, 9)
        lblTitulo.Name = "lblTitulo"
        lblTitulo.Size = New Size(387, 30)
        lblTitulo.TabIndex = 1
        lblTitulo.Text = "Consulta Datos"
        lblTitulo.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' LabelUbicaciónConsultada
        ' 
        LabelUbicaciónConsultada.Appearance.Font = New Font("Tahoma", 15.75F)
        LabelUbicaciónConsultada.Appearance.Options.UseFont = True
        LabelUbicaciónConsultada.Location = New Point(12, 63)
        LabelUbicaciónConsultada.Name = "LabelUbicaciónConsultada"
        LabelUbicaciónConsultada.Size = New Size(200, 25)
        LabelUbicaciónConsultada.TabIndex = 9
        LabelUbicaciónConsultada.Text = "Ubicación Consultada"
        ' 
        ' frmConsulta
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightBlue
        ClientSize = New Size(600, 950)
        ControlBox = False
        Controls.Add(LabelUbicaciónConsultada)
        Controls.Add(PanelTitulo)
        Controls.Add(GridControlConsultaArticulos)
        Controls.Add(btnSalir)
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Location = New Point(0, 80)
        Margin = New Padding(3, 2, 3, 2)
        MinimumSize = New Size(600, 900)
        Name = "frmConsulta"
        StartPosition = FormStartPosition.Manual
        CType(GridControlConsultaArticulos, ComponentModel.ISupportInitialize).EndInit()
        CType(GridViewConsultaArticulos, ComponentModel.ISupportInitialize).EndInit()
        PanelTitulo.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlConsultaArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewConsultaArticulos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelUbicaciónConsultada As DevExpress.XtraEditors.LabelControl
End Class
