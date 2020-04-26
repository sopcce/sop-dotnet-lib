using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace WebApp
{
    public class FormsAuthentications
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool SignOn(string username)
        {
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(username, true);

            HttpContext.Current.Response.Cookies.Remove(authCookie.Name);
            HttpContext.Current.Response.Cookies.Add(authCookie);
            return true;
        }

        /// <summary>
        /// 登出
        /// </summary>
        public static void LogOut()
        {
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName);
            //使cookie强制过期
            authCookie.Expires = DateTime.Now.AddYears(-30);
            authCookie.Path = HttpContext.Current.Request.ApplicationPath;

            HttpContext.Current.Response.Cookies.Add(authCookie);
            //退出登录后执行页面重定向到主页操作
        }

        /// <summary>
        /// 获取登录用户名部分代码，AuthenticationMoudel类中的UserName属性
        /// </summary>
        public static string UserName
        {
            get
            {
                var httpContext = HttpContext.Current;
                if (httpContext != null &&
                    httpContext.Request.IsAuthenticated)
                {
                    try
                    {
                        return httpContext.User.Identity.Name;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 执行用户登录操作
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="userData">与登录名相关的用户信息</param>
        /// <param name="expiration">登录Cookie的过期时间，单位：分钟。</param>
        public static void SignIn(string loginName, TUserData userData, int expiration)
        {
            if (string.IsNullOrEmpty(loginName))
                throw new ArgumentNullException("loginName");
            if (userData == null)
                throw new ArgumentNullException("userData");

            // 1. 把需要保存的用户数据转成一个字符串。
            string data = null;
            if (userData != null)
                data = (new JavaScriptSerializer()).Serialize(userData);


            // 2. 创建一个FormsAuthenticationTicket，它包含登录名以及额外的用户数据。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, loginName, DateTime.Now, DateTime.Now.AddDays(1), true, data);


            // 3. 加密Ticket，变成一个加密的字符串。
            string cookieValue = FormsAuthentication.Encrypt(ticket);


            // 4. 根据加密结果创建登录Cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (expiration > 0)
                cookie.Expires = DateTime.Now.AddMinutes(expiration);

            HttpContext context = HttpContext.Current;
            if (context == null)
                throw new InvalidOperationException();

            // 5. 写登录Cookie
            context.Response.Cookies.Remove(cookie.Name);
            context.Response.Cookies.Add(cookie);
        }
    }

    public class TUserData
    {
        public string UserId { get; set; }
    }
}