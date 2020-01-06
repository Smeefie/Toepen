using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class GameInstance
    {
        public List<Player> playerList;
        public string DataStream;
        public int Round;
        public int Limit;

        public GameInstance()
        {
            playerList = new List<Player>();
            Round = 0;
            Limit = 20;
        }

        public void AddPlayer(Player player)
        {
            playerList.Add(player);
        }
    }
}
