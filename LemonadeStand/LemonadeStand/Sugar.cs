using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    
    public class Sugar : Ingredient
    {
        protected bool spoiled = false;

        public Sugar():base()
        {
            this.daysExpire = 14; // 14 days to expire as defined by the problem description
        }
        
    }


}
