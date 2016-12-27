///// goback page
function goBack() {
    window.history.back();
}

//////-------------Dialog--------------------
/////------typesize 1: small size, 2 medium size, 3 large size-------------- 
function DialogConfirm(message, typesize, func_calback) {
    var sltypesize;
    if (typesize == 1) {
        sltypesize = BootstrapDialog.SIZE_SMALL
    }
    else if (typesize == 2) {
        sltypesize = BootstrapDialog.SIZE_WIDE
    }
    else {
        sltypesize = BootstrapDialog.SIZE_LARGE
    }
    BootstrapDialog.show({
        size: sltypesize,
        message: message,
        closable: false,
        buttons: [{
            label: 'Đồng ý',
            cssClass: 'btn-primary',
            action: function (dialogRef) {
                dialogRef.close();
                if (func_calback != undefined) func_calback();
            }
        }, {
            label: 'Hủy bỏ',
            action: function (dialogRef) {
                dialogRef.close();
            }
        }]
    });
}

function DialogOk(message, typesize, func_calback) {
    var sltypesize;
    if (typesize == 1) {
        sltypesize = BootstrapDialog.SIZE_SMALL
    }
    else if (typesize == 2) {
        sltypesize = BootstrapDialog.SIZE_WIDE
    }
    else {
        sltypesize = BootstrapDialog.SIZE_LARGE
    }
    BootstrapDialog.show({
        size: sltypesize,
        message: message,
        closable: false,
        buttons: [{
            label: 'Đóng',
            cssClass: 'btn-primary',
            action: function (dialogRef) {
                dialogRef.close();
                if (func_calback != undefined) func_calback();
            }
        }]
    });
}

/// call ajax
function DeleteRowAjax(typeRequest, urlRequest, urlReturn) {
    $.ajax({
        url: urlRequest,
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (data) {
            if (data == "OK") {
                window.location.href = urlReturn;
            }
            else {
                DialogOk(data, 1);
            }
        },
        error: function (xhr) {
            DialogOk('Có lỗi xảy ra trong quá trình xử lý', 1);
            return false;
        }
    });
}

function RedirectFromAdd(id, url)
{
    $('#' + id).click(function () {
        window.location.href = url;
    });
}

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function isContains(str, substr) {
    return (str.indexOf(substr) >= 0) ? true : false;
}
function SetDefaultButton(objTextBox, objButton) {
    var ButtonKeys = { 'EnterKey': 13 };
    $(function () {
        $('#' + objTextBox).keypress(function (e) {
            if ((e.which && e.which == ButtonKeys.EnterKey) || (e.keycode && e.keycode == ButtonKeys.EnterKey)) {
                $('#' + objButton).click();
                return false;
            }
        });
        $('#' + objTextBox).focus(function (e) {
            if ((e.which && e.which == ButtonKeys.EnterKey) || (e.keycode && e.keycode == ButtonKeys.EnterKey)) {
                $('#' + objButton).click();
                return false;
            }
        });
    });
}

