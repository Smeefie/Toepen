using Model;
using System;

namespace IDal
{
    public interface IUserDal
    {
        string Login(string username, string password);
        void Register(string username, string password, string email);
        bool CheckUsername(string username);
        bool CheckEmail(string email);
    }
}
