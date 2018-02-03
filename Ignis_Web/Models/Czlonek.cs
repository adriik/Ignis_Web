using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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
            string QueryPeople = "SELECT \"First Boss\",\"Second Boss\",\"Third Boss\",\"Fourth Boss\",\"Fifth Boss\",\"Total\" FROM public.\"IBP\" WHERE \"Nickname\"=" + "'"+Nickname+"'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pierwszy = reader.GetString(0);
                        Drugi = reader.GetString(1);
                        Trzeci = reader.GetString(2);
                        Czwarty = reader.GetString(3);
                        Piaty = reader.GetString(4);
                        Total = Math.Round(reader.GetDouble(5),2);
                        TotalAll += Total;
                    }
                }
            }
            cn.Close();
            
        }
    }
}