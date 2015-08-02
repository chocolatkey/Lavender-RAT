Imports System.IO

Public NotInheritable Class About

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ''Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.Text = "About Lavender"
        ' Initialize all of the text displayed on the About Box.
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
        Dim LicenseFile As String = My.Application.Info.DirectoryPath + Path.DirectorySeparatorChar + "License.txt"
        If File.Exists(LicenseFile) Then
            Me.TextBoxDescription.Text = "LICENSES" + Environment.NewLine + "=============================" + Environment.NewLine + File.ReadAllText(LicenseFile)
        Else
            Me.TextBoxDescription.Text = "License File missing!" + Environment.NewLine + LicenseFile
        End If
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
