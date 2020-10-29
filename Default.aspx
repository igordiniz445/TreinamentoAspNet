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
    <div>
        <div>
            <asp:Label ID="lblSelecao" runat="server" Text="Selecione o carro desejado"></asp:Label>
        </div>
        <br />
        <div style="width: 300px">
            <asp:DropDownList ID="dwVeiculos" runat="server" Width="300px"></asp:DropDownList>
        </div>
        <br/>
        <div>
            <asp:Label ID="lblTituloInfoCarro" runat="server" Text="Informações sobre veiculo: "></asp:Label>
            <br />
            <asp:Label ID="lblInfoGeralCarro" runat="server" Text="xxt"></asp:Label>
            <br />
            <asp:Label ID="lblPreco" runat="server" Text="Preço: ">
                <asp:Label ID="lblValorVeiculo" runat="server" Text="R$50000"></asp:Label>
            </asp:Label>
        </div>
        <br />
        <br />
        <br />
        <asp:Label ID="lblDebug" runat="server" Text="DEBUG"></asp:Label>
    </div>
    
</div>

</asp:Content>