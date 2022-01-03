/* THEME MODES 
 - Swaps out classes on body adjusting to different css-themes
 - Does not persist across pages at this point
 - Checks manually set user preference as default (browser,os)
 */

var cookiesave = false;

// Open/Close Menu
function expandThemeButtons() {
    let mainparent = document.getElementById('themeselectordropdown');
    if (mainparent.style && mainparent.style.display == "block") {
        mainparent.style.display = "none";
    } else {
        mainparent.style.display = "block";
    }
}

// Handle theme changes
if (window.hasOwnProperty('acceptedcookie') && acceptedcookie == "yes") {
    cookiesave = true;
} 

function highContrastMode(thisbutton,className) {
    var mainparent = document.body;
    if (mainparent.classList && mainparent.classList.contains(className)) {
        mainparent.classList.remove(className);
        thisbutton.classList.remove(className);
    }else {
        mainparent.classList.add(className); 
        thisbutton.classList.add(className);
    }
    if (cookiesave) {
        themeCookie();
    }
}

if (cookiesave && getCookie('theme') != null) {
    document.body.classList = getCookie('theme');
} else {
    // Sets initial preferences
    const initialContrast = matchMedia('(forced-colors: active)');
    const initialTheme = matchMedia('(prefers-color-scheme: dark)');

    function themeChecks() {
        // Detects user preference for high contrast and dark mode themes
        var mainparent = document.body;
        if (initialTheme.matches) {
            mainparent.classList.add("darktheme");
        } else {
            if (mainparent.classList) {
                mainparent.classList.remove("darktheme");
            }
        }
        if (initialContrast.matches) {
            mainparent.classList.add("highcontrast");
        } else {
            if (mainparent.classList) {
                mainparent.classList.remove("highcontrast");
            }
        }
    }

    // run the checks immediately
    themeChecks();

    // listen for any changes performed by people tinkering with their settings
    initialContrast.addListener(themeChecks);
    initialTheme.addListener(themeChecks);
}
