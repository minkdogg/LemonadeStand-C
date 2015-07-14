using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : Ingredient
    {
        protected bool melted = false;

        public Ice():base()
        {
            this.daysExpire = 3; // 3 days to expire as defined by the problem description
        }
    }
}
