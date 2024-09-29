Public Class VisualizarVendas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregarVendas()
        End If
    End Sub

    Private Sub CarregarVendas()
        Dim vendaServico As VendaServico = New VendaServico()

        Dim vendas As List(Of Venda) = vendaServico.ConsultarVendas()

        gvVendas.DataSource = vendas
        gvVendas.DataBind()

        Dim total As Decimal = vendas.Sum(Function(item) item.ValorTotal)
        lblTotalVendas.Text = $"Total das Vendas: R$ {total:N2}"
    End Sub

    Protected Sub gvVendas_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "VerDetalhes" Then
            Dim idVenda As Integer = Convert.ToInt32(e.CommandArgument)

            Dim vendaDetalhes As String = "Detalhes da venda com ID: " & idVenda.ToString()

            lblDetalhesVenda.Text = vendaDetalhes

            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowModal", "$(function() { $('#modalDetalhes').modal('show'); });", True)
        End If
    End Sub

    Private Sub ExibirDetalhesVenda(idVenda As Integer)

    End Sub


End Class