﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ingredient
    {
        public int daysExpire;

        public int DaysExpire
        {
            get
            { 
                return daysExpire; 
            }

            set 
            {
                daysExpire = value;
            }
        }

        public void subtractDay()
        {
            daysExpire -= 1;
        }

    }
}
