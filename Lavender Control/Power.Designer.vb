<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Power
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Power))
        Me.PowerPanel = New MetroFramework.Controls.MetroPanel()
        Me.LogoutButton = New System.Windows.Forms.Button()
        Me.LockButton = New System.Windows.Forms.Button()
        Me.SleepButton = New System.Windows.Forms.Button()
        Me.RestartButton = New System.Windows.Forms.Button()
        Me.ShutdownButton = New System.Windows.Forms.Button()
        Me.DatePicker = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SecondsTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ForceCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.NowCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.SecondT = New System.Windows.Forms.Timer(Me.components)
        Me.PowerPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PowerPanel
        '
        Me.PowerPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.PowerPanel.Controls.Add(Me.LogoutButton)
        Me.PowerPanel.Controls.Add(Me.LockButton)
        Me.PowerPanel.Controls.Add(Me.SleepButton)
        Me.PowerPanel.Controls.Add(Me.RestartButton)
        Me.PowerPanel.Controls.Add(Me.ShutdownButton)
        Me.PowerPanel.HorizontalScrollbarBarColor = True
        Me.PowerPanel.HorizontalScrollbarHighlightOnWheel = False
        Me.PowerPanel.HorizontalScrollbarSize = 10
        Me.PowerPanel.Location = New System.Drawing.Point(23, 63)
        Me.PowerPanel.Name = "PowerPanel"
        Me.PowerPanel.Size = New System.Drawing.Size(133, 216)
        Me.PowerPanel.TabIndex = 6
        Me.PowerPanel.VerticalScrollbarBarColor = True
        Me.PowerPanel.VerticalScrollbarHighlightOnWheel = False
        Me.PowerPanel.VerticalScrollbarSize = 10
        '
        'LogoutButton
        '
        Me.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogoutButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LogoutButton.ForeColor = System.Drawing.SystemColors.Control
        Me.LogoutButton.Image = CType(resources.GetObject("LogoutButton.Image"), System.Drawing.Image)
        Me.LogoutButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LogoutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LogoutButton.Location = New System.Drawing.Point(3, 129)
        Me.LogoutButton.Name = "LogoutButton"
        Me.LogoutButton.Size = New System.Drawing.Size(127, 42)
        Me.LogoutButton.TabIndex = 7
        Me.LogoutButton.Text = "Lo&g Off"
        Me.LogoutButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'LockButton
        '
        Me.LockButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LockButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LockButton.ForeColor = System.Drawing.SystemColors.Control
        Me.LockButton.Image = Global.LavenderControl.My.Resources.Resources.lock1
        Me.LockButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LockButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LockButton.Location = New System.Drawing.Point(3, 171)
        Me.LockButton.Name = "LockButton"
        Me.LockButton.Size = New System.Drawing.Size(127, 42)
        Me.LockButton.TabIndex = 6
        Me.LockButton.Text = "&Lock"
        Me.LockButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'SleepButton
        '
        Me.SleepButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SleepButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.SleepButton.ForeColor = System.Drawing.SystemColors.Control
        Me.SleepButton.Image = CType(resources.GetObject("SleepButton.Image"), System.Drawing.Image)
        Me.SleepButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SleepButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SleepButton.Location = New System.Drawing.Point(3, 87)
        Me.SleepButton.Name = "SleepButton"
        Me.SleepButton.Size = New System.Drawing.Size(127, 42)
        Me.SleepButton.TabIndex = 5
        Me.SleepButton.Text = "Slee&p"
        Me.SleepButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'RestartButton
        '
        Me.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RestartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.RestartButton.ForeColor = System.Drawing.SystemColors.Control
        Me.RestartButton.Image = CType(resources.GetObject("RestartButton.Image"), System.Drawing.Image)
        Me.RestartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RestartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RestartButton.Location = New System.Drawing.Point(3, 45)
        Me.RestartButton.Name = "RestartButton"
        Me.RestartButton.Size = New System.Drawing.Size(127, 42)
        Me.RestartButton.TabIndex = 4
        Me.RestartButton.Text = "&Restart"
        Me.RestartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'ShutdownButton
        '
        Me.ShutdownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShutdownButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.ShutdownButton.ForeColor = System.Drawing.SystemColors.Control
        Me.ShutdownButton.Image = CType(resources.GetObject("ShutdownButton.Image"), System.Drawing.Image)
        Me.ShutdownButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ShutdownButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ShutdownButton.Location = New System.Drawing.Point(3, 3)
        Me.ShutdownButton.Name = "ShutdownButton"
        Me.ShutdownButton.Size = New System.Drawing.Size(127, 42)
        Me.ShutdownButton.TabIndex = 3
        Me.ShutdownButton.Text = "&Shutdown"
        Me.ShutdownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'DatePicker
        '
        Me.DatePicker.CustomFormat = "yyyy/MM/dd hh:mm:ss tt"
        Me.DatePicker.Enabled = False
        Me.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DatePicker.Location = New System.Drawing.Point(6, 71)
        Me.DatePicker.Name = "DatePicker"
        Me.DatePicker.ShowUpDown = True
        Me.DatePicker.Size = New System.Drawing.Size(187, 20)
        Me.DatePicker.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AbortButton)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.SecondsTextBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ForceCheckBox)
        Me.GroupBox1.Controls.Add(Me.NowCheckBox)
        Me.GroupBox1.Controls.Add(Me.DatePicker)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Location = New System.Drawing.Point(162, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 174)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options (Shutdown && Restart)"
        '
        'AbortButton
        '
        Me.AbortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AbortButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.AbortButton.ForeColor = System.Drawing.SystemColors.Control
        Me.AbortButton.Image = Global.LavenderControl.My.Resources.Resources.cross_circle_frame
        Me.AbortButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AbortButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AbortButton.Location = New System.Drawing.Point(6, 138)
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.Size = New System.Drawing.Size(187, 30)
        Me.AbortButton.TabIndex = 10
        Me.AbortButton.Text = "&Abort planned shutdowns"
        Me.AbortButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "seconds"
        '
        'SecondsTextBox
        '
        Me.SecondsTextBox.Enabled = False
        Me.SecondsTextBox.Location = New System.Drawing.Point(28, 99)
        Me.SecondsTextBox.Name = "SecondsTextBox"
        Me.SecondsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SecondsTextBox.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "In"
        '
        'ForceCheckBox
        '
        Me.ForceCheckBox.AutoSize = True
        Me.ForceCheckBox.Checked = True
        Me.ForceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ForceCheckBox.Location = New System.Drawing.Point(6, 21)
        Me.ForceCheckBox.Name = "ForceCheckBox"
        Me.ForceCheckBox.Size = New System.Drawing.Size(52, 15)
        Me.ForceCheckBox.Style = MetroFramework.MetroColorStyle.White
        Me.ForceCheckBox.TabIndex = 11
        Me.ForceCheckBox.Text = "&Force"
        Me.ForceCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ForceCheckBox.UseSelectable = True
        Me.ForceCheckBox.UseStyleColors = True
        '
        'NowCheckBox
        '
        Me.NowCheckBox.AutoSize = True
        Me.NowCheckBox.Checked = True
        Me.NowCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.NowCheckBox.Location = New System.Drawing.Point(6, 50)
        Me.NowCheckBox.Name = "NowCheckBox"
        Me.NowCheckBox.Size = New System.Drawing.Size(48, 15)
        Me.NowCheckBox.Style = MetroFramework.MetroColorStyle.White
        Me.NowCheckBox.TabIndex = 10
        Me.NowCheckBox.Text = "&Now"
        Me.NowCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.NowCheckBox.UseSelectable = True
        Me.NowCheckBox.UseStyleColors = True
        '
        'SecondT
        '
        Me.SecondT.Enabled = True
        Me.SecondT.Interval = 1000
        '
        'Power
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 297)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PowerPanel)
        Me.Name = "Power"
        Me.Resizable = False
        Me.Text = "Power - "
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.PowerPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PowerPanel As MetroFramework.Controls.MetroPanel
    Friend WithEvents LogoutButton As Button
    Friend WithEvents LockButton As Button
    Friend WithEvents SleepButton As Button
    Friend WithEvents RestartButton As Button
    Friend WithEvents ShutdownButton As Button
    Friend WithEvents DatePicker As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents NowCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents ForceCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents AbortButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SecondsTextBox As TextBox
    Friend WithEvents SecondT As Timer
End Class
