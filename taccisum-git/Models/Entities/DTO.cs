using System;

namespace Model.Entity
{
    /// <summary>
    /// 数据传输对象（所有Entity的基类）
    /// </summary>
    public class DTO
    {
        /// <summary>
        /// 数据条目ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// 是否删除（逻辑删除）
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// 创建者人
        /// </summary>
        public Guid CreatedBy { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        public Guid? ModifiedBy { get; set; }
    }
}