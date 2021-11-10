const listButton = document.getElementById("list_view_button");
const statButton = document.getElementById("stat_view_button");

const isInputChecked = (name, value) => {
    return document.URL.indexOf(`${name}=${value}`) != -1;
}

const createCheckbox = () => {
    const inputElement = document.createElement("input");
    const name = "View";
    const value = "stat";

    inputElement.id = "view_checkbox";
    inputElement.type = "checkbox";
    inputElement.name = name;
    inputElement.value = value;
    inputElement.classList.add("collapse_checkbox");
    inputElement.checked = isInputChecked(name, value);
    
    return inputElement;
}

const insertViewCheckbox = () => {
    if (listButton) {
        const headerItem = listButton.parentNode;
        headerItem.insertBefore(createCheckbox(), headerItem.childNodes[0]);
    }
    
}

const changeViewButtons = () => {
    if (listButton || statButton) {
        const viewButtons = [listButton, statButton];

        viewButtons.forEach(btn => {
            const checkbox = document.getElementById("view_checkbox");
            btn.type = "button";
            btn.onclick = () => {
                if (btn.value == "stat") {
                    console.log("yo");
                    checkbox.checked = true;
                } else {
                    checkbox.checked = false;
                }
                document.getElementById("search_and_filter_form").submit();
            }
        })
    }   
}

insertViewCheckbox();
changeViewButtons();