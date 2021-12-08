/* - JS relevant for the entire page */

// DOM elements
const submitCheckInputs = document.getElementsByClassName("submitOnclick");

// Constants
const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
const endangered = ["CR", "EN", "VU"];

// Screen Size
const smallScreenSize = 750; // In case we want to tinker later.
const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= smallScreenSize;
}

document.addEventListener('keydown', (e) => {
    // Keypress on entire page

    if (e.code == "Escape" && isSmallReader()) {
        // Only listen to escape clicks, and only on tiny screens

        if (document.getElementById("filters") &&
            !document.getElementById("filters").classList.contains("hide_on_smallscreen")) {
            // If filter box is open, close it.
            closeFilters();
        }
    }
});
