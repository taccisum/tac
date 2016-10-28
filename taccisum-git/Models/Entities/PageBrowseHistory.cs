using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Model.Entities
{
    [Table("dbo.PageBrowseHistory")]
    public class PageBrowseHistory : DTO
    {
        /// <summary>
        /// 浏览页面的用户id，null表示游客
        /// </summary>
        public Guid? UserId { get; set; }
        public string UrlReferrer { get; set; }
        public bool IsAjaxRequest { get; set; }
        public string Url { get; set; }
        /// <summary>
        /// 关联的菜单id，null表示用户浏览的页面未添加到系统菜单中
        /// </summary>
        public Guid? RelativeMenuId { get; set; }
    }
}
