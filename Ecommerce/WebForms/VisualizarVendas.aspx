<%@ Page Title="Visualizar Vendas" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarVendas.aspx.vb" Inherits="Ecommerce.VisualizarVendas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <asp:GridView ID="gvVendas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-3" DataKeyNames="IdVenda" OnRowCommand="gvVendas_RowCommand">
            <Columns>
                <asp:BoundField DataField="IdVenda" HeaderText="ID">
                    <ItemStyle Width="7%" />
                    <HeaderStyle Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="NomeCliente" HeaderText="Cliente">
                    <ItemStyle Width="38%" />
                    <HeaderStyle Width="38%" />
                </asp:BoundField>
                <asp:BoundField DataField="DataVenda" HeaderText="Data">
                    <ItemStyle Width="15%" />
                    <HeaderStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total" DataFormatString="{0:C}" >
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>

                <asp:TemplateField>
                    <ItemTemplate>
                        
                <asp:Button ID="Button1" runat="server" Text="Ver Detalhes" CommandName="VerDetalhes" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-primary" />
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <div class="col text-end ">
            <div class="row mb-3 " style="display: inline-block;">
                <asp:Label ID="lblTotalVendas" runat="server" CssClass="font-weight-bold" Text="Total das Vendas: R$ 0,00" />
            </div>
        </div>

        <!-- Modal do Bootstrap -->
        <div class="modal fade" id="modalDetalhes" tabindex="-1" role="dialog" aria-labelledby="modalDetalhesLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalDetalhesLabel">Detalhes da Venda</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closeModal()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <!-- Informações principais da venda -->
                        <p><strong>ID da Venda:</strong>
                            <asp:Label ID="lblIdVenda" runat="server"></asp:Label></p>
                        <p><strong>Cliente:</strong>
                            <asp:Label ID="lblNomeCliente" runat="server"></asp:Label></p>
                        <p><strong>Data da Venda:</strong>
                            <asp:Label ID="lblDataVenda" runat="server"></asp:Label></p>
                        <p><strong>Valor Total da Venda:</strong>
                            <asp:Label ID="lblValorTotalVenda" CssClass="dinheiro" runat="server"></asp:Label></p>

                        <!-- GridView para exibir os itens da venda -->
                        <asp:GridView ID="gvItensVenda" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="IdProduto" HeaderText="ID" />
                                <asp:BoundField DataField="DescricaoProduto" HeaderText="Produto" />
                                <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
                                <asp:BoundField DataField="precoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:C}" />
                                <asp:BoundField DataField="valorTotalItem" HeaderText="Valor Total do Item" DataFormatString="{0:C}" />
                            </Columns>
                        </asp:GridView>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closeModal()">Voltar</button>
                    </div>
                </div>
            </div>
        </div>


    </main>
</asp:Content>
