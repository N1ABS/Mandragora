using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mandragora.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Қолданбаңыздың сипаттамасы беті.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Сіздің байланыс бетіңіз.";

            return View();
        }
    }
}