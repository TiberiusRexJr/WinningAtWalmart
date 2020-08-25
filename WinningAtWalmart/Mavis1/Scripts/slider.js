
$(document).ready(function () {

 
    OwlShit();
    GetData();
    
    
})
//functions
function OwlShit()
{
    alert("owl shit");
    var owl = $(".owl-carousel");
    owl.owlCarousel({
        items: 4,
        loop: true,
        margin: 10,
        autoplay: true,
        autoplayTimeout: 1000,
        autoplayHoverPause: true
    });
    $('.play').on('click', function () {
        owl.trigger('play.owl.autoplay', [1000])
    });
    $('.stop').on('click', function () {
        owl.trigger('stop.owl.autoplay')
    });
}
function GetData() {
    alert("hi");
    $.ajax({
        url: 'api/Values',
        type: 'GET',
        dataType: 'json',

        success: function (data, textStatus, xhr) {

            
            alert(data);
            
            $.each(data, function (index, value) {
                var data = $.parseJSON(value);
                $("<div class='item'>" + "<p>" + data.FirstName + "</p>" + "</div>").appendTo(".owl-carousel");
            })
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log(xhr);
            console.log(textStatus);
            console.log(errorThrown);
            console.log('Error in Operation');
            alert("error" + errorThrown.toString());
        }
    });
}

   