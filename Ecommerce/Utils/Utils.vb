Public Class Utils

    Public Shared Function LimparEspacos(str As String) As String
        Dim resultado As String = Trim(str)

        ' Usa Regex para substituir múltiplos espaços por um único espaço
        resultado = Regex.Replace(resultado, "\s+", " ")

        Return resultado
    End Function


    Public Shared Sub MostrarMensagem(pagina As Page, mensagem As String)
        Dim script As String = $"showToast('{mensagem}');"
        ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), "MostrarToast", script, True)
    End Sub


End Class
