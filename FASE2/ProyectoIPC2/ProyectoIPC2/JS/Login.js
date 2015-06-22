var main = function () {
    $('#Siguiente_L').click(function () {
        var slide_Activa = $('.active_slide');
        var slide_Siguiente = $('#Login');
        slide_Activa.fadeOut(1000).removeClass('active_slide');
        slide_Siguiente.fadeIn(2000).addClass('active_slide');

    });
    $('#Siguiente_R').click(function () {
        var slide_Activa = $('.active_slide');
        var slide_Siguiente = $('#Registro');
        slide_Activa.fadeOut(1000).removeClass('active_slide');
        slide_Siguiente.fadeIn(2000).addClass('active_slide');

    });
    $('#Siguiente_O').click(function () {
        var slide_Activa = $('.active_slide');
        var slide_Siguiente = $('#Olvido');
        slide_Activa.fadeOut(1000).removeClass('active_slide');
        slide_Siguiente.fadeIn(2000).addClass('active_slide');

    });
}
$(document).ready(main);

var keyCode
function tecla(e) {
    if (window.event) keyCode = window.event.keyCode;
    else if (e) keyCode = e.which;
    if (keyCode == 13)
        alert(keyCode)
    var button = document.getElementByid(Txt_Password);
    button
}