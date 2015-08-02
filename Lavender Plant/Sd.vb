
#Region "License"
' Desktop 1.1
'																																							*
' Copyright (C) 2004  http://www.onyeyiri.co.uk
' Coded by: Nnamdi Onyeyiri
'
' This code may be used in any way you desire except for commercial use.
' The code can be freely redistributed unmodified as long as all of the authors 
' copyright notices remain intact, as long as it is not being sold for profit.
' Although I have tried to ensure the stability of the code, I will not take 
' responsibility for any loss, damages, or death it may cause.
'
' This software is provided "as is" without any expressed or implied warranty.
'
' -------------------------
' Change Log
'
' Version 1.0:  -First Release
'
' Version 1.1:  -Added Window and WindowCollection classes
' 6/6/2004      -Added another GetWindows overload, that used WindowCollection
'               -Added GetInputProcesses method to retrieve processes on Input desktop
'               -Changed GetWindows and GetDesktops to return arrays, instead of them being passed by ref
'
' Version 1.2   -Implemented IDisposable
' 8/7/2004      -Implemented ICloneable
'               -Overrided ToString to return desktop name
#End Region

Imports System.Threading
Imports System.Collections
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Collections.Specialized

''' <summary>
''' Encapsulates the Desktop API.
''' </summary>
Public Class Desktop
    Implements IDisposable
    Implements ICloneable
#Region "Imports"
    <DllImport("kernel32.dll")> _
    Private Shared Function GetThreadId(thread As IntPtr) As Integer
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function GetProcessId(process As IntPtr) As Integer
    End Function

    '
    ' Imported winAPI functions.
    '
    <DllImport("user32.dll")> _
    Private Shared Function CreateDesktop(lpszDesktop As String, lpszDevice As IntPtr, pDevmode As IntPtr, dwFlags As Integer, dwDesiredAccess As Long, lpsa As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function CloseDesktop(hDesktop As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function OpenDesktop(lpszDesktop As String, dwFlags As Integer, fInherit As Boolean, dwDesiredAccess As Long) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function OpenInputDesktop(dwFlags As Integer, fInherit As Boolean, dwDesiredAccess As Long) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function SwitchDesktop(hDesktop As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function EnumDesktops(hwinsta As IntPtr, lpEnumFunc As EnumDesktopProc, lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetProcessWindowStation() As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function EnumDesktopWindows(hDesktop As IntPtr, lpfn As EnumDesktopWindowsProc, lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function SetThreadDesktop(hDesktop As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetThreadDesktop(dwThreadId As Integer) As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetUserObjectInformation(hObj As IntPtr, nIndex As Integer, pvInfo As IntPtr, nLength As Integer, ByRef lpnLengthNeeded As Integer) As Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function CreateProcess(lpApplicationName As String, lpCommandLine As String, lpProcessAttributes As IntPtr, lpThreadAttributes As IntPtr, bInheritHandles As Boolean, dwCreationFlags As Integer, _
            lpEnvironment As IntPtr, lpCurrentDirectory As String, ByRef lpStartupInfo As STARTUPINFO, ByRef lpProcessInformation As PROCESS_INFORMATION) As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function GetWindowText(hWnd As IntPtr, lpString As IntPtr, nMaxCount As Integer) As Integer
    End Function

    Private Delegate Function EnumDesktopProc(lpszDesktop As String, lParam As IntPtr) As Boolean
    Private Delegate Function EnumDesktopWindowsProc(desktopHandle As IntPtr, lParam As IntPtr) As Boolean

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure PROCESS_INFORMATION
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public dwProcessId As Integer
        Public dwThreadId As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure STARTUPINFO
        Public cb As Integer
        Public lpReserved As String
        Public lpDesktop As String
        Public lpTitle As String
        Public dwX As Integer
        Public dwY As Integer
        Public dwXSize As Integer
        Public dwYSize As Integer
        Public dwXCountChars As Integer
        Public dwYCountChars As Integer
        Public dwFillAttribute As Integer
        Public dwFlags As Integer
        Public wShowWindow As Short
        Public cbReserved2 As Short
        Public lpReserved2 As IntPtr
        Public hStdInput As IntPtr
        Public hStdOutput As IntPtr
        Public hStdError As IntPtr
    End Structure
#End Region

#Region "Constants"
    ''' <summary>
    ''' Size of buffer used when retrieving window names.
    ''' </summary>
    Public Const MaxWindowNameLength As Integer = 100

    '
    ' winAPI constants.
    '
    Private Const SW_HIDE As Short = 0
    Private Const SW_NORMAL As Short = 1
    Private Const STARTF_USESTDHANDLES As Integer = &H100
    Private Const STARTF_USESHOWWINDOW As Integer = &H1
    Private Const UOI_NAME As Integer = 2
    Private Const STARTF_USEPOSITION As Integer = &H4
    Private Const NORMAL_PRIORITY_CLASS As Integer = &H20
    Private Const DESKTOP_CREATEWINDOW As Long = &H2L
    Private Const DESKTOP_ENUMERATE As Long = &H40L
    Private Const DESKTOP_WRITEOBJECTS As Long = &H80L
    Private Const DESKTOP_SWITCHDESKTOP As Long = &H100L
    Private Const DESKTOP_CREATEMENU As Long = &H4L
    Private Const DESKTOP_HOOKCONTROL As Long = &H8L
    Private Const DESKTOP_READOBJECTS As Long = &H1L
    Private Const DESKTOP_JOURNALRECORD As Long = &H10L
    Private Const DESKTOP_JOURNALPLAYBACK As Long = &H20L
    Private Const AccessRights As Long = DESKTOP_JOURNALRECORD Or DESKTOP_JOURNALPLAYBACK Or DESKTOP_CREATEWINDOW Or DESKTOP_ENUMERATE Or DESKTOP_WRITEOBJECTS Or DESKTOP_SWITCHDESKTOP Or DESKTOP_CREATEMENU Or DESKTOP_HOOKCONTROL Or DESKTOP_READOBJECTS
