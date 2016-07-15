﻿Imports System.Net
Imports System.Net.Sockets, System.IO, System.Threading, System.Runtime.Serialization.Formatters.Binary, System.Runtime.Serialization, System.Runtime.InteropServices, Microsoft.Win32
Imports System.Runtime.CompilerServices
Imports System.Windows.Threading

Public Class SocketServer
    Private S As TcpListener
    Private _T As DispatcherTimer
    ''Public Ping As Integer = 0
    ''' <summary>
    ''' Command variable values
    ''' </summary>
    Public Shared n As New N

    Sub stops()
        Try
            S.Stop()
            Dim T As New Threading.Thread(AddressOf PND, 10)
            T.Abort()

        Catch : End Try
    End Sub
    Sub Start(ByVal P As Integer)

        S = New TcpListener(IPAddress.Any, P)

        S.Start()
        Dim T As New Threading.Thread(AddressOf PND, 10)
        T.Start()
    End Sub
    Sub Send(ByVal c As Client, ByVal s As String)
        ''MsgBox(s & "::" & c.Socket)
        Try
            If c.Trusted = True And Not s Is n.getscreen Then
                Send(c, SB(c.Cryptor.Encrypt(s, c.Key)))
            Else
                Send(c, SB(s))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            MessageBox.Show("Line: " & st.GetFrame(0).GetFileLineNumber().ToString, "Error Sending")
        End Try
    End Sub
    Sub Send(ByVal c As Client, ByVal b As Byte())
        Try
            ''Dim c As Client = Main.Clients.Find(Function(item) item.ID = id)
            Dim m As New IO.MemoryStream
            m.Write(b, 0, b.Length)
            m.Write(SB(SPL), 0, SPL.Length)
            SK(c.Socket).Send(m.ToArray, 0, m.Length, SocketFlags.None)
            m.Dispose()
        Catch ex As Exception
            MsgBox("Exception. Disconnecting")
            Disconnect(c.Socket)
        End Try
    End Sub
    Private SKT As Integer = -1
    Public SK(9999) As Socket
    Public Event Datad(ByVal info As Data)
    Public Event Data(ByVal sock As Integer, ByVal B As Byte())
    Public Event DisConnected(ByVal sock As Integer)
    Public Event Connected(ByVal sock As Integer)
    Private SPL As String = "=0-0=" ' split packets by this word
    Private Function NEWSKT() As Integer
re:
        Thread.Sleep(1)
        SKT += 1
        If SKT = SK.Length Then
            SKT = 0
            GoTo re
        End If
        If Online.Contains(SKT) = False Then
            Online.Add(SKT)
            Return SKT.ToString.Clone
        End If
        GoTo re
    End Function
    Public Online As New List(Of Integer) ' online clients
    Private Sub PND()
        Try
            ReDim SK(9999)
re:

            Thread.Sleep(1)
            If S.Pending Then

                Dim sock As Integer = NEWSKT()
                SK(sock) = S.AcceptSocket

                SK(sock).ReceiveBufferSize = 99999
                SK(sock).SendBufferSize = 99999
                SK(sock).ReceiveTimeout = 9000
                SK(sock).SendTimeout = 9000

                Dim t As New Threading.Thread(AddressOf RC, 10)
                t.Start(sock)

                RaiseEvent Connected(sock)
            End If
            GoTo re
        Catch : End Try
    End Sub
    Public Sub Disconnect(ByVal Sock As Integer)
        Try
            SK(Sock).Disconnect(False)
        Catch ex As Exception
        End Try
        Try
            SK(Sock).Close()
        Catch ex As Exception
        End Try
        SK(Sock) = Nothing
    End Sub
    Sub RC(ByVal sock As Integer)

        Dim M As New IO.MemoryStream
        Dim cc As Integer = 0

re:

        cc += 1
        If cc = 500 Then
            Try
                If SK(sock).Poll(-1, Net.Sockets.SelectMode.SelectRead) And SK(sock).Available <= 0 Then
                    GoTo e
                End If
            Catch ex As Exception
                GoTo e
            End Try
            cc = 0
        End If
        Try
            If SK(sock) IsNot Nothing Then

                If SK(sock).Connected Then
                    If SK(sock).Available > 0 Then
                        Dim B(SK(sock).Available - 1) As Byte
                        SK(sock).Receive(B, 0, B.Length, Net.Sockets.SocketFlags.None)
                        M.Write(B, 0, B.Length)
rr:
                        If BS(M.ToArray).Contains(SPL) Then
                            Dim A As Array = fx(M.ToArray, SPL)
                            RaiseEvent Data(sock, A(0))
                            M.Dispose()
                            M = New IO.MemoryStream
                            If A.Length = 2 Then
                                M.Write(A(1), 0, A(1).length)
                                Thread.Sleep(1)
                                GoTo rr
                            End If
                        End If

                    End If
                Else
                    GoTo e
                End If
            Else
                GoTo e
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
            GoTo e
        End Try
        Thread.Sleep(1)
        GoTo re
e:
        Disconnect(sock)
        Try
            Online.Remove(sock)
        Catch ex As Exception
        End Try
        RaiseEvent DisConnected(sock)
    End Sub
    Private oIP(9999) As String
    Public Function IP(ByRef sock As Integer) As String
        Try
            oIP(sock) = Split(SK(sock).RemoteEndPoint.ToString(), ":")(0)
            Return oIP(sock)
        Catch ex As Exception
            If oIP(sock) Is Nothing Then
                Return "=Unknown IP="
            Else
                Return oIP(sock)
            End If
        End Try

    End Function

    Private Sub T_Tick(ByVal sender As Object, ByVal e As EventArgs)
        ''Ping += 1
    End Sub

    Public Overridable Property T As DispatcherTimer
        Get
            Return _T
        End Get
        <MethodImpl(MethodImplOptions.Synchronized)>
        Set(ByVal WithEventsValue As DispatcherTimer)
            Dim handler As EventHandler = New EventHandler(AddressOf Me.T_Tick)
            If (Not _T Is Nothing) Then
                RemoveHandler Me._T.Tick, handler
            End If
            _T = WithEventsValue
            If (Not _T Is Nothing) Then
                AddHandler _T.Tick, handler
            End If
        End Set
    End Property
End Class
<Serializable()> Public Class Data
    Implements ISerializable
    Private data As String
    Private pic As Image
    Private bytes() As Byte
    Public Sub New(ByVal s As String, ByVal p As Image, ByVal b() As Byte)
        data = s : pic = p : bytes = b
    End Sub
    Public Sub New(ByVal info As SerializationInfo, ByVal ctxt As StreamingContext)
        data = DirectCast(info.GetValue("data", GetType(String)), String)
        pic = DirectCast(info.GetValue("image", GetType(Image)), Image)
        bytes = DirectCast(info.GetValue("bytes", GetType(Byte())), Byte())
    End Sub
    Public Sub GetObjectData(ByVal info As SerializationInfo, ByVal ctxt As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("data", data) : info.AddValue("image", pic) : info.AddValue("bytes", bytes)
    End Sub
    Public Function GetData() As String
        Return data
    End Function
    Public Function GetImage() As Image
        Return pic
    End Function
    Public Function GetBytes() As Byte()
        Return bytes
    End Function
End Class

Public Class DownloadContainer ''todo: work on this
    Public identification As Integer = 0
    Public nextPart As Boolean = False
    Public cancel As Boolean = False
    Sub New(ByVal id As Integer)
        identification = id
    End Sub
End Class