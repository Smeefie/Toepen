﻿using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPToep.Models
{
    public class GameViewModel
    {
        public List<Player> playerList;
        public string DataStream;

        public GameViewModel()
        {
            playerList = new List<Player>();
        }

        public GameViewModel(GameInstance gameInstance)
        {
            playerList = gameInstance.playerList;
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }
    }
}
