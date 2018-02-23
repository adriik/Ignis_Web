using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class NazwyDropu
    {
        //Dropdown
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public static List<NazwyDropu> GetItems()
        {
            return new List<NazwyDropu>{
            new NazwyDropu{Id=1, Name="Pas", Category="Magowe"},
            new NazwyDropu{Id=2, Name="Peleryna", Category="Magowe"},
            new NazwyDropu{Id=3, Name="Rękawice", Category="Magowe"},
            new NazwyDropu{Id=4, Name="Spodnie", Category="Magowe"},
            new NazwyDropu{Id=5, Name="Buty", Category="Magowe"},
            new NazwyDropu{Id=6, Name="Czapka", Category="Magowe"},
            new NazwyDropu{Id=7, Name="Naramienniki", Category="Magowe"},
            new NazwyDropu{Id=8, Name="Szata", Category="Magowe"},
            new NazwyDropu{Id=9, Name="Pas", Category="Healowe"},
            new NazwyDropu{Id=10, Name="Peleryna", Category="Healowe"},
            new NazwyDropu{Id=11, Name="Rękawice", Category="Healowe"},
            new NazwyDropu{Id=12, Name="Spodnie", Category="Healowe"},
            new NazwyDropu{Id=13, Name="Buty", Category="Healowe"},
            new NazwyDropu{Id=14, Name="Czapka", Category="Healowe"},
            new NazwyDropu{Id=15, Name="Naramienniki", Category="Healowe"},
            new NazwyDropu{Id=16, Name="Szata", Category="Healowe"},
            new NazwyDropu{Id=17, Name="Pas", Category="Skórzane"},
            new NazwyDropu{Id=18, Name="Peleryna", Category="Skórzane"},
            new NazwyDropu{Id=19, Name="Rękawice", Category="Skórzane"},
            new NazwyDropu{Id=20, Name="Spodnie", Category="Skórzane"},
            new NazwyDropu{Id=21, Name="Buty", Category="Skórzane"},
            new NazwyDropu{Id=22, Name="Czapka", Category="Skórzane"},
            new NazwyDropu{Id=23, Name="Naramienniki", Category="Skórzane"},
            new NazwyDropu{Id=24, Name="Zbroja", Category="Skórzane"},
            new NazwyDropu{Id=25, Name="Pas", Category="Kolcze"},
            new NazwyDropu{Id=26, Name="Peleryna", Category="Kolcze"},
            new NazwyDropu{Id=27, Name="Rękawice", Category="Kolcze"},
            new NazwyDropu{Id=28, Name="Spodnie", Category="Kolcze"},
            new NazwyDropu{Id=29, Name="Buty", Category="Kolcze"},
            new NazwyDropu{Id=30, Name="Czapka", Category="Kolcze"},
            new NazwyDropu{Id=31, Name="Naramienniki", Category="Kolcze"},
            new NazwyDropu{Id=32, Name="Zbroja", Category="Kolcze"},
            new NazwyDropu{Id=33, Name="Pas", Category="Płytowe"},
            new NazwyDropu{Id=34, Name="Peleryna", Category="Płytowe"},
            new NazwyDropu{Id=35, Name="Rękawice", Category="Płytowe"},
            new NazwyDropu{Id=36, Name="Spodnie", Category="Płytowe"},
            new NazwyDropu{Id=37, Name="Buty", Category="Płytowe"},
            new NazwyDropu{Id=38, Name="Czapka", Category="Płytowe"},
            new NazwyDropu{Id=39, Name="Naramienniki", Category="Płytowe"},
            new NazwyDropu{Id=40, Name="Zbroja", Category="Płytowe"},
            new NazwyDropu{Id=41, Name="Laska Magowa", Category="Bronie"},
            new NazwyDropu{Id=42, Name="Laska Healowa", Category="Bronie"},
            new NazwyDropu{Id=43, Name="Różdżka Magowa", Category="Bronie"},
            new NazwyDropu{Id=44, Name="Różdżka Healowa", Category="Bronie"},
            new NazwyDropu{Id=45, Name="Sztylet", Category="Bronie"},
            new NazwyDropu{Id=46, Name="Topór 2h", Category="Bronie"},
            new NazwyDropu{Id=47, Name="Topór 1h", Category="Bronie"},
            new NazwyDropu{Id=48, Name="Młot 2h", Category="Bronie"},
            new NazwyDropu{Id=49, Name="Młot 1h", Category="Bronie"},
            new NazwyDropu{Id=50, Name="Tarcza Tankowa", Category="Bronie"},
            new NazwyDropu{Id=51, Name="Tarcza Healowa", Category="Bronie"},
            new NazwyDropu{Id=52, Name="Miecz 2h", Category="Bronie"},
            new NazwyDropu{Id=53, Name="Miecz 1h", Category="Bronie"},
            new NazwyDropu{Id=54, Name="Talizman Magowy", Category="Bronie"},
            new NazwyDropu{Id=55, Name="Talizman Healowy", Category="Bronie"},
            new NazwyDropu{Id=56, Name="Kusza", Category="Bronie"},
            new NazwyDropu{Id=57, Name="Łuk", Category="Bronie"},
            new NazwyDropu{Id=58, Name="sta/hp red", Category="Stat"},
            new NazwyDropu{Id=59, Name="sta/wis red", Category="Stat"},
            new NazwyDropu{Id=60, Name="sta/patt red", Category="Stat"},
            new NazwyDropu{Id=61, Name="str/patt red", Category="Stat"},
            new NazwyDropu{Id=62, Name="dex/patt red", Category="Stat"},
            new NazwyDropu{Id=63, Name="int/matt red", Category="Stat"},
            new NazwyDropu{Id=64, Name="int/matt yellow", Category="Stat"},
            new NazwyDropu{Id=65, Name="str/patt yellow", Category="Stat"},
            new NazwyDropu{Id=66, Name="dex/patt yellow", Category="Stat"},
            
        };
        }
    }
}