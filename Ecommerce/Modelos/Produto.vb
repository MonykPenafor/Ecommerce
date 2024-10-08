﻿Imports System.Data.SqlClient

Public Class Produto

    Public Property IdProduto As Integer
    Public Property Descricao As String
    Public Property PrecoUnitario As Decimal
    Public Property SaldoEstoque As Integer

    Public Function Validar() As List(Of String)
        Dim erros As New List(Of String)()

        If IdProduto <= 0 Then
            erros.Add("O ID do produto deve ser maior que zero.")
        End If
        If String.IsNullOrWhiteSpace(Descricao) Then
            erros.Add("A descrição do produto é obrigatória.")
        End If
        If Descricao.Length > 100 Then
            erros.Add("A descrição do produto excede o limite de caracteres.")
        End If
        If PrecoUnitario <= 0 Then
            erros.Add("O preço unitário deve ser maior que zero.")
        End If
        If SaldoEstoque <= 0 Then
            erros.Add("O saldo de estoque deve ser maior que zero.")
        End If

        Return erros
    End Function

End Class
