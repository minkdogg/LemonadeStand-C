using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        protected string playerName;
        protected int hiScore;
        public Stand stand;

        public Player(string name, string location)
        {
            Stand stand = new Stand(location);
            this.playerName = name;
            this.stand = stand;
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }
        }

        public int HiScore
        {
            get
            {
                return hiScore;
            }
        }
    }
}
