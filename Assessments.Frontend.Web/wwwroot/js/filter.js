
function closeFilters() {
    document.getElementById("filters").classList.add("hide_on_smallscreen");
    document.body.classList.remove('noscroll');
    filters_open_button.focus();
}

function openFilters() {
    document.getElementById("filters").classList.remove("hide_on_smallscreen");
    filters_close_buttons[0].focus();
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

function startup() {
    console.log("~ startup filters")

    // Remove no javascript tag, making js-availiable styling apply
    if (document.getElementById("open_filter")) {
        document.getElementById("open_filter").classList.remove("no_js");
    }
    if (document.getElementById("filters")) {
        document.getElementById("filters").classList.remove("no_js");
    }
    

    // Users with javascript should always see this item
    closeFilters();

    
    console.log("~ startup complete ^.^");
}

startup();


/* EVENTS */


document.addEventListener('keydown', (e) => {
    // Keypress on entire page
    
    if (e.code == "Escape" && isSmallReader()) {
        // Only listen to escape clicks, and only on tiny screens

        if (document.getElementById("filters") &&
            !document.getElementById("filters").classList.contains("hide_on_smallscreen")) {
            // If filter box is open, close it.
            closeFilters();
        }
    }    
});

if (document.getElementById("filter_modal_background")) {
    // Click outside filtebox closes filterbox
    document.getElementById("filter_modal_background").addEventListener('click', function (e) {
        if (document.getElementById("filter_modal_background") && e.target == document.getElementById("filter_modal_background")) {
            closeFilters();
        }
    });
}

function submitClickedElement(element) {
    console.log("Updating filter on chips click")
    // Uncheck related checbox from filter
    element = element.split(' ').join('_'); // spaces must not exist -> underscore
    const checkboxed = document.getElementById(element);
    if (checkboxed && checkboxed.checked == true) {
        checkboxed.checked = false;
    }
    updateToggleAll(checkboxed);
}


/* Old code not changed  much */

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

if (filters) {
    window.addEventListener('resize', addOnclick);
    const stylesheet = document.createElement("style");
    stylesheet.innerText = filterStyles;
    document.head.appendChild(stylesheet);
    addOnclick();
    if (!hasVisited()) {
        /*
             hasVisited checks url if meta hasVisited is set 
             All filtergrups start open (people w/o js. ) TODO : CONSIDER using the no_js tag instead. 
             close all but Vurderingsområde on first visit.
             After first visit, use isCheck instead to know which groups are opened and closed.
         */
        setVisited();
        handleFirstTime();
    }
    initialCollapsibleCheck();
}
