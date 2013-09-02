
Public Class displayInfoMessage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("dispMessage") Is Nothing Then
            If CInt(Session("dispMessage")) = 1 Then lblmessage.Text = "User Information accepted please Click here to Login."
            If CInt(Session("dispMessage")) = 0 Then lblmessage.Text = "Unable to Save User Information please try again."
            If CInt(Session("dispMessage")) = 5000 Then lblmessage.Text = "Login Successful."
            If CInt(Session("dispMessage")) = 5001 Then lblmessage.Text = "Invalid user ID/Password unable to process your request, please try again."
            If CInt(Session("dispMessage")) = 5005 Then lblmessage.Text = "Invalid session, please try again."
            If CInt(Session("dispMessage")) = 5006 Then lblmessage.Text = "Your account was locked for security reasons, please contact payment Gateway Administartor."
        End If
    End Sub
End Class
