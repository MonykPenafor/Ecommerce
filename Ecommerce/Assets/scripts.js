
function showToast(message) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "show";
    setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 3000);
}

function formatarMoeda(input) {
    var valor = input.value;

    valor = valor.replace(/[^0-9,]/g, '');

    var partes = valor.split(',');
        if (partes.length > 2) {
        valor = partes[0] + ',' + partes[1];
        }

        if (partes[1] && partes[1].length > 2) {
        valor = partes[0] + ',' + partes[1].substring(0, 2);
        }

    input.value = valor;
}


function formatarInteiro(input) {
    var valor = input.value;

    valor = valor.replace(/[^0-9]/g, '');

    input.value = valor;
}


function atualizarPrecoUnitario(id) {

    var ddlProdutos = document.getElementById('<%= ddlProdutos.ClientID %>');
    var txtPrecoUnitario = document.getElementById('<%= txtPrecoUnitario.ClientID %>');

    var precoSelecionado = ddlProdutos.value;

    txtPrecoUnitario.value = "R$ " + precoSelecionado + ",00";
}



    function confirmarMensagem(mensagem, callback) {
        if (confirm(mensagem)) {
        callback(true);
        } else {
        callback(false);
        }
    }
