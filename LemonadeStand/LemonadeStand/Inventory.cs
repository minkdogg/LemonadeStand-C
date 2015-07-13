using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Inventory : IUpdate
    {
        List<Ingredient> ingredientList;

        public void update(List<Ingredient> ingredientList )
        {
            for (int i = 0; i < ingredientList.Count; i++)
            {
                ingredientList[i].daysExpire -= 1;
            }
        }

          public Inventory(List<Ingredient> ingredients)
        {
            this.ingredientList = ingredients;
            
        }

        public List<Ingredient> getIngredients()
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
                ingredientList.Add(ingredients[i]);
            }

        }



    }
}
