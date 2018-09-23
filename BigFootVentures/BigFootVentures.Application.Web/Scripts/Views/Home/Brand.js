$(function () {    
    InitScript();
    $('#infoMaximize').hide();
    $('#delMaximize').hide();
    /* START: Functions */
    function InitScript() {
        $('[name="Record.CategoriesAvailable"] option:selected').removeAttr('selected');
        $('[name="Record.CategoriesSelected"] option:selected').removeAttr('selected');
    }
    /* END: Functions */

    /* START: Event Listeners */
    $('form').submit(function () {
        $('[name="Record.CategoriesSelected"] option').attr('selected', 'selected');
    });

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

    $('#infoMinimize').on('click', function () {
        ToggleElement('panelInformation');
        $('#infoMaximize').show();
        $('#infoMinimize').hide()        
    });

    $('#infoMaximize').on('click', function () {
        ToggleElement('panelInformation');
        $('#infoMaximize').hide();
        $('#infoMinimize').show();
    });

    $('#delMinimize').on('click', function () {
        ToggleElement('delPanel');
        $('#delMaximize').show();
        $('#delMinimize').hide()
    });

    $('#delMaximize').on('click', function () {
        ToggleElement('delPanel');
        $('#delMaximize').hide();
        $('#delMinimize').show();
    });
});

