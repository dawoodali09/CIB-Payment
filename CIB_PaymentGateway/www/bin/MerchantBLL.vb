Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Model
Imports DAL

Public Class MerchantBLL

#Region "Data Fetching Operations"
    Public Function GetMerchantByEmail(ByVal EmailAddress As String) As MERCHANTS
        Dim Country As New MERCHANTS

        'Execute the query against the database 
        Using dataReader As SqlDataReader = DataAccess.SendReaderWithSP(EmailAddress)
            ' Scroll through the results 
            While dataReader.Read()
                Country = GetMerchantsObj(dataReader)
            End While
        End Using
        Return Country
    End Function


    Public Function GetMerchantList() As IList(Of MERCHANTS)
        Dim MertchantsList As IList(Of MERCHANTS) = New List(Of MERCHANTS)()
        'Execute the query against the database 
        Using dataReader As SqlDataReader = DataAccess.SendReaderMetChantsSP()
            ' Scroll through the results 
            While dataReader.Read()
                MertchantsList.Add(GetMerchantsObj(dataReader))
            End While
        End Using
        Return MertchantsList
    End Function
#End Region


#Region "Basic Database Operations"

    ''Public Function Delete(ByVal obj As MERCHANTS) As Boolean
    ''    Return DataAccess.ExecuteCommand("CIB_MERCHANTS_INSERT", True, "Delete", obj.ID, obj.RegionID, obj.Title, obj.SmallIntro, obj.MapID)
    ''End Function

    Public Function Insert(ByVal obj As MERCHANTS) As Integer
        Return DataAccess.ExecuteCommand("CIB_MERCHANTS_INSERT", True, obj.EmailAddress, obj.Password, obj.Name, obj.ContactPerson, obj.ContactNumber, obj.ContactMobile, obj.Address, obj.City, obj.CountryID)
    End Function

    Public Function Update(ByVal obj As MERCHANTS) As Integer
        Return DataAccess.ExecuteCommand("CIB_MERCHANTS_UpdateByID", True, obj.ID, obj.Name, obj.ContactPerson, obj.ContactNumber, obj.ContactMobile, obj.Address, obj.City, obj.CountryID, obj.ApiClientID, obj.ApiClientUserName, obj.ApiClientPassword, obj.AccountStatus, obj.LoginAttempsCount, obj.Created, obj.Approved, obj.Deleted)
    End Function
#End Region

#Region "Private Method Space"
    Private Function GetMerchantsObj(ByVal dataReader As SqlDataReader) As MERCHANTS
        Dim objMerchant As New MERCHANTS

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("ID"))) Then
            objMerchant.ID = Convert.ToInt32(dataReader("ID"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("EmailAddress"))) Then
            objMerchant.EmailAddress = Convert.ToString(dataReader("EmailAddress"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Password"))) Then
            objMerchant.Password = Convert.ToString(dataReader("Password"))
        End If

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Name"))) Then
            objMerchant.Name = Convert.ToString(dataReader("Name"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("ContactPerson"))) Then
            objMerchant.ContactPerson = Convert.ToString(dataReader("ContactPerson"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("ContactNumber"))) Then
            objMerchant.ContactNumber = Convert.ToString(dataReader("ContactNumber"))
        End If

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("ContactMobile"))) Then
            objMerchant.ContactMobile = Convert.ToString(dataReader("ContactMobile"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Address"))) Then
            objMerchant.Address = Convert.ToString(dataReader("Address"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("City"))) Then
            objMerchant.City = Convert.ToString(dataReader("City"))
        End If

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("CountryID"))) Then
            objMerchant.CountryID = Convert.ToString(dataReader("CountryID"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("APIClientID"))) Then
            objMerchant.ApiClientID = Convert.ToString(dataReader("APIClientID"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("APIUserName"))) Then
            objMerchant.ApiClientUserName = Convert.ToString(dataReader("APIUserName"))
        End If

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("APIPassword"))) Then
            objMerchant.ApiClientPassword = Convert.ToString(dataReader("APIPassword"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("AccountStatus"))) Then
            objMerchant.AccountStatus = Convert.ToInt32(dataReader("AccountStatus"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("LoginAttemptCount"))) Then
            objMerchant.LoginAttempsCount = Convert.ToInt32(dataReader("LoginAttemptCount"))
        End If

        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Created"))) Then
            objMerchant.Created = Convert.ToString(dataReader("Created"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Approved"))) Then
            objMerchant.Approved = Convert.ToString(dataReader("Approved"))
        End If
        If Not dataReader.IsDBNull((dataReader.GetOrdinal("Deleted"))) Then
            objMerchant.Deleted = Convert.ToString(dataReader("Deleted"))
        End If


        Return objMerchant
    End Function
#End Region
End Class
