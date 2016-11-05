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

        private bool inThisDay(DateTime d1, Nullable<DateTime> d2)
        {
            bool bandera = false;
            DateTime today = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            if (d1 != null && d2 == null)
            {
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                int result = DateTime.Compare(date1, today);
                bandera = (result <= 0);
            }
            else
            {
                DateTime d3 = d2.HasValue ? d2.Value : d2.GetValueOrDefault();
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                DateTime date2 = new DateTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
                int result1 = DateTime.Compare(date1, today);
                int result2 = DateTime.Compare(date2, today);
                bandera = (result1 <= 0 && result2 >= 0);

            }

            return bandera;
        }

        private bool inThisWeek(DateTime d1, Nullable<DateTime> d2)
        {
            bool bandera = false;
            DateTime today = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            if (d1 != null && d2 == null)
            {
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                int result = DateTime.Compare(date1, today);
                if (result <= 0)
                {
                    bandera = true;
                }
                else
                {
                    int dayWeekToday = (int)today.DayOfWeek == 0? 7: (int)today.DayOfWeek;
                    DateTime finalDayWeek = today.AddDays(7 - dayWeekToday);
                    int result1 = DateTime.Compare(date1, finalDayWeek);
                    bandera = (result1 <= 0);
                }
            }
            else
            {
                DateTime d3 = d2.HasValue ? d2.Value : d2.GetValueOrDefault();
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                DateTime date2 = new DateTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
                int result1 = DateTime.Compare(date1, today);
                int result2 = DateTime.Compare(date2, today);
                int dayWeekToday = (int)today.DayOfWeek == 0 ? 7 : (int)today.DayOfWeek;
                DateTime finalDayWeek = today.AddDays(7 - dayWeekToday);
                int result3 = DateTime.Compare(date1, finalDayWeek);
                bandera = (result1 <= 0 && result2 >= 0) || (result3 <= 0);

            }

            return bandera;
        }

        private bool inThisMonth(DateTime d1, Nullable<DateTime> d2)
        {
            bool bandera = false;
            DateTime today = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            if (d1 != null && d2 == null)
            {
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                int result = DateTime.Compare(date1, today);
                if (result <= 0)
                {
                    bandera = true;
                }
                else
                {
                    DateTime aux = today.AddMonths(1);
                    aux= new DateTime(aux.Year, aux.Month, 1, 0, 0, 0);
                    int result1 = DateTime.Compare(date1, aux);
                    bandera = (result1 < 0);
                }
            }
            else
            {
                DateTime d3 = d2.HasValue ? d2.Value : d2.GetValueOrDefault();
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                DateTime date2 = new DateTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
                int result1 = DateTime.Compare(date1, today);
                int result2 = DateTime.Compare(date2, today);
                bandera = (result1 <= 0 && result2 >= 0) || today.Month==date1.Month;

            }

            return bandera;
        }

        private bool validPromoEvent(DateTime d1, Nullable<DateTime> d2)
        {
            bool bandera = false;
            DateTime today = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 0, 0, 0);
            if (d1 != null && d2 == null)
            {
                    bandera = true;
            }
            else
            {
                DateTime d3 = d2.HasValue ? d2.Value : d2.GetValueOrDefault();
                DateTime date1 = new DateTime(d1.Year, d1.Month, d1.Day, 0, 0, 0);
                DateTime date2 = new DateTime(d3.Year, d3.Month, d3.Day, 0, 0, 0);
                int result1 = DateTime.Compare(date1, today);
                int result2 = DateTime.Compare(date2, today);
                bandera = (result1 <= 0 && result2 >= 0) || (result1 >= 0 && result2 >= 0);

            }

            return bandera;
        }

        public IEnumerable<dynamic> promosEventsToday()
        {
            IEnumerable<dynamic> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from pe in DBContext.promos_events.AsEnumerable()
                              join lc in DBContext.locals on pe.local equals lc.id
                              join es in DBContext.establishments on lc.establishment equals es.id
                              where inThisDay(pe.start_date, pe.due_date) == true
                              select new { promoEvent = new { pe.id, pe.name, pe.start_date, pe.due_date, pe.description, pe.local, pe.imagebase64, pe.is_general }, establishment = new {establishmentId = es.id, establishmentName = es.name, establishmentImage = es.imagebase64 } }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public IEnumerable<dynamic> promosEventsThisWeek()
        {
            IEnumerable<dynamic> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from pe in DBContext.promos_events.AsEnumerable()
                              join lc in DBContext.locals on pe.local equals lc.id
                              join es in DBContext.establishments on lc.establishment equals es.id
                              where inThisWeek(pe.start_date, pe.due_date) == true
                              select new { promoEvent = new { pe.id, pe.name, pe.start_date, pe.due_date, pe.description, pe.local, pe.imagebase64, pe.is_general }, establishment = new { establishmentId = es.id, establishmentName = es.name, establishmentImage = es.imagebase64 } }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public IEnumerable<dynamic> promosEventsThisMoth()
        {
            IEnumerable<dynamic> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from pe in DBContext.promos_events.AsEnumerable()
                              join lc in DBContext.locals on pe.local equals lc.id
                              join es in DBContext.establishments on lc.establishment equals es.id
                              where inThisMonth(pe.start_date, pe.due_date) == true
                              select new { promoEvent = new { pe.id, pe.name, pe.start_date, pe.due_date, pe.description, pe.local, pe.imagebase64, pe.is_general }, establishment= new { establishmentId = es.id, establishmentName = es.name, establishmentImage = es.imagebase64 }}).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public IEnumerable<dynamic> promosEventsThisMothByEstablishment(int establishment)
        {
            IEnumerable<dynamic> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from pe in DBContext.promos_events.AsEnumerable()
                              join lc in DBContext.locals on pe.local equals lc.id
                              join es in DBContext.establishments on lc.establishment equals es.id
                              where inThisMonth(pe.start_date, pe.due_date) == true && es.id == establishment
                              select new { pe.id, pe.name, pe.start_date, pe.due_date, pe.description, pe.local, pe.imagebase64, pe.is_general }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public IEnumerable<dynamic> validPromosEventsByEstablishment(int establishment)
        {
            IEnumerable<dynamic> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = (from pe in DBContext.promos_events.AsEnumerable()
                              join lc in DBContext.locals on pe.local equals lc.id
                              join es in DBContext.establishments on lc.establishment equals es.id
                              where validPromoEvent(pe.start_date, pe.due_date) == true && es.id == establishment
                              select new { pe.id, pe.name, pe.start_date, pe.due_date, pe.description, pe.local, pe.imagebase64, pe.is_general }).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public void modifyPromoEvent(promos_events promoEvent)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    var entity = DBContext.promos_events.Find(promoEvent.id);
                    DBContext.Entry(entity).CurrentValues.SetValues(promoEvent);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        public void deletePromoEvent(int id)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    promos_events promoEvent = new promos_events { id = id };
                    DBContext.promos_events.Attach(promoEvent);
                    DBContext.promos_events.Remove(promoEvent);
                    DBContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
            }
        }

        /*public List<promos_events> promosEventsToday()
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
        }*/

        /*public List<promos_events> promosEventsThisWeek()
    {
        List<promos_events> result = null;
        using (var DBContext = new dondeeshoyEntities())
        {
            try
            {
                DBContext.Configuration.LazyLoadingEnabled = false;
                result = DBContext.promos_events.AsEnumerable().Where(pe => inThisWeek(pe.start_date, pe.due_date) == true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        return result;
    }*/

        /*public List<promos_events> promosEventsThisMoth()
       {
           List<promos_events> result = null;
           using (var DBContext = new dondeeshoyEntities())
           {
               try
               {
                   DBContext.Configuration.LazyLoadingEnabled = false;
                   //DBContext.Configuration.ProxyCreationEnabled = false;
                   result = DBContext.promos_events.AsEnumerable().Where(pe => inThisMonth(pe.start_date, pe.due_date) == true).ToList(); 
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex);
               }
           }
           return result;
       }*/
    }
}
