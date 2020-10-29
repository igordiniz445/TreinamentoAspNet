Public Class Compra
    Private _idCompra As Integer
    Private _idVeiculo As Integer
    Private _cpf As String
    Private _nome As String
    Private _dataCompra As String
    Private _placa As String

    Public Compra()

    Public Property idCompra As Integer
        Get
            Return _idCompra
        End Get
        Set(ByVal value As Integer)
            _idCompra = value
        End Set
    End Property

    Public Property idVeiculo As Integer
        Get
            Return _idVeiculo
        End Get
        Set(ByVal value As Integer)
            _idVeiculo = value
        End Set
    End Property

    Public Property cpf As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    Public Property nome As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property dataCompra As String
        Get
            Return _dataCompra
        End Get
        Set(ByVal value As String)
            _dataCompra = value
        End Set
    End Property

    Public Property placa As String
        Get
            Return _placa
        End Get
        Set(ByVal value As String)
            _placa = value
        End Set
    End Property



End Class
