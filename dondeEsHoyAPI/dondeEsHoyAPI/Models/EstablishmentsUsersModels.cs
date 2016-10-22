using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dondeEsHoyAPI.Models
{
    public class RegisterEstablishmentsUsersModel
    {
        [Required]
        [Display(Name = "establishment")]
        public int establishment { get; set; }

        [Required]
        [Display(Name = "establishment_account")]
        public int establishment_account { get; set; }
    }

    public class InfoByIdEstablishmentsUsersModel
    {
        [Required]
        [Display(Name = "id")]
        public int id { get; set; }
    }

    public class InfoByEstablishmentAccountEstablishmentsUsersModel
    {
        [Required]
        [Display(Name = "establishment_account")]
        public int establishment_account { get; set; }
    }

    public class allEstablishmentsUsersInfoByEstablishmentModel
    {
        [Required]
        [Display(Name = "establishment")]
        public int establishment { get; set; }
    }

    public class RegisterEstablishmentAndAccount
    {
        [Required]
        [Display(Name = "establishment")]
        public RegisterEstablishmentModel establishment { get; set; }

        [Required]
        [Display(Name = "establishment_account")]
        public RegisterEstablishmentAccountModel establishment_account { get; set; }
    }

}