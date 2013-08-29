Imports System.Collections.Generic
Imports System.Collections
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions


Namespace Controller
	Public Class clsContract
#Region "Variables"
        ''' <summary>
        ''' User Registration Variables
        ''' </summary>
        Private _UserName As String
        Private _Password As String
        Private _FirstName As String
        Private _LastName As String
        Private _Email As String
        Private _Phoneno As String

        Private _Location As String
        Private _Created_By As String
        Private _NewUserdetails As Hashtable

        Private _Address1 As String
        Private _Address2 As String
        Private _Pin As String

#End Region

        Public Property Pin() As String
            Get
                Return _Pin
            End Get
            Set(ByVal value As String)
                _Pin = value
            End Set
        End Property

        Public Property Address2() As String
            Get
                Return _Address2
            End Get
            Set(ByVal value As String)
                _Address2 = value
            End Set
        End Property


        Public Property Address1() As String
            Get
                Return _Address1
            End Get
            Set(ByVal value As String)
                _Address1 = value
            End Set
        End Property

        Public Property NewUserdetails() As Hashtable
            Get
                Return _NewUserdetails
            End Get
            Set(ByVal value As Hashtable)
                _NewUserdetails = value
            End Set
        End Property

		''' <summary>
		''' Gets or sets the <b>_UserName</b> attribute value.
		''' </summary>
		''' <value>The <b>_UserName</b> attribute value.</value>
		Public Property UserName() As String
			Get
				Return _UserName
			End Get
			Set
				_UserName = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_Password</b> attribute value.
		''' </summary>
		''' <value>The <b>_Password</b> attribute value.</value>
		Public Property Password() As String
			Get
				Return _Password
			End Get
			Set
				_Password = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_FirstName</b> attribute value.
		''' </summary>
		''' <value>The <b>_FirstName</b> attribute value.</value>
		Public Property FirstName() As String
			Get
				Return _FirstName
			End Get
			Set
				_FirstName = value
			End Set
		End Property
		''' <summary>
		''' Gets or sets the <b>_LastName</b> attribute value.
		''' </summary>
		''' <value>The <b>_LastName</b> attribute value.</value>
		Public Property LastName() As String
			Get
				Return _LastName
			End Get
			Set
				_LastName = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_Email</b> attribute value.
		''' </summary>
		''' <value>The <b>_Email</b> attribute value.</value>
		Public Property Email() As String
			Get
				Return _Email
			End Get
			Set
				_Email = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_Phoneno</b> attribute value.
		''' </summary>
		''' <value>The <b>_Phoneno</b> attribute value.</value>
		Public Property Phoneno() As String
			Get
				Return _Phoneno
			End Get
			Set
				_Phoneno = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_Location</b> attribute value.
		''' </summary>
		''' <value>The <b>_Location</b> attribute value.</value>
		Public Property Location() As String
			Get
				Return _Location
			End Get
			Set
				_Location = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the <b>_Created_By</b> attribute value.
		''' </summary>
		''' <value>The <b>_Created_By</b> attribute value.</value>
		Public Property Created_By() As String
			Get
				Return _Created_By
			End Get
			Set
				_Created_By = value
			End Set
		End Property
    End Class

    Namespace Validate
        Public Class clsValidate

#Region "Validation"

            Shared Function IsEmail(ByVal email As String) As Boolean
                Try
                    Return Regex.IsMatch(email, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|gov|mil|biz|info|mobi|name|aero|jobs|museum|in)\b)\Z", RegexOptions.IgnoreCase)
                Catch ex As ArgumentException
                    'Syntax error in the regular expression
                    Return False
                End Try
            End Function

            Shared Function IsValidUser(ByVal user As String, ByVal password As String) As Boolean
                Try
                    Return False
                Catch ex As ArgumentException
                    'Syntax error in the regular expression
                    Return False
                End Try
            End Function

#End Region

        End Class
    End Namespace
End Namespace



