$(function () {    
    InitScript();    

    /* START: Event Listeners */
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
    /* END: Event Listeners */

    $('[name="Information.Minimize"]').on('click', function () {
        ToggleElement('PanelBody.Information');

        $('[name="Information.Maximize"]').show();
        $('[name="Information.Minimize"]').hide();
    });

    $('[name="Information.Maximize"]').on('click', function () {
        ToggleElement('PanelBody.Information');

        $('[name="Information.Maximize"]').hide();
        $('[name="Information.Minimize"]').show();
    });

    $('[name="DeletionRequest.Minimize"]').on('click', function () {
        ToggleElement('PanelBody.DeletionRequest');

        $('[name="DeletionRequest.Maximize"]').show();
        $('[name="DeletionRequest.Minimize"]').hide();
    });

    $('[name="DeletionRequest.Maximize"]').on('click', function () {
        ToggleElement('PanelBody.DeletionRequest');

        $('[name="DeletionRequest.Maximize"]').hide();
        $('[name="DeletionRequest.Minimize"]').show();
    });
});

/* START: Functions */
function InitScript() {
    $('[name="Record.CategoriesAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.CategoriesSelected"] option:selected').removeAttr('selected');

    $('[name="Information.Maximize"]').hide();
    $('[name="DeletionRequest.Maximize"]').hide();    
}
/* END: Functions */

