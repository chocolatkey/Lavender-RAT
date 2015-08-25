<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyLogger
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KeyLogger))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.RefreshButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.OpenButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.ClearButton)
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'RefreshButton
        '
        Me.RefreshButton.BackColor = System.Drawing.Color.Teal
        Me.RefreshButton.FlatAppearance.BorderSize = 0
        Me.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.RefreshButton, "RefreshButton")
        Me.RefreshButton.ForeColor = System.Drawing.SystemColors.Control
        Me.RefreshButton.Image = Global.LavenderControl.My.Resources.Resources.arrow_circle_double_135
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.UseVisualStyleBackColor = False
        '
        'OpenButton
        '
        Me.OpenButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.OpenButton.FlatAppearance.BorderSize = 0
        Me.OpenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.OpenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.OpenButton, "OpenButton")
        Me.OpenButton.ForeColor = System.Drawing.SystemColors.Control
        Me.OpenButton.Image = Global.LavenderControl.My.Resources.Resources.globe__arrow
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.UseVisualStyleBackColor = False
        '
        'ClearButton
        '
        Me.ClearButton.BackColor = System.Drawing.Color.Maroon
        Me.ClearButton.FlatAppearance.BorderSize = 0
        Me.ClearButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.ClearButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.ClearButton, "ClearButton")
        Me.ClearButton.ForeColor = System.Drawing.SystemColors.Control
        Me.ClearButton.Image = Global.LavenderControl.My.Resources.Resources.bin_metal_full
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.UseVisualStyleBackColor = False
        '
        'WebBrowser
        '
        Me.WebBrowser.AllowWebBrowserDrop = False
        resources.ApplyResources(Me.WebBrowser, "WebBrowser")
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.ScriptErrorsSuppressed = True
        Me.WebBrowser.Url = New System.Uri("", System.UriKind.Relative)
        Me.WebBrowser.WebBrowserShortcutsEnabled = False
        '
        'KeyLogger
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WebBrowser)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Name = "KeyLogger"
        Me.Style = MetroFramework.MetroColorStyle.Orange
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents ClearButton As System.Windows.Forms.Button
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents OpenButton As System.Windows.Forms.Button
End Class
