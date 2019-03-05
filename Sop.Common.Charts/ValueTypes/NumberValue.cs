

using Sop.Common.Charts.JsonConverter;
using Newtonsoft.Json;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     数值
    /// </summary>
    [JsonConverter(typeof(ValueConverter<double>))]
    public class NumberValue : ILeftValue, ITopValue, IRightValue, IBottomValue, IValue<double>, INumberOrArrayNumberValue, INumberOrStringValue
    {
        public NumberValue(double? value = null)
        {
            if (value.HasValue)
            {
                Value = value.Value;
            }
        }
        public double Value { get; set; }
    }
}