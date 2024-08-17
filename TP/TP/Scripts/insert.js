$(document).ready(function () {
    var button = $("#btn-insert");
    button.click(function () {

        if (isValid())
        clickButton();
    });
});

function isValid() {
    var isValid = true;

    if ($("#tb-name").val() == "") {
        isValid = false;
        $("[data-valmsg-for] = 'UserName'").html("user perlu diisi");
    }
        

    return isValid
}
    


function clickButton() {
    $('.loader:first').off('ajaxSuccess');
    $('.loader:first').off('ajaxFail');

    var data = {
        UserName: $("#tb-name").val(),
        UserDetail: {
            Phone: $("#tb-phone").val()
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

function clickButton2() {
    //isinya copas dari file detail.js (day 3 21.00) tapi file nya gak ada
}

