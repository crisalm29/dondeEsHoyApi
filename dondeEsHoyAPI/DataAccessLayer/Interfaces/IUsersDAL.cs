using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Interfaces
{
    interface IUsersDAL
    {
        bool login(string email, string password);

        users getUserInfoById(int id);

        users getUserInfoByEmail(string email);

        void addNewUser(users user);

        void modifyUser(users user);
    }
}
