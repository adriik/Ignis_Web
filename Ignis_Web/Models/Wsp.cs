using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis_Web.Models
{
    public class Wsp
    {
        [Display(Name = "Współczynnik 1 bossa")]
        [Required(ErrorMessage = "Musi być podany wspólczynnik")]
        [Range(0.00, 2.00, ErrorMessage = "Współczynnik musi wynosić od 0.00 do 2.00")]
        [ValidDouble(ErrorMessage = "Niepoprawny format")]
        [RegularExpression("^[0-9]+(\\.)?([0-9])*$", ErrorMessage = "Niepoprawny format")]
        public double Boss1 { get; set; }
        [Display(Name = "Współczynnik 2 bossa")]
        [Required(ErrorMessage = "Musi być podany wspólczynnik")]
        [Range(0.00, 2.00, ErrorMessage = "Współczynnik musi wynosić od 0.00 do 2.00")]
        [ValidDouble(ErrorMessage = "Niepoprawny format")]
        [RegularExpression("^[0-9]+(\\.)?([0-9])*$", ErrorMessage = "Niepoprawny format")]
        public double Boss2 { get; set; }
        [Display(Name = "Współczynnik 3 bossa")]
        [Required(ErrorMessage = "Musi być podany wspólczynnik")]
        [Range(0.00, 2.00, ErrorMessage = "Współczynnik musi wynosić od 0.00 do 2.00")]
        [ValidDouble(ErrorMessage = "Niepoprawny format")]
        [RegularExpression("^[0-9]+(\\.)?([0-9])*$", ErrorMessage = "Niepoprawny format")]
        public double Boss3 { get; set; }
        [Display(Name = "Współczynnik 4 bossa")]
        [Required(ErrorMessage = "Musi być podany wspólczynnik")]
        [Range(0.00, 2.00, ErrorMessage = "Współczynnik musi wynosić od 0.00 do 2.00")]
        [ValidDouble(ErrorMessage = "Niepoprawny format")]
        [RegularExpression("^[0-9]+(\\.)?([0-9])*$", ErrorMessage = "Niepoprawny format")]
        public double Boss4 { get; set; }
        [Display(Name = "Współczynnik 5 bossa")]
        [Required(ErrorMessage = "Musi być podany wspólczynnik")]
        [Range(0.00, 2.00, ErrorMessage = "Współczynnik musi wynosić od 0.00 do 2.00")]
        [ValidDouble(ErrorMessage = "Niepoprawny format")]
        [RegularExpression("^[0-9]+(\\.)?([0-9])*$", ErrorMessage = "Niepoprawny format")]
        public double Boss5 { get; set; }
    }
}