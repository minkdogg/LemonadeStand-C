using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class NameGenerator
    {
        public static Random random = new Random();

 

        public string GenRandomLastName()
        {
            int randomNumber = random.Next(0,20);
            switch (randomNumber)
            {
                case 1:
                    return "Smith";
                case 2:
                    return "Johnson";
                case 3:
                    return "Williams";
                case 4:
                    return "Brown";
                case 5:
                    return "Miller";
                case 6:
                    return "Wilson";
                case 7:
                    return "Moore";
                case 8:
                    return "Taylor";
                case 9:
                    return "Anderson";
                case 10:
                    return "Jackson";
                case 11:
                    return "Harris";
                case 12:
                    return "Thompson";
                case 13:
                    return "Garcia";
                case 14:
                    return "Martinez";
                case 15:
                    return "Robinson";
                case 16:
                    return "Rodriguez";
                case 17:
                    return "Walker";
                case 18:
                    return "Young";
                case 19:
                    return "King";
                case 20:
                    return "Perez";
                default:
                    return "Putin";

            }
        }
    }
}
