

using Newtonsoft.Json;
using Sop.Common.Charts.JsonConverter;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    ///     小数值
    /// </summary>
    [JsonConverter(typeof(ValueConverter<double>))]
    public class DoubleValue : ILeftValue, ITopValue, IRightValue, IBottomValue, IValue<double>
    {
        public double Value { get; set; }
    }
}