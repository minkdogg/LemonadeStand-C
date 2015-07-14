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
            float price;
            int quantityCups;
            bool gameCheck = false;
            double customerFloor;
            int customerFloorInt;
            int customerSelling;
            float sugarSalePrice;
            float lemonSalePrice;
            float iceSalePrice;
            float cupSalePrice;
            string supplierChoice;
            int lemonChoice;
            int iceChoice;
            int sugarChoice;
            int cupChoice;
            float supplyCosts = 0;
            
            Supplier selectedSupplier = new Supplier();
            var timeOfDay = DateTime.Now.TimeOfDay;
            var hourOfDay = timeOfDay.Hours;
            bool timeOfDayCheck;
            int beginningOfDay = 5;
            int endOfDay = 20;


            if (hourOfDay >= beginningOfDay && hourOfDay <= endOfDay)
            {
                timeOfDayCheck = true;
                Console.WriteLine("It's light outside, you can sell lemonade.");

            }
            else
            {
                timeOfDayCheck = false;
                Console.WriteLine("It's dark outside, you can't sell lemonade. Come back later when it's light ouside.");
                Console.ReadLine();

            }
            
            while(timeOfDayCheck == true)
            
            {


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
            Console.Write("Name: ");
            
            userName = Console.ReadLine();
            
            Console.Write("Where are you going to set up your stand? ");
            standLocation = Console.ReadLine();

            Player player = new Player(userName, standLocation);
            

            //Create initial suppliers and prices for inventory list
            var supplierNum = new Random();
            List<Supplier> supplierList = new List<Supplier> { };

            int rInt = supplierNum.Next(2, 5);
            for (int i = 0; i < rInt; i ++ )
            {
                Supplier supplier = new Supplier();
                supplierList.Add(supplier);
            }
            
            
            //Day Generation
            while(gameCheck == false)
            {
                // Show stats for the day.
                Console.Clear();
                Console.WriteLine("Day " + player.stand.days);
                Console.WriteLine("Welcome " + player.PlayerName + " Here are your stats");
                Console.WriteLine("========================================================");
                Console.WriteLine("Cash:   " + player.stand.getCash());
                Console.WriteLine("Lemons: " + player.stand.getLemonCount());
                Console.WriteLine("Ice:    " + player.stand.getIceCount());
                Console.WriteLine("Sugar:  " + player.stand.getSugarCount());
                Console.WriteLine("Cups:   " + player.stand.getCupCount());
                Console.WriteLine("");

                // Create New Weather for the day
                Weather weather = new Weather();
                Console.WriteLine("Forecast: The temperature outside is " + weather.Temperature + " and it is "+ weather.Precipitation);
                Console.WriteLine("");

                // Show Supplier prices for Supplies
                Console.WriteLine("Supplier Information");

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
                foreach(Supplier supplier in supplierList)
                {
                    Console.Write(supplier.Name + " | ");
                }
                supplierChoice = Console.ReadLine();
                bool supplierCheck = false;
                while (supplierCheck == false)
                {
                    foreach (Supplier supplier in supplierList)
                    {
                        if (supplier.Name == supplierChoice)
                        {
                            selectedSupplier = supplier;
                            supplierCheck = true;
                            break;
                        }
                }
                    if (supplierCheck == false)
                    {
                        Console.WriteLine("Supplier not found, please re-enter supplier name.");
                        Console.WriteLine("Which supplier would you like to buy from?");
                        foreach (Supplier supplier in supplierList)
                        {
                            Console.Write(supplier.Name + " | ");
                        }
                        supplierChoice = Console.ReadLine();
                    }
                }
                

                //Sugar Purchase
                Console.WriteLine("How much sugar would you like?<cash on hand: " + player.stand.getCash() + ">");
                float supplierSugarPrice = selectedSupplier.getSugarPrice();
                string sugarCheckUser = Console.ReadLine();
                bool sugarCheck = true;
                while (sugarCheck == true)
                {
                    if (Int32.TryParse(sugarCheckUser, out sugarChoice))
                    {
                        float sugarCost = supplierSugarPrice * sugarChoice;
                        if (sugarChoice >= 0 && sugarCost <= player.stand.getCash())
                        {
                            SugarOrder sugar = new SugarOrder(Convert.ToInt32(sugarChoice));
                            Shipment sugarShipment = selectedSupplier.createShipment(sugar);
                            player.stand.addSugarShipment(sugarShipment);
                            player.stand.withdrawCash(sugarCost);
                            supplyCosts += sugarCost; 
                            sugarCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Amount. How much sugar would you like?<cash on hand: " + player.stand.getCash() + ">");
                            sugarCheckUser = Console.ReadLine();
                        }    
                    }
                    else
                    {
                        Console.WriteLine("Invalid number entered. Please enter number in format: #.##");
                        Console.WriteLine("How much sugar would you like?<cash on hand: " + player.stand.getCash() + ">");
                        sugarCheckUser = Console.ReadLine();
                    }
                }


                //Cup Purchase
                Console.WriteLine("How many cups would you like?<cash on hand: " + player.stand.getCash() + ">");
                float supplierCupPrice = selectedSupplier.getCupPrice();
                string cupCheckUser = Console.ReadLine();
                bool cupCheck = true;
                while (cupCheck == true)
                {
                    if (Int32.TryParse(cupCheckUser, out cupChoice))
                    {
                        float cupCost = supplierCupPrice * cupChoice;
                        if (cupChoice >= 0 && cupCost <= player.stand.getCash())
                        {
                            CupsOrder cups = new CupsOrder(Convert.ToInt32(cupChoice));
                            Shipment cupShipment = selectedSupplier.createShipment(cups);
                            player.stand.addCupShipment(cupShipment);
                            player.stand.withdrawCash(cupCost);
                            supplyCosts += cupCost;
                            cupCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Amount. How many cups would you like?<cash on hand: " + player.stand.getCash() + ">");
                            cupCheckUser = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number entered. Please enter number in format: #.##");
                        Console.WriteLine("How many cups would you like?<cash on hand: " + player.stand.getCash() + ">");
                        cupCheckUser = Console.ReadLine();
                    }
                }

                //Lemon Purchase
                Console.WriteLine("How many lemons would you like?<cash on hand: " + player.stand.getCash() + ">");
                float supplierLemonPrice = selectedSupplier.getLemonPrice();
                string lemonCheckUser = Console.ReadLine();
                bool lemonCheck = true;
                while (lemonCheck == true)
                {
                    if (Int32.TryParse(lemonCheckUser, out lemonChoice))
                    {
                        float lemonCost = supplierLemonPrice * lemonChoice;
                        if (lemonChoice >= 0 && lemonCost <= player.stand.getCash())
                        {
                            LemonOrder lemons = new LemonOrder(Convert.ToInt32(lemonChoice));
                            Shipment lemonShipment = selectedSupplier.createShipment(lemons);
                            player.stand.addLemonShipment(lemonShipment);
                            player.stand.withdrawCash(lemonCost);
                            supplyCosts += lemonCost;
                            lemonCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Amount. How many lemons would you like?<cash on hand: " + player.stand.getCash() + ">");
                            lemonCheckUser = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number entered. Please enter number in format: #.##");
                        Console.WriteLine("How many lemons would you like?<cash on hand: " + player.stand.getCash() + ">");
                        lemonCheckUser = Console.ReadLine();
                    }
                }

                //Ice Purchase
                Console.WriteLine("How much ice would you like?<cash on hand: " + player.stand.getCash() + ">");
                float supplierIcePrice = selectedSupplier.getIcePrice();
                string iceCheckUser = Console.ReadLine();
                bool iceCheck = true;
                while (iceCheck == true)
                {
                    if (Int32.TryParse(iceCheckUser, out iceChoice))
                    {
                        float iceCost = supplierIcePrice * iceChoice;
                        if (iceChoice >= 0 && iceCost <= player.stand.getCash())
                        {
                            IceOrder ice = new IceOrder(Convert.ToInt32(iceChoice));
                            Shipment iceShipment = selectedSupplier.createShipment(ice);
                            player.stand.addIceShipment(iceShipment);
                            player.stand.withdrawCash(iceCost);
                            supplyCosts += iceCost;
                            iceCheck = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Amount. How much ice would you like?<cash on hand: " + player.stand.getCash() + ">");
                            iceCheckUser = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number entered. Please enter number in format: #.##");
                        Console.WriteLine("How much ice would you like?<cash on hand: " + player.stand.getCash() + ">");
                        iceCheckUser = Console.ReadLine();
                    }
                }
                

                
                              
                //Create Lemonade Price
                Console.WriteLine("What price would you like to sell your lemonade?");
                string priceString = Console.ReadLine();
                bool priceCheck = true;
                float floatPrice;
                while (priceCheck == true)
                {
                    if (Single.TryParse(priceString, out floatPrice))
                    {
                        priceCheck = false;
                        price = Convert.ToSingle(priceString);
                    }
                    else
                    {
                        
                        Console.WriteLine("What price would you like to sell your lemonade?");
                        priceString = Console.ReadLine();
                    }
                }
                price = Convert.ToSingle(priceString);
               

                //Create Customers and whether they buy
                var customerNumber = new Random();

                List<Customer> customerList = new List<Customer> { };
                List<Customer> customerBuyList = new List<Customer> { };
                customerFloor = Math.Floor(weather.DemandLevel);
                customerFloorInt = Convert.ToInt32(customerFloor);

                
                int customerInt = customerNumber.Next(0, customerFloorInt);
                for (int i = 0; i < customerInt; i++)
                {
                    Customer customer = new Customer(weather,price,player,player.stand);
                    customerList.Add(customer);
                }

                
                foreach(Customer customer in customerList)
                {
                    var customerBuy = new Random();
                    var customerToBuy = customerBuy.Next(0, 100);
                    if(customer.buyChance > customerToBuy)
                    {
                        customerBuyList.Add(customer);
                    }
                }
                int minAllowed = player.stand.getMinimumAvailable();
                customerSelling = customerBuyList.Count();

                Console.WriteLine("How many cups of lemonade would you like to make? <" + minAllowed + "> Max");
                quantityCups = Convert.ToInt32(Console.ReadLine());
                while (quantityCups > minAllowed)
                {
                    Console.WriteLine("Can't make requested amount, please enter new amount.");
                    Console.WriteLine("How many cups of lemonade would you like to make? <" + minAllowed + "> Max");
                    quantityCups = Convert.ToInt32(Console.ReadLine());
                }

                int daySold = player.stand.calculateTotalSold(customerSelling);
                float dayTotal = player.stand.calculateTotal(customerSelling,price);
                
                // Update day and display summary
                player.stand.update();
                foreach (Supplier supplier in supplierList)
                {
                    supplier.update();
                }
                
                Console.WriteLine("You sold " + daySold + " cups for a total of " + dayTotal + " dollars while spending " + supplyCosts + " on supplies.");
                Console.WriteLine("You have " + player.stand.getCash() + " remaining.");
                Console.ReadLine();

                // check if game over
                gameCheck = player.stand.checkifZero();

            }
           }

        }
    }
}
