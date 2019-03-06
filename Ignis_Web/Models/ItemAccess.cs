using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class ItemAccess
    {
        public List<Itemki> GetTypyItemow()
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
            cn.Close();
            return TypyItemów;
        }

        public List<item> GetListaLudzi()
        {
            var lista = new List<item>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
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
            cn.Close();
            return lista;
        }

        public void SetFirstItemStat(Itemki itemki, NazwyDropu nazwy, item username)
        {
            //Instancje
            var IBP_Dungeon = itemki.checkIBP;
            var SToES_Dungeon = itemki.checkSToES;
            string Dungeon = "";

            if (IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if (SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }

            var FirstItemType = itemki.Drop_Type1;
            var FirstItemID = itemki.Item_Drop1;
            var FirstItemDura = itemki.Item_Dura1;
            var FirstItemReceiver = itemki.Drop_Receiver1;
            var FirstItemSet = itemki.Item_Set1;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            //Zdobywanie Nazwy Itemu bazujac na wybranym ID
            string FirstItemN = "Select \"Item\" from  public.\"ListaDropu\" Where \"ID\" = " + FirstItemID + "";
            NpgsqlCommand checkFirstItemN = new NpgsqlCommand(FirstItemN, cn);
            string FirstItemName = checkFirstItemN.ExecuteScalar().ToString();
            //Zdobywanie Kategori Itemu bazujac na wybranym ID
            string FirstItemK = "Select \"Kategoria\" from  public.\"ListaDropu\" Where \"ID\" = " + FirstItemID + "";
            NpgsqlCommand checkFirstItemK = new NpgsqlCommand(FirstItemK, cn);
            string FirstItemCategory = checkFirstItemK.ExecuteScalar().ToString();

            //Wyliczenie ilosci danego statu i zaktualizowanie tej wartosci w tabelce
            string queryStr = "Select \"" + FirstItemName + "\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + FirstItemReceiver + "'";
            NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
            int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
            temp = temp + 1;
            NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"" + FirstItemName + "\" = " + temp + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
            update_Stat.Connection = cn;
            update_Stat.ExecuteNonQuery();
            cn.Close();
        }

        public void SetFirstItemItem(Itemki itemki, NazwyDropu nazwy, item username)
        {
            //Instancje
            var IBP_Dungeon = itemki.checkIBP;
            var SToES_Dungeon = itemki.checkSToES;
            string Dungeon = "";

            if (IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if (SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }

            var FirstItemType = itemki.Drop_Type1;
            var FirstItemID = itemki.Item_Drop1;
            var FirstItemDura = itemki.Item_Dura1;
            var FirstItemReceiver = itemki.Drop_Receiver1;
            var FirstItemSet = itemki.Item_Set1;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);

            cn.Open();
            //Zdobywanie Nazwy Itemu bazujac na wybranym ID
            string FirstItemN = "Select \"Item\" from  public.\"ListaDropu\" Where \"ID\" = " + FirstItemID + "";
            NpgsqlCommand checkFirstItemN = new NpgsqlCommand(FirstItemN, cn);
            string FirstItemName = checkFirstItemN.ExecuteScalar().ToString();
            //Zdobywanie Kategori Itemu bazujac na wybranym ID
            string FirstItemK = "Select \"Kategoria\" from  public.\"ListaDropu\" Where \"ID\" = " + FirstItemID + "";
            NpgsqlCommand checkFirstItemK = new NpgsqlCommand(FirstItemK, cn);
            string FirstItemCategory = checkFirstItemK.ExecuteScalar().ToString();

            cn.Close();

            if (FirstItemSet == true)
            {
                if (FirstItemName == "Pas")
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
                if (FirstItemName == "Czapka")
                {
                    cn.Open();
                    NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Head\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                    update_Item.Connection = cn;
                    update_Item.ExecuteNonQuery();
                    cn.Close();
                }
                if (FirstItemName == "Buty")
                {
                    cn.Open();
                    NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Boots\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                    update_Item.Connection = cn;
                    update_Item.ExecuteNonQuery();
                    cn.Close();
                }
                if (FirstItemName == "Naramienniki")
                {
                    cn.Open();
                    NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Shoulders\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                    update_Item.Connection = cn;
                    update_Item.ExecuteNonQuery();
                    cn.Close();
                }
                if (FirstItemName == "Szata")
                {
                    cn.Open();
                    NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Armor\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                    update_Item.Connection = cn;
                    update_Item.ExecuteNonQuery();
                    cn.Close();
                }
                if (FirstItemName == "Zbroja")
                {
                    cn.Open();
                    NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Armor\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                    update_Item.Connection = cn;
                    update_Item.ExecuteNonQuery();
                    cn.Close();
                }
                if (FirstItemCategory == "Bronie")
                {
                    if (FirstItemName.Contains("Tarcza") || FirstItemName.Contains("Talizman"))
                    {
                        cn.Open();
                        NpgsqlCommand update_Shield = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Shield\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Shield.Connection = cn;
                        update_Shield.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Open();
                        NpgsqlCommand update_Item = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Weapon\" = " + FirstItemDura + " Where \"Nickname\" ='" + FirstItemReceiver + "' ");
                        update_Item.Connection = cn;
                        update_Item.ExecuteNonQuery();
                        cn.Close();
                    }
                }
            }
            else
            {
                cn.Open();
                NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"" + Dungeon + "_Items\" Values('" + FirstItemCategory + "','" + FirstItemName + " " + FirstItemDura + "','" + FirstItemReceiver + "')");
                InsertDrop.Connection = cn;
                InsertDrop.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}