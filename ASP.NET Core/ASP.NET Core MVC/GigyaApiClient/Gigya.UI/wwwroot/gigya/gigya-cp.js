var gigya_screen_set = "RegistrationLogin";

var gigyalanguage = "en";
var globalAccountInfo = {};

var arr = window.location.href.split("/");
var currentDomain = arr[0] + "//" + arr[2];
var currentDomainArea = arr[0] + "//" + arr[2] + '/' + arr[3];
var loginUrl = currentDomain + "/Account/Login/Login";


// var profileURL = currentDomainArea + "/Profile/Profile/UpdateUser";
var profileURL = currentDomainArea + "/Profile/UpdateUser";

// var deleteURL = currentDomainArea + "/Profile/Profile/DeleteProfile";
var deleteURL = currentDomainArea + "/Profile/DeleteProfile";

var dashboardURL = currentDomainArea + "/Dashboard/Dashboard";

var cancelURL = currentDomain + "/Account/LoginStatus/LoggedIn?isLoggedIn=True";
var cancelURLProfile = currentDomain + "/Profile/Profile";

var logoutUrl = currentDomain + "/Account/Login"

var gigya_extraInclude = "profile, data, id_token";
var error = "";

//after Register field changed
function hideshowonFieldChanged(eventObj) {
    if (typeof gigya_hidedocid != 'undefined' && gigya_hidedocid == true) {
        $gigayform = $('form.gigya-register-form:visible')
        $conditionalElements = $gigayform.find('[data-condition]')
        if (eventObj.field == "data.Ihave" && eventObj.value == "DocCheckID") {
            $conditionalElements.hide();
            $gigayform.find("[data-condition*='DocCheckID']").show();
        }
        else {
            $conditionalElements.hide();
            $gigayform.find("[data-condition*='Zoetis customer number']").show();
        }
    }
}

var onGigyaServiceReady = function (serviceName) {
    gigya.events.addMap({ eventMap: [{ events: 'afterScreenLoad', args: [function (e) { return e; }], method: function method(e) { afterScreenLoadCallback(e) } }] });
    // register an event handler for Gigya onLogin event
    gigya.accounts.addEventHandlers({
        onLogin: gigyaOnLoginHandler,
        onLogout: gigyaOnLogoutHandler
    });

    if ($('#gigya-screensetcontainer').length > 0) {
        if (gigya_screen_id == "gigya-signup-screen") {
            gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: gigya_screen_id, onFieldChanged: hideshowonFieldChanged });
        }
        else if (gigya_screen_id == "gigya-login-screen") {
            gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: gigya_screen_id });
        }
        else if (gigya_screen_id == "gigya-profile-screen") {
            gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: gigya_screen_id, onAfterScreenLoad: gigyaAfterProfileScreenLoad, onAfterSubmit: gigyaAfterProfileSubmit });
        }
        else if (gigya_screen_id == "gigya-reset-password-screen") {
            gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: gigya_screen_id, onAfterSubmit: gigyaAfterResetSubmit });
        }
        else {
            gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: gigya_screen_id });
        }
    }
    GigyaLoadFunctions();
}

function GigyaLoadFunctions() {
    gigya.accounts.getAccountInfo({ callback: getAccountInfoResponse });
}

function getAccountInfoResponse(response) {
    if (response.errorCode == 0) {
        if (error) {
            // $.fn.kendoNotificationErrorMessage(error);
            if (gigya_screen_id != "gigya-profile-screen")
                AccountLogOut();
        } else {
            if (gigya_screen_id != "gigya-profile-screen")
                getAccountInfo(loginUser);
        }
    }
}

// onLogin Event handler
function gigyaOnLoginHandler(eventObj) {
    if (eventObj.data != undefined && eventObj.data.accountId != undefined && eventObj.data.accountId == "") {
        gigya.accounts.showScreenSet({ containerID: 'gigya-screensetcontainer', lang: gigyalanguage, screenSet: gigya_screen_set, startScreen: "gigya-accountid-screen", onBeforeSubmit: gigyaAccountValidate });
    }
    else {
        getAccountInfo(loginUser);
    }
}
function loginUser(eventObj) {
    console.log(eventObj);
    if (isglobalAccountInfoValid(eventObj)) {
        window.location.replace(loginUrl + "?" + getGigyaParams());
    }
}

function getGigyaParams() {
    return jQuery.param({ gigyaId: globalAccountInfo.UID, idToken: globalAccountInfo.id_token });
}

function gigyaAfterResetSubmit(eventObj) {
    if (eventObj != null && eventObj.response.errorCode == 0 && eventObj.response.message != "") {
        AccountLogOut();
        window.location.replace(currentDomain);
    }
}

function getAccountInfo(callback) {
    gigya.accounts.getAccountInfo({
        callback: function (account) {
            globalAccountInfo = account;
            callback(account);
        },
        include: gigya_extraInclude
    });
}

function deleteModal(message, title) {
    $('#deleteModalTitle').text(title);
    $('#deleteModalBody').text(message);
    $('#deleteModal').modal({
        backdrop: 'static',
        keyboard: false
    })
    .on('click', '#deleteModalOK', function () {
        $('#deleteModal').modal('hide');
        deleteProfile();
    });   
    $("#deleteModalCancel").on('click', function () {
        $('#deleteModal').off('click'); 
        $('#deleteModal').modal('hide');
    });
    $("#deleteModalClose").on('click', function () {
        $('#deleteModal').off('click'); 
        $('#deleteModal').modal('hide');
    });
}

