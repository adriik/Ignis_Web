using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
                var lista = new List<appka>();
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
                            lista.Add(new appka(reader.GetString(0)));
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
        public ActionResult FreqAppka(appka username)
        {
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
                Dungeon = "STOES";
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
                return RedirectToAction("FreqAppka", "FreqApp");

        }

    }
}