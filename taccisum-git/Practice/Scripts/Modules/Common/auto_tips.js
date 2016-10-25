define(["systools"], function(tool) {
    return {
        initAutoTips: function() {
            $.each($(".auto-tip[title]"), function (index, item) {
                var $item = $(item);
                tool.tip($item, {
                    gravity: $item.data("tip-gravity"),
                    offset: $item.data("tip-offset"),
                    opacity: $item.data("tip-opacity"),
                    fade: $item.data("tip-fade"),
                    delayIn: parseInt($item.data("tip-delayin")) || 500,
                    delayOut: parseInt($item.data("tip-delayout")),
                    trigger: $item.data("tip-trigger") == "focus" ? "focus" : undefined
                });
            });
        }
    }
})