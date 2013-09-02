Imports System.Collections
Imports Controller.Controller

Public Class signupconfirmation
    Inherits System.Web.UI.Page
    Dim objConfirm As clsContract

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Server.Transfer("usersignup.aspx")
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim obj As New clsContract()

        Dim objbll As New ControlEngine()
        Dim i As Integer = objbll.InsertUserDetails(Session("ConfirmUserInfo"))

        If i <> -1 Then
            Session("dispMessage") = 1
        Else
            Session("dispMessage") = 0
        End If
        Server.Transfer("displayInfoMessage.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (Not Session("ConfirmUserInfo") Is Nothing) Then
                Dim objConfirm As clsContract
                objConfirm = Session("ConfirmUserInfo")
                txtemailaddress.Text = objConfirm.Email
                txtpassword.Text = objConfirm.Password
                txtconfirmpassword.Text = objConfirm.Password
                txtFirstName.Text = objConfirm.FirstName
                txtLastName.Text = objConfirm.LastName
                txtAddress1.Text = objConfirm.Address1
                txtAddress2.Text = objConfirm.Address2
                txtPincode.Text = objConfirm.Pin
                txtMobileno.Text = objConfirm.Phoneno
            End If
        End If

    End Sub
End Class
