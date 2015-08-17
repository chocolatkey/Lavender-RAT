<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Passwords
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Passwords))
        Me.ApplicationImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ListView1 = New LavenderControl.ListViewEx()
        Me.Application = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Username = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Password = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ApplicationImageList
        '
        Me.ApplicationImageList.ImageStream = CType(resources.GetObject("ApplicationImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ApplicationImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ApplicationImageList.Images.SetKeyName(0, "FileZilla.ico")
        Me.ApplicationImageList.Images.SetKeyName(1, "No-IP.ico")
        Me.ApplicationImageList.Images.SetKeyName(2, "dyn-orb.ico")
        Me.ApplicationImageList.Images.SetKeyName(3, "key.ico")
        Me.ApplicationImageList.Images.SetKeyName(4, "firefox.ico")
        Me.ApplicationImageList.Images.SetKeyName(5, "chrome.ico")
        Me.ApplicationImageList.Images.SetKeyName(6, "msn.ico")
        Me.ApplicationImageList.Images.SetKeyName(7, "key.ico")
        Me.ApplicationImageList.Images.SetKeyName(8, "opera.ico")
        Me.ApplicationImageList.Images.SetKeyName(9, "iexplore.ico")
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Application, Me.Username, Me.Password})
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.LabelEdit = True
        Me.ListView1.Name = "ListView1"
        Me.ListView1.SmallImageList = Me.ApplicationImageList
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Application
        '
        resources.ApplyResources(Me.Application, "Application")
        '
        'Username
        '
        resources.ApplyResources(Me.Username, "Username")
        '
        'Password
        '
        resources.ApplyResources(Me.Password, "Password")
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
        'Passwords
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListView1)
        Me.MaximizeBox = False
        Me.Name = "Passwords"
        Me.Style = MetroFramework.MetroColorStyle.Purple
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As ListViewEx
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ApplicationImageList As System.Windows.Forms.ImageList
    Friend WithEvents Application As ColumnHeader
    Friend WithEvents Username As ColumnHeader
    Friend WithEvents Password As ColumnHeader
End Class
