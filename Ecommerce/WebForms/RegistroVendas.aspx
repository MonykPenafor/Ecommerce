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
                    <asp:RequiredFieldValidator
                        ID="rfvNomeCliente"
                        runat="server"
                        ControlToValidate="txtCliente"
                        ErrorMessage="O nome do cliente é obrigatório!"
                        CssClass="text-danger"
                        Display="Static" />
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

                <div class="col-2">
                    <div class="form-group">
                        <label for="txtQuantidade">Qtde.</label>
                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="form-control" TextMode="Number" placeholder="-" oninput="formatarInteiro(this)"></asp:TextBox>
                    </div>
                </div>
                <div class="col-2">
                    <div class="form-group">
                        <label for="txtPrecoUnitario">Preço Unitário</label>
                        <asp:TextBox ID="txtPrecoUnitario" runat="server" CssClass="form-control" Enabled="False" placeholder="-"></asp:TextBox>
                    </div>
                </div>

                <div class="col-1">
                    <div class="form-group">
                        <label for="btnInserir" style="color: transparent">---</label>
                        <asp:Button ID="btnInserir" runat="server" Text="Inserir" CssClass="btn btn-primary" CausesValidation="False" OnClick="BtnInserir_Click" />
                    </div>
                </div>

            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlItensVenda" runat="server" Style="padding: 20px;" CssClass="bg-light" Visible="false">
                    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-3" OnRowDeleting="gvProdutos_RowDeleting">
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
                            <asp:BoundField DataField="PrecoUnitario" HeaderText="Preço Unitário" DataFormatString="{0:C}">
                                <ItemStyle Width="10%" />
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ValorTotalItem" HeaderText="Valor Total" DataFormatString="{0:C}">
                                <ItemStyle Width="10%" />
                                <HeaderStyle Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnExcluir" runat="server" Text="Excluir" CommandName="Delete" CssClass="btn btn-danger" CausesValidation="False" />
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                                <HeaderStyle Width="10%" />
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                    <div class="col text-end ">
                        <div class="row mb-3 " style="display: inline-block;">
                            <asp:Label ID="lblTotalVenda" runat="server" CssClass="font-weight-bold" Text="Total da Venda: R$ 0,00" />
                        </div>

                        <div class="row-1">
                            <asp:Button ID="btnGerarVenda" runat="server" Text="Gerar Venda" CssClass="btn btn-primary" OnClick="BtnGerarVenda_Click" />
                        </div>
                    </div>

                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnInserir" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <script type="text/javascript">
            function limparCamposDadosDaVenda() {
                console.log("IDs dos campos:");
                console.log("Quantidade: " + '<%= txtQuantidade.ClientID %>');
            console.log("Preço Unitário: " + '<%= txtPrecoUnitario.ClientID %>');
            console.log("Produto: " + '<%= ddlProdutos.ClientID %>');
            console.log("Saldo em Estoque: " + '<%= lblSaldoEstoque.ClientID %>');

            $('#<%= txtQuantidade.ClientID %>').val('');
            $('#<%= txtPrecoUnitario.ClientID %>').val('');
            $('#<%= ddlProdutos.ClientID %>').prop('selectedIndex', 0);
            $('#<%= lblSaldoEstoque.ClientID %>').text('');
            }
        </script>
    </main>


</asp:Content>
