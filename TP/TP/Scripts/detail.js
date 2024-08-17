$(document).ready(function () {
    var button = $("#btn-insert");
    button.click(function () {
        if (isValid())
        clickButton();
    });

    var button = $("#btn-edit");
    button.click(function () {
        if (isValid())
        clickButtonEdit();
    });
});

function isValid() {
    var isValid = true;

    if ($("#UserName").val() == "" && $("#UserDetail_Phone").val() == "") {
        isValid = false;
        $("#validation-msg").html("UserName Tidak Boleh Kosong");
        $("#validation-msg-ph").html("Phone Tidak Boleh Kosong");
    }
    else if ($("#UserName").val().length <= 3) {
        isValid = false;
        $("#validation-msg").html("UserName Harus Lebih Dari 3 Karakter");
    }
    else if ($("#UserDetail_Phone").length <= 10) {
        isValid = false;
        $("#validation-msg-ph").html("Phone Harus Lebih Dari 9 Karakter");
    }

    return isValid;
}

function clickButton() {
    $('.loader:first').off('ajaxSuccess');
    $('.loader:first').off('ajaxFail');

    var data = { // nampung input di detail Mode edit tambahin created date dan by hidden
        UserName: $("#UserName").val(),
        UserDetail: {
            FullName: $("#UserDetail_FullName").val(),
            Phone: $("#UserDetail_Phone").val()
        },
        IsActive: $("#IsActive").is(":checked"),
        IsVerified: $("#IsVerified").is(":checked")
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

function clickButtonEdit() {
    $('.loader:first').off('ajaxSuccess');
    $('.loader:first').off('ajaxFail');

    var data = { 
        UserID: $("#UserID").val(),
        UserName: $("#UserName").val(),
        UserDetail: {
            FullName: $("#UserDetail_FullName").val(),
            Phone: $("#UserDetail_Phone").val(),
            UserID: $("#UserDetail_UserID").val(),
            CreatedBy: $("#UserDetail_CreatedBy").val(),
            CreatedDate: $("#UserDetail_CreatedDate").val()
        },
        IsActive: $("#IsActive").is(":checked"),
        IsVerified: $("#IsVerified").is(":checked"),
        CreatedBy: $("#CreatedBy").val(),
        CreatedDate: $("#CreatedDate").val()
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


