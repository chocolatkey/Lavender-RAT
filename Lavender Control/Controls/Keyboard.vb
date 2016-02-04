Public Class Keyboard

    Public Sub New(ByVal target As Control)
        ' This call is required by the designer.
        InitializeComponent()

        VK.Target = target
        Dim control As Control = target
        Activate()
    End Sub
    Private Sub Keyboard_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate

    End Sub

    Private Sub Keyboard_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Visible Then
            Close()
        End If
    End Sub
End Class