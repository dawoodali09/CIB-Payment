Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports DAL
Imports Model
Imports System.Collections

Public Class SystemUsers
    Inherits List(Of SystemUser)
End Class

Public Class SystemUserBLL

#Region "Data Fetching Regions"
    Public Shared Function GetByID(ByVal ID As String) As SystemUser

        Dim parms As New Hashtable()
        parms.Add("ID", ID)
        Dim obj As New SystemUser

        Dim objData As DataObject = DBConnect.ExecuteReader(DBConnections.PIS, "CIB_SYSTEMUSERS_GetByID", parms, True)
        If (objData.Rows.Count > 0) Then
            obj = Populate(objData.Rows(objData.Rows.Count - 1))
        End If

        Return obj
    End Function


    Public Shared Function List() As IList(Of SystemUser)
        Dim parms As New Hashtable()
        Dim SystemUsersList As IList(Of SystemUser) = New List(Of SystemUser)()
        Dim objData As DataObject = DBConnect.ExecuteReader(DBConnections.PIS, "CIB_SYSTEMUSERS_List", parms, True)
        If (objData.Rows.Count > 0) Then
            For Each Row As DAL.DataObjectRow In objData.Rows
                SystemUsersList.Add(Populate(Row))
            Next
        End If
        Return SystemUsersList
    End Function
#End Region

#Region "Basic Data Operations"
    Public Shared Sub Insert(ByVal systemuser As SystemUser)
        Dim parms As New Hashtable()
        With systemuser
            parms.Add("FirstName", .FirstName)
            parms.Add("LastName", .LastName)
            parms.Add("EmailAddress", .EmailAddress)
            parms.Add("Password", .Password)
            parms.Add("UserLevel", .UserLevel)
            parms.Add("Comment", .Comment)
            parms.Add("CIBEmployeeID", .CIBEmployeeID)
            parms.Add("SignatureURL", .SignatureURL)
            parms.Add("Title", .Title)
        End With
        DBConnect.ExecuteNonQuery(DBConnections.PIS, "CIB_SYSTEMUSERS_INSERT", parms, True)
    End Sub

    Public Shared Sub Update(ByVal systemuser As SystemUser)
        Dim parms As New Hashtable()
        With systemuser
            parms.Add("FirstName", .FirstName)
            parms.Add("LastName", .LastName)
            parms.Add("EmailAddress", .EmailAddress)
            parms.Add("Password", .Password)
            parms.Add("UserLevel", .UserLevel)
            parms.Add("Comment", .Comment)
            parms.Add("CIBEmployeeID", .CIBEmployeeID)
            parms.Add("SignatureURL", .SignatureURL)
            parms.Add("Title", .Title)
            parms.Add("ID", .ID)
        End With
        DBConnect.ExecuteNonQuery(DBConnections.PIS, "CIB_SYSTEMUSERS_UPDATE", parms, True)
    End Sub
#End Region

