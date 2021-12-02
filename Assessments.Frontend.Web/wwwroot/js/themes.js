/* THEME MODES */

function highContrastMode(thisbutton,className) {
    var mainparent = document.body;
    if (mainparent.classList && mainparent.classList.contains(className)) {
        mainparent.classList.remove(className);
        thisbutton.classList.remove(className);
    }else {
        mainparent.classList.add(className); 
        thisbutton.classList.add(className);
    }
}

function expandThemeButtons() {
    let mainparent = document.getElementById('themeselectordropdown');
    if (mainparent.style && mainparent.style.display == "block") {
        mainparent.style.display = "none";
    } else {
        mainparent.style.display = "block";
    }
}

const initialContrast = matchMedia('(forced-colors: active)');
const initialTheme = matchMedia('(prefers-color-scheme: dark)');

function checks() {
    console.log("RUNNING THEME CHECK")
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
checks();

// listen for any changes performed by people tinkering with their settings
initialContrast.addListener(checks);
initialTheme.addListener(checks);

