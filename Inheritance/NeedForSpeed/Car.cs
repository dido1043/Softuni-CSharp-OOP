using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text;

namespace NeedForSpeed
{
    public class Car:Vehicle
    {
        const double defaultFuelConsumption = 3;
        public override double FuelConsumption
        {
            get { return defaultFuelConsumption; }
        }
        public Car(int hp, double fuel):base(hp, fuel)
        {

        }
    }
}
