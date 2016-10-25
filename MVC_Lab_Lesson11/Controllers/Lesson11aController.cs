using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Lab_Lesson11.Controllers
{
    public class Lesson11aController : Controller
    {
        [ValidateAntiForgeryToken]
        public ActionResult SomeSecurity()
        {
            ViewBag.SomeSecurityValue = "I am security value.";
            ViewBag.UserID = "USER001";
            ViewBag.Password = "pwd12345678";
            return View();
        }
    }
}