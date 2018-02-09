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
            new NazwyDropu{Id=2, Name="Pas", Category="Magowe"},
            new NazwyDropu{Id=3, Name="Peleryna", Category="Magowe"},
            new NazwyDropu{Id=4, Name="Rękawice", Category="Magowe"},
            new NazwyDropu{Id=5, Name="Spodnie", Category="Magowe"},
            new NazwyDropu{Id=6, Name="Pas", Category="Skórzane"},
            new NazwyDropu{Id=7, Name="Peleryna", Category="Skórzane"},
            new NazwyDropu{Id=8, Name="Rękawice", Category="Skórzane"},
            new NazwyDropu{Id=9, Name="Spodnie", Category="Skórzane"},
            new NazwyDropu{Id=10, Name="Pas", Category="Kolcze"},
            new NazwyDropu{Id=11, Name="Peleryna", Category="Kolcze"},
            new NazwyDropu{Id=12, Name="Rękawice", Category="Kolcze"},
            new NazwyDropu{Id=13, Name="Spodnie", Category="Kolcze"},
            new NazwyDropu{Id=14, Name="Pas", Category="Płytowe"},
            new NazwyDropu{Id=15, Name="Peleryna", Category="Płytowe"},
            new NazwyDropu{Id=16, Name="Rękawice", Category="Płytowe"},
            new NazwyDropu{Id=17, Name="Spodnie", Category="Płytowe"},
            new NazwyDropu{Id=18, Name="Laska Magowa", Category="Bronie"},
            new NazwyDropu{Id=19, Name="Laska Healowa", Category="Bronie"},
            new NazwyDropu{Id=20, Name="Topór 2h", Category="Bronie"},
            new NazwyDropu{Id=21, Name="Sztylet", Category="Bronie"},
            new NazwyDropu{Id=22, Name="Kusza", Category="Bronie"},
            new NazwyDropu{Id=23, Name="Różdżka Magowa", Category="Bronie"},
            new NazwyDropu{Id=24, Name="Różdżka Healowa", Category="Bronie"},


        };
        }
    }
}