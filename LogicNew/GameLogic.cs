using Dal;
using Dal.Factory;
using Dal.SQL;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class GameLogic
    {
        IUserDal Context;
        public GameLogic(bool sql)
        {
            if (sql)
            {
                Context = new UserSQLContext(); //UNFINISHED
            }
            else
            {
                Context = Factory.GetUserDal();
            }
        }

        public List<User> GetAllUsers()
        {
            return Context.GetAllUsers();
        }

        public Player GetPlayerById(int id)
        {
            return Context.GetPlayerById(id);
        }

        public void PlayerWonRound(int playerId)
        {
            
        }

        public List<Player> CheckWinner(List<Player> tempPlayerList)
        {
            int lostCount = 0;
            foreach (var player in tempPlayerList) if (player.Lost) lostCount++;

            if (lostCount == tempPlayerList.Count - 1)
            {
                foreach (var loser in tempPlayerList)
                {
                    if (!loser.Lost)
                    {
                        loser.Won = true;
                        UpdateStatistics(tempPlayerList);
                    }
                }
            }

            return tempPlayerList;
        }

        private void UpdateStatistics(List<Player> playerList)
        {
            foreach(var player in playerList)
            {
                Context.UpdateStatistics(player.Id, player.Won);
            }
        }

        public List<Player> GetPlayerList(string json)
        {
            var listObect = JToken.Parse(json);
            var playerArray = listObect.Children<JProperty>().FirstOrDefault(x => x.Name == "list").Value;
            List<Player> tempPlayerList = new List<Player>();

            foreach (var player in playerArray.Children())
            {
                var itemProperties = player.Children<JProperty>();

                int Id = (int)itemProperties.FirstOrDefault(x => x.Name == "Id").Value;
                string Username = (string)itemProperties.FirstOrDefault(x => x.Name == "Username").Value;
                Player tempPlayer = new Player((int)Id, (string)Username)
                {
                    Score = (int)itemProperties.FirstOrDefault(x => x.Name == "Score").Value,
                    Knocked = (int)itemProperties.FirstOrDefault(x => x.Name == "Knocked").Value,
                    Won = (bool)itemProperties.FirstOrDefault(x => x.Name == "Won").Value,
                    Lost = (bool)itemProperties.FirstOrDefault(x => x.Name == "Lost").Value,
                };

                tempPlayerList.Add(tempPlayer);
            }

            return tempPlayerList;
        }
    }
}
