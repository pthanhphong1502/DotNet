$(function () {
    $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

    $("#UserRegistrationModal button[name = 'register']").prop("disabled", false);

    function onAcceptUserAgreementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", false);
        }
        else {
            $("#UserRegistrationModal button[name = 'register']").prop("disabled", true);

        }

    }

    $("#UserRegistrationModal input[name = 'Email']").blur(function () {
        var email = $("#UserRegistrationModal input[name = 'Email']").val();
        var url = "UserAuth/UserNameExists?userName=" + email;
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {

                    PresentClosableBootstrapAlert("#alert_placeholder_register", "warning", "Invalid Email", "This email address has already been registered");

                }
                else {
                    CloseAlert("#alert_placeholder_register");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;

                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);

            }
        });
    });


    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);



    function onUserRegisterClick() {
        var url = "UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();
        var email = $("#UserRegistrationModal input[name='Email']").val();
        var password = $("#UserRegistrationModal input[name='Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name='ConfirmPassword']").val();
        var FullName = $("#UserRegistrationModal input[name='FullName']").val();
        var phoneNumber = $("#UserRegistrationModal input[name='PhoneNumber']").val();
        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FullName: FullName,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement: true,
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';
                if (hasErrors) {
                    $("#UserRegistrationModal").html(data);
                    var registerUserButton = $("#UserRegistrationModal button[name = 'register']").click(onUserRegisterClick);
                    $("#UserRegistrationModal input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = '';
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
                alert("Đăng ký tài khoản không thành công");
            }

        });

    }

});