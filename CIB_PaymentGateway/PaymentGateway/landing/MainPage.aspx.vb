
Imports System
Imports Controller.Controller

Partial Class landing_MainPage
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Try



                Dim cureentSessions As SessionManager
                '' ''cureentSessions = objbll.GetLoginUser(clsContract.UserName)
                '' ''cureentSessions.CurrentLoginTime = Now()

                cureentSessions = Session("cureentSessionsLoginUser")
                If cureentSessions.LoginStatus <> True Then
                    Session("dispMessage") = 5005
                    Server.Transfer("displayInfoMessage.aspx")
                End If

            Catch ex As Exception
                Session("dispMessage") = 5005
                Response.Redirect("../displayInfoMessage.aspx")

            End Try

        End If
    End Sub

End Class
