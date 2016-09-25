using Model.Entity;

namespace Model.Entities.Layout
{
    public class WidgetModel : DTO
    {
        /// <summary>
        /// todo:: widget名称，保留字段，未使用
        /// </summary>
        public string Name { get; set; }

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
        public string Content { get; set; }
    }
}
