Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Diagnostics
Imports System.Collections
Imports System.Data.SqlTypes

Public Enum DBConnections
    PIS
    PaynShareSupport
End Enum

Public Class DBConnect
    Public Shared Function ExecuteReader(objDBConnection As DBConnections, StoredProcedure As String, ht As Hashtable, IsInjectionSafe As Boolean) As DataObject
        Dim dataresult__1 As SqlDataReader = Nothing

        Try
            Dim Connection As New SqlConnection(GetConnectionString(objDBConnection))
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.StoredProcedure
            Command.CommandText = StoredProcedure

            Command = AddParameters(Command, ht, IsInjectionSafe)

            Connection.Open()

            dataresult__1 = Command.ExecuteReader(CommandBehavior.CloseConnection)

            Dim dataResult__2 As New DataObject(dataresult__1)

            Return dataResult__2
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Shared Function ExecuteReader(ConnectionString As String, StoredProcedure As String, ht As Hashtable, IsInjectionSafe As Boolean) As DataObject
        Dim dataresult__1 As SqlDataReader = Nothing

        Try
            Dim Connection As New SqlConnection(ConnectionString)
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.StoredProcedure
            Command.CommandText = StoredProcedure

            Command = AddParameters(Command, ht, IsInjectionSafe)

            Connection.Open()

            dataresult__1 = Command.ExecuteReader(CommandBehavior.CloseConnection)

            Dim dataResult__2 As New DataObject(dataresult__1)

            Return dataResult__2
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Shared Function ExecuteReaderCommand(objDBConnection As DBConnections, StoredProcedure As String, ht As Hashtable) As DataObject
        Dim dataresult__1 As SqlDataReader = Nothing

        Try
            Dim Connection As New SqlConnection(GetConnectionString(objDBConnection))
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.Text
            Command.CommandText = StoredProcedure

            Command = AddParameters(Command, ht, False)

            Connection.Open()

            dataresult__1 = Command.ExecuteReader(CommandBehavior.CloseConnection)

            Dim dataResult__2 As New DataObject(dataresult__1)

            Return dataResult__2
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Shared Function ExecuteReaderCommand(objDBConnection As DBConnections, CommandString As String) As DataObject
        Dim dataresult__1 As SqlDataReader = Nothing

        Try
            Dim Connection As New SqlConnection(GetConnectionString(objDBConnection))
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.Text
            Command.CommandText = CommandString

            Connection.Open()

            dataresult__1 = Command.ExecuteReader(CommandBehavior.CloseConnection)

            Dim dataResult__2 As New DataObject(dataresult__1)

            Return dataResult__2
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Shared Function ExecuteReaderCommand(ConnectionString As String, CommandString As String) As DataObject
        Dim dataresult__1 As SqlDataReader = Nothing

        Try
            Dim Connection As New SqlConnection(ConnectionString)
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.Text
            Command.CommandText = CommandString

            Connection.Open()

            dataresult__1 = Command.ExecuteReader(CommandBehavior.CloseConnection)

            Dim dataResult__2 As New DataObject(dataresult__1)
            ' Connection.Close();
            Return dataResult__2
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Shared Sub ExecuteNonQuery(ConnectionString As String, CommandString As String)
        Dim dataresult As SqlDataReader = Nothing
        Try
            Dim Connection As New SqlConnection(ConnectionString)
            Dim Command As New SqlCommand()
            Command.Connection = Connection
            Command.CommandType = CommandType.Text
            Command.CommandText = CommandString

            Connection.Open()

            Command.ExecuteNonQuery()

            ' DataObject dataResult = new DataObject(dataresult);
            ' return dataResult;
            Connection.Close()
        Catch e As Exception
            Throw e
        End Try
    End Sub

    Public Shared Function ExecuteScalar(objDBConnection As DBConnections, StoredProcedure As String, ht As Hashtable, IsInjectionSafe As Boolean) As [Object]
        Dim Connection As New SqlConnection(GetConnectionString(objDBConnection))
        Dim Command As New SqlCommand()
        Command.Connection = Connection
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = StoredProcedure

        Command = AddParameters(Command, ht, IsInjectionSafe)

        Connection.Open()
        Dim objObject As [Object] = Command.ExecuteScalar()
        Connection.Close()

        Return objObject
    End Function

    Public Shared Sub ExecuteNonQuery(objDBConnection As DBConnections, StoredProcedure As String, ht As Hashtable, IsInjectionSafe As Boolean)
        Dim Connection As New SqlConnection(GetConnectionString(objDBConnection))
        Dim Command As New SqlCommand()
        Command.Connection = Connection
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = StoredProcedure

        Command = AddParameters(Command, ht, IsInjectionSafe)

        Connection.Open()

        Command.ExecuteNonQuery()
        Connection.Close()
    End Sub

    Public Shared Sub ExecuteNonQuery(ConnectionString As String, StoredProcedure As String, ht As Hashtable, IsInjectionSafe As Boolean)
        Dim Connection As New SqlConnection(ConnectionString)
        Dim Command As New SqlCommand()
        Command.Connection = Connection
        Command.CommandType = CommandType.StoredProcedure
        Command.CommandText = StoredProcedure

        Command = AddParameters(Command, ht, IsInjectionSafe)

        Connection.Open()

        Command.ExecuteNonQuery()
        Connection.Close()
    End Sub

#Region "private methods"

    Private Shared Function AddParameters(objCommand As SqlCommand, ht As Hashtable, IsInjectionSafe As Boolean) As SqlCommand
        If ht IsNot Nothing Then
            If IsInjectionSafe = False Then
                For Each s As String In ht.Keys
                    Dim input As String = ht(s).ToString()
                    If objCommand.CommandText = "Core_Errors_Add" Then
                        If s.ToLowerInvariant() <> "exception" AndAlso s.ToLowerInvariant() <> "bloguserid" AndAlso s.ToLowerInvariant() <> "created" Then
                            input = input.ToLowerInvariant().Replace("'", "&#39;").Replace("cast", "-CST-").Replace("exec", "-EKSEKVER-").Replace("execute", "-EKSEKVER-")
                        End If

                        objCommand.Parameters.Add(New SqlParameter(s, input))
                    Else
                        If input.Contains("'") = True OrElse input.ToLowerInvariant().Contains("cast") = True AndAlso input.ToLowerInvariant().Contains("exec") = True OrElse input.ToLowerInvariant().Contains("execute") = True Then
                            Try
                                objCommand.Parameters.Add(New SqlParameter(s, ht(s).ToString().Replace("'", "&#39;")))
                            Catch generatedExceptionName As Exception
                            End Try
                        Else
                            objCommand.Parameters.Add(New SqlParameter(s, ht(s)))
                        End If
                    End If
                Next
            Else
                For Each s As String In ht.Keys
                    objCommand.Parameters.Add(New SqlParameter(s, ht(s)))
                Next
            End If
        End If
        Return objCommand
    End Function

    Private Shared Function GetConnectionString(ConnectionString As DBConnections) As String
        Dim ConnStr As String = ""
        Select Case ConnectionString
            Case DBConnections.PIS
                ConnStr = ConfigurationManager.ConnectionStrings("PointPayConnection").ConnectionString
                Exit Select
            Case DBConnections.PaynShareSupport
                ConnStr = ConfigurationManager.ConnectionStrings("PISConnection").ConnectionString
                Exit Select
            Case Else
                Exit Select
        End Select
        Return ConnStr
    End Function

#End Region
End Class
