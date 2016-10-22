using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Entities;

namespace DataAccessLayer.DAL
{
    public class PromosEventsDAL: IPromosEvents
    {
        public void addNewPromoEvent(promos_events promoEvent)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.promos_events.Add(promoEvent);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }

        }

        public promos_events promoEventInfoById(int id)
        {
            promos_events result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(promos_event => promos_event.id == id).First();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<promos_events> promoEventInfoByLocal(int local)
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(promo_event => promo_event.local == local && promo_event.is_general==0).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<promos_events> generalPromosEvents()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(pe => pe.is_general == 1).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<promos_events> promosEventsToday()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                   
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.AsEnumerable().Where(pe => String.Format("{0:yyyy/MM/dd}", pe.start_date.Date) == String.Format("{0:yyyy/MM/dd}", DateTime.Now.Date)).ToList();  //pe => pe.start_date.Date == DateTime.Today.Date pe => System.Data.Entity.Core.Objects.EntityFunctions.TruncateTime(pe.start_date.Date) == DateTime.Today.Date

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }


        public List<promos_events> promosEventsThisMoth()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(pe => pe.start_date.Month == DateTime.Now.Month && pe.start_date.Year == DateTime.Now.Year).ToList(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        private bool inThisWeek(DateTime d)
        {
            bool bandera = true;
            return bandera;
        }

        public List<promos_events> promosEventsThisWeek()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.AsEnumerable().Where(pe => inThisWeek(pe.start_date) == true).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyPromoEvent(promos_events promoEvent) {
            throw new NotImplementedException();
        }
    }
}
