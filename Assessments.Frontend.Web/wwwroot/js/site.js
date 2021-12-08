/* - JS relevant for the entire page */


// DOM elements

const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const scrollTo = document.getElementById("remember_scroll");

// Constants
const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
const endangered = ["CR", "EN", "VU"];


// Screen Size
const smallScreenSize = 750; // In case we want to tinker later.
const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= smallScreenSize;
}

const updateToggleAll = (el) => {
    if (el && el.classList[0] === "insect_input") {
        toggleSingleFilter(el, "Insekter");
    } else if (el && endangered.some(category => el.id.indexOf(category) != -1)) {
        toggleSingleFilter(el, "endangered_check");
        toggleSingleFilter(el, "redlisted_check");
    } else if (el && redlisted.some(category => el.id.indexOf(category) != -1)) {
        toggleSingleFilter(el, "redlisted_check");
    }
}

