/* - JS relevant for the entire page */

// DOM elements
const submitCheckInputs = document.getElementsByClassName("submitOnclick");



// Screen Size
const smallScreenSize = 750; // In case we want to tinker later.
const padScreenSize = 940; // In case we want to tinker later.

function isSmallReader(){
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= smallScreenSize;
}

function isPadSize() {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= padScreenSize;
}

function close_headermenu() {
    if (document.getElementById("headermenu") &&
        document.getElementById("headermenu").classList.contains("show")) {
        document.getElementById("headermenu").classList.remove("show")
        document.getElementById("headermenu").classList.add("hide")
    }
}

function close_themeselectordropdown() {
    if (document.getElementById("themeselectordropdown") &&
        document.getElementById("themeselectordropdown").style &&
        document.getElementById("themeselectordropdown").style.display == "block") {        
        document.getElementById("themeselectordropdown").style.display = "none";
    }
}

function close_sidebarmenuitemclick() {
    if (isPadSize &&
        document.getElementById("sidebarmenuitemclick") &&
        document.getElementById("sidebarmenuitemclick").classList.contains("expand")) {
        document.getElementById("sidebarmenuitemclick").classList.remove("expand")
    }
}

document.addEventListener('click', e => {    
    // Click on entrie page
    if (!e.target.matches('#headermenu *')) {
        close_headermenu();
    }
    if (!e.target.matches('#theme_elements *')) { // Surrounding parent 
        close_themeselectordropdown();
    }
    if (!e.target.matches('#sidebarmenuitemclick *')) { // Surrounding parent 
        close_sidebarmenuitemclick();
    }  
    
});


document.addEventListener('keydown', (e) => {
    // Keypress on entire page

    if (e.code == "Escape") {
        // Only listen to escape clicks
        if (document.getElementById("Omoss")) {
            document.getElementById("Omoss").style.display = "none";
        }

        if (document.getElementById("Meny")) {
            document.getElementById("Meny").style.display = "none";
        }
        
        if (document.getElementById("themeselectordropdown")){
            document.getElementById("themeselectordropdown").style.display = "none";
        }

        close_sidebarmenuitemclick();
        if (isSmallReader()) {
            // For elements with different ux for mobile
            if (document.getElementById("filters") &&
                !document.getElementById("filters").classList.contains("hide_on_smallscreen")) {
                // If filter box is open, close it.
                closeFilters();
            }
            close_headermenu();
            close_themeselectordropdown();
        }
    }
});

