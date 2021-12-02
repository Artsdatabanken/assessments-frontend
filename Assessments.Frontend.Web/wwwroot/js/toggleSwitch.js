function addSliders(){
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

function addTogglesCheck() {
    if (!isSmallReader()) {
        addSliders();
    }
}

addTogglesCheck();


window.addEventListener('resize', function (event) {

    // ON RESIZE - choose between toggles and checkboxes. Complex, but necessary.
    if (isSmallReader()) {
        document.querySelectorAll('.switch_list_elemtent').forEach(function (el) {
            el.classList.remove('switch_list_elemtent')
        });
        document.querySelectorAll('.slider_container').forEach(function (el) {
            el.style.display = "none";
        });
    } else {
        if (document.querySelectorAll('.slider_container').length == 0) {
            addSliders();
        } 
        Array.prototype.forEach.call(submitCheckInputs, el => {
            parent = el.parentNode;
            parent.classList.add("switch_list_elemtent");
        });
        document.querySelectorAll('.slider_container').forEach(function (el) {
            el.style.display = "inline-block";
        });
    }
    


}, true);