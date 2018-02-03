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
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Uzytkownik uzytkownik)
        {
            var username = uzytkownik.UserName;
            var password = uzytkownik.Password;
 
            string DBPassword = null;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryPeople = "SELECT \"Password\" FROM public.\"Accounts\" WHERE \"Nickname\" ='" + username + "'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DBPassword = reader.GetString(0);
                    }
                }
            }
            cn.Close();

            if (password == DBPassword)
            {
                Session["user"] = username; 
                return RedirectToRoute(new
                {
                    controller = "FreqApp",
                    action = "FreqAppka",
                });
            }
            else
            {              
                TempData["Walidator"] = false;
                return RedirectToAction("Login");
            }
        }
    }
}