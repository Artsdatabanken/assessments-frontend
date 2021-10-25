// DOM elements
const filters = document.getElementById("filters");
const filter_modal_background = document.getElementById("filter_modal_background");
const filters_scrollable = document.getElementById("filters_scrollable");
const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const submit_filters = document.getElementById("submit_filters");
const filters_close_buttons = document.getElementsByClassName("close_filters");
const filters_open_button = document.getElementById("open_filter");
const init = document.getElementById("initial_check");
const isCheckInputs = document.getElementsByClassName("collapse_checkbox");
const redlistCheck = document.getElementById("redlisted_check");
const endangeredCheck = document.getElementById("endangered_check");
const insectInput = document.getElementById("Insekter");
const insectFilters = document.getElementsByClassName("insect_input");
const scrollTo = document.getElementById("remember_scroll");

// Constants
const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
const endangered = ["CR", "EN", "VU"];

const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= 750;
}

const hasVisited = () => {
    return init.checked;
}

const setVisited = () => {
    init.checked = true;
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
                if (el.classList[0] === "insect_input") {
                    toggleSingleFilter(el, "Insekter");
                } else if (endangered.some(category => el.id.indexOf(category) != -1)) {
                    toggleSingleFilter(el, "endangered_check");
                    toggleSingleFilter(el, "redlisted_check");
                } else if (redlisted.some(category => el.id.indexOf(category) != -1)) {
                    toggleSingleFilter(el, "redlisted_check");
                }
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

const scrollToPreviousPosition = () => {
    if (!scrollTo) return;
    const position = scrollTo.value;
    window.scrollTo(0, position);
}

const initialCheck = () => {
    scrollToPreviousPosition();
}

initialCheck();