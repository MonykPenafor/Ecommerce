Imports System.Data.SqlClient
Imports Microsoft.Ajax.Utilities

Public Class RegistroVendas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PreencherDropDown()

            If Session("ItensVenda") IsNot Nothing Then
                Session.Remove("ItensVenda")
            End If

            pnlItensVenda.Visible = False
        End If
    End Sub

    Private Sub PreencherDropDown()
        Dim produtoServico As ProdutoServico = New ProdutoServico
        Dim produtos As List(Of Produto) = produtoServico.ConsultarProdutosCadastrados()

        ddlProdutos.DataSource = produtos
        ddlProdutos.DataTextField = "Descricao"
        ddlProdutos.DataValueField = "IdProduto"
        ddlProdutos.DataBind()
    End Sub


    Protected Sub ddlProdutos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim produtoId As String = ddlProdutos.SelectedValue

        Dim produtoServico As New ProdutoServico()
        Dim produto As Produto = produtoServico.ConsultarProdutoPeloCodigo(produtoId)

        If produto IsNot Nothing Then
            txtPrecoUnitario.Text = produto.PrecoUnitario.ToString()
            lblSaldoEstoque.InnerText = "Saldo em Estoque: " + produto.SaldoEstoque.ToString()

            'If Not txtQuantidade.Text.IsNullOrWhiteSpace Then
            '    Dim total As Decimal = produtoDetalhes.PrecoUnitario * Int32.Parse(txtQuantidade.Text)
            '    txtPrecoTotalProduto.Text = total.ToString()
            'End If

        End If
    End Sub





    Protected Sub txtQuantidade_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim produtoId As String = ddlProdutos.SelectedValue

    End Sub

    Protected Sub BtnInserir_Click(sender As Object, e As EventArgs)

        pnlItensVenda.Visible = True

        Dim itemVenda As New ItemVenda With {
            .IdProduto = ddlProdutos.SelectedValue,
            .DescricaoProduto = ddlProdutos.SelectedItem.Text,
            .PrecoUnitario = Decimal.Parse(txtPrecoUnitario.Text),
            .Quantidade = Int32.Parse(txtQuantidade.Text),
            .ValorTotalItem = Decimal.Parse(txtPrecoUnitario.Text) * Int32.Parse(txtQuantidade.Text)
        }

        Dim itensVenda As List(Of ItemVenda)

        If Session("ItensVenda") Is Nothing Then
            itensVenda = New List(Of ItemVenda)()
        Else
            itensVenda = CType(Session("ItensVenda"), List(Of ItemVenda))
        End If

        itensVenda.Add(itemVenda)

        Session("ItensVenda") = itensVenda

        gvProdutos.DataSource = itensVenda
        gvProdutos.DataBind()
    End Sub




    Private totalVenda As Decimal = 0

    Protected Sub gvProdutos_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        ' Verifica se a linha é de dados
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' Obtém o valor da coluna 'ValorTotalItem' e adiciona ao total
            Dim valorTotalItem As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ValorTotalItem"))
            totalVenda += valorTotalItem
        End If

        ' Se for o rodapé, mostra o total
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(3).Text = "Total:"
            e.Row.Cells(4).Text = totalVenda.ToString("C2") ' Formato de moeda
            e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
        End If
    End Sub












End Class