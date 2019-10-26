using Logic.Interfaces;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using Dal.SQL;
using Model;

namespace Logic
{
    public class UserLogic : IAdmin, ISession, IUser
    {
        //SET CONTEXT
        IUserDal Context;
        public UserLogic(bool sql)
        {
            if (sql)
            {
                Context = new UserSQLContext(); //UNFINISHED
            }
            else
            {
                Context = new UserMemoryContext();
            }
        }

        #region GLOBAL - UserLogic
        //GET USER BY USER ID
        public User GetUserById(int id)
        {
            return Context.GetUserById(id);
        }

        //GET USER BY USERNAME
        public User GetUserByName(string username)
        {
            return Context.GetUserByName(username);
        }

        //VALIDATE USER LOGIN CREDENTIALS - ISession, IUser
        /// <exception cref="ValidateException"></exception>
        public void ValidateLogin(User loginUser)
        {
            bool valid = Context.ValidateLogin(loginUser);
            if (!valid) throw new ValidateException("Invalid login");

            loginUser.UpdateId(Context.GetUserByName(loginUser.Username).Id);
        }
        #endregion

        #region REGISTER - ISession
        //REGISTER A USER
        public void Register(User registerUser)
        {
            Error errorObject = new Error();
            if (!Context.CheckEmailExists(registerUser.Email)) errorObject.AddErrorMessage("Email", "Email already exists");

            if (!Context.CheckUsernameExists(registerUser.Username)) errorObject.AddErrorMessage("Username", "Username already exists");

            if (errorObject.GetErrorState() > 0) throw new RegisterException("Register failed", errorObject);

           Context.Register(registerUser);

        }

        //CHECK IF AN EMAIL EXISTS
        public bool CheckEmailExists(string email)
        {
            return Context.CheckEmailExists(email);
        }

        //CHECK IF A USERNAME EXISTS
        public bool CheckUsernameExists(string username)
        {
            return Context.CheckUsernameExists(username);
        }
        #endregion

        #region ADMIN - IAdmin
        #endregion

        #region UPDATE USER - IUser
        //CHECK IF A USERNAME EXISTS WITHOUT CHECK FOR CURRENT ONE
        public bool CheckUsernameExists(int excludeId, string username)
        {
            return Context.CheckUsernameExists(excludeId, username);
        }

        public void ValidateUpdate(User user, string username, string password)
        {
            //CHECK IF THE PASSWORD IS CORRECT
            Error error = new Error();
            if (!Context.ValidateLogin(new User(user.Username, password)))
                error.AddErrorMessage("Password", "Password is incorrect");

            //CHECK IF THE NEW USERNAME ALREADY EXISTS
            if (Context.CheckUsernameExists(user.Id, username))
                error.AddErrorMessage("Username", "Username is already taken");

            if (error.errorKey.Count > 0) throw new UpdateUserException("Unable to update user", error);
        }

        //UPDATE THE USER
        public void UpdateUser(int id, User newUser)
        {
            User updatedUser = GetUserById(id);
            if (newUser.Username != "") updatedUser.UpdateUsername(newUser.Username);
            if (newUser.Firstname != "") updatedUser.UpdateFirstname(newUser.Firstname);
            if (newUser.Lastname != "") updatedUser.UpdateLastname(newUser.Lastname);

            Context.UpdateUser(updatedUser);
        }
        #endregion

    }
}
