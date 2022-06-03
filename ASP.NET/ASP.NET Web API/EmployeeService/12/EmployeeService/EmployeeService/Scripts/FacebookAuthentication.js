/// <reference path="jquery-3.3.1.min.js" />

function getAccessTokenFacebook() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegisteredFacebook(accessToken);
            }
        }
    }
}

function isUserRegisteredFacebook(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem("accessToken", accessToken);
                localStorage.setItem("userName", response.Email);
                window.location.href = "Data.html";
            }
            else {
                // Pass the login provider (Facebook or Google)
                signupExternalUserFacebook(accessToken, response.LoginProvider);
            }
        }
    });
}

// Include provider parameter
function signupExternalUserFacebook(accessToken, provider) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function () {
            // Use the provider parameter value instead of
            // hardcoding the provider name
            window.location.href = "/api/Account/ExternalLogin?provider=" + provider + "&response_type=token&client_id=self&redirect_uri=https%3A%2F%2Flocalhost%3A44337%2FLogin.html&state=RuBQp4bmix272VpyNlJ4QZv5-g11h-oA7AcXHMTUBvg1";
        }
    });
}