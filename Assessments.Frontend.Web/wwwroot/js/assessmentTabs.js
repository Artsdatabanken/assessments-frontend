/* Info-tab actions for the assessment-pages. Openin/closing the big lists for 
   impact factors, criteria and habitats. Re-arranging some items that has a
   simpler (but more chaotic) display for users without javasctipt. */

/*****
*     Start of code especially for redlist species 2021
*****/

function criterialist(which, button) {
    // See more text by altering css of the clicked element's top parent node
    document.getElementById('summary_criteria').classList.remove("active");
    document.getElementById('full_list_criteria').classList.remove("active");

    if (which == 'full_list') {
        document.getElementById('criteria').classList.add("full_list");
        document.getElementById('criteria').classList.remove("summary");
    }
    if (which == 'summary') {
        document.getElementById('criteria').classList.add("summary");
        document.getElementById('criteria').classList.remove("full_list");
    }
    button.classList.add("active");
}

function impactlist(which, button) {
    // See more text by altering css of the clicked element's top parent node
    document.getElementById('summary').classList.remove("active");
    document.getElementById('full_list').classList.remove("active");

    if (which == 'full_list') {
        document.getElementById('impactfactors').classList.add("full_list");
        document.getElementById('impactfactors').classList.remove("summary");
    }
    if (which == 'summary') {
        document.getElementById('impactfactors').classList.add("summary");
        document.getElementById('impactfactors').classList.remove("full_list");
    }
    button.classList.add("active");
}

function expandCriteria(element, className) {
    expand(element, className, 'criteria');
}

function expandImpact(element, className) {
    expand(element, className, 'impactfactors');
}

function expand(element, className, id) {
    element = element.closest("li");
    var mainparent = document.getElementById(id).classList;
    // Never expand or collapse summary items
    if (mainparent.contains("full_list")) {
        if (element.classList.contains(className)) {
            element.classList.remove(className);
        } else {
            element.classList.add(className);
        }
    }
}

/*****
*     End of code especially for redlist species 2021
*****/

function showTabButtons() {
    // Users with javascript are shown the buttons to toggle tabs
    var elements = document.getElementsByClassName("changetab");
    for (let i in elements) {
        if (elements[i] && elements[i].style) {
            elements[i].style.visibility = "visible";
        }
    }
}

// Adds the class "opened_element" to all active tabs for use in the dropdown effects.
function first_close() {
    var elements = document.querySelectorAll(".tabbed_element_container li.active");

    Array.prototype.forEach.call(elements, el => {
        el.classList.add("opened_element");
    });
}

showTabButtons();
first_close();
if (document.getElementById('criteria') && document.getElementById('criteria').classList) {
    document.getElementById('criteria').classList.add("summary");
}
if (document.getElementById('impactfactors') && document.getElementById('impactfactors').classList) {
    document.getElementById('impactfactors').classList.add("summary");
}