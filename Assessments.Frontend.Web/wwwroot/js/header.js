// Startup
window.addEventListener('load', function () {
    getHeaderMenu();
})

window.addEventListener('click', function (e) {
    // Closes dropdown menu when clicking outside it. 
    if (document.getElementById('headermenu')) {
        if (!document.getElementById('headermenu').contains(e.target)) {
            if (document.getElementById("dropdown-header-menu")) {
                document.getElementById("dropdown-header-menu").style.display = "none";
            }
        }

        if (e.target.id == "navbar-mobile") {
            let drop = document.getElementById("headermenu");
            if (drop.className == "hide") {
                drop.className = "show"
            } else {
                drop.className = "hide"
            }
        }
    }
})

// Lets pretend this is a part of the main site
function getHeaderMenu() {
    try {
        // Obtaining the relevant doi to look up.
        let url = "https://www.artsdatabanken.no/api/Content/341039";
        fetch(url)
            .then((response) => {
                return response.json()
            })
            .then((data) => {
                try {
                    let apimenus = data.Records;

                    const menuButtonChevron = document.createElement('span');
                    menuButtonChevron.classList.add('material-icons');
                    menuButtonChevron.innerHTML = 'expand_more';

                    const menuButton = document.createElement('button');
                    menuButton.classList.add('dropdown-toggle');
                    menuButton.ariaHasPopup = true;
                    menuButton.innerHTML = 'Meny';
                    menuButton.appendChild(menuButtonChevron);

                    const menuDiv = document.createElement('div');
                    menuDiv.id = 'dropdown-header-menu';
                    menuDiv.classList.add('dropdown-menu', 'header-mega-menu');
                    menuDiv.style.display = 'none';

                    const menuUl = document.createElement('ul');
                    menuUl.classList.add('dropdown-menu');

                    menuDiv.appendChild(menuUl);

                    try {
                        document.getElementById('headermenu').appendChild(menuButton);
                        document.getElementById('headermenu').appendChild(menuDiv);
                    } catch (e) {
                        constole.error('unable to add header menu');
                    }

                    for (let i in apimenus) {
                        let submenu = apimenus[i];
                        let id = submenu.Values.toString().replace(" ", "");

                        // Using createelement to enable attachment of eventlistener
                        let buttonname = submenu.Values;
                        if (buttonname == "English") {
                            // Currently hiding it due to lack of uu in homepage. 
                            // Add to page
                            let spacer = document.createElement('div');
                            spacer.className = "englishspacer";
                            appendData('headermenu', spacer);
                            return null;
                        }

                        // Generate the dropdowncontent 
                        const listElement = document.createElement('li');
                        listElement.classList.add('dropdown-list');
                        listElement.id = 'dropdown-list-' + i;

                        const listTitle = document.createElement('span');
                        listTitle.classList.add('dropdown-list-title');
                        listTitle.innerHTML = buttonname;

                        listElement.appendChild(listTitle);

                        const menuDropdownList = document.createElement('ul');
                        Array.prototype.forEach.call(submenu.References, (item) => {
                            const listItem = document.createElement('li');

                            const anchorItem = document.createElement('a');
                            anchorItem.classList.add('header-mega-link-element');
                            anchorItem.href = 'https://artsdatabanken.no' + item.Url;

                            const anchorItemContent = document.createElement('div');
                            anchorItemContent.classList.add('header-mega-link-text');

                            const anchorItemContentHeader = document.createElement('b');
                            anchorItemContentHeader.classList.add('header-site-name');
                            anchorItemContentHeader.innerHTML = item.Heading ?? item.Title;

                            const anchorItemContentDescription = document.createElement('p');
                            anchorItemContentDescription.classList.add('header-site-description');
                            anchorItemContentDescription.innerHTML = item.Records[0].Values[0].startsWith('//') || item.Records[0].Values[0].startsWith('http') ? item.Records[1].Values[0] : item.Records[0].Values[0];

                            anchorItemContent.appendChild(anchorItemContentHeader);
                            anchorItemContent.appendChild(anchorItemContentDescription);

                            const anchorItemIconContainer = document.createElement('div');
                            anchorItemIconContainer.classList.add('contain-the-icon');

                            const anchorItemIcon = document.createElement('div');
                            anchorItemIcon.classList.add('material-icons');
                            anchorItemIcon.innerHTML = 'chevron_right';

                            anchorItemIconContainer.appendChild(anchorItemIcon);

                            anchorItem.appendChild(anchorItemContent);
                            anchorItem.appendChild(anchorItemIconContainer);

                            listItem.appendChild(anchorItem);

                            menuDropdownList.appendChild(listItem);
                        });

                        listElement.appendChild(menuDropdownList);
                        menuUl.appendChild(listElement);
                    }

                    menuButton.addEventListener('click', function () {
                        const dropDown = document.getElementById('dropdown-header-menu');
                        if (dropDown.style.display == 'none') {
                            dropDown.style.display = 'block';
                        } else {
                            dropDown.style.display = 'none';
                        }
                        console.log('hei', dropDown.style.display)
                    });
                } catch (err) {
                    console.error("failed at headermenu", err)
                }
            })
            .catch((err) => {
                console.error("failed obtaining headermenu")
            })
    } catch {
        console.error("error in headermenu")
    }
}

function $(id) {
    if (id[0] == ".") {
        return document.getElementsByClassName(id.substring(1));
    } else if (id[0] == "#") {
        return document.getElementById(id.substring(1));
    }
    return document.getElementById(id);
}