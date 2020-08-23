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

    var data = "eli";
    alert("hi");
    $.ajax({
        url: 'https://localhost:44363/Api/Get/data',
        type: 'POST',
        dataType: 'json',
        data: data,
        success: function (data, textStatus, xhr) {
            console.log(data);
            alert(data);
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr);
            console.log(textStatus);
            console.log(errorThrown);
            console.log('Error in Operation');
            alert("error" + errorThrown.toString());
        }
    });
})