using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string RemoveHtml(this string strHtml)
        {
            var regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            strHtml = regex.Replace(strHtml, "");
            strHtml = strHtml.Replace("&nbsp;", "");
            return strHtml;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string RemoveHtmlStyle(this string strHtml)
        {
            var regex = new Regex(@"\s[^<>]*>");
            strHtml = regex.Replace(strHtml, ">");

            regex = new Regex("<img.+?>");
            strHtml = regex.Replace(strHtml, "");


            return strHtml;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Trim() == "[]" || str.Trim() == "null")
                {
                    return true;
                }
            }
            return string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsCommaNumber(this string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Trim() == "[]" || str.Trim() == "null")
                {
                    return false;
                }
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                return new Regex(@"^(\d+,?)+$").Match(str).Success;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempValue"></param>
        /// <returns></returns>
        public static int IsBoolStringToInt(this string tempValue)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tempValue))
                {
                    return 0;
                }
                if (tempValue == "1" || tempValue.ToLower() == "true")
                {
                    return 1;
                }
                else if (tempValue == "0" || tempValue.ToLower() == "false")
                {
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return 0;



        }
        /// <summary>
        /// 存在转int  不存在 0
        /// </summary>
        /// <param name="str"></param>
        /// <returns>0 或者原来的int</returns>
        public static int IsStringToInt(this string str)
        {
            int result = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return result;
                }
                if (int.TryParse(str, out result))
                {
                    return result;
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}
