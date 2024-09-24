Public Class PaginaPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnCadProd_Click(sender As Object, e As EventArgs)
        Response.Redirect("CadastroProdutos.aspx")
    End Sub

    Protected Sub BtnRegVenda_Click(sender As Object, e As EventArgs)
        Response.Redirect("RegistroVendas.aspx")
    End Sub

    Protected Sub BtnVisVenda_Click(sender As Object, e As EventArgs)
        Response.Redirect("VisualizarVendas.aspx")
    End Sub
End Class