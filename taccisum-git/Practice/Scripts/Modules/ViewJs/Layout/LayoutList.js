


define(["systools-plus", "ViewJs/Layout/LayoutManager/LayoutManagerCreater"], function (tool, mc) {
    var table_layout = "#table_layout";

    var m = {
        init: function() {
            $.get("/Layout/GetLayoutList", function (result) {
                if (result.Success) {
                    var _vm = ko.mapping.fromJS({
                        layout_list: result.Data,
                        adjust: function (vm, event) {
                            //todo::
                            alert(vm.Id());
                        },
                        alter: function (vm, event) {
                            var manager = mc.factory(ko.mapping.toJS(vm));
                            manager.popup();
                        }
                    });
                    ko.applyBindings(_vm, $(table_layout)[0]);
                }
            });
        },
    }

    return m;
})