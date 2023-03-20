const tableOfContentButton = document.getElementById('tableOfContentsLabel');
const tableOfContentInput = document.getElementById('showTableOfContentList');
const tableOfContentsSmallScreen = document.getElementById('tableOfContentsSmallScreen');

const hideTableOfContentsSmallScreen = () => {
    tableOfContentsSmallScreen.classList.add('table-of-contents-small-screen-show');
}

const showTableOfContentButton = () => {
    tableOfContentButton.classList.remove('table-of-contents-small-screen-button-hide');
}

const initializeTableOfContents = () => {
    hideTableOfContentsSmallScreen();
    showTableOfContentButton();
}

const closeTableOfContents = (event) => {
    if (event.target.nodeName == 'A')
        tableOfContentInput.checked = false;
}

initializeTableOfContents();