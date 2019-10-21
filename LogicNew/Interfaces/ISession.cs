using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface ISession
    {
        bool ValidateLogin(User user);       

        void Register(User user);

        bool CheckUsernameExists(string username);

        bool CheckEmailExists(string email);

        //GLOBAL
        User GetUserById(int id);

        User GetUserByName(string username);
    }
}
