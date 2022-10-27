/* Anything Filter should go here
 * Filters are only relevant for the main page of the redlist */

// DOM elements
const filters = document.getElementById("filters");

if (filters) {
const isCheckInputs = document.getElementsByClassName("collapse_checkbox");
const algaeFilters = document.getElementsByClassName("Alger_input");
const insectFilters = document.getElementsByClassName("insect_input");
const alienSpeciesInsectFilters = document.getElementsByClassName("Insekter_input");
const crayfishFilters = document.getElementsByClassName("Krepsdyr_input");
const algaeInput = document.getElementById("Alger");
const insectInput = document.getElementById("Insekter");
const crayfishInput = document.getElementById("Krepsdyr");
const redlistCheck = document.getElementById("redlisted_check")?.checked;
const endangeredCheck = document.getElementById("endangered_check")?.checked;
const init = document.getElementById("initial_check");
const scrollTo = document.getElementById("remember_scroll");

// Constants
const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
const endangered = ["CR", "EN", "VU"];

// Ids for filters that should be open by default
const handleFirstTimeIds = [
    "show_area",
    "show_eda",
    "show_sal",
    "show_insects",
    "show_skr",
    "show_sin"
];

function hasVisited() {
    // in url: check if this is the first run
    return init.checked;
}

function setVisited() {
    // in url: mark page as visited.
    init.checked = true;
}

function handleFirstTime() {
    // On the first run, close all but given elements
    Array.prototype.forEach.call(isCheckInputs, (e) => {
        if (handleFirstTimeIds.includes(e.id)) {
            e.checked = true;
        } else {
            e.checked = false;
        }
    })
}

function scrollToPreviousPosition() {
    if (!scrollTo) return;
    const position = scrollTo.value;
    window.scrollTo(0, position);
}

function closeFilters() {
    document.getElementById("filters").classList.add("hide_on_smallscreen");
    document.body.classList.remove('noscroll');
    document.getElementById("open_filter").focus();
}

function openFilters() {
    document.getElementById("filters").classList.remove("hide_on_smallscreen");
    document.getElementsByClassName("close_filters")[0].focus();
    document.body.classList.add('noscroll');
}

function collapse(name) {
    item = document.getElementById(name);
    if (item.checked) {
        item.checked = false;
    } else {
        item.checked = true;
    }
    setCollapsibleIcon(name);
}

function initialCollapsibleCheck() {
    Array.prototype.forEach.call(isCheckInputs, el => {
        setCollapsibleIcon(el.id);
    })
}

function startup() {
    scrollToPreviousPosition();
    // Remove no javascript tag, making js-availiable styling apply
    if (document.getElementById("open_filter")) {
        document.getElementById("open_filter").classList.remove("no_js");
    }
    if (filters) { // Double-check in case first check gets removed ^^
        filters.classList.remove("no_js");
        // Add js-tag for elements only relevant to js-users. 
        filters.classList.add("only_js");
    }
    closeFilters();
    addOnclick();
    window.addEventListener('resize', addOnclick);
    if (!hasVisited()) {
        setVisited();
        handleFirstTime();
    }
    initialCollapsibleCheck();
}

// EVENTS 
if (document.getElementById("filter_modal_background")) {
    // Click on filter_modal_background outside filterbox closes it
    document.getElementById("filter_modal_background").addEventListener('click', function (e) {
        if (e.target == document.getElementById("filter_modal_background")) {
            closeFilters();
        }
    });
}

function submitClickedElement(element) {
    // Uncheck related checbox from filter
    element = element.split(' ').join('_'); // spaces must not exist -> underscore
    const checkboxed = document.getElementById(element);
    if (checkboxed && checkboxed.checked == true) {
        checkboxed.checked = false;
    }
    updateToggleAll(checkboxed);
}


/* Old code not changed  much */

function setCollapsibleIcon(name) {
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
    headerItem?.insertBefore(span, headerItem?.childNodes[0]);
}

// Handle toggle events for misc. scenario

function shouldToggleMarkAll(elementsClass) {
    const allElements = document.getElementsByClassName(elementsClass);
    return allElements.length && Array.prototype.every.call(allElements, (element) => {
        return element.checked === true;
    })
}

function shouldToggleMarkRedOrEnd(list) {
    return Array.prototype.every.call(list, (item) => {
        return document.getElementById("input_" + item)?.checked === true;
    })
}

function toggleMarkAll() {
    if (shouldToggleMarkAll("Alger_input")) {
        algaeInput.checked = true;
    }
    if (shouldToggleMarkAll("insect_input") || shouldToggleMarkAll("Insekter_input")) {
        insectInput.checked = true;
    }
    if (shouldToggleMarkAll("Krepsdyr_input")) {
        crayfishInput.checked = true;
    }
    if (shouldToggleMarkRedOrEnd(redlisted)) {
        redlistCheck.checked = true;
    }
    if (shouldToggleMarkRedOrEnd(endangered)) {
        endangeredCheck.checked = true;
    }
}

function toggleAllOfType(what, primaryToggleElementId, secondaryToggleElementId) {
    const secondaryToggleElement = document.getElementById(secondaryToggleElementId).checked;
    const primaryToggleElement = document.getElementById(primaryToggleElementId).checked;
    what.forEach(el => {
        if (primaryToggleElement) {
            document.getElementById("input_" + el).checked = true;
        } else {
            if (secondaryToggleElement) {
                document.getElementById(secondaryToggleElementId).checked = false;
            }
            document.getElementById("input_" + el).checked = false;
        }
    })
}

function toggleRedlistedCategories() {
    toggleAllOfType(redlisted, "redlisted_check", "endangered_check");
}

function toggleEndangeredCategories() {
    toggleAllOfType(endangered, "endangered_check", "redlisted_check");
}

function toggleSubSpecies(filters, input) {
    Array.prototype.forEach.call(filters, subSpecies => {
        if (input.checked) {
            subSpecies.checked = true;
        } else {
            subSpecies.checked = false;
        }
    });
}

function toggleSingleFilter(element, parentId) {
    if (!element.checked) {
        document.getElementById(parentId).checked = false;
    }
}

function updateToggleAll(el) {
    if (el && el.classList[0] === "Alger_input") {
        toggleSingleFilter(el, "Alger");
    } else if (el && (el.classList[0] === "insect_input" || el.classList[0] === "Insekter_input")) {
        toggleSingleFilter(el, "Insekter");
    } else if (el && el.classList[0] === "Krepsdyr_input") {
        toggleSingleFilter(el, "Krepsdyr");
    } else if (el && endangered.some(category => el.id.indexOf(category) != -1)) {
        toggleSingleFilter(el, "endangered_check");
        toggleSingleFilter(el, "redlisted_check");
    } else if (el && redlisted.some(category => el.id.indexOf(category) != -1)) {
        toggleSingleFilter(el, "redlisted_check");
    }
}

function onClickAction(el, addOrRemove) {
    // Clickevents for the toggles
    if (el.id === "redlisted_check") {
        toggleRedlistedCategories();
    } else if (el.id === "endangered_check") {
        toggleEndangeredCategories();
    } else if (el.id === "Alger") {
        toggleSubSpecies(algaeFilters, algaeInput);
    } else if (el.id === "Insekter") {
        toggleSubSpecies(insectFilters, insectInput);
        toggleSubSpecies(alienSpeciesInsectFilters, insectInput);
    } else if (el.id === "Krepsdyr") {
        toggleSubSpecies(crayfishFilters, crayfishInput);
    } else {
        if (addOrRemove == "add") {
            updateToggleAll(el);
            toggleMarkAll();
        } else {
            el.onclick = null;
        }
    }
    if (addOrRemove == "add") {
        scrollTo.value = "scroll_" + window.scrollY;
        scrollTo.checked = true;
        /*
        if (allFiltersArePossible) {
            //activate if toggle all of the filters are possible? 
            toggleSingleFilter(el);
        }*/
    }
}

function addOnclick() {
    if (!submitCheckInputs) return;
    Array.prototype.forEach.call(submitCheckInputs, el => {
        el.onclick = function () {
            onClickAction(el, "add");
            if (!isSmallReader() && this.form) {
                this.form.submit();
            }
        };
    });
}

function removeSubmitOnclick() {
    if (!submitCheckInputs) return;
    Array.prototype.forEach.call(submitCheckInputs, el => {
        el.onclick = function () {
            onClickAction(el, "remove");
        };
    });
}

/* RUN THE STARTUP */
startup();
}
