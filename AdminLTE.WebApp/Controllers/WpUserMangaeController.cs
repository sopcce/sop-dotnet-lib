using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class WpUserMangaeController : Controller
    {
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns> 
        public ActionResult UserListIndex()
        {
            return View();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public ActionResult UserEditIndex()
        {
            return View();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectTeamCostIndex()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public ActionResult UserAttendanceIndex()
        {
            return View();
        }







        // GET: ManageMent
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManageMent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ManageMent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManageMent/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageMent/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManageMent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManageMent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManageMent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
