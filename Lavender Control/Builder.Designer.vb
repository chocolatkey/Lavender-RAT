<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Builder
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
        Me.CreateButton = New MetroFramework.Controls.MetroButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CampaignLabel = New System.Windows.Forms.Label()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.PortLabel = New System.Windows.Forms.Label()
        Me.PortTextBox = New System.Windows.Forms.TextBox()
        Me.IPLabel = New System.Windows.Forms.Label()
        Me.IPTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.CopyTextBox = New System.Windows.Forms.TextBox()
        Me.CopyCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RegistryLabel = New System.Windows.Forms.Label()
        Me.RegistryTextBox = New System.Windows.Forms.TextBox()
        Me.RegistryCheckBox = New System.Windows.Forms.CheckBox()
        Me.MeltCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New MetroFramework.Controls.MetroToggle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NsRandomPool1 = New LavenderControl.NSRandomPool()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreateButton
        '
        Me.CreateButton.Location = New System.Drawing.Point(351, 413)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(267, 28)
        Me.CreateButton.TabIndex = 4
        Me.CreateButton.Text = "BUILD"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CampaignLabel)
        Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
        Me.GroupBox1.Controls.Add(Me.PasswordLabel)
        Me.GroupBox1.Controls.Add(Me.NameTextBox)
        Me.GroupBox1.Controls.Add(Me.PortLabel)
        Me.GroupBox1.Controls.Add(Me.PortTextBox)
        Me.GroupBox1.Controls.Add(Me.IPLabel)
        Me.GroupBox1.Controls.Add(Me.IPTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 195)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Connection"
        '
        'CampaignLabel
        '
        Me.CampaignLabel.AutoSize = True
        Me.CampaignLabel.Location = New System.Drawing.Point(8, 41)
        Me.CampaignLabel.Name = "CampaignLabel"
        Me.CampaignLabel.Size = New System.Drawing.Size(91, 13)
        Me.CampaignLabel.TabIndex = 9
        Me.CampaignLabel.Text = "Campaign (Name)"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Location = New System.Drawing.Point(112, 61)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(152, 20)
        Me.PasswordTextBox.TabIndex = 11
        Me.PasswordTextBox.Text = "hinki"
        '
        'PasswordLabel
        '
        Me.PasswordLabel.AutoSize = True
        Me.PasswordLabel.Location = New System.Drawing.Point(6, 64)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(53, 13)
        Me.PasswordLabel.TabIndex = 12
        Me.PasswordLabel.Text = "Password"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(112, 37)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(80, 20)
        Me.NameTextBox.TabIndex = 8
        Me.NameTextBox.Text = "Lav"
        '
        'PortLabel
        '
        Me.PortLabel.AutoSize = True
        Me.PortLabel.Location = New System.Drawing.Point(195, 41)
        Me.PortLabel.Name = "PortLabel"
        Me.PortLabel.Size = New System.Drawing.Size(26, 13)
        Me.PortLabel.TabIndex = 7
        Me.PortLabel.Text = "Port"
        '
        'PortTextBox
        '
        Me.PortTextBox.Location = New System.Drawing.Point(227, 37)
        Me.PortTextBox.Name = "PortTextBox"
        Me.PortTextBox.Size = New System.Drawing.Size(37, 20)
        Me.PortTextBox.TabIndex = 6
        Me.PortTextBox.Text = "92"
        '
        'IPLabel
        '
        Me.IPLabel.AutoSize = True
        Me.IPLabel.Location = New System.Drawing.Point(8, 17)
        Me.IPLabel.Name = "IPLabel"
        Me.IPLabel.Size = New System.Drawing.Size(73, 13)
        Me.IPLabel.TabIndex = 5
        Me.IPLabel.Text = "IP/Host name"
        '
        'IPTextBox
        '
        Me.IPTextBox.Location = New System.Drawing.Point(112, 14)
        Me.IPTextBox.Name = "IPTextBox"
        Me.IPTextBox.Size = New System.Drawing.Size(152, 20)
        Me.IPTextBox.TabIndex = 4
        Me.IPTextBox.Text = "127.0.0.1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NameLabel)
        Me.GroupBox2.Controls.Add(Me.CopyTextBox)
        Me.GroupBox2.Controls.Add(Me.CopyCheckBox)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 270)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(269, 139)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Copy/Backup Server to Host"
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(80, 20)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(35, 13)
        Me.NameLabel.TabIndex = 6
        Me.NameLabel.Text = "Name"
        '
        'CopyTextBox
        '
        Me.CopyTextBox.Location = New System.Drawing.Point(121, 17)
        Me.CopyTextBox.Name = "CopyTextBox"
        Me.CopyTextBox.Size = New System.Drawing.Size(96, 20)
        Me.CopyTextBox.TabIndex = 2
        Me.CopyTextBox.Text = "svchost"
        '
        'CopyCheckBox
        '
        Me.CopyCheckBox.AutoSize = True
        Me.CopyCheckBox.Location = New System.Drawing.Point(6, 19)
        Me.CopyCheckBox.Name = "CopyCheckBox"
        Me.CopyCheckBox.Size = New System.Drawing.Size(50, 17)
        Me.CopyCheckBox.TabIndex = 0
        Me.CopyCheckBox.Text = "Copy"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RegistryLabel)
        Me.GroupBox3.Controls.Add(Me.RegistryTextBox)
        Me.GroupBox3.Controls.Add(Me.RegistryCheckBox)
        Me.GroupBox3.Location = New System.Drawing.Point(460, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(158, 60)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Startup/Registry/Exceptions"
        '
        'RegistryLabel
        '
        Me.RegistryLabel.AutoSize = True
        Me.RegistryLabel.Location = New System.Drawing.Point(6, 37)
        Me.RegistryLabel.Name = "RegistryLabel"
        Me.RegistryLabel.Size = New System.Drawing.Size(56, 13)
        Me.RegistryLabel.TabIndex = 10
        Me.RegistryLabel.Text = "Key Name"
        '
        'RegistryTextBox
        '
        Me.RegistryTextBox.Location = New System.Drawing.Point(68, 34)
        Me.RegistryTextBox.Name = "RegistryTextBox"
        Me.RegistryTextBox.Size = New System.Drawing.Size(68, 20)
        Me.RegistryTextBox.TabIndex = 9
        Me.RegistryTextBox.Text = "Update"
        '
        'RegistryCheckBox
        '
        Me.RegistryCheckBox.AutoSize = True
        Me.RegistryCheckBox.Location = New System.Drawing.Point(9, 15)
        Me.RegistryCheckBox.Name = "RegistryCheckBox"
        Me.RegistryCheckBox.Size = New System.Drawing.Size(45, 17)
        Me.RegistryCheckBox.TabIndex = 8
        Me.RegistryCheckBox.Text = "Add"
        '
        'MeltCheckBox
        '
        Me.MeltCheckBox.AutoSize = True
        Me.MeltCheckBox.Location = New System.Drawing.Point(510, 206)
        Me.MeltCheckBox.Name = "MeltCheckBox"
        Me.MeltCheckBox.Size = New System.Drawing.Size(77, 17)
        Me.MeltCheckBox.TabIndex = 9
        Me.MeltCheckBox.Text = "Melt (Hide)"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(460, 183)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 17)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Text = "Off"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(497, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Button1"
        '
        'NsRandomPool1
        '
        Me.NsRandomPool1.Location = New System.Drawing.Point(376, 248)
        Me.NsRandomPool1.Name = "NsRandomPool1"
        Me.NsRandomPool1.Size = New System.Drawing.Size(211, 142)
        Me.NsRandomPool1.TabIndex = 16
        Me.NsRandomPool1.Text = "NsRandomPool1"
        '
        'Builder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 464)
        Me.Controls.Add(Me.NsRandomPool1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.MeltCheckBox)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CreateButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Builder"
        Me.Resizable = False
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Style = MetroFramework.MetroColorStyle.Purple
        Me.Text = "Payload Builder"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CreateButton As MetroFramework.Controls.MetroButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CampaignLabel As System.Windows.Forms.Label
    Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PortLabel As System.Windows.Forms.Label
    Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IPLabel As System.Windows.Forms.Label
    Friend WithEvents IPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents CopyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CopyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RegistryLabel As System.Windows.Forms.Label
    Friend WithEvents RegistryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents RegistryCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MeltCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As MetroFramework.Controls.MetroToggle
    Friend WithEvents Button1 As Button
    Friend WithEvents NsRandomPool1 As NSRandomPool
End Class
