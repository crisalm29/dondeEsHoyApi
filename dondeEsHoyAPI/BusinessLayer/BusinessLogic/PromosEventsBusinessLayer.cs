using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL;
using Entities;

namespace BusinessLayer.BusinessLogic
{
    public class PromosEventsBusinessLayer
    {
        PromosEventsDAL promosEventsDAL = new PromosEventsDAL();

        public dynamic[] promosEventsToday()
        {
            return promosEventsDAL.promosEventsToday();
        }

        public dynamic[] promosEventsThisMoth()
        {
            return promosEventsDAL.promosEventsThisMoth();
        }

        public dynamic[] promosEventsByEstablishment(int establishment)
        {
            return promosEventsDAL.promosEventsByEstablishment(establishment);
        }

        public dynamic[] promosEventsThisWeek()
        {
            return promosEventsDAL.promosEventsThisWeek();
        }
    }
}
