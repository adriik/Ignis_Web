using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class CzlonekAccess
    {
        public List<Czlonek> GetListaCzlonkow(string dungeon)
        {
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
                        lista.Add(new Czlonek(reader.GetString(0), dungeon));
                    }
                }
            }
            cn.Close();
            return lista;
        }

        public void SetRank(string dungeon)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryRank = "SELECT * FROM public.\"WSP_" + dungeon + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryRank, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == "Log_sta/hp red")
                        {
                            Czlonek.Stat1TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_sta/wis red")
                        {
                            Czlonek.Stat2TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_sta/patt red")
                        {
                            Czlonek.Stat3TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_str/patt red")
                        {
                            Czlonek.Stat4TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_dex/patt red")
                        {
                            Czlonek.Stat5TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_int/matt red")
                        {
                            Czlonek.Stat6TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_int/matt yellow")
                        {
                            Czlonek.Stat7TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_str/patt yellow")
                        {
                            Czlonek.Stat8TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                        else if (reader.GetString(0) == "Log_dex/patt yellow")
                        {
                            Czlonek.Stat9TotalRank = Math.Round(reader.GetDouble(1), 2);
                        }
                    }
                }
            }
            cn.Close();
        }
    }
}