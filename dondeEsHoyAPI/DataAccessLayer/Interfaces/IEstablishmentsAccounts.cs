using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Interfaces
{
    interface IEstablishmentsAccounts
    {
        establishments_accounts login(string email, string password);
        void addEstablishmentsAccounts(establishments_accounts establishment_account);
        establishments_accounts establishmentAccountInfoById(int id);
        establishments_accounts establishmentAccountInfoByEmail(string email);
        void modifyEstablishmentAccount(establishments_accounts establishment_account);
        void deleteEstablishmentAccount(int id);
    }
}
