using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPToep.Models
{
    public class GameViewModel
    {
        public List<Player> playerList;
        public string DataStream;
        public int Round;
        public int Limit;

        public GameViewModel()
        {
            playerList = new List<Player>();
            Round = 0;
        }

        public GameViewModel(GameInstance gameInstance)
        {
            playerList = gameInstance.playerList;
            Round = gameInstance.Round;
            Limit = gameInstance.Limit;
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }
    }
}
