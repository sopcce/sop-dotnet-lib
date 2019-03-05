using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sop.Common.Charts
{

   





    #region Axis 直角坐标系 grid 中的轴的相关配置封装，比如x轴、y轴等。

    #region AxisTypes 坐标轴类型
    /// <summary>
    /// 坐标轴类型
    /// </summary>
    public enum AxisTypes
    {
        /// <summary>
        ///     数值轴，适用于连续数据。
        /// </summary>
        Value,

        /// <summary>
        ///     类目轴，适用于离散的类目数据，为该类型时必须通过 data 设置类目数据。
        /// </summary>
        Category,

        /// <summary>
        ///     时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
        /// </summary>
        Time,

        /// <summary>
        ///     对数轴。适用于对数数据。
        /// </summary>
        Log
    }
    #endregion

    #region LineStyleTypes 坐标轴线线的类型
    /// <summary>
    /// 坐标轴线线的类型。
    /// </summary>
    public enum LineStyleTypes
    {
        /// <summary>
        /// 实线
        /// </summary>
        Solid,
        /// <summary>
        /// 虚线
        /// </summary>
        Dashed,
        /// <summary>
        /// 斑点
        /// </summary>
        Dotted
    }
    #endregion

    #region NameLocations 坐标轴名称显示位置

    /// <summary>
    ///  坐标轴名称显示位置。
    /// </summary>
    public enum NameLocations
    {
        End,
        Start,
        Middle
    }
    #endregion

    #region XAxisPosition  x 轴的位置
    /// <summary>
    ///   x 轴的位置
    /// </summary>
    public enum XAxisPosition
    {
        Bottom,
        Top
    }
    #endregion

    #region  YAxisPosition  y 轴的位置
    /// <summary>
    ///     y 轴的位置。默认 grid 中的第一个 y 轴在 grid 的左侧（'left'），第二个 y 轴视第一个 y 轴的位置放在另一侧。
    /// </summary>
    public enum YAxisPosition
    {
        Left,
        Right
    }
    #endregion

    #endregion


    #region CommonDefinitions 通用定义：Align、TextStyles、VerticalAlign、Label、Orients、Symbols、TextAlign




    #region TextAlign 标题文本水平对齐 
    /// <summary>
    /// 指定窗口打开主标题超链接。
    /// </summary>
    public enum Target
    {
        Self,
        Blank

    }
    /// <summary>
    ///     标题文本水平对齐
    /// </summary>
    public enum TextAlign
    {
        Left,
        Center,
        Right
    }
    #endregion

    #region Align 水平对齐 
    /// <summary>
    ///     水平对齐
    /// </summary>
    public enum Align
    {
        Left,
        Center,
        Right,
       
    }
    #endregion

    #region VerticalAlign 垂直对齐
    /// <summary>
    /// 垂直对齐
    /// </summary>
    public enum VerticalAlign
    {
        Top,
        Middle,
        Bottom
    }
    #endregion

    #region Orients 图例列表的布局朝向
    /// <summary>
    ///     图例列表的布局朝向
    /// </summary>
    public enum Orients
    {
        Horizontal,
        Vertical
    }
  


    #endregion

    #region Symbols 标记的图形
    /// <summary>
    ///     标记的图形。
    /// </summary>
    public enum Symbols
    {
        Pin,
        Circle,
        Rect,
        RoundRect,
        Triangle,
        Diamond,
        Arrow
    }
    #endregion




    #endregion






    #region Components 组件定义：DataZoom、DataZoomInside、DataZoomSlider、Grid、Legend、TimeLine、Title、ToolBox、ToolTip

    #region Legend
    public enum LegendType
    {
        /// <summary>
        /// 普通图例。缺省就是普通图例。
        /// </summary>
        Plain,
        /// <summary>
        /// 可滚动翻页的图例。当图例数量较多时可以使用。
        /// </summary>
        Scroll
    }
    public enum LegendAlign
    {
        Auto,
        Left,
        Right
    } 
    #endregion


    /// <summary>
    ///     表示『播放』按钮的位置。可选值：'left'、'right'。
    /// </summary>
    public enum ControlPositions
    {
        Left,
        Right
    }
    #region TimeLineTypes TimeLine类型
    /// <summary>
    ///     TimeLine类型
    /// </summary>
    public enum TimeLineTypes
    {
        Slider
    }
    #endregion

    #region TooltipTriggerTypes 提示框组件触发类型
    /// <summary>
    /// 提示框组件触发类型
    /// </summary>
    public enum TooltipTriggerTypes
    {
        /// <summary>
        ///     数据项图形触发，主要在散点图，饼图等无类目轴的图表中使用。
        /// </summary>
        Item,
        /// <summary>
        ///     坐标轴触发，主要在柱状图，折线图等会使用类目轴的图表中使用。
        /// </summary>
        Axis
    }
    #endregion

    /// <summary>
    ///     提示框组件触发事件
    /// </summary>
    public enum TooltipTriggerEvents
    {
        /// <summary>
        ///     鼠标移动时触发。
        /// </summary>
        mousemove,

        /// <summary>
        ///     鼠标点击时触发。
        /// </summary>
        click
    }


    #endregion

    #region Series 每个系列通过 Type 决定自己的图表类型

    #region SeriesTypes
    /*ECharts 
     * 提供了常规的折线图、柱状图、散点图、饼图、K线图，
     * 用于统计的盒形图，
     * 用于地理数据可视化的地图、热力图、线图，
     * 用于关系数据可视化的关系图、treemap、旭日图，多维数据可视化的平行坐标，
     * 用于 BI 的漏斗图，仪表盘，并且支持图与图之间的混搭。*/
    // <summary>
    ///   图表类型
    /// </summary>
    public enum SeriesTypes
    {
        /// <summary>
        ///     折线图/面积图
        /// </summary>
        Line,

        /// <summary>
        ///     柱状/条形图
        /// </summary>
        Bar,

        /// <summary>
        ///     饼图
        /// </summary>
        Pie,

        /// <summary>
        ///     散点（气泡）图
        /// </summary>
        Scatter,

        /// <summary>
        ///     带有涟漪特效动画的散点（气泡）图。利用动画特效可以将某些想要突出的数据进行视觉突出。
        /// </summary>
        EffectScatter,

        /// <summary>
        ///     雷达图
        /// </summary>
        Radar,

        /// <summary>
        ///     Treemap 是一种常见的表达『层级数据』『树状数据』的可视化形式。它主要用面积的方式，便于突出展现出『树』的各层级中重要的节点。
        /// </summary>
        Treemap,

        /// <summary>
        ///     『箱形图』、『盒须图』、『盒式图』、『盒状图』、『箱线图』
        /// </summary>
        Boxplot,

        /// <summary>
        ///     K线图
        /// </summary>
        Candlestick,

        /// <summary>
        ///     热力图
        /// </summary>
        heatmap,

        /// <summary>
        ///     地图。
        /// </summary>
        Map,

        /// <summary>
        ///     平行坐标系（Parallel Coordinates）
        /// </summary>
        Parallel,

        /// <summary>
        ///     线图
        /// </summary>
        Lines,

        /// <summary>
        ///     关系图
        /// </summary>
        Graph,

        /// <summary>
        ///     桑基图
        /// </summary>
        Sankey,

        /// <summary>
        ///     漏斗图
        /// </summary>
        Funnel,

        /// <summary>
        ///     仪表盘
        /// </summary>
        Gauge
    }
    #endregion


    /// <summary>
    ///     特殊的标注类型，用于标注最大值最小值等。
    /// </summary>
    public enum MarkPointDataTypes
    {
        /// <summary>
        ///     最小值
        /// </summary>
        min,

        /// <summary>
        ///     最大值
        /// </summary>
        max,

        /// <summary>
        ///     平均值
        /// </summary>
        average
    }
    #endregion

    /// <summary>
    /// 初始动画的缓动效果 不同的缓动效果可以参考 缓动示例:
    /// https://www.echartsjs.com/gallery/editor.html?c=line-easing。
    /// </summary>
    public enum AnimationEasing
    {
        linear,
        quadraticIn,
        quadraticOut,
        quadraticInOut,
        cubicIn,
        cubicOut,
        cubicInOut,
        quarticIn,
        quarticOut,
        quarticInOut,
        quinticIn,
        quinticOut,
        quinticInOut,
        sinusoidalIn,
        sinusoidalOut,
        sinusoidalInOut,
        exponentialIn,
        exponentialOut,
        exponentialInOut,
        circularIn,
        circularOut,
        circularInOut,
        elasticIn,
        elasticOut,
        elasticInOut,
        /// <summary>
        /// 在某一动画开始沿指示的路径进行动画处理前稍稍收回该动画的移动
        /// </summary>
        backIn,
        backOut,
        backInOut,
        bounceIn,
        bounceOut,
        bounceInOut
    }










}
