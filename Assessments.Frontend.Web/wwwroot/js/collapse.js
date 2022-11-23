/*
     Create an element containing a header element and a div for hiding.
     The header element will receive span elements injected in front of the headeing itself.
     The div is the element which will be hidden. If you have this structure you can add the id of the parent element to this list,
     and it will become collapsible.
     
     example structure when adding "example" into the id list:
     <div id="example">
        <h3>Header text</h3>
        <div>collapse me</div>
     </div>
*/

const makeCollapsibleListIds = [
    'show_expert_summary',
    'show_assessment_reasoning'
];

const expandLessInnerHtml = 'expand_less';
const expandMoreInnerHtml = 'expand_more';
const expandClassList = ['material-icons-outlined'];
const collapsibleHeaderClass = 'collapsible_header';

const getCollapsibleIcon = isOpen => {
    const icon = document.createElement('span');
    icon.classList = expandClassList;
    icon.innerHTML = isOpen ? expandLessInnerHtml : expandMoreInnerHtml;
    return icon;
}

const addCollapsibleArrow = element => {
    const icon = getCollapsibleIcon(isOpen = false);
    element.prepend(icon);
    element.classList.add(collapsibleHeaderClass);
}

const switchArrowType = element => {
    const showCollapsedIcon = Array.prototype.some.call(element?.childNodes, el => {
        return el.innerHTML === expandLessInnerHtml;
    });
    element.childNodes[0].remove();
    element.prepend(getCollapsibleIcon(!showCollapsedIcon));
}

const toggleCollapsed = element => {
    isCollapsed = element.style['display'] === 'none';
    console.log(element.style['display'])
    if (isCollapsed)
        element.style = 'display:block';
    else
        element.style = 'display:none';
}

const collapseElementUsingId = id => {
    const elements = document.getElementById(id)?.childNodes;
    const filtered = Array.prototype.filter.call(elements, (el => el.nodeType === Node.ELEMENT_NODE));
    const [ header, collapsible ] = filtered;

    switchArrowType(header);
    toggleCollapsed(collapsible);
}

const addOnclickFunction = (element, id) => {
    element.onclick = () => {
        collapseElementUsingId(id);
    }
}

const makeCollapsible = id => {
    const elements = document.getElementById(id)?.childNodes;
    if (!elements) return;

    const filtered = Array.prototype.filter.call(elements, (el => el.nodeType === Node.ELEMENT_NODE));
    if (filtered?.length !== 2) return;

    const [ header, collapsible ] = filtered;
    addCollapsibleArrow(header);
    addOnclickFunction(header, id);
    toggleCollapsed(collapsible);
}

makeCollapsibleListIds?.forEach(id => {
    makeCollapsible(id);
});