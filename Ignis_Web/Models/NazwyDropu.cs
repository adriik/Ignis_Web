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
            new NazwyDropu{Id=5, Name="Pas", Category="Skórzane"},
            new NazwyDropu{Id=6, Name="Peleryna", Category="Skórzane"},
            new NazwyDropu{Id=7, Name="Rękawice", Category="Skórzane"},
            new NazwyDropu{Id=8, Name="Spodnie", Category="Skórzane"},
            new NazwyDropu{Id=9, Name="Pas", Category="Kolcze"},
            new NazwyDropu{Id=10, Name="Peleryna", Category="Kolcze"},
            new NazwyDropu{Id=11, Name="Rękawice", Category="Kolcze"},
            new NazwyDropu{Id=12, Name="Spodnie", Category="Kolcze"},
            new NazwyDropu{Id=13, Name="Pas", Category="Płytowe"},
            new NazwyDropu{Id=14, Name="Peleryna", Category="Płytowe"},
            new NazwyDropu{Id=15, Name="Rękawice", Category="Płytowe"},
            new NazwyDropu{Id=16, Name="Spodnie", Category="Płytowe"},
            new NazwyDropu{Id=17, Name="Pas", Category="Healowe"},
            new NazwyDropu{Id=18, Name="Peleryna", Category="Healowe"},
            new NazwyDropu{Id=19, Name="Rękawice", Category="Healowe"},
            new NazwyDropu{Id=20, Name="Spodnie", Category="Healowe"},
            new NazwyDropu{Id=21, Name="Laska Magowa", Category="Bronie"},
            new NazwyDropu{Id=22, Name="Laska Healowa", Category="Bronie"},
            new NazwyDropu{Id=23, Name="Topór 2h", Category="Bronie"},
            new NazwyDropu{Id=24, Name="Sztylet", Category="Bronie"},
            new NazwyDropu{Id=25, Name="Kusza", Category="Bronie"},
            new NazwyDropu{Id=26, Name="Różdżka Magowa", Category="Bronie"},
            new NazwyDropu{Id=27, Name="Różdżka Healowa", Category="Bronie"},
            new NazwyDropu{Id=28, Name="sta/hp 251", Category="Stat"},
            new NazwyDropu{Id=29, Name="sta/wis 251", Category="Stat"},
            new NazwyDropu{Id=30, Name="sta/patt 251", Category="Stat"},
            new NazwyDropu{Id=31, Name="str/patt 251", Category="Stat"},
            new NazwyDropu{Id=32, Name="dex/patt 251", Category="Stat"},
            new NazwyDropu{Id=33, Name="int/matt 251", Category="Stat"},
            new NazwyDropu{Id=34, Name="int/matt", Category="Stat"},


        };
        }
    }
}