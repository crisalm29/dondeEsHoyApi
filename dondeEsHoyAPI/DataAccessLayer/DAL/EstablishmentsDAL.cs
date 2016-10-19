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

        public void modifyEstablishment(establishments user)
        {
            throw new NotImplementedException();
        }
    }
}
