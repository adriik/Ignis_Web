using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class Itemki
    {

        //Label
        public string Typ { get; set; }
        public string Nazwa { get; set; }
        public string Dura { get; set; }
        public string Dostał { get; set; }
        public string Set { get; set; }

        //
        public string item { get; set; }
        public string stat { get; set; }
        public string typyDropu { get; set; }
        public Itemki(string typyDropu)
        {
            this.typyDropu = typyDropu;//[0].ToString().ToUpper() + Nickname.Substring(1);

        }
        public Itemki()
        {

        }
        public string Nickname { get; set; }
        
        //Typ Dropu (Item/Stat)
        public string Drop_Type1 { get; set; }
        public string Drop_Type2 { get; set; }
        public string Drop_Type3 { get; set; }
        public string Drop_Type4 { get; set; }
        public string Drop_Type5 { get; set; }
        public string Drop_Type6 { get; set; }
        public string Drop_Type7 { get; set; }
        public string Drop_Type8 { get; set; }
        public string Drop_Type9 { get; set; }
        //Staty
        public string Stat_Drop1 { get; set; }
        public string Stat_Drop2 { get; set; }
        public string Stat_Drop3 { get; set; }
        public string Stat_Drop4 { get; set; }
        public string Stat_Drop5 { get; set; }
        public string Stat_Drop6 { get; set; }
        public string Stat_Drop7 { get; set; }
        public string Stat_Drop8 { get; set; }
        public string Stat_Drop9 { get; set; }
        //Itemy
        public string Item_Drop1 { get; set; }
        public string Item_Drop2 { get; set; }
        public string Item_Drop3 { get; set; }
        public string Item_Drop4 { get; set; }
        public string Item_Drop5 { get; set; }
        public string Item_Drop6 { get; set; }
        public string Item_Drop7 { get; set; }
        public string Item_Drop8 { get; set; }
        public string Item_Drop9 { get; set; }
        //Item do setu czy na sell
        public bool Item_Set1 { get; set; }
        public bool Item_Set2 { get; set; }
        public bool Item_Set3 { get; set; }
        public bool Item_Set4 { get; set; }
        public bool Item_Set5 { get; set; }
        public bool Item_Set6 { get; set; }
        public bool Item_Set7 { get; set; }
        public bool Item_Set8 { get; set; }
        public bool Item_Set9 { get; set; }
        //Dura itemu
        public int Item_Dura1 { get; set; }
        public int Item_Dura2 { get; set; }
        public int Item_Dura3 { get; set; }
        public int Item_Dura4 { get; set; }
        public int Item_Dura5 { get; set; }
        public int Item_Dura6 { get; set; }
        public int Item_Dura7 { get; set; }
        public int Item_Dura8 { get; set; }
        public int Item_Dura9 { get; set; }
        //Zdobywca dropu
        public string Drop_Receiver1 { get; set; }
        public string Drop_Receiver2 { get; set; }
        public string Drop_Receiver3 { get; set; }
        public string Drop_Receiver4 { get; set; }
        public string Drop_Receiver5 { get; set; }
        public string Drop_Receiver6 { get; set; }
        public string Drop_Receiver7 { get; set; }
        public string Drop_Receiver8 { get; set; }
        public string Drop_Receiver9 { get; set; }
    }
}