Public Class Keyboard

    Public Sub New(ByVal target As Control)
        ' This call is required by the designer.
        InitializeComponent()

        VK.Target = target
        Dim control As Control = DirectCast(target, Control)

        Show()

    End Sub
    Private Sub Keyboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.Close()
    End Sub
End Class