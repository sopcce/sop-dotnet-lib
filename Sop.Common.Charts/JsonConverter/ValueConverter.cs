

using System;
using Sop.Common.Charts.ValueTypes;
using Newtonsoft.Json;
using System.Text;

namespace Sop.Common.Charts.JsonConverter
{
    public class ValueConverter<T> : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var iv = value as IValue<T>;
            if (iv == null) return;
            //如果是字符串数组
            if (iv.Value is double[])
            {
                var values = iv.Value as double[];
                writer.WriteStartArray();
                foreach (var item in values)
                {
                    writer.WriteValue(item);
                }
                writer.WriteEndArray();
                return;
            }
            writer.WriteValue(iv.Value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var obj = Activator.CreateInstance(objectType) as IValue<T>;
            obj.Value = (T)reader.Value;
            return obj;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IValue<T>);
        }
    }
}