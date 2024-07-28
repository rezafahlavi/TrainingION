var shortDateFormat = "dd/mm/yy";
var generalResources = {};
var errorResources = {};
var dialog = null;
var longDateFormat = "dd/mm/yy HH:MM";
var useCKEditor = false;
var isFormSubmit = false;
var currentPage = 1;
var prev_paging_page = 1;

$(function () {
    function reposition(modal) {
        var dialog = modal.find('.modal-dialog');
        //var modalBody = modal.find('.modal-body');
        modal.css({ 'display': 'block' });
        //var scrollPost = $(window).scrollTop();

        // Dividing by two centers the modal exactly, but dividing by three.
        // or four works better for larger screens.
        dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));

        //modalBody.css({ 'max-height': $(window).height() - 200, 'overflow-y': 'auto' });
        modal.css({ 'top': 0, 'height': $(window).height() });
    }

    // Reposition when a modal is shown
    $('.modal').on('show.bs.modal', function () {
        reposition($(this));
        $("body").css({ "overflow-y": "hidden" });
    });

    $('.modal').on('hidden.bs.modal', function () {
        modal = $(this);
        var modalBody = modal.find('.modal-body');
        $("body").css({ "overflow-y": "auto" });
    });

    // Reposition when the window is resized
    $(window).on('resize', function () {
        $('.modal:visible').each(function () {
            reposition($(this))
        });
    });
});

function checkPosition() {
    if (window.matchMedia('(max-width: 767px)').matches) {
        $('#modal').height($(window).height());

        addRemoveAsterisks(true);
    } else {
        addRemoveAsterisks(false);
    }
}

function addRemoveAsterisks(isAdd) {
    $(".form-responsive").find("label.required").each(function () {
        var parent = $(this).parent();
        var input = $(parent).find(".input");

        if ($(input).length > 0) {
            switch ($(input).prop("nodeName")) {
                case "SELECT":
                    var firstOption = $(input).find("option:selected");
                    var text = $(firstOption).text();
                    var addedText = "* ...";
                    var replacedText = " ...";

                    if (text.indexOf(addedText) < 0) {
                        if (isAdd) {
                            text = text.replace(replacedText, addedText);
                            $(firstOption).text(text);
                        }
                    }
                    else {
                        if (!isAdd) {
                            text = text.replace(addedText, replacedText);
                            $(firstOption).text(text);
                        }
                    }
                    break;
                case "INPUT":
                case "TEXTAREA":

                    var text = $(input).attr("placeholder");
                    var addedText = "* ...";
                    var replacedText = " ...";

                    if (text.indexOf(addedText) < 0) {
                        if (isAdd) {
                            text = text.replace(replacedText, addedText);
                            $(input).attr("placeholder", text);
                        }
                    }
                    else {
                        if (!isAdd) {
                            text = text.replace(addedText, replacedText);
                            $(input).attr("placeholder", text);
                        }
                    }
                    break;
            }
        }
    });
}

$(window).resize(function () {
    checkPosition();
});

var config = {
    '.chosen-select': {},
    '.chosen-select-deselect': { allow_single_deselect: true },
    '.chosen-select-no-single': { disable_search_threshold: 10 },
    '.chosen-select-no-results': { no_results_text: generalResources.NoDataAvailable },
    '.chosen-select-rtl': { rtl: true },
    '.chosen-select-width': { width: '100%' }
}

$(document).on("ready", function () {
    bindCustomClickEvent();
    bindCustomGetEvent();
    bindCustomPostEvent();
    bindCancelFormHandler();
    initPhoneField();
    initIntegerField();
    onLanguageClicked();
    initIsDirty();

    $('form:not([customType="user"])').submit(function (event) {
        isFormSubmit = true;
    });

    $('form').submit(function (event) {

        //Extra process for masked input
        $.each($('input[mode="decimal"],input[mode="integer"]'), function (i, obj) {
            if ($(obj).attr('numval') != undefined) {
                $(obj).attr('numval', $(obj).attr('numval') == '' ? 0 : $(obj).attr('numval'));
                $(obj).attr('numval', $(obj).attr('numval').replace(numberFormatInfo.currencyGroupSeparator, ''));
                $(obj).val($(obj).attr('numval'));
            }
        });

    });

    dialog = $("#modal").dialogControl();

    window.setTimeout(function () {
        initFormFocus();
    }, 0);

    for (var selector in config) {
        $(selector).chosen(config[selector]);
    }

    $('[data-toggle="tooltip"]').tooltip();
});

