using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        //Car model
        private const double increment = 0.9;
        public Car(double fuelQuantity, double litersPerKm, double capacity) : base(fuelQuantity, litersPerKm, capacity, increment)
        {

        }

    }
}
