using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class WspAccess
    {
        public void SetStat(item username, string dungeonName)
        {
            List<int> Total_StaHpred = new List<int>();
            List<int> Total_StaWisred = new List<int>();
            List<int> Total_StaPattred = new List<int>();
            List<int> Total_StrPattred = new List<int>();
            List<int> Total_DexPattred = new List<int>();
            List<int> Total_IntMattred = new List<int>();
            List<int> Total_IntMatt = new List<int>();
            List<int> Total_StrPatt = new List<int>();
            List<int> Total_DexPatt = new List<int>();

            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }

            int totalStat_StaHpRed = 0;
            int totalStat_StaWisRed = 0;
            int totalStat_StaPattRed = 0;
            int totalStat_StrPattRed = 0;
            int totalStat_DexPattRed = 0;
            int totalStat_IntMattRed = 0;
            int totalStat_IntMatt = 0;
            int totalStat_StrPatt = 0;
            int totalStat_DexPatt = 0;

            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            //Query to calculate Total sta/hp red stats
            string Total_StaHpred_Query = "SELECT \"sta/hp red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaHpred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaHpred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaHpred.Count; c++)
            {

                totalStat_StaHpRed = totalStat_StaHpRed + Total_StaHpred[c];
            }
            NpgsqlCommand Update_Total_StaHpred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaHpRed + " Where \"WSP_Name\" ='sta/hp red'");
            Update_Total_StaHpred.Connection = cn;
            Update_Total_StaHpred.ExecuteNonQuery();

            //Query to calculate Total sta/wis red stats
            string Total_StaWisred_Query = "SELECT \"sta/wis red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaWisred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaWisred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaWisred.Count; c++)
            {

                totalStat_StaWisRed = totalStat_StaWisRed + Total_StaWisred[c];
            }
            NpgsqlCommand Update_Total_StaWisred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaWisRed + " Where \"WSP_Name\" ='sta/wis red'");
            Update_Total_StaWisred.Connection = cn;
            Update_Total_StaWisred.ExecuteNonQuery();

            //Query to calculate Total sta/patt red stats
            string Total_StaPattred_Query = "SELECT \"sta/patt red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaPattred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaPattred.Count; c++)
            {

                totalStat_StaPattRed = totalStat_StaPattRed + Total_StaPattred[c];
            }
            NpgsqlCommand Update_Total_StaPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaPattRed + " Where \"WSP_Name\" ='sta/patt red'");
            Update_Total_StaPattred.Connection = cn;
            Update_Total_StaPattred.ExecuteNonQuery();

            //Query to calculate Total str/patt red stats
            string Total_StrPattred_Query = "SELECT \"str/patt red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StrPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StrPattred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StrPattred.Count; c++)
            {

                totalStat_StrPattRed = totalStat_StrPattRed + Total_StrPattred[c];
            }
            NpgsqlCommand Update_Total_StrPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StrPattRed + " Where \"WSP_Name\" ='str/patt red'");
            Update_Total_StrPattred.Connection = cn;
            Update_Total_StrPattred.ExecuteNonQuery();

            //Query to calculate Total dex/patt red stats
            string Total_DexPattred_Query = "SELECT \"dex/patt red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_DexPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_DexPattred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_DexPattred.Count; c++)
            {

                totalStat_DexPattRed = totalStat_DexPattRed + Total_DexPattred[c];
            }
            NpgsqlCommand Update_Total_DexPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_DexPattRed + " Where \"WSP_Name\" ='dex/patt red'");
            Update_Total_DexPattred.Connection = cn;
            Update_Total_DexPattred.ExecuteNonQuery();

            //Query to calculate Total int/matt red stats
            string Total_IntMattred_Query = "SELECT \"int/matt red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMattred.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMattred.Count; c++)
            {

                totalStat_IntMattRed = totalStat_IntMattRed + Total_IntMattred[c];
            }
            NpgsqlCommand Update_Total_IntMattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_IntMattRed + " Where \"WSP_Name\" ='int/matt red'");
            Update_Total_IntMattred.Connection = cn;
            Update_Total_IntMattred.ExecuteNonQuery();

            //Query to calculate Total int/matt stats
            string Total_IntMatt_Query = "SELECT \"int/matt yellow\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMatt.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMatt.Count; c++)
            {

                totalStat_IntMatt = totalStat_IntMatt + Total_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_IntMatt + " Where \"WSP_Name\" ='int/matt yellow'");
            Update_Total_IntMatt.Connection = cn;
            Update_Total_IntMatt.ExecuteNonQuery();

            //Query to calculate Total str/patt stats
            string Total_StrPatt_Query = "SELECT \"str/patt yellow\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StrPatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StrPatt.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StrPatt.Count; c++)
            {

                totalStat_StrPatt = totalStat_StrPatt + Total_StrPatt[c];
            }
            NpgsqlCommand Update_Total_StrPatt = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StrPatt + " Where \"WSP_Name\" ='str/patt yellow'");
            Update_Total_StrPatt.Connection = cn;
            Update_Total_StrPatt.ExecuteNonQuery();

            //Query to calculate Total dex/patt stats
            string Total_DexPatt_Query = "SELECT \"dex/patt yellow\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_DexPatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_DexPatt.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_DexPatt.Count; c++)
            {

                totalStat_DexPatt = totalStat_DexPatt + Total_DexPatt[c];
            }
            NpgsqlCommand Update_Total_DexPatt = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_DexPatt + " Where \"WSP_Name\" ='dex/patt yellow'");
            Update_Total_DexPatt.Connection = cn;
            Update_Total_DexPatt.ExecuteNonQuery();
            cn.Close();
        }

        public void SetWsp(item username, string dungeonName)
        {
            List<float> WSP_Data = new List<float>();
            List<float> LogGold_Data = new List<float>();
            List<float> LogStat_Data = new List<float>();

            List<float> Rank_StaHpred = new List<float>();
            List<float> Rank_StaWisred = new List<float>();
            List<float> Rank_StaPattred = new List<float>();
            List<float> Rank_StrPattred = new List<float>();
            List<float> Rank_DexPattred = new List<float>();
            List<float> Rank_IntMattred = new List<float>();
            List<float> Rank_IntMatt = new List<float>();
            List<float> Rank_StrPatt = new List<float>();
            List<float> Rank_DexPatt = new List<float>();
            float total_WSP = 0;
            float total_Gold = 0;
            float total_Stat = 0;

            float getRank_StaHpred = 0;
            float getRank_StaWisred = 0;
            float getRank_StaPattred = 0;
            float getRank_StrPattred = 0;
            float getRank_DexPattred = 0;
            float getRank_IntMattred = 0;
            float getRank_IntMatt = 0;
            float getRank_StrPatt = 0;
            float getRank_DexPatt = 0;

            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();

            //Query to calculate Total Guild Frequency
            string WSP_Query = "SELECT \"Total\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(WSP_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WSP_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < WSP_Data.Count; c++)
            {

                total_WSP = total_WSP + WSP_Data[c];
            }
            string CoqTotal = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqTotal = new NpgsqlCommand(CoqTotal, cn);
            float TotalCoq = float.Parse(getCoqTotal.ExecuteScalar().ToString());
            total_WSP = total_WSP - TotalCoq;
            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_WSP + " Where \"WSP_Name\" ='WSP'");
            cmd1.Connection = cn;
            cmd1.ExecuteNonQuery();

            //Query to calculate Total Gold_Logarithm
            string LogGold_Query = "SELECT \"Gold-Logarithm\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogGold_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogGold_Data.Add(reader.GetFloat(0));

                    }
                }
            }
            for (var c = 0; c < LogGold_Data.Count; c++)
            {

                total_Gold = total_Gold + LogGold_Data[c];
            }
            string CoqGold = "Select \"Gold-Logarithm\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqGold = new NpgsqlCommand(CoqGold, cn);
            float GoldCoq = float.Parse(getCoqGold.ExecuteScalar().ToString());
            total_Gold = total_Gold - GoldCoq;
            NpgsqlCommand Update_GoldLogarithm = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_Gold + " Where \"WSP_Name\" ='LogGold'");
            Update_GoldLogarithm.Connection = cn;
            Update_GoldLogarithm.ExecuteNonQuery();

            //Query to calculate Total Stat_Logarithm
            string LogStat_Query = "SELECT \"Stat-Logarithm\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogStat_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogStat_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < LogStat_Data.Count; c++)
            {

                total_Stat = total_Stat + LogStat_Data[c];
            }
            string CoqStat = "Select \"Stat-Logarithm\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqStat = new NpgsqlCommand(CoqStat, cn);
            float StatCoq = float.Parse(getCoqStat.ExecuteScalar().ToString());
            total_Stat = total_Stat - StatCoq;
            NpgsqlCommand Update_StatLogarithm = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + total_Stat + " Where \"WSP_Name\" ='LogStat'");
            Update_StatLogarithm.Connection = cn;
            Update_StatLogarithm.ExecuteNonQuery();



            //Query to calculate Total Logarithm for sta/hp red stats
            string Rank_StaHpred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaHpred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaHpred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaHpred.Count; c++)
            {
                getRank_StaHpred = getRank_StaHpred + Rank_StaHpred[c];
            }
            NpgsqlCommand Update_Total_StaHpred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaHpred + " Where \"WSP_Name\" ='Log_sta/hp red'");
            Update_Total_StaHpred_Log.Connection = cn;
            Update_Total_StaHpred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/wis red stats
            string Rank_StaWisred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaWisred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaWisred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaWisred.Count; c++)
            {
                getRank_StaWisred = getRank_StaWisred + Rank_StaWisred[c];
            }
            NpgsqlCommand Update_Total_StaWisred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaWisred + " Where \"WSP_Name\" ='Log_sta/wis red'");
            Update_Total_StaWisred_Log.Connection = cn;
            Update_Total_StaWisred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/patt red stats
            string Rank_StaPattred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaPattred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaPattred.Count; c++)
            {
                getRank_StaPattred = getRank_StaPattred + Rank_StaPattred[c];
            }
            NpgsqlCommand Update_Total_StaPattred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StaPattred + " Where \"WSP_Name\" ='Log_sta/patt red'");
            Update_Total_StaPattred_Log.Connection = cn;
            Update_Total_StaPattred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for str/patt red stats
            string Rank_StrPattred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StrPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StrPattred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StrPattred.Count; c++)
            {
                getRank_StrPattred = getRank_StrPattred + Rank_StrPattred[c];
            }
            NpgsqlCommand Update_Total_StrPattred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StrPattred + " Where \"WSP_Name\" ='Log_str/patt red'");
            Update_Total_StrPattred_Log.Connection = cn;
            Update_Total_StrPattred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for dex/patt red stats
            string Rank_DexPattred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge','Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_DexPattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_DexPattred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_DexPattred.Count; c++)
            {
                getRank_DexPattred = getRank_DexPattred + Rank_DexPattred[c];
            }
            NpgsqlCommand Update_Total_DexPattred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_DexPattred + " Where \"WSP_Name\" ='Log_dex/patt red'");
            Update_Total_DexPattred_Log.Connection = cn;
            Update_Total_DexPattred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt red stats
            string Rank_IntMattred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMattred_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMattred.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMattred.Count; c++)
            {
                getRank_IntMattred = getRank_IntMattred + Rank_IntMattred[c];
            }
            NpgsqlCommand Update_Total_IntMattred_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_IntMattred + " Where \"WSP_Name\" ='Log_int/matt red'");
            Update_Total_IntMattred_Log.Connection = cn;
            Update_Total_IntMattred_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt stats
            string Rank_IntMatt_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMatt.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMatt.Count; c++)
            {
                getRank_IntMatt = getRank_IntMatt + Rank_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_IntMatt + " Where \"WSP_Name\" ='Log_int/matt yellow'");
            Update_Total_IntMatt_Log.Connection = cn;
            Update_Total_IntMatt_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for str/patt stats
            string Rank_StrPatt_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StrPatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StrPatt.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StrPatt.Count; c++)
            {
                getRank_StrPatt = getRank_StrPatt + Rank_StrPatt[c];
            }
            NpgsqlCommand Update_Total_StrPatt_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_StrPatt + " Where \"WSP_Name\" ='Log_str/patt yellow'");
            Update_Total_StrPatt_Log.Connection = cn;
            Update_Total_StrPatt_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for dex/patt stats
            string Rank_DexPatt_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_DexPatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_DexPatt.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_DexPatt.Count; c++)
            {
                getRank_DexPatt = getRank_DexPatt + Rank_DexPatt[c];
            }
            NpgsqlCommand Update_Total_DexPatt_Log = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + getRank_DexPatt + " Where \"WSP_Name\" ='Log_dex/patt yellow'");
            Update_Total_DexPatt_Log.Connection = cn;
            Update_Total_DexPatt_Log.ExecuteNonQuery();
            cn.Close();
        }

        public bool SimpleSetWsp(string Dungeon)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            Wsp wspolczynnik = new Wsp();

            try
            {
                NpgsqlCommand update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss1 + "'" + " WHERE \"WSP_Name\" = 'Boss1_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss2 + "'" + " WHERE \"WSP_Name\" = 'Boss2_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss3 + "'" + " WHERE \"WSP_Name\" = 'Boss3_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss4 + "'" + " WHERE \"WSP_Name\" = 'Boss4_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();

                update_wsp = new NpgsqlCommand("UPDATE public.\"" + "WSP_" + Dungeon + "\" SET \"WSP\" = " + "'" + wspolczynnik.Boss5 + "'" + " WHERE \"WSP_Name\" = 'Boss5_Multi'");
                update_wsp.Connection = cn;
                update_wsp.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (NpgsqlException)
            {
                cn.Close();
                return false;
            }
        }

        public Wsp GetWsp(string dung)
        {
            Wsp wspolczynnik = new Wsp();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string wsp = "SELECT * FROM public.\"WSP_" + dung + "\"";
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(wsp, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetString(0) == "Boss1_Multi")
                            {
                                wspolczynnik.Boss1 = Math.Round(reader.GetDouble(1), 2);
                            }
                            else if (reader.GetString(0) == "Boss2_Multi")
                            {
                                wspolczynnik.Boss2 = Math.Round(reader.GetDouble(1), 2);
                            }
                            else if (reader.GetString(0) == "Boss3_Multi")
                            {
                                wspolczynnik.Boss3 = Math.Round(reader.GetDouble(1), 2);
                            }
                            else if (reader.GetString(0) == "Boss4_Multi")
                            {
                                wspolczynnik.Boss4 = Math.Round(reader.GetDouble(1), 2);
                            }
                            else if (reader.GetString(0) == "Boss5_Multi")
                            {
                                wspolczynnik.Boss5 = Math.Round(reader.GetDouble(1), 2);
                            }
                        }
                    }
                }
                cn.Close();
            }
            catch (NpgsqlException)
            {
                return null;
            }

            return wspolczynnik;
        }

        public void SetRankStaHpred(item username, string dungeonName)
        {
            List<String> PeopleForStaHPred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaHP = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaHP, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaHPred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaHPred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaHPred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaHpred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/hp red'";
                NpgsqlCommand Total_StaHpred = new NpgsqlCommand(getTotal_StaHpred, cn);
                decimal total1 = Convert.ToDecimal(Total_StaHpred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaHpred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/hp red'";
                NpgsqlCommand Total_Log_StaHpred = new NpgsqlCommand(getTotal_Log_StaHpred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaHpred.ExecuteScalar().ToString());

                string getUser_StaHpred = "SELECT \"sta/hp red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaHPred[i] + "'";
                NpgsqlCommand user_StaHPred = new NpgsqlCommand(getUser_StaHpred, cn);
                int user_StaHpredNo = Convert.ToInt32(user_StaHPred.ExecuteScalar().ToString());

                decimal newRank_StaHpred;
                if (total_Log1 == 0)
                {
                    newRank_StaHpred = 0;
                }
                else
                {
                    newRank_StaHpred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaHpredNo;
                }


                NpgsqlCommand update_UserStaHpred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank1\" = " + newRank_StaHpred + " Where \"Nickname\" ='" + PeopleForStaHPred[i] + "' ");
                update_UserStaHpred_Log.Connection = cn;
                update_UserStaHpred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void SetRankStaWisred(item username, string dungeonName)
        {
            List<String> PeopleForStaWisred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaWis = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaWis, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaWisred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaWisred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaWisred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaWisred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/wis red'";
                NpgsqlCommand Total_StaWisred = new NpgsqlCommand(getTotal_StaWisred, cn);
                decimal total1 = Convert.ToDecimal(Total_StaWisred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaWisred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/wis red'";
                NpgsqlCommand Total_Log_StaWisred = new NpgsqlCommand(getTotal_Log_StaWisred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaWisred.ExecuteScalar().ToString());

                string getUser_StaWisred = "SELECT \"sta/wis red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaWisred[i] + "'";
                NpgsqlCommand user_StaWisred = new NpgsqlCommand(getUser_StaWisred, cn);
                int user_StaWisredNo = Convert.ToInt32(user_StaWisred.ExecuteScalar().ToString());

                decimal newRank_StaWisred;
                if (total_Log1 == 0)
                {
                    newRank_StaWisred = 0;
                }
                else
                {
                    newRank_StaWisred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaWisredNo;
                }


                NpgsqlCommand update_UserStaWisred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank2\" = " + newRank_StaWisred + " Where \"Nickname\" ='" + PeopleForStaWisred[i] + "' ");
                update_UserStaWisred_Log.Connection = cn;
                update_UserStaWisred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void SetRankRankStaPattred(item username, string dungeonName)
        {
            List<String> PeopleForStaPattred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStaPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaPattred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaPattred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaPattred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'sta/patt red'";
                NpgsqlCommand Total_StaPattred = new NpgsqlCommand(getTotal_StaPattred, cn);
                decimal total1 = Convert.ToDecimal(Total_StaPattred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_sta/patt red'";
                NpgsqlCommand Total_Log_StaPattred = new NpgsqlCommand(getTotal_Log_StaPattred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaPattred.ExecuteScalar().ToString());

                string getUser_StaPattred = "SELECT \"sta/patt red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStaPattred[i] + "'";
                NpgsqlCommand user_StaPattred = new NpgsqlCommand(getUser_StaPattred, cn);
                int user_StaPattredNo = Convert.ToInt32(user_StaPattred.ExecuteScalar().ToString());

                decimal newRank_StaPattred;
                if (total_Log1 == 0)
                {
                    newRank_StaPattred = 0;
                }
                else
                {
                    newRank_StaPattred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaPattredNo;
                }

                NpgsqlCommand update_UserStaPattred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank3\" = " + newRank_StaPattred + " Where \"Nickname\" ='" + PeopleForStaPattred[i] + "' ");
                update_UserStaPattred_Log.Connection = cn;
                update_UserStaPattred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void SetRankStrPattred(item username, string dungeonName)
        {
            List<String> PeopleForStrPattred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStrPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStrPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStrPattred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStrPattred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPattred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StrPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'str/patt red'";
                NpgsqlCommand Total_StrPattred = new NpgsqlCommand(getTotal_StrPattred, cn);
                decimal total1 = Convert.ToDecimal(Total_StrPattred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StrPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_str/patt red'";
                NpgsqlCommand Total_Log_StrPattred = new NpgsqlCommand(getTotal_Log_StrPattred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StrPattred.ExecuteScalar().ToString());

                string getUser_StrPattred = "SELECT \"str/patt red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPattred[i] + "'";
                NpgsqlCommand user_StrPattred = new NpgsqlCommand(getUser_StrPattred, cn);
                int user_StrPattredNo = Convert.ToInt32(user_StrPattred.ExecuteScalar().ToString());

                decimal newRank_StrPattred;
                if (total_Log1 == 0)
                {
                    newRank_StrPattred = 0;
                }
                else
                {
                    newRank_StrPattred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StrPattredNo;
                }

                NpgsqlCommand update_UserStrPattred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank4\" = " + newRank_StrPattred + " Where \"Nickname\" ='" + PeopleForStrPattred[i] + "' ");
                update_UserStrPattred_Log.Connection = cn;
                update_UserStrPattred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void SetRankDexPattred(item username, string dungeonName)
        {
            List<String> PeopleForDexPattred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForDexPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForDexPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForDexPattred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForDexPattred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPattred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_DexPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'dex/patt red'";
                NpgsqlCommand Total_DexPattred = new NpgsqlCommand(getTotal_DexPattred, cn);
                decimal total1 = Convert.ToDecimal(Total_DexPattred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_DexPattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_dex/patt red'";
                NpgsqlCommand Total_Log_DexPattred = new NpgsqlCommand(getTotal_Log_DexPattred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_DexPattred.ExecuteScalar().ToString());

                string getUser_DexPattred = "SELECT \"dex/patt red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPattred[i] + "'";
                NpgsqlCommand user_DexPattred = new NpgsqlCommand(getUser_DexPattred, cn);
                int user_DexPattredNo = Convert.ToInt32(user_DexPattred.ExecuteScalar().ToString());

                decimal newRank_DexPattred;
                if (total_Log1 == 0)
                {
                    newRank_DexPattred = 0;
                }
                else
                {
                    newRank_DexPattred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_DexPattredNo;
                }


                NpgsqlCommand update_UserDexPattred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank5\" = " + newRank_DexPattred + " Where \"Nickname\" ='" + PeopleForDexPattred[i] + "' ");
                update_UserDexPattred_Log.Connection = cn;
                update_UserDexPattred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void SetRankIntMattred(item username, string dungeonName)
        {
            List<String> PeopleForIntMattred = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMattred.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMattred.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMattred[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'int/matt red'";
                NpgsqlCommand Total_IntMattred = new NpgsqlCommand(getTotal_IntMattred, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMattred.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMattred = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_int/matt red'";
                NpgsqlCommand Total_Log_IntMattred = new NpgsqlCommand(getTotal_Log_IntMattred, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMattred.ExecuteScalar().ToString());

                string getUser_IntMattred = "SELECT \"int/matt red\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMattred[i] + "'";
                NpgsqlCommand user_IntMattred = new NpgsqlCommand(getUser_IntMattred, cn);
                int user_IntMattredNo = Convert.ToInt32(user_IntMattred.ExecuteScalar().ToString());

                decimal newRank_IntMattred;
                if (total_Log1 == 0)
                {
                    newRank_IntMattred = 0;
                }
                else
                {
                    newRank_IntMattred = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMattredNo;
                }


                NpgsqlCommand update_UserIntMattred_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank6\" = " + newRank_IntMattred + " Where \"Nickname\" ='" + PeopleForIntMattred[i] + "' ");
                update_UserIntMattred_Log.Connection = cn;
                update_UserIntMattred_Log.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void SetRankIntMatt(item username, string dungeonName)
        {
            List<String> PeopleForIntMatt = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMatt.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMatt.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'int/matt yellow'";
                NpgsqlCommand Total_IntMatt = new NpgsqlCommand(getTotal_IntMatt, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMatt.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_int/matt yellow'";
                NpgsqlCommand Total_Log_IntMatt = new NpgsqlCommand(getTotal_Log_IntMatt, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMatt.ExecuteScalar().ToString());

                string getUser_IntMatt = "SELECT \"int/matt yellow\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand user_IntMatt = new NpgsqlCommand(getUser_IntMatt, cn);
                int user_IntMattNo = Convert.ToInt32(user_IntMatt.ExecuteScalar().ToString());

                decimal newRank_IntMatt;
                if (total_Log1 == 0)
                {
                    newRank_IntMatt = 0;
                }
                else
                {
                    newRank_IntMatt = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMattNo;
                }


                NpgsqlCommand update_UserIntMatt_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank7\" = " + newRank_IntMatt + " Where \"Nickname\" ='" + PeopleForIntMatt[i] + "' ");
                update_UserIntMatt_Log.Connection = cn;
                update_UserIntMatt_Log.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void SetRankStrPatt(item username, string dungeonName)
        {
            List<String> PeopleForStrPatt = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForStrPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStrPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStrPatt.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStrPatt.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPatt[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StrPatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'str/patt yellow'";
                NpgsqlCommand Total_StrPatt = new NpgsqlCommand(getTotal_StrPatt, cn);
                decimal total1 = Convert.ToDecimal(Total_StrPatt.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StrPatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_str/patt yellow'";
                NpgsqlCommand Total_Log_StrPatt = new NpgsqlCommand(getTotal_Log_StrPatt, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StrPatt.ExecuteScalar().ToString());

                string getUser_StrPatt = "SELECT \"str/patt yellow\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForStrPatt[i] + "'";
                NpgsqlCommand user_StrPatt = new NpgsqlCommand(getUser_StrPatt, cn);
                int user_StrPattNo = Convert.ToInt32(user_StrPatt.ExecuteScalar().ToString());

                decimal newRank_StrPatt;
                if (total_Log1 == 0)
                {
                    newRank_StrPatt = 0;
                }
                else
                {
                    newRank_StrPatt = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StrPattNo;
                }


                NpgsqlCommand update_UserStrPatt_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank8\" = " + newRank_StrPatt + " Where \"Nickname\" ='" + PeopleForStrPatt[i] + "' ");
                update_UserStrPatt_Log.Connection = cn;
                update_UserStrPatt_Log.ExecuteNonQuery();
                cn.Close();
            }
        }
        public void SetRankDexPatt(item username, string dungeonName)
        {
            List<String> PeopleForDexPatt = new List<String>();
            string WSP = "";
            if (dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if (dungeonName == "SToES")
            {
                WSP = "WSP_SToES";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            string getPeopleForDexPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForDexPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForDexPatt.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForDexPatt.Count; i++)
            {
                cn.Open();
                string get_TotalFreq = "Select \"Total\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPatt[i] + "'";
                NpgsqlCommand TotalFreq = new NpgsqlCommand(get_TotalFreq, cn);
                double totalFreq = Convert.ToDouble(TotalFreq.ExecuteScalar().ToString());

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_DexPatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'dex/patt yellow'";
                NpgsqlCommand Total_DexPatt = new NpgsqlCommand(getTotal_DexPatt, cn);
                decimal total1 = Convert.ToDecimal(Total_DexPatt.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_DexPatt = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Log_dex/patt yellow'";
                NpgsqlCommand Total_Log_DexPatt = new NpgsqlCommand(getTotal_Log_DexPatt, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_DexPatt.ExecuteScalar().ToString());

                string getUser_DexPatt = "SELECT \"dex/patt yellow\" FROM public.\"" + dungeonName + "\" Where \"Nickname\" = '" + PeopleForDexPatt[i] + "'";
                NpgsqlCommand user_DexPatt = new NpgsqlCommand(getUser_DexPatt, cn);
                int user_DexPattNo = Convert.ToInt32(user_DexPatt.ExecuteScalar().ToString());

                decimal newRank_DexPatt;
                if (total_Log1 == 0)
                {
                    newRank_DexPatt = 0;
                }
                else
                {
                    newRank_DexPatt = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_DexPattNo;
                }


                NpgsqlCommand update_UserDexPatt_Log = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"rank9\" = " + newRank_DexPatt + " Where \"Nickname\" ='" + PeopleForDexPatt[i] + "' ");
                update_UserDexPatt_Log.Connection = cn;
                update_UserDexPatt_Log.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}