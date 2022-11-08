using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Interfaces
{
    public class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double litersPerKm;
        private double capacity;
        public Vehicle(double fuelQuantity, double litersPerKm,double capacity, double increment)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKm = litersPerKm + increment;
            Capacity = capacity;
        }

        public double FuelQuantity { get { return this.fuelQuantity; } private set { this.fuelQuantity = value; } }

        public double LitersPerKm { get { return this.litersPerKm; } private set { this.litersPerKm = value; } }

        public double Capacity { get { return this.capacity; } private set { this.capacity = value; } }

        public string Drive(double distance)
        {

            double neededFuel = distance * this.LitersPerKm;
            if (neededFuel > this.FuelQuantity)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public string DriveEmpty(double distance)
        {            
            if (distance > this.FuelQuantity)
            {
                throw new Exception($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= distance;
            return $"{this.GetType().Name} travelled {distance} km";
        }



        public virtual void Refuel(double liters)
        {

            if (this.fuelQuantity + liters >= this.capacity || liters >= this.capacity)
            {
                throw new Exception($"Cannot fit {liters} fuel in the tank");
            }
            if (this.GetType().Name == "Truck")
            {
                liters = liters * 0.95;
            }
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}"; 
        }
    }
}
 