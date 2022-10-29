using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        const double defaultFuelConsumption = 1.25;
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        //!!!
        public double DefaultFuelConsumption 
        {
            get { return defaultFuelConsumption; }
        }
        public virtual double FuelConsumption { get { return this.DefaultFuelConsumption; } }
        public Vehicle(int hoursePower, double fuel)
        {
            this.HorsePower = hoursePower;
            this.Fuel = fuel;
        }
        public virtual void Drive(double kilometers)
        {
            this.Fuel -= this.FuelConsumption * kilometers;
        }

    }
}
