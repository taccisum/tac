using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Tool.Units
{
    public static class SessionHelper
    {
        public static object Get(string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static object Set(string key, object value)
        {
            return HttpContext.Current.Session[key] = value;
        }

        public static void Remove(string key)
        {
            HttpContext.Current.Session[key] = null;
        }
    }
}
