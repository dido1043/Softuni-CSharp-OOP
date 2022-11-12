using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Felines : Mammal
    {
        public Felines(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }
        public override string ToString()
        {
            return base.ToString() +
                $"{this.GetType()} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.EatenFood}]";
        }
    }
}
