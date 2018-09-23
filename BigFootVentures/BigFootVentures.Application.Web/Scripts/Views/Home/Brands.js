$(function () {
    $('#brandsTable tr').each(function () {
        $(this).find('td:nth-child(4)').each(function () {
            var catResult = $(this).html();
            var formatedCatResult = FormatResult(";", catResult, "<br>")
            $(this).empty();
            $(this).append(formatedCatResult);
        })
    })
})