#End Region

#Region "Structures"
    ''' <summary>
    ''' Stores window handles and titles.
    ''' </summary>
    Public Structure Window
#Region "Private Variables"
        Private m_handle As IntPtr
        Private m_text As String
#End Region

#Region "Public Properties"
        ''' <summary>
        ''' Gets the window handle.
        ''' </summary>
        Public ReadOnly Property Handle() As IntPtr
            Get
                Return m_handle
            End Get
        End Property

        ''' <summary>
        ''' Gets teh window title.
        ''' </summary>
        Public ReadOnly Property Text() As String
            Get
                Return m_text
            End Get
        End Property
#End Region

#Region "Construction"
        ''' <summary>
        ''' Creates a new window object.
        ''' </summary>
        ''' <param name="handle">Window handle.</param>
        ''' <param name="text">Window title.</param>
        Public Sub New(handle As IntPtr, text As String)
            m_handle = handle
            m_text = text
        End Sub
#End Region
    End Structure

    ''' <summary>
    ''' A collection for Window objects.
    ''' </summary>
    Public Class WindowCollection
        Inherits CollectionBase
#Region "Public Properties"
        ''' <summary>
        ''' Gets a window from teh collection.
        ''' </summary>
        Default Public ReadOnly Property Item(index As Integer) As Window
            Get
                Return CType(List(index), Window)
            End Get
        End Property
#End Region

#Region "Methods"
        ''' <summary>
        ''' Adds a window to the collection.
        ''' </summary>
        ''' <param name="wnd">Window to add.</param>
        Public Sub Add(wnd As Window)
            ' adds a widow to the collection.
            List.Add(wnd)
        End Sub
#End Region
    End Class
#End Region

#Region "Private Variables"
    Private m_desktop As IntPtr
    Private m_desktopName As String
    Private Shared m_sc As StringCollection
    Private m_windows As ArrayList
    Private m_disposed As Boolean
#End Region

