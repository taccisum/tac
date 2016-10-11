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
    public class UrlReferrerPatternConverter : HttpRequestPatternConverter
    {
        protected override void HttpConvert(TextWriter writer, LoggingEvent loggingEvent, HttpContext currentContext)
        {
            writer.Write(currentContext.Request.UrlReferrer);
        }
    }
}
