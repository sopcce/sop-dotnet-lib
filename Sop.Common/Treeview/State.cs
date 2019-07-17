using System;
using System.Collections.Generic;
using System.Text;

namespace Sop.Common.Treeview
{
    /// <summary>
    /// 一个节点的初始状态。
    /// </summary>
    public class State
    {
        /// <summary>
        ///指示一个节点是否处于checked状态，用一个checkbox图标表示。
        /// </summary>
        /// <value>
        ///   <c>true</c> if checked; otherwise, <c>false</c>.
        /// </value>
        public bool Checked { get; set; } = false;
        /// <summary>
        /// 指示一个节点是否处于disabled状态。（不是selectable，expandable或checkable）
        /// </summary>
        public bool Disabled { get; set; } = false;
        /// <summary>
        /// 指示一个节点是否处于展开状态 
        /// </summary> 
        public bool Expanded { get; set; } = false;
        /// <summary>
        /// 指示一个节点是否可以被选择。
        /// </summary>

        public bool Selected { get; set; } = false;

    }
}
