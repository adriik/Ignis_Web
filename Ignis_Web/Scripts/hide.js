$(function () {
    $("#Reserves").click(function () {
        if ($(this).is(":checked")) {
            $("#reserves").show();
        } else {
            $("#reserves").hide();
        }
    });
});