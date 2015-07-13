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



    }
}
