/**
 * @author tac
 * @date 16/09/08
 * @desc 系统前端工具模块扩展，用于引入一些不常用的系统工具（如：图片上传工具、html编程器等）。
 * 引入本模块的目的主要是为了减少一些不必要（对于大多数页面来说）的js的加载以提高页面加载速度。
 * @important tips 参考systools.js
 */
define(["systools", "w_gridster"], function (tool, gridster) {
    var toolExt = {
        /**
         * @desc 弹出一个窗口，可通过拖放弹窗内生成的内容进行布局
         * @param {object} conf 详细见w_gridster模块，除了插件自带的配置参数外，还封装了以下自定义参数：
         * {string} conf.id 容器的id，默认为一个随机的guid。
         * {string} conf.cursor widget的cursor样式，默认为pointer
         * {int} conf.width dialog宽度所能容纳的列数，以一个widget的宽度为单位，超过这个宽度将出现滚动条。
         * {int} conf.height dialog高度所能容纳的行数，以一个widget的高度为单位，超过这个高度将出现滚动条。
         * {function} conf.onSubmit(data) 点击dialog的提交按钮时触发的回调事件，data为widgets序列化对象
         * @param {array} widgets数据 item必须要有3个属性：id, row, col，非必需属性sizex, sizey, color, content
         * @returns {object} Gridster实例
         */
        layout: function (conf, widgets) {
            var _outInstance;

            //private method
            /**
             * @desc 检查必要参数
             * @returns {void} 
             */
            var checkArgs = function() {
                if (!widgets) {
                    throw new Error("gridster(): arg widgets is required");
                }

                if (!conf.id) {
                    conf.id = $.newPseudoGuid();
                }
            }
            /**
             * @desc 将数据渲染成HTMLElement
             * @param {array} widgets数据
             * @returns {HTMLElement} jQuery HTMLElement
             */
            var render = function(array) {
                var _$content = $("<div id='" + conf.id + "' class='gridster'></div>");
                var $el = $("<ul></ul>");
                $el.css("list-style", "none");

                $.each(array, function (index, item) {
                    var $widget = $("<li></li");
                    $widget.attr({
                        "id": item.id,
                        "data-row": item.row,
                        "data-col": item.col,
                        "data-sizex": item.sizex || 1,
                        "data-sizey": item.sizey || 1,
                    });
                    $widget.css({
                        "background-color": item.color || "gray",
                        "cursor": conf.cursor || "pointer",
                        "opacity": 0.8
                    });
                    $widget.html(item.content || "widget");
                    $el.append($widget);
                });
                _$content.append($el);

                return _$content;
            }
            /**
             * @desc 根据参数计算弹窗尺寸
             * @param {} width 列数
             * @param {} height 行数
             * @param {} widget_margins widget的边距
             * @param {} widget_base_dimensions widget的尺寸
             * @returns {object} 计算得出的弹窗宽和高
             */
            var calc_dialog_size = function(width, height, widget_margins, widget_base_dimensions) {
                var _width;
                var _height;
                if (width) {
                    var _w = 0;
                    if (widget_margins) {
                        _w += (widget_margins[0] || 5) * 2;
                    } else {
                        _w += 5 * 2;
                    }
                    if (widget_base_dimensions) {
                        _w += widget_base_dimensions[0] || 80;
                    } else {
                        _w += 80;
                    }
                    _width = _w * width + 40; //因为设置的是dialog的宽度，所以要留出一部分padding
                }

                if (height) {
                    var _h = 0;
                    if (widget_margins) {
                        _h += (widget_margins[1] || 5) * 2;
                    } else {
                        _h += 5 * 2;
                    }
                    if (widget_base_dimensions) {
                        _h += widget_base_dimensions[1] || 80;
                    } else {
                        _h += 80;
                    }
                    _height = _h * height;
                }

                return {
                    width: _width || "",
                    height: _height || "800px"
                };
            }
            /**
             * @desc 修改一些默认参数
             * @param {object} conf 配置参数
             * @returns {void} 
             */
            var preset = function(conf) {
                if (!conf.serialize_params) {
                    conf.serialize_params = function($w, wgd) {
                        return {
                            id: $w.attr("id"),
                            col: wgd.col,
                            row: wgd.row,
                            size_x: wgd.size_x,
                            size_y: wgd.size_y,
                            color: $w.css("background-color"),
                            content: $w.text(),
                            //todo:: more info
                        }
                    }
                }
            }
            /**
             * @desc 关闭dialog时执行，垃圾清理
             * @returns {void} 
             */
            var destroy = function () {
                _outInstance.destroy();
            }

            checkArgs();
            var d_size = calc_dialog_size(conf.width, conf.height, conf.widget_margins, conf.widget_base_dimensions);
            var $content = render(widgets);
            $content.css("max-height", d_size.height); //超过此高度将出现滚动条
            preset(conf);

            tool.dialog({
                content: $content,
                width: d_size.width,
                title: "调整布局",
                button: [
                    {
                        preset: "cancel",
                        callback: function() {
                            destroy();
                            return true;
                        }
                    },
                    {
                        id: "add",
                        value: "<i class='icon-plus'></i>&nbsp;新增",
                        callback: function() {
                            alert("这里写新增的回调事件");
                            return false;
                        },
                        cls: "btn btn-info btn-sm",
                    },
                    {
                        id: "submit",
                        value: "<i class='icon-ok'></i>&nbsp;提交",
                        callback: function () {
                            var r = conf.onSubmit(_outInstance.serialize());
                            destroy();
                            return r;
                        },
                        cls: "btn btn-primary btn-sm",
                    },
                    {
                        preset: "ok",
                        callback: function() {
                            alert("预置的ok按钮回调，预置按钮不写回调默认操作关闭对话框");
                            destroy();
                            return true;
                        }
                    },
                ],
                onshow: function() {
                    gridster.selector = "#" + conf.id + " ul";
                    _outInstance = gridster.load(conf);
                }
            }).showModal();

            return _outInstance;
        },

        /**
         * @todo:: implement
         * @desc 指定一个标签，为其绑定图片裁剪功能
         * @returns {} 
         */
        cropper: function() {
            throw new Error("Method not implement");
        },

        /**
         * @todo:: implement
         * @desc 指定一个标签，以其为基础生成html编辑器
         * @returns {} 
         */
        htmlEditor: function() {
            throw new Error("Method not implement");
        },


    };

    return $.extend(tool, toolExt);
});