#Region "Public Properties"
    ''' <summary>
    ''' Gets if a desktop is open.
    ''' </summary>
    Public ReadOnly Property IsOpen() As Boolean
        Get
            Return (m_desktop <> IntPtr.Zero)
        End Get
    End Property

    ''' <summary>
    ''' Gets the name of the desktop, returns null if no desktop is open.
    ''' </summary>
    Public ReadOnly Property DesktopName() As String
        Get
            Return m_desktopName
        End Get
    End Property

    ''' <summary>
    ''' Gets a handle to the desktop, IntPtr.Zero if no desktop open.
    ''' </summary>
    Public ReadOnly Property DesktopHandle() As IntPtr
        Get
            Return m_desktop
        End Get
    End Property

    ''' <summary>
    ''' Opens the default desktop.
    ''' </summary>
    Public Shared ReadOnly [Default] As Desktop = Desktop.OpenDefaultDesktop()

    ''' <summary>
    ''' Opens the desktop the user if viewing.
    ''' </summary>
    Public Shared ReadOnly Input As Desktop = Desktop.OpenInputDesktop()
#End Region

#Region "Construction/Destruction"
    ''' <summary>
    ''' Creates a new Desktop object.
    ''' </summary>
    Public Sub New()
        ' init variables.
        m_desktop = IntPtr.Zero
        m_desktopName = [String].Empty
        m_windows = New ArrayList()
        m_disposed = False
    End Sub

    ' constructor is private to prevent invalid handles being passed to it.
    Private Sub New(desktop__1 As IntPtr)
        ' init variables.
        m_desktop = desktop__1
        m_desktopName = Desktop.GetDesktopName(desktop__1)
        m_windows = New ArrayList()
        m_disposed = False
    End Sub

    Protected Overrides Sub Finalize()
        Try
            ' clean up, close the desktop.
            Close()
        Finally
            MyBase.Finalize()
        End Try
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Creates a new desktop.  If a handle is open, it will be closed.
    ''' </summary>
    ''' <param name="name">The name of the new desktop.  Must be unique, and is case sensitive.</param>
    ''' <returns>True if desktop was successfully created, otherwise false.</returns>
    Public Function Create(name As String) As Boolean
        ' make sure object isnt disposed.
        CheckDisposed()

        ' close the open desktop.
        If m_desktop <> IntPtr.Zero Then
            ' attempt to close the desktop.
            If Not Close() Then
                Return False
            End If
        End If

        ' make sure desktop doesnt already exist.
        If Desktop.Exists(name) Then
            ' it exists, so open it.
            Return Open(name)
        End If

        ' attempt to create desktop.
        m_desktop = CreateDesktop(name, IntPtr.Zero, IntPtr.Zero, 0, AccessRights, IntPtr.Zero)

        m_desktopName = name

        ' something went wrong.
        If m_desktop = IntPtr.Zero Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Closes the handle to a desktop.
    ''' </summary>
    ''' <returns>True if an open handle was successfully closed.</returns>
    Public Function Close() As Boolean
        ' make sure object isnt disposed.
        CheckDisposed()

        ' check there is a desktop open.
        If m_desktop <> IntPtr.Zero Then
            ' close the desktop.
            Dim result As Boolean = CloseDesktop(m_desktop)

            If result Then
                m_desktop = IntPtr.Zero

                m_desktopName = [String].Empty
            End If

            Return result
        End If

        ' no desktop was open, so desktop is closed.
        Return True
    End Function

    ''' <summary>
    ''' Opens a desktop.
    ''' </summary>
    ''' <param name="name">The name of the desktop to open.</param>
    ''' <returns>True if the desktop was successfully opened.</returns>
    Public Function Open(name As String) As Boolean
        ' make sure object isnt disposed.
        CheckDisposed()

        ' close the open desktop.
        If m_desktop <> IntPtr.Zero Then
            ' attempt to close the desktop.
            If Not Close() Then
                Return False
            End If
        End If

        ' open the desktop.
        m_desktop = OpenDesktop(name, 0, True, AccessRights)

        ' something went wrong.
        If m_desktop = IntPtr.Zero Then
            Return False
        End If

        m_desktopName = name

        Return True
    End Function

    ''' <summary>
    ''' Opens the current input desktop.
    ''' </summary>
    ''' <returns>True if the desktop was succesfully opened.</returns>
    Public Function OpenInput() As Boolean
        ' make sure object isnt disposed.
        CheckDisposed()

        ' close the open desktop.
        If m_desktop <> IntPtr.Zero Then
            ' attempt to close the desktop.
            If Not Close() Then
                Return False
            End If
        End If

        ' open the desktop.
        m_desktop = OpenInputDesktop(0, True, AccessRights)

        ' something went wrong.
        If m_desktop = IntPtr.Zero Then
            Return False
        End If

        ' get the desktop name.
        m_desktopName = Desktop.GetDesktopName(m_desktop)

        Return True
    End Function

    ''' <summary>
    ''' Switches input to the currently opened desktop.
    ''' </summary>
    ''' <returns>True if desktops were successfully switched.</returns>
    Public Function Show() As Boolean
        ' make sure object isnt disposed.
        CheckDisposed()

        ' make sure there is a desktop to open.
        If m_desktop = IntPtr.Zero Then
            Return False
        End If

        ' attempt to switch desktops.
        Dim result As Boolean = SwitchDesktop(m_desktop)

        Return result
    End Function

    ''' <summary>
    ''' Enumerates the windows on a desktop.
    ''' </summary>
    ''' <param name="windows">Array of Desktop.Window objects to recieve windows.</param>
    ''' <returns>A window colleciton if successful, otherwise null.</returns>
    Public Function GetWindows() As WindowCollection
        ' make sure object isnt disposed.
        CheckDisposed()

        ' make sure a desktop is open.
        If Not IsOpen Then
            Return Nothing
        End If

        ' init the arraylist.
        m_windows.Clear()
        Dim windows As New WindowCollection()

        ' get windows.
        Dim result As Boolean = EnumDesktopWindows(m_desktop, New EnumDesktopWindowsProc(AddressOf DesktopWindowsProc), IntPtr.Zero)

        ' check for error.
        If Not result Then
            Return Nothing
        End If

        ' get window names.
        windows = New WindowCollection()

        Dim ptr As IntPtr = Marshal.AllocHGlobal(MaxWindowNameLength)

        For Each wnd As IntPtr In m_windows
            GetWindowText(wnd, ptr, MaxWindowNameLength)
            windows.Add(New Window(wnd, Marshal.PtrToStringAnsi(ptr)))
        Next

        Marshal.FreeHGlobal(ptr)

        Return windows
    End Function

    Private Function DesktopWindowsProc(wndHandle As IntPtr, lParam As IntPtr) As Boolean
        ' add window handle to colleciton.
        m_windows.Add(wndHandle)

        Return True
    End Function

    ''' <summary>
    ''' Creates a new process in a desktop.
    ''' </summary>
    ''' <param name="path">Path to application.</param>
    ''' <returns>The process object for the newly created process.</returns>
    Public Function CreateProcess(path As String) As Process
        ' make sure object isnt disposed.
        CheckDisposed()

        ' make sure a desktop is open.
        If Not IsOpen Then
            Return Nothing
        End If

        ' set startup parameters.
        Dim si As New STARTUPINFO()
        si.cb = Marshal.SizeOf(si)
        si.lpDesktop = m_desktopName

        Dim pi As New PROCESS_INFORMATION()

        ' start the process.
        Dim result As Boolean = CreateProcess(Nothing, path, IntPtr.Zero, IntPtr.Zero, True, NORMAL_PRIORITY_CLASS, _
            IntPtr.Zero, Nothing, si, pi)

        ' error?
        If Not result Then
            Return Nothing
        End If

        ' Get the process.
        Return Process.GetProcessById(pi.dwProcessId)
    End Function

    ''' <summary>
    ''' Prepares a desktop for use.  For use only on newly created desktops, call straight after CreateDesktop.
    ''' </summary>
    Public Sub Prepare()
        ' make sure object isnt disposed.
        CheckDisposed()

        ' make sure a desktop is open.
        If IsOpen Then
            ' load explorer.
            CreateProcess("explorer.exe")
        End If
    End Sub
#End Region

#Region "Static Methods"
    ''' <summary>
    ''' Enumerates all of the desktops.
    ''' </summary>
    ''' <param name="desktops">String array to recieve desktop names.</param>
    ''' <returns>True if desktop names were successfully enumerated.</returns>
    Public Shared Function GetDesktops() As String()
        ' attempt to enum desktops.
        Dim windowStation As IntPtr = GetProcessWindowStation()

        ' check we got a valid handle.
        If windowStation = IntPtr.Zero Then
            Return New String(-1) {}
        End If

        Dim desktops As String()

        ' lock the object. thread safety and all.
        SyncLock InlineAssignHelper(m_sc, New StringCollection())
            Dim result As Boolean = EnumDesktops(windowStation, New EnumDesktopProc(AddressOf DesktopProc), IntPtr.Zero)

            ' something went wrong.
            If Not result Then
                Return New String(-1) {}
            End If

            '	// turn the collection into an array.
            desktops = New String(m_sc.Count - 1) {}
            For i As Integer = 0 To desktops.Length - 1
                desktops(i) = m_sc(i)
            Next
        End SyncLock

        Return desktops
    End Function

    Private Shared Function DesktopProc(lpszDesktop As String, lParam As IntPtr) As Boolean
        ' add the desktop to the collection.
        m_sc.Add(lpszDesktop)

        Return True
    End Function

    ''' <summary>
    ''' Switches to the specified desktop.
    ''' </summary>
    ''' <param name="name">Name of desktop to switch input to.</param>
    ''' <returns>True if desktops were successfully switched.</returns>
    Public Shared Function Show(name As String) As Boolean
        ' attmempt to open desktop.
        Dim result As Boolean = False

        Using d As New Desktop()
            result = d.Open(name)

            ' something went wrong.
            If Not result Then
                Return False
            End If

            ' attempt to switch desktops.
            result = d.Show()
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Gets the desktop of the calling thread.
    ''' </summary>
    ''' <returns>Returns a Desktop object for the valling thread.</returns>
    Public Shared Function GetCurrent() As Desktop
        ' get the desktop.
        Return New Desktop(GetThreadDesktop(AppDomain.GetCurrentThreadId()))
    End Function

    ''' <summary>
    ''' Sets the desktop of the calling thread.
    ''' NOTE: Function will fail if thread has hooks or windows in the current desktop.
    ''' </summary>
    ''' <param name="desktop">Desktop to put the thread in.</param>
    ''' <returns>True if the threads desktop was successfully changed.</returns>
    Public Shared Function SetCurrent(desktop As Desktop) As Boolean
        ' set threads desktop.
        If Not desktop.IsOpen Then
            Return False
        End If

        Return SetThreadDesktop(desktop.DesktopHandle)
    End Function

    ''' <summary>
    ''' Opens a desktop.
    ''' </summary>
    ''' <param name="name">The name of the desktop to open.</param>
    ''' <returns>If successful, a Desktop object, otherwise, null.</returns>
    Public Shared Function OpenDesktop(name As String) As Desktop
        ' open the desktop.
        Dim desktop As New Desktop()
        Dim result As Boolean = desktop.Open(name)

        ' somethng went wrong.
        If Not result Then
            Return Nothing
        End If

        Return desktop
    End Function

    ''' <summary>
    ''' Opens the current input desktop.
    ''' </summary>
    ''' <returns>If successful, a Desktop object, otherwise, null.</returns>
    Public Shared Function OpenInputDesktop() As Desktop
        ' open the desktop.
        Dim desktop As New Desktop()
        Dim result As Boolean = desktop.OpenInput()

        ' somethng went wrong.
        If Not result Then
            Return Nothing
        End If

        Return desktop
    End Function

    ''' <summary>
    ''' Opens the default desktop.
    ''' </summary>
    ''' <returns>If successful, a Desktop object, otherwise, null.</returns>
    Public Shared Function OpenDefaultDesktop() As Desktop
        ' opens the default desktop.
        Return Desktop.OpenDesktop("Default")
    End Function

    ''' <summary>
    ''' Creates a new desktop.
    ''' </summary>
    ''' <param name="name">The name of the desktop to create.  Names are case sensitive.</param>
    ''' <returns>If successful, a Desktop object, otherwise, null.</returns>
    Public Shared Function CreateDesktop(name As String) As Desktop
        ' open the desktop.
        Dim desktop As New Desktop()
        Dim result As Boolean = desktop.Create(name)

        ' somethng went wrong.
        If Not result Then
            Return Nothing
        End If

        Return desktop
    End Function

    ''' <summary>
    ''' Gets the name of a given desktop.
    ''' </summary>
    ''' <param name="desktop">Desktop object whos name is to be found.</param>
    ''' <returns>If successful, the desktop name, otherwise, null.</returns>
    Public Shared Function GetDesktopName(desktop As Desktop) As String
        ' get name.
        If desktop.IsOpen Then
            Return Nothing
        End If

        Return GetDesktopName(desktop.DesktopHandle)
    End Function

    ''' <summary>
    ''' Gets the name of a desktop from a desktop handle.
    ''' </summary>
    ''' <param name="desktopHandle"></param>
    ''' <returns>If successful, the desktop name, otherwise, null.</returns>
    Public Shared Function GetDesktopName(desktopHandle As IntPtr) As String
        ' check its not a null pointer.
        ' null pointers wont work.
        If desktopHandle = IntPtr.Zero Then
            Return Nothing
        End If

        ' get the length of the name.
        Dim needed As Integer = 0
        Dim name As String = [String].Empty
        GetUserObjectInformation(desktopHandle, UOI_NAME, IntPtr.Zero, 0, needed)

        ' get the name.
        Dim ptr As IntPtr = Marshal.AllocHGlobal(needed)
        Dim result As Boolean = GetUserObjectInformation(desktopHandle, UOI_NAME, ptr, needed, needed)
        name = Marshal.PtrToStringAnsi(ptr)
        Marshal.FreeHGlobal(ptr)

        ' something went wrong.
        If Not result Then
            Return Nothing
        End If

        Return name
    End Function

    ''' <summary>
    ''' Checks if the specified desktop exists (using a case sensitive search).
    ''' </summary>
    ''' <param name="name">The name of the desktop.</param>
    ''' <returns>True if the desktop exists, otherwise false.</returns>
    Public Shared Function Exists(name As String) As Boolean
        Return Desktop.Exists(name, False)
    End Function

    ''' <summary>
    ''' Checks if the specified desktop exists.
    ''' </summary>
    ''' <param name="name">The name of the desktop.</param>
    ''' <param name="caseInsensitive">If the search is case INsensitive.</param>
    ''' <returns>True if the desktop exists, otherwise false.</returns>
    Public Shared Function Exists(name As String, caseInsensitive As Boolean) As Boolean
        ' enumerate desktops.
        Dim desktops As String() = Desktop.GetDesktops()

        ' return true if desktop exists.
        For Each desktop__1 As String In desktops
            If caseInsensitive Then
                ' case insensitive, compare all in lower case.
                If desktop__1.ToLower() = name.ToLower() Then
                    Return True
                End If
            Else
                If desktop__1 = name Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Creates a new process on the specified desktop.
    ''' </summary>
    ''' <param name="path">Path to application.</param>
    ''' <param name="desktop">Desktop name.</param>
    ''' <returns>A Process object for the newly created process, otherwise, null.</returns>
    Public Shared Function CreateProcess(path As String, desktop__1 As String) As Process
        If Not Desktop.Exists(desktop__1) Then
            Return Nothing
        End If

        ' create the process.
        Dim d As Desktop = Desktop.OpenDesktop(desktop__1)
        Return d.CreateProcess(path)
    End Function

    ''' <summary>
    ''' Gets an array of all the processes running on the Input desktop.
    ''' </summary>
    ''' <returns>An array of the processes.</returns>
    Public Shared Function GetInputProcesses() As Process()
        ' get all processes.
        Dim processes As Process() = Process.GetProcesses()

        Dim m_procs As New ArrayList()

        ' get the current desktop name.
        Dim currentDesktop As String = GetDesktopName(Desktop.Input.DesktopHandle)

        ' cycle through the processes.
        For Each process__1 As Process In processes
            ' check the threads of the process - are they in this one?
            For Each pt As ProcessThread In process__1.Threads
                ' check for a desktop name match.
                If GetDesktopName(GetThreadDesktop(pt.Id)) = currentDesktop Then
                    ' found a match, add to list, and bail.
                    m_procs.Add(process__1)
                    Exit For
                End If
            Next
        Next

        ' put ArrayList into array.
        Dim procs As Process() = New Process(m_procs.Count - 1) {}

        For i As Integer = 0 To procs.Length - 1
            procs(i) = DirectCast(m_procs(i), Process)
        Next

        Return procs
    End Function
