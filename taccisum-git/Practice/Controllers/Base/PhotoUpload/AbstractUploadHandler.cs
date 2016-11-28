using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Practice.Controllers.Base.PhotoUpload
{
    /// <summary>
    /// TODO::返回值
    /// </summary>
    internal abstract class AbstractUploadHandler
    {
        public PhotoUploadResult Upload(PhotoUploadContext context)
        {
            if (BeforeOperation(context))
            {
                var result = OnUpload(OnCut(context));
                AfterOperation(context);

                return result;
            }
            else
            {
                return null;
            }
        }


        protected virtual bool BeforeOperation(PhotoUploadContext context)
        {
            throw new NotImplementedException();
        }

        protected abstract List<Image> OnCut(PhotoUploadContext context);
        protected abstract PhotoUploadResult OnUpload(List<Image> imgs);

        protected virtual void AfterOperation(PhotoUploadContext context)
        {
            throw new NotImplementedException();
        }

    }
}