
<Serializable()> _
Public Class MERCHANTS

#Region "Private Members"

    Private _id As Long
    Private _emailAddress As String
    Private _password As String
    Private _name As String

    Private _contactPerson As String
    Private _contactNumber As String
    Private _contactMobile As String

    Private _address As String
    Private _city As String
    Private _countryID As Integer

    Private _apiClientID As String
    Private _apiClientUserName As String
    Private _apiClientPassword As String

    Private _accountStatus As Integer
    Private _loginAttempsCount As Integer

    Private _created As String
    Private _approved As String
    Private _deleted As String



#End Region

#Region "Public Properties"

    Public Property ID() As Long
        Get
            Return _id
        End Get
        Set(ByVal value As Long)
            _id = value
        End Set
    End Property




    Public Property EmailAddress() As String
        Get
            Return _emailAddress
        End Get
        Set(ByVal value As String)
            _emailAddress = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property


    Public Property ContactPerson() As String
        Get
            Return _contactPerson
        End Get
        Set(ByVal value As String)
            _contactPerson = value
        End Set
    End Property
    Public Property ContactNumber() As String
        Get
            Return _contactNumber
        End Get
        Set(ByVal value As String)
            _contactNumber = value
        End Set
    End Property
    Public Property ContactMobile() As String
        Get
            Return _contactMobile
        End Get
        Set(ByVal value As String)
            _contactMobile = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property

    Public Property CountryID() As String
        Get
            Return _countryID
        End Get
        Set(ByVal value As String)
            _countryID = value
        End Set
    End Property

    Public Property ApiClientID() As String
        Get
            Return _apiClientID
        End Get
        Set(ByVal value As String)
            _apiClientID = value
        End Set
    End Property
    Public Property ApiClientUserName() As String
        Get
            Return _apiClientUserName
        End Get
        Set(ByVal value As String)
            _apiClientUserName = value
        End Set
    End Property



    Public Property ApiClientPassword() As String
        Get
            Return _apiClientPassword
        End Get
        Set(ByVal value As String)
            _apiClientPassword = value
        End Set
    End Property


    Public Property AccountStatus() As Integer
        Get
            Return _accountStatus
        End Get
        Set(ByVal value As Integer)
            _accountStatus = value
        End Set
    End Property

    Public Property LoginAttempsCount() As Integer
        Get
            Return _loginAttempsCount
        End Get
        Set(ByVal value As Integer)
            _loginAttempsCount = value
        End Set
    End Property


    Public Property Created() As String
        Get
            Return _created
        End Get
        Set(ByVal value As String)
            _created = value
        End Set
    End Property

    Public Property Approved() As String
        Get
            Return _approved
        End Get
        Set(ByVal value As String)
            _approved = value
        End Set
    End Property
    Public Property Deleted() As String
        Get
            Return _deleted
        End Get
        Set(ByVal value As String)
            _deleted = value
        End Set
    End Property

#End Region


End Class
