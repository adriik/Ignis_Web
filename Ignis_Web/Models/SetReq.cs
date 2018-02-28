using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class SetReq
    {
        public string Nick { get; set; }
        public string Set { get; set; }
        public string username { get; set; }
        public bool collect { get; set; }
        public string Nickname { get; set; }


        public string Instancje { get; set; }
        public string IBP { get; set; }
        public string SToES { get; set; }
        public bool checkIBP { get; set; }
        public bool checkSToES { get; set; }


        public SetReq(string Nickname)
        {
            this.Nickname = Nickname;//[0].ToString().ToUpper() + Nickname.Substring(1);
        }

        public SetReq()
        {

        }
        

    }
}