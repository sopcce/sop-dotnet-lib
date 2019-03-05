

using Sop.Common.Charts.JsonConverter;
using Newtonsoft.Json;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     字符串值
    /// </summary>
    [JsonConverter(typeof(ValueConverter<string>))]
    public class StringValue : ILeftValue, ITopValue, IRightValue, IBottomValue, ISymbolValue, IValue<string>, INumberOrStringValue
    {
        public StringValue(string value = null)
        {
            Value = value;
        }
        public string Value { get; set; }
    }
}