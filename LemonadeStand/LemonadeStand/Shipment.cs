using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Shipment
    {
        protected Inventory inventory;
        protected bool shipmentDelayed = false;
        protected bool shipmentLost = false;
        /*
        public Shipment(Inventory inventory)
        {

        }

        public int shipmentDelay(Inventory inventory, int daysDelayed)
        {
            protected int newLife = inventory.getLife - daysDelayed;

            inventory.setLife(newLife);
        }

        public int shipmentLost(Inventory inventory)
        {
            inventory.setLife(0);
        }
        */
    }
}
