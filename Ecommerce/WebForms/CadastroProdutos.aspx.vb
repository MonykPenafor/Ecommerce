Imports System.Data.SqlClient

Public Class CadastroProdutos
    Inherits System.Web.UI.Page

    Private ReadOnly Property ProdutoServico As New ProdutoServico()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnSalvar_Click(sender As Object, e As EventArgs)

        Dim erroMensagem As String = ValidarCampos()

        If Not String.IsNullOrEmpty(erroMensagem) Then
            Utils.MostrarMensagem(Me, erroMensagem)
            Return
        End If

        Dim produto As New Produto With {
        .IdProduto = Convert.ToInt32(txtCodigo.Text),
        .Descricao = txtDescricao.Text,
        .PrecoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text),
        .SaldoEstoque = Convert.ToInt32(txtSaldoEstoque.Text)
        }

        Dim erros As List(Of String) = produto.Validar()

        If erros.Count > 0 Then
            Utils.MostrarMensagem(Me, erros(0))
        Else
            Dim produtoNaoCadastrado As Boolean = ProdutoServico.ConsultarProdutoPeloCodigo(produto.IdProduto) Is Nothing
            Dim resultado As String

            If produtoNaoCadastrado Then
                resultado = ProdutoServico.SalvarProduto(produto)
            Else
                resultado = ProdutoServico.AlterarProduto(produto)
            End If

            If resultado = "Produto salvo com sucesso!" Or resultado = "Produto alterado com sucesso!" Then
                LimparCampos(True)
            End If

            Session("ToastMessage") = resultado
            Response.Redirect("PaginaPrincipal.aspx")

        End If
    End Sub

    Private Function ValidarCampos() As String
        If String.IsNullOrEmpty(txtCodigo.Text) OrElse String.IsNullOrEmpty(txtDescricao.Text) OrElse
       String.IsNullOrEmpty(txtSaldoEstoque.Text) OrElse String.IsNullOrEmpty(txtPrecoUnitario.Text) Then
            Return "Por favor, preencha todos os campos para salvar."
        End If

        Dim saldoEstoque As Integer
        If Not Integer.TryParse(txtSaldoEstoque.Text, saldoEstoque) Then
            Return "O campo Saldo em Estoque deve ser um número válido."
        End If

        Dim precoUnitario As Double
        If Not Double.TryParse(txtPrecoUnitario.Text, precoUnitario) Then
            Return "O campo Preço Unitário deve ser um número válido."
        End If

        Return String.Empty
    End Function

    Protected Sub BtnCarregar_Click(sender As Object, e As EventArgs)

        If Not String.IsNullOrEmpty(txtCodigo.Text) Then
            Dim produto As Produto = ProdutoServico.ConsultarProdutoPeloCodigo(txtCodigo.Text)

            If produto IsNot Nothing Then
                txtDescricao.Text = Utils.LimparEspacos(produto.Descricao)
                txtPrecoUnitario.Text = produto.PrecoUnitario
                txtSaldoEstoque.Text = produto.SaldoEstoque
            Else

                Dim script As String = "showToast('Esse ID não está cadastrado!');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MostrarToast", script, True)
                LimparCampos(False)
            End If
        Else
            LimparCampos(False)
        End If

    End Sub

    Protected Sub BtnVoltar_Click(sender As Object, e As EventArgs)
        Response.Redirect("PaginaPrincipal.aspx")
    End Sub

    Private Sub LimparCampos(limparCodigo As Boolean)
        If limparCodigo Then
            txtCodigo.Text = ""
        End If

        txtDescricao.Text = ""
        txtPrecoUnitario.Text = ""
        txtSaldoEstoque.Text = ""
    End Sub

End Class