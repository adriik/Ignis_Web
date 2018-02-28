using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Ignis_Web.Models;
using Npgsql;

namespace Ignis_Web.Controllers
{
    public class FreqAppController : Controller
    {
        // GET: FreqApp
        public ActionResult FreqAppka()
        {
            if (Session["user"] != null)
            {
                var lista = new List<item>();
                //s = s[0].ToUpper() + s.Substring(1);
                NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
                cn.Open();
                string QueryPeople = "SELECT public.\"People\".\"Nickname\" FROM public.\"People\"";
                using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new item(reader.GetString(0)));
                        }
                    }
                }
                ViewBag.ListaLudzi = lista.ToSelectList(x => x.Nickname, false);

                cn.Close();
                return View();
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Login",
                });
            }
        }
        [HttpPost]
        public ActionResult FreqAppka(item username)
        {
            TempData.Remove("FreqSucc");
            //Nicki Graczy obecnych na instancji
            var FirstMember = username.FirstNickname;           var SecondMember = username.SecondNickname;
            var ThirdMember = username.ThirdNickname;           var FourthMember = username.FourthNickname;
            var FifthMember = username.FifthNickname;           var SixthMember = username.SixthNickname;
            var SeventhMember = username.SeventhNickname;       var EighthMember = username.EighthNickname;
            var NinthMember = username.NinthNickname;           var TenthMember = username.TenthNickname;
            var EleventhMember = username.EleventhNickname;     var TwelfthMember = username.TwelfthNickname;
            var FirstReserveMember = username.R_FirstNickname;  var SecondReserveMember = username.R_SecondNickname;
            var ThirdReserveMember = username.R_ThirdNickname;  var FourthReserveMember = username.R_FourthNickname;
            var FifthReserveMember = username.R_FifthNickname;
            //Tworzenie listy na bazie graczy
            List<String> ListaGraczy = new List<String>();
            ListaGraczy.Add(FirstMember);           ListaGraczy.Add(SecondMember);
            ListaGraczy.Add(ThirdMember);           ListaGraczy.Add(FourthMember);
            ListaGraczy.Add(FifthMember);           ListaGraczy.Add(SixthMember);
            ListaGraczy.Add(SeventhMember);        ListaGraczy.Add(EighthMember);
            ListaGraczy.Add(NinthMember);           ListaGraczy.Add(TenthMember);
            ListaGraczy.Add(EleventhMember);        ListaGraczy.Add(TwelfthMember);
            ListaGraczy.Add(FirstReserveMember);    ListaGraczy.Add(SecondReserveMember);
            ListaGraczy.Add(ThirdReserveMember);    ListaGraczy.Add(FourthReserveMember);
            ListaGraczy.Add(FifthReserveMember);
            ListaGraczy.RemoveAll(str => String.IsNullOrEmpty(str));
            if (ListaGraczy.Count != ListaGraczy.Distinct().Count())
            {
                TempData["FreqVal"] = false;
                return RedirectToAction("FreqAppka");
            }
            //Instancje
            var IBP_Dungeon = username.checkIBP;
            var SToES_Dungeon = username.checkSToES;
            string Dungeon = "";
            //Sprawdzenie czy instancja zostala wybrana i jaka zostala wybrana.
            if(IBP_Dungeon == false && SToES_Dungeon == false)
            {
                TempData["Dung"] = false;
                return RedirectToAction("FreqAppka");
            }
            if(IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if(SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }

            //Frekwencja na kazdym bossie
            int FirstFreqNo1 = 0; int FirstFreqNo2 = 0; int FirstFreqNo3 = 0; int FirstFreqNo4 = 0; int FirstFreqNo5 = 0;
            int SecondFreqNo1 = 0; int SecondFreqNo2 = 0; int SecondFreqNo3 = 0; int SecondFreqNo4 = 0; int SecondFreqNo5 = 0;
            int ThirdFreqNo1 = 0; int ThirdFreqNo2 = 0; int ThirdFreqNo3 = 0; int ThirdFreqNo4 = 0; int ThirdFreqNo5 = 0;
            int FourthFreqNo1 = 0; int FourthFreqNo2 = 0; int FourthFreqNo3 = 0; int FourthFreqNo4 = 0; int FourthFreqNo5 = 0;
            int FifthFreqNo1 = 0; int FifthFreqNo2 = 0; int FifthFreqNo3 = 0; int FifthFreqNo4 = 0; int FifthFreqNo5 = 0;
            int SixthFreqNo1 = 0; int SixthFreqNo2 = 0; int SixthFreqNo3 = 0; int SixthFreqNo4 = 0; int SixthFreqNo5 = 0;
            int SeventhFreqNo1 = 0; int SeventhFreqNo2 = 0; int SeventhFreqNo3 = 0; int SeventhFreqNo4 = 0; int SeventhFreqNo5 = 0;
            int EighthFreqNo1 = 0; int EighthFreqNo2 = 0; int EighthFreqNo3 = 0; int EighthFreqNo4 = 0; int EighthFreqNo5 = 0;
            int NinthFreqNo1 = 0; int NinthFreqNo2 = 0; int NinthFreqNo3 = 0; int NinthFreqNo4 = 0; int NinthFreqNo5 = 0;
            int TenthFreqNo1 = 0; int TenthFreqNo2 = 0; int TenthFreqNo3 = 0; int TenthFreqNo4 = 0; int TenthFreqNo5 = 0;
            int EleventhFreqNo1 = 0; int EleventhFreqNo2 = 0; int EleventhFreqNo3 = 0; int EleventhFreqNo4 = 0; int EleventhFreqNo5 = 0;
            int TwelfthFreqNo1 = 0; int TwelfthFreqNo2 = 0; int TwelfthFreqNo3 = 0; int TwelfthFreqNo4 = 0; int TwelfthFreqNo5 = 0;
            int FirstResFreqNo1 = 0; int FirstResFreqNo2 = 0; int FirstResFreqNo3 = 0; int FirstResFreqNo4 = 0; int FirstResFreqNo5 = 0;
            int SecondResFreqNo1 = 0; int SecondResFreqNo2 = 0; int SecondResFreqNo3 = 0; int SecondResFreqNo4 = 0; int SecondResFreqNo5 = 0;
            int ThirdResFreqNo1 = 0; int ThirdResFreqNo2 = 0; int ThirdResFreqNo3 = 0; int ThirdResFreqNo4 = 0; int ThirdResFreqNo5 = 0;
            int FourthResFreqNo1 = 0; int FourthResFreqNo2 = 0; int FourthResFreqNo3 = 0; int FourthResFreqNo4 = 0; int FourthResFreqNo5 = 0;
            int FifthResFreqNo1 = 0; int FifthResFreqNo2 = 0; int FifthResFreqNo3 = 0; int FifthResFreqNo4 = 0; int FifthResFreqNo5 = 0;

            //Frekwencja wartosci bool
            var checkFull1 = username.FirstFull;var checkFirst1 = username.First1; var checkFirst2 = username.First2;
            var checkFirst3 = username.First3; var checkFirst4 = username.First4; var checkFirst5 = username.First5;
            var checkFull2 = username.SecondFull; var checkSecond1 = username.Second1; var checkSecond2 = username.Second2;
            var checkSecond3 = username.Second3; var checkSecond4 = username.Second4; var checkSecond5 = username.Second5;
            var checkFull3 = username.ThirdFull; var checkThird1 = username.Third1; var checkThird2 = username.Third2;
            var checkThird3 = username.Third3; var checkThird4 = username.Third4; var checkThird5 = username.Third5;
            var checkFull4 = username.FourthFull; var checkFourth1 = username.Fourth1; var checkFourth2 = username.Fourth2;
            var checkFourth3 = username.Fourth3; var checkFourth4 = username.Fourth4; var checkFourth5 = username.Fourth5;
            var checkFull5 = username.FifthFull; var checkFifth1 = username.Fifth1; var checkFifth2 = username.Fifth2;
            var checkFifth3 = username.Fifth3; var checkFifth4 = username.Fifth4; var checkFifth5 = username.Fifth5;
            var checkFull6 = username.SixthFull; var checkSixth1 = username.Sixth1; var checkSixth2 = username.Sixth2;
            var checkSixth3 = username.Sixth3; var checkSixth4 = username.Sixth4; var checkSixth5 = username.Sixth5;
            var checkFull7 = username.SeventhFull; var checkSeventh1 = username.Seventh1; var checkSeventh2 = username.Seventh2;
            var checkSeventh3 = username.Seventh3; var checkSeventh4 = username.Seventh4; var checkSeventh5 = username.Seventh5;
            var checkFull8 = username.EighthFull; var checkEighth1 = username.Eighth1; var checkEighth2 = username.Eighth2;
            var checkEighth3 = username.Eighth3; var checkEighth4 = username.Eighth4; var checkEighth5 = username.Eighth5;
            var checkFull9 = username.NinthFull; var checkNinth1 = username.Ninth1; var checkNinth2 = username.Ninth2;
            var checkNinth3 = username.Ninth3; var checkNinth4 = username.Ninth4; var checkNinth5 = username.Ninth5;
            var checkFull10 = username.TenthFull; var checkTenth1 = username.Tenth1; var checkTenth2 = username.Tenth2;
            var checkTenth3 = username.Tenth3; var checkTenth4 = username.Tenth4; var checkTenth5 = username.Tenth5;
            var checkFull11 = username.EleventhFull; var checkEleventh1 = username.Eleventh1; var checkEleventh2 = username.Eleventh2;
            var checkEleventh3 = username.Eleventh3; var checkEleventh4 = username.Eleventh4; var checkEleventh5 = username.Eleventh5;
            var checkFull12 = username.TwelfthFull; var checkTwelfth1 = username.Twelfth1; var checkTwelfth2 = username.Twelfth2;
            var checkTwelfth3 = username.Twelfth3; var checkTwelfth4 = username.Twelfth4; var checkTwelfth5 = username.Twelfth5;
            var checkFullR1 = username.R_FirstFull; var checkR_First1 = username.R_First1; var checkR_First2 = username.R_First2;
            var checkR_First3 = username.R_First3; var checkR_First4 = username.R_First4; var checkR_First5 = username.R_First5;
            var checkFullR2 = username.R_SecondFull; var checkR_Second1 = username.R_Second1; var checkR_Second2 = username.R_Second2;
            var checkR_Second3 = username.R_Second3; var checkR_Second4 = username.R_Second4; var checkR_Second5 = username.R_Second5;
            var checkFullR3 = username.R_ThirdFull; var checkR_Third1 = username.R_Third1; var checkR_Third2 = username.R_Third2;
            var checkR_Third3 = username.R_Third3; var checkR_Third4 = username.R_Third4; var checkR_Third5 = username.R_Third5;
            var checkFullR4 = username.R_FourthFull; var checkR_Fourth1 = username.R_Fourth1; var checkR_Fourth2 = username.R_Fourth2;
            var checkR_Fourth3 = username.R_Fourth3; var checkR_Fourth4 = username.R_Fourth4; var checkR_Fourth5 = username.R_Fourth5;
            var checkFullR5 = username.R_FifthFull; var checkR_Fifth1 = username.R_Fifth1; var checkR_Fifth2 = username.R_Fifth2;
            var checkR_Fifth3 = username.R_Fifth3; var checkR_Fifth4 = username.R_Fifth4; var checkR_Fifth5 = username.R_Fifth5;

            #region sprawdzenie czy osoba byla przynajmniej na 1 bossie
            if(!string.IsNullOrEmpty(FirstMember))
            {
                if (checkFull1 != true && checkFirst1 != true && checkFirst2 != true && checkFirst3 != true && checkFirst4 != true && checkFirst5 != true)
                {
                    TempData["Obecny"] = FirstMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if(!string.IsNullOrEmpty(SecondMember))
            {
                if (checkFull2 != true && checkSecond1 != true && checkSecond2 != true && checkSecond3 != true && checkSecond4 != true && checkSecond5 != true)
                {
                    TempData["Obecny"] = SecondMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(ThirdMember))
            {
                if (checkFull3 != true && checkThird1 != true && checkThird2 != true && checkThird3 != true && checkThird4 != true && checkThird5 != true)
                {
                    TempData["Obecny"] = ThirdMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(FourthMember))
            {
                if (checkFull4 != true && checkFourth1 != true && checkFourth2 != true && checkFourth3 != true && checkFourth4 != true && checkFourth5 != true)
                {
                    TempData["Obecny"] = FourthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(FifthMember))
            {
                if (checkFull5 != true && checkFifth1 != true && checkFifth2 != true && checkFifth3 != true && checkFifth4 != true && checkFifth5 != true)
                {
                    TempData["Obecny"] = FifthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(SixthMember))
            {
                if (checkFull6 != true && checkSixth1 != true && checkSixth2 != true && checkSixth3 != true && checkSixth4 != true && checkSixth5 != true)
                {
                    TempData["Obecny"] = SixthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(SeventhMember))
            {
                if (checkFull7 != true && checkSeventh1 != true && checkSeventh2 != true && checkSeventh3 != true && checkSeventh4 != true && checkSeventh5 != true)
                {
                    TempData["Obecny"] = SeventhMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(EighthMember))
            {
                if (checkFull8 != true && checkEighth1 != true && checkEighth2 != true && checkEighth3 != true && checkEighth4 != true && checkEighth5 != true)
                {
                    TempData["Obecny"] = EighthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(NinthMember))
            {
                if (checkFull9 != true && checkNinth1 != true && checkNinth2 != true && checkNinth3 != true && checkNinth4 != true && checkNinth5 != true)
                {
                    TempData["Obecny"] = NinthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(TenthMember))
            {
                if (checkFull10 != true && checkTenth1 != true && checkTenth2 != true && checkTenth3 != true && checkTenth4 != true && checkTenth5 != true)
                {
                    TempData["Obecny"] = TenthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(EleventhMember))
            {
                if (checkFull11 != true && checkEleventh1 != true && checkEleventh2 != true && checkEleventh3 != true && checkEleventh4 != true && checkEleventh5 != true)
                {
                    TempData["Obecny"] = EleventhMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(TwelfthMember))
            {
                if (checkFull12 != true && checkTwelfth1 != true && checkTwelfth2 != true && checkTwelfth3 != true && checkTwelfth4 != true && checkTwelfth5 != true)
                {
                    TempData["Obecny"] = TwelfthMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(FirstReserveMember))
            {
                if (checkFullR1 != true && checkR_First1 != true && checkR_First2 != true && checkR_First3 != true && checkR_First4 != true && checkR_First5 != true)
                {
                    TempData["Obecny"] = FirstReserveMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(SecondReserveMember))
            {
                if (checkFullR2 != true && checkR_Second1 != true && checkR_Second2 != true && checkR_Second3 != true && checkR_Second4 != true && checkR_Second5 != true)
                {
                    TempData["Obecny"] = SecondReserveMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(ThirdReserveMember))
            {
                if (checkFullR3 != true && checkR_Third1 != true && checkR_Third2 != true && checkR_Third3 != true && checkR_Third4 != true && checkR_Third5 != true)
                {
                    TempData["Obecny"] = ThirdReserveMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(FourthReserveMember))
            {
                if (checkFullR4 != true && checkR_Fourth1 != true && checkR_Fourth2 != true && checkR_Fourth3 != true && checkR_Fourth4 != true && checkR_Fourth5 != true)
                {
                    TempData["Obecny"] = FourthReserveMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (!string.IsNullOrEmpty(FifthReserveMember))
            {
                if (checkFullR5 != true && checkR_Fifth1 != true && checkR_Fifth2 != true && checkR_Fifth3 != true && checkR_Fifth4 != true && checkR_Fifth5 != true)
                {
                    TempData["Obecny"] = FifthReserveMember;
                    return RedirectToAction("FreqAppka");
                }
            }
            #endregion

            //Dodane wartosci do frekwencji, w zaleznosci od checkboxow
            //Pierwszy Gracz
            if(checkFull1 == true)
            {
                FirstFreqNo1 = 1;
                FirstFreqNo2 = 1;
                FirstFreqNo3 = 1;
                FirstFreqNo4 = 1;
                FirstFreqNo5 = 1;
            }
            if(checkFirst1 == true)
            {
                FirstFreqNo1 = 1;
            }
            if (checkFirst2 == true)
            {
                FirstFreqNo2 = 1;
            }
            if (checkFirst3 == true)
            {
                FirstFreqNo3 = 1;
            }
            if (checkFirst4 == true)
            {
                FirstFreqNo4 = 1;
            }
            if (checkFirst5 == true)
            {
                FirstFreqNo5 = 1;
            }
            //Drugi Gracz
            if (checkFull2 == true)
            {
                SecondFreqNo1 = 1;
                SecondFreqNo2 = 1;
                SecondFreqNo3 = 1;
                SecondFreqNo4 = 1;
                SecondFreqNo5 = 1;
            }
            if (checkSecond1 == true)
            {
                SecondFreqNo1 = 1;
            }
            if (checkSecond2 == true)
            {
                SecondFreqNo2 = 1;
            }
            if (checkSecond3 == true)
            {
                SecondFreqNo3 = 1;
            }
            if (checkSecond4 == true)
            {
                SecondFreqNo4 = 1;
            }
            if (checkSecond5 == true)
            {
                SecondFreqNo5 = 1;
            }
            //Trzeci Gracz
            if (checkFull3 == true)
            {
                ThirdFreqNo1 = 1;
                ThirdFreqNo2 = 1;
                ThirdFreqNo3 = 1;
                ThirdFreqNo4 = 1;
                ThirdFreqNo5 = 1;
            }
            if (checkThird1 == true)
            {
                ThirdFreqNo1 = 1;
            }
            if (checkThird2 == true)
            {
                ThirdFreqNo2 = 1;
            }
            if (checkThird3 == true)
            {
                ThirdFreqNo3 = 1;
            }
            if (checkThird4 == true)
            {
                ThirdFreqNo4 = 1;
            }
            if (checkThird5 == true)
            {
                ThirdFreqNo5 = 1;
            }
            //Czwarty Gracz
            if (checkFull4 == true)
            {
                FourthFreqNo1 = 1;
                FourthFreqNo2 = 1;
                FourthFreqNo3 = 1;
                FourthFreqNo4 = 1;
                FourthFreqNo5 = 1;
            }
            if (checkFourth1 == true)
            {
                FourthFreqNo1 = 1;
            }
            if (checkFourth2 == true)
            {
                FourthFreqNo2 = 1;
            }
            if (checkFourth3 == true)
            {
                FourthFreqNo3 = 1;
            }
            if (checkFourth4 == true)
            {
                FourthFreqNo4 = 1;
            }
            if (checkFourth5 == true)
            {
                FourthFreqNo5 = 1;
            }
            //Piaty Gracz
            if (checkFull5 == true)
            {
                FifthFreqNo1 = 1;
                FifthFreqNo2 = 1;
                FifthFreqNo3 = 1;
                FifthFreqNo4 = 1;
                FifthFreqNo5 = 1;
            }
            if (checkFifth1 == true)
            {
                FifthFreqNo1 = 1;
            }
            if (checkFifth2 == true)
            {
                FifthFreqNo2 = 1;
            }
            if (checkFifth3 == true)
            {
                FifthFreqNo3 = 1;
            }
            if (checkFifth4 == true)
            {
                FifthFreqNo4 = 1;
            }
            if (checkFifth5 == true)
            {
                FifthFreqNo5 = 1;
            }
            //Szosty Gracz
            if (checkFull6 == true)
            {
                SixthFreqNo1 = 1;
                SixthFreqNo2 = 1;
                SixthFreqNo3 = 1;
                SixthFreqNo4 = 1;
                SixthFreqNo5 = 1;
            }
            if (checkSixth1 == true)
            {
                SixthFreqNo1 = 1;
            }
            if (checkSixth2 == true)
            {
                SixthFreqNo2 = 1;
            }
            if (checkSixth3 == true)
            {
                SixthFreqNo3 = 1;
            }
            if (checkSixth4 == true)
            {
                SixthFreqNo4 = 1;
            }
            if (checkSixth5 == true)
            {
                SixthFreqNo5 = 1;
            }
            //Siodmy Gracz
            if (checkFull7 == true)
            {
                SeventhFreqNo1 = 1;
                SeventhFreqNo2 = 1;
                SeventhFreqNo3 = 1;
                SeventhFreqNo4 = 1;
                SeventhFreqNo5 = 1;
            }
            if (checkSeventh1 == true)
            {
                SeventhFreqNo1 = 1;
            }
            if (checkSeventh2 == true)
            {
                SeventhFreqNo2 = 1;
            }
            if (checkSeventh3 == true)
            {
                SeventhFreqNo3 = 1;
            }
            if (checkSeventh4 == true)
            {
                SeventhFreqNo4 = 1;
            }
            if (checkSeventh5 == true)
            {
                SeventhFreqNo5 = 1;
            }
            //Osmy Gracz
            if (checkFull8 == true)
            {
                EighthFreqNo1 = 1;
                EighthFreqNo2 = 1;
                EighthFreqNo3 = 1;
                EighthFreqNo4 = 1;
                EighthFreqNo5 = 1;
            }
            if (checkEighth1 == true)
            {
                EighthFreqNo1 = 1;
            }
            if (checkEighth2 == true)
            {
                EighthFreqNo2 = 1;
            }
            if (checkEighth3 == true)
            {
                EighthFreqNo3 = 1;
            }
            if (checkEighth4 == true)
            {
                EighthFreqNo4 = 1;
            }
            if (checkEighth5 == true)
            {
                EighthFreqNo5 = 1;
            }
            //Dziewiaty Gracz
            if (checkFull9 == true)
            {
                NinthFreqNo1 = 1;
                NinthFreqNo2 = 1;
                NinthFreqNo3 = 1;
                NinthFreqNo4 = 1;
                NinthFreqNo5 = 1;
            }
            if (checkNinth1 == true)
            {
                NinthFreqNo1 = 1;
            }
            if (checkNinth2 == true)
            {
                NinthFreqNo2 = 1;
            }
            if (checkNinth3 == true)
            {
                NinthFreqNo3 = 1;
            }
            if (checkNinth4 == true)
            {
                NinthFreqNo4 = 1;
            }
            if (checkNinth5 == true)
            {
                NinthFreqNo5 = 1;
            }
            //Dziesiaty Gracz
            if (checkFull10 == true)
            {
                TenthFreqNo1 = 1;
                TenthFreqNo2 = 1;
                TenthFreqNo3 = 1;
                TenthFreqNo4 = 1;
                TenthFreqNo5 = 1;
            }
            if (checkTenth1 == true)
            {
                TenthFreqNo1 = 1;
            }
            if (checkTenth2 == true)
            {
                TenthFreqNo2 = 1;
            }
            if (checkTenth3 == true)
            {
                TenthFreqNo3 = 1;
            }
            if (checkTenth4 == true)
            {
                TenthFreqNo4 = 1;
            }
            if (checkTenth5 == true)
            {
                TenthFreqNo5 = 1;
            }
            //Jedenasty Gracz
            if (checkFull11 == true)
            {
                EleventhFreqNo1 = 1;
                EleventhFreqNo2 = 1;
                EleventhFreqNo3 = 1;
                EleventhFreqNo4 = 1;
                EleventhFreqNo5 = 1;
            }
            if (checkEleventh1 == true)
            {
                EleventhFreqNo1 = 1;
            }
            if (checkEleventh2 == true)
            {
                EleventhFreqNo2 = 1;
            }
            if (checkEleventh3 == true)
            {
                EleventhFreqNo3 = 1;
            }
            if (checkEleventh4 == true)
            {
                EleventhFreqNo4 = 1;
            }
            if (checkEleventh5 == true)
            {
                EleventhFreqNo5 = 1;
            }
            //Dwunasty Gracz
            if (checkFull12 == true)
            {
                TwelfthFreqNo1 = 1;
                TwelfthFreqNo2 = 1;
                TwelfthFreqNo3 = 1;
                TwelfthFreqNo4 = 1;
                TwelfthFreqNo5 = 1;
            }
            if (checkTwelfth1 == true)
            {
                TwelfthFreqNo1 = 1;
            }
            if (checkTwelfth2 == true)
            {
                TwelfthFreqNo2 = 1;
            }
            if (checkTwelfth3 == true)
            {
                TwelfthFreqNo3 = 1;
            }
            if (checkTwelfth4 == true)
            {
                TwelfthFreqNo4 = 1;
            }
            if (checkTwelfth5 == true)
            {
                TwelfthFreqNo5 = 1;
            }
            //Rezerwowi
            //Pierwszy Rezerwowy Gracz
            if (checkFullR1 == true)
            {
                FirstResFreqNo1 = 1;
                FirstResFreqNo2 = 1;
                FirstResFreqNo3 = 1;
                FirstResFreqNo4 = 1;
                FirstResFreqNo5 = 1;
            }
            if (checkR_First1 == true)
            {
                FirstResFreqNo1 = 1;
            }
            if (checkR_First2 == true)
            {
                FirstResFreqNo2 = 1;
            }
            if (checkR_First3 == true)
            {
                FirstResFreqNo3 = 1;
            }
            if (checkR_First4 == true)
            {
                FirstResFreqNo4 = 1;
            }
            if (checkR_First5 == true)
            {
                FirstResFreqNo5 = 1;
            }
            //Drugi Rezerwowy Gracz
            if (checkFullR2 == true)
            {
                SecondResFreqNo1 = 1;
                SecondResFreqNo2 = 1;
                SecondResFreqNo3 = 1;
                SecondResFreqNo4 = 1;
                SecondResFreqNo5 = 1;
            }
            if (checkR_Second1 == true)
            {
                SecondResFreqNo1 = 1;
            }
            if (checkR_Second2 == true)
            {
                SecondResFreqNo2 = 1;
            }
            if (checkR_Second3 == true)
            {
                SecondResFreqNo3 = 1;
            }
            if (checkR_Second4 == true)
            {
                SecondResFreqNo4 = 1;
            }
            if (checkR_Second5 == true)
            {
                SecondResFreqNo5 = 1;
            }
            //Trzeci Rezerwowy Gracz
            if (checkFullR3 == true)
            {
                ThirdResFreqNo1 = 1;
                ThirdResFreqNo2 = 1;
                ThirdResFreqNo3 = 1;
                ThirdResFreqNo4 = 1;
                ThirdResFreqNo5 = 1;
            }
            if (checkR_Third1 == true)
            {
                ThirdResFreqNo1 = 1;
            }
            if (checkR_Third2 == true)
            {
                ThirdResFreqNo2 = 1;
            }
            if (checkR_Third3 == true)
            {
                ThirdResFreqNo3 = 1;
            }
            if (checkR_Third4 == true)
            {
                ThirdResFreqNo4 = 1;
            }
            if (checkR_Third5 == true)
            {
                ThirdResFreqNo5 = 1;
            }
            //Czwarty Rezerwowy Gracz
            if (checkFullR4 == true)
            {
                FourthResFreqNo1 = 1;
                FourthResFreqNo2 = 1;
                FourthResFreqNo3 = 1;
                FourthResFreqNo4 = 1;
                FourthResFreqNo5 = 1;
            }
            if (checkR_Fourth1 == true)
            {
                FourthResFreqNo1 = 1;
            }
            if (checkR_Fourth2 == true)
            {
                FourthResFreqNo2 = 1;
            }
            if (checkR_Fourth3 == true)
            {
                FourthResFreqNo3 = 1;
            }
            if (checkR_Fourth4 == true)
            {
                FourthResFreqNo4 = 1;
            }
            if (checkR_Fourth5 == true)
            {
                FourthResFreqNo5 = 1;
            }
            //Piaty Rezerwowy Gracz
            if (checkFullR5 == true)
            {
                FifthResFreqNo1 = 1;
                FifthResFreqNo2 = 1;
                FifthResFreqNo3 = 1;
                FifthResFreqNo4 = 1;
                FifthResFreqNo5 = 1;
            }
            if (checkR_Fifth1 == true)
            {
                FifthResFreqNo1 = 1;
            }
            if (checkR_Fifth2 == true)
            {
                FifthResFreqNo2 = 1;
            }
            if (checkR_Fifth3 == true)
            {
                FifthResFreqNo3 = 1;
            }
            if (checkR_Fifth4 == true)
            {
                FifthResFreqNo4 = 1;
            }
            if (checkR_Fifth5 == true)
            {
                FifthResFreqNo5 = 1;
            }

            //Sprawdzenie czy pkt frekwencji nie zostana dodane do pustych(string = "") graczy
            if(string.IsNullOrEmpty(FirstMember))
            {
                if(checkFull1 == true || checkFirst1 == true || checkFirst2 == true || checkFirst3 == true || checkFirst4 == true || checkFirst5 == true){
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(SecondMember))
            {
                if (checkFull2 == true || checkSecond1 == true || checkSecond2 == true || checkSecond3 == true || checkSecond4 == true || checkSecond5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(ThirdMember))
            {
                if (checkFull3 == true || checkThird1 == true || checkThird2 == true || checkThird3 == true || checkThird4 == true || checkThird5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(FourthMember))
            {
                if (checkFull4 == true || checkFourth1 == true || checkFourth2 == true || checkFourth3 == true || checkFourth4 == true || checkFourth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(FifthMember))
            {
                if (checkFull5 == true || checkFifth1 == true || checkFifth2 == true || checkFifth3 == true || checkFifth4 == true || checkFifth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(SixthMember))
            {
                if (checkFull6 == true || checkSixth1 == true || checkSixth2 == true || checkSixth3 == true || checkSixth4 == true || checkSixth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(SeventhMember))
            {
                if (checkFull7 == true || checkSeventh1 == true || checkSeventh2 == true || checkSeventh3 == true || checkSeventh4 == true || checkSeventh5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(EighthMember))
            {
                if (checkFull8 == true || checkEighth1 == true || checkEighth2 == true || checkEighth3 == true || checkEighth4 == true || checkEighth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(NinthMember))
            {
                if (checkFull9 == true || checkNinth1 == true || checkNinth2 == true || checkNinth3 == true || checkNinth4 == true || checkNinth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(TenthMember))
            {
                if (checkFull10 == true || checkTenth1 == true || checkTenth2 == true || checkTenth3 == true || checkTenth4 == true || checkTenth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(EleventhMember))
            {
                if (checkFull11 == true || checkEleventh1 == true || checkEleventh2 == true || checkEleventh3 == true || checkEleventh4 == true || checkEleventh5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(TwelfthMember))
            {
                if (checkFull12 == true || checkTwelfth1 == true || checkTwelfth2 == true || checkTwelfth3 == true || checkTwelfth4 == true || checkTwelfth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(FirstReserveMember))
            {
                if (checkFullR1 == true || checkR_First1 == true || checkR_First2 == true || checkR_First3 == true || checkR_First4 == true || checkR_First5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(SecondReserveMember))
            {
                if (checkFullR2 == true || checkR_Second1 == true || checkR_Second2 == true || checkR_Second3 == true || checkR_Second4 == true || checkR_Second5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(ThirdReserveMember))
            {
                if (checkFullR3 == true || checkR_Third1 == true || checkR_Third2 == true || checkR_Third3 == true || checkR_Third4 == true || checkR_Third5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(FourthReserveMember))
            {
                if (checkFullR4 == true || checkR_Fourth1 == true || checkR_Fourth2 == true || checkR_Fourth3 == true || checkR_Fourth4 == true || checkR_Fourth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }
            if (string.IsNullOrEmpty(FifthReserveMember))
            {
                if (checkFullR5 == true || checkR_Fifth1 == true || checkR_Fifth2 == true || checkR_Fifth3 == true || checkR_Fifth4 == true || checkR_Fifth5 == true)
                {
                    TempData["Pusty"] = false;
                    return RedirectToAction("FreqAppka");
                }
            }

            //Lista Frekwencji 1 bossa
            List<String> FirstBossLists = new List<String>();
            FirstBossLists.Add(FirstFreqNo1.ToString());
            FirstBossLists.Add(SecondFreqNo1.ToString());
            FirstBossLists.Add(ThirdFreqNo1.ToString());
            FirstBossLists.Add(FourthFreqNo1.ToString());
            FirstBossLists.Add(FifthFreqNo1.ToString());
            FirstBossLists.Add(SixthFreqNo1.ToString());
            FirstBossLists.Add(SeventhFreqNo1.ToString());
            FirstBossLists.Add(EighthFreqNo1.ToString());
            FirstBossLists.Add(NinthFreqNo1.ToString());
            FirstBossLists.Add(TenthFreqNo1.ToString());
            FirstBossLists.Add(EleventhFreqNo1.ToString());
            FirstBossLists.Add(TwelfthFreqNo1.ToString());
            FirstBossLists.Add(FirstResFreqNo1.ToString());
            FirstBossLists.Add(SecondResFreqNo1.ToString());
            FirstBossLists.Add(ThirdResFreqNo1.ToString());
            FirstBossLists.Add(FourthResFreqNo1.ToString());
            FirstBossLists.Add(FifthResFreqNo1.ToString());
            FirstBossLists = FirstBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

            //Lista Frekwencji 2 bossa
            List<String> SecondBossLists = new List<String>();
            SecondBossLists.Add(FirstFreqNo2.ToString());
            SecondBossLists.Add(SecondFreqNo2.ToString());
            SecondBossLists.Add(ThirdFreqNo2.ToString());
            SecondBossLists.Add(FourthFreqNo2.ToString());
            SecondBossLists.Add(FifthFreqNo2.ToString());
            SecondBossLists.Add(SixthFreqNo2.ToString());
            SecondBossLists.Add(SeventhFreqNo2.ToString());
            SecondBossLists.Add(EighthFreqNo2.ToString());
            SecondBossLists.Add(NinthFreqNo2.ToString());
            SecondBossLists.Add(TenthFreqNo2.ToString());
            SecondBossLists.Add(EleventhFreqNo2.ToString());
            SecondBossLists.Add(TwelfthFreqNo2.ToString());
            SecondBossLists.Add(FirstResFreqNo2.ToString());
            SecondBossLists.Add(SecondResFreqNo2.ToString());
            SecondBossLists.Add(ThirdResFreqNo2.ToString());
            SecondBossLists.Add(FourthResFreqNo2.ToString());
            SecondBossLists.Add(FifthResFreqNo2.ToString());
            SecondBossLists = SecondBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

            //Lista Frekwencji 3 bossa
            List<String> ThirdBossLists = new List<String>();
            ThirdBossLists.Add(FirstFreqNo3.ToString());
            ThirdBossLists.Add(SecondFreqNo3.ToString());
            ThirdBossLists.Add(ThirdFreqNo3.ToString());
            ThirdBossLists.Add(FourthFreqNo3.ToString());
            ThirdBossLists.Add(FifthFreqNo3.ToString());
            ThirdBossLists.Add(SixthFreqNo3.ToString());
            ThirdBossLists.Add(SeventhFreqNo3.ToString());
            ThirdBossLists.Add(EighthFreqNo3.ToString());
            ThirdBossLists.Add(NinthFreqNo3.ToString());
            ThirdBossLists.Add(TenthFreqNo3.ToString());
            ThirdBossLists.Add(EleventhFreqNo3.ToString());
            ThirdBossLists.Add(TwelfthFreqNo3.ToString());
            ThirdBossLists.Add(FirstResFreqNo3.ToString());
            ThirdBossLists.Add(SecondResFreqNo3.ToString());
            ThirdBossLists.Add(ThirdResFreqNo3.ToString());
            ThirdBossLists.Add(FourthResFreqNo3.ToString());
            ThirdBossLists.Add(FifthResFreqNo3.ToString());
            ThirdBossLists = ThirdBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

            //Lista Frekwencji 4 bossa
            List<String> FourthBossLists = new List<String>();
            FourthBossLists.Add(FirstFreqNo4.ToString());
            FourthBossLists.Add(SecondFreqNo4.ToString());
            FourthBossLists.Add(ThirdFreqNo4.ToString());
            FourthBossLists.Add(FourthFreqNo4.ToString());
            FourthBossLists.Add(FifthFreqNo4.ToString());
            FourthBossLists.Add(SixthFreqNo4.ToString());
            FourthBossLists.Add(SeventhFreqNo4.ToString());
            FourthBossLists.Add(EighthFreqNo4.ToString());
            FourthBossLists.Add(NinthFreqNo4.ToString());
            FourthBossLists.Add(TenthFreqNo4.ToString());
            FourthBossLists.Add(EleventhFreqNo4.ToString());
            FourthBossLists.Add(TwelfthFreqNo4.ToString());
            FourthBossLists.Add(FirstResFreqNo4.ToString());
            FourthBossLists.Add(SecondResFreqNo4.ToString());
            FourthBossLists.Add(ThirdResFreqNo4.ToString());
            FourthBossLists.Add(FourthResFreqNo4.ToString());
            FourthBossLists.Add(FifthResFreqNo4.ToString());
            FourthBossLists = FourthBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

            //Lista Frekwencji 5 bossa
            List<String> FifthBossLists = new List<String>();
            FifthBossLists.Add(FirstFreqNo5.ToString());
            FifthBossLists.Add(SecondFreqNo5.ToString());
            FifthBossLists.Add(ThirdFreqNo5.ToString());
            FifthBossLists.Add(FourthFreqNo5.ToString());
            FifthBossLists.Add(FifthFreqNo5.ToString());
            FifthBossLists.Add(SixthFreqNo5.ToString());
            FifthBossLists.Add(SeventhFreqNo5.ToString());
            FifthBossLists.Add(EighthFreqNo5.ToString());
            FifthBossLists.Add(NinthFreqNo5.ToString());
            FifthBossLists.Add(TenthFreqNo5.ToString());
            FifthBossLists.Add(EleventhFreqNo5.ToString());
            FifthBossLists.Add(TwelfthFreqNo5.ToString());
            FifthBossLists.Add(FirstResFreqNo5.ToString());
            FifthBossLists.Add(SecondResFreqNo5.ToString());
            FifthBossLists.Add(ThirdResFreqNo5.ToString());
            FifthBossLists.Add(FourthResFreqNo5.ToString());
            FifthBossLists.Add(FifthResFreqNo5.ToString());
            FifthBossLists = FifthBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

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
            TempData["Wybrana_Instancja"] = Dungeon;
            TempData["FreqSucc"] = false;
            return RedirectToAction("Przeliczenia_Coquina", "FreqApp");

        }

        public ActionResult Przeliczenia_Coquina(item username)
        {
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            double FirstCoquinn;
            double SecondCoquinn;
            double ThirdCoquinn;
            double FourthCoquinn;
            double FifthCoquinn;
            var IBP_Dungeon = username.checkIBP;
            var SToES_Dungeon = username.checkSToES;
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            
            return RedirectToAction("Przeliczenia_TotalFreq", "FreqApp");
        }
        public ActionResult Przeliczenia_TotalFreq(item username)
        {
            List<String> columnData = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
            string WSP = "";
            if(dungeonName == "IBP")
            {
                WSP = "WSP_IBP";
            }
            if(dungeonName == "SToES")
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
            return RedirectToAction("Przeliczenia_Wszystkich_Stat", "FreqApp");
        }
        public ActionResult Przeliczenia_Wszystkich_Stat(item username)
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

            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            string Total_StrPattred_Query = "SELECT \"str/patt red\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            string Total_StrPatt_Query = "SELECT \"str/patt yellow\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            return RedirectToAction("Przeliczenia_WSP", "FreqApp");
        }

        public ActionResult Przeliczenia_WSP(item username)
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

            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            string Rank_StrPattred_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            string Rank_StrPatt_Query = "SELECT \"Stat-Logarithm\" From public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            return RedirectToAction("Przeliczenia_Rank_StaHpred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_StaHpred(item username)
        {
            List<String> PeopleForStaHPred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_StaWisred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_StaWisred(item username)
        {
            List<String> PeopleForStaWisred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_StaPattred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_StaPattred(item username)
        {
            List<String> PeopleForStaPattred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_StrPattred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_StrPattred(item username)
        {
            List<String> PeopleForStrPattred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            string getPeopleForStrPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            return RedirectToAction("Przeliczenia_Rank_DexPattred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_DexPattred(item username)
        {
            List<String> PeopleForDexPattred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_IntMattred", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_IntMattred(item username)
        {
            List<String> PeopleForIntMattred = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_IntMatt", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_IntMatt(item username)
        {
            List<String> PeopleForIntMatt = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("Przeliczenia_Rank_StrPatt", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_StrPatt(item username)
        {
            List<String> PeopleForStrPatt = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            string getPeopleForStrPatt = "SELECT public.\"" + dungeonName + "\".\"Nickname\" FROM public.\"" + dungeonName + "\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"" + dungeonName + "\".\"Nickname\"";
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
            return RedirectToAction("Przeliczenia_Rank_DexPatt", "FreqApp");
        }

        public ActionResult Przeliczenia_Rank_DexPatt(item username)
        {
            List<String> PeopleForDexPatt = new List<String>();
            string dungeonName = TempData["Wybrana_Instancja"].ToString();
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
            return RedirectToAction("FreqAppka", "FreqApp");
        }
        public ActionResult Set()
        {
            if (Session["user"] != null)
            {
                var lista = new List<item>();
                //s = s[0].ToUpper() + s.Substring(1);
                NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
                cn.Open();
                string QueryPeople = "SELECT public.\"People\".\"Nickname\" FROM public.\"People\"";
                using (NpgsqlCommand command = new NpgsqlCommand(QueryPeople, cn))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new item(reader.GetString(0)));
                        }
                    }
                }
                ViewBag.ListaLudzi = lista.ToSelectList(x => x.Nickname, false);

                cn.Close();
                return View();
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Account",
                    action = "Login",
                });
            }
        }

        [HttpPost]
        public ActionResult Set(SetReq secik)
        {
            var nicknames = secik.Nickname;
            var setCollect = secik.collect;
            //Instancje
            var IBP_Dungeon = secik.checkIBP;
            var SToES_Dungeon = secik.checkSToES;
            string Dungeon = "";
            //Sprawdzenie czy instancja zostala wybrana i jaka zostala wybrana.
            if (IBP_Dungeon == false && SToES_Dungeon == false)
            {
                TempData["Dungeon"] = false;
                return RedirectToAction("AddItem");
            }
            if (IBP_Dungeon == true)
            {
                Dungeon = "IBP";
            }
            if (SToES_Dungeon == true)
            {
                Dungeon = "SToES";
            }

            string checkSet = "";
            if(setCollect == true)
            {
                checkSet = "true";
            }
            if(setCollect == false)
            {
                checkSet = "false";
            }
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["IgnisTabs"].ConnectionString);
            cn.Open();
            NpgsqlCommand updateSetCollection = new NpgsqlCommand("UPDATE public.\"" + Dungeon + "\" SET \"Set\" = '" + checkSet + "' Where \"Nickname\" ='" + nicknames + "' ");
            updateSetCollection.Connection = cn;
            updateSetCollection.ExecuteNonQuery();
            cn.Close();
            TempData["FreqSucc"] = false;
            return RedirectToAction("Set", "FreqApp");
        }
        }
}