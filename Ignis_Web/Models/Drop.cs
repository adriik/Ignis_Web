using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class Drop
    {
        public string Nickname { get; set; }
        public List<string> ItemList { get; set; }

        public Drop(string nickname)
        {
            Nickname = nickname;
            ItemList = new List<string>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryDrop = "SELECT \"Drop\" FROM public.\"IBP_Items\" WHERE \"Receiver\" = '" + nickname + "' AND \"Type\" = 'Item'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryDrop, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemList.Add(reader.GetString(0));
                    }
                }
            }
        }
    }
}