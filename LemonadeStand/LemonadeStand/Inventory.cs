using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Inventory : IUpdate
    {
        protected List<Ingredient> ingredientList;

        public void update()
        {
            for (int i = 0; i < this.ingredientList.Count; i++)
            {
                this.ingredientList[i].daysExpire -= 1;
            }
        }

        public Inventory(List<Ingredient> ingredients)
        {
            this.ingredientList = ingredients;

            
        }

        public List<Ingredient> getInventory()
        {
            return this.ingredientList;
        }



        public void setInventory(List<Ingredient> ingredients)
        {
            this.ingredientList = ingredients;
        }


        public void add(List<Ingredient> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                this.ingredientList.Add(ingredients[i]);
            }

        }



    }
}
