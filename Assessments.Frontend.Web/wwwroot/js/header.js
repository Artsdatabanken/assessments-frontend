// Startup
window.addEventListener('load', function () {
    getHeaderMenu();
})

window.addEventListener('click', function (e) {
    // Closes dropdown menu when clicking outside it. 
    if (document.getElementById('artsdatabanken-navbar-collapse')) {
        if (!document.getElementById('artsdatabanken-navbar-collapse').contains(e.target)) {
            const menuButton = document.getElementById("dropdown-header-menu-button");
            if (document.getElementById("dropdown-header-menu")) {
                document.getElementById("dropdown-header-menu").style.display = "none";
                menuButton.ariaExpanded = false;
            }
        }

        if (e.target.id == "navbar-mobile") {
            const drop = document.getElementById("artsdatabanken-navbar-collapse");
            if (drop.classList.contains('open')) {
                drop.classList.remove('open');
                menuButton.ariaExpanded = false;
            } else {
                drop.classList.add('open');
                menuButton.ariaExpanded = true;
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
                    menuButton.id = 'dropdown-header-menu-button';
                    menuButton.ariaHasPopup = true;
                    menuButton.ariaExpanded = false;
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
                        document.getElementById('artsdatabanken-navbar-collapse').appendChild(menuButton);
                        document.getElementById('artsdatabanken-navbar-collapse').appendChild(menuDiv);
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
                            appendData('artsdatabanken-navbar-collapse', spacer);
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
                        const menuButton = document.getElementById("dropdown-header-menu-button");

                        if (dropDown.style.display == 'none') {
                            dropDown.style.display = 'block';
                            dropDown.classList.add('open');
                            menuButton.ariaExpanded = true;
                        } else {
                            dropDown.style.display = 'none';
                            dropDown.classList.remove('open');
                            menuButton.ariaExpanded = false;
                        }
                    });
                } catch (err) {
                    console.error("failed at artsdatabanken-navbar-collapse", err)
                }
            })
            .catch(() => {
                console.error("failed obtaining artsdatabanken-navbar-collapse")
            })
    } catch {
        console.error("error in artsdatabanken-navbar-collapse")
    }
}
