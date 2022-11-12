using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.4;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>() 
        {typeof(Meat) };

        public override string HungrinessSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return base.ToString() +
                $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.EatenFood}]"; 
        }
    }
}
