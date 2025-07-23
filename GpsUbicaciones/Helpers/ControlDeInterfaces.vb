Imports DevExpress.XtraEditors

Module ControlDeInterfaces
    ''' <summary>
    ''' Configura un SpinEdit para aceptar decimales sin modificar su valor actual
    ''' </summary>
    ''' <param name="Control">El control SpinEdit a configurar</param>
    ''' <param name="Valor">True si debe aceptar decimales, False para solo enteros</param>
    ''' <param name="mostrarLabel">Control opcional para mostrar icono de peso</param>
    Public Sub AceptarDecimales(Control As SpinEdit, Valor As Boolean, Optional mostrarLabel As Control = Nothing)
        ' Preservar el valor actual antes de cualquier cambio
        Dim valorActual = Control.Value

        With Control.Properties
            .Mask.UseMaskAsDisplayFormat = True
            .MinValue = 0
            .MaxValue = Decimal.MaxValue

            If Valor Then
                .IsFloatValue = True
                .EditMask = $"N{nDecUds}"
                .Increment = 0.1
                If mostrarLabel IsNot Nothing Then
                    mostrarLabel.Visible = True
                End If
            Else
                .IsFloatValue = False
                .EditMask = "d"
                .Increment = 1
                If mostrarLabel IsNot Nothing Then
                    mostrarLabel.Visible = False
                End If
            End If
        End With

        ' Restaurar el valor preservado
        Control.Value = valorActual
    End Sub

    Public Sub PermitirEdicion(control As Control, permitir As Boolean, Optional ActivarFoco As Boolean = True)
        If control IsNot Nothing Then
            control.Enabled = permitir
            If permitir AndAlso ActivarFoco Then control.Focus()
        End If
    End Sub

    Public Sub BuscarUltimoFoco(ByRef LastFocus As Control, ParamArray controls As Control())
        For Each control As Control In controls
            If control.Text = String.Empty OrElse control.Text = "" Then
                control.Focus()
                Exit Sub
            End If
        Next

        LastFocus.Focus()
    End Sub
End Module