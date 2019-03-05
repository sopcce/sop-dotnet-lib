
using System;
using System.ComponentModel;
using Sop.Common.Charts.CommonDefinitions;
using Sop.Common.Charts.Components.ToolTip;
using Sop.Common.Charts.ValueTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Sop.Common.Charts.Components
{
    /// <summary>
    /// 图例组件(https://www.echartsjs.com/option.html#legend.zlevel) 4.0+
    /// </summary>
    public class Legend
    {
        public Legend(LegendType type = LegendType.Plain)
        {
            if (Show && type.Equals(LegendType.Scroll))
            {
                //scrollDataIndex;
            }


        }
        public object scrollDataIndex { get; }


        /// <summary>
        /// 图例的类型。 
        /// </summary> 
        [JsonConverter(typeof(StringEnumConverter))]
        public LegendType Type { get; set; }

        /// <summary>
        /// 组件 ID。默认不指定。指定则可用于在 option 或者 API 中引用组件
        /// </summary>
        public string Id { get; set; } = null;
        /// <summary>
        ///  是否显示图例组件。
        /// </summary>
        [DefaultValue(true)]
        public bool Show { get; set; } = true;

        /// <summary> 
        ///  所有图形的 zlevel 值。 [ default: 0 ], 设置为NULL不输出
        ///zlevel用于 Canvas 分层，不同zlevel值的图形会放置在不同的 Canvas 中，Canvas 分层是一种常见的优化手段。我们可以把一些图形变化频繁（例如有动画）的组件设置成一个单独的zlevel。需要注意的是过多的 Canvas 会引起内存开销的增大，在手机端上需要谨慎使用以防崩溃。 
        /// zlevel 大的 Canvas 会放在 zlevel 小的 Canvas 的上面。 
        /// </summary>
        [Obsolete("在手机端上需要谨慎使用以防崩溃。")]
        public string Zlevel { get; set; } = null;

        /// <summary>
        /// [ default: 2 ]
        //组件的所有图形的z值。控制图形的前后顺序。z值小的//图形会被z值大的图形覆盖。 
        /// z相比zlevel优先级更低，而且不会创建新的 Canvas。
        /// </summary>
        [Obsolete("建议不要使用")]
        public string Z { get; set; } = null;

        /// <summary>
        ///     图例组件离容器左侧的距离。
        ///     left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'left', 'center', 'right'。
        ///     如果 left 的值为'left', 'center', 'right'，组件会根据相应的位置自动对齐。
        /// </summary>
        public ILeftValue Left { get; set; }

        /// <summary>
        ///     图例组件离容器上侧的距离。
        ///     top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        ///     如果 top 的值为'top', 'middle', 'bottom'，组件会根据相应的位置自动对齐。
        /// </summary>
        public ITopValue Top { get; set; }

        /// <summary>
        ///     图例组件离容器右侧的距离。
        ///     right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        ///     默认自适应。
        /// </summary>
        public IRightValue Right { get; set; }

        /// <summary>
        ///     图例组件离容器下侧的距离。
        ///     bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        ///     默认自适应。
        /// </summary>
        public IBottomValue Bottom { get; set; }

        /// <summary>
        ///     图例组件的宽度。默认自适应。[ default: 'auto' ]
        /// </summary>
        public string Width { get; set; }
        /// <summary>
        /// 图例组件的高度。默认自适应。[ default: 'auto' ]
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// 图例列表的布局朝向。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Orients Orient { get; set; }
        /// <summary>
        /// 图例标记和文本的对齐。默认自动
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LegendAlign Align { get; set; }


        ////    使用字符串模板，模板变量为图例名称 {name}
        ////        formatter: 'Legend {name}'
        ////    使用回调函数
        ////    formatter: function(name)
        ////    {
        ////        return 'Legend ' + name;
        ////    }
        /// <summary>
        ///     图例文本的内容格式器，支持字符串模板和回调函数两种形式。
        ///     示例：
        /// </summary>
        public string Formatter { get; set; }

        /// <summary>
        /// 图例内边距，单位px，默认各方向内边距为5，接受数组分别设定上右下左边距。 [ default: 5 ]
        /// <code>
        /// // 设置内边距为 5
        ///padding: 5
        /// 设置上下的内边距为 5，左右的内边距为 10
        ///padding: [5, 10]
        /// 分别设置四个方向的内边距
        ///padding: [
        ///    5,  // 上
        ///    10, // 右
        ///    5,  // 下
        ///    10, // 左
        ///]</code> 
        /// </summary>

        public INumberOrArrayNumberValue Padding { get; set; }
        /// <summary>
        /// 图例每项之间的间隔。横向布局时为水平间隔，纵向布局时为纵向间隔。[ default: 10 ]
        /// </summary> 
        public int itemGap { get; set; }



        /// <summary>
        ///     图例选择的模式，默认开启图例选择，可以设成 false 关闭。
        ///     除此之外也可以设成 'single' 或者 'multiple' 使用单选或者多选模式。
        /// </summary>
        [DefaultValue(true)]
        public string SelectedMode { get; set; }

        ////示例：
        ////selected: {
        ////    // 选中'系列1'
        ////    '系列1': true,
        ////    // 不选中'系列2'
        ////    '系列2': false
        ////}
        /// <summary>
        ///     图例选中状态表。
        /// </summary>
        public object Selected { get; set; }

        //// legend: {
        ////    formatter: function(name)
        ////        {
        ////            return echarts.format.truncateText(name, 40, '14px Microsoft Yahei', '…');
        ////        },
        ////    tooltip: {
        ////        show: true
        ////    }
        ////}
        /// <summary>
        ///     图例的 tooltip 配置，配置项同 tooltip。默认不显示，可以在 legend 文字很多的时候对文字做裁剪并且开启 tooltip，如下示例：
        /// </summary>
        public Tooltip Tooltip { get; set; }

        /// <summary>
        ///     图例的数据数组。数组项通常为一个字符串，每一项代表一个系列的 name（如果是饼图，也可以是饼图单个数据的 name）。图例组件会自动获取对应系列的颜色，图形标记（symbol）作为自己绘制的颜色和标记，特殊字符串
        ///     ''（空字符串）或者 '\n' (换行字符串)用于图例的换行。
        /// </summary>
        public LegendData[] Data { get; set; }
    }


}