Imports Controller.Controller
Partial Class NewPasswordPage
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblErrorMessage.Text = ValidateFields()
        If lblErrorMessage.Visible = False Then
            Dim passwordch As String
            passwordch = Trim(txtpassword.Text)
            Dim objbll As New ControlEngine()
            objbll.UpdateUserPassword(Session("newuserlogin"), 0, 0, passwordch)
            Response.Redirect("landing\MainPage.aspx")
        End If
    End Sub


    Private Function ValidateFields() As String

        Dim result As String = ""
        lblErrorMessage.Visible = False

    
        'Password validation
        If txtpassword.Text.Length = 0 Then
            result = result & "<li>- Password field is empty</li>" & vbNewLine
        End If
        If InStr(txtpassword.Text, " "c) = True Then
            result = result & "<li>- Password field has spaces</li>" & vbNewLine
        End If
        If txtconfirmpassword.Text.Length = 0 Then
            result = result & "<li>- Confirm Password field is empty</li>" & vbNewLine
        End If
        If InStr(txtconfirmpassword.Text, " "c) = True Then
            result = result & "<li>- Confirm Password field has spaces</li>" & vbNewLine
        End If
        If String.Compare(txtpassword.Text, txtconfirmpassword.Text) <> 0 Then
            result = result & "<li>- Password and Confirm Password doesn't match</li>" & vbNewLine
        End If

       
     
       

        If result <> "" Then lblErrorMessage.Visible = True
        'return
        Return result
    End Function
End Class
