$(function () {
    $('[name="Button.ParentAccountName"]').on('click', function () {
        $('[name="Modal.Input.SearchAccount"]').val('');
        $('[name="Modal.Input.Loader"]').hide();

        var currentName = $('[name="Record.ParentAccountName"]').val();
        var tbody = '';

        if (currentName.length > 0) {
            tbody += '<tr>';
            tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
            tbody += '</tr>';
        }

        $('[name="Modal.Table.Accounts"] tbody').html(tbody);

        $('.modal').modal('show');
    });

    $('[name="Modal.Input.SearchAccount"]').on('keyup', function () {
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
                    var currentValue = $('[name="Record.ParentAccountID').val();
                    var currentName = $('[name="Record.ParentAccountName"]').val();

                    if (currentName.length > 0) {
                        tbody += '<tr>';
                        tbody += '<td>' + currentName + '<span class="label label-primary pull-right">SELECTED</span></td>';
                        tbody += '</tr>';
                    }

                    $.each(response.Result, function (key, entry) {
                        if (entry.Value != currentValue) {
                            tbody += '<tr>';
                            tbody += '<td>' + entry.Text + '<button type="button" data-text="' + entry.Text + '" data-value="' + entry.Value + '" class="modal-table-select-account-btn pull-right">Select</button></td>';
                            tbody += '</tr>';
                        }
                    });

                    $('[name="Modal.Table.Accounts"] tbody').html(tbody);

                    $('.modal-table-select-account-btn').on('click', function () {
                        $('[name="Record.ParentAccountName"]').val($(this).data('text'));
                        $('[name="Record.ParentAccountID"]').val($(this).data('value'));

                        $('.modal').modal('hide');
                    });
                }
                else {

                }
            }
        });
    });
});