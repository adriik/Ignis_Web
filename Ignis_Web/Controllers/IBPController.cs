using Ignis_Web.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Controllers
{
    public class IBPController : Controller
    {
        CzlonekAccess czlonekAccess = new CzlonekAccess();
        DropAccess dropAccess = new DropAccess();
        static string dungeon = "IBP";
        public ActionResult Frequency()
        {
            Clear();
            TempData["Previous"] = this.Url.Action("Frequency", dungeon, null, this.Request.Url.Scheme);
            var lista = czlonekAccess.GetListaCzlonkow(dungeon);

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
            List<double> percentRank8 = new List<double>();
            List<double> percentRank9 = new List<double>();

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
                    percentRank8.Add(item.Stat8Rank);
                }

                if (item.Class == "Rouge" || item.Class == "Scout")
                {
                    percentRank5.Add(item.Stat5Rank);
                    percentRank9.Add(item.Stat9Rank);
                }

                if (item.Class == "Warlock" || item.Class == "Mage")
                {
                    percentRank6.Add(item.Stat6Rank);
                    percentRank7.Add(item.Stat7Rank);
                }
            }

            foreach (var item in listSortByClass)
            {
                if(MathNet.Numerics.ExcelFunctions.PercentRank(percentRank1.ToArray(), item.Stat1Rank) > 0.7)
                {
                    item.Stat1Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank2.ToArray(), item.Stat2Rank) > 0.7)
                {
                    item.Stat2Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank3.ToArray(), item.Stat3Rank) > 0.6)
                {
                    item.Stat3Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank4.ToArray(), item.Stat4Rank) > 0.75)
                {
                    item.Stat4Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank5.ToArray(), item.Stat5Rank) > 0.75)
                {
                    item.Stat5Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank6.ToArray(), item.Stat6Rank) > 0.70)
                {
                    item.Stat6Select = true;
                    
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank7.ToArray(), item.Stat7Rank) > 0.7)
                {
                    item.Stat7Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank8.ToArray(), item.Stat8Rank) > 0.75)
                {
                    item.Stat8Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank9.ToArray(), item.Stat9Rank) > 0.75)
                {
                    item.Stat9Select = true;
                }
            }
            UpdateRank();
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

            ViewBag.Stat8Total = Czlonek.Stat8Total;
            ViewBag.Stat8TotalRank = Czlonek.Stat8TotalRank;

            ViewBag.Stat9Total = Czlonek.Stat9Total;
            ViewBag.Stat9TotalRank = Czlonek.Stat9TotalRank;

            ViewBag.ParameterValueList = listSortByClass.ToSelectList(x => x.Nickname, false);
            //ViewBag.LocationList = allLocations.ToSelectList(x => x.Key, x => x.Value, myLocations /* selectedValues */);

            return View();
        }

        public ActionResult Summary()
        {
            Clear();
            TempData["Previous"] = this.Url.Action("Summary", dungeon, null, this.Request.Url.Scheme);
            var lista = czlonekAccess.GetListaCzlonkow(dungeon);

            List<Czlonek> listSortByClass = new List<Czlonek>();

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
            List<double> percentRank8 = new List<double>();
            List<double> percentRank9 = new List<double>();

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
                    percentRank8.Add(item.Stat8Rank);
                }

                if (item.Class == "Rouge" || item.Class == "Scout")
                {
                    percentRank5.Add(item.Stat5Rank);
                    percentRank9.Add(item.Stat9Rank);
                }

                if (item.Class == "Warlock" || item.Class == "Mage")
                {
                    percentRank6.Add(item.Stat6Rank);
                    percentRank7.Add(item.Stat7Rank);
                }
            }

            foreach (var item in listSortByClass)
            {
                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank1.ToArray(), item.Stat1Rank) > 0.7)
                {
                    item.Stat1Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank2.ToArray(), item.Stat2Rank) > 0.7)
                {
                    item.Stat2Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank3.ToArray(), item.Stat3Rank) > 0.6)
                {
                    item.Stat3Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank4.ToArray(), item.Stat4Rank) > 0.75)
                {
                    item.Stat4Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank5.ToArray(), item.Stat5Rank) > 0.75)
                {
                    item.Stat5Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank6.ToArray(), item.Stat6Rank) > 0.70)
                {
                    item.Stat6Select = true;

                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank7.ToArray(), item.Stat7Rank) > 0.7)
                {
                    item.Stat7Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank8.ToArray(), item.Stat8Rank) > 0.75)
                {
                    item.Stat8Select = true;
                }

                if (MathNet.Numerics.ExcelFunctions.PercentRank(percentRank9.ToArray(), item.Stat9Rank) > 0.75)
                {
                    item.Stat9Select = true;
                }
            }
            UpdateRank();
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

            ViewBag.Stat8Total = Czlonek.Stat8Total;
            ViewBag.Stat8TotalRank = Czlonek.Stat8TotalRank;

            ViewBag.Stat9Total = Czlonek.Stat9Total;
            ViewBag.Stat9TotalRank = Czlonek.Stat9TotalRank;

            ViewBag.ParameterValueList = listSortByClass.ToSelectList(x => x.Nickname, false);
            //ViewBag.LocationList = allLocations.ToSelectList(x => x.Key, x => x.Value, myLocations /* selectedValues */);

            return View();
        }

        public ActionResult Items()
        {
            TempData["Previous"] = this.Url.Action("Items", dungeon, null, this.Request.Url.Scheme);
            List<Drop> listDrop = dropAccess.GetListaDrop(dungeon);

            List<Drop> listPlate = new List<Drop>();
            List<Drop> listChain = new List<Drop>();
            List<Drop> listLeather = new List<Drop>();
            List<Drop> listCloth = new List<Drop>();
            List<Drop> listWeapon = new List<Drop>();
            List<Drop> listHeal = new List<Drop>();

            foreach (var person in listDrop)
            {
                foreach (var item in person.ItemList)
                {
                    if (item.Type == "Plytowe")
                    {
                        listPlate.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                    else if (item.Type == "Kolcze")
                    {
                        listChain.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                    else if (item.Type == "Magowe")
                    {
                        listCloth.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                    else if (item.Type == "Skorzane")
                    {
                        listLeather.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                    else if (item.Type == "Healowe")
                    {
                        listHeal.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                    else
                    {
                        listWeapon.Add(new Drop(person.Nickname, item.Name, dungeon));
                    }
                }
            }


            ViewBag.listPlate = listPlate;
            ViewBag.listChain = listChain;
            ViewBag.listLeather = listLeather;
            ViewBag.listCloth = listCloth;
            ViewBag.listWeapon = listWeapon;
            ViewBag.listHeal = listHeal;

            return View();
        }

        private void Clear()
        {
            Czlonek.TotalAll = 0;
            Czlonek.GoldTotalAll = 0;

            Czlonek.Stat1Total = 0;
            Czlonek.Stat1TotalRank = 0;

            Czlonek.Stat2Total = 0;
            Czlonek.Stat2TotalRank = 0;

            Czlonek.Stat3Total = 0;
            Czlonek.Stat3TotalRank = 0;

            Czlonek.Stat4Total = 0;
            Czlonek.Stat4TotalRank = 0;

            Czlonek.Stat5Total = 0;
            Czlonek.Stat5TotalRank = 0;

            Czlonek.Stat6Total = 0;
            Czlonek.Stat6TotalRank = 0;

            Czlonek.Stat7Total = 0;
            Czlonek.Stat7TotalRank = 0;

            Czlonek.Stat8Total = 0;
            Czlonek.Stat8TotalRank = 0;

            Czlonek.Stat9Total = 0;
            Czlonek.Stat9TotalRank = 0;
        }

        private void UpdateRank()
        {
            czlonekAccess.SetRank(dungeon);
        }
    }
}