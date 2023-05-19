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
    element.style['margin-top'] = '20px';
    element.style.padding = '0';
    const elementClone = element.parentElement.parentElement.cloneNode(true);
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

const updateTaxonLink = (linkElement) => {
    const imageLastElementHrefArray = linkElement.href.split('/taxon');
    imageLastElementHrefArray[0] = adbLink;
    linkElement.href = imageLastElementHrefArray.join('/taxon');
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

                Array.prototype.forEach.call(images, (el, index) => {
                    if (index > 3) return;

                    const imageText = el.parentElement.parentElement.children[1].children;
                    const imageFirstElements = imageText[0].children[0].children;
                    const imageLastElement = imageText[2];

                    updateTaxonLink(imageLastElement);
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
