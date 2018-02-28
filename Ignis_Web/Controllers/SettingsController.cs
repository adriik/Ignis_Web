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

        // GET: Settings
        public ActionResult IBP()
        {
            Dungeon = "IBP";
            ViewBag.Title = "Współczynniki " + Dungeon;
            Wsp wspolczynnik = GetWsp(Dungeon);
            if (wspolczynnik != null)
                return View(wspolczynnik);
            else
            {
                return View();
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
            Dungeon = "SToES";
            ViewBag.Title = "Współczynniki " + Dungeon;
            Wsp wspolczynnik = GetWsp(Dungeon);
            if (wspolczynnik != null)
                return View(wspolczynnik);
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SToES(Wsp wspolczynnik)
        {
            Dungeon = "SToES";
            SetWsp(Dungeon);
            return View();
        }

        public Wsp GetWsp(string dung)
        {
            Wsp wspolczynnik = new Wsp();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string wsp = "SELECT * FROM public.\"WSP_" + Dungeon + "\"";
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(wsp, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == "Boss1_Multi")
                            {
                                wspolczynnik.Boss1 = reader.GetDouble(1);
                            }
                            else if (reader.GetString(0) == "Boss2_Multi")
                            {
                                wspolczynnik.Boss2 = reader.GetDouble(1);
                            }
                            else if (reader.GetString(0) == "Boss3_Multi")
                            {
                                wspolczynnik.Boss3 = reader.GetDouble(1);
                            }
                            else if (reader.GetString(0) == "Boss4_Multi")
                            {
                                wspolczynnik.Boss4 = reader.GetDouble(1);
                            }
                            else if (reader.GetString(0) == "Boss5_Multi")
                            {
                                wspolczynnik.Boss5 = reader.GetDouble(1);
                            }
                        }
                    }
                }
                cn.Close();
            }
            catch (NpgsqlException)
            {
                return null;
            }

            return wspolczynnik;
        }

        public void SetWsp(string dung)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            Wsp wspolczynnik = new Wsp();

            try
            {
                NpgsqlCommand update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss1 + "'" + " WHERE \"WSP_Name\" = 'Boss1_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss2 + "'" + " WHERE \"WSP_Name\" = 'Boss2_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss3 + "'" + " WHERE \"WSP_Name\" = 'Boss3_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss4 + "'" + " WHERE \"WSP_Name\" = 'Boss4_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss5 + "'" + " WHERE \"WSP_Name\" = 'Boss5_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();
                TempData["Walidator"] = true;
            }
            catch (NpgsqlException)
            {
                TempData["Walidator"] = false;
            }
            cn.Close();
        }
    }
}