using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace LemonadeStand
{
    public class Supplier : IUpdate 
    {
        protected Inventory inventory;
        protected float cashOnHand;
        protected GeoCoordinate Location;





        public GeoCoordinate Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = ValueType;
            }
        }



        public override void update()
        {
            inventory.update();

        }



    }
}
