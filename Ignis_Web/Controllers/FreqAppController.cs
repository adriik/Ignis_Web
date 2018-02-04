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
                var lista = new List<appka>();
                //s = s[0].ToUpper() + s.Substring(1);
                NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
                cn.Open();
                string QueryPeople = "SELECT public.\"People\".\"Nickname\" FROM public.\"People\"";
                using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new appka(reader.GetString(0)));
                        }
                    }
                }
                ViewBag.ListaLudzi = lista.ToSelectList(x => x.Nickname, false);

                cn.Close();
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
        [HttpPost]
        public ActionResult FreqAppka(appka username)
        {
            var checkfirst = username.FirstNickname;
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + checkfirst + "'";
            NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
            int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
            temp = temp + 1;
            NpgsqlCommand update_FirstBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"First Boss\" = " + temp + " Where \"Nickname\" ='" + checkfirst + "' ");
            update_FirstBoss.Connection = cn;
            update_FirstBoss.ExecuteNonQuery();
            cn.Close();
            //return RedirectToAction("FreqApp", checkfirst);
            //return View();
            return RedirectToAction("FreqAppka", "FreqApp");
        }

    }
}