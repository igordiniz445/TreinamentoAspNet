<%@ Page Title="Consulta de vendas" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="About.aspx.vb" Inherits="WebApplication1.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="Height: 250px;Width: 920px;margin: 12px">
        <h2>
            Consulta de Vendas
        </h2>
        <br/>
        <br/>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Digite o CPF ou placa do veiculo para consultar venda"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txtBoxBusca" style="width:250px" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" style="margin-left:10px" runat="server" 
                Text="Buscar" />
            <br />
            <br />
            <div>
                <asp:GridView ID="myGridCompra" runat="server" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
            </div>
        </div>
    </div>


</asp:Content>
