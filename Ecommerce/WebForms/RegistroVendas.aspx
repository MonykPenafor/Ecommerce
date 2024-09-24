<%@ Page Title="Registro de Vendas" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroVendas.aspx.vb" Inherits="Ecommerce.RegistroVendas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>

        <div class="container" style="background-color: #20d6ef36; padding: 20px;">
            <h5>Dados do Cliente</h5>
            <div class="row">
                <div class="form-group">
                    <label for="txtCliente">Cliente</label>
                    <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" placeholder="Nome"></asp:TextBox>
                </div>
            </div>
        </div>

        <hr style="padding: 0; margin: 0;" />

        <div class="container" style="padding: 20px; border-radius: 1rem;">

            <h5>Dados da Venda</h5>

            <div class="row d-flex align-items-end" style="margin-bottom: 20px; margin-top: 10px;">
                <div class="col-8">
                    <label for="DdlProdutos">Produto</label>
                    <asp:DropDownList ID="DdlProdutos" runat="server" CssClass="form-control">
                        <asp:ListItem Value="--">--</asp:ListItem>
                        <asp:ListItem Value="A1">A1</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-1">
                    <div class="form-group">
                        <label for="txtQuantidade">Qtde.</label>
                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" placeholder="-"></asp:TextBox>
                    </div>
                </div>
                <div class="col-2">
                    <div class="form-group">
                        <label for="txtPrecoUnitario">Preço Unitário</label>
                        <asp:TextBox ID="txtPrecoUnitario" runat="server" CssClass="form-control" placeholder="-"></asp:TextBox>
                    </div>
                </div>
                <div class="col-1">
                    <asp:Button ID="BtnInserir" runat="server" Text="Inserir" CssClass="btn btn-primary" />
                </div>

            </div>
        </div>

        <div class="container d-flex justify-content-end" style="padding: 20px; border-radius: 1rem;">
            <asp:GridView runat="server">


            </asp:GridView>
           
            <asp:Button ID="BtnGerarVenda" runat="server" Text="Gerar Venda" CssClass="btn btn-primary" />

        </div>

    </main>
</asp:Content>
