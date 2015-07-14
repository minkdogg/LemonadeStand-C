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
                buyChance = (1);
            }
            else if(price <= 3)
            {
                buyChance = (90 / 100);
            }

            else if (price <= 6)
            {
                buyChance = (50 / 100);
            }
            else if (price <= 10)
            {
                buyChance = (25 / 100);
            }

            else if (price <= 20)
            {
                buyChance = (5 / 100);
            }
            else
            {
                buyChance = (1 / 100);
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
