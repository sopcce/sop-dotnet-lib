

using Sop.Common.Charts.CommonDefinitions;
using Sop.Common.Charts.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     垂直对齐值
    /// </summary>
    [JsonConverter(typeof(ValueConverter<VerticalAlign>))]
    public class VerticalAlignValue : ITopValue, IValue<VerticalAlign>
    {
        public VerticalAlignValue(VerticalAlign value)
        {
            Value = value;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public VerticalAlign Value { get; set; }
    }
}