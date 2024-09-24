<%@ Page Title="Cadastro de Produto" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProdutos.aspx.vb" Inherits="Ecommerce.CadastroProdutos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <div class="row">

            <div class="form-group col-2">
                <label for="txtCodigo">Código</label>
                <div class="input-group">
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" placeholder="Código"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="BtnCarregar" runat="server" Text="Carregar" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <div class="form-group col-6">
                <label for="txtDescricao">Descrição</label>
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" placeholder="Descrição"></asp:TextBox>
            </div>
            <div class="form-group col-2">
                <label for="txtSaldoEstoque">Saldo em Estoque</label>
                <asp:TextBox ID="txtSaldoEstoque" runat="server" CssClass="form-control" placeholder="Saldo em Estoque"></asp:TextBox>
            </div>
            <div class="form-group col-2">
                <label for="txtPrecoUnitario">Preço Unitário</label>
                <asp:TextBox ID="txtPrecoUnitario" runat="server" CssClass="dinheiro form-control" placeholder="Preço Unitário"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="d-flex justify-content-end gap-3">
            <asp:Button ID="BtnInserir" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="BtnInserir_Click"/>
            <asp:Button ID="BtnSalvarAlteracoes" runat="server" Text="Salvar Alterações" CssClass="btn btn-primary" />
        </div>
    </main>
</asp:Content>
