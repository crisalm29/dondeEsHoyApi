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

        public List<promos_events> promosEventsToday()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(pe => pe.start_date.Date == DateTime.Today.Date).ToList();  //pe => pe.start_date.Date == DateTime.Today.Date pe => System.Data.Entity.Core.Objects.EntityFunctions.TruncateTime(pe.start_date.Date) == DateTime.Today.Date

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


        public List<promos_events> generalPromosEvents()
        {
            List<promos_events> result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try
                {
                    DBContext.Configuration.LazyLoadingEnabled = false;
                    result = DBContext.promos_events.Where(pe => pe.is_general ==1).ToList();  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        public List<promos_events> promosEventsThisWeek()
        {
            throw new NotImplementedException();
        }
    }
}
