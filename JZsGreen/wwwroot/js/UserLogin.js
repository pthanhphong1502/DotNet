﻿$(function () {

    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {
         // Get the form data.
        var url = "/UserAuth/Login";
        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();
        var email = $("#UserLoginModal input[name = 'UserName']").val();
        var password = $("#UserLoginModal input[name = 'Pass']").val();
        var rememberMe = $("#UserLoginModal input[name = 'RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            UserName: email,
            Pass: password,
            RememberMe: rememberMe
        };

        // Submit the form data using AJAX.
        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {
                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LoginInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserLoginModal").html(data);

                    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);
                    var form = $("#UserLoginForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);
                }
                else {
                    if (email == "admin@gmail.com") {
                        location.href = '/Admin/Home';
                    } else {
                        location.href = '';
                    }
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
         
    }
});