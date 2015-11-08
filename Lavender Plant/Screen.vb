Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports Lavender_Plant.ScreenShot

Public Class CRDP
    Private Shared OA As New List(Of Bitmap)
    Private Shared OAA As New List(Of Point)
    Private Shared OM As New Bitmap(1, 1) ' OLD IMAGE
    Public Shared cscreen As Screen = Screen.PrimaryScreen ''current screen
    Public Shared sc As ScreenCapture = New ScreenCapture

    Shared _prevBitmap As Bitmap
    Shared _newBitmap As Bitmap
    Private Shared Function QZ(ByVal q As Integer) As Size '  Lower size of image
        Dim zs As New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
        Select Case q
            Case 0
                Return zs
            Case 1
                zs.Width = zs.Width / 1.1
                zs.Height = zs.Height / 1.1
            Case 2
                zs.Width = zs.Width / 1.3
                zs.Height = zs.Height / 1.3
            Case 3
                zs.Width = zs.Width / 1.5
                zs.Height = zs.Height / 1.5
            Case 4
                zs.Width = zs.Width / 1.9
                zs.Height = zs.Height / 1.9
            Case 5
                zs.Width = zs.Width / 2
                zs.Height = zs.Height / 2
            Case 6
                zs.Width = zs.Width / 2.1
                zs.Height = zs.Height / 2.1
            Case 7
                zs.Width = zs.Width / 2.2
                zs.Height = zs.Height / 2.2
            Case 8
                zs.Width = zs.Width / 2.5
                zs.Height = zs.Height / 2.5
            Case 9
                zs.Width = zs.Width / 3
                zs.Height = zs.Height / 3
            Case 10
                zs.Width = zs.Width / 3.5
                zs.Height = zs.Height / 3.5
            Case 11
                zs.Width = zs.Width / 4
                zs.Height = zs.Height / 4
            Case 12
                zs.Width = zs.Width / 5
                zs.Height = zs.Height / 5
            Case 13
                zs.Width = zs.Width / 6
                zs.Height = zs.Height / 6
        End Select
        zs.Width = Mid(zs.Width.ToString, 1, zs.Width.ToString.Length - 1) & 0
        zs.Height = Mid(zs.Height.ToString, 1, zs.Height.ToString.Length - 1) & 0
        Return zs
    End Function
    Private Shared Function Gd(Optional ByVal Wi As Integer = 0, Optional ByVal He As Integer = 0, Optional ByVal Sh As Boolean = True) As Image
        Dim W As Integer = cscreen.Bounds.Width
        Dim H As Integer = cscreen.Bounds.Height
        Dim B As New Bitmap(W, H)
        Dim g As Graphics = Graphics.FromImage(B)
        g.CompositingQuality = CompositingQuality.HighSpeed
        g.DrawImage(sc.CaptureDeskTopRectangle(cscreen.Bounds, cscreen.Bounds.Width, cscreen.Bounds.Height), 0, 0)
        'g.CopyFromScreen(cscreen.Bounds.X, cscreen.Bounds.Y, 0, 0, New Size(cscreen.Bounds.Width, cscreen.Bounds.Height), CopyPixelOperation.SourceCopy)

        Dim c As Bitmap = CaptureCursor(0, 0)
        Dim r As Rectangle = New Rectangle(0, 0, c.Width, c.Height)
        g.DrawImage(c, r)
        If Sh Then
            Try
                Cursors.Default.Draw(g, New Rectangle(Cursor.Position, New Size(32, 32)))
            Catch ex As Exception
            End Try
        End If
        g.Dispose()

        B = sc.CaptureDeskTopRectangle(cscreen.Bounds, cscreen.Bounds.Width, cscreen.Bounds.Height)
        If Wi = 0 And He = 0 Then
            ''Return B
            Return B
        Else
            Return B.GetThumbnailImage(Wi, He, Nothing, Nothing)
        End If
    End Function

    Private Shared Function GetEncoderInfo(ByVal M As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = M Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function
    Shared Sub Clear()
        oQ = -1
        oCo = -1
        oQu = -1
        OM = New Bitmap(1, 1)
    End Sub

    Private Shared oQ As Integer = 0
    Private Shared oCo As Integer = 0
    Private Shared oQu As Integer = 0
    ''' <summary>
    ''' Capture screen
    ''' </summary>
    ''' <param name="q">Size</param>
    ''' <param name="co">Split Pieces</param>
    ''' <param name="Qu">Quality</param>
    ''' <returns></returns>
    Shared Function Cap(ByVal q As Integer, ByVal co As Integer, ByVal Qu As Integer) As Byte()
ee:
        Dim ZS As New Size(QZ(q))
        ZS.Width = Mid(ZS.Width.ToString, 1, ZS.Width.ToString.Length - 1) & 0
        ZS.Height = Mid(ZS.Height.ToString, 1, ZS.Height.ToString.Length - 1) & 0
        If OM.Size.Width <> ZS.Width Or OM.Height <> ZS.Height Or oCo <> co Or oQu <> Qu Then
            OA.Clear()
            OAA.Clear()
            OM = New Bitmap(ZS.Width, ZS.Height)
        End If
        oQ = q
        oCo = co
        oQu = Qu

        Dim A As New List(Of Bitmap)
        Dim AA As New List(Of Point)
        Dim m As Bitmap
        If OA.Count > 0 Then
            A.AddRange(OA.ToArray)
            OA.Clear()
            AA.AddRange(OAA.ToArray)
            OAA.Clear()

            m = OM
            GoTo e
        End If
        m = Gd(ZS.Width, ZS.Height)
        Dim w As Integer = ZS.Width
        Dim h As Integer = ZS.Height
        Dim K As Integer = 0
        For i As Integer = 0 To co - 1
            For ii As Integer = 0 To co - 1
                Dim y As Integer = h / co * i
                Dim x As Integer = w / co * ii
                Dim wc As Integer = w / co
                Dim hc As Integer = h / co
                If wc.ToString.Contains(".") Then
                    wc = Split(wc, ".")(0)
                End If
                If hc.ToString.Contains(".") Then
                    hc = Split(hc, ".")(0)
                End If
                Dim MM As New IO.MemoryStream
                Dim Mj = m.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim MJJ = OM.Clone(New Rectangle(x, y, wc, hc), m.PixelFormat)
                Dim b1 As Byte()
                Dim b2 As Byte()
                Mj.Save(MM, Imaging.ImageFormat.Jpeg)
                b1 = MM.ToArray
                MM.Dispose()
                MM = New IO.MemoryStream
                MJJ.Save(MM, Imaging.ImageFormat.Jpeg)

                b2 = MM.ToArray

                MM.Dispose()

                'If md5(b1) = md5(b2) Then
                '    Mj.Dispose()
                'Else
                If Crypt.Crc32.ComputeChecksum(b1) = Crypt.Crc32.ComputeChecksum(b2) Then
                    Mj.Dispose()
                Else
                    A.Add(Mj)
                    AA.Add(New Point(x, y))
                End If
                MJJ.Dispose()
nx:
            Next
        Next
e:

        If A.Count = 0 Then
            Return New Byte() {0}
        End If
        Dim hh As Integer = 0
        Dim QA As New List(Of Integer)
        For i As Integer = 0 To co * co / 5
            If i = A.Count Then Exit For
            QA.Add(i)
            hh += A(i).Height
        Next
        Dim xx As New Bitmap(A(0).Width, hh)
        Dim gg = Graphics.FromImage(xx)
        Dim tp As Integer = 0
        Dim s As String = m.Width & "." & m.Height & ","
        For Each i As Integer In QA
            s += AA(i).X & "." & AA(i).Y & "." & A(i).Height & ","
            gg.DrawImage(A(i), 0, tp)
            tp += A(i).Height
        Next
        s += "^&^"
        For i As Integer = 0 To A.Count - 1
            If QA.Contains(i) = False Then
                OA.Add(A(i))
                OAA.Add(AA(i))
            End If
        Next
        gg.Dispose()
        Dim JA = New IO.MemoryStream
        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Drawing.Imaging.Encoder.Quality, Qu)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        xx.Save(JA, ici, eps)
        Dim J2 As New IO.MemoryStream
        J2.Write(System.Text.Encoding.Default.GetBytes(s), 0, s.Length)
        J2.Write(JA.ToArray, 0, JA.Length)
        OM = m
        xx.Dispose()
        Return J2.ToArray
    End Function


    Public Shared Function CaptureCursor(ByRef x As Integer, ByRef y As Integer) As Bitmap
        Dim bmp As Bitmap = Nothing
        If True Then
            Dim ci As New CURSORINFO()
            Dim icInfo As ICONINFO
            ci.cbSize = Marshal.SizeOf(ci)
            If GetCursorInfo(ci) Then
                If ci.flags = CURSOR_SHOWING Then
                    Dim hicon As IntPtr = CopyIcon(ci.hCursor)
                    If GetIconInfo(hicon, icInfo) Then
                        If icInfo.hbmMask <> IntPtr.Zero Then
                            DeleteObject(icInfo.hbmMask)
                        End If
                        If icInfo.hbmColor <> IntPtr.Zero Then
                            DeleteObject(icInfo.hbmColor)
                        End If
                        x = ci.ptScreenPos.X - icInfo.xHotspot
                        y = ci.ptScreenPos.Y - icInfo.yHotspot

                        Dim ic As Icon = Icon.FromHandle(hicon)
                        If ic.Width > 0 AndAlso ic.Height > 0 Then
                            bmp = ic.ToBitmap()
                        End If
                        DestroyIcon(hicon)
                    End If
                End If
            End If
        End If

        Return bmp
    End Function

#Region "Class Functions"
    Public Const SM_CXSCREEN As Integer = 0
    Public Const SM_CYSCREEN As Integer = 1

    Public Const CURSOR_SHOWING As Int32 = &H1

    <StructLayout(LayoutKind.Sequential)>
    Public Structure ICONINFO
        Public fIcon As Boolean
        ' Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies 
        Public xHotspot As Int32
        ' Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot 
        Public yHotspot As Int32
        ' Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot 
        Public hbmMask As IntPtr
        ' (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon, 
        Public hbmColor As IntPtr
        ' (HBITMAP) Handle to the icon color bitmap. This member can be optional if this 
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure CURSORINFO
        Public cbSize As Int32
        ' Specifies the size, in bytes, of the structure. 
        Public flags As Int32
        ' Specifies the cursor state. This parameter can be one of the following values:
        Public hCursor As IntPtr
        ' Handle to the cursor. 
        Public ptScreenPos As Point
        ' A POINT structure that receives the screen coordinates of the cursor. 
    End Structure



    <DllImport("user32.dll", EntryPoint:="GetCursorInfo")>
    Public Shared Function GetCursorInfo(ByRef pci As CURSORINFO) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="CopyIcon")>
    Public Shared Function CopyIcon(hIcon As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="GetIconInfo")>
    Public Shared Function GetIconInfo(hIcon As IntPtr, ByRef piconinfo As ICONINFO) As Boolean
    End Function

    <DllImport("gdi32.dll", EntryPoint:="DeleteObject")>
    Public Shared Function DeleteObject(hDc As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="DestroyIcon")>
    Public Shared Function DestroyIcon(hIcon As IntPtr) As Boolean
    End Function
#End Region
End Class