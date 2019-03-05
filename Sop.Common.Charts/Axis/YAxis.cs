

using System.Collections.Generic;
using Sop.Common.Charts.CommonDefinitions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sop.Common.Charts.ValueTypes;
using Sop.Common.Charts.Axis;
using Sop.Common.Charts.CommonDefinitions;

namespace Sop.Common.Charts.Axis
{
    /// <summary>
    ///     直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
    /// </summary>
    public class YAxis
    {
        /// <summary>
        ///     x 轴的位置。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public YAxisPosition Position { get; set; }

        /// <summary>
        ///     坐标轴类型。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AxisTypes Type { get; set; }

        /// <summary>
        ///     坐标轴名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     坐标轴名称显示位置。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public NameLocations NameLocation { get; set; }

        /// <summary>
        ///     类目数据，在类目轴（type: 'category'）中有效。
        /// </summary>
        public List<object> Data { get; set; }

        /// <summary>
        ///     坐标轴刻度标签的相关设置。
        /// </summary>
        public Label AxisLabel { get; set; }

        /// <summary>
        /// 坐标轴刻度最大值，在类目轴中无效。
        /// 可以设置成特殊值 'dataMax'，此时取数据在该轴上的最大值作为最大刻度。
        /// 不设置时会自动计算最大值保证坐标轴刻度的均匀分布。
        /// </summary>
        public INumberOrStringValue Max { get; set; }

        /// <summary>
        /// y 轴所在的 grid 的索引，默认位于第一个 grid。
        /// </summary>
        public double? GridIndex { get; set; }

        /// <summary>
        /// 是否是反向坐标轴。ECharts 3 中新加。
        /// </summary>

        public bool? Inverse { get; set; }
    }
}