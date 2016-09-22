using System;

namespace Common.CustomerException
{
    /// <summary>
    /// todo:: 这个异常可能要适当改写
    /// </summary>
    public class CommonException : ApplicationException
    {
        public object Data { get; private set; }

        public CommonException(string msg, object data = null) : base(message: msg)
        {
            Data = data;
        }
    }
}
