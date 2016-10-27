using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Interfaces
{
    interface ILocals
    {
        void addNewLocal(locals local);
        locals localInfoById(int id);
        locals localInfoByGoogleKey(string google_key);
        List<locals> localsInfoByEstablishment(int establishment);
        List<locals> localsInfoByZone(string zone);
        void modifyLocal(locals local);
        void deleteLocal(int id);
    }
}
