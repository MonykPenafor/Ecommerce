<%@ Page Title="Pagina Principal" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.vb" Inherits="Ecommerce.PaginaPrincipal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="ecommerce">ECOMMERCE</h1>
            <p class="lead">Ecommerce Projeto Movere</p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Cadastro de Produtos</h2>
                <p></p>
                <asp:Button ID="BtnCadProd" runat="server" Text="Cadastrar Produto" CssClass="btn btn-primary" OnClick="BtnCadProd_Click"/>

            </section>

            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Registro de Vendas</h2>
                <p></p>
                <asp:Button ID="BtnRegVenda" runat="server" Text="Registrar Venda" CssClass="btn btn-primary" OnClick="BtnRegVenda_Click"/>

            </section>

            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Visualizar Vendas</h2>
                <p></p>
                <asp:Button ID="BtnVisVenda" runat="server" Text="Visualizar Vendas" CssClass="btn btn-primary" OnClick="BtnVisVenda_Click"/>

            </section>
        </div>
    </main>
</asp:Content>


