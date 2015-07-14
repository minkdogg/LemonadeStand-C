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
        public double weatherDemand;
        public bool buy = true;

        public Customer(Weather weather, float price)
        {
            this.weatherDemand = weather.DemandLevel;
            if (price <= 1)
            {
                buyChance = (100);
            }
            else if(price <= 3)
            {
                buyChance = (90);
            }

            else if (price <= 6)
            {
                buyChance = (50);
            }
            else if (price <= 10)
            {
                buyChance = (5);
            }

            else if (price <= 20)
            {
                buyChance = (0);
            }
            else
            {
                buyChance = (0);
            }
            
        }

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
