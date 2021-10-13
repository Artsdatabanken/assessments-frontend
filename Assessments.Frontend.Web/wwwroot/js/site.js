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
const scrollTo = document.getElementById("remember_scroll");

// Constants
const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
const endangered = ["CR", "EN", "VU"];

const toggleRedlistedCategories = () => {
    const isEndangeredActive = endangeredCheck.checked;
    const isRedlistedActive = redlistCheck.checked;
    redlisted.forEach(el => {
        if (isRedlistedActive) {
            document.getElementById("input_" + el).checked = true;
        } else {
            if (isEndangeredActive) {
                if (!endangered.includes(el)) {
                    document.getElementById("input_" + el).checked = false;
                }
            } else {
                document.getElementById("input_" + el).checked = false;
            }
        }
    })
}


const toggleEndangeredCategories = () => {
    const isEndangeredActive = endangeredCheck.checked;
    const isRedlistedActive = redlistCheck.checked;
    endangered.forEach(el => {
        if (isEndangeredActive) {
            document.getElementById("input_" + el).checked = true;
        } else {
            if (isRedlistedActive) {
                if (!redlisted.includes(el)) {
                    document.getElementById("input_" + el).checked = false;
                }
            } else {
                document.getElementById("input_" + el).checked = false;
            }
        }
    })
}

const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= 750;
}

const hasVisited = () => {
    return init.checked;
}

const setVisited = () => {
    init.checked = true;
}

const addSubmitOnclick = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        if (el.id === "redlisted_check") {
            el.onclick = function () {
                toggleRedlistedCategories();
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                this.form.submit();
            };
        } else if (el.id === "endangered_check") {
            el.onclick = function () {
                toggleEndangeredCategories();
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                this.form.submit();
            };
        } else {
            el.onclick = function() {
                scrollTo.value = "scroll_" + window.scrollY;
                scrollTo.checked = true;
                this.form.submit();
            };
        }
    });
    submit_filters.style["display"] = "none";
}

const removeSubmitOnclick = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        if (el.id === "redlisted_check") {
            el.onclick = function () {
                toggleRedlistedCategories();
            };
        } else if (el.id === "endangered_check") {
            el.onclick = function () {
                toggleEndangeredCategories();
            };
        } else {
            el.onclick = null;
        }
    });
    submit_filters.style["display"] = "block";
}

const scrollToPreviousPosition = () => {
    const position = scrollTo.value;
    window.scrollTo(0, position);
}

const initialCheck = () => {
    scrollToPreviousPosition();
}

initialCheck();