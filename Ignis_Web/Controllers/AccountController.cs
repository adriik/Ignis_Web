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
    public class AccountController : Controller
    {
        private UzytkownikAccess uzytkownikAccess = new UzytkownikAccess();

        // GET: Account
        public ActionResult Login()
        {
            if (TempData["Previous"] == null)
            {
                TempData["Previous"] = this.Url.Action("Start", "General", null, this.Request.Url.Scheme);
            }
            else
            {
                TempData["Previous"] = TempData["Previous"];
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(Uzytkownik uzytkownik)
        {
            if (uzytkownikAccess.IsValid(uzytkownik))
            {
                Session["user"] = uzytkownik.UserName;
                return Redirect(TempData["Previous"].ToString());
            }
            else
            {
                TempData["Walidator"] = false;
                return RedirectToAction("Login");
            }
        }
    }
}