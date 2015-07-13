using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        protected int temperature;
        protected string precipitation;
        protected decimal demandLevel;

        public Weather()
        {
            Random rnd1 = new Random();
            this.temperature = rnd1.Next(65, 110);

            Random rnd2 = new Random();
            int precipAssigner = rnd2.Next(1, 3);
            if (precipAssigner == 1)
            {
                this.precipitation = "Sunny";
            }
            else if (precipAssigner == 2)
            {
                this.precipitation = "Cloudy";
            }
            else
            {
                this.precipitation = "Rainy";
            }

            /*DEMAND GENERATOR*/
            if (this.precipitation == "Sunny")
            {
                this.demandLevel = Decimal.ToDecimal(temperature) * 1.2;
            }
            else if (this.precipitation == "Cloudy")
            {
                this.demandLevel = Decimal.ToDecimal(this.temperature);
            }
            else
            {
                this.demandLevel = Decimal.ToDecimal(temperature) * 0.8;
            }
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }
        }

        public string Precipitation
        {
            get
            {
                return precipitation;
            }
        }

        public decimal DemandLevel
        {
            get
            {
                return demandLevel;
            }
        }
    }
}
