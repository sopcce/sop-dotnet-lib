

using Sop.Common.Charts.CommonDefinitions;
using Sop.Common.Charts.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     标记的图形
    /// </summary>
    [JsonConverter(typeof(ValueConverter<Symbols>))]
    public class SymbolValue : ISymbolValue, IValue<Symbols>
    {
        public SymbolValue(Symbols value)
        {
            Value = value;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public Symbols Value { get; set; }
    }
}