Imports System.Data.SqlClient
Imports WebApplication1.Veiculo
Public Class _Default
    Inherits System.Web.UI.Page
    Private _veiculos As New Dictionary(Of Integer, Veiculo)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Dim results As String = ""


        myConn = New SqlConnection("Initial Catalog=treinamento;" & _
                   "Data Source=localhost;Integrated Security=SSPI;")

        System.Console.Write("OK ... ")
        myCmd = myConn.CreateCommand
        myCmd.CommandText = "exec buscarTodosOsVeiculos"
        myConn.Open()

        myReader = myCmd.ExecuteReader()

        Dim count As Integer = 0
        Do While myReader.Read()

            Dim veiculo As New Veiculo()
            veiculo.id = myReader.GetInt32(0)
            veiculo.modelo = myReader.GetString(1)
            veiculo.ano = myReader.GetInt32(2)
            veiculo.valor = myReader.GetDecimal(3)

            _veiculos.Add(count, veiculo)
            count += 1

            dwVeiculos.Items.Add(veiculo.modelo & " " & veiculo.ano)

        Loop


        'Open the connection.



    End Sub

    Protected Sub dwVeiculos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dwVeiculos.SelectedIndexChanged

        Dim selectedVeiculo As New Veiculo
        selectedVeiculo = _veiculos.Values(dwVeiculos.SelectedIndex)
        lblDebug.Text = dwVeiculos.SelectedIndex
        lblInfoGeralCarro.Text = selectedVeiculo.showVeiculo

    End Sub
End Class