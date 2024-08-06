﻿$(document).ready(function () {
    var button = $("#btn-insert");
    button.click(function () {
        clickButton();
    });
});

function clickButton() {
    $('.loader:first').off('ajaxSuccess');
    $('.loader:first').off('ajaxFail');

    var data = { // nampung input di detail Mode edit tambahin created date dan by hidden
        UserName: $("#UserName").val(),
        UserDetail: {
            FullName: $("#UserDetail_FullName").val(),
            Phone: $("#UserDetail_Phone").val()
        },
        IsActived: $("#IsActive").is("checked"),
        IsVerified: $("#IsVerified").is("checked")
    };

    $('.loader:first').trigger('loadAjax', [url, data]);

    $('.loader:first').on('ajaxSuccess', function (event, result) {
        $("#div-result").html(result.Message);
        window.location.href = '/TP/User/AjaxUsers';
    });
    $('.loader:first').on('ajaxFail', function (event, data) {
        alert(data);

        toggleButton(false);
    });
}


