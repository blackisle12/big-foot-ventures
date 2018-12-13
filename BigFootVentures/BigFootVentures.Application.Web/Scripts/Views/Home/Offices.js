$(function () {
    $('form').submit(function (e) {
        e.preventDefault();

        var keyword = $('[name="keyword"]').val();

        if (keyword.length > 0) {
            window.open(location.origin + '/Home/Offices/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val() + '/' + keyword + '/', '_self');
        }
        else {
            window.open(location.origin + '/Home/Offices/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val(), '_self');
        }
    });
});