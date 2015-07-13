using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            string standLocation;
            string price;
            string quantityCups;
            bool gameCheck = true;
            double customerFloor;
            int customerFloorInt;
            int customerSelling;
            float sugarSalePrice;
            float lemonSalePrice;
            float iceSalePrice;
            float cupSalePrice;
            string supplierChoice;
            string lemonChoice;
            string iceChoice;
            string sugarChoice;
            string cupsChoice;
            Supplier selectedSupplier = new Supplier();



            Console.WriteLine("Welcome to the curb kid.");
            Console.WriteLine("You'll have to be tough to make it in this business");
            Console.WriteLine("You've got one stand, an inventory of cups, lemons, sugar, ice,");
            Console.WriteLine("and a lemonade thirsty public.");
            Console.WriteLine("Nothing comes free or easy, though, and you'll have to purchase and managed your inventory.");
            Console.WriteLine("You've got a list of suppliers that may offer different prices, and not all of them are located near by.");
            Console.WriteLine("You'll have to keep an eye on your inventory costs, and shipping times to be sure you're always supplied and always have cash.");
            Console.WriteLine("Your inventory items will also expire if they're too old.");
            Console.WriteLine(".. and you'll have to watch your suppliers bottomline.");
            Console.WriteLine("If they get too low on cash they're out of business, and you lose that supplier option.");
            Console.WriteLine("The price you set for your lemonade, and the weather will have an important influence on how many people will be willing to buy.");
            Console.WriteLine(" ");
            Console.WriteLine("... so if you think you're ready to make some cold hard lemonade cash enter your name, and let's get started:");
            
            userName = Console.ReadLine();
            
            Console.WriteLine("Where are you going to set up your stand?");
            standLocation = Console.ReadLine();

            Player player = new Player(userName, standLocation);
            

            //Create initial suppliers and prices for inventory list
            var customerNum = new Random();
            List<Supplier> supplierList = new List<Supplier> { };

            int rInt = customerNum.Next(2, 5);
            for (int i = 0; i < rInt; i ++ )
            {
                Supplier supplier = new Supplier();
                supplierList.Add(supplier);
               
            }
                Console.ReadLine();
            
            //Day Generation
            while(gameCheck == true)
            {
                Weather weather = new Weather();
                var customerNumber = new Random();
                
                List<Customer> customerList = new List<Customer> { };
                customerFloor = Math.Floor(weather.DemandLevel);
                customerFloorInt = Convert.ToInt32(customerFloor);

                //customer loop
                int customerInt = customerNumber.Next(0, customerFloorInt);
                for (int i = 0; i < customerInt; i++)
                {
                    Customer customer = new Customer(weather);
                    customerList.Add(customer);
                }

                customerSelling = customerList.Count();

                Console.WriteLine("The temperature outside is " + weather.Temperature);

                for (int i = 0; i < rInt; i++)
                {
                    lemonSalePrice = supplierList[i].getLemonPrice();
                    cupSalePrice = supplierList[i].getCupPrice();
                    sugarSalePrice = supplierList[i].getSugarPrice();
                    iceSalePrice = supplierList[i].getIcePrice();
                    Console.WriteLine("Name: " + supplierList[i].Name);
                    Console.WriteLine("Sugar Price: " + sugarSalePrice);
                    Console.WriteLine("Lemon Price: " + lemonSalePrice);
                    Console.WriteLine("Ice Price: " + iceSalePrice);
                    Console.WriteLine("Cup Price: " + cupSalePrice);
                    Console.WriteLine("");
                    
                }

                Console.WriteLine("Which supplier would you like to buy from?");
                supplierChoice = Console.ReadLine();
                foreach(Supplier supplier in supplierList){
                    if (supplier.Name == supplierChoice){
                        selectedSupplier = supplier;
                        break;
                    }
                }
                


                Console.WriteLine("How much sugar would you like?");
                sugarChoice = Console.ReadLine();

                if (Convert.ToInt32(sugarChoice) > 0)
                {
                    SugarOrder sugar = new SugarOrder(Convert.ToInt32(sugarChoice));
                    selectedSupplier.createShipment(sugar);
                }
                

                Console.WriteLine("How many cups would you like?");
                cupsChoice = Console.ReadLine();
                if (Convert.ToInt32(cupsChoice) > 0)
                {
                    CupsOrder cups = new CupsOrder(Convert.ToInt32(cupsChoice));
                    selectedSupplier.createShipment(cups);
                }

                Console.WriteLine("How many lemons would you like?");
                lemonChoice = Console.ReadLine();
                if (Convert.ToInt32(lemonChoice) > 0)
                {
                    LemonOrder lemon = new LemonOrder(Convert.ToInt32(lemonChoice));
                    selectedSupplier.createShipment(lemon);
                }

                Console.WriteLine("How much ice would you like?");
                iceChoice = Console.ReadLine();
                {
                    IceOrder ice = new IceOrder(Convert.ToInt32(iceChoice));
                    selectedSupplier.createShipment(ice);
                }
                Console.ReadLine();





               
                

       
                Console.WriteLine("What price would you like to sell your lemonade?");
                price = Console.ReadLine();
                Console.WriteLine("How many cups of lemonade would you like to make?");
                quantityCups = Console.ReadLine();

                gameCheck = player.stand.checkifZero();



            }
            
            
            

        }
    }
}
