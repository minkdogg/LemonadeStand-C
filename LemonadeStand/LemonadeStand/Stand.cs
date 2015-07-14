using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace LemonadeStand
{
    public class Stand : IUpdate
    {

        public int days = 0;
        public float cash;
        public string location;
        protected List<Lemon> lemonList = new List<Lemon> { };
        protected List<Sugar> sugarList = new List<Sugar> { };
        protected List<Ice> iceList = new List<Ice>() { };
        protected List<Cups> cupList = new List<Cups> { };


        public void update()
        {
            days += 1;
            
            List<int> lemonListIndex = new List<int> { };
            for (int i = 0; i< lemonList.Count(); i++)
            {
                lemonList[i].subtractDay();
                if (lemonList[i].daysExpire <= 0)
                {
                    lemonListIndex.Add(i);
                }
            }
            foreach (int index in lemonListIndex)
            {
                lemonList.RemoveAt(0);
            }

                foreach (Sugar sugar in sugarList)
                {
                    sugar.subtractDay();
                    if (sugar.daysExpire == 0)
                    {
                        sugarList.Remove(sugar);
                    }
                }

            foreach (Ice ice in iceList)
            {
                ice.subtractDay();
                if (ice.daysExpire == 0)
                {
                    iceList.Remove(ice);
                }
            }

            foreach (Cups cup in cupList)
            {
                cup.subtractDay();
                if (cup.daysExpire == 0)
                {
                    cupList.Remove(cup);
                }
            }

        }

        public float getCash()
        {
            return cash;
        }

        public float calculateTotal(int customers, float price)
        {

            int cupsAvailable = getMinimumAvailable();
            float total;
            
            
            if (customers > cupsAvailable)
            {
                
                total = cupsAvailable * price;
                addCash(total);
                
            }
            else
            {
                total = customers * price;
                addCash(total);
                int lastItem = customers - cupsAvailable;
                int cupsSold = customers;
            }

            for (int i = 0; i < cupsAvailable; i++)
            {
                lemonList.RemoveAt(0);
                sugarList.RemoveAt(0);
                iceList.RemoveAt(0);
                cupList.RemoveAt(0);
            }

            return total;  
        }

        public int calculateTotalSold(int customers)
        {

            int cupsAvailable = getMinimumAvailable();
            int totalSold;


            if (customers > cupsAvailable)
            {
                totalSold = cupsAvailable;
            }
            else
            {
                totalSold = customers;
            }

            return totalSold;
        }

        public int getMinimumAvailable()
        {
            List<int> minList = new List<int> { };
            minList.Add(getLemonCount());
            minList.Add(getSugarCount());
            minList.Add(getIceCount());
            minList.Add(getCupCount());

            return minList.Min();
        }

        public void addLemonShipment(Shipment shipLemons)
        {
            foreach (Lemon lemon in shipLemons.lemonList)
            {
                lemonList.Add(lemon);
            }
        }

        public void addSugarShipment(Shipment shipSugar)
        {
            foreach (Sugar sugar in shipSugar.sugarList)
            {
                sugarList.Add(sugar);
            }
        }

        public void addIceShipment(Shipment shipIce)
        {
            foreach (Ice ice in shipIce.iceList)
            {
                iceList.Add(ice);
            }
        }

        public void addCupShipment(Shipment shipCup)
        {
            foreach (Cups cup in shipCup.cupList)
            {
                cupList.Add(cup);
            }
        }

     
        public void addCash(float newCash)
        {
            cash += newCash;
        }

        public void withdrawCash(float newCash)
        {
            cash -= newCash;
        }




        public bool checkifZero()
        {
            if (cash <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

          public Stand (string standLocation)
        {
            this.cash = 500;
            this.location = standLocation;
        }

         public int getLemonCount()
         {
             int countList = lemonList.Count();
             return countList;
         }

         public int getIceCount()
         {
             int countList = iceList.Count();
             return countList;
         }

         public int getCupCount()
         {
             int countList = cupList.Count();
             return countList;
         }

         public int getSugarCount()
         {
             int countList = sugarList.Count();
             return countList;
         }
    }
    
}
