using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>() { typeof(Meat)};

        public override string HungrinessSound()
        {
            return "Hoot Hoot";
        }
    }
}
