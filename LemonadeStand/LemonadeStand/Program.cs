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

            Player player = new Player(userName);
        }
    }
}
