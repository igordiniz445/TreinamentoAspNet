<%@ Page Title="Home Page" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="Height: 250px;Width: 920px;margin: 12px">
    <h2>
        Venda de Carros
    </h2>
    <br/>
    <br/>
    <div style="float:left; width: 450px">
        <div>
            <asp:Label ID="lblSelecao" runat="server" Text="Selecione o carro desejado"></asp:Label>
        </div>
        <br />
        <div style="width: 300px">
            <asp:DropDownList ID="dwVeiculos" runat="server" Width="300px" 
               AutoPostBack="True" ></asp:DropDownList>
            
        </div>
        <br/>
        <div>
            <asp:Label ID="lblTituloInfoCarro" runat="server" Width="300px" Text="Informações sobre veiculo: "></asp:Label>
            <br /><br />
            <asp:Label ID="lblInfoGeralCarro" Width="300px" Height="50px" runat="server" 
                ViewStateMode="Enabled"></asp:Label>
            <br />
            <asp:Label ID="lblPreco" runat="server" Text="Preço: ">
                <asp:Label ID="lblValorVeiculo" runat="server"></asp:Label>
            </asp:Label>
        </div>
        <br />
        <br />
        
    </div>
    <div style="float:right; width:450px">
        <asp:Label ID="Label2" runat="server" Text="Nome Completo"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Digite seu CPF para confirmar compra:"></asp:Label> <br />
        <asp:TextBox ID="txtCpf" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Placa do novo veículo"></asp:Label>
        <br />
        <asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnComprar" runat="server" Text="Comprar" />

        <br />
        <br />
    </div>
</div>
</asp:Content>