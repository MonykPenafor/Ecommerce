<%@ Page Title="Cadastro de Produtos" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProdutos.aspx.vb" Inherits="Ecommerce.CadastroProdutos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <p>Your app description page.</p>
        <p>Use this area to provide additional information.</p>

        <div class="col">
            <div class="form-group">

                <asp:TextBox ID="codigo" runat="server" MaxLength="30" placeholder="Codigo"></asp:TextBox>

                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />

                <asp:TextBox ID="descricao" runat="server" MaxLength="30" placeholder="Descrição"></asp:TextBox>
                <asp:TextBox ID="precoUnitario" runat="server" MaxLength="30" placeholder="Preço Unitário"></asp:TextBox>
                <asp:TextBox ID="saldoEmEstoque" runat="server" MaxLength="30" placeholder="Saldo em Estoque"></asp:TextBox>

            </div>
        </div>

    </main>
</asp:Content>
