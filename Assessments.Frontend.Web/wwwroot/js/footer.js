var footerAddress = "342287";
var footerSome = "342288";
var footerReadmore = "341268";


// Lets pretend this is a part of the main site
function getFooter(node,place) {
    try {
        // Obtaining the relevant doi to look up.
        let url = "https://www.artsdatabanken.no/api/Content/" + node;
        fetch(url)
            .then((response) => {
                return response.json()
            })
            .then((data) => {
                try {
                    if (place === 'readmore') {                        
                        let contentList = data.Records[0].References;
                        let finalstring = '<ul class="footer-list">';
                        for (let i in contentList) {                            
                            let el = contentList[i];                            
                            let htmlstring = '<li><a href="' + el.Url + '">' + el.Title;
                            htmlstring += '</a><li>';
                            finalstring += htmlstring;
                        }
                        finalstring += '</ul>';  
                        let newplace = document.getElementById('readmore');
                        newplace.innerHTML = finalstring;

                    } else {
                    let footer = document.getElementById(place);
                    footer.innerHTML = data.Body;
                    }

                } catch (err) {
                    console.error("failed at footer")
                }
            })
            .catch((err) => {
                console.error("failed obtaining footer")
            })
    } catch {
        console.log("error in footer")
    }
}

// Startup
window.addEventListener('load', function () {
    getFooter(footerAddress, 'address');
    getFooter(footerSome, 'some');
    getFooter(footerReadmore, 'readmore');
})