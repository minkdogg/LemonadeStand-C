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

        public Player(string name)
        {
            Stand name = new Stand();
            this.playerName = name;
        }

        public int PlayerName
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
