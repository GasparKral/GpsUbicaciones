Imports DevExpress.XtraEditors

Module ControlDeInterfaces
    Public Sub AceptarDecimales(Control As SpinEdit, Valor As Boolean, Optional mostrarLabel As Control = Nothing)
        Control.Properties.Mask.UseMaskAsDisplayFormat = True
        Control.Properties.MinValue = 0.00
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

    Public Sub PermitirEdicion(control As Control, permitir As Boolean, Optional ActivarFoco As Boolean = True)
        If control IsNot Nothing Then
            control.Enabled = permitir
            If permitir AndAlso ActivarFoco Then control.Focus()
        End If
    End Sub
End Module
