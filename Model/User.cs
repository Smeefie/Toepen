using System;

namespace Model
{

    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        //0 - user
        //1 - admin
        //2 - root
        public int Role { get; set; }

        //LOGIN USER
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        //REGISTER USER OVERRIDE
        public User(int id, string username, string firstname, string lastname, string password, string email)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public User()
        {
            
        }


        #region UPDATES
        public void UpdateId(int id)
        {
            Id = id;
        }

        public void UpdateRole(int role)
        {
            Role = role;
        }

        public void UpdateUsername(string username)
        {
            Username = username;
        }

        public void UpdateFirstname(string firstname)
        {
            Firstname = firstname;
        }

        public void UpdateLastname(string lastname)
        {
            Lastname = lastname;
        }

        public void UpdateUserInfo(string username, string lastname, string password)
        {
            Username = username;
            Firstname = Firstname;
            Lastname = lastname;
        }
        #endregion

        
    }
}
