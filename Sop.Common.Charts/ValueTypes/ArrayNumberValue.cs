using Newtonsoft.Json;
using Sop.Common.Charts.JsonConverter;

namespace Sop.Common.Charts.ValueTypes
{
    /// <summary>
    /// 小数数组
    /// </summary>
    [JsonConverter(typeof(ValueConverter<double[]>))]
    public class ArrayNumberValue : IValue<double[]>, INumberOrArrayNumberValue
    {
       public double[] Value { get; set; }
    }
}
