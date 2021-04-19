using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularProject.Models;

namespace AngularProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public JsonResult getrecord() 
        {
            using (ResearchDBEntities db=new ResearchDBEntities())
            {
                var listreg = db.tbl_Status.ToList();
                return Json(listreg, JsonRequestBehavior.AllowGet);
            }

        }
    }
}