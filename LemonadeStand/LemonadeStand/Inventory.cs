using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory : IUpdate
    {
        protected List<Ingredient> ingredientList;

        public void update()
        {
            for (int i = 0; i < this.ingredientList.Count; i++)
            {
                this.ingredientList[i].daysExpire -= 1;
            }
        }

        public Inventory()
        {
            this.ingredientList = new List<Ingredient> { };

            
        }

        public List<Ingredient> getInventory()
        {
            return this.ingredientList;
        }



        public void setInventory(List<Ingredient> ingredients)
        {
            this.ingredientList = ingredients;
        }


        public void add(Ingredient ingredients)
        {
            this.ingredientList.Add(ingredients);
        }

      



    }
}
