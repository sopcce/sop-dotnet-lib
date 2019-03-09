

using System.Collections.Generic;

namespace Sop.Common.Charts
{
    /// <summary>
    ///     timeline配置项
    ///     timeline 和其他组件有些不同，它需要操作『多个option』  
    /// </summary>
    public class TimelineOptions
    {
        /// <summary>
        ///     baseOption 是一个 『原子option』，options 数组中的每一项也是一个 『原子option』。
        /// </summary>
        public EChartsOption BaseOption { get; set; }

        /// <summary>
        /// </summary>
        public List<EChartsOption> Options { get; set; }
    }
}