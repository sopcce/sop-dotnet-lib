

using Sop.Common.Charts.CommonDefinitions;

namespace Sop.Common.Charts.Components
{
    /// <summary>
    ///     图例的数据
    /// </summary>
    public class LegendData
    {
        public LegendData(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     图形，比如circle
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        ///     文本样式
        /// </summary>
        public TextStyles TextStyle { get; set; }
    }
}