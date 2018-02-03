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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (Session["user"]!= null)
            //{
                var lista = new List<Czlonek>();
                NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
                cn.Open();
                string QueryPeople = "SELECT public.\"People\".\"Nickname\" FROM public.\"People\"";
                using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Czlonek(reader.GetString(0)));
                        }
                    }
                }
                ViewBag.People = lista;
                cn.Close();

                return View();
            //}
            //else
            //{
            //    return RedirectToRoute(new
            //    {
            //        controller = "Account",
            //        action = "Login",
            //    });
            //}
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