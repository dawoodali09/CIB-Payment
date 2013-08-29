Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections
Imports System

Public Class clsDAL
    'SQL Connection string 
    Shared ConnectionString As String = "Data Source=CIBFINANCE-PC\CIBFINANCE;Initial Catalog=CIB;Integrated Security=True; User ID=CIBUSER;pwd=cibuser123;" 'ConfigurationManager.AppSettings("LocalConnection").ToString()

#Region "Insert User Details"

    ''' <summary> 
    ''' Insert Job Details
    ''' </summary>
    ''' <param name="objBELJobs"></param>
    ''' <returns></returns>

    Shared Function InsertUserInformation(ByVal EMAIL As String, ByVal PWD As String, ByVal FNAME As String, ByVal LNAME As String, ByVal ADD1 As String, ByVal ADD2 As String, ByVal PIN As String, ByVal MOBNO As String) As Integer
        Dim con As New SqlConnection(ConnectionString)
        Dim objHash As New Hashtable()
        con.Open()
        Dim cmd As New SqlCommand("sp_userinformation", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            '''objHash = objBELUserDetails.NewUserdetails
            cmd.Parameters.AddWithValue("@USERID", EMAIL)
            cmd.Parameters.AddWithValue("@PASSWORD", PWD)
            cmd.Parameters.AddWithValue("@FIRSTNAME", FNAME)
            cmd.Parameters.AddWithValue("@LASTNAME", LNAME)
            cmd.Parameters.AddWithValue("@ADDRESS1", ADD1)
            cmd.Parameters.AddWithValue("@ADDRESS2", ADD2)
            cmd.Parameters.AddWithValue("@PINCODE", PIN)
            cmd.Parameters.AddWithValue("@MOBILENO", MOBNO)
            'cmd.Parameters.AddWithValue("@Created_By", objBELUserDetails.Created_By)
            'cmd.Parameters.Add("@ERROR", SqlDbType.[Char], 500)
            'cmd.Parameters("@ERROR").Direction = ParameterDirection.Output
            Dim iRetUserInfo As Integer = cmd.ExecuteNonQuery()
            'Dim strMessage As String = DirectCast(cmd.Parameters("@ERROR").Value, String)
            con.Close()
            Return iRetUserInfo
        Catch ex As Exception
            Return -1
            ' Throw ex
        Finally
            cmd.Dispose()
            con.Close()
            con.Dispose()
        End Try
    End Function

    Shared Function ValidateUser(ByVal userID As String, ByVal password As String) As Integer
        Dim con As New SqlConnection(ConnectionString)
        Dim dr As SqlDataReader
        con.Open()
        Dim cmd As New SqlCommand("sp_IsValidUser", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@USERID", userID)
            cmd.Parameters.AddWithValue("@PASSWORD", password)
            'cmd.Parameters.Add("@ERROR", SqlDbType.VarChar, 8000)
            'cmd.Parameters("@ERROR").Direction = ParameterDirection.Output
            Dim iReturn As Integer
            dr = cmd.ExecuteReader()
            If (dr.HasRows) Then
                iReturn = 0
            Else
                iReturn = -1
            End If
            'Dim strMessage As String = DirectCast(cmd.Parameters("@ERROR").Value, String)
            con.Close()
            Return iReturn 'strMessage
        Catch ex As Exception
            'Throw ex
            Return -1
        Finally
            cmd.Dispose()
            con.Close()
            con.Dispose()
        End Try
    End Function

    Shared Function GetLoginUser(ByVal userID As String) As SqlDataReader
        Dim con As New SqlConnection(ConnectionString)
        Dim dr As SqlDataReader
        con.Open()
        Dim cmd As New SqlCommand("sp_GetUser", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@USERID", userID)            
            dr = cmd.ExecuteReader()           
            Return dr
        Catch ex As Exception
            'Throw ex
            '''Return dr
        Finally
            '''cmd.Dispose()
            '''con.Close()
            '''con.Dispose()
        End Try
    End Function

    Shared Sub UpdateUserStatus(ByVal userID As String, ByVal wrongAttampts As Integer, ByVal statusID As Integer)
        Dim con As New SqlConnection(ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand("sp_UpdateStatus", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@USERID", userID)
            cmd.Parameters.AddWithValue("@WRONGATTAMPTS", wrongAttampts)
            cmd.Parameters.AddWithValue("@STATUSID", statusID)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'Throw ex
            '''Return dr
        Finally
            cmd.Dispose()
            con.Close()
            con.Dispose()

        End Try
    End Sub

    Shared Sub UpdateUserPassword(ByVal userID As String, ByVal wrongAttampts As Integer, ByVal statusID As Integer, ByVal passWord As String)
        Dim con As New SqlConnection(ConnectionString)
        con.Open()
        Dim cmd As New SqlCommand("sp_UpdatePassword", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@USERID", userID)
            cmd.Parameters.AddWithValue("@WRONGATTAMPTS", wrongAttampts)
            cmd.Parameters.AddWithValue("@STATUSID", statusID)
            cmd.Parameters.AddWithValue("@PASSWORD", passWord)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'Throw ex
            '''Return dr
        Finally
            cmd.Dispose()
            con.Close()
            con.Dispose()

        End Try
    End Sub

#End Region
End Class
