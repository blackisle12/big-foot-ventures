$(function () {
    $('[name="nav-toggle"]').on('click', function () {
        $('[name="sidebar"]').toggleClass('active');
        $('[name="overlay"]').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    $('[name="overlay"]').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('[name="overlay"]').toggleClass('active');
    });
}); 