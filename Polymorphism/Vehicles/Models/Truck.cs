using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        //Truck model 
        private const double increment = 1.6;
        public Truck(double fuelQuantity, double litersPerKm,double capacity) : base(fuelQuantity, litersPerKm,capacity, increment)
        {

        }
        public override void Refuel(double liters)
        {
            base.Refuel(liters);
        }
    }
}
