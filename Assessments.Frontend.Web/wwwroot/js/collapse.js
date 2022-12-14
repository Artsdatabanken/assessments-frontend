/**
 * toggleMe toggles an element's grandparent on and off.
 * A example of expandable box with styling:
 
 <div class="expandable expanded">
        <div class="expand_header">
             <h2>TITLE</h2>
            <button onclick="toggleMe(this)" class="ghost">
                <span class="material-icons if_expanded">expand_less </span>
                <span class="material-icons if_collapsed">expand_more </span>
            </button>
        </div>
        <div class="if_expanded expand_content">
        </div>
    </div>
 */

function toggleMe(element) {
    console.log(element.parentNode);
    parent = element.parentNode.parentNode;
    isExpanded = parent.classList.contains("expanded");
    if (isExpanded) {
        parent.classList.remove("expanded")
        parent.classList.add("collapsed")
    } else {
        parent.classList.add("expanded");
        parent.classList.remove("collapsed")
    }   
}

/*
'show_occurence_area',
'show_category_changed'*/