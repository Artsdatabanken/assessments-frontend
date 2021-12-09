/* - JS relevant for the entire page */

// DOM elements
const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const headerMenuRL = document.getElementsByClassName("headermenu");
const themeSelectorDropDownRL = document.getElementsByClassName("themeselectordropdown");
const sidebarMenuItemClickRL = document.getElementsByClassName("sidebarmenuitemclick");

// Screen Size
const smallScreenSize = 750; // In case we want to tinker later.
const padScreenSize = 940; // In case we want to tinker later.

function isSmallReader(){
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= smallScreenSize;
}

function isPadSize() {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= padScreenSize;
}

function closeHeadermenu() {
    if (headerMenuRL &&
        headerMenuRL.classList.contains("show")) {
        headerMenuRL.classList.remove("show")
        headerMenuRL.classList.add("hide")
    }
}

function closeThemeselectordropdown() {
    if (themeSelectorDropDownRL &&
        themeSelectorDropDownRL.style &&
        themeSelectorDropDownRL.style.display == "block") {        
        themeSelectorDropDownRL.style.display = "none";
    }
}

function closeSidebarmenuitemclick() {
    if (isPadSize &&
        sidebarMenuItemClickRL &&
        sidebarMenuItemClickRL.classList.contains("expand")) {
        sidebarMenuItemClickRL.classList.remove("expand")
    }
}

document.addEventListener('click', e => {    
    // Click on entrie page
    if (!e.target.matches('#headermenu *')) {
        closeHeadermenu();
    }
    if (!e.target.matches('#theme_elements *')) { // Surrounding parent 
        closeThemeselectordropdown();
    }
    if (!e.target.matches('#sidebarmenuitemclick *')) { // Surrounding parent 
        closeSidebarmenuitemclick();
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
        
        if (themeSelectorDropDownRL){
            themeSelectorDropDownRL.style.display = "none";
        }

        closeSidebarmenuitemclick();
        if (isSmallReader()) {
            // For elements with different ux for mobile
            if (document.getElementById("filters") &&
                !document.getElementById("filters").classList.contains("hide_on_smallscreen")) {
                // If filter box is open, close it.
                closeFilters();
            }
            closeHeadermenu();
            closeThemeselectordropdown();
        }
    }
});

