﻿using Ignis_Web.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
                        lista.Add(new Czlonek(reader.GetString(0)));
                    }
                }
            }
            //List<Czlonek> lista2 = new List<Czlonek>(lista);
            //lista2.Sort((emp1, emp2) => emp1.Stat1Rank.CompareTo(emp2.Stat1Rank));


            //foreach (var item in lista2.Skip(Math.Max(0, lista.Count() - 3)))
            //{
            //    System.Diagnostics.Debug.WriteLine("Uzytkownik: " + item.Nickname + "Rank: " + item.Stat1Rank);

            //}
            //lista.Sort((emp1, emp2) => emp1.Nickname.CompareTo(emp2.Nickname));
            //lista.Sort((emp1, emp2) => emp1.Class.CompareTo(emp2.Class));

            List<Czlonek>listSortByClass = new List<Czlonek>();
            
            foreach (var item in lista)
            {
                if (item.Class == "Druid")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid green;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Priest")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid cornflowerblue;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Knight")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid yellow;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Warden")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid rebeccapurple;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Champion")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid royalblue;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Rouge")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid deepskyblue;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Scout")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid forestgreen;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Mage")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid darkorange;";
                }
            }

            foreach (var item in lista)
            {
                if (item.Class == "Warlock")
                {
                    listSortByClass.Add(item);
                    item.Kolor = "border-left: solid saddlebrown;";
                }
            }

            double Total1 = 0;
            double Total2 = 0;
            double Total3 = 0;
            double Total4 = 0;
            double Total5 = 0;
            double Total6 = 0;
            double Total7 = 0;

            List<double> percentRank1 = new List<double>();
            List<double> percentRank2 = new List<double>();
            List<double> percentRank3 = new List<double>();
            List<double> percentRank4 = new List<double>();
            List<double> percentRank5 = new List<double>();
            List<double> percentRank6 = new List<double>();
            List<double> percentRank7 = new List<double>();

            foreach (var item in listSortByClass)
            {
                //System.Diagnostics.Debug.WriteLine("Klasa: " + item.Class);
                if (item.Class == "Druid" || item.Class == "Knight" || item.Class == "Priest")
                {
                    percentRank1.Add(item.Stat1Rank);
                }

                if (item.Class == "Druid" || item.Class == "Priest")
                {
                    percentRank2.Add(item.Stat2Rank);
                }

                if (item.Class == "Knight")
                {
                    percentRank3.Add(item.Stat3Rank);
                }

                if (item.Class == "Warden" || item.Class == "Rouge" || item.Class == "Scout" || item.Class == "Warrior" || item.Class == "Champion")
                {
                    percentRank4.Add(item.Stat4Rank);
                }

                if (item.Class == "Rouge" || item.Class == "Scout")
                {
                    percentRank5.Add(item.Stat5Rank);
                }

                if (item.Class == "Warlock" || item.Class == "Mage")
                {
                    percentRank6.Add(item.Stat6Rank);
                    percentRank7.Add(item.Stat7Rank);
                }
            }

            foreach (var item in listSortByClass)
            {
                if(PercentRank(percentRank1, item.Stat1Rank) > 0.7)
                {
                    item.Stat1Select = true;
                }

                if (PercentRank(percentRank2, item.Stat2Rank) > 0.7)
                {
                    item.Stat2Select = true;
                }

                if (PercentRank(percentRank3, item.Stat3Rank) > 0.6)
                {
                    item.Stat3Select = true;
                }

                if (PercentRank(percentRank4, item.Stat4Rank) > 0.75)
                {
                    item.Stat4Select = true;
                }

                if (PercentRank(percentRank5, item.Stat5Rank) > 0.75)
                {
                    item.Stat5Select = true;
                }

                if (PercentRank(percentRank6, item.Stat6Rank) > 0.70)
                {
                    item.Stat6Select = true;
                    
                }

                if (PercentRank(percentRank7, item.Stat7Rank) > 0.7)
                {
                    item.Stat7Select = true;
                }
            }

            //list.Sort( (emp1,emp2)=>emp1.FirstName.CompareTo(emp2.FirstName) );
            ViewBag.People = listSortByClass;
            ViewBag.TotalAll = Czlonek.TotalAll;
            ViewBag.GoldTotalAll = Czlonek.GoldTotalAll;

            ViewBag.Stat1Total = Czlonek.Stat1Total;
            ViewBag.Stat1TotalRank = Czlonek.Stat1TotalRank;

            ViewBag.Stat2Total = Czlonek.Stat2Total;
            ViewBag.Stat2TotalRank = Czlonek.Stat2TotalRank;

            ViewBag.Stat3Total = Czlonek.Stat3Total;
            ViewBag.Stat3TotalRank = Czlonek.Stat3TotalRank;

            ViewBag.Stat4Total = Czlonek.Stat4Total;
            ViewBag.Stat4TotalRank = Czlonek.Stat4TotalRank;

            ViewBag.Stat5Total = Czlonek.Stat5Total;
            ViewBag.Stat5TotalRank = Czlonek.Stat5TotalRank;

            ViewBag.Stat6Total = Czlonek.Stat6Total;
            ViewBag.Stat6TotalRank = Czlonek.Stat6TotalRank;

            ViewBag.Stat7Total = Czlonek.Stat7Total;
            ViewBag.Stat7TotalRank = Czlonek.Stat7TotalRank;

            ViewBag.ParameterValueList = listSortByClass.ToSelectList(x => x.Nickname, false);
            //ViewBag.LocationList = allLocations.ToSelectList(x => x.Key, x => x.Value, myLocations /* selectedValues */);


            cn.Close();

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private static double PercentRank(List<double> matrix, double value)
        {
            matrix.Sort();

            for (int i = 0; i < matrix.Count; i++)
                if (matrix[i] == value)
                    return ((double)i) / (matrix.Count - 1);

            // calculate value using linear interpolation
            double x1, x2, y1, y2;

            for (int i = 0; i < matrix.Count - 1; i++)
            {
                if (matrix[i] < value && value < matrix[i + 1])
                {
                    x1 = matrix[i];
                    x2 = matrix[i + 1];
                    y1 = PercentRank(matrix, x1);
                    y2 = PercentRank(matrix, x2);

                    return (((x2 - value) * y1 + (value - x1) * y2)) / (x2 - x1);
                }
            }

            throw new Exception("Out of bounds");
        }
    }
}