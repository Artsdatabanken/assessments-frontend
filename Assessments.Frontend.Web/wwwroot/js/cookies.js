/* 
 * Cookies for Google Analytics and their handling
 * Using session-storage to remember which user preference. 
 * These fall under criteria B for not needing warning as they are 1. session and B. remembers choice across page.
 * TODO: Follow best practices: https://www.cookieyes.com/google-analytics-cookie-banner/
 */

var acceptedcookies = null;
var readValue = sessionStorage['acceptedcookies'];
var acceptedcookie = getCookie("acceptedcookie");

// Duration for all persistent cookies should be the same.
// Set to 365 days (12 months), based on GDPR cookie consent rules.
var cookieDurationDays = 365;
var cookieDurationSeconds = cookieDurationDays * 24 * 60 * 60; // GA uses seconds
var cookieDuration = new Date();
cookieDuration.setTime(cookieDuration.getTime() + (cookieDurationSeconds * 1000));
var cookieDurationString = cookieDuration.toUTCString(); // setCookie uses this one.


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

// expand read more
function learnAboutCookies() {
    if (document.getElementById('moreCookieInfo')){
        if (document.getElementById('moreCookieInfo').style.display == "none") {
            document.getElementById('moreCookieInfo').style.display = "block";
        } else {
            document.getElementById('moreCookieInfo').style.display = "none";
        }
    }
}

// Make a new cookie
function setCookie(cname, cvalue,cduration) {   
    let expires = "expires=" + cduration;
    const secure = "Secure"
    document.cookie = cname + "=" + cvalue + ";" + expires + ";" + secure + ";path=/";
}

// Read a cookie
function getCookie(cname) {
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

// User choice triggers tracking or rejecting tracking.
function acceptCookies(accepted) {
    if (accepted) {        
        hasAcceptedCookies();
    } else {
        hasRejectedCookies();
    }   
}

function themeCookie() {
    if (document.body) {
        let currenttheme = document.body.classList || " ";
        setCookie("theme", currenttheme, cookieDurationString);
    }
}

// When cookies are accepted, make'em all, and with the same duration
function hasAcceptedCookies() {
    if (document.getElementById('heyCookie')) { // Only run on page with cookieWarning
        acceptedcookies = "yes";
        setCookie("acceptedcookie", acceptedcookies, cookieDurationString); // Remember choice for x days.    
        ga('create', 'UA-74815937-4', { 'cookieExpires': cookieDurationSeconds, 'cookieUpdate': 'false', 'cookieFlags': 'Secure' });
        ga('send', 'pageview');
        themeCookie();
        document.getElementById('heyCookie').style.display = "none";
    }
}

// When cookies are rejected, remember choice for now with sessionstorage
function hasRejectedCookies() {
    if (document.getElementById('heyCookie')) {// Only run on page with cookieWarning      
        acceptedcookies = "no";
        sessionStorage['acceptedcookies'] = acceptedcookies;
        document.getElementById('heyCookie').style.display = "none";
        // TODO: SHOULD LOOP THRU AND DELETE ALL COOKIES.
    }
}

// Hide cookiewarning if already accepted this session
window.onload = function () {
    if (readValue || acceptedcookie == "yes") {
        // if sessionstorage set or cookieconsent given, hide warning
        document.getElementById('heyCookie').style.display = "none";       
    }
};
