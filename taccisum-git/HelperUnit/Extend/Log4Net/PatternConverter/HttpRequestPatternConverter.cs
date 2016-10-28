using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using log4net.Core;
using log4net.Layout.Pattern;

namespace Common.Tool.Extend.Log4Net.PatternConverter
{
    /// <summary>
    /// 扩展log4net PatternLayout，专用于记录Http请求相关信息的扩展
    /// </summary>
    public abstract class HttpRequestPatternConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            try
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    HttpConvert(writer, loggingEvent, HttpContext.Current);
                }
                else
                {
                    ConvertIfContextNull(writer, loggingEvent, HttpContext.Current);
                }
            }
            catch (HttpException) {}
        }

        protected abstract void HttpConvert(TextWriter writer, LoggingEvent loggingEvent, HttpContext currentContext);

        protected virtual void ConvertIfContextNull(TextWriter writer, LoggingEvent loggingEvent, HttpContext currentContext)
        {
            writer.Write("-");
        }
    }
}
