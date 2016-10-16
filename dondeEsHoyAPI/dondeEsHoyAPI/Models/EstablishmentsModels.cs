using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{
        public class RegisterEstablishmentModel
        {
            [Required]
            [Display(Name = "name")]
            public string name { get; set; }

            [Required]
            [Display(Name = "establishment_type")]
            public int establishment_type { get; set; }

            [Required]
            [Display(Name = "imagebase64")]
            public string imagebase64 { get; set; }

            [Required]
            [Display(Name = "telefono")]
            public string telefono { get; set; }
        }

        public class InfoByIdEstablishmentModel
        {
            [Required]
            [Display(Name = "id")]
            public int id { get; set; }
        }

        public class InfoByNameEstablishmentModel
        {
            [Required]
            [Display(Name = "name")]
            public string name { get; set; }
        }
}