using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{
    public class addNewLocalModel
    {
        [Required]
        [Display(Name = "establishment")]
        public int establishment { get; set; }

        [Required]
        [Display(Name = "google_key")]
        public string google_key { get; set; }

        [Required]
        [Display(Name = "zone")]
        public string zone { get; set; }

        [Required]
        [Display(Name = "telefono")]
        public string telefono { get; set; }
    }

    public class InfoByIdLocalModel
    {
        [Required]
        [Display(Name = "id")]
        public int id { get; set; }
    }

    public class InfoByGoogleKeyLocalModel
    {
        [Required]
        [Display(Name = "google_key")]
        public string google_key { get; set; }
    }

    public class InfoByEstablishmentLocalsModel
    {
        [Required]
        [Display(Name = "establishment")]
        public int establishment { get; set; }
    }

    public class InfoByZoneLocalsModel
    {
        [Required]
        [Display(Name = "zone")]
        public string zone { get; set; }
    }
}