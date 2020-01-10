using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.SQL
{
    public class UserSQLContext : IUserDal
    {
        MySqlConnection conn;
        MySqlCommand command;
        string query;
        private readonly string ConnectionString = "Server=studmysql01.fhict.local;Uid=dbi409505;Database=dbi409505;Pwd=qhwr68tb2;";
        public UserSQLContext()
        {
            conn = new MySqlConnection(ConnectionString);
        }

        public bool CheckEmailExists(string email)
        {
            int exists = -1;
            command = new MySqlCommand("CheckEmailExists", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("checkEmail", email));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                exists = reader.GetInt32(0);
            }
            conn.Close();

            return exists == -1 ? false : true;
        }

        public bool CheckUsernameExists(int excludeId, string username)
        {
            int exists = -1;
            command = new MySqlCommand("CheckUsernameExistsExclude", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("uName", username));
            command.Parameters.Add(new MySqlParameter("excludeId", excludeId));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                exists = reader.GetInt32(0);
            }
            conn.Close();

            return exists == -1 ? false : true;
        }

        public bool CheckUsernameExists(string username)
        {
            int exists = -1;
            command = new MySqlCommand("CheckUsernameExists", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("uName", username));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                exists = reader.GetInt32(0);
            }
            conn.Close();

            return exists == -1 ? false : true;
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            
            command = new MySqlCommand("GetAllUsers", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();
                user.Id = reader.GetInt32(0);
                user.Username = reader.GetString(1);
                user.Firstname = reader.GetString(2);
                user.Lastname = reader.GetString(3);
                user.Password = reader.GetString(4);
                user.Email = reader.GetString(5);

                userList.Add(user);
            }
            conn.Close();

            return userList;
        }

        public Player GetPlayerById(int id)
        {
            Player player = new Player();
            command = new MySqlCommand("GetUserById", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("userId", id));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                player.Id = reader.GetInt32(0);
                player.Username = reader.GetString(1);
            }
            conn.Close();

            return player.Id == -1 ? null : player;
        }

        public User GetUserById(int id)
        {
            User user = new User(); 
            command = new MySqlCommand("GetUserById", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("userId", id));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Id = reader.GetInt32(0);
                user.Username = reader.GetString(1);
                user.Firstname = reader.GetString(2);
                user.Lastname = reader.GetString(3);
                user.Password = reader.GetString(4);
                user.Email = reader.GetString(5);
            }
            conn.Close();

            return user.Id == -1 ? null : user;
        }

        public User GetUserByName(string name)
        {
            User user = new User(); ;
            command = new MySqlCommand("GetUserByName", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("uName", name));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user.Id = reader.GetInt32(0);
                user.Username = reader.GetString(1);
                user.Firstname = reader.GetString(2);
                user.Lastname = reader.GetString(3);
                user.Password = reader.GetString(4);
                user.Email = reader.GetString(5);
            }
            conn.Close();

            return user.Id == -1 ? null : user;
        }

        public void Register(User registerUser)
        {
            command = new MySqlCommand("Register", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("uName", registerUser.Username));
            command.Parameters.Add(new MySqlParameter("fName", registerUser.Firstname));
            command.Parameters.Add(new MySqlParameter("lName", registerUser.Lastname));
            command.Parameters.Add(new MySqlParameter("pWord", registerUser.Password));
            command.Parameters.Add(new MySqlParameter("email", registerUser.Email));
           
            conn.Open();          
            command.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateUser(User newUser)
        {
            command = new MySqlCommand("UpdateUser", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("updateId", newUser.Id));
            command.Parameters.Add(new MySqlParameter("uName", newUser.Username));
            command.Parameters.Add(new MySqlParameter("fName", newUser.Firstname));
            command.Parameters.Add(new MySqlParameter("lName", newUser.Lastname));
            command.Parameters.Add(new MySqlParameter("pWord", newUser.Password));
            command.Parameters.Add(new MySqlParameter("newEmail", newUser.Email));

            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

        public bool ValidateLogin(User loginUser)
        {
            int validated = -1;
            command = new MySqlCommand("ValidateLogin", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add(new MySqlParameter("uName", loginUser.Username));
            command.Parameters.Add(new MySqlParameter("pWord", loginUser.Password));

            conn.Open();
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                validated = reader.GetInt32(0);
            }
            conn.Close();

            return validated == -1 ? false : true;
        }
    }
}
