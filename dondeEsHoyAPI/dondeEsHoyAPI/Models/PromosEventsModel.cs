using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{

    public class RegisterPromosEventsModel
    {
        [Required]
        [Display(Name = "name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "local")]
        public int local { get; set; }

        [Required]
        [Display(Name = "start_date")]
        public string start_date { get; set; }

        [Required]
        [Display(Name = "due_date")]
        public string due_date { get; set; }

        [Required]
        [Display(Name = "description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "imagebase64")]
        public string imagebase64 { get; set; }

        [Required]
        [Display(Name = "is_general")]
        public int is_general { get; set; }
    }

    public class InfoByIdPromosEventsModel
    {
        [Required]
        [Display(Name = "id")]
        public int id { get; set; }
    }

    public class InfoByLocalPromosEventsModel
    {
        [Required]
        [Display(Name = "local")]
        public int local { get; set; }
    }
}