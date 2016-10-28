using System;
using System.Web;

namespace Common.Tool.Utility
{
    public static class SessionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NullReferenceException">由于当前HttpContext为null引发的异常</exception>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            CheckNull();
            return HttpContext.Current.Session[key];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NullReferenceException">由于当前HttpContext为null引发的异常</exception>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout"></param>
        public static void Set(string key, object value, int timeout)
        {
            CheckNull();
            HttpContext.Current.Session[key] = value;
            HttpContext.Current.Session.Timeout = timeout > 0 ? timeout : 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NullReferenceException">由于当前HttpContext为null引发的异常</exception>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            CheckNull();
            HttpContext.Current.Session[key] = null;
        }

        private static void CheckNull()
        {
            if (HttpContext.Current == null)
            {
                throw new NullReferenceException("HttpContext.Current");
            }
        }
    }
}
