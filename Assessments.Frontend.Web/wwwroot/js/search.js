const searchField = document.getElementById("Name");
const searchUrlBase = "https://artskart.artsdatabanken.no/appapi/api/data/SearchTaxons?";

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

const inputChange = async (e) => {
    if (e.target.value.length < 3) {
        return;
    }

    searchUrl = searchUrlBase + `name=${e.target.value}`;

    let response = await fetch(searchUrl);
    let json;
    if (response.ok) {
        json = await response.json();
    }
    json = json.map(el => {
        return {"match": el.MatchedName, "category": taxonCategories[el.TaxonCategory]};
    });
    console.log(json);
}

searchField.addEventListener("input", inputChange);