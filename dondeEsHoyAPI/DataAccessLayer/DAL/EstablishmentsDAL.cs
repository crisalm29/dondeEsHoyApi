using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.DAL
{
    public class EstablishmentsDAL : IEstablishments
    {
        public void addNewEstablishment(establishments establishment)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.establishments.Add(establishment);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }

        }

        public establishments establishmentInfoById(int id)
        {
            establishments result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments.Where(establishment => establishment.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public establishments establishmentInfoByName(string name)
        {
            establishments result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments.Where(establishment => establishment.name == name).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<establishments> allEstablishmentsInfo()
        {
            List<establishments> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.establishments.Where(establishment => establishment.id > 0).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public establishments establishmentByAccount(string email)
        {
            establishments result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from es in DBContext.establishments
                              join eu in DBContext.establishments_users on es.id equals eu.establishment
                              join ea in DBContext.establishments_accounts on eu.establishment_account equals ea.id
                              where ea.email == email
                              select es).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyEstablishment(establishments user)
        {
            throw new NotImplementedException();
        }

    }
}
