Public Class Venda

    Public Property IdVenda As Integer
    Public Property NomeCliente As String
    Public Property ValorTotal As Decimal
    Public Property DataVenda As DateTime
    Public Property ItensVenda As List(Of ItemVenda)

    Public Function CalcularValorTotal() As Decimal
        If ItensVenda IsNot Nothing Then
            ValorTotal = ItensVenda.Sum(Function(item) item.ValorTotalItem)
        End If
        Return ValorTotal
    End Function

    Public Function Validar() As List(Of String)
        Dim erros As New List(Of String)()

        If String.IsNullOrEmpty(NomeCliente) Then
            erros.Add("O nome do cliente não pode estar vazio.")
        End If

        If DataVenda > DateTime.Now Then
            erros.Add("A data da venda não pode ser uma data futura.")
        End If

        If ItensVenda Is Nothing OrElse ItensVenda.Count = 0 Then
            erros.Add("A venda deve conter pelo menos um item.")
        End If

        If CalcularValorTotal() <= 0 Then
            erros.Add("O valor total da venda deve ser maior que zero.")
        End If

        Return erros
    End Function
End Class
