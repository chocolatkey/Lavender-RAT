<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Remote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Remote))
        Me.C1 = New MetroFramework.Controls.MetroComboBox()
        Me.C2 = New MetroFramework.Controls.MetroComboBox()
        Me.LinesCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.ToggleButton = New MetroFramework.Controls.MetroButton()
        Me.C = New System.Windows.Forms.NumericUpDown()
        Me.MouseCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.ControlFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.MetroLabel4 = New MetroFramework.Controls.MetroLabel()
        Me.M = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.StatsCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.KeyboardCheckBox = New MetroFramework.Controls.MetroCheckBox()
        Me.P1 = New System.Windows.Forms.PictureBox()
        CType(Me.C, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ControlFlowLayoutPanel.SuspendLayout()
        CType(Me.P1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1
        '
        Me.C1.FontSize = MetroFramework.MetroLinkSize.Small
        Me.C1.ForeColor = System.Drawing.SystemColors.Control
        Me.C1.FormattingEnabled = True
        resources.ApplyResources(Me.C1, "C1")
        Me.C1.Name = "C1"
        Me.C1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'C2
        '
        Me.C2.FontSize = MetroFramework.MetroLinkSize.Small
        Me.C2.ForeColor = System.Drawing.SystemColors.Control
        Me.C2.FormattingEnabled = True
        resources.ApplyResources(Me.C2, "C2")
        Me.C2.Name = "C2"
        Me.C2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'LinesCheckBox
        '
        Me.LinesCheckBox.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.LinesCheckBox.ForeColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.LinesCheckBox, "LinesCheckBox")
        Me.LinesCheckBox.Name = "LinesCheckBox"
        Me.LinesCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.LinesCheckBox.UseVisualStyleBackColor = True
        '
        'ToggleButton
        '
        resources.ApplyResources(Me.ToggleButton, "ToggleButton")
        Me.ToggleButton.Name = "ToggleButton"
        Me.ToggleButton.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'C
        '
        Me.C.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.C, "C")
        Me.C.ForeColor = System.Drawing.SystemColors.Desktop
        Me.C.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.C.Name = "C"
        Me.C.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'MouseCheckBox
        '
        Me.MouseCheckBox.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.MouseCheckBox.ForeColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.MouseCheckBox, "MouseCheckBox")
        Me.MouseCheckBox.Name = "MouseCheckBox"
        Me.MouseCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MouseCheckBox.UseVisualStyleBackColor = True
        '
        'ControlFlowLayoutPanel
        '
        resources.ApplyResources(Me.ControlFlowLayoutPanel, "ControlFlowLayoutPanel")
        Me.ControlFlowLayoutPanel.Controls.Add(Me.MetroLabel4)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.M)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.MetroLabel1)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.C1)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.MetroLabel2)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.C2)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.MetroLabel3)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.C)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.LinesCheckBox)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.StatsCheckBox)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.MouseCheckBox)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.KeyboardCheckBox)
        Me.ControlFlowLayoutPanel.Controls.Add(Me.ToggleButton)
        Me.ControlFlowLayoutPanel.Name = "ControlFlowLayoutPanel"
        '
        'MetroLabel4
        '
        resources.ApplyResources(Me.MetroLabel4, "MetroLabel4")
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'M
        '
        Me.M.FontSize = MetroFramework.MetroLinkSize.Small
        Me.M.ForeColor = System.Drawing.SystemColors.Control
        Me.M.FormattingEnabled = True
        resources.ApplyResources(Me.M, "M")
        Me.M.Name = "M"
        Me.M.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel1
        '
        resources.ApplyResources(Me.MetroLabel1, "MetroLabel1")
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel2
        '
        resources.ApplyResources(Me.MetroLabel2, "MetroLabel2")
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'MetroLabel3
        '
        resources.ApplyResources(Me.MetroLabel3, "MetroLabel3")
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark
        '
        'StatsCheckBox
        '
        Me.StatsCheckBox.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.StatsCheckBox.ForeColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.StatsCheckBox, "StatsCheckBox")
        Me.StatsCheckBox.Name = "StatsCheckBox"
        Me.StatsCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.StatsCheckBox.UseVisualStyleBackColor = True
        '
        'KeyboardCheckBox
        '
        Me.KeyboardCheckBox.FontSize = MetroFramework.MetroLinkSize.Medium
        Me.KeyboardCheckBox.ForeColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.KeyboardCheckBox, "KeyboardCheckBox")
        Me.KeyboardCheckBox.Name = "KeyboardCheckBox"
        Me.KeyboardCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.KeyboardCheckBox.UseVisualStyleBackColor = True
        '
        'P1
        '
        resources.ApplyResources(Me.P1, "P1")
        Me.P1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.P1.Name = "P1"
        Me.P1.TabStop = False
        '
        'Remote
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ControlFlowLayoutPanel)
        Me.Controls.Add(Me.P1)
        Me.Name = "Remote"
        Me.Style = MetroFramework.MetroColorStyle.White
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        CType(Me.C, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ControlFlowLayoutPanel.ResumeLayout(False)
        Me.ControlFlowLayoutPanel.PerformLayout()
        CType(Me.P1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents P1 As System.Windows.Forms.PictureBox
    Friend WithEvents C As System.Windows.Forms.NumericUpDown
    Friend WithEvents C1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents C2 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents LinesCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents ToggleButton As MetroFramework.Controls.MetroButton
    Friend WithEvents MouseCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents ControlFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents KeyboardCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents M As MetroFramework.Controls.MetroComboBox
    Friend WithEvents StatsCheckBox As MetroFramework.Controls.MetroCheckBox
    Friend WithEvents MetroLabel4 As MetroFramework.Controls.MetroLabel
End Class
