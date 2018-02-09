using Ignis_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using System.Configuration;

namespace Ignis_Web.Controllers
{
    public class AddItemController : Controller
    {
        // GET: AddItem
        public ActionResult AddItem()
        {
            var TypyItemów = new List<Itemki>();
            //s = s[0].ToUpper() + s.Substring(1);
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryTyp = "SELECT public.\"DropType\".\"Typ\" FROM public.\"DropType\"";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryTyp, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TypyItemów.Add(new Itemki(reader.GetString(0)));
                    }
                }
            }

            var lista = new List<item>();
            //s = s[0].ToUpper() + s.Substring(1);
            string QueryPeople = "SELECT public.\"People\".\"Nickname\" FROM public.\"People\"";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new item(reader.GetString(0)));
                    }
                }
            }
            ViewBag.ListaLudzi = lista.ToSelectList(x => x.Nickname, false);
            ViewBag.Typy = TypyItemów.ToSelectList(x => x.typyDropu, false);
            cn.Close();
            ViewBag.ItemList = GetItemsSelectList();
            return View();
        }
        public SelectList GetItemsSelectList()
        {
            return new SelectList(NazwyDropu.GetItems(), "Id", "Name", "Category", 1);
        }
        [HttpPost]
        public ActionResult AddItem(Itemki itemki, NazwyDropu nazwy, item username)
        {
            
            return RedirectToAction("", "AddItem");
        }
    }

}