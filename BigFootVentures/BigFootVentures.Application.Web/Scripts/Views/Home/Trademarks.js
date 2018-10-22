$(function () {
    $('form').submit(function (e) {
        e.preventDefault();
        window.open(location.origin + '/Home/Trademarks/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val(), '_self');
    });
});