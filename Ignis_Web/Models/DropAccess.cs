using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class DropAccess
    {
        public List<Drop> GetListaDrop(string dungeon)
        {
            List<Drop> listDrop = new List<Drop>();

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryDrop = "SELECT DISTINCT \"Receiver\" FROM public.\"" + dungeon + "_Items\"";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryDrop, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listDrop.Add(new Drop(reader.GetString(0), dungeon));
                    }
                }
            }
            cn.Close();
            return listDrop;
        }
    }
}