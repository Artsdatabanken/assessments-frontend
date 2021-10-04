const filters = document.getElementById("filters");
const filter_modal_background = document.getElementById("filter_modal_background");
const filters_scrollable = document.getElementById("filters_scrollable");
const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const submit_filters = document.getElementById("submit_filters");
const filters_close_buttons = document.getElementsByClassName("close_filters")

const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= 750;
}

const showFilterButton = () => {
    document.getElementById("open_filter").style["display"] = "block";
}

const hideFilters = () => {
    document.getElementById("filters").style["display"] = "none";
}

const showFilters = () => {
    filters.style["display"] = "block";

    filter_modal_background.style["display"] = "block";
    filter_modal_background.style["background"] = "rgba(0,0,0,0.5)";
    filter_modal_background.style["top"] = "0";
    filter_modal_background.style["bottom"] = "0";
    filter_modal_background.style["position"] = "fixed";
    filter_modal_background.style["margin-left"] = "-15px";
    filter_modal_background.style["width"] = "100vw";
    filter_modal_background.style["height"] = "100vh";
    filter_modal_background.style["z-index"] = "10";

    filters_scrollable.style["position"] = "fixed";
    filters_scrollable.style["width"] = "90vw";
    filters_scrollable.style["top"] = "5vh";
    filters_scrollable.style["left"] = "5vw";

    Array.prototype.forEach.call(filters_close_buttons, el => {
        el.style["display"] = "block";
    });
}

const closeFilters = () => {
    filters.style["display"] = "none";
    filter_modal_background.style["display"] = "none";
}

const addSubmitOnclick = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        el.onclick = function() {
            this.form.submit();
        };
    });
    submit_filters.style["display"] = "none";
}



if (isSmallReader()) {
    showFilterButton();
    hideFilters();
} else {
    addSubmitOnclick();
}