const searchField = document.getElementById("Name");
const autocompleteList = document.getElementById("autocomplete_list_ul");
const domain = window.location.domain;
const searchUrlBase =  "/rodlisteforarter/2021/suggestions";
const autoCompleteWaitTime = 1000;

const taxonCategories = {
    0: "Unknown",
    1: "Rike",
    2: "SubKingdom",
    3: "Rekke",
    4: "Underrekke",
    5: "SuperClass",
    6: "Klasse",
    7: "SubClass",
    8: "InfraClass",
    9: "Cohort",
    10: "SuperOrder",
    11: "Orden",
    12: "SubOrder",
    13: "InfraOrder",
    14: "SuperFamily",
    15: "Familie",
    16: "SubFamily",
    17: "Tribe",
    18: "SubTribe",
    19: "Slekt",
    20: "SubGenus",
    21: "Section",
    22: "Art",
    23: "Underart",
    24: "Varietet",
    25: "Form"
}

const wait = async (ms) => {
    return new Promise(resolve => {
        setTimeout(resolve, ms);
    });
}

const formatScientificName = (name) => {
    if (!name) return;
    name = `<i>${name}</i>`
    name = name.replace("×", "</i>×<i>");
    name = name.replace("aff.", "</i>aff.<i>");
    name = name.replace("agg.", "</i>agg.<i>");
    name = name.replace("coll.", "</i>coll.<i>");
    name = name.replace("n.", "</i>n.<i>");
    name = name.replace("sp.", "</i>sp.<i>");
    name = name.replace("subsp.", "</i>subsp.<i>");
    name = name.replace("var.", "</i>var.<i>")
    name = name.replace(" '", "</i> '");
    name = name.replace("' ", "'<i> ");
    name = name.replace("<i></i>", "");
    return name;
}

const formatListElements = (el) => {
    if (el.message) {
        return `<span>${el.message}</span>`
    }
    if (!el.PopularName) {
        return `${formatScientificName(el.ScientificName)} <span>(${el.TaxonCategory})</span>`
    }
    return `<span>${el.PopularName}</span> ${formatScientificName(el.ScientificName)} <span class="taxon_rank">(${el.TaxonCategory})</span>`
}

const createList = (json) => {
    autocompleteList.innerHTML = "";
    json.forEach(el => {
        const li = document.createElement("li");
        li.innerHTML = formatListElements(el);
        li.classList.add("search_autocomplete");
        li.tabIndex = 1;
        li.onclick = () => {
            searchField.value = el.ScientificName + " /" + el.TaxonCategory;
            document.getElementById("search_and_filter_form").submit();
        }
        autocompleteList.appendChild(li);
    });
    autocompleteList.style["display"] = "block";
}

const removeList = () => {
    autocompleteList.innerHTML = "";
    autocompleteList.style["display"] = "none";
}

const getListValues = (json) => {
<<<<<<< HEAD
    return json.map(el => {
        return {
            "PopularName": el.popularName,
            "TaxonCategory": taxonCategories[el.taxonCategory],
            "ScientificName": el.scientificName,
            "assessments": el.assessments,
            "message": el.message
        };
=======
    console.log(json);
    return json.map(el => {        
        return { "PopularName": el.popularName, "TaxonCategory": taxonCategories[el.taxonCategory], "ScientificName": el.scientificName, "message": el.message };
>>>>>>> a4ec9068caa4bbea0ab68d7393617e0fdc3b0d8a
    });
}

let autoCompleteTs;
const inputChange = async (e) => {
    let json;
    let localTs = Date.now();
    autoCompleteTs = localTs;
    
    const hasStoppedTyping = () => localTs === autoCompleteTs;
    
    if (e.target.value.length < 3) {
        timeStamp = Date.now();
        removeList();
        return;
    }
    searchUrl = searchUrlBase + `?search=${e.target.value}`;

    // wait and check if user has stopped typing
    await wait(autoCompleteWaitTime);
    if (!hasStoppedTyping()) {
        return;
    }

    // fetch results from api
    let response = await fetch(searchUrl);
    console.log(searchUrl);
    if (response.ok) {
        json = await response.json();
    }
    console.log(json);
    jsonList = getListValues(json);
    createList(jsonList);
}

if (searchField) {
    searchField.addEventListener("input", inputChange);
}

// close list when clicking outside it
window.onclick = (e) => {
    if (searchField && !searchField.contains(e.target) && !autocompleteList.contains(e.target)) {
        removeList();
    } 
}


// ACCESSIBILITY - NAVIGATE DROPDOWNLIST:

// Go from searchfield to suggestion on arrowdown
var autocompletelist = document.getElementById("autocomplete_list_ul");
searchField.addEventListener('keydown', function (event) {       
    if (autocompletelist.innerHTML.trim() != "") {
        if (event.key == "ArrowDown") {
            event.preventDefault();
            autocompletelist.firstChild.focus();
        }
    } 
});

// Navigate list with arrowkeys, leave list on first-child upkey
autocompletelist.addEventListener('keydown', function (event) {
    event.preventDefault();
    if (event.key == "ArrowUp") {
        if (event.target == autocompletelist.firstChild) {
            searchField.focus();
        } else {
            event.target.previousElementSibling.focus();
        }
    } else if (event.key == "ArrowDown") {
        if (event.target != autocompletelist.lastChild) {
            event.target.nextElementSibling.focus();
        }        
    }
});


