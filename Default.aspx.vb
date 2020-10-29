Imports System.Data.SqlClient
Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim results As String

        myConn = New SqlConnection("Initial Catalog=Treinamento;" & _
                   "Data Source=localhost;Integrated Security=SSPI;")

        myCmd = myConn.CreateCommand
        myCmd.CommandText = "SELECT * FROM Carros"

        'Open the connection.
        myConn.Open()


    End Sub

End Class