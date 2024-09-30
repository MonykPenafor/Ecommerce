
function showToast(message) {
    const toast = document.getElementById("toast");
    toast.textContent = message;
    toast.className = "show";
    setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 3000);
}

function RestringirASomenteNumeros(input) {
    var valor = input.value;

    valor = valor.replace(/[^0-9]/g, '');

    input.value = valor;
}

function closeModal() {
    $('#modalDetalhes').modal('hide');
}
