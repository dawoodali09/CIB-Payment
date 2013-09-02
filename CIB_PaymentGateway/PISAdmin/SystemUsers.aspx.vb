Imports Controller
Imports Model

Public Class SystemUsers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindSystemUsers()
        End If
    End Sub

    Sub bindSystemUsers()
        gv.DataSource = SystemUserBLL.List()
        gv.DataBind()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim objUser As New SystemUser
        If (btnAdd.Text = "ADD") Then
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
            txtCIBEmployeeID.Text = ""
            txtComments.Text = ""
            txtEmailAddress.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtPassword.Text = ""
            txtSignatureURL.Text = ""
            txtTitle.Text = ""
            bindSystemUsers()
            divAddEdit.Visible = False
            gv.Visible = True
            lbtn.Text = "ADD"
            litCaption.Text = "System Users"

        ElseIf btnAdd.Text = "UPDATE" Then

            objUser = SystemUserBLL.GetByID(Integer.Parse(Session("CurrentID")))
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
            SystemUserBLL.Update(objUser)
            txtCIBEmployeeID.Text = ""
            txtComments.Text = ""
            txtEmailAddress.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtPassword.Text = ""
            txtSignatureURL.Text = ""
            txtTitle.Text = ""
            bindSystemUsers()
            divAddEdit.Visible = False
            gv.Visible = True
            lbtn.Text = "ADD"
            litCaption.Text = "System Users"

        End If

        

    End Sub

    Function GetName(ByVal ID) As String
        Dim CompleteName As String = ""
        Dim user As New SystemUser
        user = SystemUserBLL.GetByID(ID)
        CompleteName = user.FirstName + " " + user.LastName
        Return CompleteName
    End Function

    Protected Sub lbtn_Click(sender As Object, e As EventArgs) Handles lbtn.Click
        txtCIBEmployeeID.Text = ""
        txtComments.Text = ""
        txtEmailAddress.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtPassword.Text = ""
        txtSignatureURL.Text = ""
        txtTitle.Text = ""
        txtPassword.TextMode = TextBoxMode.Password
        txtEmailAddress.Enabled = True

        If lbtn.Text = "ADD" Then
            divAddEdit.Visible = True
            gv.Visible = False
            lbtn.Text = "LIST ALL"
            litCaption.Text = "Add New System User"
        Else
            divAddEdit.Visible = False
            gv.Visible = True
            lbtn.Text = "ADD"
            litCaption.Text = "System Users"
        End If

    End Sub

    Protected Sub gv_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gv.RowCommand

        If (e.CommandName.ToLower().Contains("editrecord")) Then
            Dim user = SystemUserBLL.GetByID(Integer.Parse(e.CommandArgument))
            With user
                txtCIBEmployeeID.Text = .CIBEmployeeID
                txtComments.Text = .Comment
                txtEmailAddress.Text = .EmailAddress
                txtFirstName.Text = .FirstName
                txtLastName.Text = .LastName
                txtPassword.TextMode = TextBoxMode.SingleLine
                txtPassword.Text = .Password
                txtSignatureURL.Text = .SignatureURL
                txtTitle.Text = .Title
                DDLUserLevel.SelectedValue = .UserLevel
                Session("CurrentID") = .ID
                txtEmailAddress.Enabled = False
            End With
            divAddEdit.Visible = True
            gv.Visible = False
            lbtn.Text = "LIST ALL"
            litCaption.Text = "Edit System User"
            btnAdd.Text = "UPDATE"

        ElseIf (e.CommandName.ToLower().Contains("deleterecord")) Then

        End If

    End Sub
End Class