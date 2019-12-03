using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GameInstance
    {
        public List<Player> playerList;
        public string DataStream;

        public GameInstance()
        {
            playerList = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }
    }
}
