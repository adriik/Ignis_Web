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
        public List<Items> ItemList { get; set; }

        public string Name { get; set; }

        public Drop(string nickname, string dungeon)
        {
            Nickname = nickname;
            ItemList = new List<Items>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryDrop = "SELECT \"Drop\",\"Type\" FROM public.\"" + dungeon + "_Items\" WHERE \"Receiver\" = '" + nickname + "'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryDrop, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ItemList.Add(new Items(reader.GetString(0), reader.GetString(1)));
                    }
                }
            }
        }

        public Drop(string nickname, string name, string dungeon)
        {
            Name = name;
            Nickname = nickname;
        }
    }

    public class Items
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public Items(string v1, string v2)
        {
            this.Type = v2;
            this.Name = v1;
        }
    }
}