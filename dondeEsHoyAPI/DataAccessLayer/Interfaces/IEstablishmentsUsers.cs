using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace DataAccessLayer.Interfaces
{
    interface IEstablishmentsUsers
    {
        void addNewEstablishmentUser(establishments_users establishments_users);
        establishments_users establishmentsUsersInfoById(int id);
        establishments_users establishmentsUsersInfoByEstablishmentAccount(int establishment_account);
        List<establishments_users> allEstablishmentsUsersInfoByEstablishment(int establishment);
        void deleteEstablishmentsUsers(int id);
    }
}
