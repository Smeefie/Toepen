﻿using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.SQL
{
    public class UserSQLContext : IUserDal
    {
        MySqlConnection conn;
        private readonly string ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi409505;Database=dbi409505;Pwd=qhwr68tb2;";
        public UserSQLContext()
        {

        }

        public bool CheckEmailExists(string email)
        {
            //try
            //{
            //    conn = new MySqlConnection();
            //    conn.ConnectionString = ConnectionString;
            //    conn.Open();
            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    //ERROR
            //}
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

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerById(int id)
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
