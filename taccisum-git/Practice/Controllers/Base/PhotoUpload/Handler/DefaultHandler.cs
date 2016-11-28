using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload.Handler
{
    internal class DefaultHandler: AbstractUploadHandler
    {
        protected override List<System.Drawing.Image> OnCut(PhotoUploadContext context)
        {
            throw new NotImplementedException();
        }

        protected override PhotoUploadResult OnUpload(List<System.Drawing.Image> imgs)
        {
            throw new NotImplementedException();
        }
    }
}