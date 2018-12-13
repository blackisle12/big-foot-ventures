$(function () {
    $('form').submit(function (e) {
        e.preventDefault();

        var keyword = $('[name="keyword"]').val();

        if (keyword.length > 0) {
            window.open(location.origin + '/Home/Brands/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val() + '/' + keyword + '/', '_self');
        }
        else {
            window.open(location.origin + '/Home/Brands/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val(), '_self');
        }
    });

    $('[name="Table.Brands"] tr').each(function () {
        $(this).find('td:nth-child(4)').each(function () {
            var catResult = $(this).html();
            var formatedCatResult = FormatResult(';', catResult, '<br>');
            $(this).empty();
            $(this).append(formatedCatResult);
        });
    });
});