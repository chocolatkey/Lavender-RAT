''' <summary>
''' This class extends the PictureBox control with the following:
''' <list type="table">
''' <item><term>GetRelativeMousePosition()</term></item>
''' </list>
''' </summary>
Public Class PictureBoxExtended
    Inherits PictureBox

#Region "Events"

    ''' <summary>
    ''' Handler for when the mouse moves over the image part of the picture box
    ''' </summary>
    Public Delegate Sub MouseMoveOverImageHandler(sender As Object, e As MouseEventArgs)

    ''' <summary>
    ''' Occurs when the mouse have moved over the image part of a picture box
    ''' </summary>
    Public Event MouseMoveOverImage As MouseMoveOverImageHandler

#End Region

#Region "Properties"
    ''' <summary>
    ''' Gets the mouse position relative to the <see cref="PictureBox.Image">Image</see> top left corner
    ''' </summary>
    ''' <value>The location of the mouse translated onto the <see cref="PictureBox.Image">Image</see> .</value>
    Public ReadOnly Property MousePositionOnImage() As Point
        Get
            Dim local As Point = PointToClient(MousePosition)
            Return TranslatePointToImageCoordinates(local)
        End Get
    End Property
#End Region
#Region "Methods"
#Region "Public Methods"
    ''' <summary>
    ''' Translates a point to coordinates relative to the <see cref="PictureBox.Image">Image</see>.
    ''' The supplied point is taken relativce to the control's upper left corner
    ''' </summary>
    ''' <param name="controlCoordinates">The point to translate, relative to the control's upper left corner.</param>
    ''' <returns>A new point representing where over the <see cref="PictureBox.Image">Image</see> the supplied point is.</returns>
    Public Function TranslatePointToImageCoordinates(controlCoordinates As Point) As Point
        Select Case SizeMode
            Case PictureBoxSizeMode.Normal
                Return TranslateNormalMousePosition(controlCoordinates)
            Case PictureBoxSizeMode.AutoSize
                Return TranslateAutoSizeMousePosition(controlCoordinates)
            Case PictureBoxSizeMode.CenterImage
                Return TranslateCenterImageMousePosition(controlCoordinates)
            Case PictureBoxSizeMode.StretchImage
                Return TranslateStretchImageMousePosition(controlCoordinates)
            Case PictureBoxSizeMode.Zoom
                Return TranslateZoomMousePosition(controlCoordinates)
        End Select
        Throw New NotImplementedException("PictureBox.SizeMode was not in a valid state")
    End Function
