using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using Practice.App_Start;
using Practice.Mef;

namespace Practice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            #region Log4Net Config
#if DEBUG
            var fl = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
#else
            var fl = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net-release.config");
#endif
            if (!fl.Exists)
            {
                throw new IOException(fl.DirectoryName + "，log4net配置文件未找到");
            }
            log4net.Config.XmlConfigurator.ConfigureAndWatch(fl);
            #endregion

            var log = LogManager.GetLogger("System.AppStart");
            log.Info("应用程序开始运行");
            log.Info("加载Log4Net配置完成");

            #region RegistryConfig
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            log.Info("注册MVC配置完成");
            #endregion
            
            #region MefSolver
            DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            MefDependencySolver solver = new MefDependencySolver(catalog);
            DependencyResolver.SetResolver(solver);
            log.Info("注册Mef依赖解析完成");
            #endregion
        }

    }
}
