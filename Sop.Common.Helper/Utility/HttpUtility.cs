using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace Sop.Common.Helper.Utility
{
    public class HttpUtility
    {
        /// <summary>
        ///  发送POST 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonData"></param> 
        /// <returns></returns>
        public static string Post(string url, string jsonData)
        {
            url = (url.IndexOf("http://", StringComparison.Ordinal) > -1 || url.IndexOf("https://", StringComparison.Ordinal) > -1) ? url : "http://" + url;
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                httpWebRequest.ServicePoint.Expect100Continue = true;
                httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
                httpWebRequest.ServicePoint.ConnectionLimit = int.MaxValue;
                httpWebRequest.AllowWriteStreamBuffering = false;
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36";
                httpWebRequest.Accept =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
                httpWebRequest.ContentType = "application/json;charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Timeout = 1000 * 60 * 5;
                byte[] data = Encoding.UTF8.GetBytes(jsonData);
                httpWebRequest.ContentLength = data.Length;
                using (Stream reqStream = httpWebRequest.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }

                List<byte> lst = new List<byte>();
                int nRead = 0;
                string strHtml = string.Empty;
                using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {

                    // 判断是否重定向  Ambiguous 300  Found 302  Moved 301
                    if (httpWebResponse.StatusCode == HttpStatusCode.Ambiguous ||
                        httpWebResponse.StatusCode == HttpStatusCode.Found ||
                        httpWebResponse.StatusCode == HttpStatusCode.Moved)
                    {
                        string newUrl = httpWebResponse.Headers["Location"];//获取重定向的网址
                        if (!string.IsNullOrEmpty(newUrl))
                        {
                            httpWebResponse.Close();
                            return Post(newUrl, jsonData);
                        }
                    }
                    if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                    {

                        if (httpWebResponse.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
                        {
                            using (System.IO.Stream streamReceive = httpWebResponse.GetResponseStream())
                            {
                                using (var stream = new GZipStream(streamReceive, CompressionMode.Decompress))
                                {
                                    while ((nRead = stream.ReadByte()) != -1) lst.Add((byte)nRead);
                                    byte[] byHtml = lst.ToArray();
                                    strHtml = Encoding.UTF8.GetString(byHtml, 0, byHtml.Length);
                                }
                            }
                        }
                        else if (httpWebResponse.ContentEncoding.ToLower().Contains("deflate"))//解压
                        {
                            using (Stream streamReceive = httpWebResponse.GetResponseStream())
                            {
                                using (var stream = new DeflateStream(streamReceive, CompressionMode.Decompress))
                                {

                                    while ((nRead = stream.ReadByte()) != -1) lst.Add((byte)nRead);
                                    byte[] byHtml = lst.ToArray();
                                    strHtml = Encoding.UTF8.GetString(byHtml, 0, byHtml.Length);
                                }
                            }
                        }
                        else
                        {
                            using (Stream stream = httpWebResponse.GetResponseStream())
                            {
                                while (stream != null && (nRead = stream.ReadByte()) != -1) lst.Add((byte)nRead);
                                byte[] byHtml = lst.ToArray();
                                strHtml = Encoding.UTF8.GetString(byHtml, 0, byHtml.Length);
                            }
                        }
                    }
                    httpWebResponse.Close();
                }
                return strHtml;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
