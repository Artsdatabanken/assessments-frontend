const searchField = document.getElementById("Name");
const autocompleteList = document.getElementById("autocomplete_list_ul");
const searchUrlBase = "https://artskart.artsdatabanken.no/appapi/api/data/SearchTaxons?";
const autoCompleteWaitTime = 1500;

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

const createList = (json) => {
    autocompleteList.innerHTML = "";
    json.forEach(el => {
        const li = document.createElement("li");
        li.innerHTML = `${el.MatchedName} (${el.TaxonCategory})`;
        li.classList.add("search_autocomplete");
        li.tabIndex = 1;
        li.onclick = () => {
            searchField.value = el.MatchedName;
            document.getElementById("search_and_filter_form").submit();
        }
        autocompleteList.appendChild(li);
    });
    autocompleteList.style["display"] = "block";
}

let autoCompleteTs;
const inputChange = async (e) => {
    let json;
    let localTs = Date.now();
    autoCompleteTs = localTs;
    
    const hasStoppedTyping = () => localTs === autoCompleteTs;
    
    if (e.target.value.length < 3) {
        timeStamp = Date.now();
        return;
    }
    searchUrl = searchUrlBase + `name=${e.target.value}`;

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
    json = json.map(el => {
        return { "MatchedName": el.MatchedName, "TaxonCategory": taxonCategories[el.TaxonCategory]};
    });

    createList(json);
}

searchField.addEventListener("input", inputChange);