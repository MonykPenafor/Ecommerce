Imports System.Data.SqlClient

Public Class CadastroProdutos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnInserir_Click(sender As Object, e As EventArgs)

        If String.IsNullOrEmpty(txtCodigo.Text) OrElse String.IsNullOrEmpty(txtDescricao.Text) OrElse
       String.IsNullOrEmpty(txtSaldoEstoque.Text) OrElse String.IsNullOrEmpty(txtPrecoUnitario.Text) Then

            Dim script As String = "<script type='text/javascript'>showToast('Por favor, preencha todos os campos antes de salvar.');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "MostrarToast", script)
            Return
        End If

        Dim codigo As String = txtCodigo.Text
        Dim descricao As String = txtDescricao.Text
        Dim saldoEstoque As Integer
        Dim precoUnitario As Double

        If Not Integer.TryParse(txtSaldoEstoque.Text, saldoEstoque) Then
            Dim script As String = "<script type='text/javascript'>showToast('O campo Saldo em Estoque deve ser um número válido.');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "MostrarToast", script)
            Return
        End If

        If Not Double.TryParse(txtPrecoUnitario.Text, precoUnitario) Then
            Dim script As String = "<script type='text/javascript'>showToast('O campo Preço Unitário deve ser um número válido.');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "MostrarToast", script)
            Return
        End If

        Dim produto As New Produto With {
            .IdProduto = codigo,
            .Descricao = descricao,
            .PrecoUnitario = precoUnitario,
            .SaldoEstoque = saldoEstoque
        }

        Dim erros As List(Of String) = produto.Validar()

        If erros.Count > 0 Then

            Dim script As String = $"<script type='text/javascript'>showToast('{erros(0)}');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "MostrarToast", script)

        Else
            Dim resultado As String = SalvarProduto(produto)
            txtCodigo.Text = ""
            txtDescricao.Text = ""
            txtSaldoEstoque.Text = ""
            txtPrecoUnitario.Text = ""

            Dim script As String = $"<script type='text/javascript'>showToast('{resultado}');</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "MostrarToast", script)

        End If
    End Sub

End Class