$(function () {
    InitScript();

    $('form').submit(function () {
        $('[name="Record.WIPODesignatedProtectionsSelected"] option').attr('selected', 'selected');
        $('[name="Record.WIPOBasicApplicationISOsSelected"] option').attr('selected', 'selected');
        $('[name="Record.ARIPODesignatedStatesSelected"] option').attr('selected', 'selected');
    });

    $('[name="Button.Add.WIPODesignatedProtection"]').on('click', function () {
        var $available = $('[name="Record.WIPODesignatedProtectionsAvailable"]');
        var $selected = $('[name="Record.WIPODesignatedProtectionsSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.WIPODesignatedProtectionsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.WIPODesignatedProtection"]').on('click', function () {
        var $available = $('[name="Record.WIPODesignatedProtectionsAvailable"]');
        var $selected = $('[name="Record.WIPODesignatedProtectionsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.WIPODesignatedProtectionsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Add.WIPOBasicApplicationISO"]').on('click', function () {
        var $available = $('[name="Record.WIPOBasicApplicationISOsAvailable"]');
        var $selected = $('[name="Record.WIPOBasicApplicationISOsSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.WIPOBasicApplicationISOsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.WIPOBasicApplicationISO"]').on('click', function () {
        var $available = $('[name="Record.WIPOBasicApplicationISOsAvailable"]');
        var $selected = $('[name="Record.WIPOBasicApplicationISOsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.WIPOBasicApplicationISOsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Add.ARIPODesignatedState"]').on('click', function () {
        var $available = $('[name="Record.ARIPODesignatedStatesAvailable"]');
        var $selected = $('[name="Record.ARIPODesignatedStatesSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.ARIPODesignatedStatesAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.ARIPODesignatedState"]').on('click', function () {
        var $available = $('[name="Record.ARIPODesignatedStatesAvailable"]');
        var $selected = $('[name="Record.ARIPODesignatedStatesSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.ARIPODesignatedStatesSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    });
});

function InitScript() {
    $('[name="Record.WIPODesignatedProtectionsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.WIPODesignatedProtectionsSelected"] option:selected').removeAttr('selected');

    $('[name="Record.WIPOBasicApplicationISOsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.WIPOBasicApplicationISOsSelected"] option:selected').removeAttr('selected');

    $('[name="Record.ARIPODesignatedStatesAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.ARIPODesignatedStatesSelected"] option:selected').removeAttr('selected');
}

