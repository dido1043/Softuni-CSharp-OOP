using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public string Name { get; protected set; }
        public string FavoriteFood { get; protected set; }
        public Animal(string name, string favFood)
        {
            Name = name;
            FavoriteFood = favFood;
        }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavoriteFood}";
        }
    }
}
