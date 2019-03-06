using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class SetReqAccess
    {
        public void SetReq(SetReq secik)
        {
            var nicknames = secik.Nickname;
            var setCollect = secik.collect;
            //Instancje
            var IBP_Dungeon = secik.checkIBP;
            var SToES_Dungeon = secik.checkSToES;
            string Dungeon = "";

            if (IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if (SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }

            string checkSet = "";
            if (setCollect == true)
            {
                checkSet = "true";
            }
            if (setCollect == false)
            {
                checkSet = "false";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            NpgsqlCommand updateSetCollection = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Set\" = '" + checkSet + "' Where \"Nickname\" ='" + nicknames + "' ");
            updateSetCollection.Connection = cn;
            updateSetCollection.ExecuteNonQuery();
            cn.Close();
        }
    }
}