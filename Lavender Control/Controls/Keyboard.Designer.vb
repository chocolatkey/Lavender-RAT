<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Keyboard
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VK = New LavenderControl.NSKeyboard()
        Me.SuspendLayout()
        '
        'VK
        '
        Me.VK.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.VK.Location = New System.Drawing.Point(2, 6)
        Me.VK.MaximumSize = New System.Drawing.Size(386, 162)
        Me.VK.MinimumSize = New System.Drawing.Size(386, 162)
        Me.VK.Name = "VK"
        Me.VK.Size = New System.Drawing.Size(386, 162)
        Me.VK.TabIndex = 0
        Me.VK.Target = Nothing
        Me.VK.Text = "NsKeyboard1"
        '
        'Keyboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.VK)
        Me.DisplayHeader = False
        Me.Name = "Keyboard"
        Me.Padding = New System.Windows.Forms.Padding(20, 30, 20, 20)
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Keyboard"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VK As NSKeyboard
End Class
