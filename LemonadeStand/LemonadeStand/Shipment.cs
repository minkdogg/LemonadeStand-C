using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Shipment
    {
        protected List<object> lemonList = new List<object>();
        protected List<object> sugarList = new List<object>();
        protected List<object> iceList = new List<object>();
        protected List<object> cupList = new List<object>();

        protected int daysToDelivery;

        protected bool shipmentDelayed = false;
        protected bool shipmentLost = false;

        public void AddLemons(object lemon)
        {
            this.lemonList.Add(lemon);
        }

        public void AddSugar(object sugar)
        {
            this.sugarList.Add(sugar);
        }

        public void AddIce(object ice)
        {
            this.iceList.Add(ice);
        }

        public void AddCup(object cup)
        {
            this.cupList.Add(cup);
        }

        public int DaysToDelivery
        {
            get
            {
                return daysToDelivery;
            }
            set
            {
                this.daysToDelivery = value;
            }
        }

        public void update()
        {
            this.daysToDelivery -= 1;
        }
        /*
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
