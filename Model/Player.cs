using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Player
    {
        //TODO Check if JsonProperty works
        //[JsonProperty("Id")]
        public int Id { get; set; }

        public string Username { get; set; }
        public int Score { get; set; }
        public int RoundPoints { get; set; }
        public int Knocked { get; set; }
        public bool Lost { get; set; }
        public bool Won { get; set; }

        public Player(int Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
            Score = 0;
            RoundPoints = 1;
            Knocked = 0;
            Lost = false;
            Won = false;
        }

        public Player()
        {
            Id = -1;
            Score = 0;
            RoundPoints = 1;
            Knocked = 0;
            Lost = false;
            Won = false;
        }

        public void ResetRound()
        {
            RoundPoints = 1;
            Knocked = 0;
        }

        public void CalculateScore(bool jack, int limit)
        {
            Score += (1 + Knocked + (jack?2:0));
            if(Score >= limit)
            {
                Score = limit;
                Lost = true;
            }
        }
    }
}
