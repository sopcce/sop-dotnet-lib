using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sop.Common.Serialization.Json
{

  /// <summary>  
  /// Newtonsoft.Json序列化扩展特性  
  /// <para>DateTime序列化（输出为时间戳）</para>  
  /// </summary>  
  /// <summary>  
  /// Newtonsoft.Json序列化扩展特性  
  /// <para>DateTime序列化（输出为时间戳）</para>  
  /// </summary>  
  public class TimestampConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      return objectType == typeof(DateTime);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      return ConvertIntDateTime(long.Parse(reader.Value.ToString()));
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteValue(ConvertDateTimeInt((DateTime)value));
    }

    public static DateTime ConvertIntDateTime(long aSeconds)
    {
      return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(aSeconds);
    }

    public static long ConvertDateTimeInt(DateTime date)
    {
      return (long)(date - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
    }
  }

}
