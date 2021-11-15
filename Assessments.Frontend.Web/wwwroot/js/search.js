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
    let name = "";
    if (el.message) {
        return `<span>${el.message}</span>`;
    }
    if (el.PopularName) {
        name = `<span>${el.PopularName}</span>`;
    }
    if (el.ScientificName) {
        name = `<span class="search_name">${name} ${formatScientificName(el.ScientificName)}</span>`;
    }
    if (el.TaxonCategory) {
        name += `<span class="taxon_rank">${el.TaxonCategory}</span>`;
    }
    return name;
}

const createList = (json) => {
    autocompleteList.innerHTML = "";
    json.forEach(el => {
        const assessments = el.assessments;
        if (assessments != null) {
            for (let i in assessments) {
                const id = assessments[i].id;
                const li = document.createElement("li");
                let action = `<span class="material-icons right_icon">keyboard_arrow_right</span>`;
                let category = "<span></span>";
                let icon = '<span class="material-icons search_list_icon">list</span>';
                if (assessments[i] && assessments[i].area) {
                    let areaname = "Norge";
                    if (assessments[i].area == "S") {
                        areaname = "Svalbard";
                    }
                    if (assessments[i].category) {
                        category = `<span class="search_category graphic_element ${assessments[i].category}">${assessments[i].category}</span >`;
                    }
                    if (assessments[i].speciesGroup) {
                        speciesGroup = '<span class="search_speciesgroup">' + assessments[i].speciesGroup + '</span >';
                    }
                    if (assessments[i].speciesGroupIconUrl) {
                        icon = '<img src="' + assessments[i].speciesGroupIconUrl + '" class="search_speciesicon" >';
                    }                   
                    action = '<span class="right_action">'+areaname+"</span >" + action;
                }
                
                li.innerHTML = icon + formatListElements(el) + speciesGroup + category + action;
                li.classList.add("search_autocomplete");
                li.tabIndex = 0;
                li.onclick = () => {
                    window.location.href = "/rodlisteforarter/2021/" + id;
                }
                li.onkeyup = (e) => {
                    if (e.keyCode === 13) {
                        window.location.href = "/rodlisteforarter/2021/" + id;
                    }
                }
                autocompleteList.appendChild(li);
            }
        } else {
            const li = document.createElement("li");
            let right_action = `<span class="right_action">Søk</span><span class="material-icons right_icon">search</span>`;
            let icon = '<span class="material-icons search_list_icon">list</span>';
            let category = "<span></span>";
            let speciesGroup = '<span class="search_speciesgroup"></span >';
            li.innerHTML = icon + formatListElements(el,) + speciesGroup + category + right_action;
            li.classList.add("search_autocomplete");
            li.tabIndex = 0;
            li.onclick = () => {
                searchField.value = el.ScientificName + " /" + el.TaxonCategory;
                document.getElementById("search_and_filter_form").submit();
            }
            li.onkeyup = (e) => {
                if (e.keyCode === 13) {
                    searchField.value = el.ScientificName + " /" + el.TaxonCategory;
                    document.getElementById("search_and_filter_form").submit();
                }
            }
            autocompleteList.appendChild(li);
        }
    });
    autocompleteList.style["display"] = "block";
}

const removeList = () => {
    autocompleteList.innerHTML = "";
    autocompleteList.style["display"] = "none";
}

const getListValues = (json) => {
    return json.map(el => {
        return {
            "PopularName": el.popularName,
            "TaxonCategory": taxonCategories[el.taxonCategory],
            "ScientificName": el.scientificName,
            "assessments": el.assessments,
            "message": el.message
        };
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


