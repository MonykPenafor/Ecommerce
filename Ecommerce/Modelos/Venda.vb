Public Class Venda

    Public Property IdVenda As Integer
    Public Property NomeCliente As String
    Public Property ValorTotal As Decimal
    Public Property DataVenda As Date
    Public Property ItensVenda As List(Of ItemVenda)

    Public Sub New()
        ItensVenda = New List(Of ItemVenda)()
    End Sub

    Public Function CalcularValorTotal() As Decimal
        ValorTotal = ItensVenda.Sum(Function(item) item.ValorTotalItem)
        Return ValorTotal
    End Function
End Class
