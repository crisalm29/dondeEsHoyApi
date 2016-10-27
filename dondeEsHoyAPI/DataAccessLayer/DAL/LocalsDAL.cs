using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Entities;

namespace DataAccessLayer.DAL
{
    public class LocalsDAL : ILocals
    {
        public void addNewLocal(locals local)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.locals.Add(local);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public locals localInfoById(int id)
        {
            locals result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.locals.Where(local => local.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public locals localInfoByGoogleKey(string google_key)
        {
            locals result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.locals.Where(local => local.google_key == google_key).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<locals> localsInfoByEstablishment(int establishment)
        {
            List<locals> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.locals.Where(local => local.establishment == establishment).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<locals> localsInfoByZone(string zone)
        {
            List<locals> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.locals.Where(local => local.zone == zone).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyLocal(locals local)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    var entity = DBContext.locals.Find(local.id);
                    DBContext.Entry(entity).CurrentValues.SetValues(local);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public void deleteLocal(int id)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    locals local = new locals { id = id };
                    DBContext.locals.Attach(local);
                    DBContext.locals.Remove(local);
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
