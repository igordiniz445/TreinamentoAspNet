Imports System.Data.SqlClient
Public Class About
    Inherits System.Web.UI.Page

    Private myConn As SqlConnection = New SqlConnection("Initial Catalog=treinamento;" & _
                   "Data Source=localhost;Integrated Security=SSPI;")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                realizarConsulta("buscarTodasAsCompras")

                'Response.Write("<script>alert(Parabéns pela compra!);</script>")
            Catch ex As Exception
                Response.Write("<script>alert(Não foi possível buscar ultimas compras!);</script>")
            End Try
        End If
        



    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click

        Dim paramentro As String = txtBoxBusca.Text.Trim

        If paramentro.Length < 7 Then
            If paramentro.Length = 0 Then
                realizarConsulta("buscarTodasAsCompras")
            End If
            realizarConsulta("buscarCompraByPlaca")
            Return
        ElseIf paramentro.Length > 11 Then
            Response.Write("<script>alert('CPF Inválido');</script>")
            Return
        ElseIf paramentro.Length = 7 Then
            realizarConsulta("buscarCompraByPlaca")
        ElseIf paramentro.Length = 11 Then
            realizarConsulta("buscarCompraByCpf")
        End If

    End Sub


    Sub realizarConsulta(ByVal consulta As String)
        Dim paramentro As String = txtBoxBusca.Text.Trim
        Dim myCmd As SqlCommand
        myCmd = myConn.CreateCommand
        myCmd.CommandType = CommandType.StoredProcedure
        myCmd.CommandText = consulta

        Select Case consulta
            Case "buscarCompraByPlaca"
                myCmd.Parameters.AddWithValue("@placa", paramentro)
            Case "buscarCompraByCpf"
                myCmd.Parameters.AddWithValue("@cpf", paramentro)
        End Select

        Dim adapter As New SqlDataAdapter(myCmd)

        Dim table As New DataTable

        adapter.Fill(table)

        myGridCompra.DataSource = table
        myGridCompra.DataBind()
    End Sub
End Class