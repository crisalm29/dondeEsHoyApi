using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.DAL
{
    public class EstablishmentsUsersDAL : IEstablishmentsUsers
    {
        public void addNewEstablishmentUser(establishments_users establishments_users)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.establishments_users.Add(establishments_users);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public establishments_users establishmentsUsersInfoById(int id)
        {
            establishments_users result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments_users.Where(establishments_users => establishments_users.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public establishments_users establishmentsUsersInfoByEstablishmentAccount(int establishment_account)
        {
            establishments_users result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments_users.Where(establishments_users => establishments_users.establishment_account == establishment_account).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<establishments_users> allEstablishmentsUsersInfoByEstablishment(int establishment)
        {
            List<establishments_users> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments_users.Where(establishments_users => establishments_users.establishment > establishment).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

    }
}
