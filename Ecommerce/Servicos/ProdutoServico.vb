Imports System.Data.SqlClient

Public Class ProdutoServico

    Private connectionString As String = ConfigurationManager.ConnectionStrings("EcommerceDB").ConnectionString

    Public Function SalvarProduto(produto As Produto) As String
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO Produtos (idProduto, descricao, precoUnitario, saldoEstoque) " &
                                  "VALUES (@IdProduto, @Descricao, @PrecoUnitario, @SaldoEstoque)"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdProduto", produto.IdProduto)
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao)
                    command.Parameters.AddWithValue("@PrecoUnitario", produto.PrecoUnitario)
                    command.Parameters.AddWithValue("@SaldoEstoque", produto.SaldoEstoque)

                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Produto salvo com sucesso!"

        Catch ex As SqlException
            If ex.Number = 2627 Then
                Return "Erro: O ID do produto já existe."
            Else
                Return "Erro ao criar produto: " & ex.Message
            End If

        Catch ex As Exception
            Return "Erro ao criar produto: " & ex.Message
        End Try
    End Function

End Class
