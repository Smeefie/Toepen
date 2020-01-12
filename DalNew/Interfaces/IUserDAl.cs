using Model;
using System;
using System.Collections.Generic;

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

        //GAME
        List<User> GetAllUsers();
        Player GetPlayerById(int id);
        void UpdateStatistics(int id, bool won);
        List<Stat> GetAllStats();
    }
}
