using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int EatenFood { get; }
        string HungrinessSound();
        void Eat(IFood food);
        
    }
}
