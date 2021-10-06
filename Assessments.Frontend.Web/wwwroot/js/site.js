const filters = document.getElementById("filters");
const filter_modal_background = document.getElementById("filter_modal_background");
const filters_scrollable = document.getElementById("filters_scrollable");
const submitCheckInputs = document.getElementsByClassName("submitOnclick");
const submit_filters = document.getElementById("submit_filters");
const filters_close_buttons = document.getElementsByClassName("close_filters");
const filters_open_button = document.getElementById("open_filter");
const init = document.getElementById("initial_check");
const isCheckInputs = document.getElementsByClassName("collapse_checkbox");


const isSmallReader = () => {
    return Math.max(document.documentElement.clientWidth || 0, window.innerWidth || 0) <= 750;
}

const showFilterButton = () => {
    document.getElementById("open_filter").style["display"] = "block";
}

const hideFilterButton = () => {
    document.getElementById("open_filter").style["display"] = "none";
}

const showFilters = () => {
    filters.style["display"] = "block";

    filter_modal_background.style["display"] = "block";
    filter_modal_background.style["background"] = "rgba(0,0,0,0)";
    filter_modal_background.style["top"] = "0";
    filter_modal_background.style["bottom"] = "0";
    filter_modal_background.style["position"] = "relative";
    filter_modal_background.style["margin-left"] = "0";
    filter_modal_background.style["width"] = "auto";
    filter_modal_background.style["height"] = "auto";
    filter_modal_background.style["z-index"] = "1";

    filters_scrollable.style["position"] = "relative";
    filters_scrollable.style["width"] = "auto";
    filters_scrollable.style["top"] = "auto";
    filters_scrollable.style["left"] = "auto";

    Array.prototype.forEach.call(filters_close_buttons, el => {
        el.style["display"] = "none";
    });
}

const hideFilters = () => {
    document.getElementById("filters").style["display"] = "none";
}

const openFilters = () => {
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

    filters_close_buttons[0].focus();
}

const closeFilters = () => {
    filters.style["display"] = "none";
    filter_modal_background.style["display"] = "none";
    filters_open_button.focus();
}

const addSubmitOnclick = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        el.onclick = function() {
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

const collapse = (name) => {
    item = document.getElementById(name);
    if (item.checked) {
        item.checked = false;
    } else {
        item.checked = true;
    }
    setCollapsibleIcon(name);
}

const setCollapsibleIcon = (name) => {
    if (name == "initial_check") {
        return;
    }
    item = document.getElementById(name);
    headerId = "list_header" + name.substring(4);
    headerItem = document.getElementById(headerId);
    // remove old and insert new icon
    if (item.checked) {
        removeId = headerId + "_less";
        addId = headerId + "_more";
        content = "expand_more";
        classNames = "material-icons more";
    } else {
        removeId = headerId + "_more";
        addId = headerId + "_less";
        content = "expand_less";
        classNames = "material-icons less";
    }
    remove = document.getElementById(removeId);
    if (remove) {
        headerItem.removeChild(remove);
    }
    span = document.createElement("span");
    span.innerHTML = content;
    span.setAttribute("id", addId);
    span.setAttribute("class", classNames);
    headerItem.appendChild(span);
}

const initialCollapsibleCheck = () => {
    Array.prototype.forEach.call(isCheckInputs, el => {
        setCollapsibleIcon(el.id);
    })
}

const hasVisited = () => {
    return init.checked;
}

const handleFirstTime = () => {
    Array.prototype.forEach.call(isCheckInputs, (e) => {
        if (e.id != "show_area") {
            e.checked = true;
        }
    })
}

document.addEventListener('keydown', (e) => {
    if (e.code == "Escape" && filters.style["display"] === "block" && isSmallReader) {
        closeFilters();
    }
});

const initialCheck = () => {
    if (isSmallReader()) {
        showFilterButton();
        hideFilters();
        removeSubmitOnclick();
    } else {
        addSubmitOnclick();
        showFilters();
        hideFilterButton();
    }
}

window.addEventListener('resize', initialCheck);

initialCheck();
if (!hasVisited()) {
    handleFirstTime();
}
initialCollapsibleCheck();
