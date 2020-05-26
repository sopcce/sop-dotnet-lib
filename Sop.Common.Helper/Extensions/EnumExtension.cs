using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace System
{
    // <summary>
    /// 枚举类扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举项上设置的显示Display文字
        /// </summary>
        /// <param name="value">被扩展对象</param>
        public static string ToDisplayName(this Enum value)
        {
            var attribute = value.GetType().GetField(Enum.GetName(value.GetType(), value)).GetCustomAttributes(
                 typeof(DisplayAttribute), false)
                 .Cast<DisplayAttribute>()
                 .FirstOrDefault();
            if (attribute != null)
            {
                return attribute.Name;
            }

            return Enum.GetName(value.GetType(), value);
        }


        /// <summary>
        /// 获取枚举项上设置的显示Description文字
        /// </summary>
        /// <param name="enumSubitem">枚举</param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumSubitem, int index)
        {
            string text = enumSubitem.ToString();
            System.Reflection.FieldInfo field = enumSubitem.GetType().GetField(text);
            object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string result;
            if (customAttributes.Length == 0)
            {
                result = text;
            }
            else
            {
                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)customAttributes[0];
                result = descriptionAttribute.Description.Split(new char[]
                {
                    '|'
                })[index];
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumSubitem"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum enumSubitem)
        {
            string text = enumSubitem.ToString();
            System.Reflection.FieldInfo field = enumSubitem.GetType().GetField(text);
            object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string result;
            if (customAttributes.Length == 0)
            {
                result = text;
            }
            else
            {
                DescriptionAttribute descriptionAttribute = (DescriptionAttribute)customAttributes[0];
                result = descriptionAttribute.Description;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumDescription"></param>
        /// <param name="filed"></param>
        /// <returns></returns>
        public static bool ToEnumValue<TEnum>(this string enumDescription, ref TEnum filed)
        {
            bool result = false;
            System.Type typeFromHandle = typeof(TEnum);
            System.Reflection.FieldInfo[] fields = typeFromHandle.GetFields();
            for (int i = 1; i < fields.Length - 1; i++)
            {
                if (fields[i].GetCustomAttributes(typeof(DescriptionAttribute), false)[0] is DescriptionAttribute descriptionAttribute && descriptionAttribute.Description.Contains(enumDescription))
                {
                    filed = (TEnum)((object)fields[i].GetValue(typeof(TEnum)));
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
 
}