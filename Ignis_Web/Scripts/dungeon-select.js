$('#checkIBP').change(function () {

    if ($(this).is(':checked')) {
        $('#checkSToES').prop('checked', false);
    }
    else {
        $('#checkIBP').prop('checked', false);
        $('#checkSToES').prop('checked', true);
    }
});

$('#checkSToES').change(function () {

    if ($(this).is(':checked')) {
        $('#checkIBP').prop('checked', false);
    }
    else {
        $('#checkSToES').prop('checked', false);
        $('#checkIBP').prop('checked', true);
    }
});
