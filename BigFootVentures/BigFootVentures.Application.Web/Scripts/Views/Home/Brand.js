$(function () {    
    /* START: Event Listeners */
    $('[name="btn-add-categories"]').on('click', function () {        
        var $categoriesAvailable = $('[name="Record.CategoriesAvailable"]');
        var $categoriesSelected = $('[name="Record.CategoriesSelected"]');
        
        $.each($categoriesAvailable.val(), function (i, category) {
            $('[name="Record.CategoriesAvailable"] option:contains("' + category + '")').remove();
            $categoriesSelected.append($('<option>', { text: category }));
        });
    });

    $('[name="btn-remove-categories"]').on('click', function () {
        var $categoriesAvailable = $('[name="Record.CategoriesAvailable"]');
        var $categoriesSelected = $('[name="Record.CategoriesSelected"]');

        $.each($categoriesSelected.val(), function (i, category) {
            $('[name="Record.CategoriesSelected"] option:contains("' + category + '")').remove();
            $categoriesAvailable.append($('<option>', { text: category }));
        });
    });
    /* END: Event Listeners */
});