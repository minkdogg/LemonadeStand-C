using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LemonadeStand
{
    public class Weather
    {
        protected double temperature;
        protected string precipitation;
        protected double demandLevel;
        protected double sunnyFactor = 1.2;
        protected double rainyFactor = .8;

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
                this.demandLevel = temperature * sunnyFactor;
                
            }
            else if (this.precipitation == "Cloudy")
            {
                this.demandLevel = temperature;
            }
            else
            {
                this.demandLevel = temperature * rainyFactor;
            }
        }

        public double Temperature
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

        public double DemandLevel
        {
            get
            {
                return demandLevel;
            }
        }
    }
}
