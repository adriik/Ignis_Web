using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class UzytkownikAccess
    {
        public bool IsValid(Uzytkownik uzytkownik)
        {
            var username = uzytkownik.UserName;
            var password = uzytkownik.Password;

            string DBPassword = null;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string QueryPeople = "SELECT \"Password\" FROM public.\"Accounts\" WHERE \"Nickname\" ='" + username + "'";
            using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DBPassword = reader.GetString(0);
                    }
                }
            }
            cn.Close();

            if (password.Equals(DBPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}