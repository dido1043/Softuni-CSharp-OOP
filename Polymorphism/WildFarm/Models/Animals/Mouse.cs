using System;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.1;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>(){typeof(Fruit), typeof(Vegetable)};

        public override string HungrinessSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return base.ToString() +
                $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.EatenFood}]";
        }
    }
}
