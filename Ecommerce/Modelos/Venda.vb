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
End Class
