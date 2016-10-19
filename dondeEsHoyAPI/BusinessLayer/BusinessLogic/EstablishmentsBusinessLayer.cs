using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.DAL;
using Entities;

namespace BusinessLayer.BusinessLogic
{
    public class EstablishmentsBusinessLayer
    {

        EstablishmentsDAL establishmentDAL = new EstablishmentsDAL();

        public void registerEstablishment(string name, int establishment_type, string imagebase64, string telefono)
        {
            establishments newEstablishment= new establishments()
            {
                name = name,
                establishment_type = establishment_type,
                imagebase64 = imagebase64,
                telefono = telefono
            };

            establishmentDAL.addNewEstablishment(newEstablishment);
        }

        public establishments establishmentInfoById(int id)
        {
            return establishmentDAL.establishmentInfoById(id);
        }

        public establishments establishmentInfoByName(string name)
        {
            return establishmentDAL.establishmentInfoByName(name);
        }

        public List<establishments> allEstablishmentsInfo()
        {
            return establishmentDAL.allEstablishmentsInfo();
        }


        public void modifyEstablishment(string name, int establishment_type, string imagebase64, string telefono)
        {
            establishments newEstablishment = new establishments()
            {
                name = name,
                establishment_type = establishment_type,
                imagebase64 = imagebase64,
                telefono = telefono
            };

            establishmentDAL.modifyEstablishment(newEstablishment);
        }
    }
}
