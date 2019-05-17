function OnRecordDelete(url) {
    if (confirm('Are you sure you want to delete this record?')) {
        window.location.href = url;
    }
}

$(function () {
    $('.open-link').click(function () {
        var link = $(this).data('link');

        if (!link.startsWith('http')) {
            link = 'http://' + link;
        }

        var win = window.open(link, '_blank');

        win.focus();
    });
});