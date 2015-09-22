Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Timers

Public Class Remote
    Public Sock As Integer
    Public Sz As Size
    Public F As Main
    ''' <summary>
    ''' Is the screen capturing active
    ''' </summary>
    Public active As Boolean = False
    ''' <summary>
    ''' Image file size
    ''' </summary>
    Public filesize As String
    ''' <summary>
    ''' String for amount of current tile changes
    ''' </summary>
    Public changes As String
    ''' <summary>
    ''' Frames per Second
    ''' </summary>
    Public FPS As Integer = 0 ''todo: implement
    ''' <summary>
    ''' Area where stats are overlayed on picture
    ''' </summary>
    Public overlayarea As Bitmap
    ''' <summary>
    ''' Control Panel Visible
    ''' </summary>
    Dim sPanel As Boolean = True
    ''' <summary>
    ''' Mouse and Keyboard action timers
    ''' </summary>
    Public mTimer, kTimer As Timers.Timer
    Dim K As Bitmap
    Dim G As Graphics
    Dim srcImage
    Dim mousePos As Point
    Const KEYEVENTF_KEYUP As UInteger = &H2 '0x0002
    ''' <summary>
    ''' Current screen data
    ''' </summary>
    Public cscreen As Byte()
    Private Sub Remote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        For i As Integer = 0 To 13
            C1.Items.Add(QZ(i))
        Next
        For i As Integer = 1 To 10
            C2.Items.Add(i)
        Next
        P1.Image = New Bitmap(Sz.Width, Sz.Height)
        C1.SelectedIndex = 4
        C2.SelectedIndex = 4
        M.SelectedIndex = 0
        M.Enabled = False
        InfoStrip.Visible = False
        InfoStrip.BackColor = Color.FromArgb(17, 17, 17)
        overlayarea = New Bitmap(Sz.Width, Sz.Height)
        mTimer = New Timer(500)
        kTimer = New Timer(300)
        AddHandler mTimer.Elapsed, AddressOf mTimer_Tick
        AddHandler kTimer.Elapsed, AddressOf kTimer_Tick
    End Sub

    Public Sub change()
        C1.Items.Clear()

        For i As Integer = 0 To 13
            C1.Items.Add(QZ(i))
        Next
        P1.Image = New Bitmap(Sz.Width, Sz.Height)
        C1.SelectedIndex = 4
        C2.SelectedIndex = 4

        overlayarea = New Bitmap(Sz.Width, Sz.Height)
    End Sub
    Private ReadOnly pLock As New Object() ''lock
    Public Sub PktToImage(ByVal BY As Byte())
        cscreen = BY
        If active Then
            F.S.Send(Sock, Main.n.getscreen & Main.Sep & C1.SelectedIndex & Main.Sep & C2.Text & Main.Sep & C.Value)
        End If
        Dim B As Array = fx(BY, "^&^")
        Dim Q As New IO.MemoryStream(CType(B(1), Byte()))
        Dim L As Bitmap = Image.FromStream(Q)
        Dim QQ As String() = Split(BS(B(0)), ",")
        filesize = siz(BY.LongLength) ''add bytesize extension and pad with zeros
        If filesize.Contains(".") Then filesize = filesize.PadLeft(8, "0") Else filesize = filesize.PadLeft(7, "0") ''pad with zeros
        changes = QQ.Length - 2
        K = P1.Image.GetThumbnailImage(CType(Split(QQ(0), ".")(0), Integer), CType(Split(QQ(0), ".")(1), Integer), Nothing, Nothing)
        G = Graphics.FromImage(K)
        'If StatsCheckBox.Checked Then
        '    G.DrawImage(overlayarea, 0, 0) ''before everything, restore area with stat overlay
        'End If
        Dim tp As Integer = 0
        For i As Integer = 1 To QQ.Length - 2
            Dim P As New Point(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1))
            Dim SZ As New Size(L.Width, Split(QQ(i), ".")(2))
            G.DrawImage(L.Clone(New Rectangle(0, tp, L.Width, CType(Split(QQ(i), ".")(2), Integer)), L.PixelFormat), New Point(CType(Split(QQ(i), ".")(0), Integer), CType(Split(QQ(i), ".")(1), Integer)))
            If LinesCheckBox.Checked Then ''draw split lines
                Dim r As New Rectangle(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1), SZ.Width, SZ.Height)
                If K.GetPixel(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1)) = Color.Aquamarine Then
                    G.DrawRectangle(Pens.Blue, r) ''Doesn't work yet
                Else
                    G.DrawRectangle(Pens.Aquamarine, r)
                End If
            End If
            tp += SZ.Height
        Next
        'If StatsCheckBox.Checked Then ''draw fps
        '    Using gp As New GraphicsPath, f As New Font("Segoe UI", 15, FontStyle.Bold), p As New Pen(Brushes.Black, 2)
        '        gp.AddString(filesize, f.FontFamily, f.Style, f.Size, New Point(2, 2), StringFormat.GenericTypographic)
        '        gp.AddString("Changes: " & changes, f.FontFamily, f.Style, f.Size, New Point(2, 16), StringFormat.GenericTypographic)
        '        gp.AddString("FPS lag: " & FPS, f.FontFamily, f.Style, f.Size, New Point(2, 30), StringFormat.GenericTypographic)
        '        overlayarea = K.Clone(New Rectangle(0, 0, gp.GetBounds.Width, gp.GetBounds.Height), overlayarea.PixelFormat) ''before drawing, back up area stats will be displayed on
        '        G.DrawPath(p, gp)
        '        G.FillPath(Brushes.Yellow, gp)
        '    End Using
        'End If
        UpdateInfo(True)
        G.Dispose()
        P1.Image = K
    End Sub

    Private Sub mTimer_Tick(ByVal sender As System.Object, ByVal e As ElapsedEventArgs)
        MouseLabel.Image = My.Resources.mouse
        mTimer.Stop()
    End Sub

    Private Sub kTimer_Tick(ByVal sender As System.Object, ByVal e As ElapsedEventArgs)
        KeyboardLabel.Image = My.Resources.keyboard1
        kTimer.Stop()
    End Sub

    Private Sub chI(ByVal c As ToolStripStatusLabel, ByVal i As Image, ByVal t As Timer)
        c.Image = i
        t.Start()
    End Sub

    ''' <summary>
    ''' Update status info labels
    ''' </summary>
    ''' <param name="active"></param>
    Public Sub UpdateInfo(ByVal active As Boolean)
        If active Then
            FPSLabel.Text = "FPS: " & FPS ''TODO: implement
        Else
            FPSLabel.Text = "FPS: --"
        End If
        SizeLabel.Text = "Size: " & filesize
        ChangesLabel.Text = "Changes: " & changes
    End Sub

    Function QZ(ByVal q As Integer) As Size '  Lower Size of image
        Dim zs As New Size(Sz)
        Select Case q
            Case 0
                Return Sz
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

    Private Sub Remote_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim key As String
        If KeyboardCheckBox.Checked = True Then
            P1.Focus()
            chI(KeyboardLabel, My.Resources.keyboard__arrow, kTimer)
            key = e.KeyCode
            F.S.Send(Sock, Main.n.keyboard & Main.Sep & key & Main.Sep & 0)
        End If
    End Sub

    Private Sub Remote_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Dim key As String
        If KeyboardCheckBox.Checked = True Then
            P1.Focus()
            chI(KeyboardLabel, My.Resources.keyboard__arrow, kTimer)
            key = e.KeyCode
            F.S.Send(Sock, Main.n.keyboard & Main.Sep & key & Main.Sep & KEYEVENTF_KEYUP)
        End If
    End Sub

    Private Sub P1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseDown
        If MouseCheckBox.Checked = True Then
            ''todo: implememtn mouse wheel
            Dim PP = New Point(mousePos.X, mousePos.Y)
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 2
                chI(MouseLabel, My.Resources.mouse_select, mTimer)
            End If
            If e.Button = Windows.Forms.MouseButtons.Middle Then
                but = 20
                chI(MouseLabel, My.Resources.mouse_select_wheel, mTimer)
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 8
                chI(MouseLabel, My.Resources.mouse_select_right, mTimer)
            End If
            F.S.Send(Sock, Main.n.mouseclick & Main.Sep & PP.X & Main.Sep & PP.Y & Main.Sep & but)
        End If
    End Sub
    Private Sub P1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseUp
        If MouseCheckBox.Checked = True Then
            Dim PP = New Point(mousePos.X, mousePos.Y)
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 4
                chI(MouseLabel, My.Resources.mouse_select, mTimer)
            End If
            If e.Button = Windows.Forms.MouseButtons.Middle Then
                but = 40
                chI(MouseLabel, My.Resources.mouse_select_wheel, mTimer)
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 16
                chI(MouseLabel, My.Resources.mouse_select_right, mTimer)
            End If
            F.S.Send(Sock, Main.n.mouseclick & Main.Sep & PP.X & Main.Sep & PP.Y & Main.Sep & but)
        End If

    End Sub
    Dim op As New Point
    Dim pp As New Point
    Private Sub P1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseMove
        Try
            srcImage = Me.P1.Image.Clone
        Catch ex As Exception
        End Try
        Dim sfx, sfy As Single  'scalefactor of Image width to Picturebox Width, and image height to Picturebox height
        Dim xl, yt As Single    'Where the top left x,y ooordinate of the image is in the picturebox when zoomed
        Dim sf As Single        'What the scalefactor is to keep the image in proportion (zoomed)

        With P1
            sfx = CSng(Sz.Width / .ClientSize.Width)               'determine X ratio
            sfy = CSng(Sz.Height / .ClientSize.Height)             'determine Y ratio
            If sfx > sfy Then                                               'if X ratio is larger Then use it
                sf = sfx                                                      '  Scale factor is X ratio
                yt = (.ClientSize.Height - (Sz.Height / sf)) / 2     '  calculate Y offset to top of centered image
            Else                                                            'else (Y is larger or equal to X)
                sf = sfy                                                      '  Scale factor is Y ratio
                xl = (.ClientSize.Width - Sz.Width / sf) / 2         '  calculate X offset to left side of centered image
            End If
        End With
        'Get the mouse position in the source image.
        ' Dim mousePos = Me.srcPictureBox.PointToClient(Control.MousePosition)
        mousePos.X = CInt((e.X - xl) * sf)                             'Adjust Mouse X to account for center offset and scaling
        mousePos.Y = CInt((e.Y - yt) * sf)                             'Adjust mouse Y to account for center offset and scaling


        If MouseCheckBox.Checked = True Then
            If active Then
                Dim PP = New Point(mousePos.X, mousePos.Y)
                If PP <> op Then
                    op = PP
                    chI(MouseLabel, My.Resources.mouse__arrow, mTimer)
                    F.S.Send(Sock, Main.n.mousemove & Main.Sep & PP.X & Main.Sep & PP.Y & Main.Sep)
                End If
            End If
        End If
    End Sub
    Private Sub ToggleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton.Click
        If active = False Then
            P1.Focus()
            M.Enabled = True
            active = True
            InfoStrip.Visible = True
            ToggleButton.Text = "Stop"
            F.S.Send(Sock, Main.n.getscreen & Main.Sep & C1.SelectedIndex & Main.Sep & C2.Text & Main.Sep & C.Value)
        Else
            M.Enabled = False
            active = False
            InfoStrip.Visible = False
            ToggleButton.Text = "Start"
        End If
    End Sub

    Private Sub LinesCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles LinesCheckBox.CheckedChanged
        If Not LinesCheckBox.Checked Then
            clear()
        End If
    End Sub

    Sub clear()
        F.S.Send(Sock, Main.n.clearscreen)
    End Sub

    Private Sub M_SelectedIndexChanged(sender As Object, e As EventArgs) Handles M.SelectedIndexChanged
        F.S.Send(Sock, Main.n.changescreen & Main.Sep & M.SelectedIndex)
    End Sub

    Private Sub P1_Resize(sender As Object, e As EventArgs) Handles P1.Resize
        If active Then

        End If
    End Sub

    Public Structure Rect
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Sub HideLabel_Click(sender As Object, e As EventArgs) Handles HideLabel.Click
        If sPanel Then ''hide
            ControlFlowLayoutPanel.Visible = False
            HideLabel.Top = 10
            HideLabel.Image = My.Resources.arrow_270_medium
        Else ''show
            ControlFlowLayoutPanel.Visible = True
            HideLabel.Top = ControlFlowLayoutPanel.Bottom
            HideLabel.Image = My.Resources.arrow_090_medium
        End If
        sPanel = Not sPanel
    End Sub

    Private Sub Remote_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        HideLabel.Left = Me.Width / 2 - HideLabel.Width / 2
    End Sub

    Private Sub KeyboardCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles KeyboardCheckBox.CheckedChanged
        P1.Focus()
    End Sub

    'Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    '    Static first_time As Boolean = True
    '    Static aspect_ratio As Double
    '    Const WM_SIZING As Long = &H214
    '    Const WMSZ_LEFT As Integer = 1
    '    Const WMSZ_RIGHT As Integer = 2
    '    Const WMSZ_TOP As Integer = 3
    '    Const WMSZ_TOPLEFT As Integer = 4
    '    Const WMSZ_TOPRIGHT As Integer = 5
    '    Const WMSZ_BOTTOM As Integer = 6
    '    Const WMSZ_BOTTOMLEFT As Integer = 7
    '    Const WMSZ_BOTTOMRIGHT As Integer = 8

    '    If m.Msg = WM_SIZING And m.HWnd.Equals(Me.Handle) Then
    '        ' Turn the message's lParam into a Rect.
    '        Dim r As Rect
    '        r = DirectCast(
    '            Marshal.PtrToStructure(m.LParam, GetType(Rect)),
    '            Rect)

    '        ' The first time, save the form's aspect ratio.
    '        If first_time Then
    '            first_time = False
    '            aspect_ratio = (r.bottom - r.top) / (r.right - r.left)
    '        End If

    '        ' Get the current dimensions.
    '        Dim wid As Double = r.right - r.left
    '        Dim hgt As Double = r.bottom - r.top

    '        ' Enlarge if necessary to preserve the aspect ratio.
    '        If hgt / wid > aspect_ratio Then
    '            ' It's too tall and thin. Make it wider.
    '            wid = hgt / aspect_ratio
    '        Else
    '            ' It's too short and wide. Make it taller.
    '            hgt = wid * aspect_ratio
    '        End If

    '        ' See if the user is dragging the top edge.
    '        If m.WParam.ToInt32 = WMSZ_TOP Or
    '           m.WParam.ToInt32 = WMSZ_TOPLEFT Or
    '           m.WParam.ToInt32 = WMSZ_TOPRIGHT _
    '        Then
    '            ' Reset the top.
    '            r.top = r.bottom - CInt(hgt)
    '        Else
    '            ' Reset the height to the saved value.
    '            r.bottom = r.top + CInt(hgt)
    '        End If

    '        ' See if the user is dragging the left edge.
    '        If m.WParam.ToInt32 = WMSZ_LEFT Or
    '           m.WParam.ToInt32 = WMSZ_TOPLEFT Or
    '           m.WParam.ToInt32 = WMSZ_BOTTOMLEFT _
    '        Then
    '            ' Reset the left.
    '            r.left = r.right - CInt(wid)
    '        Else
    '            ' Reset the width to the saved value.
    '            r.right = r.left + CInt(wid)
    '        End If

    '        ' Update the Message object's LParam field.
    '        Marshal.StructureToPtr(r, m.LParam, True)
    '    End If

    '    MyBase.WndProc(m)
    'End Sub
End Class