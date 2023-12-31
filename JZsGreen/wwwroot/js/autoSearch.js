$(function () {
    const apiBaseUrl = "/Product/GetNameList"
    $.ajax(`${apiBaseUrl}`)
        .done(function (result) {
            $("#search").autocomplete({
                source: result
            });
        })
        .fail(function (error) {
            console.log(error);
        });
});