using Sop.Common.Charts.Axis;
using Sop.Common.Charts.Components;
using Sop.Common.Charts.Components.Legend;
using Sop.Common.Charts.Components.TimeLine;
using Sop.Common.Charts.Components.ToolTip;
using System.Collections.Generic;

namespace Sop.Common.Charts
{
    /// <summary>
    ///     EChart相关配置
    /// </summary>
    public class EChartsOption
    {
        /// <summary>
        ///     标题组件
        /// </summary>
        public Title Title { get; set; }

        /// <summary>
        ///     是否启用拖拽重计算特性，默认关闭
        /// </summary>
        public bool Calculable { get; set; }

        /// <summary>
        ///     提示框组件
        /// </summary>
        public Tooltip Tooltip { get; set; }

        /// <summary>
        ///     工具箱 每个图表仅有一个
        /// </summary>
        public ToolBox Toolbox { get; set; }

        /// <summary>
        ///     timeline 组件，提供了在多个 ECharts option 间进行切换、播放等操作的功能。
        /// </summary>
        public TimeLine Timeline { get; set; }

        /// <summary>
        ///     图例组件
        /// </summary>
        public Legend Legend { get; set; }

        /// <summary>
        ///     直角坐标系 grid 中的 x 轴，单个 grid 组件最多只能放上下两个 x 轴。
        /// </summary>
        public XAxis[] XAxis { get; set; }

        /// <summary>
        ///     直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
        /// </summary>
        public YAxis[] YAxis { get; set; }

        /// <summary>
        ///     系列列表
        /// </summary>
        public Series.Series[] Series { get; set; }
        /// <summary>
        /// dataZoom 组件 用于区域缩放，从而能自由关注细节的数据信息，或者概览数据整体，或者去除离群点的影响。
        /// </summary>
        public List<DataZoom> DataZoom { get; set; }

        /// <summary>
        /// 网格组件列表
        /// </summary>
        public List<Grid> Grid { get; set; }
    }
}