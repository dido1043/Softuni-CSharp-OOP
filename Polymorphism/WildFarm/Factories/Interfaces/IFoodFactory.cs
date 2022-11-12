using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Factories.Interfaces
{
    public interface IFoodFactory
    {
        Food Food(string typeOfFood, int quantity);
    }
}
