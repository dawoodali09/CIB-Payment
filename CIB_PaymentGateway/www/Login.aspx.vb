Imports System
Imports Controller.Controller
'''Imports BLL

'' comments by naresh...

Public Class Login1
    Inherits System.Web.UI.Page

    Protected Sub btnsignup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsignup.Click
        Server.Transfer("usersignUp.aspx")
    End Sub

    Protected Sub btnlogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If PageValidations() Then
            Dim clsContract As New clsContract()
            clsContract.UserName = email.Text
            clsContract.Password = password.Text
            Dim checkStatus As New SessionManager
            Dim objbll As New ControlEngine()
            Session("newuserlogin") = ""
            If objbll.CheckUserID(clsContract.UserName) Then

                checkStatus = objbll.GetLoginUser(clsContract.UserName)
                If checkStatus.StatusID = 1 Then
                    Session("dispMessage") = 5006
                    Server.Transfer("displayInfoMessage.aspx")
                End If
                If checkStatus.WrongAttempts > 5 Then
                    objbll.UpdateUserStatus(checkStatus.UserName, checkStatus.WrongAttempts + 1, 1)
                    Session("dispMessage") = 5006
                    Server.Transfer("displayInfoMessage.aspx")
                Else
                    Dim i As Integer
                    i = objbll.ValidateUserCredentials(clsContract)
                    If i <> -1 Then
                        lblErrorMessage.Visible = False
                        Session("dispMessage") = 5000
                        Dim currentSessions As New SessionManager
                        currentSessions = objbll.GetLoginUser(clsContract.UserName)
                        currentSessions.CurrentLoginTime = Now()
                        currentSessions.LoginStatus = True

                        Session("cureentSessionsLoginUser") = currentSessions

                        If checkStatus.StatusID = 2 Then
                            Session("newuserlogin") = checkStatus.UserName
                            objbll.UpdateUserStatus(checkStatus.UserName, 0, 2)
                            Response.Redirect("NewPasswordPage.aspx")
                        ElseIf checkStatus.StatusID = 0 Then
                            objbll.UpdateUserStatus(checkStatus.UserName, 0, 0)
                            Response.Redirect("landing\MainPage.aspx")
                        End If

                    ElseIf i = -1 Then
                        If checkStatus.WrongAttempts = 5 Then
                            objbll.UpdateUserStatus(checkStatus.UserName, checkStatus.WrongAttempts + 1, 1)
                        Else
                            objbll.UpdateUserStatus(checkStatus.UserName, checkStatus.WrongAttempts + 1, checkStatus.StatusID)
                        End If
                        lblErrorMessage.Visible = True : lblErrorMessage.Text = "Ivalid Email Address or Password."
                        Session("dispMessage") = 5001
                        Server.Transfer("displayInfoMessage.aspx")
                    End If
                End If

            Else
                Session("dispMessage") = 5001
                Server.Transfer("displayInfoMessage.aspx")
            End If


        End If

    End Sub

    Private Function PageValidations() As Boolean
        lblErrorMessage.Text = ""
        lblErrorMessage.Visible = False
        If Trim(email.Text) = "" Then
            lblErrorMessage.Text = "Please enter valid email address"
            lblErrorMessage.Visible = True
            Return False
        End If

        If Trim(password.Text) = "" Then
            lblErrorMessage.Text = "Please enter valid password"
            lblErrorMessage.Visible = True
            Return False
        End If

        Return True

    End Function
End Class
