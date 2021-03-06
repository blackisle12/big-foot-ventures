﻿$(function () {    
    InitScript();    
    
    $('form').submit(function () {
        $('[name="Record.CategoriesSelected"] option').attr('selected', 'selected');
    });

    $('[name="Button.Add.Categories"]').on('click', function () {        
        var $categoriesAvailable = $('[name="Record.CategoriesAvailable"]');
        var $categoriesSelected = $('[name="Record.CategoriesSelected"]');
        
        $.each($categoriesAvailable.val(), function (i, category) {
            $('[name="Record.CategoriesAvailable"] option:contains("' + category + '")').remove();
            $categoriesSelected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.Categories"]').on('click', function () {
        var $categoriesAvailable = $('[name="Record.CategoriesAvailable"]');
        var $categoriesSelected = $('[name="Record.CategoriesSelected"]');

        $.each($categoriesSelected.val(), function (i, category) {
            $('[name="Record.CategoriesSelected"] option:contains("' + category + '")').remove();
            $categoriesAvailable.append($('<option>', { text: category }));
        });
    });    
});

function InitScript() {
    $('[name="Record.CategoriesAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.CategoriesSelected"] option:selected').removeAttr('selected');
}

