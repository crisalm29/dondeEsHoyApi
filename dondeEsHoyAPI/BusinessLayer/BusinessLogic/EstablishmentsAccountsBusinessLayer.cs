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
    public class EstablishmentsAccountsBusinessLayer
    {
        EstablishmentsAccountsDAL establishmentsAccountsDAL = new EstablishmentsAccountsDAL();

        public establishments_accounts login(string email, string password)
        {
            return establishmentsAccountsDAL.login(email, password);
        }

        public void registerEstablishmentAccount(string email, string password, string name, string lastName, string imagebase64)
        {
            establishments_accounts newEstablishmentAccount = new establishments_accounts()
            {
                name = name,
                lastName = lastName,
                password = password,
                email = email,
                imagebase64 = imagebase64
            };

            establishmentsAccountsDAL.addEstablishmentsAccounts(newEstablishmentAccount);
        }

        public establishments_accounts establishmentAccountInfoById(int id)
        {
            return establishmentsAccountsDAL.establishmentAccountInfoById(id);
        }

        public establishments_accounts establishmentAccountInfoByEmail(string email)
        {
            return establishmentsAccountsDAL.establishmentAccountInfoByEmail(email);
        }


        public void modifyEstablishmentAccount( string email, string password, string name, string imagebase64)
        {
            establishments_accounts newEstablishmentAccount = new establishments_accounts()
            {
                name = name,
                password = password,
                email = email,
                imagebase64 = imagebase64
            };

            establishmentsAccountsDAL.modifyEstablishmentAccount(newEstablishmentAccount);
        }

        public void deleteEstablishmentAccount(int id)
        {
            establishmentsAccountsDAL.deleteEstablishmentAccount(id);
        }
    }
}
