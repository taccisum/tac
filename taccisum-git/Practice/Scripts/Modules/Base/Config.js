/**
 * @author tac
 * @desc requireJS配置及常用模块路径
 * @date 16/09/05
 */

(function () {
    //path
    var base = "Base/";
    var common = "Common/";
    var wrapper = "Common/Wrapper/";
    var scripts = "../";

    require.config({
        baseUrl: "/Scripts/Modules",
        paths: {
            //public
            "base": base + "BaseModule",
            "mockdata": common + "mockdata",
            "sidebar": "ViewJs/Shared/Sidebar",
            "systools": common + "systools",
            "systools-plus": common + "systools-plus",
            "auto_tips": common + "auto_tips",



            //private
            "jquery": scripts + "jQuery/jquery-2.2.3", //这里定义jquery是为了给其它jquery插件的amd加载提供依赖，jquery.js不通过requirejs而是直接通过标签加载
            "jq_ext": common + "jq_extend",
            "js_ext": common + "js_extend",
            "global": common + "global",
            "mockjs": scripts + "MockJS/mock",
            "composite": scripts + "CommonClass/composite",
            "list": scripts + "CommonClass/list",

            //wrapper
            "w_datatables": wrapper + "datatables",
            "w_art_dialog": wrapper + "artDialog",
            "w_jq_ac": wrapper + "jq_autocomplete",
            "w_gridster": wrapper + "gridster",
            "w_jcrop": wrapper + "jcrop",
            "w_tipsy": wrapper + "tipsy_wrapper",
            "w_shade": wrapper + "myshade",
            //plugins
            "jq_ui": "../../css/ace/js/jquery-ui-1.10.3.full.min",
            "datatables": scripts + "jQueryPlugins/Datatables/jquery.dataTables",
            "artDialog": scripts + "jQueryPlugins/artDialog/dist/dialog-plus",
            "gridster": scripts + "jQueryPlugins/gridster/jquery.gridster",
            "jcrop": scripts + "jQueryPlugins/Jcrop/js/jquery.Jcrop",
            "tipsy": scripts + "jQueryPlugins/tipsy/javascripts/jquery.tipsy",
        },
        shim: {
            //为一些非amd规范的js提供依赖
            "jq_ui": "jquery",
            "tipsy": "jquery",
            "w_jq_ac": "jq_ui",
            "w_jcrop": "jcrop",
            "w_tipsy": "tipsy"
        }
    });
})();
