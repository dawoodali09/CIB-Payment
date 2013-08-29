Imports System.Collections.Generic
Imports System.Collections
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions


Namespace Controller
    Public Class SessionManager

#Region "Variables"
     
        Private _UserName As String
        Private _FirstName As String
        Private _LastName As String
        Private _Email As String
        Private _Phoneno As String

        Private _LastLoginTime As String
        Private _CurrentLoginTime As String
        Private _CustomerType As String
        Private _OtherDetails As String
        Private _LoginStatus As Boolean
        Private _CustomerID As String

        Private _StatusID As Integer
        Private _WrongAttempts As Integer


#End Region

#Region "properties"

        Public Property WrongAttempts() As Integer
            Get
                Return _WrongAttempts
            End Get
            Set(ByVal value As Integer)
                _WrongAttempts = value
            End Set
        End Property

        Public Property StatusID() As Integer
            Get
                Return _StatusID
            End Get
            Set(ByVal value As Integer)
                _StatusID = value
            End Set
        End Property

        Public Property CustomerID() As String
            Get
                Return _CustomerID
            End Get
            Set(ByVal value As String)
                _CustomerID = value
            End Set
        End Property

        Public Property LoginStatus() As Boolean
            Get
                Return _LoginStatus
            End Get
            Set(ByVal value As Boolean)
                _LoginStatus = value
            End Set
        End Property

        Public Property OtherDetails() As String
            Get
                Return _OtherDetails
            End Get
            Set(ByVal value As String)
                _OtherDetails = value
            End Set
        End Property

        Public Property CustomerType() As String
            Get
                Return _CustomerType
            End Get
            Set(ByVal value As String)
                _CustomerType = value
            End Set
        End Property

        Public Property CurrentLoginTime() As String
            Get
                Return _CurrentLoginTime
            End Get
            Set(ByVal value As String)
                _CurrentLoginTime = value
            End Set
        End Property

        Public Property LastLoginTime() As String
            Get
                Return _LastLoginTime
            End Get
            Set(ByVal value As String)
                _LastLoginTime = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _UserName
            End Get
            Set(ByVal value As String)
                _UserName = value
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
            Set(ByVal value As String)
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
            Set(ByVal value As String)
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
            Set(ByVal value As String)
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
            Set(ByVal value As String)
                _Phoneno = value
            End Set
        End Property

#End Region


    End Class
End Namespace
