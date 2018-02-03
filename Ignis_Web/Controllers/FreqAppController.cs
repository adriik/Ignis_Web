using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ignis_Web.Models;
using Npgsql;

namespace Ignis_Web.Controllers
{
    public class FreqAppController : Controller
    {
        // GET: FreqApp
        public ActionResult FreqAppka()
        {
            if (Session["user"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Login",
                });
            }
        }


        }
}