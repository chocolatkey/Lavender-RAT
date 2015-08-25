<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileManager))
        Me.DirTextBox = New System.Windows.Forms.TextBox()
        Me.FileContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExecuteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.SmallImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.NavigationPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.UpButton = New System.Windows.Forms.Button()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.HomeButton = New System.Windows.Forms.Button()
        Me.GoButton = New System.Windows.Forms.Button()
        Me.ImgListL = New System.Windows.Forms.ImageList(Me.components)
        Me.ImgListS = New System.Windows.Forms.ImageList(Me.components)
        Me.FileListView = New LavenderControl.ListViewEx()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.InfoToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FileContextMenuStrip.SuspendLayout()
        Me.NavigationPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'DirTextBox
        '
        resources.ApplyResources(Me.DirTextBox, "DirTextBox")
        Me.DirTextBox.Name = "DirTextBox"
        Me.InfoToolTip.SetToolTip(Me.DirTextBox, resources.GetString("DirTextBox.ToolTip"))
        '
        'FileContextMenuStrip
        '
        Me.FileContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExecuteToolStripMenuItem, Me.RenameToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator1, Me.ViewToolStripMenuItem})
        Me.FileContextMenuStrip.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.FileContextMenuStrip, "FileContextMenuStrip")
        '
        'ExecuteToolStripMenuItem
        '
        Me.ExecuteToolStripMenuItem.Name = "ExecuteToolStripMenuItem"
        resources.ApplyResources(Me.ExecuteToolStripMenuItem, "ExecuteToolStripMenuItem")
        '
        'RenameToolStripMenuItem
        '
        Me.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem"
        resources.ApplyResources(Me.RenameToolStripMenuItem, "RenameToolStripMenuItem")
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        resources.ApplyResources(Me.DeleteToolStripMenuItem, "DeleteToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailsToolStripMenuItem, Me.ListToolStripMenuItem, Me.TilesToolStripMenuItem, Me.SmallIconsToolStripMenuItem, Me.LargeIconsToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        resources.ApplyResources(Me.ViewToolStripMenuItem, "ViewToolStripMenuItem")
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        resources.ApplyResources(Me.DetailsToolStripMenuItem, "DetailsToolStripMenuItem")
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        resources.ApplyResources(Me.ListToolStripMenuItem, "ListToolStripMenuItem")
        '
        'TilesToolStripMenuItem
        '
        Me.TilesToolStripMenuItem.Name = "TilesToolStripMenuItem"
        resources.ApplyResources(Me.TilesToolStripMenuItem, "TilesToolStripMenuItem")
        '
        'SmallIconsToolStripMenuItem
        '
        Me.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem"
        resources.ApplyResources(Me.SmallIconsToolStripMenuItem, "SmallIconsToolStripMenuItem")
        '
        'LargeIconsToolStripMenuItem
        '
        Me.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem"
        resources.ApplyResources(Me.LargeIconsToolStripMenuItem, "LargeIconsToolStripMenuItem")
        '
        'LargeImageList
        '
        Me.LargeImageList.ImageStream = CType(resources.GetObject("LargeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.LargeImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.LargeImageList.Images.SetKeyName(0, "drive.ico")
        Me.LargeImageList.Images.SetKeyName(1, "diskdrive.ico")
        Me.LargeImageList.Images.SetKeyName(2, "folder.ico")
        Me.LargeImageList.Images.SetKeyName(3, "application.ico")
        Me.LargeImageList.Images.SetKeyName(4, "zip.ico")
        Me.LargeImageList.Images.SetKeyName(5, "text.ico")
        Me.LargeImageList.Images.SetKeyName(6, "dll.ico")
        Me.LargeImageList.Images.SetKeyName(7, "docl2.ico")
        Me.LargeImageList.Images.SetKeyName(8, "jpg.ico")
        Me.LargeImageList.Images.SetKeyName(9, "gif.ico")
        Me.LargeImageList.Images.SetKeyName(10, "png.ico")
        Me.LargeImageList.Images.SetKeyName(11, "bmp.ico")
        Me.LargeImageList.Images.SetKeyName(12, "word.ico")
        Me.LargeImageList.Images.SetKeyName(13, "powerpoint.ico")
        Me.LargeImageList.Images.SetKeyName(14, "excel.ico")
        Me.LargeImageList.Images.SetKeyName(15, "PDF.ico")
        Me.LargeImageList.Images.SetKeyName(16, "media.ico")
        Me.LargeImageList.Images.SetKeyName(17, "java.ico")
        Me.LargeImageList.Images.SetKeyName(18, "batch.ico")
        Me.LargeImageList.Images.SetKeyName(19, "storage.ico")
        '
        'SmallImageList
        '
        Me.SmallImageList.ImageStream = CType(resources.GetObject("SmallImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SmallImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.SmallImageList.Images.SetKeyName(0, "drive.ico")
        Me.SmallImageList.Images.SetKeyName(1, "diskdrive.ico")
        Me.SmallImageList.Images.SetKeyName(2, "folder.ico")
        Me.SmallImageList.Images.SetKeyName(3, "application.ico")
        Me.SmallImageList.Images.SetKeyName(4, "zip.ico")
        Me.SmallImageList.Images.SetKeyName(5, "text.ico")
        Me.SmallImageList.Images.SetKeyName(6, "dll.ico")
        Me.SmallImageList.Images.SetKeyName(7, "docl2.ico")
        Me.SmallImageList.Images.SetKeyName(8, "jpg.ico")
        Me.SmallImageList.Images.SetKeyName(9, "gif.ico")
        Me.SmallImageList.Images.SetKeyName(10, "png.ico")
        Me.SmallImageList.Images.SetKeyName(11, "bmp.ico")
        Me.SmallImageList.Images.SetKeyName(12, "word.ico")
        Me.SmallImageList.Images.SetKeyName(13, "powerpoint.ico")
        Me.SmallImageList.Images.SetKeyName(14, "excel.ico")
        Me.SmallImageList.Images.SetKeyName(15, "PDF.ico")
        Me.SmallImageList.Images.SetKeyName(16, "media.ico")
        Me.SmallImageList.Images.SetKeyName(17, "java.ico")
        Me.SmallImageList.Images.SetKeyName(18, "batch.ico")
        Me.SmallImageList.Images.SetKeyName(19, "storage.ico")
        '
        'NavigationPanel
        '
        Me.NavigationPanel.Controls.Add(Me.UpButton)
        Me.NavigationPanel.Controls.Add(Me.RefreshButton)
        Me.NavigationPanel.Controls.Add(Me.HomeButton)
        Me.NavigationPanel.Controls.Add(Me.DirTextBox)
        Me.NavigationPanel.Controls.Add(Me.GoButton)
        resources.ApplyResources(Me.NavigationPanel, "NavigationPanel")
        Me.NavigationPanel.Name = "NavigationPanel"
        '
        'UpButton
        '
        Me.UpButton.BackColor = System.Drawing.Color.Maroon
        Me.UpButton.FlatAppearance.BorderSize = 0
        Me.UpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.UpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.UpButton, "UpButton")
        Me.UpButton.ForeColor = System.Drawing.SystemColors.Control
        Me.UpButton.Image = Global.LavenderControl.My.Resources.Resources.arrow_090_medium
        Me.UpButton.Name = "UpButton"
        Me.InfoToolTip.SetToolTip(Me.UpButton, resources.GetString("UpButton.ToolTip"))
        Me.UpButton.UseVisualStyleBackColor = False
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
        Me.InfoToolTip.SetToolTip(Me.RefreshButton, resources.GetString("RefreshButton.ToolTip"))
        Me.RefreshButton.UseVisualStyleBackColor = False
        '
        'HomeButton
        '
        Me.HomeButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.HomeButton.FlatAppearance.BorderSize = 0
        Me.HomeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.HomeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.HomeButton, "HomeButton")
        Me.HomeButton.ForeColor = System.Drawing.SystemColors.Control
        Me.HomeButton.Image = Global.LavenderControl.My.Resources.Resources.home
        Me.HomeButton.Name = "HomeButton"
        Me.InfoToolTip.SetToolTip(Me.HomeButton, resources.GetString("HomeButton.ToolTip"))
        Me.HomeButton.UseVisualStyleBackColor = False
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GoButton.FlatAppearance.BorderSize = 0
        Me.GoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.GoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.GoButton, "GoButton")
        Me.GoButton.ForeColor = System.Drawing.SystemColors.Control
        Me.GoButton.Name = "GoButton"
        Me.InfoToolTip.SetToolTip(Me.GoButton, resources.GetString("GoButton.ToolTip"))
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'ImgListL
        '
        Me.ImgListL.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImgListL, "ImgListL")
        Me.ImgListL.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImgListS
        '
        Me.ImgListS.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.ImgListS, "ImgListS")
        Me.ImgListS.TransparentColor = System.Drawing.Color.Transparent
        '
        'FileListView
        '
        resources.ApplyResources(Me.FileListView, "FileListView")
        Me.FileListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.FileListView.ContextMenuStrip = Me.FileContextMenuStrip
        Me.FileListView.FullRowSelect = True
        Me.FileListView.GridLines = True
        Me.FileListView.LargeImageList = Me.ImgListL
        Me.FileListView.MultiSelect = False
        Me.FileListView.Name = "FileListView"
        Me.FileListView.SmallImageList = Me.ImgListL
        Me.FileListView.UseCompatibleStateImageBehavior = False
        Me.FileListView.View = System.Windows.Forms.View.Details
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
        'FileManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NavigationPanel)
        Me.Controls.Add(Me.FileListView)
        Me.Name = "FileManager"
        Me.Style = MetroFramework.MetroColorStyle.Red
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.FileContextMenuStrip.ResumeLayout(False)
        Me.NavigationPanel.ResumeLayout(False)
        Me.NavigationPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DirTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FileListView As ListViewEx
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents SmallImageList As System.Windows.Forms.ImageList
    Friend WithEvents FileContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExecuteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents NavigationPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents UpButton As System.Windows.Forms.Button
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents GoButton As System.Windows.Forms.Button
    Friend WithEvents HomeButton As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents ImgListL As System.Windows.Forms.ImageList
    Friend WithEvents ImgListS As System.Windows.Forms.ImageList
    Friend WithEvents InfoToolTip As System.Windows.Forms.ToolTip
End Class
