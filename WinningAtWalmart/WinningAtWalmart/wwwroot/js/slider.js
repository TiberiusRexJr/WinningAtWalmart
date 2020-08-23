$('#right-arrow').click(function () {
    var currentSlide = $(".slide.active");
    var nextSlide = currentSlide.next();
    currentSlide.fadeOut(300).removeClass('active');
   

    if (nextSlide.length == 0) {
        $('.slide').first().fadeIn(300).addClass("active");
    }
    else {
        nextSlide.fadeIn(300).addClass('active');
    }
});

$("#left-arrow").click(function ()
{
   
    var currentSlide = $('.slide.active');
    var previousSlide = currentSlide.prev();

    currentSlide.fadeOut(300).removeClass('active');
    previousSlide.fadeIn(300).addClass('active');
    

    if (previousSlide.length == 0) {
        $(".slide").last().fadeIn(300).addClass('active');
    }
    else {
        
    }
})

$(document).ready(function () {
    
})