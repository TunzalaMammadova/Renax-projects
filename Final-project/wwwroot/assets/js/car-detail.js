
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
    

    $('#services-cart .owl-carousel').owlCarousel({
        loop: true,
        margin: 30,
        mouseDrag: true,
        autoplay: false,
        dots: true,
        autoplayHoverPause: true,
        nav: false,
        navText: ["<i class='fa-solid fa-chevron-left'></i>", "<i class='fa-solid fa-chevron-right'></i>"],
        responsiveClass: true,
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 2
            },
            1000: {
                items: 3
            }
        }
    });
    
    if ($(".accordion-box").length) {
        $(".accordion-box").on("click", ".acc-btn", function () {
            var outerBox = $(this).parents(".accordion-box");
            var target = $(this).parents(".item");
            if ($(this).next(".acc-content").is(":visible")) {
                $(this).removeClass("active");
                $(this).next(".acc-content").slideUp(300);
                $(outerBox).children(".item").removeClass("active-block");
            } 
            else {
                $(outerBox).find(".item .acc-btn").removeClass("active");
                $(this).addClass("active");
                $(outerBox).children(".item").removeClass("active-block");
                $(outerBox).find(".item").children(".acc-content").slideUp(300);
                target.addClass("active-block");
                $(this).next(".acc-content").slideDown(300);
            }
        });
    }


    let startDate = null;
    let endDate = null;

    Date.prototype.addDays = function (days) {
        var date = new Date(this.valueOf());
        date.setDate(date.getDate() + days);
        return date;
    };

    function getDates(startDate, stopDate) {
        var dateArray = [];
        var currentDate = startDate;
        while (currentDate <= stopDate) {
            dateArray.push(moment(new Date(currentDate)).format('YYYY-MM-DD'));
            currentDate = currentDate.addDays(1);
        }
        return dateArray;
    }

    let pickUpInput = $('input[name="pickUpDate"]');
    pickUpInput.daterangepicker({
        opens: 'left',
        autoUpdateInput: false,
        minDate: new Date(),
        isInvalidDate: function (ele) {
            var currDate = moment(ele._d).format('YYYY-MM-DD');
            return reservations.reduce((prev, val) => [...prev, ...getDates(val.startDate, val.endDate)], []).indexOf(currDate) != -1;
        }
    });

    let returnInput = $('input[name="returnDate"]');
    returnInput.daterangepicker({
        opens: 'left',
        autoUpdateInput: false,
        minDate: new Date(),
        isInvalidDate: function (ele) {
            var currDate = moment(ele._d).format('YYYY-MM-DD');
            return reservations.reduce((prev, val) => [...prev, ...getDates(val.startDate, val.endDate)], []).indexOf(currDate) != -1;
        }
    });

    pickUpInput.on('apply.daterangepicker', function (ev, picker) {
        startDate = picker.startDate.format('YYYY-MM-DD');
        $('input[name="pickUpDate"]').val(startDate);
    });
    returnInput.on('apply.daterangepicker', function (ev, picker) {
        endDate = picker.endDate.format('YYYY-MM-DD');
        $('input[name="returnDate"]').val(endDate);
    });

    $(document).on('click', '.booking-form .booking-box .booking-button', function (e) {
        e.preventDefault();

        let carId = parseInt($(this).attr("id"));
        let serviceId = $(".select-box").val();
        let enquiry = $(".message").val();
        let userEmail = $(".email").val();

        console.log("Form data:", carId, startDate, endDate, enquiry, serviceId);

        if (userEmail.trim() === "" || startDate === null || endDate === null || enquiry.trim() === "") {
            toastr["error"]("Please fill all inputs");
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };
            return;
        }

        $.ajax({
            url: `../AddReservation`,
            data: { carId, startDate, endDate, serviceId },
            type: 'POST',
            success: function (response) {
                toastr["success"]("Thanks for your reservation");
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };
            },
            error: function (response) {
                toastr["error"]("sss");
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-center",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };
            }
        });
    });
})