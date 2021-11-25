const addSliders = () => {
    Array.prototype.forEach.call(submitCheckInputs, el => {
        const span = document.createElement("span");
        const div = document.createElement("div");
        span.setAttribute("class", "slider");
        div.setAttribute("class", "slider_container toggle_switch");
        parent = el.parentNode;
        parent.classList.add("switch_list_elemtent");
        div.appendChild(span);
        parent.insertBefore(div, el.nextSibling);
    });
}

if (!isSmallReader()) {
    addSliders();
}