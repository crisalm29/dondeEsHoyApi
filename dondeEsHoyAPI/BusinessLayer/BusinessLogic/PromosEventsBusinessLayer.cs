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

        public void addNewPromoEvent(string name, string start_date, string due_date, string description, string imagebase64, int is_general)
        {
            promos_events newPromoEvent = new promos_events()
            {
                name = name,
                start_date = DateTime.Parse(start_date),
                due_date = DateTime.Parse(due_date),
                description= description,
                imagebase64 = imagebase64,
                is_general = is_general
            };

            promosEventsDAL.addNewPromoEvent(newPromoEvent);
        }

        public promos_events promoEventInfoById(int id)
        {
            return promosEventsDAL.promoEventInfoById(id);
        }

        public List<promos_events> promoEventInfoByLocal(int local)
        {
            return promosEventsDAL.promoEventInfoByLocal(local);
        }

        public List<promos_events> promosEventsToday()
        {
            return promosEventsDAL.promosEventsToday();
        }


        public List<promos_events> promosEventsThisMoth()
        {
            return promosEventsDAL.promosEventsThisMoth();
        }

        public List<promos_events> generalPromosEvents()
        {
            return promosEventsDAL.generalPromosEvents();
        }

        public List<promos_events> promosEventsThisWeek()
        {
            return promosEventsDAL.promosEventsThisWeek();
        }

        public void modifyPromoEvent(string name, string start_date, string due_date, string description, string imagebase64, int is_general)
        {
            promos_events newPromoEvent = new promos_events()
            {
                name = name,
                start_date = DateTime.Parse(start_date),
                due_date = DateTime.Parse(due_date),
                description = description,
                imagebase64 = imagebase64,
                is_general = is_general
            };

            promosEventsDAL.modifyPromoEvent(newPromoEvent);
        }
    }
}
