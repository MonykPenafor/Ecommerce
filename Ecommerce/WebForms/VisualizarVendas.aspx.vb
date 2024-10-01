Imports System.Data.SqlClient

Public Class VisualizarVendas
    Inherits System.Web.UI.Page

    Private ReadOnly Property VendaServico As New VendaServico()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregarVendas()
        End If
    End Sub

    Private Sub CarregarVendas()
        Dim vendas As List(Of Venda) = VendaServico.ConsultarVendas()

        gvVendas.DataSource = vendas
        gvVendas.DataBind()

        Dim total As Decimal = vendas.Sum(Function(item) item.ValorTotal)
        lblTotalVendas.Text = $"Total das Vendas: R$ {total:N2}"
    End Sub

    Protected Sub gvVendas_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "VerDetalhes" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = gvVendas.Rows(index)

            Dim idVenda As Integer = Convert.ToInt32(gvVendas.DataKeys(index).Value) ' Pega o ID da venda
            Dim nomeCliente As String = row.Cells(1).Text
            Dim dataVenda As String = row.Cells(2).Text
            Dim valorTotal As String = row.Cells(3).Text

            lblIdVenda.Text = idVenda.ToString()
            lblNomeCliente.Text = nomeCliente
            lblDataVenda.Text = dataVenda
            lblValorTotalVenda.Text = valorTotal

            Dim itensVenda As List(Of ItemVenda) = VendaServico.ConsultarItensVendaPeloIdDaVenda(idVenda)

            If itensVenda IsNot Nothing Then
                gvItensVenda.DataSource = itensVenda
                gvItensVenda.DataBind()

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowModal", "$(function() { $('#modalDetalhes').modal('show'); });", True)
            End If
        End If
    End Sub

End Class