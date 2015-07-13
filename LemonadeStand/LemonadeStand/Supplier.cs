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

        protected float lemonSalePrice;
        protected float sugarSalePrice;
        protected float iceSalePrice;
        protected float cupSalePrice;

        protected int lemonsSoldToday;
        protected int sugarSoldToday;
        protected int iceSoldToday;
        protected int cupSoldToday;

        protected string name;


        public Supplier()
        {
            // Generate Random Name
            NameGenerator nameGenerator = new NameGenerator();
            this.name = nameGenerator.GenRandomLastName();
            
            //
            // Generate Random Starting Inventory
            //
            int minStartingQuantity = 5;
            int maxStartingQuantity = 15;
            Random random = new Random();
            // Lemons
            int generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {

                lemonInventory.add(new Lemon());
            }
            // Sugar
            generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {
                sugarInventory.add(new Sugar());
            }
            // Ice
            generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {
                iceInventory.add(new Ice());
            }
            // Cups
            generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {
                cupInventory.add(new Cups());
            }


            // Generate Random Price List ??
            // STUB Hard Code STUB
            int stubbedPrice = 1;
            this.lemonSalePrice = stubbedPrice;
            this.sugarSalePrice = stubbedPrice;
            this.iceSalePrice = stubbedPrice;
            this.cupSalePrice = stubbedPrice;

            // Generate Random Cash on Hand
            int minStartingCash = 600;
            int maxStartingCash = 1400;
            this.cashOnHand = random.Next(minStartingCash, maxStartingCash);
        }


        
        //
        // ACCESSORS
        //
        public GeoCoordinate Location
        {
            get {return this.location;}
            set {this.location = value;}
        }

        public string Name
        {
            get 
            {return this.name;}
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



        //
        // UPDATE METHODS - UPDATE PURCHASES, PRICES, SPOILAGE
        //
        public void update()
        {
            // Update Spoilage of inventory
            this.lemonInventory.update();
            this.sugarInventory.update();
            this.iceInventory.update();
            this.cupInventory.update();

            // Purchase new goods based off the day's sales.
            // How to figure out how much they are going to buy?
            


            // Update Prices based off the day's sales.
            // How to figure out when to buy/sell more?
            // this.lemonSalePrice += (this.lemonsSoldToday - lemons Bought today) // ??




            this.cashOnHand = this.calculateOperatingCost();
        }


        protected float calculateOperatingCost()
        {
            // DEBUG - HARD CODE STUB - This will become a calculation based upon what is bought today.
            return 50;
        }


        public float getCashOnHand()
        {
            return this.cashOnHand;
        }


        //
        // Create Shipment
        //
        public Shipment createShipment(LemonOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i=0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Lemon());
            }
            return shipment;
        }

        public Shipment createShipment(SugarOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Sugar());
            }
            return shipment;
        }
        public Shipment createShipment(IceOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Ice());
            }
            return shipment;
        }

        public Shipment createShipment(CupsOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Cups());
            }
            return shipment;
        }






    }
}
