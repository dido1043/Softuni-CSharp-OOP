using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double LitersPerKm { get; }

        double Capacity { get; }
        string DriveEmpty(double distance);
        string Drive(double distance);
        void Refuel(double liters);
    }
}
