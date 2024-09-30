Public Class ItemVenda

    Public Property IdItemVenda As Integer
    Public Property IdProduto As Integer
    Public Property DescricaoProduto As String
    Public Property Quantidade As Integer
    Public Property PrecoUnitario As Decimal
    Public Property ValorTotalItem As Decimal

    Public Function Validar() As List(Of String)
        Dim erros As New List(Of String)()

        Dim produtoServico As ProdutoServico = New ProdutoServico()
        Dim produto As Produto = produtoServico.ConsultarProdutoPeloCodigo(IdProduto)

        If produto Is Nothing Then
            erros.Add("O produto informado não foi encontrado no sistema. Verifique o código e tente novamente.")
        End If
        If produto.SaldoEstoque < Quantidade Then
            erros.Add("A quantidade solicitada excede o estoque disponível. Reduza a quantidade ou escolha outro produto.")
        End If
        If Quantidade <= 0 Then
            erros.Add("A quantidade informada é inválida. Deve ser maior que zero.")
        End If
        If PrecoUnitario < 0 Then
            erros.Add("O preço deve ser maior que zero.")
        End If

        Return erros
    End Function

End Class
