
Imports System.IO
Imports System.Globalization
Imports System.Threading
Imports System.Resources


Public Class LogOut

    Inherits Page



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '//

        '//
        Session.Abandon()
    End Sub


End Class
