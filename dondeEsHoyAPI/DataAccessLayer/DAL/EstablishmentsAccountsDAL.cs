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

        public establishments_accounts login(string email, string password)
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
            return result ;
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
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    var entity = DBContext.establishments_accounts.Find(establishment_account.id);
                    DBContext.Entry(entity).CurrentValues.SetValues(establishment_account);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public void deleteEstablishmentAccount(int id)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    establishments_accounts establishmentAccount = new establishments_accounts { id = id };
                    DBContext.establishments_accounts.Attach(establishmentAccount);
                    DBContext.establishments_accounts.Remove(establishmentAccount);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }
    }
}
