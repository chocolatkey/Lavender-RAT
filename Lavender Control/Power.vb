Public Class Power
    Public sock As Integer

#Region "Power Buttons"
    Private Sub ShutdownButton_Click(sender As Object, e As EventArgs) Handles ShutdownButton.Click
        Main.S.Send(sock, Main.n.shutdown & Main.Sep & vars())
    End Sub

    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click
        Main.S.Send(sock, Main.n.restart & Main.Sep & vars())
    End Sub

    Private Sub SleepButton_Click(sender As Object, e As EventArgs) Handles SleepButton.Click
        Main.S.Send(sock, Main.n.sleep)
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        Main.S.Send(sock, Main.n.logoff)
    End Sub

    Private Sub LockButton_Click(sender As Object, e As EventArgs) Handles LockButton.Click
        Main.S.Send(sock, Main.n.lock)
    End Sub

    Private Sub AbortButton_Click(sender As Object, e As EventArgs) Handles AbortButton.Click
        Main.S.Send(sock, Main.n.abort)
    End Sub
#End Region

    ''' <summary>
    ''' Recompute Time
    ''' </summary>
    ''' <param name="t">Dateime for action</param>
    Sub RecomputeTime(ByVal t As Date)
        DatePicker.Value = t
        SecondsTextBox.Text = Math.Round(t.Subtract(Date.Now).TotalSeconds, 0)
    End Sub

    Function vars() As String
        If Not NowCheckBox.Checked Then
            Return "-t " & SecondsTextBox.Text
        ElseIf ForceCheckBox.Checked
            Return "-f"
        End If
    End Function

    Private Sub Power_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DatePicker.Value = Date.Now
        RecomputeTime(DatePicker.Value)
    End Sub

    Private Sub SecondsTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SecondsTextBox.KeyPress
        ''https://stackoverflow.com/questions/9969824/vb-net-need-text-box-to-only-accept-numbers
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DatePicker_ValueChanged(sender As Object, e As EventArgs) Handles DatePicker.ValueChanged
        RecomputeTime(DatePicker.Value)
    End Sub

    Private Sub SecondsTextBox_TextChanged(sender As Object, e As EventArgs) Handles SecondsTextBox.TextChanged
        If Not SecondsTextBox.Text = "" Then
            RecomputeTime(Date.Now.AddSeconds(Double.Parse(SecondsTextBox.Text)))
        End If
    End Sub

    Private Sub NowCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles NowCheckBox.CheckedChanged
        SecondsTextBox.Enabled = Not NowCheckBox.Checked
        DatePicker.Enabled = Not NowCheckBox.Checked
    End Sub
End Class