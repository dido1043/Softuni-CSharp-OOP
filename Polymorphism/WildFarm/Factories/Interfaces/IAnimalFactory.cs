using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        Animal Animal(string[] arr);
    }
}
