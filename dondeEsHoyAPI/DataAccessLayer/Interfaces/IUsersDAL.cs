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

        void addNewUser(users user);

        users userInfoById(int id);

        users userInfoByEmail(string email);

        void modifyUser(users user);

        void deleteUser(int id);
    }
}
