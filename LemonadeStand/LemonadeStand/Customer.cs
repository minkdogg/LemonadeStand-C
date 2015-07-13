using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer : IUpdate
    {
        public int buyChance;
        public bool buy = true;
        public int BuyChance
        {
            get
            {
                return buyChance;
            }
        }

        public void update()
        {

        }
    }
}
