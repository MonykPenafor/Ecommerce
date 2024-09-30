
Public Class Toast

    Public Shared Sub MostrarMensagem(pagina As Page, mensagem As String)
        Dim script As String = $"showToast('{mensagem}');"
        ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "MostrarToast", script, True)
    End Sub

End Class
