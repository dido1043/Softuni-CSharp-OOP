using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        const double defaultFuelConsumption = 10;
        public override double FuelConsumption
        {
            get { return defaultFuelConsumption; }
        }
        public SportCar(int hp, double fuel) : base(hp, fuel)
        {

        }
    }
}