#End Region
#Region "Protected Methods"
    ''' <summary>
    ''' Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to AutoSize
    ''' </summary>
    ''' <param name="coordinates">Point to translate</param>
    ''' <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see></returns>
    ''' <remarks>
    ''' In AutoSize mode, the <see cref="PictureBox">PictureBox</see> is automagically resized* to the size of the <see cref="PictureBox.Image">Image.</see>
    ''' Thus, the image is at the top left corner of the control, and no translation takes place.
    ''' * This is not necessary true.  The <see cref="PictureBox">PictureBox</see> may NOT be resized depending on how it is docked in it's parent.
    ''' However, even in these cases no translation is needed, as the image is rendered the same as if it was in Normal mode
    ''' </remarks>
    Protected Function TranslateAutoSizeMousePosition(coordinates As Point) As Point
        'TODO: When we implement scrolling, we will have to make sure we test that properly. As of now, not sure how the rendering will take place
        Return coordinates
    End Function

    ''' <summary>
    ''' Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Zoom
    ''' </summary>
    ''' <param name="coordinates">Point to translate</param>
    ''' <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
    ''' If the Image is null, no translation is performed
    ''' </returns>
    Protected Function TranslateZoomMousePosition(coordinates As Point) As Point
        '	test to make sure our image is not null
        If Image Is Nothing Then
            Return coordinates
        End If
        '	Make sure our control width and height are not 0 and our image width and height are not 0
        If Width = 0 OrElse Height = 0 OrElse Image.Width = 0 OrElse Image.Height = 0 Then
            Return coordinates
        End If
        '	This is the one that gets a little tricky.  Essentially, need to check the aspect ratio of the image to the aspect ratio of the control
        ' to determine how it is being rendered
        Dim imageAspect As Single = CSng(Image.Width) / Image.Height
        Dim controlAspect As Single = CSng(Width) / Height
        Dim newX As Single = coordinates.X
        Dim newY As Single = coordinates.Y
        If imageAspect > controlAspect Then
            '	This means that we are limited by width, meaning the image fills up the entire control from left to right
            Dim ratioWidth As Single = CSng(Image.Width) / Width
            newX *= ratioWidth
            Dim scale As Single = CSng(Width) / Image.Width
            Dim displayHeight As Single = scale * Image.Height
            Dim diffHeight As Single = Height - displayHeight
            diffHeight /= 2
            newY -= diffHeight
            newY /= scale
        Else
            '	This means that we are limited by height, meaning the image fills up the entire control from top to bottom
            Dim ratioHeight As Single = CSng(Image.Height) / Height
            newY *= ratioHeight
            Dim scale As Single = CSng(Height) / Image.Height
            Dim displayWidth As Single = scale * Image.Width
            Dim diffWidth As Single = Width - displayWidth
            diffWidth /= 2
            newX -= diffWidth
            newX /= scale
        End If
        Return New Point(CInt(newX), CInt(newY))
    End Function

    ''' <summary>
    ''' Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to StretchImage
    ''' </summary>
    ''' <param name="coordinates">Point to translate</param>
    ''' <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
    ''' If the Image is null, no translation is performed
    ''' </returns>
    Protected Function TranslateStretchImageMousePosition(coordinates As Point) As Point
        '	test to make sure our image is not null
        If Image Is Nothing Then
            Return coordinates
        End If
        '	Make sure our control width and height are not 0
        If Width = 0 OrElse Height = 0 Then
            Return coordinates
        End If
        '	First, get the ratio (image to control) the height and width
        Dim ratioWidth As Single = CSng(Image.Width) / Width
        Dim ratioHeight As Single = CSng(Image.Height) / Height
        '	Scale the points by our ratio
        Dim newX As Single = coordinates.X
        Dim newY As Single = coordinates.Y
        newX *= ratioWidth
        newY *= ratioHeight
        Return New Point(CInt(newX), CInt(newY))
    End Function

    ''' <summary>
    ''' Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Center
    ''' </summary>
    ''' <param name="coordinates">Point to translate</param>
    ''' <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see>
    ''' If the Image is null, no translation is performed
    ''' </returns>
    Protected Function TranslateCenterImageMousePosition(coordinates As Point) As Point
        '	Test to make sure our image is not null
        If Image Is Nothing Then
            Return coordinates
        End If
        '	First, get the top location (relative to the top left of the control) of the image itself
        ' To do this, we know that the image is centered, so we get the difference in size (width and height) of the image to the control
        Dim diffWidth As Integer = Width - Image.Width
        Dim diffHeight As Integer = Height - Image.Height
        '	We now divide in half to accomadate each side of the image
        diffWidth /= 2
        diffHeight /= 2
        '	Finally, we subtract this numer from the original coordinates
        ' In the case that the image is larger than the picture box, this still works
        coordinates.X -= diffWidth
        coordinates.Y -= diffHeight
        Return coordinates
    End Function

    ''' <summary>
    ''' Gets the mouse position over the image when the <see cref="PictureBox">PictureBox's</see> <see cref="PictureBox.SizeMode">SizeMode</see> is set to Normal
    ''' </summary>
    ''' <param name="coordinates">Point to translate</param>
    ''' <returns>A point relative to the top left corner of the <see cref="PictureBox.Image">Image</see></returns>
    ''' <remarks>
    ''' In normal mode, the image is placed in the top left corner, and as such the point does not need to be translated.
    ''' The resulting point is the same as the original point
    ''' </remarks>
    Protected Function TranslateNormalMousePosition(coordinates As Point) As Point
        '	TODO: When we implement scrolling in this, we will need to test for scroll offset
        '	NOTE: As it stands now, this could be made static, but in the future we will be making this handle scaling
        Return coordinates
    End Function

    ''' <summary>
    ''' Raises the <see cref="E:System.Windows.Forms.Control.MouseMove"></see> event.
    ''' If the mouse is over the <see cref="PictureBox.Image">Image</see>, raises the <see cref="MouseMoveOverImage"></see> event.
    ''' </summary>
    ''' <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"></see> that contains the event data.</param>
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Image IsNot Nothing Then
            If MouseMoveOverImage IsNot Nothing Then
                Dim p As Point = TranslatePointToImageCoordinates(e.Location)
                If p.X >= 0 AndAlso p.X < Image.Width AndAlso p.Y >= 0 AndAlso p.Y < Image.Height Then
                    Dim ne As New MouseEventArgs(e.Button, e.Clicks, p.X, p.Y, e.Delta)
                    RaiseEvent MouseMoveOverImage(Me, ne)
                End If
            End If
        End If
    End Sub

#End Region
#End Region
End Class
