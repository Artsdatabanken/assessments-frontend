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
    if (!el.ScientificName) {
        return `<span>${el.message}</span>`
    }
    if (!el.PopularName) {
        return `${formatScientificName(el.ScientificName)} <span>(${el.TaxonCategory})</span>`
    }
    return `<span>${el.PopularName}</span> ${formatScientificName(el.ScientificName)} <span>(${el.TaxonCategory})</span>`
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
    if (typeof json != Array) {
        return [json];
    }
    return json.map(el => {
        return { "PopularName": el.popularName, "TaxonCategory": taxonCategories[el.taxonCategory], "ScientificName": el.scientificName };
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
    if (response.ok) {
        json = await response.json();
    }
    
    jsonList = getListValues(json);

    createList(jsonList);
}

searchField.addEventListener("input", inputChange);

window.onclick = (e) => {
    if (!searchField.contains(e.target) && !autocompleteList.contains(e.target)) {
        removeList();
    }
}