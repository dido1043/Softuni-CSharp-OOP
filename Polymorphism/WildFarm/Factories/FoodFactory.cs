using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public Food Food(string typeOfFood, int quantity)
        {
            Food food = null;
            if (typeOfFood == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (typeOfFood == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (typeOfFood == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (typeOfFood == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else { throw new Exception(String.Format(ErrorMessages.InvalidFood)); }
            return food;
        }

    }
}
