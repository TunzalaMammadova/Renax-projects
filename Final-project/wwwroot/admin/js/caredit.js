
$(function () {

    $(document).on("click", ".product-images .product-action .make-main", function (e) {
        e.preventDefault();
        let id = parseInt($(this).parent().parent().parent().parent().attr("data-id"))
        let CarId = parseInt($(this).parent().parent().parent().parent().attr("data-car-id"))

        console.log(id, CarId);
        $.ajax({
            url: `../ChangeMainImage?id=${id}&CarId=${CarId}`,
            type: 'POST',
            success: function (response) {
                $(".main-image").removeClass("main-image");
                $(`[data-id = ${id}]`).addClass("main-image");
            },
        });
    })

    $(document).on("click", ".product-images .product-action .remove-image", function (e) {
        e.preventDefault();
        let id = parseInt($(this).parent().parent().parent().parent().attr("data-id"))
        let CarId = parseInt($(this).parent().parent().parent().parent().attr("data-car-id"))
        $.ajax({
            url: `../DeleteCarImage?imageId=${id}&carId=${CarId}`,
            type: 'POST',
            success: function (response) {
                $(`[data-id = ${id}]`).remove();
            },
            error: function (response) {
                toastr["error"]("Cannot remove main image")
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
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
                }
            }
        });
    })

});