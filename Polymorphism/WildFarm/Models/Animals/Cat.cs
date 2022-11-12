using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Felines
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.3;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>() { typeof(Meat), typeof(Vegetable)};

        public override string HungrinessSound()
        {
            return "Meow";
        }
    }
}
