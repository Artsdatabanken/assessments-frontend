// Get species images from taxon pages

const adbLink = 'https://artsdatabanken.no';

const renderSpeciesImage = (targetElement, element) => {
    const datasetSrc = element.dataset.src;
    element.style = "";
    element.alt = "Bilde av arten";
    element.src = `${datasetSrc}?mode=320x320`;
    element.dataset.src = '';
    element.style.height = 'auto';
    element.style.width = '200px';
    element.style.padding = '0';
    const elementClone = element.parentElement.parentElement.cloneNode(true);
    elementClone.style['margin-bottom'] = '20px';
    targetElement.appendChild(elementClone);
}

const updateImageMeta = (imageMeta) => {
    Array.prototype.forEach.call(imageMeta, (imgElement) => {
        if (imgElement.tagName != 'IMG') {
            return;
        }
        const srcArray = imgElement.src.split('/Content')
        srcArray[0] = adbLink;
        imgElement.src = srcArray.join('/Content');
        imgElement.style.width = '25px';
        imgElement.style.background = 'transparent';
        imgElement.style['vertical-align'] = 'text-bottom';
    });
}

const removeTaxonLink = (imageText) => {
    imageText[2].remove();
    imageText[1].remove();
}

const renderHeader = (element) => {
    const separatorLine = document.createElement('hr');
    const header = document.createElement('h3');
    header.innerText = 'Bilder av arten';
    element.appendChild(separatorLine);
    element.appendChild(header);
}

const addLinkToTaxonPage = (element, url) => {
    const link = document.createElement('a');
    link.href = url;
    link.innerText = 'Se flere bilder av arten her';
    element.appendChild(link);
}

const getAssessmentImages = () => {
    const taxonPagesElements = document.getElementsByClassName('taxon-page-link');
    const taxonPagesUrls = Array.prototype.map.call(taxonPagesElements, (el) => {
        return el.href;
    });

    Array.prototype.forEach.call(taxonPagesUrls, (url) => {
        fetch(url)
            .then((res) => {
                return res.text();
            })
            .then((text) => {
                const parser = new DOMParser();
                const doc = parser.parseFromString(text, 'text/html');
                const images = doc.getElementsByClassName("js-lazy-taxonimage")
                const targetClassName = 'species-images-' + url.split('/').reverse()[0];
                const targetElement = document.getElementsByClassName(targetClassName)[0];

                for (let i = 0; i < images.length; i++) {
                    if (i == 0) {
                        renderHeader(targetElement);
                    }

                    if (i > 3) {
                        addLinkToTaxonPage(targetElement, url);
                        return;
                    }


                    const imageText = images[i].parentElement.parentElement.children[1].children;
                    const imageFirstElements = imageText[0].children[0].children;
                    removeTaxonLink(imageText);
                    updateImageMeta(imageFirstElements);
                    renderSpeciesImage(targetElement, images[i]);
                }
            })
            .catch(() => {
                return;
            })
    });
}

getAssessmentImages();