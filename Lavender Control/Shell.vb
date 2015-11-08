Public Class Shell
    Public cli As Client

    Private Sub CommandTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CommandTextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Return) Then
            Main.S.Send(cli, Main.n.putshell & Main.Sep & CommandTextBox.Text)
            CommandTextBox.Text = ""
        End If
    End Sub

    Private Sub Shell_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.S.Send(cli, Main.n.endshell)
    End Sub

    Private Sub Shell_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CommandTextBox.Focus()
    End Sub
End Class