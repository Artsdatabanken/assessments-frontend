// Get species images from taxon pages

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
                // Max 4 images
                if (index > 3) {
                    return;
                }
                const imageElements = el.parentElement.parentElement.children[1].children[0].children[0].children;
                Array.prototype.forEach.call(imageElements, (imgElement) => {
                    if (imgElement.tagName != 'IMG') {
                        return;
                    }
                    const srcArray = imgElement.src.split('/Content')
                    srcArray[0] = 'https://artsdatabanken.no';
                    imgElement.src = srcArray.join('/Content');
                    imgElement.style.width = '25px';
                    imgElement.style.background = 'transparent';
                    imgElement.style['vertical-align'] = 'text-bottom';
                })
                const datasetSrc = el.dataset.src;
                el.style = "";
                el.alt = "Bilde av arten";
                el.src = datasetSrc;
                el.dataset.src = '';
                el.style.height = 'auto';
                el.style.width = '200px';
                el.style['margin-top'] = '20px';
                el.style.padding = '0';
                targetElement.appendChild(el.parentElement.parentElement);
            });
        })
        .catch(() => {
            return;
        })
});

console.log(taxonPagesUrls);