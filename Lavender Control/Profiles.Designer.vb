<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Profiles))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.PrivateKeyTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PublicKeyTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProfileListBox = New System.Windows.Forms.ListBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteCurrentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PublicKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrivateKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabel = New System.Windows.Forms.ToolStripLabel()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        Me.ToolStripContainer1.BottomToolStripPanelVisible = False
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PrivateKeyTextBox)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label2)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.PublicKeyTextBox)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label1)
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.ProfileListBox)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(581, 271)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.LeftToolStripPanelVisible = False
        Me.ToolStripContainer1.Location = New System.Drawing.Point(20, 60)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.RightToolStripPanelVisible = False
        Me.ToolStripContainer1.Size = New System.Drawing.Size(581, 296)
        Me.ToolStripContainer1.TabIndex = 1
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.ToolStrip1)
        '
        'PrivateKeyTextBox
        '
        Me.PrivateKeyTextBox.BackColor = System.Drawing.Color.Black
        Me.PrivateKeyTextBox.ForeColor = System.Drawing.SystemColors.Control
        Me.PrivateKeyTextBox.Location = New System.Drawing.Point(123, 171)
        Me.PrivateKeyTextBox.Multiline = True
        Me.PrivateKeyTextBox.Name = "PrivateKeyTextBox"
        Me.PrivateKeyTextBox.ReadOnly = True
        Me.PrivateKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PrivateKeyTextBox.Size = New System.Drawing.Size(458, 100)
        Me.PrivateKeyTextBox.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Private Key"
        '
        'PublicKeyTextBox
        '
        Me.PublicKeyTextBox.BackColor = System.Drawing.Color.Black
        Me.PublicKeyTextBox.ForeColor = System.Drawing.SystemColors.Control
        Me.PublicKeyTextBox.Location = New System.Drawing.Point(120, 16)
        Me.PublicKeyTextBox.Multiline = True
        Me.PublicKeyTextBox.Name = "PublicKeyTextBox"
        Me.PublicKeyTextBox.ReadOnly = True
        Me.PublicKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.PublicKeyTextBox.Size = New System.Drawing.Size(461, 100)
        Me.PublicKeyTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(120, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Public Key"
        '
        'ProfileListBox
        '
        Me.ProfileListBox.BackColor = System.Drawing.Color.Black
        Me.ProfileListBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ProfileListBox.ForeColor = System.Drawing.SystemColors.Control
        Me.ProfileListBox.FormattingEnabled = True
        Me.ProfileListBox.Location = New System.Drawing.Point(0, 0)
        Me.ProfileListBox.Name = "ProfileListBox"
        Me.ProfileListBox.ScrollAlwaysVisible = True
        Me.ProfileListBox.Size = New System.Drawing.Size(120, 273)
        Me.ProfileListBox.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripDropDownButton2, Me.ProgressBar, Me.StatusLabel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(581, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.DeleteCurrentToolStripMenuItem, Me.RenameToolStripMenuItem, Me.ToolStripSeparator1, Me.ImportToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripDropDownButton1.Text = "Profile"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'DeleteCurrentToolStripMenuItem
        '
        Me.DeleteCurrentToolStripMenuItem.Name = "DeleteCurrentToolStripMenuItem"
        Me.DeleteCurrentToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteCurrentToolStripMenuItem.Text = "Delete"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.GenerateToolStripMenuItem, Me.ChangePasswordToolStripMenuItem})
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(40, 22)
        Me.ToolStripDropDownButton2.Text = "Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PublicKeyToolStripMenuItem, Me.PrivateKeyToolStripMenuItem})
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.CopyToolStripMenuItem.Text = "Copy to clipboard"
        '
        'PublicKeyToolStripMenuItem
        '
        Me.PublicKeyToolStripMenuItem.Name = "PublicKeyToolStripMenuItem"
        Me.PublicKeyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PublicKeyToolStripMenuItem.Text = "Public Key"
        '
        'PrivateKeyToolStripMenuItem
        '
        Me.PrivateKeyToolStripMenuItem.Name = "PrivateKeyToolStripMenuItem"
        Me.PrivateKeyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PrivateKeyToolStripMenuItem.Text = "Private Key"
        '
        'GenerateToolStripMenuItem
        '
        Me.GenerateToolStripMenuItem.Name = "GenerateToolStripMenuItem"
        Me.GenerateToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.GenerateToolStripMenuItem.Text = "Regenerate"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Enabled = False
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'ProgressBar
        '
        Me.ProgressBar.Maximum = 10
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(100, 22)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.ToolTipText = "Working..."
        Me.ProgressBar.Visible = False
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 22)
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        Me.RenameToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RenameToolStripMenuItem.Text = "Rename"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'Profiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 376)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Profiles"
        Me.Resizable = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Style = MetroFramework.MetroColorStyle.Yellow
        Me.Text = "Keypair Profile Manager"
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ProfileListBox As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteCurrentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PublicKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrivateKeyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrivateKeyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PublicKeyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents RenameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
