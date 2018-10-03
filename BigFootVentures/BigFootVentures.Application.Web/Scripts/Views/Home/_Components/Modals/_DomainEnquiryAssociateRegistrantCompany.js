$(function () {
    $('[name="Button.RegistrantCompanyName"]').on('click', function () {
        $('[name="Modal.Input.SearchRegistrantCompany"]').val('');
        $('[name="Modal.Input.Loader"]').hide();

        var currentName = $('[name="Record.RegistrantCompanyName"]').val();
        var tbody = '';

        if (currentName.length > 0) {
            tbody += '<tr>';
            tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
            tbody += '</tr>';
        }

        $('[name="Modal.Table.RegistrantCompany"] tbody').html(tbody);

        $('[name="Modal.RegistrantCompany"]').modal('show');
    });

    $('[name="Modal.Input.SearchRegistrantCompany"]').on('keyup', function () {
        var value = $(this).val();

        if (value.length < 5) {
            return;
        }

        $('[name="Modal.Input.Loader"]').show();

        $.ajax({
            type: 'GET',
            url: '../../Company/Autocomplete/' + value,
            success: function (response) {
                $('[name="Modal.Input.Loader"]').hide();

                if (response.IsSuccess) {
                    var tbody = '';
                    var currentValue = $('[name="Record.RegistrantCompanyID').val();
                    var currentName = $('[name="Record.RegistrantCompanyName"]').val();

                    if (currentName.length > 0) {
                        tbody += '<tr>';
                        tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
                        tbody += '</tr>';
                    }

                    $.each(response.Result, function (key, entry) {
                        if (entry.Value != currentValue) {
                            tbody += '<tr>';
                            tbody += '<td>' + entry.Text + '<button type="button" data-text="' + entry.Text + '" data-value="' + entry.Value + '" class="modal-table-select-registrant-company-btn pull-right">Select</button></td>';
                            tbody += '</tr>';
                        }
                    });

                    $('[name="Modal.Table.RegistrantCompany"] tbody').html(tbody);

                    $('.modal-table-select-registrant-company-btn').on('click', function () {
                        $('[name="Record.RegistrantCompanyName"]').val($(this).data('text'));
                        $('[name="Record.RegistrantCompanyID"]').val($(this).data('value'));

                        $('[name="Modal.RegistrantCompany"]').modal('hide');
                    });
                }
                else {

                }
            }
        });
    });
});