<%@ Page Title="Cadastro de Produto" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProdutos.aspx.vb" Inherits="Ecommerce.CadastroProdutos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <div class="row">

            <div class="form-group col-2">
                <label for="txtCodigo">Código</label>
                <div class="input-group">
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control no-spin" placeholder="Código" oninput="RestringirASomenteNumeros(this)" MaxLength="10" ></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="btnCarregar" runat="server" Text="Carregar" CssClass="btn btn-primary" CausesValidation="False" OnClick="BtnCarregar_Click"/>
                    </div>
                </div>
                <asp:RequiredFieldValidator
                    ID="rfvCodigo"
                    runat="server"
                    ControlToValidate="txtCodigo"
                    ErrorMessage="O código é obrigatório!"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>

            <div class="form-group col-6">
                <label for="txtDescricao">Descrição</label>
                <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" MaxLength="100" placeholder="Descrição"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvDescricao"
                    runat="server"
                    ControlToValidate="txtDescricao"
                    ErrorMessage="A descrição é obrigatória!"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>

            <div class="form-group col-2">
                <label for="txtSaldoEstoque">Saldo em Estoque</label>
                <asp:TextBox ID="txtSaldoEstoque" runat="server" CssClass="form-control no-spin" MaxLength="8" placeholder="Saldo em Estoque" oninput="RestringirASomenteNumeros(this)"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvSaldoEstoque"
                    runat="server"
                    ControlToValidate="txtSaldoEstoque"
                    ErrorMessage="O saldo em estoque é obrigatório!"
                    CssClass="text-danger"
                    Display="Static" />

            </div>

            <div class="form-group col-2">
                <label for="txtPrecoUnitario">Preço Unitário</label>
                <asp:TextBox ID="txtPrecoUnitario" runat="server" CssClass="dinheiro form-control" MaxLength="12" placeholder="Preço Unitário" ></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvPrecoUnitario"
                    runat="server"
                    ControlToValidate="txtPrecoUnitario"
                    ErrorMessage="O preço unitário é obrigatório!"
                    CssClass="text-danger"
                    Display="Dynamic" />
            </div>
        </div>
        <br />

        <div class="d-flex justify-content-end gap-3">
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn btn-warning" CausesValidation="False" OnClick="BtnVoltar_Click" />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="BtnSalvar_Click" />
        </div>
    </main>
</asp:Content>
