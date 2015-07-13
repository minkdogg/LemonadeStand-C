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
        protected Inventory lemonInventory = new Inventory();
        protected Inventory sugarInventory = new Inventory();
        protected Inventory iceInventory = new Inventory();
        protected Inventory cupInventory = new Inventory();
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
            System.Threading.Thread.Sleep(100);
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
                Ingredient lemon = new Lemon();
                this.lemonInventory.add(lemon);
            }
            // Sugar
            generateQuantity = random.Next(1,15);
            for (int i = 0; i < generateQuantity; i++)
            {
                Ingredient sugar = new Sugar();
                sugarInventory.add(sugar);
            }
            // Ice
            generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {
                Ingredient ice = new Ice();
                iceInventory.add(ice);
            }
            // Cups
            generateQuantity = random.Next(minStartingQuantity, maxStartingQuantity);
            for (int i = 0; i < generateQuantity; i++)
            {
                Ingredient cups = new Cups();
                cupInventory.add(cups);
            }


            // Generate Random Price List ??
            // STUB Hard Code STUB
            int basePrice = 1;
            int minVariance = 10;
            int maxVariance = 100;
            this.lemonSalePrice = basePrice + (random.Next(minVariance, maxVariance)/100f);
            this.sugarSalePrice = basePrice + (random.Next(minVariance, maxVariance)/100f);
            this.iceSalePrice = basePrice + (random.Next(minVariance, maxVariance)/100f);
            this.cupSalePrice = basePrice + (random.Next(minVariance, maxVariance)/100f);

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
        // GET PRICE METHODS
        //
        public float getLemonPrice()
        {
            return this.lemonSalePrice;
        }
        public float getSugarPrice()
        {
            return this.sugarSalePrice;
        }
        public float getIcePrice()
        {
            return this.iceSalePrice;
        }
        public float getCupPrice()
        {
            return this.cupSalePrice;
        }





        //
        // UPDATE METHODS - UPDATE PURCHASES, PRICES, SPOILAGE
        //
        public void update()
        {
            // Update Spoilage of inventory
            this.lemonInventory.update();
            this.sugarInventory.update();
            // this.iceInventory.update(); // Ice has a variable spoilage that is not programmed in yet
            // this.cupInventory.update(); // Cups do not spoil
            

            //
            // Purchase new inventory based off the day's sales
            // 
            int inventoryBumpForSales = 2; // For each lemon sold, but two more
            // Lemons
            for (int i = 0; i < lemonsSoldToday; i++)
            {
                for (int j = 0; j < inventoryBumpForSales; j++)
                {
                    Ingredient lemon = new Lemon();
                    lemonInventory.add(lemon);
                    cashOnHand -= lemonSalePrice/2;

                }
            }
            // Sugar
            for (int i = 0; i < sugarSoldToday; i++)
            {
                for (int j = 0; j < inventoryBumpForSales; j++)
                {
                    Ingredient sugar = new Sugar();
                    sugarInventory.add(sugar);
                    cashOnHand -= sugarSalePrice / 2;
                }
            }
            // Ice
            for (int i = 0; i < iceSoldToday; i++)
            {
                for (int j = 0; j < inventoryBumpForSales; j++)
                {
                    Ingredient ice = new Ice();
                    iceInventory.add(ice);
                    cashOnHand -= iceSalePrice / 2;
                }
            }
            // Cup
            for (int i = 0; i < cupSoldToday; i++)
            {
                for (int j = 0; j < inventoryBumpForSales; j++)
                {
                    Ingredient cup = new Cups();
                    cupInventory.add(cup);
                    cashOnHand -= cupSalePrice / 2;
                }
            }



            //
            // Update Prices based off the day's sales.
            //
            // Lemons
            if (this.lemonsSoldToday == 0)
            {
                this.lemonSalePrice -= .01f;
            }
            else
            {
                this.lemonSalePrice += .01f * this.lemonsSoldToday;
            }
            // Sugar
            if (this.sugarSoldToday == 0)
            {
                this.sugarSalePrice -= .01f;
            }
            else
            {
                this.sugarSalePrice += .01f * this.sugarSoldToday;
            }
            // Ice
            if (this.iceSoldToday == 0)
            {
                this.iceSalePrice -= .01f;
            }
            else
            {
                this.iceSalePrice += .01f * this.iceSoldToday;
            }
            // Cups
            if (this.cupSoldToday == 0)
            {
                this.cupSalePrice -= .01f;
            }
            else
            {
                this.cupSalePrice += .01f * this.cupSoldToday;
            }

            //
            // Calculate Todays Fixed Operating Cost
            //
            float dailyHardCost = 50f;
            this.cashOnHand -= dailyHardCost;


            //
            // Reset Daily Sales Count
            //
            this.lemonsSoldToday = 0;
            this.sugarSoldToday = 0;
            this.iceSoldToday = 0;
            this.cupSoldToday = 0;
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
            shipment.DaysToDelivery = 0;
            return shipment;
        }

        public Shipment createShipment(SugarOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Sugar());
            }
            shipment.DaysToDelivery = 0;
            return shipment;
        }
        public Shipment createShipment(IceOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Ice());
            }
            shipment.DaysToDelivery = 0;
            return shipment;
        }

        public Shipment createShipment(CupsOrder order)
        {
            Shipment shipment = new Shipment();
            for (int i = 0; i < order.getQuantity(); i++)
            {
                shipment.AddLemons(new Cups());
            }
            shipment.DaysToDelivery = 0;
            return shipment;
        }






    }
}
