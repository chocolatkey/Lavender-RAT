Imports System.Security.Cryptography
Imports LavenderControl.Crypt.RSA
Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Profiles
    Dim profileName As String
    Dim password As String
    Dim aes As New Crypt.Aes256Base64Encrypter
    Private trd As Thread

    Private Sub Keys_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox(Main.pf)
    End Sub

    Private Sub CreateNewKeys()
        Dim Keys As Crypt.Keypair = Crypt.Keypair.CreateNewKeys(4096)
        PrivateKeyTextBox.Text = Keys.Privatekey
        PublicKeyTextBox.Text = Keys.Publickey
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ProgressBarReset(1)
        profileName = InputBox("Please enter a name for the new profile", "New Profile", "")
        If profileName Is "" Then
            ProgressBarReset(0)
            Exit Sub
        End If
        ProgressBar.Increment(1)
        password = InputBox("Please enter a password for the new profile", "New Profile", "")
        If password Is "" Then
            MsgBox("Password error, aborting")
            ProgressBarReset(0)
            Exit Sub
        End If

        ProgressBar.Increment(8)
        StatusLabel.Text = "Generating Keys. Please wait..."

        Me.Refresh()

        CreateNewKeys()


        ProgressBarReset(0)
        ''ProgressBar.Invalidate()
    End Sub

    Sub ProgressBarReset(ByVal e As Integer)
        ProgressBar.Visible = e
        ProgressBar.Value = e
        StatusLabel.Visible = e
        StatusLabel.Text = Nothing
    End Sub

    Private Sub ProfileListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfileListBox.SelectedIndexChanged
        profileName = ProfileListBox.SelectedItem
    End Sub
End Class