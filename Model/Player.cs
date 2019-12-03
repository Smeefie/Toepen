using Newtonsoft.Json.Linq;
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
        public int RoundPoints { get; set; }
        public int Knocked { get; set; }

        public Player(int Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
            this.Score = 0;
            this.RoundPoints = 1;
            Knocked = 0;
        }

        public Player(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jPlayer = jObject["Player"];
            Id = (int)jPlayer["Id"];
            Username = (string)jPlayer["Username"];
            Score = (int)jPlayer["Score"];
            Knocked = (int)jPlayer["Knocked"];
        }

        public void ResetRound()
        {
            RoundPoints = 1;
            Knocked = 0;
        }
    }
}
