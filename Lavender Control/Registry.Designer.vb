<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Registry
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_CLASSES_ROOT")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_CURRENT_USER")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_LOCAL_MACHINE")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("HKEY_USERS")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Registry))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListViewEx1 = New LavenderControl.ListViewEx()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RegImageList = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.RegImageList
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "HKEY_CLASSES_ROOT"
        TreeNode1.Text = "HKEY_CLASSES_ROOT"
        TreeNode2.Name = "HKEY_CURRENT_USER"
        TreeNode2.Text = "HKEY_CURRENT_USER"
        TreeNode3.Name = "HKEY_LOCAL_MACHINE"
        TreeNode3.Text = "HKEY_LOCAL_MACHINE"
        TreeNode4.Name = "HKEY_USERS"
        TreeNode4.Text = "HKEY_USERS"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(198, 379)
        Me.TreeView1.TabIndex = 0
        '
        'ListViewEx1
        '
        Me.ListViewEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewEx1.Location = New System.Drawing.Point(0, 0)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(496, 379)
        Me.ListViewEx1.TabIndex = 1
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(20, 60)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewEx1)
        Me.SplitContainer1.Size = New System.Drawing.Size(698, 379)
        Me.SplitContainer1.SplitterDistance = 198
        Me.SplitContainer1.TabIndex = 2
        '
        'RegImageList
        '
        Me.RegImageList.ImageStream = CType(resources.GetObject("RegImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.RegImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.RegImageList.Images.SetKeyName(0, "folder.ico")
        '
        'Registry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 459)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Registry"
        Me.Style = MetroFramework.MetroColorStyle.Teal
        Me.Text = "Registry - "
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ListViewEx1 As ListViewEx
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents RegImageList As ImageList
End Class
