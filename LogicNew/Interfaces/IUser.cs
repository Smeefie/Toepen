using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IUser
    {
        
        bool ValidateLogin(User user);

        bool CheckUsernameExists(int ExcludeId, string username);

        void UpdateUser(int id, User user);

        Error ValidateUpdate(User user, string username, string password);

        //GLOBAL
        User GetUserById(int id);

        User GetUserByName(string username);
    }
}
