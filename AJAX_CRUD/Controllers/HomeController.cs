using AJAX_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAX_CRUD.Controllers
{
    public class HomeController : Controller
    {
        StudentDB db = new StudentDB();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(db.All(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(int id)
        {
            var student = db.All().Find(x => x.StudentId.Equals(id));
            return Json(student, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(Student entity)
        {
            var rs = db.Add(entity);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student entity)
        {
            var rs = db.Update(entity);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            var rs = db.Delete(id);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
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