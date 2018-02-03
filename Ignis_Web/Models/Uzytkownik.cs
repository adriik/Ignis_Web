using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignis_Web.Models
{
    public class Uzytkownik
    {
        [Required(ErrorMessage = "Musisz podać nazwę użytkownika.")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Musisz podać hasło.")]
        public string Password { get; set; }
    }
}