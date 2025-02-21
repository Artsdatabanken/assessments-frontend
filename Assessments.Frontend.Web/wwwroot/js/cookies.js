window.addEventListener('CookieInformationConsentGiven', function (event) {
    if (CookieInformation.getConsentGivenFor('cookie_cat_marketing')) {

        // Place cookie-setting script here.
        // Or some other javascript function you want to fire on consent.
        // Google Analytics tracking
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r;
            i[r] = i[r] ||
                function () {
                    (i[r].q = i[r].q || []).push(arguments);
                }, i[r].l = 1 * new Date();
            a = s.createElement(o),
                m = s.getElementsByTagName(o)[0];
            a.async = 1;
            a.src = g;
            m.parentNode.insertBefore(a, m);

        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');
    }
}, false);

window.addEventListener('CookieInformationConsentGiven', function (event) {
    if (CookieInformation.getConsentGivenFor('cookie_cat_statistic')) {

        // Place cookie-setting script here.
        // Or some other javascript function you want to fire on consent.

        // clarity
        (function (c, l, a, r, i, t, y) {
            c[a] = c[a] || function () { (c[a].q = c[a].q || []).push(arguments) };
            t = l.createElement(r); t.async = 1; t.src = "https://www.clarity.ms/tag/" + i;
            y = l.getElementsByTagName(r)[0]; y.parentNode.insertBefore(t, y);
        })(window, document, "clarity", "script", "oizcojljrc");

        // test matomo
        var _paq = window._paq = window._paq || [];
        /* tracker methods like "setCustomDimension" should be called before "trackPageView" */
        _paq.push(['trackPageView']);
        _paq.push(['enableLinkTracking']);
        (function () {
            var u = "//hoemtestmatomo.gentleplant-dc3ffafd.norwayeast.azurecontainerapps.io/";
            _paq.push(['setTrackerUrl', u + 'matomo.php']);
            _paq.push(['setSiteId', '1']);
            var d = document, g = d.createElement('script'), s = d.getElementsByTagName('script')[0];
            g.async = true; g.src = u + 'matomo.js'; s.parentNode.insertBefore(g, s);
        })();
    }
}, false);