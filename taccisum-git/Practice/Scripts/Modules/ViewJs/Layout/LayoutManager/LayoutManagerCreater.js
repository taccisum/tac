define(["systools-plus"], function (tool) {
    var BaseLayoutManager = function (_layout) {
        this.layout = _layout;
        this.popup = function() {
            throw new Error("popup(): method is not implement");
        };
    }

    var CommonLayoutManager = function (_layout) {
        BaseLayoutManager.call(this, _layout);

        this.popup = function() {
            var d = tool.dialog({ title: this.layout.Name, width: "200px", height: "120px" }).showModal();
            d.content("<span>ahh</span>");
        }
    }

    var appHomePageLayoutId = "9232E509-EC2E-40ED-9C7B-47EA87B48BEE";
    var AppHomePageLayoutManager = function (_layout) {
        BaseLayoutManager.call(this, _layout);

        this.popup = function() {
            var d = tool.dialog({
                title: this.layout.Name,
                width: "500px",
                height: "300px",
                content: "<input/>"
            }).showModal();

        }
    }


    var c = {
        factory: function(layout) {
            //todo:: 这里是通过id的string来创建manager的，字符串比较可能会出问题（可能是同一个guid比较出来却不相等）
            var instance;
            switch (layout.ID.toUpperCase()) {
            case appHomePageLayoutId:
                instance = new AppHomePageLayoutManager(layout);
                break;
            default:
                instance = new CommonLayoutManager(layout);
                break;
            }
            return instance;
        }
    }


    return c;
});