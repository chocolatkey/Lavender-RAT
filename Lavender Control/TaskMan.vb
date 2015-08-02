Imports System.Runtime.InteropServices

Public Class TaskMan
    Public sock As Integer
    <DllImport("uxtheme", ExactSpelling:=True, CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(hWnd As IntPtr, textSubAppName As [String], textSubIdList As [String]) As Int32 ''unthemed controls
    End Function

    Private Sub KillProcesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillProcesToolStripMenuItem.Click
        Dim allprocess As String = ""
        For Each item As ListViewItem In ListView1.SelectedItems
            allprocess += (item.Text & "ProcessSplit")
        Next
        Main.S.Send(sock, "KillProcess" & Main.Sep & allprocess)
        RefreshButton.PerformClick()
    End Sub

    Private Sub NewButton_Click(sender As Object, e As EventArgs) Handles NewButton.Click
        Dim a As String
        a = InputBox("Enter Path", "New Process")
        If a <> "" Then
            Main.S.Send(sock, "Execute" & Main.Sep & a)
        End If
    End Sub

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        clearwait()
        Main.S.Send(sock, "GetProcesses")
    End Sub

    Private Sub KillButton_Click(sender As Object, e As EventArgs) Handles KillButton.Click
        KillProcesToolStripMenuItem.PerformClick()
    End Sub

    Public Sub clearwait()
        ListView1.Items.Clear()
        ListView1.Items.Add("Waiting for response...").Group = ListView1.Groups(0)
        NewButton.Enabled = False
        KillButton.Enabled = False
    End Sub

    Public Sub donewait()
        NewButton.Enabled = True
        KillButton.Enabled = True
    End Sub

    Private Sub TaskMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetWindowTheme(RAMVPB.Handle, "", "")
        SetWindowTheme(CPUVPB.Handle, "", "")
    End Sub
End Class