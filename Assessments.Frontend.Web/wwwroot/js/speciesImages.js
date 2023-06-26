// Get species images from taxon pages

const adbLink = 'https://artsdatabanken.no';

const renderSpeciesImage = (targetElement, element) => {
    const datasetSrc = element.dataset.src;
    element.style = "";
    element.alt = "Bilde av arten";
    element.src = `${datasetSrc}?mode=350x350`;
    element.onerror = `this.src='${datasetSrc}'`;
    element.dataset.src = '';
    element.style.height = 'auto';
    element.style.width = 'auto';
    element.style['width'] = '280px';
    element.style['height'] = '280px';
    element.style.padding = '0';
    const elementClone = element.parentElement.parentElement.cloneNode(true);
    targetElement.appendChild(elementClone);
}

const updateImageMeta = (imageMeta) => {
    imageMeta[0].remove();
    Array.prototype.forEach.call(imageMeta, (imgElement) => {
        if (imgElement.tagName != 'IMG') {
            return;
        }
        const srcArray = imgElement.src.split('/Content')
        srcArray[0] = adbLink;
        imgElement.src = srcArray.join('/Content');
        imgElement.style.width = '20px';
        imgElement.style.background = 'transparent';
        imgElement.style['vertical-align'] = 'text-bottom';
    });
    imageMeta[1].style['margin-left'] = '2px';
}

const removeTaxonLink = (imageText) => {
    if (imageText.length > 1) {
        imageText[2].remove();
        imageText[1].remove();
    }
}

const renderHeader = (element) => {
    const header = document.createElement('h3');
    header.innerText = 'Bilde av arten';
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

    Array.prototype.forEach.call(taxonPagesUrls, (url, ind) => {
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

                Array.prototype.forEach.call(images, (el, index) => {
                    if (index > 0) {
                        return;
                    }

                    const imageText = el.parentElement.parentElement.children[1].children;
                    let items = Array.prototype.slice.call(imageText[0].children[0].children);
                    items.unshift(items.pop());

                    imageText[0].children[0].appendChild(items[0]);
                    imageText[0].children[0].appendChild(items[1]);
                    imageText[0].children[0].appendChild(items[2]);

                    const imageFirstElements = imageText[0].children[0].children;
                    removeTaxonLink(imageText);
                    updateImageMeta(imageFirstElements);
                    renderSpeciesImage(targetElement, el);
                });
            })
            .catch(() => {
                return;
            })
    });
}

getAssessmentImages();
