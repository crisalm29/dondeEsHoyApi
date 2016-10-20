using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DAL;
using Entities;

namespace BusinessLayer.BusinessLogic
{
    public class EstablishmentsUsersBusinessLayer
    {
        EstablishmentsUsersDAL establishmentsUsersDAL = new EstablishmentsUsersDAL();

        public void registerEstablishmentsUsers(int establishment, int establishment_account)
        {
            establishments_users newEstablishmentsUsers = new establishments_users()
            {
                establishment = establishment,
                establishment_account = establishment_account
            };

            establishmentsUsersDAL.addNewEstablishmentUser(newEstablishmentsUsers);
        }

        public establishments_users establishmentsUsersInfoById(int id)
        {
            return establishmentsUsersDAL.establishmentsUsersInfoById(id);
        }

        public establishments_users establishmentsUsersInfoByEstablishmentAccount(int establishment_account)
        {
            return establishmentsUsersDAL.establishmentsUsersInfoByEstablishmentAccount(establishment_account);
        }

        public List<establishments_users> allEstablishmentsUsersInfoByEstablishment(int establishment)
        {
            return establishmentsUsersDAL.allEstablishmentsUsersInfoByEstablishment(establishment);
        }
    }
}
