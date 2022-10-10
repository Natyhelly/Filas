// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//function novaReserva() {
//    var proximoId = proximoRegistro();
//    var idReserva = document.getElementById('id-reserva').value;
//    var nome = document.getElementById('nome-reserva').value;
//    var quantidade = document.getElementById('quantidade-reserva').value;

//    var idTr = idReserva != '' ? idReserva : proximoId;
//    var novaTr = '<tr id="' + idTr + '" class="registros"> \
//                            <td>' + nome + '</td> \
//                            <td>' + quantidade + '</td> \
//                            <td style="display: flex; justify-content: space-around; height: 41px; align-items:center"> \
//                                1º \
//                                <img onclick="deletarLinha('+ idTr + ')" src="lib/bootstrap/dist/icons/check-circle.svg" width="16" height="16" style="cursor: pointer"> \
//                            </td> \
//                        </tr>';

//    if (document.getElementById('id-reserva').value == '')
//        document.getElementById('bodyTabela').innerHTML += novaTr;
//    else
//        document.getElementById(idTr).innerHTML = novaTr;

    
//}

var btn = document.getElementById('btn-div');
var painel = document.querySelector('.itens-painel');
var quantidadePessoas = document.getElementById('quantidade-reserva').value;
var numeroPessoas = document.querySelector('.numero-pessoas').innerHTML;
var numeroMesas = document.querySelector('.numero-mesas').innerHTML;
btn.addEventListener('click', function () {
    if (painel.style.display == "none" && document.getElementById('quantidade-reserva').value == 1) {
        painel.style.display = "block";
        numeroPessoas = "Um";
        document.querySelector('.numero-mesas').innerHTML = "1";
    }
    else if (document.querySelector('.numero-pessoas').innerHTML == "Um" && document.querySelector('.numero-mesas').innerHTML == "1")
        document.querySelector('.numero-mesas').innerHTML = "2";
});

//function proximoRegistro() {
//    var proximoId = 0;
//    var registrosId = document.getElementsByClassName('registros');

//    for (let i = 0; i < registrosId.length; i++) {
//        if (proximoId < parseInt(registrosId[i].id))
//            proximoId = parseInt(registrosId[i].id);
//    }
//    return (proximoId + 1).toString();
//}