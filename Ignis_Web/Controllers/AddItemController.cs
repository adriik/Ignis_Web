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
            return new SelectList(NazwyDropu.GetItems(), "Id", "Name", "Category", 0);
        }
        [HttpPost]
        public ActionResult AddItem(Itemki itemki, NazwyDropu nazwy, item username)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);

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
                Dungeon = "STOES";
            }
            //Pobieranie danych ze strony
            var FirstItemType = itemki.Drop_Type1;
            var FirstItemID = itemki.Item_Drop1;
            var FirstItemDura = itemki.Item_Dura1;
            var FirstItemReceiver = itemki.Drop_Receiver1;
            var FirstItemSet = itemki.Item_Set1;

            if(string.IsNullOrEmpty(FirstItemType))
            {
                TempData["ItemType"] = false;
                return RedirectToAction("AddItem");
            }
            if (string.IsNullOrEmpty(FirstItemID))
            {
                TempData["ItemName"] = false;
                return RedirectToAction("AddItem");
            }
            if(FirstItemType == "Item" && FirstItemDura == 0)
            {
                TempData["ItemDura"] = false;
                return RedirectToAction("AddItem");
            }
            if (string.IsNullOrEmpty(FirstItemReceiver))
            {
                TempData["ItemReceiver"] = false;
                return RedirectToAction("AddItem");
            }

            if(FirstItemType == "Stat")
            {
                cn.Open();
                //Zdobywanie Nazwy Itemu bazujac na wybranym ID
                string FirstItemN = "Select \"Item\" from  public.\"" + Dungeon + "_ListaDropu" + "\" Where \"ID\" = " + FirstItemID + "";
                NpgsqlCommand checkFirstItemN = new NpgsqlCommand(FirstItemN, cn);
                string FirstItemName = checkFirstItemN.ExecuteScalar().ToString();
                //Zdobywanie Kategori Itemu bazujac na wybranym ID
                string FirstItemK = "Select \"Kategoria\" from  public.\"" + Dungeon + "_ListaDropu" + "\" Where \"ID\" = " + FirstItemID + "";
                NpgsqlCommand checkFirstItemK = new NpgsqlCommand(FirstItemK, cn);
                string FirstItemCategory = checkFirstItemK.ExecuteScalar().ToString();

                //Dodanie dropu do tabelki
                NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + FirstItemType + "', '" + FirstItemName + "','" + FirstItemReceiver + "')");
                InsertDrop.Connection = cn;
                InsertDrop.ExecuteNonQuery();

                //Wyliczenie ilosci danego statu i zaktualizowanie tej wartosci w tabelce
                string queryStr = "Select \"" + FirstItemName + "\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + FirstItemReceiver + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                temp = temp + 1;
                NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"" + FirstItemName + "\" = " + temp + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                update_Stat.Connection = cn;
                update_Stat.ExecuteNonQuery();
                cn.Close();
                TempData["FreqSucc"] = false;
                TempData["Wybrana_Instancja"] = Dungeon;
                return RedirectToAction("Przeliczenia_Wszystkich_Stat", "AddItem");
            }
            if (FirstItemType == "Item")
            {
                cn.Open();
                //Zdobywanie Nazwy Itemu bazujac na wybranym ID
                string FirstItemN = "Select \"Item\" from  public.\"" + Dungeon + "_ListaDropu" + "\" Where \"ID\" = " + FirstItemID + "";
                NpgsqlCommand checkFirstItemN = new NpgsqlCommand(FirstItemN, cn);
                string FirstItemName = checkFirstItemN.ExecuteScalar().ToString();
                //Zdobywanie Kategori Itemu bazujac na wybranym ID
                string FirstItemK = "Select \"Kategoria\" from  public.\"" + Dungeon + "_ListaDropu" + "\" Where \"ID\" = " + FirstItemID + "";
                NpgsqlCommand checkFirstItemK = new NpgsqlCommand(FirstItemK, cn);
                string FirstItemCategory = checkFirstItemK.ExecuteScalar().ToString();

                NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + FirstItemType + "', '" + FirstItemName + " " + FirstItemCategory + "','" + FirstItemReceiver + "')");
                InsertDrop.Connection = cn;
                InsertDrop.ExecuteNonQuery();
                cn.Close();

                if (FirstItemSet == true)
                {
                    if(FirstItemName == "Pas")
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Belt\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                    if (FirstItemName == "Peleryna")
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Cloak\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                    if (FirstItemName == "Rekawice")
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Gloves\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                    if (FirstItemName == "Spodnie")
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Pants\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                    if (FirstItemCategory == "Bronie")
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Weapon\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                TempData["FreqSucc"] = false;
                return RedirectToAction("AddItem", "AddItem");
            }

                return RedirectToAction("AddItem", "AddItem");
        }

        public ActionResult Przeliczenia_Wszystkich_Stat(item username)
        {
            List<int> Total_StaHp251 = new List<int>();
            List<int> Total_StaWis251 = new List<int>();
            List<int> Total_StaPatt251 = new List<int>();
            List<int> Total_StrPatt251 = new List<int>();
            List<int> Total_DexPatt251 = new List<int>();
            List<int> Total_IntMatt251 = new List<int>();
            List<int> Total_IntMatt = new List<int>();

            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }

            int totalStat_StaHp251 = 0;
            int totalStat_StaWis51 = 0;
            int totalStat_StaPatt251 = 0;
            int totalStat_StrPatt251 = 0;
            int totalStat_DexPatt251 = 0;
            int totalStat_IntMatt251 = 0;
            int totalStat_IntMatt = 0;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            //Query to calculate Total sta/hp 251 stats
            string Total_StaHp251_Query = "SELECT \"sta/hp 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaHp251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaHp251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaHp251.Count; c++)
            {

                totalStat_StaHp251 = totalStat_StaHp251 + Total_StaHp251[c];
            }
            NpgsqlCommand Update_Total_StaHp251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaHp251 + " Where \"WSP_Name\" ='sta/hp 251'");
            Update_Total_StaHp251.Connection = cn;
            Update_Total_StaHp251.ExecuteNonQuery();

            //Query to calculate Total sta/wis 251 stats
            string Total_StaWis251_Query = "SELECT \"sta/wis 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaWis251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaWis251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaWis251.Count; c++)
            {

                totalStat_StaWis51 = totalStat_StaWis51 + Total_StaWis251[c];
            }
            NpgsqlCommand Update_Total_StaWis251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaWis51 + " Where \"WSP_Name\" ='sta/wis 251'");
            Update_Total_StaWis251.Connection = cn;
            Update_Total_StaWis251.ExecuteNonQuery();

            //Query to calculate Total sta/patt 251 stats
            string Total_StaPatt251_Query = "SELECT \"sta/patt 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaPatt251.Count; c++)
            {

                totalStat_StaPatt251 = totalStat_StaPatt251 + Total_StaPatt251[c];
            }
            NpgsqlCommand Update_Total_StaPatt251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaPatt251 + " Where \"WSP_Name\" ='sta/patt 251'");
            Update_Total_StaPatt251.Connection = cn;
            Update_Total_StaPatt251.ExecuteNonQuery();

            //Query to calculate Total str/patt 251 stats
            string Total_StrPatt251_Query = "SELECT \"str/patt 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StrPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StrPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StrPatt251.Count; c++)
            {

                totalStat_StrPatt251 = totalStat_StrPatt251 + Total_StrPatt251[c];
            }
            NpgsqlCommand Update_Total_StrPatt251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StrPatt251 + " Where \"WSP_Name\" ='str/patt 251'");
            Update_Total_StrPatt251.Connection = cn;
            Update_Total_StrPatt251.ExecuteNonQuery();

            //Query to calculate Total dex/patt 251 stats
            string Total_DexPatt251_Query = "SELECT \"dex/patt 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_DexPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_DexPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_DexPatt251.Count; c++)
            {

                totalStat_DexPatt251 = totalStat_DexPatt251 + Total_DexPatt251[c];
            }
            NpgsqlCommand Update_Total_DexPatt251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_DexPatt251 + " Where \"WSP_Name\" ='dex/patt 251'");
            Update_Total_DexPatt251.Connection = cn;
            Update_Total_DexPatt251.ExecuteNonQuery();

            //Query to calculate Total int/matt 251 stats
            string Total_IntMatt251_Query = "SELECT \"int/matt 251\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMatt251.Count; c++)
            {

                totalStat_IntMatt251 = totalStat_IntMatt251 + Total_IntMatt251[c];
            }
            NpgsqlCommand Update_Total_IntMatt251 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_IntMatt251 + " Where \"WSP_Name\" ='int/matt 251'");
            Update_Total_IntMatt251.Connection = cn;
            Update_Total_IntMatt251.ExecuteNonQuery();

            //Query to calculate Total int/matt stats
            string Total_IntMatt_Query = "SELECT \"int/matt\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMatt.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMatt.Count; c++)
            {

                totalStat_IntMatt = totalStat_IntMatt + Total_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_IntMatt + " Where \"WSP_Name\" ='int/matt'");
            Update_Total_IntMatt.Connection = cn;
            Update_Total_IntMatt.ExecuteNonQuery();

            cn.Close();
            return RedirectToAction("Przeliczenia_WSP", "AddItem");
        }

        public ActionResult Przeliczenia_WSP(item username)
        {
            List<float> WSP_Data = new List<float>();
            List<float> LogGold_Data = new List<float>();
            List<float> LogStat_Data = new List<float>();

            List<float> Rank_StaHp251 = new List<float>();
            List<float> Rank_StaWis251 = new List<float>();
            List<float> Rank_StaPatt251 = new List<float>();
            List<float> Rank_StrPatt251 = new List<float>();
            List<float> Rank_DexPatt251 = new List<float>();
            List<float> Rank_IntMatt251 = new List<float>();
            List<float> Rank_IntMatt = new List<float>();
            float total_WSP = 0;
            float total_Gold = 0;
            float total_Stat = 0;

            float getRank_StaHp251 = 0;
            float getRank_StaWis251 = 0;
            float getRank_StaPatt251 = 0;
            float getRank_StrPatt251 = 0;
            float getRank_DexPatt251 = 0;
            float getRank_IntMatt251 = 0;
            float getRank_IntMatt = 0;

            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();

            //Query to calculate Total Guild Frequency
            string WSP_Query = "SELECT \"Total\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(WSP_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WSP_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < WSP_Data.Count; c++)
            {

                total_WSP = total_WSP + WSP_Data[c];
            }
            string CoqTotal = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqTotal = new NpgsqlCommand(CoqTotal, cn);
            float TotalCoq = float.Parse(getCoqTotal.ExecuteScalar().ToString());
            total_WSP = total_WSP - TotalCoq;
            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_WSP + " Where \"WSP_Name\" ='WSP'");
            cmd1.Connection = cn;
            cmd1.ExecuteNonQuery();

            //Query to calculate Total Gold_Logarithm
            string LogGold_Query = "SELECT \"Gold-Logarithm\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogGold_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogGold_Data.Add(reader.GetFloat(0));

                    }
                }
            }
            for (var c = 0; c < LogGold_Data.Count; c++)
            {

                total_Gold = total_Gold + LogGold_Data[c];
            }
            string CoqGold = "Select \"Gold-Logarithm\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqGold = new NpgsqlCommand(CoqGold, cn);
            float GoldCoq = float.Parse(getCoqGold.ExecuteScalar().ToString());
            total_Gold = total_Gold - GoldCoq;
            NpgsqlCommand Update_GoldLogarithm = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_Gold + " Where \"WSP_Name\" ='LogGold'");
            Update_GoldLogarithm.Connection = cn;
            Update_GoldLogarithm.ExecuteNonQuery();

            //Query to calculate Total Stat_Logarithm
            string LogStat_Query = "SELECT \"Stat-Logarithm\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogStat_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogStat_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < LogStat_Data.Count; c++)
            {

                total_Stat = total_Stat + LogStat_Data[c];
            }
            string CoqStat = "Select \"Stat-Logarithm\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqStat = new NpgsqlCommand(CoqStat, cn);
            float StatCoq = float.Parse(getCoqStat.ExecuteScalar().ToString());
            total_Stat = total_Stat - StatCoq;
            NpgsqlCommand Update_StatLogarithm = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_Stat + " Where \"WSP_Name\" ='LogStat'");
            Update_StatLogarithm.Connection = cn;
            Update_StatLogarithm.ExecuteNonQuery();



            //Query to calculate Total Logarithm for sta/hp 251 stats
            string Rank_StaHp251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaHp251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaHp251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaHp251.Count; c++)
            {
                getRank_StaHp251 = getRank_StaHp251 + Rank_StaHp251[c];
            }
            NpgsqlCommand Update_Total_StaHp251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaHp251 + " Where \"WSP_Name\" ='Log_sta/hp 251'");
            Update_Total_StaHp251_Log.Connection = cn;
            Update_Total_StaHp251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/wis 251 stats
            string Rank_StaWis251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaWis251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaWis251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaWis251.Count; c++)
            {
                getRank_StaWis251 = getRank_StaWis251 + Rank_StaWis251[c];
            }
            NpgsqlCommand Update_Total_StaWis251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaWis251 + " Where \"WSP_Name\" ='Log_sta/wis 251'");
            Update_Total_StaWis251_Log.Connection = cn;
            Update_Total_StaWis251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/patt 251 stats
            string Rank_StaPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaPatt251.Count; c++)
            {
                getRank_StaPatt251 = getRank_StaPatt251 + Rank_StaPatt251[c];
            }
            NpgsqlCommand Update_Total_StaPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaPatt251 + " Where \"WSP_Name\" ='Log_sta/patt 251'");
            Update_Total_StaPatt251_Log.Connection = cn;
            Update_Total_StaPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for str/patt 251 stats
            string Rank_StrPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StrPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StrPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StrPatt251.Count; c++)
            {
                getRank_StrPatt251 = getRank_StrPatt251 + Rank_StrPatt251[c];
            }
            NpgsqlCommand Update_Total_StrPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StrPatt251 + " Where \"WSP_Name\" ='Log_str/patt 251'");
            Update_Total_StrPatt251_Log.Connection = cn;
            Update_Total_StrPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for dex/patt 251 stats
            string Rank_DexPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge','Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_DexPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_DexPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_DexPatt251.Count; c++)
            {
                getRank_DexPatt251 = getRank_DexPatt251 + Rank_DexPatt251[c];
            }
            NpgsqlCommand Update_Total_DexPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_DexPatt251 + " Where \"WSP_Name\" ='Log_dex/patt 251'");
            Update_Total_DexPatt251_Log.Connection = cn;
            Update_Total_DexPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt 251 stats
            string Rank_IntMatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMatt251.Count; c++)
            {
                getRank_IntMatt251 = getRank_IntMatt251 + Rank_IntMatt251[c];
            }
            NpgsqlCommand Update_Total_IntMatt251_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_IntMatt251 + " Where \"WSP_Name\" ='Log_int/matt 251'");
            Update_Total_IntMatt251_Log.Connection = cn;
            Update_Total_IntMatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt stats
            string Rank_IntMatt_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMatt.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMatt.Count; c++)
            {
                getRank_IntMatt = getRank_IntMatt + Rank_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_IntMatt + " Where \"WSP_Name\" ='Log_int/matt'");
            Update_Total_IntMatt_Log.Connection = cn;
            Update_Total_IntMatt_Log.ExecuteNonQuery();

            cn.Close();
            return RedirectToAction("Przeliczenia_Rank_StaHp251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaHp251(item username)
        {
            List<String> PeopleForStaHP251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaHP = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaHP, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaHP251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaHP251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaHp251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/hp 251'";
                NpgsqlCommand Total_StaHp251 = new NpgsqlCommand(getTotal_StaHp251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaHp251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaHp251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/hp 251'";
                NpgsqlCommand Total_Log_StaHp251 = new NpgsqlCommand(getTotal_Log_StaHp251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaHp251.ExecuteScalar().ToString());

                string getUser_StaHp251 = "SELECT \"sta/hp 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand user_StaHP251 = new NpgsqlCommand(getUser_StaHp251, cn);
                int user_StaHp251No = Convert.ToInt32(user_StaHP251.ExecuteScalar().ToString());

                decimal newRank_StaHp251;
                if (total_Log1 == 0)
                {
                    newRank_StaHp251 = 0;
                }
                else
                {
                    newRank_StaHp251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaHp251No;
                }


                NpgsqlCommand update_UserStaHp251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank1\" = " + newRank_StaHp251 + " Where \"Nickname\" ='" + PeopleForStaHP251[i] + "' ");
                update_UserStaHp251_Log.Connection = cn;
                update_UserStaHp251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_StaWis251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaWis251(item username)
        {
            List<String> PeopleForStaWis251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaWis = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaWis, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaWis251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaWis251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaWis251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/wis 251'";
                NpgsqlCommand Total_StaWis251 = new NpgsqlCommand(getTotal_StaWis251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaWis251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaWis251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/wis 251'";
                NpgsqlCommand Total_Log_StaWis251 = new NpgsqlCommand(getTotal_Log_StaWis251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaWis251.ExecuteScalar().ToString());

                string getUser_StaWis251 = "SELECT \"sta/wis 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand user_StaWis251 = new NpgsqlCommand(getUser_StaWis251, cn);
                int user_StaWis251No = Convert.ToInt32(user_StaWis251.ExecuteScalar().ToString());

                decimal newRank_StaWis251;
                if (total_Log1 == 0)
                {
                    newRank_StaWis251 = 0;
                }
                else
                {
                    newRank_StaWis251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaWis251No;
                }


                NpgsqlCommand update_UserStaWis251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank2\" = " + newRank_StaWis251 + " Where \"Nickname\" ='" + PeopleForStaWis251[i] + "' ");
                update_UserStaWis251_Log.Connection = cn;
                update_UserStaWis251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_StaPatt251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StaPatt251(item username)
        {
            List<String> PeopleForStaPatt251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaPatt251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/patt 251'";
                NpgsqlCommand Total_StaPatt251 = new NpgsqlCommand(getTotal_StaPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/patt 251'";
                NpgsqlCommand Total_Log_StaPatt251 = new NpgsqlCommand(getTotal_Log_StaPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaPatt251.ExecuteScalar().ToString());

                string getUser_StaPatt251 = "SELECT \"sta/patt 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand user_StaPatt251 = new NpgsqlCommand(getUser_StaPatt251, cn);
                int user_StaPatt251No = Convert.ToInt32(user_StaPatt251.ExecuteScalar().ToString());

                decimal newRank_StaPatt251;
                if (total_Log1 == 0)
                {
                    newRank_StaPatt251 = 0;
                }
                else
                {
                    newRank_StaPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaPatt251No;
                }

                NpgsqlCommand update_UserStaPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank3\" = " + newRank_StaPatt251 + " Where \"Nickname\" ='" + PeopleForStaPatt251[i] + "' ");
                update_UserStaPatt251_Log.Connection = cn;
                update_UserStaPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_StrPatt251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_StrPatt251(item username)
        {
            List<String> PeopleForStrPatt251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStrPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStrPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStrPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStrPatt251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StrPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'str/patt 251'";
                NpgsqlCommand Total_StrPatt251 = new NpgsqlCommand(getTotal_StrPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_StrPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StrPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_str/patt 251'";
                NpgsqlCommand Total_Log_StrPatt251 = new NpgsqlCommand(getTotal_Log_StrPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StrPatt251.ExecuteScalar().ToString());

                string getUser_StrPatt251 = "SELECT \"str/patt 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand user_StrPatt251 = new NpgsqlCommand(getUser_StrPatt251, cn);
                int user_StrPatt251No = Convert.ToInt32(user_StrPatt251.ExecuteScalar().ToString());

                decimal newRank_StrPatt251;
                if (total_Log1 == 0)
                {
                    newRank_StrPatt251 = 0;
                }
                else
                {
                    newRank_StrPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StrPatt251No;
                }

                NpgsqlCommand update_UserStrPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank4\" = " + newRank_StrPatt251 + " Where \"Nickname\" ='" + PeopleForStrPatt251[i] + "' ");
                update_UserStrPatt251_Log.Connection = cn;
                update_UserStrPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_DexPatt251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_DexPatt251(item username)
        {
            List<String> PeopleForDexPatt251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForDexPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForDexPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForDexPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForDexPatt251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_DexPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'dex/patt 251'";
                NpgsqlCommand Total_DexPatt251 = new NpgsqlCommand(getTotal_DexPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_DexPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_DexPatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_dex/patt 251'";
                NpgsqlCommand Total_Log_DexPatt251 = new NpgsqlCommand(getTotal_Log_DexPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_DexPatt251.ExecuteScalar().ToString());

                string getUser_DexPatt251 = "SELECT \"dex/patt 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand user_DexPatt251 = new NpgsqlCommand(getUser_DexPatt251, cn);
                int user_DexPatt251No = Convert.ToInt32(user_DexPatt251.ExecuteScalar().ToString());

                decimal newRank_DexPatt251;
                if (total_Log1 == 0)
                {
                    newRank_DexPatt251 = 0;
                }
                else
                {
                    newRank_DexPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_DexPatt251No;
                }


                NpgsqlCommand update_UserDexPatt251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank5\" = " + newRank_DexPatt251 + " Where \"Nickname\" ='" + PeopleForDexPatt251[i] + "' ");
                update_UserDexPatt251_Log.Connection = cn;
                update_UserDexPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_IntMatt251", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_IntMatt251(item username)
        {
            List<String> PeopleForIntMatt251 = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMatt251.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'int/matt 251'";
                NpgsqlCommand Total_IntMatt251 = new NpgsqlCommand(getTotal_IntMatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMatt251 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_int/matt 251'";
                NpgsqlCommand Total_Log_IntMatt251 = new NpgsqlCommand(getTotal_Log_IntMatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMatt251.ExecuteScalar().ToString());

                string getUser_IntMatt251 = "SELECT \"int/matt 251\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand user_IntMatt251 = new NpgsqlCommand(getUser_IntMatt251, cn);
                int user_IntMatt251No = Convert.ToInt32(user_IntMatt251.ExecuteScalar().ToString());

                decimal newRank_IntMatt251;
                if (total_Log1 == 0)
                {
                    newRank_IntMatt251 = 0;
                }
                else
                {
                    newRank_IntMatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMatt251No;
                }


                NpgsqlCommand update_UserIntMatt251_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank6\" = " + newRank_IntMatt251 + " Where \"Nickname\" ='" + PeopleForIntMatt251[i] + "' ");
                update_UserIntMatt251_Log.Connection = cn;
                update_UserIntMatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("Przeliczenia_Rank_IntMatt", "AddItem");
        }

        public ActionResult Przeliczenia_Rank_IntMatt(item username)
        {
            List<String> PeopleForIntMatt = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMatt.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMatt.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'int/matt'";
                NpgsqlCommand Total_IntMatt = new NpgsqlCommand(getTotal_IntMatt, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMatt.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_int/matt'";
                NpgsqlCommand Total_Log_IntMatt = new NpgsqlCommand(getTotal_Log_IntMatt, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMatt.ExecuteScalar().ToString());

                string getUser_IntMatt = "SELECT \"int/matt\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand user_IntMatt = new NpgsqlCommand(getUser_IntMatt, cn);
                int user_IntMattNo = Convert.ToInt32(user_IntMatt.ExecuteScalar().ToString());

                decimal newRank_IntMatt;
                if (total_Log1 == 0)
                {
                    newRank_IntMatt = 0;
                }
                else
                {
                    newRank_IntMatt = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMattNo;
                }


                NpgsqlCommand update_UserIntMatt_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank7\" = " + newRank_IntMatt + " Where \"Nickname\" ='" + PeopleForIntMatt[i] + "' ");
                update_UserIntMatt_Log.Connection = cn;
                update_UserIntMatt_Log.ExecuteNonQuery();
                cn.Close();
            }
            return RedirectToAction("AddItem", "AddItem");
        }
    }

}