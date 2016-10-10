using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{

    public class PromosEventsByEstablishmentPromosEventsModel
    {

        [Required]
        [Display(Name = "establishment")]
        public int establishment { get; set; }
    }
}