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

        if (isSmallReader()) {
            // For elements with different ux for mobile
            if (document.getElementById("filters") &&
                !document.getElementById("filters").classList.contains("hide_on_smallscreen")) {
                // If filter box is open, close it.
                closeFilters();
            }

            if (document.getElementById("sidebarmenuitemclick") &&
                document.getElementById("sidebarmenuitemclick").classList.contains("expand")) {
                // If filter box is open, close it.
                document.getElementById("sidebarmenuitemclick").classList.remove("expand")
            }

            if (document.getElementById("headermenu") &&
                document.getElementById("headermenu").classList.contains("show")) {
                // If filter box is open, close it.
                document.getElementById("headermenu").classList.remove("show")
                document.getElementById("headermenu").classList.add("hide")
            }

            if (document.getElementById("themeselectordropdown")) {
                document.getElementById("themeselectordropdown").style.display = "none";
            }                        
        }
    }
});

