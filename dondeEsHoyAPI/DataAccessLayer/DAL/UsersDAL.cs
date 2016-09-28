using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.DAL
{
    public class UsersDAL : IUsersDAL
    {
        public void addNewUser(users user)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                DBContext.users.Add(user);
                DBContext.SaveChanges();
            }
        }

        public users getUserInfoByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public users getUserInfoById(int id)
        {
            throw new NotImplementedException();
        }

        public bool login(string email, string password)
        {
            using (var DBContext = new dondeeshoyEntities())
            {
                users result = DBContext.users.Where(user => user.email == email && user.password == password).First();
                return result != null;
            }
        }

        public void modifyUser(users user)
        {
            throw new NotImplementedException();
        }
    }
}
