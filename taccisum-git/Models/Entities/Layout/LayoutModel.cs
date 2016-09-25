using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;

namespace Model.Entities.Layout
{
    public class LayoutModel : DTO
    {
        /// <summary>
        /// 布局名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int Cols { get; set; }
        /// <summary>
        /// 行数
        /// </summary>
        public int Rows { get; set; }
        /// <summary>
        /// 一个1*1widget的宽度，单位：px
        /// </summary>
        public int WidgetWidth { get; set; }
        /// <summary>
        /// 一个1*1widget的高度，单位：px
        /// </summary>
        public int WidgetHeight{ get; set; }
        /// <summary>
        /// widget水平方向之间的边距，单位：px
        /// </summary>
        public int HorizontalMargin { get; set; }
        /// <summary>
        /// widget垂直方向之间的边距，单位：px
        /// </summary>
        public int VerticalMargin { get; set; }

        /// <summary>
        /// todo:: 
        /// </summary>
        [ForeignKey("ID")]
        public ICollection<WidgetModel> Widgets { get; set; }
    }
}
