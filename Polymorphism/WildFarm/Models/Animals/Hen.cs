using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.35;

        public override IReadOnlyCollection<Type> PrefferedFoods => new HashSet<Type>() 
        { typeof(Meat), typeof(Fruit),typeof(Vegetable),typeof(Seeds)};

        public override string HungrinessSound()
        {
            return "Cluck";
        }
    }
}
