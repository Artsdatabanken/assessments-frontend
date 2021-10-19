const addSliders = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        const span = document.createElement("span");
        span.setAttribute("class", "slider");
        parent = el.parentNode;
        grandParent = parent.parentNode;
        parent.classList.add("toggle_switch");
        grandParent.classList.add("switch_list_elemtent");
        parent.insertBefore(span, el.nextSibling);
    });
}

if (!isSmallReader()) {
    addSliders();
}