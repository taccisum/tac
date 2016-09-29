using System;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Entity;

namespace Model.Entities.Layout
{
    [Table("dbo.LayoutWidget")]
    public class WidgetModel : DTO
    {
        /// <summary>
        /// Widgets关联的LayoutId
        /// </summary>
        public Guid LayoutId { get; set; }

        /// <summary>
        /// todo:: widget名称，保留字段，未使用
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模块编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public string ExtData { get; set; }

        /// <summary>
        /// x坐标（即第CoordX列）
        /// </summary>
        public int CoordX { get; set; }
        /// <summary>
        /// y坐标（即第CoordY行）
        /// </summary>
        public int CoordY { get; set; }
        /// <summary>
        /// 宽，单位：列数
        /// </summary>
        public int SizeCol { get; set; }
        /// <summary>
        /// 高，单位：行数
        /// </summary>
        public int SizeRow { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// widget显示内容
        /// </summary>
        public string Body { get; set; }


        public WidgetModel UpdateTo(WidgetModel model)
        {
            this.Name = model.Name;
            this.Code = model.Code;
            this.ExtData = model.ExtData;
            this.CoordX = model.CoordX;
            this.CoordY = model.CoordY;
            this.SizeCol = model.SizeCol;
            this.SizeRow = model.SizeRow;
            this.Color = model.Color;
            this.Body = model.Body;
            return this;
        }
    }
}
