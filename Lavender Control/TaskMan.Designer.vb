<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskMan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TaskMan))
        Me.ContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KillProcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.NewButton = New System.Windows.Forms.Button()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.KillButton = New System.Windows.Forms.Button()
        Me.CPUVPB = New LavenderControl.VerticalProgressBar()
        Me.RAMVPB = New LavenderControl.VerticalProgressBar()
        Me.ListView1 = New LavenderControl.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InfoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenu.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenu
        '
        Me.ContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KillProcesToolStripMenuItem})
        Me.ContextMenu.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenu, "ContextMenu")
        '
        'KillProcesToolStripMenuItem
        '
        Me.KillProcesToolStripMenuItem.Name = "KillProcesToolStripMenuItem"
        resources.ApplyResources(Me.KillProcesToolStripMenuItem, "KillProcesToolStripMenuItem")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "application.ico")
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.NewButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.RefreshButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.KillButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.CPUVPB)
        Me.FlowLayoutPanel1.Controls.Add(Me.RAMVPB)
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'NewButton
        '
        Me.NewButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NewButton.FlatAppearance.BorderSize = 0
        Me.NewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.NewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.NewButton, "NewButton")
        Me.NewButton.ForeColor = System.Drawing.SystemColors.Control
        Me.NewButton.Image = Global.LavenderControl.My.Resources.Resources.plus
        Me.NewButton.Name = "NewButton"
        Me.NewButton.UseVisualStyleBackColor = False
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
        'KillButton
        '
        Me.KillButton.BackColor = System.Drawing.Color.Maroon
        Me.KillButton.FlatAppearance.BorderSize = 0
        Me.KillButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.KillButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.KillButton, "KillButton")
        Me.KillButton.ForeColor = System.Drawing.SystemColors.Control
        Me.KillButton.Image = Global.LavenderControl.My.Resources.Resources.cross_script
        Me.KillButton.Name = "KillButton"
        Me.KillButton.UseVisualStyleBackColor = False
        '
        'CPUVPB
        '
        Me.CPUVPB.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CPUVPB.ForeColor = System.Drawing.Color.DodgerBlue
        resources.ApplyResources(Me.CPUVPB, "CPUVPB")
        Me.CPUVPB.Name = "CPUVPB"
        '
        'RAMVPB
        '
        Me.RAMVPB.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RAMVPB.ForeColor = System.Drawing.Color.Purple
        resources.ApplyResources(Me.RAMVPB, "RAMVPB")
        Me.RAMVPB.Name = "RAMVPB"
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.ContextMenuStrip = Me.ContextMenu
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("ListView1.Groups"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListView1.Groups1"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("ListView1.Groups2"), System.Windows.Forms.ListViewGroup)})
        Me.ListView1.HideSelection = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.ShowItemToolTips = True
        Me.ListView1.SmallImageList = Me.ImageList1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'ColumnHeader6
        '
        resources.ApplyResources(Me.ColumnHeader6, "ColumnHeader6")
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'ColumnHeader5
        '
        resources.ApplyResources(Me.ColumnHeader5, "ColumnHeader5")
        '
        'Label1
        '
        Me.Label1.Image = Global.LavenderControl.My.Resources.Resources.processor
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.Image = Global.LavenderControl.My.Resources.Resources.memory
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'InfoToolTip
        '
        Me.InfoToolTip.AutomaticDelay = 200
        Me.InfoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        '
        'TaskMan
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "TaskMan"
        Me.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemShadow
        Me.Style = MetroFramework.MetroColorStyle.Green
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ContextMenu.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As ListViewEx
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents KillProcesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents KillButton As System.Windows.Forms.Button
    Friend WithEvents NewButton As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents RAMVPB As LavenderControl.VerticalProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CPUVPB As LavenderControl.VerticalProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InfoToolTip As System.Windows.Forms.ToolTip
End Class
