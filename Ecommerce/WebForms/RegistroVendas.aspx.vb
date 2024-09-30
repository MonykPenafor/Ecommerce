Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities

Public Class RegistroVendas
    Inherits System.Web.UI.Page

    Private ReadOnly Property ProdutoServico As New ProdutoServico()
    Private ReadOnly Property VendaServico As New VendaServico()

    Private Property ItensVenda As List(Of ItemVenda)
        Get
            If Session("ItensVenda") Is Nothing Then
                Session("ItensVenda") = New List(Of ItemVenda)()
            End If
            Return CType(Session("ItensVenda"), List(Of ItemVenda))
        End Get
        Set(value As List(Of ItemVenda))
            Session("ItensVenda") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PreencherDropDown()

            If Session("ItensVenda") IsNot Nothing Then
                Session.Remove("ItensVenda")
            End If
        End If

        AtualizarItensVenda()

    End Sub

    Private Sub PreencherDropDown()
        Dim produtos As List(Of Produto) = ProdutoServico.ConsultarProdutosCadastrados()

        ddlProdutos.DataSource = produtos
        ddlProdutos.DataTextField = "Descricao"
        ddlProdutos.DataValueField = "IdProduto"
        ddlProdutos.DataBind()

        ddlProdutos.Items.Insert(0, New ListItem("Selecione um produto", 0))
    End Sub

    Protected Sub ddlProdutos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim produtoId As String = ddlProdutos.SelectedValue

        If produtoId = 0 Then
            txtPrecoUnitario.Text = ""
            lblSaldoEstoque.InnerText = ""
        End If

        Dim produto As Produto = ProdutoServico.ConsultarProdutoPeloCodigo(produtoId)

        If produto IsNot Nothing Then
            txtQuantidade.Text = ""
            txtPrecoUnitario.Text = produto.PrecoUnitario.ToString()
            lblSaldoEstoque.InnerText = "Saldo em Estoque: " + produto.SaldoEstoque.ToString()
        End If
    End Sub

    Protected Sub BtnInserir_Click(sender As Object, e As EventArgs)

        Dim idProduto As Integer = ddlProdutos.SelectedValue

        If Not idProduto = 0 Then
            If Not String.IsNullOrEmpty(txtQuantidade.Text) Then

                Dim produtoExistente As ItemVenda = ItensVenda.FirstOrDefault(Function(item) item.IdProduto = idProduto)

                If produtoExistente IsNot Nothing Then
                    Toast.MostrarMensagem(Me, "Este produto já foi inserido na venda.")
                    Return
                End If

                Dim itemVenda As New ItemVenda With {
                .IdProduto = idProduto,
                .DescricaoProduto = ddlProdutos.SelectedItem.Text,
                .PrecoUnitario = Decimal.Parse(txtPrecoUnitario.Text),
                .Quantidade = Int32.Parse(txtQuantidade.Text),
                .ValorTotalItem = Decimal.Parse(txtPrecoUnitario.Text) * Int32.Parse(txtQuantidade.Text)
                }

                Dim erros As List(Of String) = itemVenda.Validar()

                If erros.Count > 0 Then
                    Toast.MostrarMensagem(Me, erros(0))
                Else
                    ItensVenda.Add(itemVenda)
                    gvProdutos.DataSource = ItensVenda
                    gvProdutos.DataBind()
                    AtualizarTotalVenda()
                    pnlItensVenda.Visible = True
                    ddlProdutos.SelectedValue = 0
                End If
            Else
                Toast.MostrarMensagem(Me, "Informe a quantidade!")
            End If
        Else
            Toast.MostrarMensagem(Me, "Selecione um produto para inserir!")
        End If

    End Sub

    Private Sub AtualizarTotalVenda()
        Dim total As Decimal = ItensVenda.Sum(Function(item) item.ValorTotalItem)
        lblTotalVenda.Text = $"Total da Venda: R$ {total}"
    End Sub

    Private Sub AtualizarItensVenda()
        If ItensVenda IsNot Nothing AndAlso ItensVenda.Count > 0 Then
            gvProdutos.DataSource = ItensVenda
            gvProdutos.DataBind()
            pnlItensVenda.Visible = True
        Else
            pnlItensVenda.Visible = False
        End If
    End Sub

    Protected Sub BtnGerarVenda_Click(sender As Object, e As EventArgs)

        If Not String.IsNullOrEmpty(txtCliente.Text) Then
            If Not ItensVenda.Count = 0 Then

                Dim venda As New Venda With {
                .NomeCliente = txtCliente.Text,
                .ItensVenda = ItensVenda,
                .ValorTotal = .CalcularValorTotal()
                }

                Dim erros As List(Of String) = venda.Validar()

                If erros.Count > 0 Then
                    Toast.MostrarMensagem(Me, erros(0))
                Else
                    Dim resultado As String = VendaServico.SalvarVenda(venda)

                    If resultado = "Venda e itens salvos com sucesso!" Then
                        Session("ToastMessage") = resultado
                        Response.Redirect("PaginaPrincipal.aspx")
                    End If

                    Toast.MostrarMensagem(Me, resultado)
                End If
            Else
                Toast.MostrarMensagem(Me, "Nenhum item foi adicionado à venda!")
            End If
        Else
            Toast.MostrarMensagem(Me, "Nome do cliente é obrigatório!")
        End If
    End Sub

End Class