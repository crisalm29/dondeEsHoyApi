using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Interfaces
{
    interface IEstablishments
    {
        void addNewEstablishment(establishments establishment);
        establishments establishmentInfoById(int id);
        establishments establishmentInfoByName(string name);
        List<establishments> allEstablishmentsInfo();
        establishments establishmentByAccount(string email);
        void modifyEstablishment(establishments establishment);
        void deleteEstablishment(int id);
    }
}
