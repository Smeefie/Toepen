using Model;
using System;

namespace Dal
{
    public interface IUserDal
    {
        //LOGIN AND REGISTER
        bool ValidateLogin(User loginUser);

        void Register(User registerUser);

        bool CheckUsernameExists(string username);

        bool CheckEmailExists(string email);

        //UPDATING THE USER
        bool CheckUsernameExists(int ExcludeId, string username);

        void UpdateUser(User newUser);

        //GLOBAL
        User GetUserById(int id);

        User GetUserByName(string name);
    }
}
