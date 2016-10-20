using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{
    public class LoginEstablishmentAccountModel
    {
        [Required]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
    }

    public class RegisterEstablishmentAccountModel
    {
        [Required]
        [Display(Name = "email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "lastName")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "imagebase64")]
        public string imagebase64 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
    }

    public class InfoByIdEstablishmentAccountModel
    {
        [Required]
        [Display(Name = "id")]
        public int id { get; set; }
    }

    public class InfoByEmailEstablishmentAccountModel
    {

        [Required]
        [Display(Name = "email")]
        public string email { get; set; }
    }
}