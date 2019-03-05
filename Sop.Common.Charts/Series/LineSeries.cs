

using Sop.Common.Charts.ValueTypes;

namespace Sop.Common.Charts.Series
{
    /// <summary>
    ///     折线/面积图
    /// </summary>
    public class LineSeries : Series
    {
        public LineSeries()
        {
            Type = SeriesTypes.line;
        }

        /// <summary>
        ///     是否平滑曲线显示。
        /// </summary>
        public bool Smooth { get; set; }

        /// <summary>
        /// 标记的大小，可以设置成诸如 10 这样单一的数字，也可以用数组分开表示宽和高，例如 [20, 10] 表示标记宽为20，高为10。
        /// </summary>
        public INumberOrArrayNumberValue SymbolSize { get; set; }

        /// <summary>
        /// 是否开启 hover 在拐点标志上的提示动画效果。
        /// </summary>
        public bool? HoverAnimation { get; set; }

        


    }
}