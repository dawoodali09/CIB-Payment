Imports System
Imports Controller.Controller

Public Class FooterPage
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Try

                Dim currentSessions As SessionManager
                currentSessions = Session("cureentSessionsLoginUser")
                If currentSessions.LoginStatus = True Then
                    lblLoginUser.Text = UCase(currentSessions.FirstName) & " " & UCase(currentSessions.LastName)
                    lblLastLogin.Text = Now

                End If

            Catch ex As Exception
                ' ''Session("dispMessage") = 5005
                ' ''Response.Redirect("../displayInfoMessage.aspx")

            End Try

        End If
    End Sub

End Class