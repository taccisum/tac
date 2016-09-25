using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CustomerException
{
    /// <summary>
    /// Service层异常
    /// </summary>
    public class ServiceLayerException : CommonException
    {
        public ServiceLayerException(string msg, object data = null) : base(msg, data)
        {
        }
    }
}
