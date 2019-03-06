using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Ignis_Web.Models
{
    public class FreqAccess
    {
        public void SetFreq(List<String> ListaGraczy, List<String> FirstBossLists, List<String> SecondBossLists, List<String> ThirdBossLists, List<String> FourthBossLists, List<String> FifthBossLists, string Dungeon)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            for (var i = 0; i < ListaGraczy.Count; i++)
            {
                if (FirstBossLists[i].ToString() == "1")
                {
                    cn.Open();
                    string queryStr = "Select \"First Boss\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + ListaGraczy[i] + "'";
                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                    temp = temp + 1;
                    NpgsqlCommand update_FirstBoss = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"First Boss\" = " + temp + " Where \"Nickname\" ='" + ListaGraczy[i] + "' ");
                    update_FirstBoss.Connection = cn;
                    update_FirstBoss.ExecuteNonQuery();
                    cn.Close();


                }
                if (SecondBossLists[i].ToString() == "1")
                {
                    cn.Open();
                    string queryStr2 = "Select \"Second Boss\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + ListaGraczy[i] + "'";
                    NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                    int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());
                    temp2 = temp2 + 1;
                    NpgsqlCommand update_SecondBoss = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Second Boss\" = " + temp2 + " Where \"Nickname\" ='" + ListaGraczy[i] + "' ");
                    update_SecondBoss.Connection = cn;
                    update_SecondBoss.ExecuteNonQuery();
                    cn.Close();
                }
                if (ThirdBossLists[i].ToString() == "1")
                {
                    cn.Open();
                    string queryStr3 = "Select \"Third Boss\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + ListaGraczy[i] + "'";
                    NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                    int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());
                    temp3 = temp3 + 1;
                    NpgsqlCommand update_thirdBoss = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Third Boss\" = " + temp3 + " Where \"Nickname\" ='" + ListaGraczy[i] + "' ");
                    update_thirdBoss.Connection = cn;
                    update_thirdBoss.ExecuteNonQuery();
                    cn.Close();
                }
                if (FourthBossLists[i].ToString() == "1")
                {
                    cn.Open();
                    string queryStr4 = "Select \"Fourth Boss\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + ListaGraczy[i] + "'";
                    NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                    int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());
                    temp4 = temp4 + 1;
                    NpgsqlCommand update_FourthBoss = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Fourth Boss\" = " + temp4 + " Where \"Nickname\" ='" + ListaGraczy[i] + "' ");
                    update_FourthBoss.Connection = cn;
                    update_FourthBoss.ExecuteNonQuery();
                    cn.Close();
                }
                if (FifthBossLists[i].ToString() == "1")
                {
                    cn.Open();
                    string queryStr5 = "Select \"Fifth Boss\" from  public.\"" + Dungeon + "\" Where \"Nickname\" = '" + ListaGraczy[i] + "'";
                    NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                    int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());
                    temp5 = temp5 + 1;
                    NpgsqlCommand update_FifthBoss = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Fifth Boss\" = " + temp5 + " Where \"Nickname\" ='" + ListaGraczy[i] + "' ");
                    update_FifthBoss.Connection = cn;
                    update_FifthBoss.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }

        public void SetCoquin(item username, string dungeonName)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            double FirstCoquinn;
            double SecondCoquinn;
            double ThirdCoquinn;
            double FourthCoquinn;
            double FifthCoquinn;
            var IBP_Dungeon = username.checkIBP;
            var SToES_Dungeon = username.checkSToES;

            cn.Open();
            string FirstVax = "Select \"First Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFirstBoss1 = new NpgsqlCommand(FirstVax, cn);
            int Boss1_Vax = Convert.ToInt32(checkFirstBoss1.ExecuteScalar().ToString());
            string SecondVax = "Select \"Second Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkSecondBoss1 = new NpgsqlCommand(SecondVax, cn);
            int Boss2_Vax = Convert.ToInt32(checkSecondBoss1.ExecuteScalar().ToString());
            string ThirdVax = "Select \"Third Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkThirdBoss1 = new NpgsqlCommand(ThirdVax, cn);
            int Boss3_Vax = Convert.ToInt32(checkThirdBoss1.ExecuteScalar().ToString());
            string FourthVax = "Select \"Fourth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFourthBoss1 = new NpgsqlCommand(FourthVax, cn);
            int Boss4_Vax = Convert.ToInt32(checkFourthBoss1.ExecuteScalar().ToString());
            string FifthVax = "Select \"Fifth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFifthBoss1 = new NpgsqlCommand(FifthVax, cn);
            int Boss5_Vax = Convert.ToInt32(checkFifthBoss1.ExecuteScalar().ToString());

            string FirstSou = "Select \"First Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFirstBoss2 = new NpgsqlCommand(FirstSou, cn);
            int Boss1_Sou = Convert.ToInt32(checkFirstBoss2.ExecuteScalar().ToString());
            string SecondSou = "Select \"Second Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkSecondBoss2 = new NpgsqlCommand(SecondSou, cn);
            int Boss2_Sou = Convert.ToInt32(checkSecondBoss2.ExecuteScalar().ToString());
            string ThirdSou = "Select \"Third Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkThirdBoss2 = new NpgsqlCommand(ThirdSou, cn);
            int Boss3_Sou = Convert.ToInt32(checkThirdBoss2.ExecuteScalar().ToString());
            string FourthSou = "Select \"Fourth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFourthBoss2 = new NpgsqlCommand(FourthSou, cn);
            int Boss4_Sou = Convert.ToInt32(checkFourthBoss2.ExecuteScalar().ToString());
            string FifthSou = "Select \"Fifth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFifthBoss2 = new NpgsqlCommand(FifthSou, cn);
            int Boss5_Sou = Convert.ToInt32(checkFifthBoss2.ExecuteScalar().ToString());

            FirstCoquinn = ((double)Boss1_Sou + (double)Boss1_Vax) / (double)2;
            SecondCoquinn = ((double)Boss2_Sou + (double)Boss2_Vax) / (double)2;
            ThirdCoquinn = ((double)Boss3_Sou + (double)Boss3_Vax) / (double)2;
            FourthCoquinn = ((double)Boss4_Sou + (double)Boss4_Vax) / (double)2;
            FifthCoquinn = ((double)Boss5_Sou + (double)Boss5_Vax) / (double)2;
            int FirstCoquinn1 = Convert.ToInt32(Math.Round(FirstCoquinn, MidpointRounding.AwayFromZero));
            int SecondCoquinn1 = Convert.ToInt32(Math.Round(SecondCoquinn, MidpointRounding.AwayFromZero));
            int ThirdCoquinn1 = Convert.ToInt32(Math.Round(ThirdCoquinn, MidpointRounding.AwayFromZero));
            int FourthCoquinn1 = Convert.ToInt32(Math.Round(FourthCoquinn, MidpointRounding.AwayFromZero));
            int FifthCoquinn1 = Convert.ToInt32(Math.Round(FifthCoquinn, MidpointRounding.AwayFromZero));

            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"First Boss\" = " + FirstCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd1.Connection = cn;
            cmd1.ExecuteNonQuery();

            NpgsqlCommand cmd2 = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Second Boss\" = " + SecondCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd2.Connection = cn;
            cmd2.ExecuteNonQuery();

            NpgsqlCommand cmd3 = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Third Boss\" = " + ThirdCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd3.Connection = cn;
            cmd3.ExecuteNonQuery();

            NpgsqlCommand cmd4 = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Fourth Boss\" = " + FourthCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd4.Connection = cn;
            cmd4.ExecuteNonQuery();

            NpgsqlCommand cmd5 = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Fifth Boss\" = " + FifthCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd5.Connection = cn;
            cmd5.ExecuteNonQuery();
            cn.Close();
        }

        public void SetTotalFreq(string dungeonName)
        {
            List<String> columnData = new List<String>();
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
            string query = "SELECT \"Nickname\" FROM public.\"" + dungeonName + "\"";
            using (NpgsqlCommand command = new NpgsqlCommand(query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columnData.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();

            columnData = columnData.Select(t => Regex.Replace(t, @"\s+", "")).ToList();
            for (var i = 0; i < columnData.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"" + dungeonName + "\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                string queryA1Field = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'A1'";
                NpgsqlCommand checkA1Field = new NpgsqlCommand(queryA1Field, cn);
                int A1 = Convert.ToInt32(checkA1Field.ExecuteScalar().ToString());

                string Boss1 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Boss1_Multi'";
                NpgsqlCommand Multi1 = new NpgsqlCommand(Boss1, cn);
                double BossMulti1 = Convert.ToDouble(Multi1.ExecuteScalar().ToString());

                string Boss2 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Boss2_Multi'";
                NpgsqlCommand Multi2 = new NpgsqlCommand(Boss2, cn);
                double BossMulti2 = Convert.ToDouble(Multi2.ExecuteScalar().ToString());

                string Boss3 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Boss3_Multi'";
                NpgsqlCommand Multi3 = new NpgsqlCommand(Boss3, cn);
                double BossMulti3 = Convert.ToDouble(Multi3.ExecuteScalar().ToString());

                string Boss4 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Boss4_Multi'";
                NpgsqlCommand Multi4 = new NpgsqlCommand(Boss4, cn);
                double BossMulti4 = Convert.ToDouble(Multi4.ExecuteScalar().ToString());

                string Boss5 = "Select \"WSP\" from  public.\"" + WSP + "\" Where \"WSP_Name\" = 'Boss5_Multi'";
                NpgsqlCommand Multi5 = new NpgsqlCommand(Boss5, cn);
                double BossMulti5 = Convert.ToDouble(Multi5.ExecuteScalar().ToString());

                double totalFreq = (BossMulti1 * temp) + (BossMulti2 * temp2) + (BossMulti3 * temp3) + (BossMulti4 * temp4) + (BossMulti5 * temp5);
                string dotTotalFrew = totalFreq.ToString().Replace(",", ".");
                double goldLog = A1 * Math.Log10((totalFreq + A1) / A1);
                goldLog = Math.Round(goldLog, 2);
                string dotGoldLog = goldLog.ToString().Replace(",", ".");
                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);
                string dotStatLog = statLog.ToString().Replace(",", ".");
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Total\" = '" + dotTotalFrew + "' Where \"Nickname\" ='" + columnData[i] + "' ");
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                NpgsqlCommand update_LogGold = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Gold-Logarithm\" = '" + dotGoldLog + "' Where \"Nickname\" ='" + columnData[i] + "' ");
                update_LogGold.Connection = cn;
                update_LogGold.ExecuteNonQuery();

                NpgsqlCommand update_LogStat = new NpgsqlCommand("UPDATE public.\"" + dungeonName + "\" SET \"Stat-Logarithm\" = '" + dotStatLog + "' Where \"Nickname\" ='" + columnData[i] + "' ");
                update_LogStat.Connection = cn;
                update_LogStat.ExecuteNonQuery();

                cn.Close();

            }
        }

        public void SetAllStat(string dungeonName)
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

            int totalStat_StaHpred = 0;
            int totalStat_StaWis51 = 0;
            int totalStat_StaPattred = 0;
            int totalStat_StrPattred = 0;
            int totalStat_DexPattred = 0;
            int totalStat_IntMattred = 0;
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

                totalStat_StaHpred = totalStat_StaHpred + Total_StaHpred[c];
            }
            NpgsqlCommand Update_Total_StaHpred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaHpred + " Where \"WSP_Name\" ='sta/hp red'");
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

                totalStat_StaWis51 = totalStat_StaWis51 + Total_StaWisred[c];
            }
            NpgsqlCommand Update_Total_StaWisred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaWis51 + " Where \"WSP_Name\" ='sta/wis red'");
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

                totalStat_StaPattred = totalStat_StaPattred + Total_StaPattred[c];
            }
            NpgsqlCommand Update_Total_StaPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StaPattred + " Where \"WSP_Name\" ='sta/patt red'");
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

                totalStat_StrPattred = totalStat_StrPattred + Total_StrPattred[c];
            }
            NpgsqlCommand Update_Total_StrPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_StrPattred + " Where \"WSP_Name\" ='str/patt red'");
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

                totalStat_DexPattred = totalStat_DexPattred + Total_DexPattred[c];
            }
            NpgsqlCommand Update_Total_DexPattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_DexPattred + " Where \"WSP_Name\" ='dex/patt red'");
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

                totalStat_IntMattred = totalStat_IntMattred + Total_IntMattred[c];
            }
            NpgsqlCommand Update_Total_IntMattred = new NpgsqlCommand("UPDATE public.\"" + WSP + "\" SET \"WSP\" = " + totalStat_IntMattred + " Where \"WSP_Name\" ='int/matt red'");
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
    }
}