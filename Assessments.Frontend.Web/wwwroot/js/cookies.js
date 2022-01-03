
/* 
 * Cookies for Google Analytics and their handling
 * Using session-storage to remember which user preference. 
 * These fall under criteria B for not needing warning as they are 1. session and B. remembers choice across page.
 * TODO: Follow best practices: https://www.cookieyes.com/google-analytics-cookie-banner/
 */

var acceptedcookies = null;
var readValue = sessionStorage['acceptedcookies'];
var acceptedcookie = getCookie("acceptedcookie");
var cookieDuration = 365; // Amount of days we let a cookie live.

// Google Analytics tracking
(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r;
    i[r] = i[r] ||
        function () {
            (i[r].q = i[r].q || []).push(arguments);
        }, i[r].l = 1 * new Date();
    a = s.createElement(o),
        m = s.getElementsByTagName(o)[0];
    a.async = 1;
    a.src = g;
    m.parentNode.insertBefore(a, m);

})(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');


function learnAboutCookies() {
    if (document.getElementById('moreCookieInfo')){
        if (document.getElementById('moreCookieInfo').style.display == "none") {
            document.getElementById('moreCookieInfo').style.display = "block";
        } else {
            document.getElementById('moreCookieInfo').style.display = "none";
        }
    }
}

// Make new cookie
function setCookie(cname, cvalue, exdays) {
    const d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

// Read the cookie
function getCookie(cname) {
    console.log("Fetch cookie ", cname)
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

// User choice triggers tracking or rejecting tracking. Means we lose lots of stats.
function acceptCookies(accepted) {
    if (accepted) {
        acceptedcookies = "yes"
        ga('create', 'UA-74815937-4', 'auto');
        ga('send', 'pageview');
        setCookie("acceptedcookie", acceptedcookies, cookieDuration); // Remember choice for x days.
        document.getElementById('heyCookie').style.display = "none";
    } else {
        document.getElementById('heyCookie').style.display = "none";
        acceptedcookies = "no";
    }
    sessionStorage['acceptedcookies'] = acceptedcookies;
}


// Hide cookiewarning if already accepted this session
window.onload = function () {
    if (readValue || acceptedcookie == "yes") {
        if (document.getElementById('heyCookie')) {
            document.getElementById('heyCookie').style.display = "none";
        }
    }
};
