// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

console.log("site.js loaded");

document.addEventListener('click', function (e) {

    // Check if the item exists
    if (document.getElementById('listview')) {
        if (e.target.id == "listview") {
            console.log("set list")
            document.getElementById('listheader').classList.remove("grid");
            document.getElementById('redlist').classList.remove("grid");
           

            
        }
    }

    // Check if the item exists
    if (document.getElementById('gridview')) {
        if (e.target.id == "gridview") {
            console.log("set grid")
            document.getElementById('listheader').classList.add("grid");
            document.getElementById('redlist').classList.add("grid");
        }
    }
})

// Filters
function addFilter(filter) {
    if (document.URL.includes("?")) {
        return document.URL + "&" + filter;
    }
    return document.URL + "?" + filter;
}

function removeFilter(filter) {
    isOnlyFilter = !document.URL.includes("&");
    if (isOnlyFilter) {
        return  document.URL.replace("?" + filter, "");
    }
    if (document.URL.includes("&" + filter)) {
        return document.URL.replace("&" + filter, "")
    }
    return document.URL.replace(filter + "&", "");
}

function applyFilter(filter) {
    if (!document.URL.includes(filter)) {
        url = addFilter(filter);
    } else {
        url = removeFilter(filter);
    }
    window.location.replace(url);
}

function initialChecks() {
    filtersString = document.URL.split("?")[1];
    if (filtersString) {
        filters = filtersString.split("&");
        filters.forEach(filter => {
            if (!filter.includes("Name=")) {
                document.getElementById(filter).checked = true;
            }
        });
    }
}

initialChecks();