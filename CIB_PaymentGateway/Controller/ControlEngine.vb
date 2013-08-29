Imports DAL
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System
Imports System.Net.Mail
Namespace Controller
    Public Class ControlEngine


        Public Function ValidateUserCredentials(ByVal objUserDetails As clsContract) As Integer
            Try

                Return clsDAL.ValidateUser(objUserDetails.UserName, objUserDetails.Password)
            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        Public Function CheckUserID(ByVal userID As String) As Boolean
            Try
                Dim dr As SqlDataReader
                Dim currSession As New SessionManager
                dr = clsDAL.GetLoginUser(userID)


                If (dr.HasRows) Then

                    Return True
                Else
                    Return False

                End If

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        Public Sub UpdateUserStatus(ByVal userID As String, ByVal wrongAttampts As Integer, ByVal statusID As Integer)
            Try
               
                clsDAL.UpdateUserStatus(userID, wrongAttampts, statusID)


            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Sub

        Public Sub UpdateUserPassword(ByVal userID As String, ByVal wrongAttampts As Integer, ByVal statusID As Integer, ByVal password As String)
            Try

                clsDAL.UpdateUserPassword(userID, wrongAttampts, statusID, password)


            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Sub

        Public Function GetLoginUser(ByVal userID As String) As SessionManager
            Try
                Dim dr As SqlDataReader
                Dim currSession As New SessionManager
                dr = clsDAL.GetLoginUser(userID)

                '''dr.
                If (dr.HasRows) Then

                    dr.Read()
                    currSession.UserName = dr.Item("USERID").ToString()
                    currSession.FirstName = dr.Item("FIRSTNAME").ToString()
                    currSession.LastName = dr.Item("LASTNAME").ToString()

                    currSession.StatusID = CInt(dr.Item("STATUSID").ToString())
                    currSession.WrongAttempts = CInt(dr.Item("WRONGATTAMPTS").ToString())

                    Return currSession

                End If

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

        Public Function InsertUserDetails(ByVal objUserDetails As clsContract) As Integer
            Try
                Dim i As Integer
                i = clsDAL.InsertUserInformation(objUserDetails.Email, objUserDetails.Password, objUserDetails.FirstName, objUserDetails.LastName, objUserDetails.Address1, objUserDetails.Address2, objUserDetails.Pin, objUserDetails.Phoneno)

                If i <> -1 Then

                    Try
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False
                        Smtp_Server.Credentials = New Net.NetworkCredential("njnareshbabu@gmail.com", "poojitha7")
                        Smtp_Server.Port = 587
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Host = "smtp.gmail.com"

                        e_mail = New MailMessage()
                        e_mail.From = New MailAddress("njnareshbabu@gmail.com")
                        e_mail.To.Add(objUserDetails.Email)
                        e_mail.Subject = "Asia gate payment Gateway subscription"
                        e_mail.IsBodyHtml = False
                        e_mail.Body = "Your subscription is successfull, please find your login credentials.  User ID : " & objUserDetails.Email & "  Password : " & objUserDetails.Password
                        Smtp_Server.Send(e_mail)


                    Catch error_t As Exception

                    End Try

                End If

                Return i

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Function

    End Class

End Namespace
