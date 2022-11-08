using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public class VehicleFactory : IFactor
    {
        public Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double capacity)
        {
            Vehicle vehicle;

            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity,fuelConsumption, capacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, capacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, capacity);
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle!");
            }
            return vehicle;
        }
    }
}
