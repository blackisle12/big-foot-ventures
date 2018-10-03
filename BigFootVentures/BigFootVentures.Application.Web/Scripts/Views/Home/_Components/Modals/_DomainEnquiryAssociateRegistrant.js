$(function () {
    $('[name="Button.RegistrantName"]').on('click', function () {
        $('[name="Modal.Input.SearchRegistrant"]').val('');
        $('[name="Modal.Input.Loader"]').hide();

        var currentName = $('[name="Record.RegistrantName"]').val();
        var tbody = '';

        if (currentName.length > 0) {
            tbody += '<tr>';
            tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
            tbody += '</tr>';
        }

        $('[name="Modal.Table.Registrant"] tbody').html(tbody);

        $('[name="Modal.Registrant"]').modal('show');
    });

    $('[name="Modal.Input.SearchRegistrant"]').on('keyup', function () {
        var value = $(this).val();

        if (value.length < 5) {
            return;
        }

        $('[name="Modal.Input.Loader"]').show();

        $.ajax({
            type: 'GET',
            url: '../../Register/Autocomplete/' + value,
            success: function (response) {
                $('[name="Modal.Input.Loader"]').hide();

                if (response.IsSuccess) {
                    var tbody = '';
                    var currentValue = $('[name="Record.RegistrantID').val();
                    var currentName = $('[name="Record.RegistrantName"]').val();

                    if (currentName.length > 0) {
                        tbody += '<tr>';
                        tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
                        tbody += '</tr>';
                    }

                    $.each(response.Result, function (key, entry) {
                        if (entry.Value != currentValue) {
                            tbody += '<tr>';
                            tbody += '<td>' + entry.Text + '<button type="button" data-text="' + entry.Text + '" data-value="' + entry.Value + '" class="modal-table-select-registrant-btn pull-right">Select</button></td>';
                            tbody += '</tr>';
                        }
                    });

                    $('[name="Modal.Table.Registrant"] tbody').html(tbody);

                    $('.modal-table-select-registrant-btn').on('click', function () {
                        $('[name="Record.RegistrantName"]').val($(this).data('text'));
                        $('[name="Record.RegistrantID"]').val($(this).data('value'));

                        $('[name="Modal.Registrant"]').modal('hide');
                    });
                }
                else {

                }
            }
        });
    });
});