using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int EatenFood { get; private set; }
        private Animal()
        {
            this.EatenFood = 0;
        }
        public Animal(string name, double weight):this()
        {
            Name = name;
            Weight = weight;
        }

        public abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PrefferedFoods { get; }
        public abstract string HungrinessSound();
        public void Eat(IFood food)
        {
            if (!this.PrefferedFoods.Any(x => food.GetType().Name == x.Name))
            {
                throw new Exception(string.Format(ErrorMessages.ErrorFood,this.GetType().Name,food.GetType().Name));
            }
            this.Weight += food.Quantity * this.WeightMultiplier;
            this.EatenFood += food.Quantity;
        }
    }
}
