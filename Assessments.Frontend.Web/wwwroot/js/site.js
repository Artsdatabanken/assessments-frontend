// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

console.log("site.js loaded");

document.addEventListener('click', function (e) {

    // Check if the item exists
    if (document.getElementById('listview')) {
        if (e.target.id == "listview") {
            console.log("set list")
            document.getElementById('listheader').classList.remove("grid");
            document.getElementById('redlist').classList.remove("grid");
           

            
        }
    }

    // Check if the item exists
    if (document.getElementById('gridview')) {
        if (e.target.id == "gridview") {
            console.log("set grid")
            document.getElementById('listheader').classList.add("grid");
            document.getElementById('redlist').classList.add("grid");
        }
    }
})