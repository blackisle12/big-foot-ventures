﻿$(function () {
    $('form').submit(function (e) {
        e.preventDefault();
        window.open(location.origin + '/Home/TrademarkOwners/' + $('[name="rowCount"]').val() + '/' + $('[name="page"]').val(), '_self');
    });
});