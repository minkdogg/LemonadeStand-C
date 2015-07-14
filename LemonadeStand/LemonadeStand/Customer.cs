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

        public int levelOneBuyPrice = 2;
        public int levelOneBuyChance = 100;

        public int levelTwoBuyPrice = 6;
        public int levelTwoBuyChance = 90;

        public int levelThreeBuyPrice = 12;
        public int levelThreeBuyChance = 50;

        public int levelFourBuyPrice = 20;
        public int levelFourBuyChance = 5;

        public int levelFiveBuyPrice = 40;
        public int levelFiveBuyChance = 0;

        public int defaultBuyChance = 0;

        public int guaranteedBuy = 100;

        public Customer(Weather weather, float price, Player player, Stand stand)
        {
            if (player.PlayerName != "Tad from Prep School" && stand.location != "The Hamptons")
            {
                this.weatherDemand = weather.DemandLevel;
                if (price <= levelOneBuyPrice)
                {
                    buyChance = (levelOneBuyChance);
                }
                else if (price <= levelTwoBuyPrice)
                {
                    buyChance = (levelTwoBuyChance);
                }
                else if (price <= levelThreeBuyPrice)
                {
                    buyChance = (levelThreeBuyChance);
                }
                else if (price <= levelFourBuyPrice)
                {
                    buyChance = (levelFourBuyChance);
                }

                else if (price <= levelFiveBuyPrice)
                {
                    buyChance = (levelFiveBuyChance);
                }
                else
                {
                    buyChance = (defaultBuyChance);
                }
            }
            else
            {
                buyChance = guaranteedBuy;
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