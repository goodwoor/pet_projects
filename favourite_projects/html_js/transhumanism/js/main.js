"use strict";
function checkSize()
{
    var fonts_size_x = document.body.clientWidth;

    // for small
    if(fonts_size_x < 1720)
    {
        $('body').css('font-size', '19px');
        $('.text-big').css('font-size', '22px');
        $('.label-small').css('font-size', '23px');
        $('.white-block').css('font-size', '19px');
        $('.label').css('font-size', '25px');
    }
    // for big
    if(fonts_size_x > 1720)
    {
        $('body').css('font-size', '23px');
        $('.text-big').css('font-size', '26px');
        $('.label-small').css('font-size', '27px');
        $('.white-block').css('font-size', '23px');
        $('.label').css('font-size', '29px');
    }
}

//resize
$(function() {
    $(window).resize(function() {
        checkSize();
    });
});

//обработчик скроллинга для кнопки
$(function() {
    $(window).scroll(function() {
        if($(this).scrollTop() != 0) {
            $('#toTop').fadeIn();
        } 
        else {
            $('#toTop').fadeOut();
        }
    });
     
    $('#toTop').click(function() {
        $('body,html').animate({scrollTop:0},800);
    });
     
});