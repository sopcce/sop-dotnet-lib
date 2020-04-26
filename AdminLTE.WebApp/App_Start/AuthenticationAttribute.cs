using System;
using System.Web;
using System.Web.Mvc;

namespace WebApp
{ 

    public class AuthenticationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            //如果控制器没有加AllowAnonymous特性或者Action没有加AllowAnonymous特性才检查
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //此处写判断是否登录的逻辑代码
                HttpCookie cookie = filterContext.HttpContext.Request.Cookies["Member"];
                if (!(cookie != null && cookie.Values["name"] == "test" && cookie.Values["pass"] == "123"))
                {
                    filterContext.Result = new RedirectResult("/Member/Login");
                }
            }
        }
    }
}