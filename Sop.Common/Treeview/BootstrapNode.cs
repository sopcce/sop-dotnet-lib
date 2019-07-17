using System;
using System.Collections.Generic;
using System.Text;

namespace Sop.Common.Treeview
{
    [Serializable]
    public class BootstrapNode
    { 
        public virtual string Id { get; set; }
        /// <summary>
        /// 列表树节点上的文本，通常是节点右边的小图标。
        /// </summary> 
        public virtual string Text { get; set; }
        /// <summary>
        /// 列表树节点上的图标，通常是节点左边的图标。
        /// </summary>
        public virtual string Icon { get; set; }
        /// <summary>
        /// 当某个节点被选择后显示的图标，通常是节点左边的图标。
        /// </summary> 
        public virtual string SelectedIcon { get; set; }
        /// <summary>
        /// 结合全局enableLinks选项为列表树节点指定URL。
        /// </summary>
        public virtual string Href { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool Selectable { get; set; } = true;
        /// <summary>
        /// 状态
        /// </summary>
        public virtual State State { get; set; }
        /// <summary>
        /// 节点的前景色，覆盖全局的前景色选项。
        /// </summary>
        public virtual string Color { get; set; }
        /// <summary>
        /// 节点的背景色，覆盖全局的背景色选项。
        /// </summary>

        public virtual string BackColor { get; set; }
        /// <summary>
        /// 通过结合全局showTags选项来在列表树节点的右边添加额外的信息。
        /// </summary>

        public virtual string[] Tags { get; set; }


        public virtual List<BootstrapNode> Nodes { get; set; } 
    }
}
