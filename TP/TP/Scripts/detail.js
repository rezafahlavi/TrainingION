$(document).ready(function () {
    var button = $("#btn-insert");
    button.click(function () {
        clickButton();
    });
});

function clickButton() {
    $('.loader:first').off('ajaxSuccess');
    $('.loader:first').off('ajaxFail');

    var data = { // ini ganti semua input di detail?
        UserName: $("#tb-name").val(),
        UserDetail: {
            FullName: $("#tb-fullname").val(),
        UserDetail: {
            Phone: $("#tb-phone").val(),
        IsActived: $("#tb-actived").val(),
        IsVerified: $("#tb-verified").val(),
        }
    };

    $('.loader:first').trigger('loadAjax', [url, data]);

    $('.loader:first').on('ajaxSuccess', function (event, result) {
        $("#div-result").html(result.Message);
    });
    $('.loader:first').on('ajaxFail', function (event, data) {
        alert(data);

        toggleButton(false);
    });
}


