/**
 * @author tac
 * @date 16/09/08
 * @desc 系统前端工具模块扩展，用于引入一些不常用的系统工具（如：图片上传工具、html编程器等）。
 * 引入本模块的目的主要是为了减少一些不必要（对于大多数页面来说）的js的加载以提高页面加载速度。
 * @important tips 参考systools.js
 */
define(["systools"], function (tool) {
    var toolExt = {

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
        }
    };

    return $.extend(tool, toolExt);
});