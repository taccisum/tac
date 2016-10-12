using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Tool.Extend.Log4Net.PatternConverter;

namespace Common.Tool.Extend.Log4Net.PatternLayout
{
    public class TacPatternLayout: log4net.Layout.PatternLayout
    {
        public TacPatternLayout() : base()
        {
            //todo:: here extend pattern layout
            AddConverter("client_ip", typeof(ClientIpPatternConverter));
            AddConverter("browser", typeof(BrowserPatternConverter));
            AddConverter("agent", typeof(UserAgentPatternConverter));
            AddConverter("url", typeof(UrlPatternConverter));
            AddConverter("url_referrer", typeof(UrlReferrerPatternConverter));
            AddConverter("session_id", typeof(SessionIdPatternConverter));
        }
    }
}
