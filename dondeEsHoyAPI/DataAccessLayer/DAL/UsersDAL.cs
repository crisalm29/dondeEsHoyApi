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
                try {
                    DBContext.users.Add(user);
                    DBContext.SaveChanges();
                }catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw (ex);
                }
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
            users result = null;
            using (var DBContext = new dondeeshoyEntities())
            {
                try {
                     result = DBContext.users.Where(user => user.email == email && user.password == password).First();
                }catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result != null;
        }

        public void modifyUser(users user)
        {
            throw new NotImplementedException();
        }
    }
}
