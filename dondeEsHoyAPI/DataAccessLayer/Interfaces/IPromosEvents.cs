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
        dynamic[] promosEventsToday();
        dynamic[] promosEventsThisMoth();
        dynamic[] promosEventsByEstablishment(int establishment);
        dynamic[] promosEventsThisWeek();
    }
}
