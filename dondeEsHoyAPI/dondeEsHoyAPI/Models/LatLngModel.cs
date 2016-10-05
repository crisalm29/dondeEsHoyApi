using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{
    public class LatLngModel
    {
        
        [Required]
        [Display(Name = "lat")]
        public string lat { get; set; }

        [Required]
        [Display(Name = "lng")]
        public string lng { get; set; }
        
    }
}