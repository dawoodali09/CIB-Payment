Imports System
Imports System.Collections.Generic
Imports System.Text

<Serializable()> _
Public Class SystemUser

#Region "Private Members"
    Private _ID As Long
    Private _FirstName As String = [String].Empty
    Private _LastName As String = [String].Empty
    Private _EmailAddress As String = [String].Empty
    Private _Password As String = [String].Empty
    Private _UserLevel As String = [String].Empty
    Private _Comment As String = [String].Empty
    Private _CIBEmployeeID As Integer = 0
    Private _SignatureURL As String = [String].Empty
    Private _Title As String = [String].Empty
    Private _Created As DateTime = DateTime.MinValue
    Private _Deleted As DateTime = DateTime.MinValue
#End Region

#Region "Public Properties"
    Public Overridable Property ID() As Long
        Get
            Return _ID
        End Get
        Set(ByVal Value As Long)
            _ID = Value
        End Set
    End Property


    Public Overridable Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal Value As String)
            _FirstName = Value
        End Set
    End Property


    Public Overridable Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal Value As String)
            _LastName = Value
        End Set
    End Property


    Public Overridable Property EmailAddress() As String
        Get
            Return _EmailAddress
        End Get
        Set(ByVal Value As String)
            _EmailAddress = Value
        End Set
    End Property


    Public Overridable Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal Value As String)
            _Password = Value
        End Set
    End Property


    Public Overridable Property UserLevel() As String
        Get
            Return _UserLevel
        End Get
        Set(ByVal Value As String)
            _UserLevel = Value
        End Set
    End Property


    Public Overridable Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal Value As String)
            _Comment = Value
        End Set
    End Property


    Public Overridable Property CIBEmployeeID() As Integer
        Get
            Return _CIBEmployeeID
        End Get
        Set(ByVal Value As Integer)
            _CIBEmployeeID = Value
        End Set
    End Property


    Public Overridable Property SignatureURL() As String
        Get
            Return _SignatureURL
        End Get
        Set(ByVal Value As String)
            _SignatureURL = Value
        End Set
    End Property


    Public Overridable Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
        End Set
    End Property


    Public Overridable Property Created() As DateTime
        Get
            Return _Created
        End Get
        Set(ByVal Value As DateTime)
            _Created = Value
        End Set
    End Property


    Public Overridable Property Deleted() As DateTime
        Get
            Return _Deleted
        End Get
        Set(ByVal Value As DateTime)
            _Deleted = Value
        End Set
    End Property


#End Region

    Public Sub New()
    End Sub
End Class
