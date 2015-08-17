<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Shell
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shell))
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.CommandTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'OutputTextBox
        '
        Me.OutputTextBox.BackColor = System.Drawing.SystemColors.Desktop
        Me.OutputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.OutputTextBox, "OutputTextBox")
        Me.OutputTextBox.ForeColor = System.Drawing.SystemColors.Window
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.ReadOnly = True
        '
        'CommandTextBox
        '
        Me.CommandTextBox.BackColor = System.Drawing.SystemColors.Desktop
        Me.CommandTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CommandTextBox.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.CommandTextBox, "CommandTextBox")
        Me.CommandTextBox.Name = "CommandTextBox"
        '
        'Shell
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CommandTextBox)
        Me.Controls.Add(Me.OutputTextBox)
        Me.MaximizeBox = False
        Me.Name = "Shell"
        Me.Style = MetroFramework.MetroColorStyle.Black
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents OutputTextBox As TextBox
    Friend WithEvents CommandTextBox As TextBox
End Class
