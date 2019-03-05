using Sop.Common.Charts.Axis;
using Sop.Common.Charts.Components;
using Sop.Common.Charts.Components.TimeLine;
using Sop.Common.Charts.Components.ToolTip;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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


        //[JsonConverter(typeof(StringEnumConverter))]
        //public Orients Orient { get; set; }



        /// <summary>
        /// 是否开启动画。
        /// </summary>
        public bool animation { get; set; } = true;
        /// <summary>
        /// 是否开启动画的阈值，当单个系列显示的图形数量大于这个阈值时会关闭动画。
        /// </summary>
        public int animationThreshold { get; set; } = 2000;

        /// <summary>
        /// 初始动画的时长，支持回调函数，可以通过每个数据返回不同的 delay 时间实现更戏剧的初始动画效果：
        /// <code>
        /// animationDuration: function (idx) {
        ///    // 越往后的数据延迟越大
        ///    return idx * 100;
        ///}
        /// </code>
        /// </summary>
        public int animationDuration { get; set; } = 1000;
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AnimationEasing animationEasing { get; set; }

        public int animationDelay { get; set; }

        /// <summary>
        /// 图形的混合模式，不同的混合模式见 https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation 。
        /// 默认为 'source-over'。 支持每个系列单独设置。
        ///    'lighter' 也是比较常见的一种混合模式，该模式下图形数量集中的区域会颜色叠加成高亮度的颜色（白色）。常常能起到突出该区域的效果。见示例  https://www.echartsjs.com/gallery/editor.html?c=lines-airline
        /// </summary>
        public int blendMode { get; set; }

        /// <summary>
        /// 图形数量阈值，决定是否开启单独的 hover 层，在整个图表的图形数量大于该阈值时开启单独的 hover 层。
        /// </summary>
        public int? HoverLayerThreshold { get; set; } = 3000;




        ///  <summary>
        ///  是否使用 UTC 时间。
        ///  <see>
        ///      <cref>
        ///          是否使用 UTC 时间。
        ///          true: 表示 axis.type 为 &apos;time&apos; 时，依据 UTC 时间确定 tick 位置，并且 axisLabel 和 tooltip 默认展示的是 UTC 时间。
        ///          false: 表示 axis.type 为 &apos;time&apos; 时，依据本地时间确定 tick 位置，并且 axisLabel 和 tooltip 默认展示的是本地时间。
        ///          默认取值为false，即使用本地时间。因为考虑到：
        ///          很多情况下，需要展示为本地时间（无论服务器存储的是否为 UTC 时间）。
        ///          如果 data 中的时间为 &apos;2012-01-02&apos; 这样的没有指定时区的时间表达式，往往意为本地时间。默认情况下，时间被展示时需要和输入一致而非有时差。
        ///          注意，这个参数实际影响的是『展示』，而非用户输入的时间值的解析。 关于用户输入的时间值（例如 1491339540396, &apos;2013-01-04&apos; 等）的解析，参见 date 中时间相关部分。
        ///      </cref>
        ///  </see>
        ///  </summary>
        public bool UseUtc { get; set; } = false;
    }
}