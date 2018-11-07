$(function () {
    $('[name="nav-toggle"]').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('[name="overlay"]').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });

    $('[name="overlay"]').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('[name="overlay"]').toggleClass('active');
    });
}); 