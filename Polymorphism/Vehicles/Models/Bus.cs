using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Bus:Vehicle
    {
        private const double increment = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double capacity) :base(fuelQuantity, litersPerKm, capacity, increment)
        {

        }
    }
}
