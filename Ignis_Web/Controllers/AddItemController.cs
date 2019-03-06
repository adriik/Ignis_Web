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
        private ItemAccess itemAccess = new ItemAccess();
        private WspAccess wspAccess = new WspAccess();
        // GET: AddItem
        public ActionResult AddItem()
        {
            if (Session["user"] != null)
            {
                var TypyItemów = itemAccess.GetTypyItemow();
                var lista = itemAccess.GetListaLudzi();

                ViewBag.ListaLudzi = lista.ToSelectList(x => x.Nickname, false);
                ViewBag.Typy = TypyItemów.ToSelectList(x => x.typyDropu, false);
                ViewBag.ItemList = GetItemsSelectList();
                return View();
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
        public SelectList GetItemsSelectList()
        {
            return new SelectList(NazwyDropu.GetItems(), "Id", "Name", "Category", 0);
        }
        [HttpPost]
        public ActionResult AddItem(Itemki itemki, NazwyDropu nazwy, item username)
        {
            //Instancje
            var IBP_Dungeon = itemki.checkIBP;
            var SToES_Dungeon = itemki.checkSToES;
            string Dungeon = "";
            //Sprawdzenie czy instancja zostala wybrana i jaka zostala wybrana.
            if (IBP_Dungeon == false && SToES_Dungeon == false)
            {
                TempData["Dungeon"] = false;
                return RedirectToAction("AddItem");
            }
            if (IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if (SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }
            //Pobieranie danych ze strony
            var FirstItemType = itemki.Drop_Type1;
            var FirstItemID = itemki.Item_Drop1;
            var FirstItemDura = itemki.Item_Dura1;
            var FirstItemReceiver = itemki.Drop_Receiver1;
            var FirstItemSet = itemki.Item_Set1;

            if (string.IsNullOrEmpty(FirstItemType))
            {
                TempData["ItemType"] = false;
                return RedirectToAction("AddItem");
            }
            if (string.IsNullOrEmpty(FirstItemID))
            {
                TempData["ItemName"] = false;
                return RedirectToAction("AddItem");
            }
            if (FirstItemType == "Item" && FirstItemDura == 0)
            {
                TempData["ItemDura"] = false;
                return RedirectToAction("AddItem");
            }
            if (string.IsNullOrEmpty(FirstItemReceiver))
            {
                TempData["ItemReceiver"] = false;
                return RedirectToAction("AddItem");
            }

            if (FirstItemType == "Stat")
            {
                itemAccess.SetFirstItemStat(itemki,nazwy,username);

                TempData["FreqSucc"] = false;
                TempData["Wybrana_Instancja"] = Dungeon;
                return RedirectToAction("Przeliczenia_Wszystkich_Stat", "AddItem");
            }
            if (FirstItemType == "Item")
            {
                if (FirstItemDura <= 100)
                {
                    TempData["ItemLD"] = false;
                    return RedirectToAction("AddItem");
                }

                itemAccess.SetFirstItemItem(itemki, nazwy, username);

                if (FirstItemSet == true)
                {
                    TempData["FreqSucc"] = false;
                    return RedirectToAction("AddItem", "AddItem");
                }
                else
                {
                    TempData["FreqSucc"] = false;
                    return RedirectToAction("AddItem", "AddItem");
                }
            }

            return RedirectToAction("AddItem", "AddItem");
        }

        public ActionResult Przeliczenia_Wszystkich_Stat(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();

            wspAccess.SetStat(username, dungeonName);
            
            return RedirectToAction("Przeliczenia_WSP", "AddItem");
        }

        public ActionResult Przeliczenia_WSP(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetWsp(username, dungeonName);
            
            return RedirectToAction("Przeliczenia_Rank_StaHpred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaHpred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankStaHpred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_StaWisred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaWisred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankStaWisred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_StaPattred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaPattred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankRankStaPattred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_StrPattred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StrPattred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankStrPattred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_DexPattred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_DexPattred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankDexPattred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_IntMattred", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_IntMattred(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankIntMattred(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_IntMatt", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_IntMatt(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankIntMatt(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_StrPatt", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StrPatt(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankStrPatt(username, dungeonName);
            return RedirectToAction("Przeliczenia_Rank_DexPatt", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_DexPatt(item username)
        {
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            wspAccess.SetRankDexPatt(username, dungeonName);
            return RedirectToAction("AddItem", "AddItem");
        }
    }
}