function gigyaAfterProfileScreenLoad(eventObj) {

    $('input[type="button"][value="Delete Profile"]').click(function () {

        deleteModal('Are you sure you want to delete the profile?', 'Profile Delete');

        /*
        kendo.confirm("Are you sure you want to delete your profile?").then(function () {
            deleteProfile();
        });
        */
    });

    $('input[type="button"][value="Cancel"]').click(function () {
        if ($('.gigya-composite-control.gigya-composite-control-header.gigya-header').text() == "UPDATE PROFILE") {
            window.location.href = cancelURL;
        }
        else {
            window.location.href = cancelURLProfile;
        }
    });

    /*
    $('input[type="button"][value="Save"]').click(function () {
    });
    */

    /*
    $("#gigya-profile-form").submit(function (e) { 
    });
    */

    // $('input[type="button"][value="Cancel"]').parent().attr('href', dashboardURL);
}


/*
function gigyaAfterProfileScreenLoad(eventObj) {
    $('input[type="button"][value="Delete Profile"]').click(function () {
        var dfd = new jQuery.Deferred();            
        var result = false;
        $("<div id='popupWindow'></div>")
                .appendTo("body")
                .kendoWindow({
                    width: "400px",
                    modal: true,
                    title: false,
                    modal: true,
                    visible: false,
                    close: function (e) {
                        this.destroy();
                        dfd.resolve(result);
                    }
                }).data('kendoWindow').content($('#confirmationTemplate').html()).center().open();
        
            $('.popupMessage').html('Are you sure you want to delete your profile?');

            $('#popupWindow .confirm_yes').val('OK');
            $('#popupWindow .confirm_no').val('Cancel');

            $('#popupWindow .confirm_no').click(function () {
                $('#popupWindow').data('kendoWindow').close();
            });

        $('#popupWindow .confirm_yes').click(function () {
            result = true;
            deleteProfile();
        });
    });
    $('input[type="button"][value="Cancel').click(function () {
        window.location.replace(dashboardURL);
    });
    return dfd.promise();
}
*/

function gigyaAfterProfileSubmit(eventObj) {
    getAccountInfo(gigyaProfile);
}

function gigyaProfile(eventObj) {
    if (eventObj != null && eventObj.errorCode == 0)
        window.location.replace(profileURL + "?" + getGigyaParams());
}

function showMessage(message, status) {   
    let element;
    let spanElement;
    switch (status) {
        case "success":
            element = $("#successInfo");
            spanElement = $("#successSpanMessage");
            break;
        case "warning":
            element = $("#warningInfo");
            spanElement = $("#warningSpanMessage");
            break;
        case "error":
            element = $("#errorInfo");
            spanElement = $("#errorSpanMessage");
            break;
        default:
            break;
    }
    if (element != null && spanElement != null) {
        element.attr("hidden", false);
        spanElement.append(message);
        element.fadeTo(5000, 500).slideUp(500, function () {
            $(this).slideUp(500);
        });
        element.click(function () {
            $(this).attr("hidden", true);
        });
    }
}

function popupMessage(message, title) {
    $('#popupModalTitle').text(title);
    $('#popupModalBody').text(message);
    $('#popupModal').modal('show');
    $("#popupModalOK").on('click', function () {
        window.location.replace(currentDomain);
    });
    $("#popupModalClose").on('click', function () {
        window.location.replace(currentDomain);
    });
}

/*
function deleteProfile() {
    $.ajax({
        type: "POST",
        url: deleteURL,
        success: function (response) {
            if (response.ErrorCode == 0 && response.Message != "") {
                showProfileNotification(response.Message, "error");
                AccountLogOut();
                window.location.replace(currentDomain);
            } else {
                showProfileNotification(response.Message, "success");
            }
        },
        error: function (response) {
            $.fn.kendoNotificationErrorMessage(response);
        }
    });
}
*/

function deleteProfile() {
    $.ajax({
        type: "POST",
        url: deleteURL,     
        contentType: 'application/json, charset=utf-8',
        success: function (response) {
            var json = JSON.stringify(response);              
            // var result = $.parseJSON(json);
            var result = JSON.parse(json);
            /*
            $.each(result, function (k, v) {                
                alert(k + ' = ' + v);
            });
            */
            if (result != null && result["errorCode"] != null) {
                if (result["errorCode"] === 0 && result["message"] != null) {
                    showMessage(result["message"], "success");
                    accountLogOut();
                    popupMessage("Logged out.", "Profile Logout");                    
                } else if (result["errorCode"] > 0 && result["message"] != null) {
                    showMessage(result["message"], "warning");
                }
            }
        },
        error: function (response) {
            showMessage(JSON.stringify(response), "error");
        }
    });
}

// after Screen Load callback
function afterScreenLoadCallback(eventObj) {
    return true;
}

// Set Default Global Info object
function isglobalAccountInfoValid(globalAccountInfo) {
    isValid = false;
    if (globalAccountInfo && globalAccountInfo.profile && globalAccountInfo.data) {
        isValid = true;
    }
    return isValid;
}

// onLogout mobile event handler
function onLogout(eventObj) {
    if (eventObj.errorCode == 0) {
        gigyaOnLogoutHandler(eventObj);
    }
    else {
        // $.fn.kendoNotificationErrorMessage(eventObj.errorMessage);
    }
}

// onLogout Gigya Event handler
function gigyaOnLogoutHandler(eventObj) {
    setglobalAccountInfo(eventObj);
}
// Set Default Global Info object
function setglobalAccountInfo(eventObj) {
    globalAccountInfo = eventObj;
}

// display results of getAccountInfo() call
function showAccountInfo(eventObj) {
}
// For convenience...
Date.prototype.format = function (mask, utc) {
    return dateFormat(this, mask, utc);
};

function accountLogOut() {
    gigya.accounts.logout({ callback: onLogout });
}

function logOut(url) {
    accountLogOut();
    window.location.replace(url);
}

