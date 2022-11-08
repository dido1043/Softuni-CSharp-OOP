using System;
using System.Data;
using System.IO;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Engine
{
    public class Enginee : IEngine
    {
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;
        public Enginee(Vehicle car, Vehicle truck,Vehicle bus)
        {
            this.car = car;
            this.truck = truck;
            this.bus = bus;
        }

        public void RunEngine()
        {
            //Logic of code
            int n = int.Parse(Console.ReadLine());
            string[] command;
            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine().Split(" ");
                try
                {
                    if (double.Parse(command[2]) <= 0)
                    {
                        throw new Exception("Fuel must be a positive number");
                    }
                    if (command[0] == "Drive")
                    {
                        if (command[1] == "Car")
                        {
                            Console.WriteLine(this.car.Drive(double.Parse(command[2])));
                        }
                        else if (command[1] == "Truck")
                        {
                            Console.WriteLine(this.truck.Drive(double.Parse(command[2])));
                        }
                        else if (command[1] == "Bus")
                        {
                            Console.WriteLine(this.bus.Drive(double.Parse(command[2])));
                        }
                    }

                    if (command[0] == "DriveEmpty")
                    {
                        if (command[1] == "Car")
                        {
                            Console.WriteLine(this.car.DriveEmpty(double.Parse(command[2])));
                        }
                        else if (command[1] == "Truck")
                        {
                            Console.WriteLine(this.truck.DriveEmpty(double.Parse(command[2])));
                        }
                        else if (command[1] == "Bus")
                        {
                            Console.WriteLine(this.bus.DriveEmpty(double.Parse(command[2])));
                        }
                    }
                    if (command[0] == "Refuel")
                    {
                        if (command[1] == "Car")
                        {
                            this.car.Refuel(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            this.truck.Refuel(double.Parse(command[2]));

                        }
                        else if (command[1] == "Bus")
                        {
                            this.bus.Refuel(double.Parse(command[2]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }
    }
}
