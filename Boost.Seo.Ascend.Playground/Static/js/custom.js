var customAlloy = customAlloy || {};

(function (window, $) {
    'use strict';

    $(function () {
        customAlloy.init();
    });

    customAlloy = {
        $document: $(document),

        init: function () {
            customAlloy.clickEvents();
        },
        
        clickEvents: function () {
            customAlloy.$document.on('click', '.js-show-more', function (e) {
                var $this = $(this);
                e.preventDefault();

                var url = $this.data('url'),
                    languageCode = $this.data('language-code'),
                    nextPage = $this.data('next-page'),
                    contentGuid = $this.data('content-guid');

                $.ajax({
                    type: 'GET',
                    data: {
                        contentGuid: contentGuid,
                        languageCode: languageCode,
                        nextPage: nextPage
                    },
                    url: url,
                    dataType: 'html',
                    success: function (data) {
                        if (data != null && data.length > 0) {
                            $this.replaceWith(data);
                        }
                    },
                    error: function () {
                        console.error('More items could not be loaded.');
                    }
                });
            });

            customAlloy.$document.on('click', '.js-show-more-chunk', function (e) {
                var $this = $(this);
                e.preventDefault();

                var url = $this.data('url'),
                    segmentTypeId = $this.data('segment-type-id'),
                    pageNumber = $this.data('page-number'),
                    currentLanguage = $this.data('current-language'),
                    searchText = $this.data('search-text');

                $.ajax({
                    type: 'GET',
                    data: {
                        segmentTypeId: segmentTypeId,
                        pageNumber: pageNumber,
                        currentLanguage: currentLanguage,
                        searchText: searchText
                    },
                    url: url,
                    dataType: 'html',
                    success: function (data) {
                        if (data != null && data.length > 0) {
                            $this.parent().replaceWith(data);
                        }
                    },
                    error: function () {
                        console.error('More items could not be loaded.');
                    }
                });
            });
        }
    };

})(this, jQuery);