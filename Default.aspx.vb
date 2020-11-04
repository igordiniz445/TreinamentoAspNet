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
            Dim dicionarioVeiculos As New Dictionary(Of Integer, Veiculo)
            Do While myReader.Read()

                Dim veiculo As New Veiculo()
                veiculo.id = myReader.GetInt32(0)
                veiculo.modelo = myReader.GetString(1)
                veiculo.ano = myReader.GetInt32(2)
                veiculo.valor = myReader.GetDecimal(3)

                dwVeiculos.Items.Add(New ListItem(veiculo.modelo, veiculo.id))
                dicionarioVeiculos.Add(veiculo.id, veiculo)
            Loop
            Session("dicionarioVeiculos") = dicionarioVeiculos
        End If
        myReader.Close()
    End Sub

    Protected Sub dwVeiculos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dwVeiculos.SelectedIndexChanged

        Dim selectedVeiculo As New Veiculo
        Dim id As Integer = dwVeiculos.SelectedItem.Value
        Dim dicionarioVeiculos As New Dictionary(Of Integer, Veiculo)

        dicionarioVeiculos = Session("dicionarioVeiculos")
        selectedVeiculo = dicionarioVeiculos.Values(id)

        'Response.Write("<script>alert(" & selectedVeiculo.ToString & ");</script>")

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
        lblInfoGeralCarro.Text = "Modelo: " & veiculo.modelo & "<br/>" &
                                    "Ano: " & veiculo.ano
        lblValorVeiculo.Text = "R$ " & CStr(veiculo.valor) & ",00"

        Session("veiculoId") = id

    End Sub

    Protected Sub btnComprar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnComprar.Click
            
        realizarCompra()

    End Sub

    Sub realizarCompra()

        Dim nomeCompleto As String = txtNome.Text.Trim
        Dim cpf As String = txtCpf.Text.Trim
        Dim placa As String = txtPlaca.Text.Trim
        Dim id As Integer = CInt(Session("veiculoId"))
        If Not cpf.Length = 11 Then
            Response.Write("<script>alert('CPF inválido');</script>")
        Else

            If validaCpf(cpf) Then
                Try
                    Dim myCmd As SqlCommand
                    Dim myReader As SqlDataReader

                    myCmd = myConn.CreateCommand

                    myCmd.CommandType = CommandType.StoredProcedure
                    myCmd.CommandText = "realizarCompra"
                    myCmd.Parameters.AddWithValue("@nome", nomeCompleto)
                    myCmd.Parameters.AddWithValue("@cpf", cpf)
                    myCmd.Parameters.AddWithValue("@placa", placa)
                    myCmd.Parameters.AddWithValue("@idVeiculo", id)

                    myReader = myCmd.ExecuteReader()

                    Response.Write("<script>alert('Compra Realizada com sucesso!');</script>")
                Catch ex As Exception
                    If ex.Message.Contains("Violação da restrição UNIQUE KEY") Then
                        Response.Write("<script>alert('Não foi possível realizar compra. Placa já registrada');</script>")
                    Else
                        Response.Write("<script>alert('Não foi possível realizar compra. Verifique os dados inseridos');</script>")
                    End If
                End Try
            Else
                Response.Write("<script>alert('CPF inválido');</script>")
            End If
        End If
    End Sub

    Function validaCpf(ByVal cpf As String) As Boolean

        Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, soma1, soma2 As Integer
        Dim resto1, resto2 As Decimal

        num1 = cpf.Substring(0, 1)
        num2 = cpf.Substring(1, 1)
        num3 = cpf.Substring(2, 1)
        num4 = cpf.Substring(3, 1)
        num5 = cpf.Substring(4, 1)
        num6 = cpf.Substring(5, 1)
        num7 = cpf.Substring(6, 1)
        num8 = cpf.Substring(7, 1)
        num9 = cpf.Substring(8, 1)
        num10 = cpf.Substring(9, 1)
        num11 = cpf.Substring(10, 1)
        'num1 = cpf.Substring(11, 1)

        If num1 = num2 And num2 = num3 And num3 = num4 And num4 = num5 And num5 = num6 And num6 = num7 And num7 = num8 And num8 = num9 And num9 = num10 And num10 = num11 Then
            Return False
        Else
            soma1 = num1 * 10 + num2 * 9 + num3 * 8 + num4 * 7 + num5 * 6 + num6 * 5 + num7 * 4 + num8 * 3 + num9 * 2
            resto1 = (soma1 * 10) Mod 11
            If resto1 = 10 Then
                resto1 = 0
            End If
            soma2 = num1 * 11 + num2 * 10 + num3 * 9 + num4 * 8 + num5 * 7 + num6 * 6 + num7 * 5 + num8 * 4 + num9 * 3 + num10 * 2
            resto2 = (soma2 * 10) Mod 11
            If resto2 = 10 Then
                resto2 = 0
            End If

            If (resto1 = num10) And (resto2 = num11) Then
                Return True
            Else
                Return False
            End If
        End If

        Return True
    End Function

End Class