using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using log4net.Core;

namespace Common.Tool.Extend.Log4Net.PatternConverter
{
    public class ClientIpPatternConverter : HttpRequestPatternConverter
    {
        protected override void HttpConvert(TextWriter writer, LoggingEvent loggingEvent, HttpContext currentContext)
        {
            var request = currentContext.Request;
            string ip;
            if (!string.IsNullOrWhiteSpace(request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
            {
                ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
            }
            else
            {
                ip = request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = request.UserHostAddress;
            }
            writer.Write(ip);
        }

        protected override void ConvertIfContextNull(TextWriter writer, LoggingEvent loggingEvent, HttpContext currentContext)
        {
            writer.Write("::1");
        }
    }
}
