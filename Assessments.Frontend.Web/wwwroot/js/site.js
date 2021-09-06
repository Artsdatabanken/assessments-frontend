// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

console.log("site.js loaded");

// Constants
const filters = {
    RE: "Categories=RE",
    CR: "Categories=CR",
    EN: "Categories=EN",
    VU: "Categories=VU",
    NT: "Categories=NT",
    DD: "Categories=DD"
}

const chooseEndangered = "ChooseEndangered";
const chooseRedlisted = "ChooseRedlisted";

const endangeredFilter = [filters.CR, filters.EN, filters.VU];
const redlistFilter = [filters.RE, filters.CR, filters.EN, filters.VU, filters.NT, filters.DD];

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
function addFilter(filter, url) {
    if (url.includes(filter)) {
        return url;
    }
    if (url.includes("?")) {
        return url + "&" + filter;
    }
    return url + "?" + filter;
}

function removeFilter(filter, url) {
    isOnlyFilter = !url.includes("&");
    if (isOnlyFilter) {
        return  url.replace("?" + filter, "");
    }
    if (url.includes("&" + filter)) {
        return url.replace("&" + filter, "")
    }
    return url.replace(filter + "&", "");
}

function addSpecialFilter(appropriateFilters) {
    appropriateFilters.forEach(filter => {
        if (document.getElementById(filter).checked != true) {
            url = addFilter(filter, url);
        }
    });
    return url;
}

function removeSpecialFilter(appropriateFilters) {
    appropriateFilters.forEach(filter => {
        if (document.getElementById(filter).checked === true) {
            url = removeFilter(filter, url);
        }
    });
    return url;
}

function applySpecialFilter(filterType) {
    url = document.URL;
    appropriateFilters = [];
    if (filterType == chooseRedlisted) {
        appropriateFilters = [filters.RE, filters.CR, filters.EN, filters.VU, filters.NT, filters.DD];
    } else if (filterType == chooseEndangered) {
        appropriateFilters = [filters.CR, filters.EN, filters.VU];
    }
    if (document.getElementById(filterType).checked === true) {
        addSpecialFilter(appropriateFilters);
    } else {
        removeSpecialFilter(appropriateFilters);
    }
    window.location.replace(url);
}
