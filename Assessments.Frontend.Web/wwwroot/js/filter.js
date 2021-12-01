const filterStyles = `
input[type=checkbox]:not(:checked)#show_area~.filter_area,
input[type=checkbox]:not(:checked)#show_category~.filter_category,
input[type=checkbox]:not(:checked)#show_region~.filter_region,
input[type=checkbox]:not(:checked)#show_european_population~.filter_european_population,
input[type=checkbox]:not(:checked)#show_criteria~.filter_criteria,
input[type=checkbox]:not(:checked)#show_habitat~.filter_habitat,
input[type=checkbox]:not(:checked)#show_extinct~.filter_extinct,
input[type=checkbox]:not(:checked)#show_species_groups~.filter_species_groups,
input[type=checkbox]:not(:checked)#show_taxon_rank~.filter_taxon_rank {
    display: none;
}

input[type=checkbox]:checked#show_insects~.filter_insects {
    display: block;
}

.filter_area,
.filter_category,
.filter_region,
.filter_european_population,
.filter_criteria,
.filter_extinct,
.filter_habitat,
.filter_species_groups,
.filter_taxon_rank {
    display: block;
}

.filter_insects {
    display: none;
}
`;

const showFilterButton = () => {
    document.getElementById("open_filter").style["display"] = "inline-block";
}

const hideFilterButton = () => {
    document.getElementById("open_filter").style["display"] = "none";
}

const showFilters = () => {
    filters.style["display"] = "block";
    filter_modal_background.style["display"] = "block";
    filter_modal_background.classList.remove("modal_background_open");
    filters_scrollable.style["position"] = "relative";
    filters_scrollable.style["width"] = "auto";
    filters_scrollable.style["top"] = "auto";
    filters_scrollable.style["left"] = "auto";
    submit_filters.style["display"] = "none";
    Array.prototype.forEach.call(filters_close_buttons, el => {
        el.style["display"] = "none";
    });
}

const hideFilters = () => {
    submit_filters.style["display"] = "block";
    document.getElementById("filters").style["display"] = "none";
}

const openFilters = () => {
    filters.style["display"] = "block";
    filter_modal_background.style["display"] = "block";
    filter_modal_background.classList.add("modal_background_open");
    filters_scrollable.classList.add("open_field")
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
        removeId = headerId + "_more";
        addId = headerId + "_less";
        content = "arrow_drop_down";
        classNames = "material-icons less";
    } else {
        removeId = headerId + "_less";
        addId = headerId + "_more";
        content = "arrow_right";
        classNames = "material-icons more";
    }
    remove = document.getElementById(removeId);
    if (remove) {
        headerItem.removeChild(remove);
    }
    span = document.createElement("span");
    span.innerHTML = content;
    span.setAttribute("id", addId);
    span.setAttribute("class", classNames);
    headerItem.insertBefore(span, headerItem.childNodes[0]);
}

const initialCollapsibleCheck = () => {
    Array.prototype.forEach.call(isCheckInputs, el => {
        setCollapsibleIcon(el.id);
    })
}

const handleFirstTime = () => {
    Array.prototype.forEach.call(isCheckInputs, (e) => {
        if (e.id == "show_area" || e.id == "show_insects") {
            e.checked = true;
        } else {
            e.checked = false;
        }
    })
}

const shouldToggleMarkAll = (elementsClass) => {
    const allElements = document.getElementsByClassName(elementsClass);
    return Array.prototype.every.call(allElements, (element) => {
        return element.checked === true;
    })
}

const shouldToggleMarkRedOrEnd = (list) => {
    return Array.prototype.every.call(list, (item) => {
        return document.getElementById("input_" + item).checked === true;
    })
}

const toggleMarkAll = () => {
    if (shouldToggleMarkAll("insect_input")) {
        insectInput.checked = true;
    }
    if (shouldToggleMarkRedOrEnd(redlisted)) {
        redlistCheck.checked = true;
    }
    if (shouldToggleMarkRedOrEnd(endangered)) {
        endangeredCheck.checked = true;
    }
}

const toggleRedlistedCategories = () => {
    const isEndangeredActive = endangeredCheck.checked;
    const isRedlistedActive = redlistCheck.checked;
    redlisted.forEach(el => {
        if (isRedlistedActive) {
            document.getElementById("input_" + el).checked = true;
        } else {
            if (isEndangeredActive) {
                endangeredCheck.checked = false;
            } 
            document.getElementById("input_" + el).checked = false;
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
                redlistCheck.checked = false;
            }
            document.getElementById("input_" + el).checked = false;
        }
    })
}

const toggleInsects = () => {
    Array.prototype.forEach.call(insectFilters, insect => {
        if (insectInput.checked) {
            insect.checked = true;
        } else {
            insect.checked = false;
        }
    });
}

const toggleSingleFilter = (element, parentId) => {
    if (!element.checked) {
        document.getElementById(parentId).checked = false;
    }
}

document.addEventListener('keydown', (e) => {
    if (e.code == "Escape" && filters.style["display"] === "block" && isSmallReader()) {
        closeFilters();
    }
});

const initialFilterCheck = () => {
    if (isSmallReader()) {
        showFilterButton();
        hideFilters();
        removeSubmitOnclick();
    } else {
        showFilters();
        hideFilterButton();
    }
    addOnclick();
}

if (filters) {
    window.addEventListener('resize', initialFilterCheck);

    const stylesheet = document.createElement("style");
    stylesheet.innerText = filterStyles;
    document.head.appendChild(stylesheet);

    initialFilterCheck();
    if (!hasVisited()) {
        setVisited();
        handleFirstTime();
    }
    initialCollapsibleCheck();
}

document.getElementById("filter_modal_background").addEventListener('click', function (e) {
    if (document.getElementById("filter_modal_background") && e.target == document.getElementById("filter_modal_background")) {
        closeFilters();
    } 
});


function submitClickedElement(element) {
    // Uncheck related checbox from filter
    const checkboxed = document.getElementById(element);
    if (checkboxed && checkboxed.checked == true) {
        checkboxed.checked = false;
    }
    updateToggleAll(checkboxed);
}