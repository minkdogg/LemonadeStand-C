using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace LemonadeStand
{
    public class Supplier : IUpdate 
    {
        protected Inventory lemonInventory;
        protected Inventory sugarInventory;
        protected Inventory iceInventory;
        protected Inventory cupInventory;
        protected float cashOnHand;
        protected GeoCoordinate location;


        


        
        
        public GeoCoordinate Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public void recieveShipment(Shipment shipment)
        {

        }


        //
        // GET INVENTORY METHODS
        //
        public List<Ingredient> getLemonInventory()
        {
            return this.lemonInventory.getInventory();
        }
        public List<Ingredient> getSugarInventory()
        {
            return this.sugarInventory.getInventory();
        }
        public List<Ingredient> getIceInventory()
        {
            return this.iceInventory.getInventory();
        }
        public List<Ingredient> getCupInventory()
        {
            return this.cupInventory.getInventory();
        }


        //
        // SET INVENTORY METHODS
        //
        public void setLemonInventory(List<Ingredient> inventory)
        {
            this.lemonInventory.setInventory(inventory);
        }
        public void setSugarInventory(List<Ingredient> inventory)
        {
            this.sugarInventory.setInventory(inventory);
        }
        public void setIceInventory(List<Ingredient> inventory)
        {
            this.iceInventory.setInventory(inventory);
        }
        public void setCupInventory(List<Ingredient> inventory)
        {
            this.cupInventory.setInventory(inventory);
        }




        public override void update()
        {
            inventory.update();

            this.cashOnHand = this.calculateOperatingCost();
        }


        protected float calculateOperatingCost();


    }
}
