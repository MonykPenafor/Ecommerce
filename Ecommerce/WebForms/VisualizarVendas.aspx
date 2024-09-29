<%@ Page Title="Visualizar Vendas" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarVendas.aspx.vb" Inherits="Ecommerce.VisualizarVendas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <asp:GridView ID="gvVendas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-3">
            <Columns>
                <asp:BoundField DataField="IdProduto" HeaderText="ID">
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="DescricaoProduto" HeaderText="Descrição">
                    <ItemStyle Width="40%" />
                    <HeaderStyle Width="40%" />
                </asp:BoundField>
                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade">
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="PrecoUnitario" HeaderText="Preço Unitário">
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:BoundField DataField="ValorTotalItem" HeaderText="Valor Total">
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

        <div class="col text-end ">
            <div class="row mb-3 " style="display: inline-block;">
                <asp:Label ID="lblTotalVendas" runat="server" CssClass="font-weight-bold" Text="Total das Vendas: R$ 0,00" />
            </div>

        </div>




    </main>
</asp:Content>
