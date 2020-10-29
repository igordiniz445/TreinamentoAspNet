Public Class Veiculo
    Private _id As Integer
    Private _modelo As String
    Private _ano As String
    Private _valor As Decimal

    Public Veiculo()

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property modelo As String
        Get
            Return _modelo
        End Get
        Set(ByVal value As String)
            _modelo = value
        End Set
    End Property

    Public Property valor As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
        End Set
    End Property

    Public Property ano As String
        Get
            Return _ano
        End Get
        Set(ByVal value As String)
            _ano = value
        End Set
    End Property


    Public Function showVeiculo() As String
        Return "Modelo: " & vbTab & _modelo & vbCrLf &
            "Ano: " & vbTab & _ano & vbCrLf & "Valor: " & vbTab & CStr(_valor) & vbCrLf
    End Function

End Class
