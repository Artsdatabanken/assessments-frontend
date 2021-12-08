/* Anything Filter should go here
 * Filters are only relevant for the main page of the redlist */

// DOM elements
const filters = document.getElementById("filters");
const isCheckInputs = document.getElementsByClassName("collapse_checkbox");
const insectFilters = document.getElementsByClassName("insect_input");
const insectInput = document.getElementById("Insekter");
const redlistCheck = document.getElementById("redlisted_check").checked;
const endangeredCheck = document.getElementById("endangered_check").checked;
const init = document.getElementById("initial_check");


function hasVisited(){
    return init.checked;
}

function setVisited(){
    init.checked = true;
}

function scrollToPreviousPosition(){
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
    console.log("~ startup filters")
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

    // Users with javascript should always see this item
    closeFilters();
    window.addEventListener('resize', addOnclick);
    addOnclick();
    if (!hasVisited()) {
        /*
             hasVisited checks url if meta hasVisited is set 
             All filtergrups start open (people w/o js. ) 
             TODO : CONSIDER using the no_js tag instead. 
             close all but Vurderingsområde on first visit.
             After first visit, use isCheck instead to know which groups are opened and closed.
         */
        setVisited();
        handleFirstTime();
    }
    initialCollapsibleCheck();
    console.log("~ startup complete ^.^");
}

if (filters) {
    /* RUN THE STARTUP */
    startup();
}


// EVENTS 

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


function setCollapsibleIcon(name){
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


function handleFirstTime(){
    Array.prototype.forEach.call(isCheckInputs, (e) => {
        if (e.id == "show_area" || e.id == "show_insects") {
            e.checked = true;
        } else {
            e.checked = false;
        }
    })
}

function shouldToggleMarkAll(elementsClass){
    const allElements = document.getElementsByClassName(elementsClass);
    return Array.prototype.every.call(allElements, (element) => {
        return element.checked === true;
    })
}

function shouldToggleMarkRedOrEnd(list){
    return Array.prototype.every.call(list, (item) => {
        return document.getElementById("input_" + item).checked === true;
    })
}

function toggleMarkAll(){
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

function toggleAllOfType(what, thisid, thatid) {
    const thatone = document.getElementById(thatid).checked;
    const thisone = document.getElementById(thisid).checked;
    what.forEach(el => {
        if (thisone) {
            document.getElementById("input_" + el).checked = true;
        } else {
            if (thatone) {
                document.getElementById(thatid).checked = false;
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

function toggleInsects(){
    Array.prototype.forEach.call(insectFilters, insect => {
        if (insectInput.checked) {
            insect.checked = true;
        } else {
            insect.checked = false;
        }
    });
}

function toggleSingleFilter(element, parentId){
    if (!element.checked) {
        document.getElementById(parentId).checked = false;
    }
}

