﻿define(["jquery", "systools"], function ($, tool) {
    var icons =
    [
        "icon-adjust", "icon-asterisk", "icon-ban-circle", "icon-bar-chart", "icon-barcode", "icon-beaker", "icon-beer",
        "icon-bell", "icon-bell-alt", "icon-bolt", "icon-book", "icon-bookmark", "icon-bookmark-empty", "icon-briefcase",
        "icon-bullhorn", "icon-calendar", "icon-camera", "icon-camera-retro", "icon-certificate", "icon-check", "icon-check-empty",
        "icon-circle", "icon-circle-blank", "icon-cloud", "icon-cloud-download", "icon-cloud-upload", "icon-coffee", "icon-cog",
        "icon-cogs", "icon-comment", "icon-comment-alt", "icon-comments", "icon-comments-alt", "icon-credit-card", "icon-dashboard",
        "icon-desktop", "icon-download", "icon-download-alt", "icon-edit", "icon-envelope", "icon-envelope-alt", "icon-exchange",
        "icon-exclamation-sign", "icon-external-link", "icon-eye-close", "icon-eye-open", "icon-facetime-video", "icon-fighter-jet",
        "icon-film", "icon-filter", "icon-fire", "icon-flag", "icon-folder-close", "icon-folder-open", "icon-folder-close-alt",
        "icon-folder-open-alt", "icon-food", "icon-gift", "icon-glass", "icon-globe", "icon-group", "icon-hdd", "icon-headphones",
        "icon-heart", "icon-heart-empty", "icon-home", "icon-inbox", "icon-info-sign", "icon-key", "icon-leaf", "icon-laptop",
        "icon-legal", "icon-lemon", "icon-lightbulb", "icon-lock", "icon-unlock", "icon-magic", "icon-magnet", "icon-map-marker",
        "icon-minus", "icon-minus-sign", "icon-mobile-phone", "icon-money", "icon-move", "icon-music", "icon-off", "icon-ok",
        "icon-ok-circle", "icon-ok-sign", "icon-pencil", "icon-picture", "icon-plane", "icon-plus", "icon-plus-sign", "icon-print",
        "icon-pushpin", "icon-qrcode", "icon-question-sign", "icon-quote-left", "icon-quote-right", "icon-random", "icon-refresh",
        "icon-remove", "icon-remove-circle", "icon-remove-sign", "icon-reorder", "icon-reply", "icon-resize-horizontal",
        "icon-resize-vertical", "icon-retweet", "icon-road", "icon-rss", "icon-screenshot", "icon-search", "icon-share", "icon-share-alt",
        "icon-shopping-cart", "icon-signal", "icon-signin", "icon-signout", "icon-sitemap", "icon-sort", "icon-sort-down", "icon-sort-up",
        "icon-spinner", "icon-star", "icon-star-empty", "icon-star-half", "icon-tablet", "icon-tag", "icon-tags", "icon-tasks",
        "icon-thumbs-down", "icon-thumbs-up", "icon-time", "icon-tint", "icon-trash", "icon-trophy", "icon-truck", "icon-umbrella",
        "icon-upload", "icon-upload-alt", "icon-user", "icon-user-md", "icon-volume-off", "icon-volume-down", "icon-volume-up",
        "icon-warning-sign", "icon-wrench", "icon-zoom-in", "icon-zoom-out", "icon-file", "icon-file-alt", "icon-cut", "icon-copy",
        "icon-paste", "icon-save", "icon-undo", "icon-repeat", "icon-text-height", "icon-text-width", "icon-align-left", "icon-align-center",
        "icon-align-right", "icon-align-justify", "icon-indent-left", "icon-indent-right", "icon-font", "icon-bold", "icon-italic",
        "icon-strikethrough", "icon-underline", "icon-link", "icon-paper-clip", "icon-columns", "icon-table", "icon-th-large", "icon-th",
        "icon-th-list", "icon-list", "icon-list-ol", "icon-list-ul", "icon-list-alt", "icon-angle-left", "icon-angle-right", "icon-angle-up",
        "icon-angle-down", "icon-arrow-down", "icon-arrow-left", "icon-arrow-right", "icon-arrow-up", "icon-caret-down", "icon-caret-left",
        "icon-caret-right", "icon-caret-up", "icon-chevron-down", "icon-chevron-left", "icon-chevron-right", "icon-chevron-up",
        "icon-circle-arrow-down", "icon-circle-arrow-left", "icon-circle-arrow-right", "icon-circle-arrow-up", "icon-double-angle-left",
        "icon-double-angle-right", "icon-double-angle-up", "icon-double-angle-down", "icon-hand-down", "icon-hand-left", "icon-hand-right",
        "icon-hand-up", "icon-circle", "icon-circle-blank", "icon-play-circle", "icon-play", "icon-pause", "icon-stop", "icon-step-backward",
        "icon-fast-backward", "icon-backward", "icon-forward", "icon-fast-forward", "icon-step-forward", "icon-eject", "icon-fullscreen",
        "icon-resize-full", "icon-resize-small", "icon-phone", "icon-phone-sign", "icon-facebook", "icon-facebook-sign", "icon-twitter",
        "icon-twitter-sign", "icon-github", "icon-github-alt", "icon-github-sign", "icon-linkedin", "icon-linkedin-sign", "icon-pinterest",
        "icon-pinterest-sign", "icon-google-plus", "icon-google-plus-sign", "icon-sign-blank", "icon-ambulance", "icon-beaker", "icon-h-sign",
        "icon-hospital", "icon-medkit", "icon-plus-sign-alt", "icon-stethoscope", "icon-user-md"
    ];

    return {
        bind: function (selector) {
            var $target;
            var d_api;
            if (typeof selector == "string") {
                $target = $(selector);
            } else {
                $target = selector;
            }
            $target.css("cursor", "pointer");
            var $content = $("<div style='max-height:300px;'></div>");
            $.each(icons, function(index, item) {
                var $icon = $("<a style='color:gray; margin:3px; cursor:pointer;' data-icon='" + item + "' href='javascript: void(0);' class='" + item + "'></a>");
                $icon.hover(function() {
                    $target.val($icon.data("icon"));
                });
                $icon.on("click", function () {
                    $target.val($icon.data("icon"));
                    d_api.close();
                });
                $content.append($icon);
            });

            var id = $.newPseudoGuid();
            $target.on("click", function () {
                d_api = tool.dialog({
                    id: id,
                    title: "",
                    content: $content,
                    width: 500,
                    quickClose: true,
                });
                d_api.show(this);
            });
        }
    }
})