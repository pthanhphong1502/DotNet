$(function () {
    $('#activeBarPro').on("click", function () {
        $("#bar-pro").css({"display":"block", "opacity":"0"}).show().animate({opacity:1});
        $('#unActiveBarPro').css({ "display": "block", "opacity": "0" }).show().animate({ opacity: 1 });
        $(this).css("display", "none");
    });
    $('#unActiveBarPro').on("click", function () {
        $("#bar-pro").css("display", "none");
        $("#activeBarPro").css({ "display": "block", "opacity": "0" }).show().animate({ opacity: 1 });
        $(this).css("display", "none");
    });

    $('button[id^=update-isActive]').on("click", function () {
        var id = $(this).attr('data-productid');
        $.ajax({
            method: "PUT",
            url: "/Admin/Products/updateActive/" + id,
            dataType: "json",
            success: function (data) {
                window.location.href = "";
            }
        });
    });
    $('a[id^=card-pro]').hover(function () {
        var hide = $(this).find(".hide");
        hide.text("Xem Ngay");
        hide.css("background", "#198754");
    }, function () {
        var hide = $(this).find(".hide");
        $(this).find(".hide").text("")
        hide.css("background", "transparent");
    });

    $('.PagedList-skipToPrevious .page-link').text("Đầu Trang");
    $('.PagedList-skipToNext .page-link').text("Cuối Trang");
});