#End Region

#Region "IDisposable"
    ''' <summary>
    ''' Dispose Object.
    ''' </summary>
    Public Sub Dispose()
        ' dispose
        Dispose(True)
        ' suppress finalisation
        GC.SuppressFinalize(Me)
    End Sub

    ''' <summary>
    ''' Dispose Object.
    ''' </summary>
    ''' <param name="disposing">True to dispose managed resources.</param>
    Public Overridable Sub Dispose(disposing As Boolean)
        If Not m_disposed Then
            ' dispose of managed resources,
            ' close handles
            Close()
        End If
        m_disposed = True
    End Sub

    Private Sub CheckDisposed()
        ' check if disposed
        If m_disposed Then
            ' object disposed, throw exception
            Throw New ObjectDisposedException("")
        End If
    End Sub
#End Region

#Region "ICloneable"
    ''' <summary>
    ''' Creates a new Desktop object with the same desktop open.
    ''' </summary>
    ''' <returns>Cloned desktop object.</returns>
    Public Function Clone() As Object
        ' make sure object isnt disposed.
        CheckDisposed()

        Dim desktop As New Desktop()

        ' if a desktop is open, make the clone open it.
        If IsOpen Then
            desktop.Open(m_desktopName)
        End If

        Return desktop
    End Function
#End Region

#Region "Overrides"
    ''' <summary>
    ''' Gets the desktop name.
    ''' </summary>
    ''' <returns>The desktop name, or a blank string if no desktop open.</returns>
    Public Overrides Function ToString() As String
        ' return the desktop name.
        Return m_desktopName
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
#End Region
End Class