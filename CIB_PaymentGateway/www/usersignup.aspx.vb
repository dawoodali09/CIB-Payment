Imports System.Collections
Imports Controller.Controller.Validate
Imports System
Imports Controller.Controller
'' dawood ali added some comment

Public Class usersignup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        initialvalues()
    End Sub

    Public Sub initialvalues()
        txtemailaddress.Text = String.Empty : txtpassword.Text = String.Empty : txtconfirmpassword.Text = String.Empty : txtFirstName.Text = String.Empty : txtLastName.Text = String.Empty : txtAddress1.Text = String.Empty : txtAddress2.Text = String.Empty : txtPincode.Text = String.Empty : txtMobileno.Text = String.Empty
        lblErrorMessage.Visible = False : lblErrorMessage.Text = String.Empty
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblErrorMessage.Text = ValidateFields()
        If lblErrorMessage.Visible = False Then
            Dim objparams As New clsContract
            objparams.Email = txtemailaddress.Text
            objparams.Password = txtpassword.Text
            objparams.FirstName = txtFirstName.Text
            objparams.LastName = txtLastName.Text

            objparams.Address1 = txtAddress1.Text
            objparams.Address2 = txtAddress2.Text
            objparams.Pin = txtPincode.Text
            objparams.Phoneno = txtMobileno.Text

            Session("ConfirmUserInfo") = objparams
            Server.Transfer("signupconfirmation.aspx")
        End If
    End Sub


    Private Function ValidateFields() As String

        Dim result As String = ""
        lblErrorMessage.Visible = False

        'first name field validation
        If txtFirstName.Text.Length = 0 Then
            result = result & "<li>- First Name field is empty</li>" & vbNewLine
        End If
        If InStr(txtFirstName.Text, " "c) = True Then
            result = result & "<li>- First Name field has spaces</li>" & vbNewLine
        End If
        If InStr(txtFirstName.Text, IsNumeric(txtFirstName.Text)) = True Then
            result = result & "<li>- First Name field has numbers</li>" & vbNewLine
        End If
        'last name field validation
        If txtLastName.Text.Length = 0 Then
            result = result & "<li>- Last Name field is empty</li>" & vbNewLine
        End If
        If InStr(txtLastName.Text, " "c) = True Then
            result = result & "<li>- Last Name field has spaces</li>" & vbNewLine
        End If
        If InStr(txtLastName.Text, IsNumeric(txtLastName.Text)) = True Then
            result = result & "<li>- Last Name field has numbers</li>" & vbNewLine
        End If
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

        'phone validation
        If txtMobileno.Text.Length = 0 Then
            result = result & "<li>- Phone field is empty</li>" & vbNewLine
        End If
        If Len(txtMobileno.Text) > 0 Then
            If IsNumeric(txtMobileno.Text) = False Then
                result = result & "<li>- Phone field contains illegal characters</li>" & vbNewLine
            End If
        End If
        'email validation
        If txtemailaddress.Text.Length = 0 Then
            result = result & "<li>- Email field is empty</li>" & vbNewLine
        End If
        If Len(txtemailaddress.Text) > 0 Then
            Dim blnIsValidEmail As Boolean = clsValidate.IsEmail(txtemailaddress.Text)
            'If InStr(txtemailaddress.Text, "@") = False And InStr(txtemailaddress.Text, ".") Then
            If Not blnIsValidEmail Then
                result = result & "<li>- Email field is invalid</li>" & vbNewLine
            End If
        End If
        'Address validation
        If txtAddress1.Text.Length = 0 Then
            result = result & "<li>- Address Line 1 field is empty</li>" & vbNewLine
        End If
        If txtPincode.Text.Length = 0 Then
            result = result & "<li>- Pincode field is empty</li>" & vbNewLine
        End If
        If Len(txtPincode.Text) > 0 Then
            If IsNumeric(txtPincode.Text) = False Then
                result = result & "<li>- Pincode field contains illegal characters</li>" & vbNewLine
            End If
        End If

        If result <> "" Then lblErrorMessage.Visible = True
        'return
        Return result
    End Function

End Class
