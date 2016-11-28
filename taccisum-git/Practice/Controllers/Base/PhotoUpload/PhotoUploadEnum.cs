using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload
{
    internal enum PhotoHandler
    {
        Default,
        Product,
        Service,
        Groupon
    }

    internal enum ContextResolver
    {
        Default,
    }

    /// <summary>
    /// TODO::
    /// </summary>
    internal static class PhotoHandlerExtendForInteger
    {
        public static PhotoHandler ConvertToPhotoHandler(this int type)
        {
            throw new NotImplementedException();
        }
    }
}