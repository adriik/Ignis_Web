using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Controllers
{
    public class GeneralController : Controller
    {
        // GET: General
        public ActionResult Start()
        {
            TempData["Previous"] = this.Url.Action("Start", "General", null, this.Request.Url.Scheme);
            return View();
        }
    }
}