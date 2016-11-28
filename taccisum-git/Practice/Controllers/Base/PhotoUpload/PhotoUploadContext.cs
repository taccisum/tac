using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Controllers.Base.PhotoUpload
{
    internal class PhotoUploadContext
    {
        /// <summary>
        /// 待上传的图片类型
        /// </summary>
        public PhotoHandler Type { get; set; }

    }
}
