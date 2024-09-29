Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities

Public Class RegistroVendas
    Inherits System.Web.UI.Page

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
        Dim produtoServico As ProdutoServico = New ProdutoServico
        Dim produtos As List(Of Produto) = produtoServico.ConsultarProdutosCadastrados()

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

        Dim produtoServico As New ProdutoServico()
        Dim produto As Produto = produtoServico.ConsultarProdutoPeloCodigo(produtoId)

        If produto IsNot Nothing Then
            txtQuantidade.Text = ""
            txtPrecoUnitario.Text = produto.PrecoUnitario.ToString()
            lblSaldoEstoque.InnerText = "Saldo em Estoque: " + produto.SaldoEstoque.ToString()

            'If Not txtQuantidade.Text.IsNullOrWhiteSpace Then
            '    Dim total As Decimal = produto.PrecoUnitario * Int32.Parse(txtQuantidade.Text)
            '    txtPrecoTotalProduto.Text = total.ToString()
            'End If
        End If
    End Sub

    Protected Sub BtnInserir_Click(sender As Object, e As EventArgs)

        Dim idProduto As Integer = ddlProdutos.SelectedValue

        If Not idProduto = 0 Then

            If Not String.IsNullOrEmpty(txtQuantidade.Text) Then

                Dim produtoExistente As ItemVenda = ItensVenda.FirstOrDefault(Function(item) item.IdProduto = idProduto)

                If produtoExistente IsNot Nothing Then
                    Dim script As String = "showToast('Este produto já foi inserido na venda.');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
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
                    Dim script As String = $"showToast('{erros(0)}');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
                Else
                    ItensVenda.Add(itemVenda)

                    gvProdutos.DataSource = ItensVenda
                    gvProdutos.DataBind()

                    AtualizarTotalVenda()

                    pnlItensVenda.Visible = True
                End If
            Else

                Dim script As String = "showToast('Informe a quantidade!');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
            End If
        Else
            Dim script As String = "showToast('Selecione um produto para inserir!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
        End If

    End Sub

    Private Sub AtualizarTotalVenda()
        Dim total As Decimal = ItensVenda.Sum(Function(item) item.ValorTotalItem)
        lblTotalVenda.Text = total
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

                Dim vendaServico As VendaServico = New VendaServico()

                Dim venda As New Venda With {
                .NomeCliente = txtCliente.Text,
                .ValorTotal = Decimal.Parse(lblTotalVenda.Text),
                .ItensVenda = ItensVenda
                }

                Dim resultado As String = vendaServico.SalvarVenda(venda)

                If resultado = "Venda e itens salvos com sucesso!" Then
                    Session("ToastMessage") = resultado
                    Response.Redirect("PaginaPrincipal.aspx")
                End If

                Dim script As String = $"showToast('{resultado}');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
            Else
                Dim script As String = "showToast('Nenhum item foi adicionado à venda!');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
            End If
        Else
            Dim script As String = "showToast('Nome do cliente é obrigatório!');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
        End If
    End Sub

End Class