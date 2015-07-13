using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Ingredient
    {
        protected bool spoiled = false;


        public Lemon():base()
        {
            this.daysExpire = 12; // 12 days to expire as defined by the problem description
        }
    }
}
