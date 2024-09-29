<%@ Page Title="Visualizar Vendas" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarVendas.aspx.vb" Inherits="Ecommerce.VisualizarVendas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>

        <asp:GridView ID="gvVendas" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-3" OnRowCommand="gvVendas_RowCommand">
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
                <asp:BoundField DataField="ValorTotal" HeaderText="Valor Total">
                    <ItemStyle Width="10%" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnVerDetalhes" runat="server" Text="Ver Detalhes" CommandName="VerDetalhes" CommandArgument='<%# Eval("IdVenda") %>' CssClass="btn btn-primary" />
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
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalDetalhesLabel">Detalhes da Venda</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closeModal()">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">



                        <asp:Label ID="lblDetalhesVenda" runat="server" Text="Aqui vão os detalhes da venda."></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="closeModal()">Voltar</button>
                    </div>
                </div>
            </div>
        </div>


    </main>
</asp:Content>
