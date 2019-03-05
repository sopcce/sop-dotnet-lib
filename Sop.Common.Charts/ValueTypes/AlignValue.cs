using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sop.Common.Charts.JsonConverter;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     水平对齐值
    /// </summary>
    [JsonConverter(typeof(ValueConverter<Align>))]
    public class AlignValue : ILeftValue, IValue<Align>
    {
        public AlignValue(Align value)
        {
            Value = value;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public Align Value { get; set; }
    }
}