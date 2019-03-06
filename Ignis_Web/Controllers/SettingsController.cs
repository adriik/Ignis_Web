using Ignis_Web.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Controllers
{
    public class SettingsController : Controller
    {
        string Dungeon;
        WspAccess wspAccess = new WspAccess();

        // GET: Settings
        public ActionResult IBP()
        {
            if (Session["user"] != null)
            {
                Dungeon = "IBP";
                ViewBag.Title = "Współczynniki " + Dungeon;
                Wsp wspolczynnik = wspAccess.GetWsp(Dungeon);
                if (wspolczynnik != null)
                    return View(wspolczynnik);
                else
                {
                    return View();
                }
            }
            else
            {
                TempData["Previous"] = Request.Url.ToString();
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Login",
                });
            }
        }

        [HttpPost]
        public ActionResult IBP(Wsp wspolczynnik)
        {
            Dungeon = "IBP";
            SetWsp(Dungeon);
            return View();
        }

        public ActionResult SToES()
        {
            if (Session["user"] != null)
            {
                Dungeon = "SToES";
                ViewBag.Title = "Współczynniki " + Dungeon;
                Wsp wspolczynnik = wspAccess.GetWsp(Dungeon);
                if (wspolczynnik != null)
                    return View(wspolczynnik);
                else
                {
                    return View();
                }
            }
            else
            {
                TempData["Previous"] = Request.Url.ToString();
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Login",
                });
            }
        }

        [HttpPost]
        public ActionResult SToES(Wsp wspolczynnik)
        {
            Dungeon = "SToES";
            SetWsp(Dungeon);
            return View();
        }

        public void SetWsp(string dung)
        {
            TempData["Walidator"] = wspAccess.SimpleSetWsp(dung);
        }
    }
}