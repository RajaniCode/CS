/// <reference path="jquery-3.3.1.min.js" />

function getAccessTokenGoogle() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegisteredGoogle(accessToken);
            }
        }
    }
}

function isUserRegisteredGoogle(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/JSON',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem('accessToken', accessToken);
                localStorage.setItem('userName', response.Email);
                window.location.href = "Data.html";
            }
            else {
                signupExternalUserGoogle(accessToken);
            }
        }
    });
}

function signupExternalUserGoogle(accessToken) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function () {
            window.location.href = "/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri=https%3A%2F%2Flocalhost%3A44337%2FLogin.html&state=IxmBkiD0Nc00iHTxEFqBDh1L_pEpoqnbNB8V7llBZEo1";
        }
    });
}