#Region "Private Methode Region"
    Private Function GetSystemUsersObj(ByVal dataReader As SqlDataReader) As SystemUser
        Dim obj As New SystemUser
        With obj
            If Not dataReader.IsDBNull((dataReader.GetOrdinal("ID"))) Then
                .ID = Convert.ToInt32(dataReader("ID"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("FirstName"))) Then
                .FirstName = Convert.ToString(dataReader("FirstName"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("LastName"))) Then
                .LastName = Convert.ToString(dataReader("LastName"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("EmailAddress"))) Then
                .EmailAddress = Convert.ToString(dataReader("EmailAddress"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("Password"))) Then
                .Password = Convert.ToString(dataReader("Password"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("UserLevel"))) Then
                .UserLevel = Convert.ToString(dataReader("UserLevel"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("Comment"))) Then
                .Comment = Convert.ToString(dataReader("Comment"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("CIBEmployeeID"))) Then
                .CIBEmployeeID = Convert.ToInt32(dataReader("CIBEmployeeID"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("SignatureURL"))) Then
                .SignatureURL = Convert.ToString(dataReader("SignatureURL"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("Title"))) Then
                .Title = Convert.ToString(dataReader("Title"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("Created"))) Then
                .Created = Convert.ToDateTime(dataReader("Created"))
            End If

            If Not dataReader.IsDBNull((dataReader.GetOrdinal("Deleted"))) Then
                .Deleted = Convert.ToDateTime(dataReader("Deleted"))
            End If

        End With
        Return obj
    End Function

    Private Shared Function Populate(objDataRecord As DataObjectRow) As SystemUser
        Dim obj As New SystemUser()
        With obj
            If objDataRecord.HasValue("ID") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("ID")) AndAlso (objDataRecord.[Get]("ID").ToString() <> "") Then
                    .ID = System.Convert.ToInt32(objDataRecord.[Get]("ID"))
                End If
            End If

            If objDataRecord.HasValue("ID") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("FirstName")) AndAlso (objDataRecord.[Get]("FirstName").ToString() <> "") Then
                    .FirstName = System.Convert.ToString(objDataRecord.[Get]("FirstName"))
                End If
            End If

            If objDataRecord.HasValue("LastName") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("LastName")) AndAlso (objDataRecord.[Get]("LastName").ToString() <> "") Then
                    .LastName = System.Convert.ToString(objDataRecord.[Get]("LastName"))
                End If
            End If

            If objDataRecord.HasValue("EmailAddress") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("EmailAddress")) AndAlso (objDataRecord.[Get]("EmailAddress").ToString() <> "") Then
                    .EmailAddress = System.Convert.ToString(objDataRecord.[Get]("EmailAddress"))
                End If
            End If

            If objDataRecord.HasValue("Password") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("Password")) AndAlso (objDataRecord.[Get]("Password").ToString() <> "") Then
                    .Password = System.Convert.ToString(objDataRecord.[Get]("Password"))
                End If
            End If

            If objDataRecord.HasValue("UserLevel") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("UserLevel")) AndAlso (objDataRecord.[Get]("UserLevel").ToString() <> "") Then
                    .UserLevel = System.Convert.ToString(objDataRecord.[Get]("UserLevel"))
                End If
            End If

            If objDataRecord.HasValue("Comment") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("Comment")) AndAlso (objDataRecord.[Get]("Comment").ToString() <> "") Then
                    .Comment = System.Convert.ToString(objDataRecord.[Get]("Comment"))
                End If
            End If
          
            If objDataRecord.HasValue("CIBEmployeeID") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("CIBEmployeeID")) AndAlso (objDataRecord.[Get]("CIBEmployeeID").ToString() <> "") Then
                    .CIBEmployeeID = System.Convert.ToInt32(objDataRecord.[Get]("CIBEmployeeID"))
                End If
            End If

            If objDataRecord.HasValue("SignatureURL") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("SignatureURL")) AndAlso (objDataRecord.[Get]("SignatureURL").ToString() <> "") Then
                    .SignatureURL = System.Convert.ToString(objDataRecord.[Get]("SignatureURL"))
                End If
            End If

            If objDataRecord.HasValue("Title") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("Title")) AndAlso (objDataRecord.[Get]("Title").ToString() <> "") Then
                    .Title = System.Convert.ToString(objDataRecord.[Get]("Title"))
                End If
            End If

            If objDataRecord.HasValue("Created") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("Created")) AndAlso (objDataRecord.[Get]("Title").ToString() <> "") Then
                    .Created = System.Convert.ToDateTime(objDataRecord.[Get]("Created"))
                End If
            End If

            If objDataRecord.HasValue("Deleted") Then
                If Not DBNull.Value.Equals(objDataRecord.[Get]("Deleted")) AndAlso (objDataRecord.[Get]("Deleted").ToString() <> "") Then
                    .Deleted = System.Convert.ToDateTime(objDataRecord.[Get]("Deleted"))
                End If
            End If

        End With
        Return obj
    End Function
#End Region
End Class
