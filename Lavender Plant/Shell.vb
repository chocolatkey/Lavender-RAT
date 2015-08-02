Public Class CShell
    Dim prc As System.Diagnostics.Process
    Dim read As Boolean = True

    Sub createsession()
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
        Dim read As System.Threading.Thread = New System.Threading.Thread(AddressOf redirect)
        read.IsBackground = True
        read.Start()
    End Sub

    Sub closesession()
        read = False
        prc.Kill()
    End Sub

    Sub redirect()
        Try
            Dim oStreamReader As System.IO.StreamReader
            While read
                While True
                    Dim line As String = ""
                    oStreamReader = prc.StandardOutput
                    line = oStreamReader.ReadLine()
                    If String.IsNullOrEmpty(line) Then
                        Exit While
                    End If
                    ''AppendTextBox(txtoutput, line)
                End While
            End While
        Catch
            createsession()
        End Try
    End Sub
    Private Delegate Sub AppendTextBoxDelegate(ByVal TB As System.Windows.Forms.TextBox, ByVal txt As String)

    Private Sub AppendTextBox(ByVal TB As System.Windows.Forms.TextBox, ByVal txt As String)
        If TB.InvokeRequired Then
            TB.Invoke(New AppendTextBoxDelegate(AddressOf AppendTextBox), New Object() {TB, txt})
        Else
            TB.AppendText(txt & vbNewLine)
        End If
    End Sub
    Sub execute(ByVal code As String)
        If code <> "exit" Then
            prc.StandardInput.WriteLine(code)
            prc.StandardInput.WriteLine()
            prc.StandardInput.Flush()
        Else
            System.Windows.Forms.Application.Exit()
        End If
    End Sub
    'Private Sub txtcommand_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcommand.KeyPress
    '    If e.KeyChar = Microsoft.VisualBasic.ChrW(System.Windows.Forms.Keys.Return) Then
    '        ''execute(txtcommand.Text)
    '        ''txtcommand.Text = ""
    '    End If
    'End Sub
End Class
