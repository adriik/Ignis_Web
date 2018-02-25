using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Models
{
    public class Czlonek
    {
        public string Nickname { get; set; }
        public string Class { get; set; }

        public string Pierwszy { get; set; }
        public string Drugi { get; set; }
        public string Trzeci { get; set; }
        public string Czwarty { get; set; }
        public string Piaty { get; set; }
        public string Kolor { get; set; }
        public double Total { get; set; }
        public static double TotalAll { get; set; }
        public static int GoldTotalAll { get; set; }
        public int GoldIncome { get; set; }
        public bool Set { get; set; }
        public int Gloves { get; set; }
        public string GlovesHd { get; set; }
        public int Belt { get; set; }
        public string BeltHd { get; set; }
        public int Cloak { get; set; }
        public string CloakHd { get; set; }
        public int Pants { get; set; }
        public string PantsHd { get; set; }
        public int Weapon { get; set; }
        public string WeaponHd { get; set; }
        public int Shield { get; set; }
        public string ShieldHd { get; set; }
        public int Stat1 { get; set; }
        public double Stat1Rank { get; set; }
        public bool Stat1Select { get; set; } = false;
        public double Stat1PercentRank { get; set; }
        public static int Stat1Total { get; set; }
        public static double Stat1TotalRank { get; set; }
        public int Stat2 { get; set; }
        public double Stat2Rank { get; set; }
        public bool Stat2Select { get; set; } = false;
        public double Stat2PercentRank { get; set; }
        public static int Stat2Total { get; set; }
        public static double Stat2TotalRank { get; set; }
        public int Stat3 { get; set; }
        public double Stat3Rank { get; set; }
        public bool Stat3Select { get; set; } = false;
        public double Stat3PercentRank { get; set; }
        public static int Stat3Total { get; set; }
        public static double Stat3TotalRank { get; set; }
        public int Stat4 { get; set; }
        public double Stat4Rank { get; set; }
        public bool Stat4Select { get; set; } = false;
        public double Stat4PercentRank { get; set; }
        public static int Stat4Total { get; set; }
        public static double Stat4TotalRank { get; set; }
        public int Stat5 { get; set; }
        public double Stat5Rank { get; set; }
        public bool Stat5Select { get; set; } = false;
        public double Stat5PercentRank { get; set; }
        public static int Stat5Total { get; set; }
        public static double Stat5TotalRank { get; set; }
        public int Stat6 { get; set; }
        public double Stat6Rank { get; set; }
        public bool Stat6Select { get; set; } = false;
        public double Stat6PercentRank { get; set; }
        public static int Stat6Total { get; set; }
        public static double Stat6TotalRank { get; set; }
        public int Stat7 { get; set; }
        public double Stat7Rank { get; set; }
        public bool Stat7Select { get; set; } = false;
        public double Stat7PercentRank { get; set; }
        public static int Stat7Total { get; set; }
        public static double Stat7TotalRank { get; set; }
        public int Stat8 { get; set; }
        public double Stat8Rank { get; set; }
        public bool Stat8Select { get; set; } = false;
        public double Stat8PercentRank { get; set; }
        public static int Stat8Total { get; set; }
        public static double Stat8TotalRank { get; set; }
        public int Stat9 { get; set; }
        public double Stat9Rank { get; set; }
        public bool Stat9Select { get; set; } = false;
        public double Stat9PercentRank { get; set; }
        public static int Stat9Total { get; set; }
        public static double Stat9TotalRank { get; set; }

        public Czlonek(string Nickname, string Dungeon)
        {
            this.Nickname = Nickname;//[0].ToString().ToUpper() + Nickname.Substring(1);

            //Stat1Select = false;
            //s = s[0].ToUpper() + s.Substring(1);
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryPeople = "SELECT * FROM public.\"" + Dungeon + "\",public.\"People\" WHERE \"" + Dungeon + "\".\"Nickname\"=" + "'"+Nickname+ "' AND \"People\".\"Nickname\"=" + "'" +Nickname+"'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pierwszy = reader.GetString(1);
                        Drugi = reader.GetString(2);
                        Trzeci = reader.GetString(3);
                        Czwarty = reader.GetString(4);
                        Piaty = reader.GetString(5);
                        Total = Math.Round(reader.GetDouble(6),2);
                        TotalAll += Total;
                        GoldIncome = reader.GetInt32(9);
                        GoldTotalAll += GoldIncome;
                        Set = reader.GetBoolean(10);
                        Gloves = reader.GetInt32(11);
                        Belt = reader.GetInt32(12);
                        Cloak = reader.GetInt32(13);
                        Pants = reader.GetInt32(14);
                        Weapon = reader.GetInt32(15);
                        Shield = reader.GetInt32(16);
                        Stat1 = reader.GetInt32(17);
                        Stat1Rank = Math.Round(reader.GetDouble(18),2);
                        Stat1Total += Stat1;

                        Stat2 = reader.GetInt32(19);
                        Stat2Rank = Math.Round(reader.GetDouble(20),2);
                        Stat2Total += Stat2;

                        Stat3 = reader.GetInt32(21);
                        Stat3Rank = Math.Round(reader.GetDouble(22),2);
                        Stat3Total += Stat3;

                        Stat4 = reader.GetInt32(23);
                        Stat4Rank = Math.Round(reader.GetDouble(24),2);
                        Stat4Total += Stat4;

                        Stat5 = reader.GetInt32(25);
                        Stat5Rank = Math.Round(reader.GetDouble(26),2);
                        Stat5Total += Stat5;

                        Stat6 = reader.GetInt32(27);
                        Stat6Rank = Math.Round(reader.GetDouble(28),2);
                        Stat6Total += Stat6;

                        Stat7 = reader.GetInt32(29);
                        Stat7Rank = Math.Round(reader.GetDouble(30),2);
                        Stat7Total += Stat7;

                        Stat8 = reader.GetInt32(31);
                        Stat8Rank = Math.Round(reader.GetDouble(32), 2);
                        Stat8Total += Stat8;

                        Stat9 = reader.GetInt32(33);
                        Stat9Rank = Math.Round(reader.GetDouble(34), 2);
                        Stat9Total += Stat9;

                        Class = reader.GetString(36);
                    }
                }
            }
            cn.Close();
            if (Gloves > 100) { GlovesHd = "color-hd"; } else if(Set == true) { GlovesHd = "color-set-negative"; }
            if (Pants > 100) { PantsHd = "color-hd"; } else if (Set == true) { PantsHd = "color-set-negative"; }
            if (Belt > 100) { BeltHd = "color-hd"; } else if (Set == true) { BeltHd = "color-set-negative"; }
            if (Cloak > 100) { CloakHd = "color-hd"; } else if (Set == true) { CloakHd = "color-set-negative"; }
            if (Weapon > 100) { WeaponHd = "color-hd"; } else { WeaponHd = "color-set-negative"; }
            if (Shield > 100) { ShieldHd = "color-hd"; } else { ShieldHd = "color-set-negative"; }
        }
    }
}