using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle:Motorcycle
    {
        const double defaultFuelConsumption = 8;
        public override double FuelConsumption
        {
            get { return defaultFuelConsumption; }
        }
        public RaceMotorcycle(int hp, double fuel) : base(hp, fuel)
        {

        }
    }
}
