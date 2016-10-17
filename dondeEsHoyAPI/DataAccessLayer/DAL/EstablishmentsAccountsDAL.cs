using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;


namespace DataAccessLayer.DAL
{
    public class EstablishmentsAccountsDAL : IEstablishmentsAccounts
    {

        public bool login(string email, string password)
        {
            establishments_accounts result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    result = DBContext.establishments_accounts.Where(establishments_accounts => establishments_accounts.email == email && establishments_accounts.password == password).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result != null;
        }

        public void addEstablishmentsAccounts(establishments_accounts establishment_account)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.establishments_accounts.Add(establishment_account);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public establishments_accounts establishmentAccountInfoById(int id)
        {
            establishments_accounts result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments_accounts.Where(user => user.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public establishments_accounts establishmentAccountInfoByEmail(string email)
        {
            establishments_accounts result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments_accounts.Where(user => user.email == email).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyEstablishmentAccount(establishments_accounts establishment_account)
        {
            throw new NotImplementedException();
        }
    }
}
