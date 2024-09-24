Imports System.Data.SqlClient

Public Class CadastroProdutos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnInserir_Click(sender As Object, e As EventArgs)
        Dim codigo As String = txtCodigo.Text
        Dim descricao As String = txtDescricao.Text
        Dim saldoEstoque As Integer = txtSaldoEstoque.Text
        Dim precoUnitario As Double = txtPrecoUnitario.Text

        Dim produto As New Produto With {
            .IdProduto = Integer.Parse(txtCodigo.Text),
            .Descricao = txtDescricao.Text,
            .PrecoUnitario = Decimal.Parse(txtPrecoUnitario.Text),
            .SaldoEstoque = Integer.Parse(txtSaldoEstoque.Text)
        }

        Dim erros As List(Of String) = produto.Validar()

        If erros.Count > 0 Then
            'MessageBox.Show(String.Join(Environment.NewLine, erros), "Erros de Validação")
        Else
            SalvarProduto(produto)
            txtCodigo.Text = ""
            txtDescricao.Text = ""
            txtSaldoEstoque.Text = ""
            txtPrecoUnitario.Text = ""

        End If
    End Sub



    Private connectionString As String = ConfigurationManager.ConnectionStrings("EcommerceDB").ConnectionString

    Public Function SalvarProduto(ByVal produto As Produto) As String
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

            Return "Produto criado com sucesso!"

        Catch ex As Exception
            Return "Erro ao criar produto: " & ex.Message
        End Try
    End Function


End Class