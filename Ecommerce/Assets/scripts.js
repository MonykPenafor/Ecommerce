
function showToast(message) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "show";
    setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 3000);
}

function formatarMoeda(input) {
    var valor = input.value;

    valor = valor.replace(',', '.');

    valor = valor.replace(/[^0-9.]/g, '');

    var partes = valor.split('.');
        if (partes.length > 2) {
        valor = partes[0] + '.' + partes[1];  // Se mais de um ponto, só permite um
        }

        if (partes[1] && partes[1].length > 2) {
        valor = partes[0] + '.' + partes[1].substring(0, 2);
        }

    input.value = valor;
}
