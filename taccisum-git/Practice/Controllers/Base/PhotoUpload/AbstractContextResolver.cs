using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload
{
    internal abstract class AbstractContextResolver
    {
        public abstract PhotoUploadContext Resolve();
    }
}