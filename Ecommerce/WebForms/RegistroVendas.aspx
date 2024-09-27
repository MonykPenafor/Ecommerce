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

            <div class="row d-flex" style="margin-bottom: 20px; margin-top: 10px;">
                <div class="col-6">
                    <label for="ddlProdutos">Produto</label>
                    <asp:DropDownList ID="ddlProdutos" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProdutos_SelectedIndexChanged"></asp:DropDownList>
                    <label id="lblSaldoEstoque" runat="server"></label>
                </div>

                <div class="col-1">
                    <div class="form-group">
                        <label for="txtQuantidade">Qtde.</label>
                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" TextMode="Number" AutoPostBack="True" OnTextChanged="txtQuantidade_TextChanged" placeholder="-"></asp:TextBox>
                    </div>
                </div>
                <div class="col-2">
                    <div class="form-group">
                        <label for="txtPrecoUnitario">Preço Unitário</label>
                        <asp:TextBox ID="txtPrecoUnitario" runat="server" CssClass="form-control" Enabled="False" placeholder="-"></asp:TextBox>
                    </div>
                </div>
                <div class="col-2">
                    <div class="form-group">
                        <label for="txtPrecoTotalProduto">Total</label>
                        <asp:TextBox ID="txtPrecoTotalProduto" runat="server" CssClass="form-control" Enabled="False" placeholder="-"></asp:TextBox>
                    </div>
                </div>
                <div class="col-1">
                    <div class="form-group">
                        <label for="btnInserir" style="color: transparent">---</label>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn btn-primary" OnClick="BtnInserir_Click" />
                    </div>
                </div>

            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlItensVenda" runat="server" Style="padding: 20px;" CssClass="bg-light" Visible="false">
                    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-3" ShowFooter="True" OnRowDataBound="gvProdutos_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="IdProduto" HeaderText="ID" />
                            <asp:BoundField DataField="DescricaoProduto" HeaderText="Descrição" />
                            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
                            <asp:BoundField DataField="PrecoUnitario" HeaderText="Preço Unitário" />
                            <asp:BoundField DataField="ValorTotalItem" HeaderText="Total" />
                        </Columns>
                        <FooterStyle CssClass="font-weight-bold" />
                    </asp:GridView>

                    <div class="col">
                        <asp:Label ID="lblTotalVenda" runat="server" CssClass="font-weight-bold" Text="Total da Venda: R$ 0,00" />
                        
                        <br />

                        <asp:Button ID="btnGerarVenda" runat="server" Text="Gerar Venda" CssClass="btn btn-primary" />
                    </div>

                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnInserir" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </main>
</asp:Content>