function onLanguageClicked() {
    $(".languageMenu li").on('click', function () {
        var culture = $(this).attr('culture');
        window.location.href = baseURL + culture + "/" + pageURL.replace(/\&amp;/g, '&');
    });
}

function initPhoneField() {
    $('input[mode="phone"]').off("keydown");
    $('input[mode="phone"]').on("keydown", isPhoneKey);
}

function initIntegerField() {

    $('input[mode="numeric-text"]').off("keydown");
    $('input[mode="numeric-text"]').on("keydown", isNumberKey);

    $('input[mode="negative-decimal"]').off("keydown");
    $('input[mode="negative-decimal"]').on("keydown", isNegativeDecimalNumberKey);

    $('input[mode="integer"]').off("keydown");
    $('input[mode="integer"]').on("keydown", isNumberKey);

    $('input[mode="integer"]').focus(function (evt) {
        var numVal = $(evt.currentTarget).attr('numval');
        $(evt.currentTarget).val(numVal);
    });

    $('input[mode="integer"]').blur(function (evt) {
        var numVal = $(evt.currentTarget).val();
        if (parseInt(numVal) > 0) {
            $(evt.currentTarget).attr('numval', numVal);
            $(evt.currentTarget).val(formatNumeric(numVal));
        }
        else {
            $(evt.currentTarget).attr('numval', '');
            $(evt.currentTarget).val('');
        }
    });

    //Decimal
    $('input[mode="decimal"]').keydown(isDecimalNumberKey);

    $('input[mode="decimal"]').focus(function (evt) {
        var numVal = $(evt.currentTarget).attr('numval');
        $(evt.currentTarget).val(parseFloat(numVal) != 0 ? numVal : '');
    });

    $('input[mode="decimal"]').blur(function (evt) {
        var numVal = $(evt.currentTarget).val();

        if (numVal == '')
            numVal = 0;

        $(evt.currentTarget).attr('numval', numVal);
        $(evt.currentTarget).val(formatNumeric(numVal));
    });
}

function initFormFocus() {
    var focusField = $('.container.body-content form input:visible:not([readonly]):not([disabled]),.container.body-content form textarea:visible:not([readonly]):not([disabled])').first();
    focusField.focus();
}

function bindCustomPostEvent() {
    $('.loader').off("loadAjax");
    $('.loader').on("loadAjax", function (event, url, data, useDefaultDialogAction) {
        commonAjaxRequest($(this), url, data, 'POST', useDefaultDialogAction);
    });
}

function bindCustomGetEvent() {
    $('.loader').off("loadAjaxGet");
    $('.loader').on("loadAjaxGet", function (event, url, data, useDefaultDialogAction) {

        commonAjaxRequest($(this), url, data, 'GET', useDefaultDialogAction);
    });
}

function bindCustomClickEvent() {

    $('input[type="button"].loader, a.loader, button.loader').off('click');

    $('input[type="button"].loader, a.loader, button.loader').click(function () {
        console.log("Pre click handler");

        $(this).trigger("customClick");
    });
}

function bindCustomClickEventTargeted(tgtSelector) {

    $(tgtSelector).off('click');

    $(tgtSelector).click(function () {
        console.log("Pre click handler");

        dialog.show({ type: "loader" });
        $(this).trigger("customClick");
    });
}

function getAntiForgeryToken() {
    var tokenInput = $("input[name='__RequestVerificationToken'");

    var antiForgeryToken = "";
    if (tokenInput.length > 0)
        antiForgeryToken = tokenInput.val()

    return antiForgeryToken;
}

