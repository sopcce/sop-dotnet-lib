using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            FormsAuthentications.SignOn("guojiaqiu");


            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string password,string ReturnUrl)
        {
            if (ReturnUrl.IsNullOrWhiteSpace())
            {
                return Json(new { code = 200, msg = "asdasd" });

            }
            else
            {
                return Redirect(ReturnUrl);

            }
         
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}