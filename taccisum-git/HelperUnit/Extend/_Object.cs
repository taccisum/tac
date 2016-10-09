using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common.Tool.Extend
{
    public static class _Object
    {
        public static bool IsNull(this object o)
        {
            return o == null;
        }

        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
