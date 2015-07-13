using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace LemonadeStand
{
    public class Stand : IUpdate
    {
           
        public float cash;
        public int lemons;
        public int ice;
        public int sugar;
        public string location;
        public int cups;
        public int lemonadeCups;
        protected Inventory lemonInventory = new Inventory();
        protected Inventory sugarInventory = new Inventory();
        protected Inventory iceInventory = new Inventory();
        protected Inventory cupInventory = new Inventory();

        public void update(){


        }

        public float getCash()
        {
            return cash;
        }

        public void makeLemonade(int lemonade)
        {
            if (lemonade > sugar || lemonade > cups || lemonade > lemons || lemonade > ice)
            {
                Console.WriteLine("Not enough ingredients to make lemonade");
            }
            else
            {
                lemons -= lemonade;
                cups -= lemonade;
                sugar -= lemonade;
                ice -= lemonade;
            }
        }

        public void setCash(float newCash)
        {
            cash = cash + newCash;
        }

        public bool checkifZero()
        {
            if (cash <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

          public Stand (string standLocation)
        {
            this.cash = 500;
            this.lemons = 0;
            this.sugar = 0;
            this.ice = 0;
            this.cups = 0;
            this.location = standLocation;
        }





    
}
    
}
