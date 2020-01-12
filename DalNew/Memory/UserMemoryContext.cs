using Exceptions;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class UserMemoryContext : IUserDal
    {
        List<User> memoryData;

        //CREATE MEMORY CONTEXT
        public UserMemoryContext()
        {
            memoryData = new List<User>()
            {
                new User(0, "Smeef", "Freek", "Jansen", "123", "Freek.jansen@mail.com"),
                new User(1, "Smiff", "First", "Last", "123", "First.last@mail.com"),
                new User(2, "Root", "Root", "RootLast", "123", "Root.Root@mail.com")
            };

            memoryData[0].UpdateRole(1);
            memoryData[1].UpdateRole(0);
            memoryData[2].UpdateRole(2);
        }

        #region GLOBAL
        //GET USER BY USER ID
        public User GetUserById(int id)
        {
            return memoryData.First(i => i.Id == id);
        }

        //GET USER BY USERNAME
        public User GetUserByName(string username)
        {
            return memoryData.First(i => i.Username == username);
        }
        #endregion

        #region LOGIN
        //VALIDATE THE LOGIN
        public bool ValidateLogin(User user)
        {
            return memoryData.Exists(i => i.Username == user.Username && i.Password == user.Password);
        }
        #endregion

        #region REGISTER
        //REGISTER A NEW USER
        public void Register(User user)
        {
            int newId = memoryData.Count + 1;
            memoryData.Add(new User(newId, user.Username, user.Firstname, user.Lastname, user.Password, user.Email));
        }

        //CHECK IF EMAIL ALREADY EXISTS
        public bool CheckEmailExists(string email)
        {
            return !memoryData.Exists(i=>i.Email == email);
        }

        //CHECK IF USERNAME ALREADY EXISTS
        public bool CheckUsernameExists(string username)
        {
            return !memoryData.Exists(i => i.Username == username);
        }
        #endregion

        #region UPDATE THE USER
        //CHECK IF NEW USERNAME IS UNIQUE
        public bool CheckUsernameExists(int excludeId, string username)
        {
            return memoryData.Where(i => i.Id != excludeId).ToList().Exists(i => i.Username == username);
        }

        public void UpdateUser(User user)
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region GAME
        public List<User> GetAllUsers()
        {
            return memoryData;
        }

        public Player GetPlayerById(int id)
        {
            var user = memoryData.First(i => i.Id == id);
            return new Player(user.Id, user.Username);
        }

        public void UpdateStatistics(int id, bool won)
        {
            throw new NotImplementedException();
        }

        public List<Stat> GetAllStats()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
