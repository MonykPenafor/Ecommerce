Imports System.Data.SqlClient

Public Class VendaServico

    Private connectionString As String = ConfigurationManager.ConnectionStrings("EcommerceDB").ConnectionString

    Public Function SalvarVenda(venda As Venda) As String
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using transaction = connection.BeginTransaction()

                    Dim queryVenda As String = "INSERT INTO Vendas (nomeCliente, valorTotal)" &
                                           "OUTPUT INSERTED.idVenda " &
                                           "VALUES (@NomeCliente, @ValorTotal)"

                    Dim idVenda As Integer

                    Using commandVenda As New SqlCommand(queryVenda, connection, transaction)
                        commandVenda.Parameters.AddWithValue("@NomeCliente", venda.NomeCliente)
                        commandVenda.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal)

                        idVenda = Convert.ToInt32(commandVenda.ExecuteScalar())
                    End Using

                    For Each item As ItemVenda In venda.ItensVenda
                        Dim queryItem As String = "INSERT INTO ItensVendas (idProduto, idVenda, quantidade, valorTotalItem, precoUnitario)" &
                                              "VALUES (@IdProduto, @IdVenda, @Quantidade, @ValorTotalItem, @PrecoUnitario)"

                        Using commandItem As New SqlCommand(queryItem, connection, transaction)
                            commandItem.Parameters.AddWithValue("@IdProduto", item.IdProduto)
                            commandItem.Parameters.AddWithValue("@IdVenda", idVenda)
                            commandItem.Parameters.AddWithValue("@Quantidade", item.Quantidade)
                            commandItem.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario)
                            commandItem.Parameters.AddWithValue("@ValorTotalItem", item.ValorTotalItem)

                            commandItem.ExecuteNonQuery()
                        End Using
                    Next

                    transaction.Commit()

                End Using
            End Using

            Return "Venda e itens salvos com sucesso!"

        Catch ex As SqlException
            Return "Erro ao gerar venda: " & ex.Message

        Catch ex As Exception
            Return "Erro ao gerar venda: " & ex.Message
        End Try
    End Function

    Public Function ConsultarVendaPeloCodigo(codigo As String) As Venda
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT nomeCliente, valorTotal, dataVenda FROM Vendas WHERE idVenda = @IdVenda"

                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdVenda", codigo)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            Dim nomeCliente As String = reader("nomeCliente").ToString()
                            Dim valorTotal As Decimal = Convert.ToDecimal(reader("valorTotal"))
                            Dim dataVenda As Date = Convert.ToDateTime(reader("dataVenda"))

                            Dim venda As New Venda With {
                            .NomeCliente = nomeCliente,
                            .ValorTotal = valorTotal,
                            .DataVenda = dataVenda,
                            .IdVenda = codigo
                        }
                            Return venda
                        Else
                            Return Nothing
                        End If
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            Throw New Exception("Erro ao consultar venda: " & ex.Message)

        Catch ex As Exception
            Throw New Exception("Erro ao consultar venda: " & ex.Message)
        End Try
    End Function

    Public Function ConsultarVendas() As List(Of Venda)
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT idVenda, nomeCliente, valorTotal, dataVenda FROM Vendas"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim vendas As New List(Of Venda)()

                        While reader.Read()
                            Dim venda As New Venda With {
                            .IdVenda = Convert.ToInt32(reader("idVenda")),
                            .NomeCliente = (reader("nomeCliente")).ToString(),
                            .ValorTotal = Convert.ToDecimal(reader("valorTotal")),
                            .DataVenda = Convert.ToDateTime(reader("dataVenda"))
                        }

                            vendas.Add(venda)
                        End While

                        Return vendas
                    End Using
                End Using
            End Using

        Catch ex As SqlException
            Throw New Exception("Erro ao consultar as vendas: " & ex.Message)

        Catch ex As Exception
            Throw New Exception("Erro ao consultar as vendas: " & ex.Message)
        End Try
    End Function

    Public Function ConsultarItensVendaPeloIdDaVenda(idVenda As Integer) As List(Of ItemVenda)

        Dim itensVenda As New List(Of ItemVenda)()

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("GetVendaDetalhada", conn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@idVenda", idVenda)

                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            Dim item As New ItemVenda()

                            item.IdItemVenda = Convert.ToInt32(reader("idItemVenda"))
                            item.IdProduto = Convert.ToInt32(reader("idProduto"))
                            item.Quantidade = Convert.ToInt32(reader("quantidade"))
                            item.PrecoUnitario = Convert.ToDecimal(reader("precoUnitario"))
                            item.ValorTotalItem = Convert.ToDecimal(reader("valorTotalItem"))
                            item.DescricaoProduto = reader("descricao").ToString()

                            itensVenda.Add(item)
                        End While
                    End If
                End Using
            End Using
        End Using

        Return itensVenda
    End Function

End Class
