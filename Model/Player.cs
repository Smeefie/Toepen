using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Player
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public int Score { get; set; }

        public Player(int Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
            this.Score = 0;
        }
    }
}
