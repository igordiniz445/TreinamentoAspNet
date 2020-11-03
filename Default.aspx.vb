Imports System.Data.SqlClient
Imports WebApplication1.Veiculo
Public Class _Default
    Inherits System.Web.UI.Page

    Private myConn As SqlConnection = New SqlConnection("Initial Catalog=treinamento;" & _
                   "Data Source=localhost;Integrated Security=SSPI;")



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader

        myCmd = myConn.CreateCommand
        myCmd.CommandText = "exec buscarTodosOsVeiculos"
        myConn.Open()

        myReader = myCmd.ExecuteReader()

        Dim count As Integer = 0


        If Not IsPostBack Then
            Do While myReader.Read()

                Dim veiculo As New Veiculo()
                veiculo.id = myReader.GetInt32(0)
                veiculo.modelo = myReader.GetString(1)
                veiculo.ano = myReader.GetInt32(2)
                veiculo.valor = myReader.GetDecimal(3)

                dwVeiculos.Items.Add(New ListItem(veiculo.modelo, veiculo.id))
            Loop
        End If
        myReader.Close()
    End Sub

    Protected Sub dwVeiculos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dwVeiculos.SelectedIndexChanged

        Dim selectedVeiculo As New Veiculo
        Dim id As Integer = dwVeiculos.SelectedItem.Value
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader

        myCmd = myConn.CreateCommand
        myCmd.CommandText = "Select * from veiculos where id= " & id
        myReader = myCmd.ExecuteReader()

        Dim veiculo As New Veiculo()
        Do While myReader.Read()
            veiculo.id = myReader.GetInt32(0)
            veiculo.modelo = myReader.GetString(1)
            veiculo.ano = myReader.GetInt32(2)
            veiculo.valor = myReader.GetDecimal(3)
        Loop
        lblInfoGeralCarro.Text = "Modelo: " & veiculo.modelo & vbCrLf & vbTab &
                                    "Ano: " & veiculo.ano
        lblValorVeiculo.Text = "R$ " & CStr(veiculo.valor) & ",00"

        Session("veiculoId") = id

    End Sub

    Protected Sub btnComprar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnComprar.Click
            
        realizarCompra()

        'Response.Write("<script language=""javascript"">alert('Parabéns pela compra!');</script>")

    End Sub

    Sub realizarCompra()

        Dim nomeCompleto As String = txtNome.Text.Trim
        Dim cpf As String = txtCpf.Text.Trim
        Dim placa As String = txtPlaca.Text.Trim
        Dim id As Integer = CInt(Session("veiculoId"))
        If Not cpf.Length = 11 Then
            Response.Write("<script>alert(CPF inválido);</script>")
        Else

            Try
                Dim myCmd As SqlCommand
                Dim myReader As SqlDataReader

                lbldebug.Text = Session("veiculoId")

                myCmd = myConn.CreateCommand

                myCmd.CommandType = CommandType.StoredProcedure
                myCmd.CommandText = "realizarCompra"
                myCmd.Parameters.AddWithValue("@nome", nomeCompleto)
                myCmd.Parameters.AddWithValue("@cpf", cpf)
                myCmd.Parameters.AddWithValue("@placa", placa)
                myCmd.Parameters.AddWithValue("@idVeiculo", id)

                myReader = myCmd.ExecuteReader()

                Response.Write("<script>alert(Parabéns pela compra!);</script>")
            Catch ex As Exception
                Response.Write("<script>alert(Não foi possível realizar compra, confira os dados inseridos!);</script>")
            End Try
        End If
    End Sub
    
End Class