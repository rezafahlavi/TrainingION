function isValid() {
    var isValid = true;

    if ($("#UserName").val() == "" && $("#UserDetail_Phone").val() == "") {
        isValid = false;
        $("#validation-msg").html("UserName Tidak Boleh Kosong");
        $("#validation-msg-ph").html("Phone Tidak Boleh Kosong");
    }
    else if ($("#UserName").length <= 3) {
        isValid = false;
        $("#validation-msg").html("UserName Harus Lebih Dari 3 Karakter");
    }
    else ($("#UserDetail_Phone").length <= 10); {
        isValid = false;
        $("#validation-msg-ph").html("Phone Harus Lebih Dari 9 Karakter");
    }

    return isValid;
}
