using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories
{
    public interface IFactor
    {
        Vehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double capacity);
    }
}
