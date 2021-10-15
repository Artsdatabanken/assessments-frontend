const addSliders = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        const span = document.createElement("span");
        span.setAttribute("class", "slider");
        parent = el.parentNode;
        parent.classList.add("toggle_switch");
        parent.insertBefore(span, el.nextSibling);
    });
}

if (!isSmallReader()) {
    addSliders();
}