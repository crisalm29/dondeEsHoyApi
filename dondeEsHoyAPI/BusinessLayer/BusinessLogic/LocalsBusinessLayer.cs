using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DAL;
using Entities;
using System.Collections.Generic;

namespace BusinessLayer.BusinessLogic
{
    public class LocalsBusinessLayer
    {
       LocalsDAL localsDAL = new LocalsDAL();

        public void addNewLocal(int establishment, string google_key, string zone, string telefono)
        {
            locals newLocal= new locals()
            {
                establishment = establishment,
                google_key = google_key,
                zone = zone,
                telefono = telefono
            };

            localsDAL.addNewLocal(newLocal);
        }

        public locals localInfoById(int id)
        {
            return localsDAL.localInfoById(id);
        }

        public locals localInfoByGoogleKey(string google_key)
        {
            return localsDAL.localInfoByGoogleKey(google_key);
        }

        public List<locals> localsInfoByEstablishment(int establishment)
        {
            return localsDAL.localsInfoByEstablishment(establishment);
        }

        public List<locals> localsInfoByZone(string zone)
        {
            return localsDAL.localsInfoByZone(zone);
        }


        public void modifyLocal(int establishment, string google_key, string zone, string telefono)
        {
            locals newLocal = new locals()
            {
                establishment = establishment,
                google_key = google_key,
                zone = zone,
                telefono = telefono
            };

            localsDAL.modifyLocal(newLocal);
        }

        public void deleteLocal(int id)
        {
            localsDAL.deleteLocal(id);
        }
    }
}
