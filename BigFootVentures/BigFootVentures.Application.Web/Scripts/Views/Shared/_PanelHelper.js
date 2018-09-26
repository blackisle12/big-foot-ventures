$(function () {
    $('.panel-control').on('click', function () {
        $(this).parent().parent().siblings('.panel-body').toggle()

        var $control = $(this).children('i').first();
        
        if ($control.hasClass('fa-window-minimize')) {
            $control.removeClass('fa-window-minimize').addClass('fa-window-maximize');
        }
        else {
            $control.removeClass('fa-window-maximize').addClass('fa-window-minimize');
        }
    });
});