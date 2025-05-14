Imports DevExpress.XtraEditors

Module ControlDeInterfaces
    Public Sub AceptarDecimales(Control As SpinEdit, Valor As Boolean, Optional mostrarLabel As Label = Nothing)
        Control.Properties.Mask.UseMaskAsDisplayFormat = True
        If Valor Then
            Control.Properties.IsFloatValue = True
            Control.Properties.EditMask = $"N{nDecUds}"
            Control.Properties.Increment = 0.1
            If mostrarLabel IsNot Nothing Then
                mostrarLabel.Visible = True
            End If
        Else
            Control.Properties.IsFloatValue = False
            Control.Properties.EditMask = "d"
            Control.Properties.Increment = 1
            If mostrarLabel IsNot Nothing Then
                mostrarLabel.Visible = False
            End If
        End If
    End Sub

    Public Sub PermitirEdicion(campo As Control, estado As Boolean)
        campo.Enabled = estado
    End Sub
End Module
