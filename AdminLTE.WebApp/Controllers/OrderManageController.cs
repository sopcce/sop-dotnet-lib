using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OrderManageController : Controller
    {
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public ActionResult OrderManageListIndex()
        {
          
             
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderManageEditIndex()
        {
         


            FormsAuthentications.LogOut();
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}