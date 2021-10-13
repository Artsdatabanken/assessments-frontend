const filters = document.getElementById("filters");
const filter_modal_background = document.getElementById("filter_modal_background");
const filters_scrollable = document.getElementById("filters_scrollable");
const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const submit_filters = document.getElementById("submit_filters");
const filters_close_buttons = document.getElementsByClassName("close_filters");
const filters_open_button = document.getElementById("open_filter");
const init = document.getElementById("initial_check");
const isCheckInputs = document.getElementsByClassName("collapse_checkbox");
const scrollTo = document.getElementById("remember_scroll");


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
        el.onclick = function() {
            scrollTo.value = "scroll_" + window.scrollY;
            scrollTo.checked = true;
            this.form.submit();
        };
    });
    submit_filters.style["display"] = "none";
}

const removeSubmitOnclick = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        el.onclick = null;
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