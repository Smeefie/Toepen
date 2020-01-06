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
                };

                tempPlayerList.Add(tempPlayer);
            }

            return tempPlayerList;
        }
    }
}
