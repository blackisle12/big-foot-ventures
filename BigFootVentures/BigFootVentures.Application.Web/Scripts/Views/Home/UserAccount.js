$(function () {    
    InitScript();    
    
    $('form').submit(function () {
        $('[name="Record.RolesSelected"] option').attr('selected', 'selected');
    });

    $('[name="Button.Add.Roles"]').on('click', function () {        
        var $available = $('[name="Record.RolesAvailable"]');
        var $selected = $('[name="Record.RolesSelected"]');
        
        $.each($available.val(), function (i, category) {
            $('[name="Record.RolesAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.Roles"]').on('click', function () {
        var $available = $('[name="Record.RolesAvailable"]');
        var $selected = $('[name="Record.RolesSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.RolesSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    }); 
});

function InitScript() {
    $('[name="Record.RolesAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.RolesSelected"] option:selected').removeAttr('selected');
}

