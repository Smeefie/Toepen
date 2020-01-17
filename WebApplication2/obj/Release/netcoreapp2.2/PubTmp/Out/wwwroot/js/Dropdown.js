
///*Dropdown Menu*/


//$('.dropdown').focusout(function () {
//    toggleUp($(this));
//});

$(document).mousedown(function () {
    toggleUp($(".dropdown"));
});


$('.dropdown').mousedown(function (e) {
    e.stopPropagation();
    if ($(this).hasClass("active") == false) {
        toggleDown($(this));
    }
     
});

$('.dropdown .dropdown-menu li').mouseup(function () {
    if ($(this).parents('.dropdown').hasClass('active')) {
        if ($(this).attr('id') != "nonClick") {
            $(this).parents('.dropdown').find('span').text($(this).text());
            $(this).parents('.dropdown').find('input#valueField').attr('value', $(this).attr('id'));

            toggleUp($(this).parents('.dropdown'));
        } 
    }
});

function toggleUp(obj) {
   obj.attr('tabindex', 1).focus(false);
   obj.removeClass('active');
   obj.find('.dropdown-menu').slideUp(300);
}

function toggleDown(obj) {
    obj.attr('tabindex', 1).focus(true);
    obj.addClass('active');
    obj.find('.dropdown-menu').slideDown(300);
}


///*End Dropdown Menu*/


$('.dropdown-menu li').click(function () {
    var input = '<strong>' + $(this).parents('.dropdown').find('input').val() + '</strong>',
        msg = '<span class="msg">Hidden input value: ';
    $('.msg').html(msg + input + '</span>');
}); 