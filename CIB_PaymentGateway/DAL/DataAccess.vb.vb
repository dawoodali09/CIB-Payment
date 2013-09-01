Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Public NotInheritable Class DataAccess

    Public Shared ConString As String = "Data Source=cibdbuser.db.11702767.hostedresource.com;Initial Catalog=cibdbuser;Persist Security Info=True;User ID=cibdbuser; pwd=CIBdb123!;" '' ConfigurationManager.AppSettings("LocalConnection").ToString() ''''ConfigurationManager.ConnectionStrings("local").ConnectionString


#Region "Data Retrival"

    Public Overloads Shared Function SendReader(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As Object) As SqlDataReader


        Dim DBCon As New SqlConnection(ConString)
        Dim Rdr As SqlDataReader

        DBCon.Open()

        Dim Cmd As New SqlCommand(commandText, DBCon)
        Cmd.CommandType = commandType


        Dim p As SqlParameter
        For Each p In commandParameters
            Cmd.Parameters.Add(p)
        Next p
        Rdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Cmd.Parameters.Clear()

        Return Rdr


    End Function



    Public Overloads Shared Function SendReader(ByVal spName As String, ByVal ParamArray parameterValues() As Object) As SqlDataReader

        Dim CommandParameters As SqlParameter()
        CommandParameters = GetSpParameterSet(spName)

        Dim i As Short
        Dim j As Short

        j = CommandParameters.Length - 1
        For i = 0 To j
            CommandParameters(i).Value = parameterValues(i)
        Next

        Dim DBCon As New SqlConnection(ConString)
        Dim Rdr As SqlDataReader

        DBCon.Open()

        Dim Cmd As New SqlCommand(spName, DBCon)
        Cmd.CommandType = CommandType.StoredProcedure


        Dim p As SqlParameter
        For Each p In CommandParameters
            Cmd.Parameters.Add(p)
        Next p
        Rdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Cmd.Parameters.Clear()

        Return Rdr
    End Function

    Public Overloads Shared Function SendReader(ByVal SQL As String) As SqlDataReader
        Dim DBCon As New SqlConnection(ConString)
        Dim Rdr As SqlDataReader

        DBCon.Open()

        Dim Cmd As New SqlCommand(SQL, DBCon)
        Cmd.CommandType = CommandType.Text
        Rdr = Cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Return Rdr
    End Function

    Public Overloads Shared Function SendDataSet(ByVal spName As String, ByVal ParamArray parameterValues() As Object) As DataSet

        Dim CommandParameters As SqlParameter()
        CommandParameters = GetSpParameterSet(spName)

        Dim i As Short
        Dim j As Short

        j = CommandParameters.Length - 1
        For i = 0 To j
            CommandParameters(i).Value = parameterValues(i)
        Next

        Dim DBCon As New SqlConnection(ConString)
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        DBCon.Open()

        Dim Cmd As New SqlCommand(spName, DBCon)
        Cmd.CommandType = CommandType.StoredProcedure

        Dim p As SqlParameter
        For Each p In CommandParameters
            Cmd.Parameters.Add(p)
        Next p

        da = New SqlDataAdapter(Cmd)
        da.Fill(ds)

        Cmd.Parameters.Clear()
        DBCon.Dispose()

        Return ds
    End Function

    Public Overloads Shared Function SendReaderWithSP(ByVal EmailAdress As String) As SqlDataReader

        

        Dim con As New SqlConnection(ConString)
        Dim dr As SqlDataReader
        con.Open()
        Dim cmd As New SqlCommand("CIB_MERCHANTS_GetByEmailAddress", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@EmailAdress", EmailAdress)
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

    Public Overloads Shared Function SendReaderMetChantsSP() As SqlDataReader



        Dim con As New SqlConnection(ConString)
        Dim dr As SqlDataReader
        con.Open()
        Dim cmd As New SqlCommand("CIB_MERCHANTS_List", con)
        cmd.CommandType = CommandType.StoredProcedure
        Try
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

    Public Overloads Shared Function SendDataSet(ByVal SQL As String) As DataSet
        Dim DBCon As New SqlConnection(ConString)
        Dim ds As New DataSet
        Dim da As SqlDataAdapter

        DBCon.Open()

        Dim Cmd As New SqlCommand(SQL, DBCon)
        Cmd.CommandType = CommandType.Text

        da = New SqlDataAdapter(Cmd)
        da.Fill(ds)

        Cmd.Parameters.Clear()
        DBCon.Dispose()

        Return ds
    End Function

    Public Overloads Shared Sub ExecuteNonQuery(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter)
        Dim DBCon As New SqlConnection(ConString)
        Try
            DBCon.Open()

            Dim Cmd As New SqlCommand(commandText, DBCon)
            Cmd.CommandType = commandType

            If Not (commandParameters Is Nothing) Then

                Dim p As SqlParameter
                For Each p In commandParameters
                    If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
                        p.Value = Nothing
                    End If
                    Cmd.Parameters.Add(p)
                Next p
            End If

            Cmd.ExecuteNonQuery()
            Cmd.Parameters.Clear()

        Finally
            DBCon.Dispose()
        End Try
    End Sub


#End Region


#Region "Data Command"

    Public Overloads Shared Function ExecuteCommand(ByVal spName As String, ByVal IncludeReturnValue As Boolean, ByVal ParamArray parameterValues() As Object) As Integer

        Dim commandParameters As SqlParameter()
        commandParameters = GetSpParameterSet(spName)

        Dim i As Short
        Dim j As Short

        j = commandParameters.Length - 1
        For i = 0 To j
            commandParameters(i).Value = parameterValues(i)
        Next

        Dim DBCon As New SqlConnection(ConString)
        DBCon.Open()

        Dim Cmd As SqlCommand = New SqlCommand(spName, DBCon)
        Cmd.CommandType = CommandType.StoredProcedure

        Dim p As SqlParameter
        For Each p In commandParameters
            Cmd.Parameters.Add(p)
        Next p

        Dim RetValue As Integer
        If IncludeReturnValue Then
            RetValue = Cmd.ExecuteScalar()
        Else
            Cmd.ExecuteNonQuery()
        End If

        Cmd.Parameters.Clear()

        Cmd.Dispose()
        DBCon.Dispose()

        Return RetValue


    End Function

    Public Overloads Shared Sub ExecuteCommand(ByVal SQL As String)
        Dim DBCon As New SqlConnection(ConString)
        DBCon.Open()

        Dim Cmd As New SqlCommand(SQL, DBCon)
        Cmd.CommandType = CommandType.Text

        Cmd.ExecuteNonQuery()
        Cmd.Dispose()
        DBCon.Dispose()
    End Sub

#End Region

    Protected Shared Function GetSpParameterSet(ByVal spName As String) As SqlParameter()
        Dim paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)
        Dim cachedParameters() As SqlParameter
        'Dim hashKey As String

        Dim cn As New SqlConnection(ConString)
        Dim cmd As SqlCommand = New SqlCommand(spName, cn)

        Try
            cn.Open()
            cmd.CommandType = CommandType.StoredProcedure
            SqlCommandBuilder.DeriveParameters(cmd)
            cmd.Parameters.RemoveAt(0)

            cachedParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
            cmd.Parameters.CopyTo(cachedParameters, 0)
        Finally
            cmd.Dispose()
            cn.Dispose()
        End Try


        Dim i As Short
        Dim j As Short = cachedParameters.Length - 1
        Dim clonedParameters(j) As SqlParameter

        For i = 0 To j
            clonedParameters(i) = CType(CType(cachedParameters(i), ICloneable).Clone, SqlParameter)
        Next

        Return clonedParameters

    End Function

End Class

