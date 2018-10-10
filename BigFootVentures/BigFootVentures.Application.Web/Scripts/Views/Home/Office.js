$(function () {    
    InitScript();    
    
    $('form').submit(function () {
        $('[name="Record.RegistrationPaymentNotificationsSelected"] option').attr('selected', 'selected');
        $('[name="Record.RegistrationPaymentMethodsSelected"] option').attr('selected', 'selected');
        $('[name="Record.OppositionPaymentNotificationsSelected"] option').attr('selected', 'selected');
        $('[name="Record.OppositionPaymentMethodsSelected"] option').attr('selected', 'selected');
    });

    $('[name="Button.Add.RegistrationPaymentNotifications"]').on('click', function () {        
        var $available = $('[name="Record.RegistrationPaymentNotificationsAvailable"]');
        var $selected = $('[name="Record.RegistrationPaymentNotificationsSelected"]');
        
        $.each($available.val(), function (i, category) {
            $('[name="Record.RegistrationPaymentNotificationsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.RegistrationPaymentNotifications"]').on('click', function () {
        var $available = $('[name="Record.RegistrationPaymentNotificationsAvailable"]');
        var $selected = $('[name="Record.RegistrationPaymentNotificationsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.RegistrationPaymentNotificationsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    }); 

    $('[name="Button.Add.RegistrationPaymentMethods"]').on('click', function () {
        var $available = $('[name="Record.RegistrationPaymentMethodsAvailable"]');
        var $selected = $('[name="Record.RegistrationPaymentMethodsSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.RegistrationPaymentMethodsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.RegistrationPaymentMethods"]').on('click', function () {
        var $available = $('[name="Record.RegistrationPaymentMethodsAvailable"]');
        var $selected = $('[name="Record.RegistrationPaymentMethodsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.RegistrationPaymentMethodsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Add.OppositionPaymentNotifications"]').on('click', function () {
        var $available = $('[name="Record.OppositionPaymentNotificationsAvailable"]');
        var $selected = $('[name="Record.OppositionPaymentNotificationsSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.OppositionPaymentNotificationsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.OppositionPaymentNotifications"]').on('click', function () {
        var $available = $('[name="Record.OppositionPaymentNotificationsAvailable"]');
        var $selected = $('[name="Record.OppositionPaymentNotificationsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.OppositionPaymentNotificationsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Add.OppositionPaymentMethods"]').on('click', function () {
        var $available = $('[name="Record.OppositionPaymentMethodsAvailable"]');
        var $selected = $('[name="Record.OppositionPaymentMethodsSelected"]');

        $.each($available.val(), function (i, category) {
            $('[name="Record.OppositionPaymentMethodsAvailable"] option:contains("' + category + '")').remove();
            $selected.append($('<option>', { text: category }));
        });
    });

    $('[name="Button.Remove.OppositionPaymentMethods"]').on('click', function () {
        var $available = $('[name="Record.OppositionPaymentMethodsAvailable"]');
        var $selected = $('[name="Record.OppositionPaymentMethodsSelected"]');

        $.each($selected.val(), function (i, category) {
            $('[name="Record.OppositionPaymentMethodsSelected"] option:contains("' + category + '")').remove();
            $available.append($('<option>', { text: category }));
        });
    }); 
});

function InitScript() {
    $('[name="Record.RegistrationPaymentNotificationsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.RegistrationPaymentNotificationsSelected"] option:selected').removeAttr('selected');

    $('[name="Record.RegistrationPaymentMethodsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.RegistrationPaymentMethodsSelected"] option:selected').removeAttr('selected');

    $('[name="Record.OppositionPaymentNotificationsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.OppositionPaymentNotificationsSelected"] option:selected').removeAttr('selected');

    $('[name="Record.OppositionPaymentMethodsAvailable"] option:selected').removeAttr('selected');
    $('[name="Record.OppositionPaymentMethodsSelected"] option:selected').removeAttr('selected');
}

