using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Order
    {
        public int quantity;
        public Order(int quantity)
        {
            this.quantity = quantity;
        }

        public int getQuantity()
        {
            return this.quantity;
        }
    }
}
