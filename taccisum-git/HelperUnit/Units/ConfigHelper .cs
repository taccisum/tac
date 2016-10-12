using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tool.Units
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 从app.config中获取指定配置项的值，不存在则返回空字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
