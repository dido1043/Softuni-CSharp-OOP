using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Felines
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 1;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>() { typeof(Meat) };

        public override string HungrinessSound()
        {
            return "ROAR!!!";
        }
    }
}