function commonAjaxRequest(elem, url, data, type, useDefaultDialogAction) {
    console.log("ajax initialize");

    if (typeof useDefaultDialogAction === "undefined")
        useDefaultDialogAction = true;

    if (dialog) {
        if (dialog.settings && dialog.settings.type == "dialog") {
            dialog.showInnerLoader();
        }
        else {
            dialog.show({ type: "loader" });
        }
    }

    if (type == 'POST')
        data = JSON.stringify(data);

    var antiForgeryToken = getAntiForgeryToken();

    $.ajax({
        url: url,
        data: data,
        type: type,
        contentType: 'application/json',
        dataType: 'json',
        headers:
        {
            __RequestVerificationToken: antiForgeryToken
        },
        cache: false,
        success: function (data) {

            console.log("ajax success");

            $(elem).trigger("ajaxSuccess", [data]);

            if (useDefaultDialogAction) {
                if (!data.DisableHide) {
                    dialog.ajaxHide();
                }
            }
        },
        error: function (e) {
            console.log("ajax fail");
            $(elem).trigger("ajaxFail", [e]);

            if (dialog.settings && dialog.settings.type == "dialog") {
                dialog.hideInnerLoader();
            }
            else {
                console.log('dialog hide');
                dialog.hide();
            }
        }
    });
}

function initIsDirty() {
    (function ($) {
        $.fn.checkChanges = function (message) {
            var _self = this;

            $(_self).bind('change', function (e) {
                $(this).addClass('changedInput');
            });

            $(window).bind('beforeunload ', function () {

                if (useCKEditor) {

                    if (($('.changedInput').length || getCKEditorIsDirty()) && !isFormSubmit) {
                        return message;
                    }
                }
                else {
                    if ($('.changedInput').length && !isFormSubmit) {
                        return message;
                    }
                }
            });
        };
    })(jQuery);

    $('form:not([customType="user"])').checkChanges("Do You Want To Leave?");

}

function getCKEditorIsDirty() {
    for (var i in CKEDITOR.instances) {
        if (CKEDITOR.instances[i].checkDirty()) {
            return true;
        }
        else {
            return false;
        }
    }
}

function processCommonAjaxError(data) {
    var message = "";

    if (data.status == "500") {
        var redirectComp = $($(data.responseText)[1]).text().split("###");

        var action = redirectComp[0];
        var redirectUrl = redirectComp[1];

        if (action == "REDIRECT") {
            window.location = redirectUrl;
        } else if (action == "RENDER") {
            message = redirectUrl;
        } else {
            alert(action);
        }
    }
    else {
        alert(data);
    }

    return message;
}

String.prototype.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }

    return s;
}

function bindCancelFormHandler() {
    $(".button-cancel[targetLink]").on('click', function () {
        window.location = $(this).attr('targetLink');
    });
}

function hideAlertBoxes() {
    $(".alert span").not(".glyphicon").remove();
    $(".alert").each(function () {
        if (!$(this).hasClass("hidden")) {
            $(this).addClass("hidden")
        }
    });
}

function showMessageOnAlertBox(message, element) {
    if (message != "") {
        if ($(element).hasClass("hidden")) {
            $(element).removeClass("hidden");
        }

        //var messageElement = $("<span></span>").html(message);
        var iconText = $(element).html().split("</span>")[0] + "</span> ";
        var messageElement = "<span>" + message + "</span>";

        $(element).html(iconText + messageElement);
    }
}

function setFormatedDate(elementName, displayedElementName) {
    var dateVal = formatDate($(displayedElementName).val());
    var formatedDate = getFormattedDate(dateVal);
    $(elementName).val(formatedDate);
}

function getFormattedDate(date) {
    var month = date.getMonth() + 1;
    var day = date.getDate();
    var year = date.getFullYear();

    return year + "-" + month + "-" + day + " 00:00:00";
}

function showValidationMessage(elementId, errorMessage) {
    $('#' + elementId).addClass('input-validation-error');
    $('[data-valmsg-for="' + elementId + '"]').removeClass('field-validation-valid').addClass('field-validation-error').html(errorMessage);
}

function removeValidationMessage(elementId) {
    $('#' + elementId).removeClass('input-validation-error').addClass('field-validation-valid');
    $('[data-valmsg-for="' + elementId + '"]').removeClass('field-validation-error').addClass('field-validation-valid').html("");
}