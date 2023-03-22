/* Anything Filter should go here
 * Filters are only relevant for the main page of the redlist */

// DOM elements
const filters = document.getElementById("filters");

if (filters) {
    const isCheckInputs = document.getElementsByClassName("collapse_checkbox");
    const insectFilters = document.getElementsByClassName("insect_input");
    const insectInput = document.getElementById("Insekter");
    const redlistCheckbox = document.getElementById("redlisted_check");
    const endangeredCheckbox = document.getElementById("endangered_check");
    const init = document.getElementById("initial_check");
    const scrollTo = document.getElementById("remember_scroll");

    // Constants
    const redlisted = ["RE", "CR", "EN", "VU", "NT", "DD"];
    const endangered = ["CR", "EN", "VU"];

    // Ids for filters that should be open by default
    const handleFirstTimeIds = [
        "show_area",
        "show_dcin",
        "show_dcok",
        "show_dcipah",
        "show_eds",
        "show_sal",
        "show_ccke",
        "show_insects",
        "show_skr",
        "show_sin",
        "show_ttn",
        "show_cep",
        "show_cei",
        "show_swimp",
        "show_swnat",
        "show_swspr",
        "show_regionallyalien",
        "show_rar"
    ];

    const markAllInputs = document.querySelectorAll(".mark_all > input:first-of-type");
        
    const hasVisited = () => {
        // in url: check if this is the first run
        if (init) {
            return init.checked;
        } else {
            return false;
        }
    }

    const setVisited = () => {
        // in url: mark page as visited.
        if (init) {
            init.checked = true;
        }
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
            const parentElement = document.getElementById(element.id).parentElement;
            const shouldIgnoreMarkAllInput = Array.prototype.includes.call(parentElement.classList, 'mark_all');
            return element.checked === true || shouldIgnoreMarkAllInput;
        })
    }

    function shouldToggleMarkRedOrEnd(list) {
        return Array.prototype.every.call(list, (item) => {
            return document.getElementById("input_" + item)?.checked === true;
        })
    }

    function allChildrenMarkedTriggerMarkAll() {
        if (markAllInputs) {
            Array.prototype.forEach.call(markAllInputs, input => {
                if (shouldToggleMarkAll(`${input.id}_input`)) {
                    input.checked = true;
                }
            });
        }
        // redlist species 2021
        if (shouldToggleMarkAll("insect_input")) {
            insectInput.checked = true;
        }
        if (shouldToggleMarkRedOrEnd(redlisted)) {
            redlistCheckbox.checked = true;
        }
        if (shouldToggleMarkRedOrEnd(endangered)) {
            endangeredCheckbox.checked = true;
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

    function toggleSubGroup(filters, input) {
        Array.prototype.forEach.call(filters, subGroup => {
            subGroup.checked = input.checked;
        });
    }

    function toggleSingleFilter(element, parentId) {
        if (!element.checked) {
            if (document.getElementById(parentId))
                document.getElementById(parentId).checked = false;
        }
    }

    const updateToggleAll = (el) => {
        if (!el) return;

        if (markAllInputs) {
            const shouldToggleSubGroup = Array.prototype.some.call(markAllInputs, input => input.id === el.id);

            if (shouldToggleSubGroup) {
                const subFilters = document.getElementsByClassName(`${el.id}_input`);
                toggleSubGroup(subFilters, el);
            }
        }
        const classNames = Array.prototype.filter.call(el.classList, name => name.indexOf('_input') != -1);

        if (classNames.length && !classNames.includes('insect_input')) {
            classNames.forEach(name => {
                const idIndex = name.indexOf('_input');
                const filterId = name.substring(0, idIndex);
                toggleSingleFilter(el, filterId);
            })
        }
        // redlist species 2021
        else if (el.classList[0] === "insect_input") {
            toggleSingleFilter(el, "Insekter");
        } else if (endangered.some(category => el.id.indexOf(category) != -1)) {
            toggleSingleFilter(el, "endangered_check");
            toggleSingleFilter(el, "redlisted_check");
        } else if (redlisted.some(category => el.id.indexOf(category) != -1)) {
            toggleSingleFilter(el, "redlisted_check");
        }
    }

    // Clickevents for the toggles
    function onClickAction(el, addOrRemove) {
        if (el.id === "redlisted_check") {
            toggleRedlistedCategories();
        } else if (el.id === "endangered_check") {
            toggleEndangeredCategories();
        } else if (el.id === "Insekter") {
            toggleSubGroup(insectFilters, insectInput);
        } else {
            if (addOrRemove == "add") {
                updateToggleAll(el);
                allChildrenMarkedTriggerMarkAll();
            } else {
                el.onclick = null;
            }
        }
        if (addOrRemove == "add") {
            scrollTo.value = "scroll_" + window.scrollY;
            scrollTo.checked = true;
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
