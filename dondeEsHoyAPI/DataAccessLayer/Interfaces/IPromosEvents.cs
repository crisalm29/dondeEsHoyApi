using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Interfaces
{
    interface IPromosEvents
    {
        void addNewPromoEvent(promos_events promoEvent);
        promos_events promoEventInfoById(int id);
        List<promos_events> promoEventInfoByLocal(int local);
        List<promos_events> generalPromosEvents();
        //List<promos_events> promoEventInfoByStartDate();
        //List<promos_events> promoEventInfoByDueDate();
        IEnumerable<dynamic> promosEventsToday();
        IEnumerable<dynamic> promosEventsThisMoth();
        IEnumerable<dynamic> promosEventsThisWeek();
        void modifyPromoEvent(promos_events promoEvent);
    }
}
