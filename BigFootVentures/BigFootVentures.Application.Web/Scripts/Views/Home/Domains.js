$(function () {
    $('form').submit(function (e) {
        e.preventDefault();
        window.open(location.origin + '/Home/Domains/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val(), '_self');
    });
});