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
    public class UsersBusinessLayer
    {
        UsersDAL userDAL = new UsersDAL();

        public bool login(string email, string password)
        {
            return userDAL.login(email, password);
        }

        public void registerUser(string email, string password, string name, string lastName)
        {
            users newUser = new users()
            {
                name = name,
                lastName = lastName,
                password = password,
                email = email
            };

            userDAL.addNewUser(newUser);
        }

        public users userInfoById(int id)
        {
            return userDAL.userInfoById(id);
        }

        public users userInfoByEmail(string email)
        {
            return userDAL.userInfoByEmail(email);
        }


        public void modifyUser(string email, string password, string name, string lastName)
        {
            users newUser = new users()
            {
                name = name,
                lastName = lastName,
                password = password,
                email = email
            };

            userDAL.modifyUser(newUser);
        }
    }
}
