using Practice.Controllers.Base.PhotoUpload.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload
{
    internal static class HandlerFactory
    {
        private static Dictionary<PhotoHandler, Type> _handlers = new Dictionary<PhotoHandler, Type>()
        {
            {PhotoHandler.Default, typeof(DefaultHandler)}
        };


        public static AbstractUploadHandler Create(PhotoHandler type)
        {            
            if (_handlers.ContainsKey(type))
            {
                return Activator.CreateInstance(_handlers[type]) as AbstractUploadHandler;
            }
            else
            {
                return Activator.CreateInstance(_handlers[PhotoHandler.Default]) as AbstractUploadHandler;
            }
        }
    }
}