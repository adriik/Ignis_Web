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
        public int GoldIncome { get; set; }
        public bool Set { get; set; }
        public int Gloves { get; set; }
        public int Belt { get; set; }
        public int Cloak { get; set; }
        public int Pants { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
        public int Stat1 { get; set; }
        public double Stat1Rank { get; set; }
        public int Stat2 { get; set; }
        public double Stat2Rank { get; set; }
        public int Stat3 { get; set; }
        public double Stat3Rank { get; set; }
        public int Stat4 { get; set; }
        public double Stat4Rank { get; set; }
        public int Stat5 { get; set; }
        public double Stat5Rank { get; set; }
        public int Stat6 { get; set; }
        public double Stat6Rank { get; set; }
        public int Stat7 { get; set; }
        public double Stat7Rank { get; set; }

        public Czlonek(string Nickname)
        {
            this.Nickname = Nickname;//[0].ToString().ToUpper() + Nickname.Substring(1);
            if(Nickname == "Etze")
            {
                this.Kolor = "background-color: coral;";
            }
            
            //s = s[0].ToUpper() + s.Substring(1);
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryPeople = "SELECT * FROM public.\"IBP\" WHERE \"Nickname\"=" + "'"+Nickname+"'";
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
                        Set = reader.GetBoolean(10);
                        Gloves = reader.GetInt32(11);
                        Belt = reader.GetInt32(12);
                        Cloak = reader.GetInt32(13);
                        Pants = reader.GetInt32(14);
                        Weapon = reader.GetInt32(15);
                        Shield = reader.GetInt32(16);
                        Stat1 = reader.GetInt32(17);
                        Stat1Rank = Math.Round(reader.GetDouble(18),3);

                        Stat2 = reader.GetInt32(19);
                        Stat2Rank = Math.Round(reader.GetDouble(20),3);

                        Stat3 = reader.GetInt32(21);
                        Stat3Rank = Math.Round(reader.GetDouble(22),3);

                        Stat4 = reader.GetInt32(23);
                        Stat4Rank = Math.Round(reader.GetDouble(24),3);

                        Stat5 = reader.GetInt32(25);
                        Stat5Rank = Math.Round(reader.GetDouble(26),3);

                        Stat6 = reader.GetInt32(27);
                        Stat6Rank = Math.Round(reader.GetDouble(28),3);

                        Stat7 = reader.GetInt32(29);
                        Stat7Rank = Math.Round(reader.GetDouble(30),3);
                    }
                }
            }
            cn.Close();
            
        }
    }
}