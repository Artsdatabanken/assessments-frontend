//This file contains code for the collapsible property of elements.
//When adding a new collapsible element to the page, you need to have the code structured in this way
//with the appropriate class names and ids corresponing to what it is. The class name "initially_closed" is added
// if you want to collapse the element initially.
//
//<div class="collapsible initially_closed">
//    <div class="collapsible_header">
//        <h2>This is header text</h2>
//        <button onclick="toggleCollapsible(this)">
//            <span class="material-icons expanded_icon">expand_less</span>
//            <span class="material-icons collapsed_icon">expand_more</span>
//        </button>
//    </div >
//
//    <div class="collapsible_content">
//        <collapsible content>
//    </div>
//</div >

const hideClassName = 'hide-element';
const collapsibleClassName = 'collapsible';

const toggleCollapsible = buttonElement => {
    const mainElement = buttonElement.parentNode.parentNode;
    const collapsibleContentElement = mainElement.children[1];
    const isCollapsed = collapsibleContentElement.classList.contains(hideClassName);
    const expandLessIcon = buttonElement.children[0];
    const expandMoreIcon = buttonElement.children[1];

    if (isCollapsed) {
        collapsibleContentElement.classList.remove(hideClassName);
        expandLessIcon.classList.remove(hideClassName);
        expandMoreIcon.classList.add(hideClassName);
    } else {
        collapsibleContentElement.classList.add(hideClassName);
        expandLessIcon.classList.add(hideClassName);
        expandMoreIcon.classList.remove(hideClassName);
    }
}

const initialCollapse = () => {
    const collapsibleMainElements = document.getElementsByClassName(collapsibleClassName);
    Array.prototype.forEach.call(collapsibleMainElements, element => {
        const collapsibleContent = element.children[1];
        collapsibleContent.classList.add(hideClassName);
    });
}

const revealToggleCollapsibleButtons = () => {
    const collapsibleMainElements = document.getElementsByClassName(collapsibleClassName);
    Array.prototype.forEach.call(collapsibleMainElements, element => {
        const buttonElement = element.children[0].children[1];
        buttonElement.classList.remove(hideClassName);
        toggleCollapsible(buttonElement);
    });
}

const initCollapsible = () => {
    revealToggleCollapsibleButtons();
    initialCollapse();
}

initCollapsible();