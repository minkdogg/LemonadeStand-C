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

        public void update(){


        }

          public Stand (string standLocation)
        {
            this.cash = 500;
            this.lemons = 0;
            this.sugar = 0;
            this.ice = 0;
            this.location = standLocation;
        }





    
}
    
}
