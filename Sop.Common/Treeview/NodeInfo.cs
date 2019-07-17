using System;
using System.Collections.Generic;
using System.Text;

namespace Sop.Common.Treeview
{
    public class NodeInfo
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 栏目描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public virtual int ParentId { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public virtual string ParentIdList { get; set; } = "";
        /// <summary>
        /// 子栏目数目
        /// </summary>
        public virtual int ChildCount { get; set; }
        /// <summary>
        /// 深度
        /// </summary>
        public virtual int Depth { get; set; } = 0;
        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool Enabled { get; set; } = true;
        /// <summary>
        /// 排序id
        /// </summary>
        public virtual int DisplayOrder { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime DateCreated { get; set; } = DateTime.Now;

        public virtual string Tags { get; set; }

        public virtual string Color { get; set; }
        public virtual string Url { get; set; }

        public virtual string BackColor { get; set; }

    }
}
