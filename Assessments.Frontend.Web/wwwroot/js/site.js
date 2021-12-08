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



