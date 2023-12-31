$(function () {
    loadVoucher();
    loadtotal();

    if (window.location.pathname == "/cart") {
        $('#height-body').css("height", "125px");
        $('#cart-title').css("display", "none");
        $('#cart-pro .cart').css("border-top-right-radius", "1rem");
        $('#cart-pro .cart').css("border-bottom-right-radius", "1rem");
    }
    else if (window.location.pathname == "/cart/checkout") {
        $('#cart-title').css("display", "none");
        $('header').css("display", "none");
        $('footer').css("display", "none");
        $('#height-body').css("height", "0");
        $('body').css("background", "#bbbbbb");
        $('#space-footer').css("display", "none");
    }
    else {
        loadCountCart();
        $('#height-body').css("height", "120px");
        addToCart();
    }
    minusAndPlusCart();
});

var minusAndPlusCart = function () {
    $('.plus.updatecartitem').click(function () {
        var $input = $(this).parent().find('.itemCount');
        $input.val(parseInt($input.val()) + 1);
        var productid = $(this).attr("data-productid");
        var quantity = $("#quantity-" + productid).val();
        var count = $input.val();
        $.ajax({
            method: "GET",
            url: "/cart/CheckQuantity?productid=" + productid,
            success: function (data) {
                if (count > data.quantity) {
                    alert("Số lượng sản phẩm này chỉ còn (" + data.quantity + " " + data.unit + ")");
                    $input.val(parseInt($input.val()) -1)
                    $input.change();

                } else {
                    updateCount(productid, quantity);
                    $input.change();
                }
            },
        });
    });
    $('.minus.updatecartitem').each(function (i) {
        $(this).click(function (e) {
            e.preventDefault();
            var $input = $(this).parent().find('.itemCount');
            var count = parseInt($input.val()) - 1;
            $input.val(count);
            $input.change();
            var productid = $(this).attr("data-productid");
            var quantity = $("#quantity-" + productid).val();
            updateCount(productid, quantity);

            if (count < 1) {
                $.ajax({
                    method: "Delete",
                    url: "/removecart/" + productid,
                    success: function () {
                        if (window.location.pathname == "/cart") {
                            window.location.href = "";
                        } else {
                            $('div[id^=activeCart]:eq(' + i + ')').css("display", "none").attr("data-id");
                            $('a[id^=addcart]:eq(' + i + ')').css("display", "block").attr("data-id");
                            $("a[id^=card-pro]:eq(" + i + ')').css("border", "none");
                            loadCountCart();
                        }
                    },
                });
            }

        });
    });
}

var addToCart = function () {
    var cardLoaded = [];
    $('a[id^=addcart]').each(function (i, item) {
        cardLoaded.push({ name: 'id', value: $(item).data('id') });
        var that = $(this);
        $.ajax({
            method: "GET",
            url: "/cart/jsonCartItems/",
            success: function (data) {
                $.each(data, function (index, value) {
                    if (cardLoaded[i].value == value.product.id) {
                        $(that).css("display", "none");
                        $('div[id^=activeCart]:eq(' + i + ')').css("display", "block").attr("data-id");
                        $('input[class^=itemCount]:eq(' + i + ')').val(value.quantity);
                        $(that).parent().find("a").css("border", "1px solid green");
                    }
                });
            }
        });
        $(that).click(function (e) {
            event.preventDefault();
            var id = $(this).attr("data-id");
            $(this).css("display", "none");
            $.ajax({
                method: "POST",
                url: "/addcart/" + id,
                dataType: "json",
                success: function (data) {
                    loadCountCart();
                }
            });
            $('div[id^=activeCart]:eq(' + i + ')').css("display", "block").attr("data-id");
            $('input[class^=itemCount]:eq(' + i + ')').val("1");
            $(that).parent().find("a").css("border", "1px solid green");
        });
    });
}
var loadCountCart = function () {
    $.ajax({
        method: "GET",
        url: "/Cart/GetTotalItemInCart",
        dataType: "json",
        success: function (data) {
            if (data == 0) {
                $('#cart-title').css("display", "none");
            }
            else {
                $('#cartCount').text(" " + data);
                $('#cart-title').css("display", "block");
            }
        }
    });
}

var updateCount = function (productid, quantity) {
    $.ajax({
        type: "POST",
        url: "/updatecart",
        datatype: "json",
        data: {
            productid: productid,
            quantity: quantity
        },
        success: function (result) {
            loadtotal();
        }
    });
}
var loadtotal = function () {
    $.ajax({
        type: "GET",
        url: "../cart/gettotal",
        datatype: "json",
        success: function (data) {
            $("#totalpro").text(data);
        }
    });
}


var loadVoucher = function () {
    $.ajax({
        type: "GET",
        url: "../cart/GetTotalDiscount",
        datatype: "json",
        success: function (data) {
            $("#discountVoucher").text(data + "%");
        }
    });
    $.ajax({
        type: "GET",
        url: "../cart/GetTotalBill",
        datatype: "json",
        success: function (data) {
            $("#totalBill").text(new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(data));
        }
    });
}
