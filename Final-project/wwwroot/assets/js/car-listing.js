$(function () {

    $(window).on("scroll", function () {
        var bodyScroll = $(this).scrollTop(),
            navbar = $(".navbar");
        if (bodyScroll > 100) {
            navbar.addClass("nav-scroll");
        } else {
            navbar.removeClass("nav-scroll");
        }
    });

    var progressPath = document.querySelector('.progress-wrap path');
    var pathLength = progressPath.getTotalLength();
    progressPath.style.transition = progressPath.style.WebkitTransition = 'none';
    progressPath.style.strokeDasharray = pathLength + ' ' + pathLength;
    progressPath.style.strokeDashoffset = pathLength;
    progressPath.getBoundingClientRect();
    progressPath.style.transition = progressPath.style.WebkitTransition = 'stroke-dashoffset 10ms linear';
    var updateProgress = function () {
        var scroll = $(window).scrollTop();
        var height = $(document).height() - $(window).height();
        var progress = pathLength - (scroll * pathLength / height);
        progressPath.style.strokeDashoffset = progress;
    }
    updateProgress();
    $(window).scroll(updateProgress);
    var offset = 150;
    var duration = 550;
    jQuery(window).on('scroll', function () {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.progress-wrap').addClass('active-progress');
        } else {
            jQuery('.progress-wrap').removeClass('active-progress');
        }
    });
    jQuery('.progress-wrap').on('click', function (event) {
        event.preventDefault();
        jQuery('html, body').animate({
            scrollTop: 0
        }, duration);
        return false;
    })

    $('#all-cars .sort select').on('change', function () {
        const value = $(this).val().trim();
        $(".car-list .row").slice(0).remove();

        $.ajax({
            type: "Get",
            url: "CarListing/Index",
            data: { sort: value },
            success: function (res) {
                console.log(res);
                $('#all-cars .car-list').html(res);
            },
        });
    });


    $('.cars-filter .cars-group button').on('click', function () {
        const value = $(this).html();
        $(".car-list .row").slice(0).remove();
        $.ajax({
            type: "Get",
            url: "CarListing/Index",
            data: { sort: value },
            success: function (res) {
                $('#all-cars .car-list').html(res);
            },
        });
    });


})