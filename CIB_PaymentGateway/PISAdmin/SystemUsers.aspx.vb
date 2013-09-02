Imports Controller
Imports Model

Public Class SystemUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gv.DataSource = SystemUserBLL.List()
        gv.DataBind()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim objUser As New SystemUser
        With objUser
            .CIBEmployeeID = Integer.Parse(txtCIBEmployeeID.Text)
            .Comment = txtComments.Text
            .EmailAddress = txtEmailAddress.Text
            .FirstName = txtFirstName.Text
            .LastName = txtLastName.Text
            .Password = txtPassword.Text
            .SignatureURL = txtSignatureURL.Text
            .Title = txtTitle.Text
            .UserLevel = DDLUserLevel.SelectedValue
        End With
        SystemUserBLL.Insert(objUser)
    End Sub
End Class