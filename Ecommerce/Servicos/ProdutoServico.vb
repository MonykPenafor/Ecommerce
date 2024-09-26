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

    Public Function AlterarProduto(produto As Produto) As String
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "UPDATE Produtos SET descricao = @Descricao, precoUnitario = @PrecoUnitario, saldoEstoque = @SaldoEstoque WHERE idProduto = @IdProduto"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdProduto", produto.IdProduto)
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao)
                    command.Parameters.AddWithValue("@PrecoUnitario", produto.PrecoUnitario)
                    command.Parameters.AddWithValue("@SaldoEstoque", produto.SaldoEstoque)

                    command.ExecuteNonQuery()
                End Using
            End Using

            Return "Produto alterado com sucesso!"

        Catch ex As SqlException
            Return "Erro ao alterar produto: " & ex.Message
        Catch ex As Exception
            Return "Erro ao alterar produto: " & ex.Message
        End Try
    End Function

    Public Function ConsultarProdutoPeloCodigo(codigo As String) As Produto
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT descricao, precoUnitario, saldoEstoque FROM Produtos WHERE idProduto = @IdProduto"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdProduto", codigo)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            Dim descricao As String = reader("descricao").ToString()
                            Dim precoUnitario As Decimal = Convert.ToDecimal(reader("precoUnitario"))
                            Dim saldoEstoque As Integer = Convert.ToInt32(reader("saldoEstoque"))

                            Dim produto As New Produto With {
                            .IdProduto = codigo,
                            .Descricao = descricao,
                            .PrecoUnitario = precoUnitario,
                            .SaldoEstoque = saldoEstoque
                        }

                            Return produto
                        Else
                            Return Nothing
                        End If
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            Throw New Exception("Erro ao consultar o produto: " & ex.Message)

        Catch ex As Exception
            Throw New Exception("Erro geral ao consultar o produto: " & ex.Message)
        End Try
    End Function

    Public Function ConsultarProdutosCadastrados() As List(Of Produto)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT idProduto, descricao, precoUnitario, saldoEstoque FROM Produtos"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim produtos As New List(Of Produto)()

                        While reader.Read()
                            Dim produto As New Produto With {
                            .IdProduto = Convert.ToInt32(reader("idProduto")),
                            .Descricao = reader("descricao").ToString(),
                            .PrecoUnitario = Convert.ToDecimal(reader("precoUnitario")),
                            .SaldoEstoque = Convert.ToInt32(reader("saldoEstoque"))
                        }

                            produtos.Add(produto)
                        End While

                        Return produtos
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            Throw New Exception("Erro ao consultar os produtos: " & ex.Message)

        Catch ex As Exception
            Throw New Exception("Erro geral ao consultar os produtos: " & ex.Message)
        End Try
    End Function

End Class
