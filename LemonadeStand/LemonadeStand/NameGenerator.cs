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
                    break;
                case 2:
                    return "Johnson";
                    break;
                case 3:
                    return "Williams";
                    break;
                case 4:
                    return "Brown";
                    break;
                case 5:
                    return "Miller";
                    break;
                case 6:
                    return "Wilson";
                    break;
                case 7:
                    return "Moore";
                    break;
                case 8:
                    return "Taylor";
                    break;
                case 9:
                    return "Anderson";
                    break;
                case 10:
                    return "Jackson";
                    break;
                case 11:
                    return "Harris";
                    break;
                case 12:
                    return "Thompson";
                    break;
                case 13:
                    return "Garcia";
                    break;
                case 14:
                    return "Martinez";
                    break;
                case 15:
                    return "Robinson";
                    break;
                case 16:
                    return "Rodriguez";
                    break;
                case 17:
                    return "Walker";
                    break;
                case 18:
                    return "Young";
                    break;
                case 19:
                    return "King";
                    break;
                case 20:
                    return "Perez";
                    break;
                default:
                    return "Putin";
                    break;

            }
        }
    }
}
