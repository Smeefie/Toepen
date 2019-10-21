using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.SQL
{
    public class UserSQLContext : IUserDal
    {
        public UserSQLContext()
        {

        }

        public bool CheckEmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckUsernameExists(int ExcludeId, string username)
        {
            throw new NotImplementedException();
        }

        public bool CheckUsernameExists(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Register(User registerUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public bool ValidateLogin(User loginUser)
        {
            throw new NotImplementedException();
        }
    }
}
