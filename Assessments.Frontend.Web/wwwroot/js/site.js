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

const addOnclick = () => {
    if (!submitCheckInputs) return;
    Array.prototype.forEach.call(submitCheckInputs, el => {
        if (el.id === "redlisted_check") {
            el.onclick = function () {
                toggleRedlistedCategories();
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                // toggleSingleFilter(el); activate if toggle all of the filters are possible
                if (!isSmallReader()) {
                    this.form.submit();
                }
            };
        } else if (el.id === "endangered_check") {
            el.onclick = function () {
                toggleEndangeredCategories();
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                // toggleSingleFilter(el); activate if toggle all of the filters are possible
                if (!isSmallReader()) {
                    this.form.submit();
                }
            };
        } else if (el.id === "Insekter") {
            el.onclick = function () {
                toggleInsects();
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                // toggleSingleFilter(el); activate if toggle all of the filters are possible
                if (!isSmallReader()) {
                    this.form.submit();
                }
            };
        } else {
            el.onclick = function() {
                updateToggleAll(el);
                toggleMarkAll();

                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                if (!isSmallReader()) {
                    this.form.submit();
                }
            };
        }
    });
}

const removeSubmitOnclick = () => {
    if (!submitCheckInputs) return;
    Array.prototype.forEach.call(submitCheckInputs, el => {
        if (el.id === "redlisted_check") {
            el.onclick = function () {
                toggleRedlistedCategories();
            };
        } else if (el.id === "endangered_check") {
            el.onclick = function () {
                toggleEndangeredCategories();
            };
        } else if (el.id === "Insekter") {
            el.onclick = function () {
                toggleInsects();
            };
        } else {
            el.onclick = null;
        }
    });
}





